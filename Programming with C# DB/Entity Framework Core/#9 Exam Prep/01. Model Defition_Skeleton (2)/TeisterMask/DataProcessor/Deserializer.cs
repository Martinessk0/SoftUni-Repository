namespace TeisterMask.DataProcessor
{
    using System;
    using System.Collections.Generic;

    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using Data;
    using Newtonsoft.Json;
    using TeisterMask.Data.Models;
    using TeisterMask.Data.Models.Enums;
    using TeisterMask.DataProcessor.ImportDto;
    using TeisterMask.DataProcessor.XmlHelper;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedProject
            = "Successfully imported project - {0} with {1} tasks.";

        private const string SuccessfullyImportedEmployee
            = "Successfully imported employee - {0} with {1} tasks.";

        public static string ImportProjects(TeisterMaskContext context, string xmlString)
        {
            const string root = "Projects";
            var sb = new StringBuilder();
            var dtoProjects = XmlConverter.Deserializer<ProjectsImportModelDto>(xmlString, root);
            var projects =new List<Project>();
            foreach (var project in dtoProjects)
            {
                if (!IsValid(project))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                DateTime openDate;
                var isOpenDateValid = DateTime.TryParseExact(project.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out openDate);
                if (!isOpenDateValid)
                {
                    sb.AppendLine("Invalid Data!");
                    continue;
                }

                DateTime? dueDate = null;
                if (!string.IsNullOrWhiteSpace(project.DueDate)) 
                {
                    DateTime dueDateDb;
                    var isDueDateValid = DateTime.TryParseExact(project.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dueDateDb);
                    if (!isDueDateValid)
                    {
                        sb.AppendLine("Invalid Data!");
                        continue;
                    }

                    dueDate = dueDateDb;
                }        
                
                var pjo = new Project()
                {
                    Name = project.Name,
                    OpenDate = openDate,
                    DueDate = dueDate,
                };

                foreach (var taskDto in project.Tasks)
                {
                    if (!IsValid(taskDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    DateTime taskOpenDate;
                    bool isTaskOpenDateValid = DateTime.TryParseExact(taskDto.OpenDate, "dd/MM/yyyy",
                        CultureInfo.InvariantCulture, DateTimeStyles.None, out taskOpenDate);

                    if (!isTaskOpenDateValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    DateTime taskDueDate;
                    bool isTaskDueDateValid = DateTime.TryParseExact(taskDto.DueDate, "dd/MM/yyyy",
                        CultureInfo.InvariantCulture, DateTimeStyles.None, out taskDueDate);

                    if (!isTaskDueDateValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (taskOpenDate < openDate)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (dueDate.HasValue && taskDueDate > dueDate.Value)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Task t = new Task()
                    {
                        Name = taskDto.Name,
                        OpenDate = taskOpenDate,
                        DueDate = taskDueDate,
                        ExecutionType = (ExecutionType)taskDto.ExecutionType,
                        LabelType = (LabelType)taskDto.LabelType
                    };

                    pjo.Tasks.Add(t);
                }

                projects.Add(pjo);
                sb.AppendLine($"Successfully imported project - {project.Name} with {pjo.Tasks.Count()} tasks.");
            }
            context.Projects.AddRange(projects);
            context.SaveChanges();
            
            return sb.ToString().TrimEnd();
        }

        public static string ImportEmployees(TeisterMaskContext context, string jsonString)
        {
            var sb = new StringBuilder();
            var employeesDto = JsonConvert.DeserializeObject<EmployeesImportModelDto[]>(jsonString); 
            var employees = new List<Employee>();
            var tasks = context.Tasks.ToList();

            foreach (var employee in employeesDto)
            {
                if (!IsValid(employee))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var e = new Employee()
                {
                    Username = employee.Username,
                    Email = employee.Email,
                    Phone = employee.Phone,
                };
                foreach (var taskId in employee.Tasks.Distinct())
                {
                    var t = tasks.Find(x => x.Id == taskId);

                    if(t == null)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    e.EmployeesTasks.Add(new EmployeeTask()
                    {
                        Task = t
                    });
                }
                employees.Add(e);
                sb.AppendLine($"Successfully imported employee - {e.Username} with {e.EmployeesTasks.Count} tasks.");
                
            }
            context.Employees.AddRange(employees);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}