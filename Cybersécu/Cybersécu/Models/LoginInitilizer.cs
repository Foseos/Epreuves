using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.IO;

namespace Cybersécu.Models
{
    public class LoginInitilizer : DropCreateDatabaseIfModelChanges<LoginContext>
    {


        protected override void Seed(LoginContext context)
        {


            base.Seed(context);
            var LoginList = new List<LoginModel>
            {
                new LoginModel
                {
                    Username = "test",
                    Password = "azertyui",
                    ConfirmPassword = "azertyui",
                    Email = "test@test.test",
                    TermsAndConditions = true
                }
            };

            LoginList.ForEach(p => context.Login.Add(p));
            context.SaveChanges();
        }
    }
}