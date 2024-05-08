using System.ComponentModel.DataAnnotations;

namespace COMP003B.Week7Assignment.Models
{
    public class Actor
    {

        [Required]
        public string Name { get; set; }

        [Required]
        public string Roleplayed { get; set; }

        //Collection navigation property
        public virtual ICollection<IMDB>? IMDBs { get; set; }

    }
}
