using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2_Inheritance
{
    internal class Employee
    {
        protected string protected_id;
        protected string Protected_name;
        protected string Protected_address;
        protected string Protected_phone;
        protected long Protected_sin;
        protected string Protected_dob;
        protected string Protected_dept;

        public string Id
        {
            get { return protected_id; }
            set { protected_id = value; }
        }

        public string Name
        {
            get { return Protected_name; }
            set { Protected_name = value; }
        }

        public string Address
        {
            get { return Protected_address; }
            set { Protected_address = value; }
        }

        public string Phone
        {
            get { return Protected_phone; }
            set { Protected_phone = value; }
        }

        public long Sin
        {
            get { return Protected_sin; }
            set { Protected_sin = value; }
        }

        public string Dob
        {
            get { return Protected_dob; }
            set { Protected_dob = value; }
        }

        public string Dept
        {
            get { return Protected_dept; }
            set { Protected_dept = value; }
        }


        public Employee()
        {

        }

        public Employee(string id, string name, string address, string phone, long sin, string dob, string dept)
        {
            this.Id = id;
            this.Name = name;
            this.Address = address;
            this.Phone = phone;
            this.Sin = sin;
            this.Dob = dob;
            this.Dept = dept;

        }

        public override string ToString()
        {
            
            return $"ID: {Id}, Name: {Name}, Address {Address}, Phone: {Phone}, SIN: {Sin}, DOB: {Dob}, DEPT: {Dept} ";
        }

        public virtual double GetPay()
        {
            return 0;
        }
    }
}
