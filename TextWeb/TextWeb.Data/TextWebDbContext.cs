﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextWeb.Entity;

namespace TextWeb.Data
{
    public class TextWebDbContext : IdentityDbContext<User>
    {
        public TextWebDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Page> Pages { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Settings> Settings { get; set; }
    }
}
