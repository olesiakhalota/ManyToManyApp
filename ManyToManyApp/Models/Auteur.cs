using System.ComponentModel.DataAnnotations;

namespace ManyToManyApp.Models
{
    public class Auteur
    {
        //[Key]
        public int AuteurId { get; set; } //naam van de klass + id => automatish primary key by convention

        public string Naam { get; set; }

        public ICollection<Boek> Boeken { get; set; } // ICollection - is lightweight proprerties than IList 




    }
}
