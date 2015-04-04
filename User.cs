using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace piataAZ.Entities
{
    public class User
    {
        private String username, password, role, name;
        public User(String username, String password, String role, String name)
        {
            this.username = username;
            this.password = password;
            this.role = role;
            this.name = name;
        }

        public String getRole()
        {
            return this.role;
        }

        public String getName()
        {
            return this.name;
        }
    }
}
