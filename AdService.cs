using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using piataAZ.DAL;
using piataAZ.Entities;
using Entities;
using System.IO;

namespace piataAZ.BL
{
    public class AdService
    {
        private AdDAL adDAL;
        private Ad ad;

        public AdService()
        {
            adDAL = AdDAL.getInstance();
        }

        public void createAd (String title, String category, String description, String image, String author)
        {
            adDAL.insertAd(title, category, description, image, author);
        }

        public void updateAd (String title, String category, String description, String image)
        {
            adDAL.updateAd(title, category, description, image);
        }

        public Ad readAd (String title)
        {
            return adDAL.getAd(title); 
        }

        public List<String> getTitle()
        {
            List<String> titles = adDAL.getTitles();

            return titles;
        }

        public void deleteAd(String title)
        {
            adDAL.deleteAd(title);
        }

        public int getReport(String author)
        {
            int numOfAds = adDAL.getReport(author);
            return numOfAds;
        }
    }
}
