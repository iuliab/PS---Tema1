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

namespace piataAZ
{
    public partial class FormAdmin : Form
    {
        private UserService userService;
        private AdService adService;
        public FormAdmin(String s)
        {
            InitializeComponent();
            label1.Text = s;
            userService = new UserService();

            FillCombo();
        }

        private void FormAdmin_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String name = textBox1.Text;
            String username = textBox2.Text;
            String password = textBox3.Text;

            if (name.Equals("") || username.Equals("") || password.Equals(""))
            {
                MessageBox.Show("Please insert name, username and password!");
            }
            else
            {
                userService.createAccount(name, username, password);
            }
            comboBox1.Items.Clear();
            FillCombo();
        }

        void FillCombo()
        {
            List<String> users = userService.getUsers();
            for (int i = 0; i < users.Count; i++)
            {
                comboBox1.Items.Add(users[i]);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String author = comboBox1.GetItemText(comboBox1.SelectedItem);

            int numberOfAds = adService.getReport(author);

            MessageBox.Show(author + " posted " + numberOfAds + " ad(s)");
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            List<String> users = userService.getUsers();
            String result = "";
            for (int i = 0; i < users.Count; i++)
            {
                int numOfAds = adService.getReport(users[i]);
                result += users[i] + " posted " + numOfAds + "ad(s)\n";
            }

            MessageBox.Show(result);
        }
    }
}
