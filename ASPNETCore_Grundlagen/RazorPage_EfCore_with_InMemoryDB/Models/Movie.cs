namespace RazorPage_EfCore_with_InMemoryDB.Models
{
    public class Movie
    {
        //Ef Core erkennt an dem Namen Id, dass es sich um einen PK handelt
        public int Id { get; set; } 

        public string Title { get; set; }

        public string Description { get; set; } 

        public decimal Preis { get; set; }

        public GenreType Genre { get; set; }
    }


    //enums werden als integer-wert abgespeichert
    public enum GenreType { Aciton, Thriller, Drama, Romance, Family, ScieneFiction, Horror, Comedy, Docu}

}
