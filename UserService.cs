using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Threading.Tasks;
using piataAZ.DAL;
using piataAZ.Entities;

namespace piataAZ.BL
{
    public class UserService
    {
        private UserDAL userDAL;
        private User user;

        public UserService()
        {
            userDAL = UserDAL.getInstance();
        }

        private string getMd5Hash(string input)
        {
            // Create a new instance of the MD5CryptoServiceProvider object.
            MD5 md5Hasher = MD5.Create();

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
                
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }


        public User login(String username, String password)
        {
            String pass = getMd5Hash(password);
            user = userDAL.getUser(username, pass);

            return user;    
        }

        public String changePassword(String username)
        {
            String characters = "0a1b2c3d4e5f6g7h8i9j0k1l2m3n4o5p6q7r8s9t0u1v2w3x4y5z6";
            String pass = "";

            Random rand = new Random();
            int numberOfChar = rand.Next(10, 30);

            int i = 0;
            while (i < numberOfChar)
            {
                int index = rand.Next(0, 52);
                pass += characters[index];
                i++;
            }
            
            String password = getMd5Hash(pass);
            userDAL.updatePassword(username, password);

            return pass;
        }

        public void createAccount(String name, String username, String password)
        {
            userDAL.insertEmployee(name, username, password);
        }

        public List<String> getUsers()
        {
            List<String> users = userDAL.getUsers();

            return users;
        }
    }
}
