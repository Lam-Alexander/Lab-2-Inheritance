using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Lab_2_Inheritance
{
    internal class Wages : Employee
    {
        private double hours;
        private double rate;

        public Wages() { }
        public Wages(string id, string name, string address, string phone, long sin, string dob, string dept, double rate, double hours) : 
                     base (id, name, address, phone, sin, dob, dept)
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

            if (hours > 40)
            {
                double overTimeHours = hours - 40;
                double overTimePay = (1.5 * rate) * overTimeHours;
                double totalPayWithOverTime = ( 40 * rate) + overTimePay;
                return totalPayWithOverTime;
            }

            else 
            {
                double totalPayWithoutOvertime = hours * rate;
                return totalPayWithoutOvertime;
            }
        } 
       
    }
}
