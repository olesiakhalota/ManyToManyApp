using ManyToManyApp.Enums;

namespace ManyToManyApp.Models
{
    public class Boek
    {
        public int BoekId { get; set; }
        public string Titel { get; set; }
        public int AuteurId { get; set; }  //foreign key to Auteur 
        public Auteur? Auteur { get; set; }             //nullable
        
        public bool IsAvailable { get; set; }
        public bool IsNewRelease { get; set; }
        public bool IsBestSeller { get; set; }
        public BindingType? BindingType { get; set; }   //nullable


        public string? AfbeeldingPad { get; set; } = "/images/default.jpg";   //Переход изображения

        
        // MAKE RELATIONS HERE WITH OTHER TABLE
        public ICollection<Genre> Genres { get; set; } = new List<Genre>();        //een boek kan tot mindere genre hebben => 1 ganre kan mindere boeken hebben 
        public ICollection<BoekGenre> BoekGenres { get; set; } = new List<BoekGenre>();  //initialization in constructor 




    }
}
