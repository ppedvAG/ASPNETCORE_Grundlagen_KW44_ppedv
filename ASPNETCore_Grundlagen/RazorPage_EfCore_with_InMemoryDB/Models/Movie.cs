using RazorPage_EfCore_with_InMemoryDB.Attributes;
using System.ComponentModel.DataAnnotations;

namespace RazorPage_EfCore_with_InMemoryDB.Models
{
    public class Movie
    {
        //Ef Core erkennt an dem Namen Id, dass es sich um einen PK handelt
        public int Id { get; set; }

        [Required]
        [MaxLength(15)]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Range(0, 100)]
        public decimal Preis { get; set; }


        public GenreType Genre { get; set; }

        [ClassicMovie(1970)]
        public int Year { get; set; }

        public bool WinOscar { get; set; } = false;
    }


    //enums werden als integer-wert abgespeichert
    public enum GenreType { Action, Thriller, Drama, Romance, Family, ScieneFiction, Horror, Comedy, Classic, Docu}

}
