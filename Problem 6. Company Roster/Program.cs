using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

public class Employee
{
    string name;
    double salary;
    string position;
    string department;
    string email;
    int age;

    public string Name { get; set; }
    public double Salary { get; set; }
    public string Position { get; set; }
    public string Department { get; set; }
    public string Email { get; set; }
    public int Age { get; set; }

    public Employee(string name, double salary, string position, string department)
    {
        Name = name;
        Salary = salary;
        Position = position;
        Department = department;
        Email = "N/A";
        Age = -1;
    }
}

public class Department
{
    public string name;
    public List<Employee> employees;

    public Department(string x)
    {
        name = x;
        employees = new List<Employee>();
    }

    public Department()
    {

    }
}

namespace Problem_6.Company_Roster
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var ci = (CultureInfo)CultureInfo.InvariantCulture.Clone();
            ci.NumberFormat.NumberDecimalSeparator = ".";
            Thread.CurrentThread.CurrentCulture = ci;
            var departments = new List<Department>();
            Console.Write("How many employees do u want to enter? : ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                Console.Write("Employee #" + (i + 1) + " : ");
                var employeeInfo = Console.ReadLine().Split();
                var employeeName = employeeInfo[0];
                var salary = double.Parse(employeeInfo[1]);
                var possition = employeeInfo[2];
                var departmentName = employeeInfo[3];

                if (!departments.Any(d => d.name == departmentName))
                {
                    var department = new Department(departmentName);
                    departments.Add(department);
                }

                if (!departments.Any(d => d.employees.Any(e => e.Name == employeeName)))
                {
                    var employee = new Employee(employeeName, salary, possition, departmentName) ;
                    if (employeeInfo.Length == 6)
                    {
                        employee.Email = employeeInfo[4];
                        employee.Age = int.Parse(employeeInfo[5]);
                    }
                    else if (employeeInfo.Length == 5)
                    {
                        if (employeeInfo[4].Contains("@"))
                        {
                            employee.Email = employeeInfo[4];
                        }
                        else
                        {
                            employee.Age = int.Parse(employeeInfo[4]);
                        }
                    }

                    departments.FirstOrDefault(d => d.name == departmentName).employees.Add(employee);
                }
            }

            var currentDepartment =
                departments
                    .OrderByDescending(d => d.employees.Average(e => e.Salary))
                    .FirstOrDefault();

            Console.WriteLine($"Highest Average Salary: {currentDepartment.name}");

            foreach (var employee in currentDepartment.employees.OrderByDescending(e => e.Salary))
            {
                Console.WriteLine($"{employee.Name} {employee.Salary:f2} {employee.Email} {employee.Age}");
            }
        }
    }
}
