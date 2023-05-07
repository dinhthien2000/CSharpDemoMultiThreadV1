using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoMultiThread.Model
{
    internal class Employee
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Age { get; set; }

        public Employee() { }

        public Employee(int id, string name, string age)
        {
            Id = id;
            Name = name;
            Age = age;
        }

        public override string ToString()
        {
            return "Ìd: " + Id + " - Name: " + Name + " - Age: "+Age;
        }
    }
}
