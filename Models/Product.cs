using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarisSneakerCloset.Models
{
    public class Product
    {
        public int SneakersID { get; set; }
        public string Brand { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public decimal Size { get; set; }
        public double Price { get; set; }
        public DateTime Release_Date { get; set; }
        public string Location { get; set; }
        public bool In_Stock { get; set; }
        public bool Is_Released { get; set; }
       // public IEnumerable<Category> Categories { get; set; }
        public object CategoryID { get; internal set; }
    }
}
