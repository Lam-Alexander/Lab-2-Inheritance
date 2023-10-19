using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2_Inheritance
{
    internal class PartTime : Employee
    {
        private double hours;
        private double rate;
        public PartTime() { }

        public PartTime(string id, string name, string address, string phone, long sin, string dob, string dept, double rate,double hours ) : 
                        base(id, name, address, phone, sin, dob, dept)
        {
            this.hours = hours;
            this.rate = rate;
        }

        public override string ToString()
        {

            return $"ID: {Id}, Name: {Name}, Address {Address}, Phone: {Phone}, SIN: {Sin}, DOB: {Dob}, DEPT: {Dept}, Rate: {rate} ,Hours: {hours}";
        }

        public override double GetPay()
        {
            return hours * rate;
        }
    }
}

