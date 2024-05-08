using System.ComponentModel.DataAnnotations;

namespace COMP003B.Week7Assignment.Models
{
    public class Movie
    {
        public int movieId { get; set; }

        [Required]
        public int yearReleased { get; set; }
        [Required]
        public string movieTitle { get; set; }


        //Collection Navigation property
        public virtual ICollection<IMDB>? IMDBs { get; set; }
    }
}
