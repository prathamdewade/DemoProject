using DemoProject.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoProject.DAL
{
    public class StudentRepository
    {
        
        private readonly string conString= "Server=(localdb)\\MSSQLLocalDB;Database=crud;Trusted_Connection=true;TrustServerCertificate=True;";
        private string query;
        public bool AddStudent(Student s)
        {
            query = "insert into student(name,marks) values(@n,@m)";
            SqlConnection con= new SqlConnection(conString);
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.Add("@n",SqlDbType.VarChar).Value = s.Name;
            cmd.Parameters.Add("@m", SqlDbType.Decimal).Value = s.Marks;
            con.Open();
           int res= cmd.ExecuteNonQuery();
            con.Close();
            return res > 0;

        }
        public bool UpdateStudent(int id,Student s)
        {
            query = "update  student set name=@n ,marks=@m where id =@id";
            SqlConnection con = new SqlConnection(conString);
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.Add("@n", SqlDbType.VarChar).Value = s.Name;
            cmd.Parameters.Add("@m", SqlDbType.Decimal).Value = s.Marks;
            cmd.Parameters.Add("@id",SqlDbType.Int).Value= id;
            con.Open();
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res > 0;

        }
        public bool RemoveStudent(int id)
        {
            query = "delete from student where id =@id";
            SqlConnection con = new SqlConnection(conString);
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
            con.Open();
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res > 0;

        }
    }
}
