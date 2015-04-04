using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using piataAZ.BL;
using piataAZ.Entities;

namespace piataAZ
{
    public partial class FormLogin : Form
    {
        private UserService u;
        public FormLogin()
        {
            InitializeComponent();
            u = new UserService();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String username = textBox1.Text;
            String password = textBox2.Text;

            if (username.Equals("") || password.Equals(""))
            {
                MessageBox.Show("Please insert your username and password!");
            }
            else
            {
                User user = u.login(username, password);
                if (user != null)
                {
                    String role = user.getRole();
                    String name = user.getName();
                    if (role.Equals("admin"))
                    {
                        FormAdmin formAdmin = new FormAdmin("Administrator (" + name + ") logged in!");
                        formAdmin.Show();
                    }
                    else if (role.Equals("employee"))
                    {
                        FormEmployee formEmployee = new FormEmployee("Welcome, " + username + "!");
                        formEmployee.Show();
                    }
                }
                else
                {
                    MessageBox.Show("Wrong username/password!");
                }
            }       
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            String username = textBox1.Text;
            String newPassword = "";

            if (username.Equals(""))
            {
                MessageBox.Show("Please insert your username!");
            }
            else
            {
                newPassword = u.changePassword(username);
                MessageBox.Show("Your new password is: " + newPassword);
            }
        }
    }
}
