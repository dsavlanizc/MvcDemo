using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MvcDemo.Models
{
    public class MyContext : DbContext
    {
        public MyContext() : base("name=MyConnectionString") { }
        public DbSet<Student> Students { get; set; }
    }
}