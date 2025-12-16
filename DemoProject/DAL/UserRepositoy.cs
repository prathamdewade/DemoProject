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
    public interface IUserRepositoy
    {
        public Task<bool> AddUserAsync(User user);
        public Task<User?> GetUserByEmailAsync(string email);
        public Task<bool> UpdateUserAsync(User user);
        public Task<bool> DeleteUserAsync(int id);
        public Task<User?> GetUserByIdAsync(int id);
        public Task<List<User>> GetAllUser();
    }
    class UserRepository : IUserRepositoy
    {
        private readonly string conString = "Server=(localdb)\\MSSQLLocalDB;Database=WorkDb;Trusted_Connection=true;TrustServerCertificate=True;";
        private string query = null;
        public async Task<bool> AddUserAsync(User user)
        {
            query = "insert into Users(FullName,Email,Password) values(@fn,@em,@pw)";
            SqlConnection con = new SqlConnection(conString);
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@fn", user.FullName);
            cmd.Parameters.AddWithValue("@em", user.Email);
            cmd.Parameters.AddWithValue("@pw", user.Password);
            await con.OpenAsync();
            var res=await cmd.ExecuteNonQueryAsync();
            await  con.CloseAsync();
            return res > 0;
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
           query= "delete from Users where Id=@id";
            SqlConnection con = new SqlConnection(conString);
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@id", id);
            await con.OpenAsync();
            var res= await cmd.ExecuteNonQueryAsync();
            await  con.CloseAsync();
            return res > 0;
        }

        public async Task<List<User>> GetAllUser()
        {
            query= "select * from Users";
            SqlConnection con = new SqlConnection(conString);
            SqlCommand cmd = new SqlCommand(query, con);
            await con.OpenAsync();
            SqlDataReader reader= await cmd.ExecuteReaderAsync();
            List<User> users = new List<User>();
            while (reader.Read())
            {
                User user = new User
                {
                    Id = reader.GetInt32(0),
                    FullName = reader["FullName"].ToString(),
                    Email = reader["Email"].ToString(),
                    Password = reader["Password"].ToString()
                };
                users.Add(user);
            }
            await  con.CloseAsync();
            return users;
        }

        public async Task<User?> GetUserByEmailAsync(string email)
        {
           query ="select * from Users where Email=@em";
            SqlConnection con = new SqlConnection(conString);
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@em", email);
            await con.OpenAsync();
            SqlDataReader reader= await cmd.ExecuteReaderAsync();
            User? user = null;
            if (reader.Read())
            {
                user = new User
                {
                    Id = reader.GetInt32(0),
                    FullName = reader["FullName"].ToString(),
                    Email = reader["Email"].ToString(),
                    Password = reader["Password"].ToString()
                };
            }
             await  con.CloseAsync();
            return user;
        }

        public async Task<User?> GetUserByIdAsync(int id)
        {
            query = "select * from Users where Id=@id";
            SqlConnection con = new SqlConnection(conString);
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@id", id);
            await con.OpenAsync();
            SqlDataReader reader = await cmd.ExecuteReaderAsync();
            User? user = null;
            if (reader.Read())
            {
                user = new User
                {
                    Id = reader.GetInt32(0),
                    FullName = reader["FullName"].ToString(),
                    Email = reader["Email"].ToString(),
                    Password = reader["Password"].ToString()
                };
            }
            await  con.CloseAsync();
            return user;
        }

        public async Task<bool> UpdateUserAsync(User user)
        {
            query = "update Users set FullName=@fn, Email=@em, Password=@pw where Id=@id";
            SqlConnection con = new SqlConnection(conString);
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@fn", user.FullName);
            cmd.Parameters.AddWithValue("@em", user.Email);
            cmd.Parameters.AddWithValue("@pw", user.Password);
            cmd.Parameters.AddWithValue("@id", user.Id);
            await con.OpenAsync();
            var res= await cmd.ExecuteNonQueryAsync();
            await  con.CloseAsync();
            return res > 0;
        }
    }
    }

