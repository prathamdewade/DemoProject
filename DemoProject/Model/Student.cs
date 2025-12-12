using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoProject.Model
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Marks { get; set; }

        //tostring
        public override string ToString()
        {
            return $"Student [{Id} , {Name}  ,{Marks}]";
        }
    }
}
