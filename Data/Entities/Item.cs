using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularASP.Data.Entities
{
    public class Item
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public string Size { get; set; }
        public decimal Price { get; set; }
        public string ArtDescription { get; set; }
        public DateTime ArtDate { get; set; }
        public string ArtistName { get; set; }
        public string ArtistId { get; set; }



    }
}
