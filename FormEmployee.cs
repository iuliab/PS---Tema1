using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using piataAZ.BL;
using piataAZ.Entities;
using Entities;

namespace piataAZ
{
    public partial class FormEmployee : Form
    {
        private AdService adService;
        private String img;
        public FormEmployee(String s)
        {
            InitializeComponent();
            label1.Text = s;
            adService = new AdService();
            FillCombo();
        }

        void FillCombo()
        {
            List<String> titles = adService.getTitle();
            for (int i = 0; i < titles.Count; i++)
            {
                comboBox1.Items.Add(titles[i]);
            }
        }

        private void FormEmployee_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String title = textBox1.Text;
            String category = comboBox2.GetItemText(comboBox2.SelectedItem);
            String description = textBox3.Text;
            String image = img;
            String author = label1.Text.Substring(9, label1.Text.Length - 10);

            if (title.Equals("") || category.Equals("") || description.Equals("") || image.Equals(""))
            {
                MessageBox.Show("Please fill all the fields!");
            }
            else
            {
                adService.createAd(title, category, description, image, author);
                MessageBox.Show("Ad created!");
            }
            comboBox1.Items.Clear();
            FillCombo();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String title = comboBox1.GetItemText(comboBox1.SelectedItem);
            String category = textBox4.Text;
            String description = textBox5.Text;
            String image = img;

            if (title.Equals("") || category.Equals("") || description.Equals("") || image.Equals(""))
            {
                MessageBox.Show("Please fill all the fields!");
            }
            else
            {
                adService.updateAd(title, category, description, image);
                MessageBox.Show("Ad updated!");
            }
            comboBox1.Items.Clear();
            FillCombo();

            textBox4.Text = "";
            textBox5.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            String title = comboBox1.GetItemText(comboBox1.SelectedItem);
            Ad ad = adService.readAd(title);
            
            textBox4.Text = ad.getCategory();
            textBox5.Text = ad.getDescription();
            String path = ad.getImage().Replace(".", @"\");
            pictureBox2.ImageLocation = path;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            String item = comboBox1.GetItemText(comboBox1.SelectedItem);
            
            if (item.Equals(""))
            {
                MessageBox.Show("Please choose a title!");
            }
            else
            {
                adService.deleteAd(item);
                MessageBox.Show("Ad deleted!");
            }
            comboBox1.Items.Clear();
            FillCombo();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "JPG Files(*.jpg)|*.jpg|PNG Files(*.png)|*.png|All Files(*.*)|*.*";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string imageLocation = dlg.FileName.ToString();
                textBox2.Text = imageLocation;
                img = imageLocation;
                img = img.Replace("\\", ".");
                pictureBox1.ImageLocation = imageLocation;
            }
        }
    }
}
