using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Cybersécu.Models
{
    public class LoginContext : DbContext
    {
        public LoginContext() : base("name = LoginDB") { }
        public DbSet<LoginModel> Login { get; set; }

    }
}