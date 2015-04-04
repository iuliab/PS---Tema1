using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Ad
    {
        private String title, category, description, image;
        public Ad(String title, String category, String description, String image)
        {
            this.title = title;
            this.category = category;
            this.description = description;
            this.image = image;
        }

        public String getTitle()
        {
            return this.title;
        }

        public String getCategory()
        {
            return this.category;
        }

        public String getDescription()
        {
            return this.description;
        }

        public String getImage()
        {
            return this.image;
        }
    }
}
