namespace ManyToManyApp.Models
{
    public class BoekGenre
    {
        //BridgeTabel
        public int BoekId { get; set; }   //composit key - 2> primary keys
        public Boek Boek { get; set; }

        public int GenreId { get; set; }  //composit key - 2> primary keys
        public Genre Genre { get; set; }



    }
}
