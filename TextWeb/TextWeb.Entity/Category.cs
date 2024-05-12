using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextWeb.Entity
{
    public class Category
    {
        public Category()
        {
            Products = new List<Product>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; } = false;
        public User User { get; set; }
        public List<Product> Products { get; set; }
    }
}
