using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace StateManagementSample.Models
{
    //POCO Objecte 
    public class Movie
    {
        //Konvention EFCore sucht in POCOs nach einer Property, die eine Id im Namen der Variable beinhaltet (Id, MovieId)

        public int Id { get; set; }

        [Display(Name = "Titel"), Required(ErrorMessage = "Title Reqired")] //Bei Localisation ist 'Title Required' der Key in der Ressouce-DAtei mit seiner Übersetzungsausgabe

        public string Title { get; set; }


        [Display(Name = "Beschreibung")]
        [MaxLength(100)]
        public string Description { get; set; }


        [Range(0.1, 100)]
        public decimal Price { get; set; }


        [Required]
        public GenreTyp Genre { get; set; }
    }

    public enum GenreTyp { Action, Thriller, Drama, Romantic, Horror, Comedy, Animation, Biogrpahy, Docu }

}
