using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using piataAZ.Entities;

namespace piataAZ.DAL
{
    public class UserDAL
    {
        private static UserDAL _userDAL = null;
        private String _connectionString = String.Format("server={0};user id={1}; password={2}; database={3}; pooling=false", "localhost", "root", "iulia1", "piata_az");
        MySqlConnection _conn = null;

        private UserDAL()
        {
            try
            {
                _conn = new MySqlConnection(_connectionString);
            }
            catch (MySqlException e)
            {
                //de facut ceva error handling, afisat mesaj, etc..
                _conn = null;
            }
        }

        public static UserDAL getInstance()
        {
            if (_userDAL == null)
            {
                _userDAL = new UserDAL();
            }
            return _userDAL;
        }


        public User getUser(String username, String password)
        {
            User u = null;
            String sql = "SELECT * FROM users WHERE username='" + username + "' AND password='" + password + "'";
            try
            {
                _conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, _conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                u = new User(reader["username"].ToString(), reader["password"].ToString(), reader["role"].ToString(), reader["name"].ToString());
                _conn.Close();

            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
            return u;
        }


        public void updatePassword(String username, String password)
        {
            String sql = "UPDATE users SET password='" + password +"' WHERE username='" + username + "'";
            try
            {
                _conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, _conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                _conn.Close();

            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void insertEmployee (String name, String username, String password)
        {
            String sql = "INSERT INTO users (username, password, role, name) VALUES ('" + username + "', '" + password + "', 'employee', '" + name + "')";
            try
            {
                _conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, _conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                _conn.Close();

            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public List<String> getUsers()
        {
            List<String> users = new List<String>();

            String sql = "SELECT * FROM users";
            try
            {
                _conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, _conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    users.Add(reader.GetString("username"));
                }
                _conn.Close();

            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
            }
            return users;
        }
    }
}
