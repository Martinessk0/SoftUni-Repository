namespace TeisterMask.DataProcessor
{
    using System;
    using System.Globalization;
    using System.Linq;
    using Data;
    using Newtonsoft.Json;
    using TeisterMask.DataProcessor.ExportDto;
    using TeisterMask.DataProcessor.XmlHelper;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportProjectWithTheirTasks(TeisterMaskContext context)
        {
            const string root = "Projects";

            var projects=context.Projects
               .Where(p => p.Tasks.Any())
               .ToArray()
               .Select(p => new ProjectsExportModelDto()
               {
                   Name = p.Name,
                   HasEndDate = p.DueDate.HasValue ? "Yes" : "No",
                   TasksCount = p.Tasks.Count,
                   Tasks = p.Tasks
                    .ToArray()
                    .Select(t => new ProjectTasksExportModelDto()
                    {
                        Name = t.Name,
                        Label = t.LabelType.ToString()
                    })
                    .OrderBy(t => t.Name)
                    .ToArray()
               })
            .OrderByDescending(p => p.TasksCount)
            .ThenBy(p => p.Name)
            .ToArray();

            var xmlResult = XmlConverter.Serialize<ProjectsExportModelDto>(projects, root);
            return xmlResult;
        }

        public static string ExportMostBusiestEmployees(TeisterMaskContext context, DateTime date)
        {
            var employees = context.Employees
                .Where(e => e.EmployeesTasks.Any(et => et.Task.OpenDate >= date))
                .ToArray()
                .Select(e => new
                {
                    Username = e.Username,
                    Tasks = e.EmployeesTasks
                    .Where(et => et.Task.OpenDate >= date)
                    .ToArray()
                    .OrderByDescending(t => t.Task.DueDate)
                    .ThenBy(t => t.Task.Name)
                    .Select(t => new
                    {
                        TaskName = t.Task.Name,
                        OpenDate = t.Task.OpenDate.ToString("d", CultureInfo.InvariantCulture),
                        DueDate = t.Task.DueDate.ToString("d", CultureInfo.InvariantCulture),
                        LabelType = t.Task.LabelType.ToString(),
                        ExecutionType = t.Task.ExecutionType.ToString(),
                    })
                    .ToArray(),
                })
                .OrderByDescending(e => e.Tasks.Length)
                .ThenBy(e => e.Username)
                .Take(10)
                .ToArray();
            var jsonResult=JsonConvert.SerializeObject(employees,Formatting.Indented);
            return jsonResult;
        }
    }
}