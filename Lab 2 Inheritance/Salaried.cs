using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2_Inheritance
{
    internal class Salaried : Employee
    {
        private double salary;

        public Salaried() { }

        public Salaried(string id, string name, string address, string phone, long sin, string dob, string dept, double salary) : 
                        base(id, name, address, phone, sin, dob, dept)
        {
            this.salary = salary;

        }

        public override string ToString()
        {

            return $"ID: {Id}, Name: {Name}, Address {Address}, Phone: {Phone}, SIN: {Sin}, DOB: {Dob}, DEPT: {Dept}, Salary: {salary}";
        }

        public override double GetPay()
        {
            return salary / 52;
        }
    }
}
