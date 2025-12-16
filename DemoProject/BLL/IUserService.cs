using DemoProject.DAL;
using DemoProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoProject.BLL
{
    public interface IUserService
    {
        Task<User> GetUser(int  id);
        Task<List<User>> GetUsers();
        Task<bool> Login(string username , string password);
        Task<bool> Register(User u);
        Task<bool> DeleteUser(int id);
        Task<bool> UpdateUser(int id , User user);
    }

    public class UserService : IUserService
    {
        public readonly IUserRepositoy repo= new UserRepository();
        public Task<bool> DeleteUser(int id)
        {
            throw new NotImplementedException();
        }
        public Task<User> GetUser(int id)
        {
            throw new NotImplementedException();
        }
        public Task<List<User>> GetUsers()
        {
            throw new NotImplementedException();
        }
        public async Task<bool> Login(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || !username.Contains("@"))
            {
                return false;
            }
            User u= await repo.GetUserByEmailAsync(username);
            if(u==null)
            {
                Console.WriteLine("Email invalids");
                return false;
            }
            bool res=BCrypt.Net.BCrypt.Verify(password, u.Password);
            if(!res)
            {
                Console.WriteLine("Password invalids");
                return false;
            }
            return res;
        }
        public async Task<bool> Register(User u)
        {
           if(u==null || string.IsNullOrEmpty( u.Email)|| !u.Email.Contains("@") || string.IsNullOrEmpty(u.Password))
            {
                return false;
            }
            User user=await repo.GetUserByEmailAsync(u.Email);
            if(user!=null)
            {
                return false;
            }
           string passhash= BCrypt.Net.BCrypt.HashPassword(u.Password);
            u.Password= passhash;
          return await repo.AddUserAsync(u);


        }
        public Task<bool> UpdateUser(int id, User user)
        {
            throw new NotImplementedException();
        }
    }
}
