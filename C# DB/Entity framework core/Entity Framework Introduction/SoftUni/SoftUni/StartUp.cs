using SoftUni.Data;
using SoftUni.Models;
using System;
using System.Globalization;
using System.Linq;
using System.Text;

namespace SoftUni
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            SoftUniContext context = new SoftUniContext();
            string result = GetEmployeesByFirstNameStartingWithSa(context);
            Console.WriteLine(result);
        }

        //Task 03
        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            StringBuilder output = new StringBuilder();

            var employees = context
                .Employees
                .OrderBy(e => e.EmployeeId)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.MiddleName,
                    e.JobTitle,
                    e.Salary
                })
                .ToArray();

            foreach (var e in employees)
            {
                output
                    .AppendLine($"{e.FirstName} {e.LastName} {e.MiddleName} {e.JobTitle} {e.Salary:f2}");
            }

            return output.ToString().TrimEnd();
        }

        //Task 04
        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            StringBuilder output = new StringBuilder();
            var employee = context
                .Employees
                .OrderBy(e => e.FirstName)
                .Select(e => new
                {
                    e.FirstName,
                    e.Salary
                })
                .Where(e => e.Salary > 50000)
                .ToArray();

            foreach (var e in employee)
            {
                output
                    .AppendLine($"{e.FirstName} - {e.Salary:f2}");
            }

            return output.ToString().TrimEnd();
        }

        //Task 05
        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            StringBuilder output = new StringBuilder();

            var employee = context
                .Employees
                .OrderBy(e => e.Salary)
                .ThenByDescending(e => e.FirstName)
                .Where(e => e.Department.Name == "Research and Development")
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.Department.Name,
                    e.Salary
                })
                .ToArray();

            foreach (var e in employee)
            {
                output
                    .AppendLine($"{e.FirstName} {e.LastName} from {e.Name} - ${e.Salary:f2}");
            }

            return output.ToString().TrimEnd();
        }

        //Task 06
        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            StringBuilder output = new StringBuilder();

            Address newAddress = new Address
            {
                AddressText = "Vitoshka 15",
                TownId = 4
            };

            Employee nakov = context
                .Employees
                .FirstOrDefault(e => e.LastName == "Nakov");

            nakov.Address = newAddress;

            context.SaveChanges();

            string[] addressTexts = context
                .Employees
                .OrderByDescending(e => e.AddressId)
                .Take(10)
                .Select(e => e.Address.AddressText)
                .ToArray();

            foreach (var address in addressTexts)
            {
                output.AppendLine(address);
            }

            return output.ToString().TrimEnd();
        }

        //Task 07
        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            StringBuilder output = new StringBuilder();

            var employee = context
                .Employees
                .Where(e => e.EmployeesProjects
                    .Any(ep => ep.Project.StartDate.Year >= 2001
                                            && ep.Project.StartDate.Year <= 2003)
                    )
                .Take(10)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    ManagerFirstName = e.Manager.FirstName,
                    ManagerLastName = e.Manager.LastName,
                    AllProjects = e.EmployeesProjects
                        .Select(ep => new
                        {
                            ProjectName = ep.Project.Name,
                            StartDate = ep.Project.StartDate.ToString("M/d/yyyy h:mm:ss tt"),
                            EndDate = ep.Project.EndDate.HasValue
                            ?
                            ep.Project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt")
                            : "not finished"
                        })
                        .ToArray()
                })
                .ToArray();

            foreach (var e in employee)
            {
                output
                    .AppendLine($"{e.FirstName} {e.LastName} - Manager: {e.ManagerFirstName} {e.ManagerLastName}");

                foreach (var ep in e.AllProjects)
                {
                    output
                        .AppendLine($"--{ep.ProjectName} - {ep.StartDate} - {ep.EndDate}");
                }
            }

            return output.ToString().TrimEnd();
        }

        //Task 08
        public static string GetAddressesByTown(SoftUniContext context)
        {
            StringBuilder output = new StringBuilder();

            var addresses = context
                .Addresses
                .OrderByDescending(a => a.Employees.Count)
                .ThenBy(a => a.Town.Name)
                .ThenBy(a => a.AddressText)
                .Select(a => new
                {
                    address = a.AddressText,
                    town = a.Town.Name,
                    employeeCount = a.Employees.Count
                })
                .ToArray();

            foreach (var a in addresses)
            {
                output
                    .AppendLine($"{a.address}, {a.town} - {a.employeeCount} employees");
            }


            return output.ToString().TrimEnd();
        }

        //Task 09
        public static string GetEmployee147(SoftUniContext context)
        {
            StringBuilder output = new StringBuilder();

            var employee = context
                .Employees
                .Where(e => e.EmployeeId == 147)
                .Select(e => new
                {
                    fName = e.FirstName,
                    lName = e.LastName,
                    job = e.JobTitle,
                    projects = e.EmployeesProjects
                        .Select(ep => new
                        {
                            project = ep.Project.Name
                        })
                        .OrderBy(ep => ep.project)
                        .ToArray()
                })
                .ToArray();

            foreach (var e in employee)
            {
                output
                    .AppendLine($"{e.fName} {e.lName} - {e.job}");

                foreach (var ep in e.projects)
                {
                    output
                        .AppendLine($"{ep.project}");
                }
            }

            return output.ToString().TrimEnd();
        }

        //Task 10
        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            StringBuilder output = new StringBuilder();

            var departments = context
                .Departments
                .Where(d => d.Employees.Count > 5)
                .OrderBy(d => d.Employees.Count)
                .Select(d => new
                {
                    d.Name,
                    managerFirstName = d.Manager.FirstName,
                    managerLastName = d.Manager.LastName,
                    employees = d.Employees
                        .Select(e => new
                        {
                            firstName = e.FirstName,
                            lastName = e.LastName,
                            job = e.JobTitle
                        })
                        .ToArray()
                })
                .OrderBy(d => d.Name)
                .ToArray();

            foreach (var d in departments)
            {
                output
                    .AppendLine($"{d.Name} – {d.managerFirstName} {d.managerLastName}");

                foreach (var e in d.employees
                    .OrderBy(em => em.firstName)
                    .ThenBy(em => em.lastName))
                {
                    output
                        .AppendLine($"{e.firstName} {e.lastName} - {e.job}");
                }
            }

            return output.ToString().TrimEnd();
        }

        //Task 11
        public static string GetLatestProjects(SoftUniContext context)
        {
            StringBuilder output = new StringBuilder();

            var project = context
                .Projects
                .OrderByDescending(p => p.StartDate)
                .Take(10)
                .OrderBy(p => p.Name)
                .Select(p => new
                {
                    p.Name,
                    p.Description,
                    p.StartDate
                })
                .ToArray();

            foreach (var p in project)
            {
                output.AppendLine(p.Name);
                output.AppendLine(p.Description);
                output.AppendLine(p.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture));
            }

            return output.ToString().TrimEnd();
        }

        //Task 12
        public static string IncreaseSalaries(SoftUniContext context)
        {
            StringBuilder output = new StringBuilder();

            var employee = context
                .Employees
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.Salary,
                    department = e.Department.Name
                })
                .Where(e => e.department == "Engineering"
                || e.department == "Tool Design" || e.department == "Marketing" || e.department == "Information Services")
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .ToArray();

            foreach (var e in employee)
            {
                var salary = e.Salary + e.Salary * 12/100;

                output
                    .AppendLine($"{e.FirstName} {e.LastName} (${salary:f2})");
            }
            return output.ToString().TrimEnd();
        }

        //Task 13
        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            StringBuilder output = new StringBuilder();

            var employee = context
                .Employees
                .Where(e => e.FirstName.StartsWith("Sa"))
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.JobTitle,
                    salary = e.Salary
                })
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .ToArray();

            foreach (var e in employee)
            {
                output
                    .AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle} - (${e.salary:f2})");
            }

            return output.ToString().TrimEnd();
        }
    }
}
