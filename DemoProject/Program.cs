


using DemoProject.DAL;
using DemoProject.Model;
using System.Data;
using System.Data.SqlClient;

namespace DemoProject
{
    public class Program
    {
       public static void Main(string[] args)
        {
            //insert Operation 
            Student s=UI("insert");
            StudentRepository dao = new StudentRepository();
            var res=dao.AddStudent(s);
            Console.WriteLine( res ? "Data Added" : "Data Not Added");
         
        }
        public static Student UI(string type="update")
        {
            Student s = new Student();
            if (type.Equals("update"))
            {
                Console.WriteLine("Enter Student Id For Updation");
                s.Id= int.Parse(Console.ReadLine());
            }
            Console.WriteLine("Enter Name"); ;
            s.Name = Console.ReadLine();
            Console.WriteLine("Enter Marks");
            s.Marks=Decimal.Parse(Console.ReadLine());
            return s;


        }
    }
}