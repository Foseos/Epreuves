using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Movies.Models
{
    public class MoviesContext : DbContext
    {
        public MoviesContext() : base("name = MoviesDB") { }
        public DbSet<MoviesModel> Movie { get; set; }
        
    }
}