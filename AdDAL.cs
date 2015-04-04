using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.IO;
using System.Data;
using piataAZ.Entities;
using Entities;
using DAL;

namespace piataAZ.DAL
{
    public class AdDAL
    {
        private static AdDAL _adDAL = null;
        private String connectionString;
        MySqlConnection conn = null;

        private AdDAL()
        {
            connectionString = String.Format("server={0};user id={1}; password={2}; database={3}; pooling=false","localhost", "root", "iulia1", "piata_az");
            conn = new MySqlConnection(connectionString); 
        }

        public static AdDAL getInstance()
        {
            if (_adDAL == null)
            {
                _adDAL = new AdDAL();
            }
            return _adDAL;
        }

        public Ad getAd (String title)
        {
            Ad ad = null;
            String sql = "SELECT * FROM ad WHERE title = '" + title + "'";
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                ad = new Ad(reader["title"].ToString(), reader["category"].ToString(), reader["description"].ToString(), reader["image"].ToString());
                
                conn.Close();

            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
                conn.Close();
                return null;
            }

            return ad;
        }

        public List<String> getTitles()
        {
            List<String> titles = new List<String>();

            String sql = "SELECT * FROM ad";
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    titles.Add(reader.GetString("title"));
                }
                conn.Close();

            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
            }
            return titles;
        }
        
        public void updateAd (String title, String category, String description, String image)
        {
            String sql = "UPDATE ad SET category = '" + category + "', description = '" + description + "', image = '" + image + "' WHERE title = '" + title + "'";
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                conn.Close();

            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void insertAd (String title, String category, String description, String image, String author)
        {
            String sql = "INSERT INTO ad (title, category, description, image, author) VALUES ('" + title + "', '" + category + "', '" + description + "', '" + image + "', '" + author + "')";
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                conn.Close();

            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void deleteAd (String title)
        {
            String sql = "DELETE FROM ad WHERE title = '" + title + "'";
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                conn.Close();

            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public int getReport(String author)
        {
            String sql = "SELECT COUNT(*) FROM ad WHERE author = '" + author + "'";
            //List<String> titles = new List<String>();
            int numberOfAds = 0;
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                //MySqlDataReader reader = cmd.ExecuteReader();
                numberOfAds = Convert.ToInt32(cmd.ExecuteScalar());
                
                conn.Close();

            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
            }
            //numberOfAds = titles.Count();
            return numberOfAds;
        }
    }
}
