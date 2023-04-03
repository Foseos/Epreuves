using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.IO;

namespace Movies.Models
{
    public class MoviesInitializer : DropCreateDatabaseIfModelChanges<MoviesContext>
    {


        protected override void Seed(MoviesContext context)
        {
            

            base.Seed(context);
            var MovieList = new List<MoviesModel>
            {
                new MoviesModel
                {

                    Name = "La Cabane dans les Bois",
                    Description = "Cinq amis partent passer le week-end dans une cabane perdue au fond des bois. Ils n'ont aucune idée du cauchemar qui les y attend, ni de ce que cache vraiment la cabane dans les bois.",
                    Date_Sortie = new DateTime(2012, 05, 02),
                    ImageUrl = "https://proxymedia.woopic.com/api/v1/images/331%2FLACABANEDANW0105515_BAN1_2424_NEWTV_HD.jpg"

                }
            };
            MovieList.ForEach(p => context.Movie.Add(p));
            context.SaveChanges();
        }
    }
}