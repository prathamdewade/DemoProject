using System.Data.SqlClient;

namespace StudentApi.Data
{
    public class AppDbContext
    {
        private  static SqlConnection con = null;

        public static SqlConnection GetDatabaseConnection(string connectionstring)
        {
            if (con == null)
            {
                con = new SqlConnection(connectionstring);
            }
            return con;
        }
    }
}
