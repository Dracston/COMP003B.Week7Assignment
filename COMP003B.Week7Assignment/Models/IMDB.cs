namespace COMP003B.Week7Assignment.Models
{
    public class IMDB
    {

        public int Id { get; set; }
        public int movieId { get; set; }
        public int actorId { get; set; }

        //Nullable navigation properties
        public virtual Actor? Actor { get; set; }
        public virtual Movie? Movie { get; set; }

    }
}
