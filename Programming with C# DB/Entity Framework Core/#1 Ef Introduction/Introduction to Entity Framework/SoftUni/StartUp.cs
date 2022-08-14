using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Microsoft.EntityFrameworkCore;
using SoftUni.Data;
using SoftUni.Models;

namespace SoftUni
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            //var context = new SoftUniContext();
            //Console.WriteLine(GetEmployeesFullInformation(context));
            //var context = new SoftUniContext();
            //Console.WriteLine(GetEmployeesWithSalaryOver50000(context));
            //var context = new SoftUniContext();
            //Console.WriteLine(GetEmployeesFromResearchAndDevelopment(context));
            //var context = new SoftUniContext();
            //Console.WriteLine(AddNewAddressToEmployee(context));
            //var context = new SoftUniContext();
            //Console.WriteLine(GetEmployeesInPeriod(context));
            //var context = new SoftUniContext();
            //Console.WriteLine(GetAddressesByTown(context));
            //var context = new SoftUniContext();
            //Console.WriteLine(GetEmployee147(context));
            //var context = new SoftUniContext();
            //Console.WriteLine(GetDepartmentsWithMoreThan5Employees(context));
            //var context = new SoftUniContext();
            //Console.WriteLine(GetLatestProjects(context));
            //var context = new SoftUniContext();
            //Console.WriteLine(IncreaseSalaries(context));
            //var context = new SoftUniContext();
            //Console.WriteLine(GetEmployeesByFirstNameStartingWithSa(context));
            //var context = new SoftUniContext();
            //Console.WriteLine(DeleteProjectById(context));
            var context = new SoftUniContext();
            Console.WriteLine(RemoveTown(context));
        }
        //StringBuilder sb = new StringBuilder();
        //return sb.ToString().TrimEnd();
        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();
            var employees = context.Employees;
            foreach (var employee in employees.OrderBy(x => x.EmployeeId))
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} {employee.MiddleName} {employee.JobTitle} {employee.Salary:f2}");
            }

            return sb.ToString().Trim();
        }
        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();
            var employees = context.Employees.Where(e => e.Salary > 50000);
            foreach (var employee in employees.OrderBy(x => x.FirstName))
            {
                sb.AppendLine($"{employee.FirstName} - {employee.Salary:f2}");
            }

            return sb.ToString().Trim();
        }
        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();
            var employees = context.Employees.Where(x => x.Department.Name == "Research and Development").Select(e => new
            {
                FirstName=e.FirstName,
                LastName=e.LastName,
                Department=e.Department.Name,
                Salary=e.Salary
            });
            foreach (var employee in employees.OrderBy(x => x.Salary).ThenByDescending(s =>s.FirstName))
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} from {employee.Department} - ${employee.Salary:F2}");
            }
            return sb.ToString().Trim();
        }
        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();
            var address = new Address()
            {
                AddressText = "Vitoshka 15",
                TownId = 4
            };
            var employee = context.Employees.Where(x => x.LastName == "Nakov").FirstOrDefault();
            employee.Address = address;
            context.SaveChanges();
            var employees = context.Employees.OrderByDescending(x => x.AddressId).Take(10).Select(x => new
            {
                AddressText=x.Address.AddressText
            });
            foreach (var itm in employees)
            {
                sb.AppendLine(itm.AddressText);
            }
            return sb.ToString().Trim();
        }
        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var employees = context.Employees
                .Include(x => x.EmployeesProjects)
                .ThenInclude(x => x.Project)
                .Where(x => x.EmployeesProjects.Any(p => p.Project.StartDate.Year >= 2001 && p.Project.StartDate.Year <= 2003))
                .Select(x => new
                {
                    EmployeeFisrtName = x.FirstName,
                    EmployeeLastName = x.LastName,
                    ManagerFirstName = x.Manager.FirstName,
                    ManagerLastName = x.Manager.LastName,
                    Projetcs = x.EmployeesProjects.Select(p => new
                    {
                        Name = p.Project.Name,
                        StartDate = p.Project.StartDate,
                        EndDate = p.Project.EndDate
                    })
                })
                .Take(10)
                .ToList();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.EmployeeFisrtName} {employee.EmployeeLastName} - Manager: {employee.ManagerFirstName} {employee.ManagerLastName}");

                foreach (var emplProject in employee.Projetcs)
                {
                    var endDate = emplProject.EndDate.HasValue
                        ? emplProject.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)
                        : "not finished";

                    sb.AppendLine($"--{emplProject.Name} - {emplProject.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)} - {emplProject.EndDate}");
                }
            }

            return sb.ToString().TrimEnd();
        }
        public static string GetAddressesByTown(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();
            var addresses = context.Addresses
                .Include(x => x.Employees)
                .Include(x => x.Town)
                .Select(x => new
                {
                    x.AddressText,
                    TownName = x.Town.Name,
                    Count = x.Employees.Count(),
                })
                .OrderByDescending(x => x.Count)
                .ThenBy(x => x.TownName)
                .ThenBy(x => x.AddressText)
                .Take(10)
                .ToList();
            foreach (var address in addresses)
            {
                sb.AppendLine($"{address.AddressText}, {address.TownName} - {address.Count} employees");
            }

            return sb.ToString().TrimEnd();
        }
        public static string GetEmployee147(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();
            var employee = context.Employees
                .Include(x => x.EmployeesProjects)
                .ThenInclude(x => x.Project)
                .Where(x => x.EmployeeId == 147)
                .Select(x => new
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    JobTitle = x.JobTitle,
                    Projetcs = x.EmployeesProjects.Select(p => new
                    {
                        Name = p.Project.Name,
                    })
                });
            foreach (var emp in employee)
            {
                sb.AppendLine($"{emp.FirstName} {emp.LastName} - {emp.JobTitle}");
                foreach (var projetc in emp.Projetcs.OrderBy(x => x.Name))
                {
                    sb.AppendLine($"{projetc.Name}");
                }
            }
            return sb.ToString().TrimEnd();
        }
        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var department = context.Departments
                .Where(x => x.Employees.Count() > 5)
                .Select(x => new
                {
                    Name = x.Name,
                    ManagerFirstName = x.Manager.FirstName,
                    ManagerLastName = x.Manager.LastName,
                    Employees = x.Employees.Select(e => new
                        {
                            FirstName = e.FirstName,
                            LastName = e.LastName,
                            JobTitle = e.JobTitle
                        })
                        .OrderBy(e => e.FirstName)
                        .ThenBy(e => e.LastName)
                        .ToList()
                })
                .ToList();

            foreach (var dep in department)
            {
                sb.AppendLine($"{dep.Name} - {dep.ManagerFirstName} {dep.ManagerLastName}");
                foreach (var emp in dep.Employees)
                {
                    sb.AppendLine($"{emp.FirstName} {emp.LastName} - {emp.JobTitle}");
                }
            }

            return sb.ToString().TrimEnd();
        }
        public static string GetLatestProjects(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();
            var projects = context.Projects
                .OrderByDescending(p => p.StartDate)
                .Take(10)
                .ToList();
            foreach (var project in projects.OrderBy(x => x.Name))
            {
                sb.AppendLine($"{project.Name}");
                sb.AppendLine($"{project.Description}");
                sb.AppendLine($"{project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)}");
            }
            return sb.ToString().TrimEnd();
        }
        public static string IncreaseSalaries(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();
            var employees = context.Employees
                .Where(x => x.Department.Name == "Engineering" 
                            || x.Department.Name == "Tool Design"
                            || x.Department.Name == "Marketing" 
                            || x.Department.Name == "Information Services")
                .OrderBy(x => x.FirstName)
                .ToList();
            foreach (var employee in employees)
            {
                employee.Salary *= (decimal)1.12;
                sb.AppendLine($"{employee.FirstName} {employee.LastName} (${employee.Salary:f2})");
            }
            return sb.ToString().TrimEnd();
        }
        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();
            var employees = context.Employees.Where(x => x.FirstName.StartsWith("Sa")).Select(x => new
            {
                FirstName=x.FirstName,
                LastName=x.LastName,
                JobTitle=x.JobTitle,
                Salary=x.Salary
            })
                .OrderBy(x => x.FirstName)
                .ThenBy(x => x.LastName);
            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle} - (${employee.Salary:f2})");
            }
            return sb.ToString().TrimEnd();
        }
        public static string DeleteProjectById(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();
            var project = context.Projects.Find(2);
            var empProjects = context.EmployeesProjects
                .Where(x => x.ProjectId == 2)
                .ToList();
            foreach (var item in empProjects)
            {
                context.EmployeesProjects.Remove(item);
            }
            context.Projects.Remove(project);
            context.SaveChanges();
            var projects = context.Projects.Take(10).ToList();
            foreach (var pr in projects)
            {
                sb.AppendLine(pr.Name);
            }
            return sb.ToString().TrimEnd();
        }
        public static string RemoveTown(SoftUniContext context)
        {
            var town = context.Towns
                .Include(x => x.Addresses)
                .FirstOrDefault(x => x.Name == "Seattle");
            var addressesIDs = town.Addresses.Select(x => x.AddressId).ToList();
            var employees = context.Employees.Where(x => x.AddressId.HasValue && addressesIDs.Contains(x.AddressId.Value)).ToList();

            foreach (var emp in employees)
            {
                emp.AddressId = null;
            }

            foreach (var addressID in addressesIDs)
            {
                var address = context.Addresses.FirstOrDefault(x => x.AddressId == addressID);

                context.Addresses.Remove(address);
            }

            context.Towns.Remove(town);
            context.SaveChanges();

            return $"{addressesIDs.Count()} addresses in Seattle were deleted";
        }
    }
}
