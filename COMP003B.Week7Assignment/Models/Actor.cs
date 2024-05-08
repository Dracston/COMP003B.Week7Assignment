using System.ComponentModel.DataAnnotations;

namespace COMP003B.Week7Assignment.Models
{
    public class Actor
    {
        public int actorId { get; set; }

        [Required]
        public string actorName { get; set; }

        [Required]
        public string rolePlayed { get; set; }

        //Collection navigation property
        public virtual ICollection<IMDB>? IMDBs { get; set; }

    }
}
