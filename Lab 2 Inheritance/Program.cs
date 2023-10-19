using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


namespace Lab_2_Inheritance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("List of all employees");
            Console.WriteLine("____________________________________________________________________________________");
            Console.WriteLine();

            List<Employee> employeeList = reader();
            double averagePay = AverageWeeklyPay(employeeList);

            
            Console.WriteLine();
            Console.WriteLine("____________________________________________________________________________________");
            Console.WriteLine($"The average weekly pay of all employee's is ${averagePay:F2}");


            double highestPay = HighestWeeklyPayWage(employeeList);
            double lowestSalary = LowestSalary(employeeList);

            EmployeeCategoryPercentage(employeeList);
        }

      

        static List<Employee> reader()
        {

            string filePath = "res\\employees.txt";

            List<Employee> list = new List<Employee>();

            using (StreamReader sr = new StreamReader(filePath))
            {
                string line;

                while ((line = sr.ReadLine()) != null)
                {

                    string[] attributes = line.Split(':');

                    string id = attributes[0].Trim();
                    string name = attributes[1].Trim();
                    string address = attributes[2].Trim();
                    string phone = attributes[3].Trim();
                    long sin = long.Parse(attributes[4].Trim());
                    string dob = attributes[5].Trim();
                    string dept = attributes[6].Trim();


                    if (id.StartsWith("0") || id.StartsWith("1") || id.StartsWith("2") || id.StartsWith("3") || id.StartsWith("4"))
                    {
                        double salary = double.Parse(attributes[7].Trim());
                        list.Add(new Salaried(id,name,address,phone,sin,dob,dept,salary));
                        
                    }

                    else if (id.StartsWith("5") || id.StartsWith("6") || id.StartsWith("7"))
                    {
                        double rate = double.Parse(attributes[7].Trim());
                        double hours = double.Parse(attributes[8].Trim());
                        Wages wage = new Wages(id, name, address, phone, sin, dob, dept, rate, hours);
                        list.Add(wage);
                    }

                    else if (id.StartsWith("8") || id.StartsWith("9"))
                    {
                        double rate = double.Parse((attributes[7].Trim()));
                        double hours = double.Parse((attributes[8].Trim()));
                        PartTime parttime = new PartTime(id, name, address, phone, sin, dob, dept, rate, hours);
                        list.Add(parttime);

                        
                    }
                }
            }

            //

            foreach (Employee employee in list)
            {
                Console.WriteLine(employee);
            }
            return list;
        }

        static double AverageWeeklyPay(List<Employee> employeeList)
        {
            int employeeCounter = 0;
            double totalPay = 0;

            foreach (Employee employee in employeeList)
            {
                if (employee is Salaried salariedEmployee)
                {
                    double salaryPay = salariedEmployee.GetPay();
                    totalPay += salaryPay;
                    employeeCounter++;
                }

                else if (employee is PartTime partTimeEmployee)
                {
                    double salaryPay = partTimeEmployee.GetPay();
                    totalPay += salaryPay;
                    employeeCounter++;
                }

                else if (employee is Wages wageEmployee)
                {
                    double salaryPay = wageEmployee.GetPay();
                    totalPay += salaryPay;
                    employeeCounter++;
                }
            }
            double averagePay = totalPay / employeeCounter;
            return averagePay;
        }

        static double HighestWeeklyPayWage(List<Employee> employeeList)
        {
            
           double highestPay = double.MinValue;
            string highestPayEmployeeName = "";

            foreach (Employee employee in employeeList)
            {

                if (employee is Wages wageEmployee)
                {
                    double pay = wageEmployee.GetPay();
                    
                    if (pay > highestPay)
                    {
                        highestPay = pay;
                        highestPayEmployeeName = employee.Name;
                    }
                }
            }

            Console.WriteLine($"The highest pay employee is {highestPayEmployeeName:F2}");
            return highestPay;
        }

        static double LowestSalary(List<Employee> employeeList)
        {
            double lowestSalary = double.MaxValue;
            string lowestSalaryEmployeeName = "";

            foreach (Employee employee in employeeList)
            {
                if (employee is Salaried salariedEmployee)
                {
                    double salary = salariedEmployee.GetPay();

                    if (salary < lowestSalary)
                    {
                        lowestSalary = salary;
                        lowestSalaryEmployeeName = employee.Name;
                    }
                }
            }

            Console.WriteLine($"Lowest Salary Employee: {lowestSalaryEmployeeName}, Salary: ${lowestSalary:F2}");
            return lowestSalary;
        }

        static void EmployeeCategoryPercentage(List<Employee> employeeList)
        {
            int totalEmployees = employeeList.Count;
            int salariedEmployees = 0;
            int wageEmployees = 0;
            int partTimeEmployees = 0;

            foreach (Employee employee in employeeList)
            {
                if (employee is Salaried)
                {
                    salariedEmployees++;
                }
                else if (employee is Wages)
                {
                    wageEmployees++;
                }
                else if (employee is PartTime)
                {
                    partTimeEmployees++;
                }
            }

            double salariedPercentage = (double)salariedEmployees / totalEmployees * 100;
            double wagePercentage = (double)wageEmployees / totalEmployees * 100;
            double partTimePercentage = (double)partTimeEmployees / totalEmployees * 100;

            Console.WriteLine($"Salaried Employees: {salariedPercentage:F2}%");
            Console.WriteLine($"Wage Employees: {wagePercentage:F2}%");
            Console.WriteLine($"Part Time Employees: {partTimePercentage:F2}%");
        }



    }
}
