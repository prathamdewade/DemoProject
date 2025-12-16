using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoProject.Model
{
    public  class User
    {
        public int Id { get; set; }
        public string  FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        //tostring
        public override string ToString()
        {
            return $"User [Id: {Id}, FullName: {FullName}, Email: {Email}]";
        }
    }
}
