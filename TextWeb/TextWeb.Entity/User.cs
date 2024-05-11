using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextWeb.Entity
{
    public class User : IdentityUser
    {
        public User()
        {
            Pages = new List<Page>();
            Categories = new List<Category>();
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Page> Pages { get; set; }
        public List<Category> Categories { get; set; }

    }
}
