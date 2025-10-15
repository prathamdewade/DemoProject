using StudentApi.Data;
using StudentApi.Models;
using System.Data.SqlClient;
using System.Data;

namespace StudentApi.Repository
{
    public class StudentRepository
    {
        private string? conString;

        public StudentRepository(IConfiguration config)
        {
           conString= config.GetConnectionString("MyCon");
        }
        public bool AddStudent(Student s)
        {
           SqlConnection con= AppDbContext.GetDatabaseConnection(conString);
            con.Open();
            SqlCommand cmd = new SqlCommand("spCrudStud", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@action", SqlDbType.VarChar).Value = "Insert";
            cmd.Parameters.Add("@name", SqlDbType.VarChar).Value = s.Name;
            cmd.Parameters.AddWithValue("@marks", s.Marks);
             int res=cmd.ExecuteNonQuery();
            con.Close();
            return res > 0;

        }

        public IList<Student> GetAllStudents()
        {
            IList<Student> slist = new List<Student>();
            SqlConnection con = AppDbContext.GetDatabaseConnection(conString);
            con.Open();
            SqlCommand cmd = new SqlCommand("spCrudStud", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@action", SqlDbType.VarChar).Value = "Select";
            SqlDataReader reader=cmd.ExecuteReader();
            while (reader.Read())
            {
                Student s = new Student();
                s.Id = reader.GetInt32(0);
                s.Name= reader.GetString(1);
                s.Marks = reader.GetDecimal(2);

                slist.Add(s);

            }
            con.Close();
            return slist;

        }
    }
}
