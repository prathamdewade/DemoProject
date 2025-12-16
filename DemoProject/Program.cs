


using DemoProject.BLL;
using DemoProject.DAL;
using DemoProject.Model;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace DemoProject
{
    public class Program
    {
       public static async Task Main(string[] args)
        {
            IUserService userService = new UserService();
            User user = new User()
            {
                FullName = "raju",
                Email = "rrr@gmail.com",
                Password = "pass123"
            };

            //var res = await userService.Register(user);
            //Console.WriteLine(res ? "Data Register" : "Data not Register");

            var res=await userService.Login(user.Email, user.Password);
            Console.WriteLine( res ? "Login Successful" : "Login Failed");
        }
    }
}