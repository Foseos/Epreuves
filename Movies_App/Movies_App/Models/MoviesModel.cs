using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Movies.Models
{
    public class MoviesModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date_Sortie { get; set; }
        public string DateSortieFormat
        {
            get
            {
                return Date_Sortie.ToShortDateString();
            }
        }
        public string ImageUrl { get; set; }


    }
}