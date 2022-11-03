using RazorPage_EfCore_with_InMemoryDB.Models;
using System.ComponentModel.DataAnnotations;

namespace RazorPage_EfCore_with_InMemoryDB.Attributes
{
    public class ClassicMovieAttribute : ValidationAttribute
    {
        public int Year { get; set; }

        public ClassicMovieAttribute(int year)
            => Year = year;

        public string GetErrorMessage() =>
            $"Klassiker Movies sind vor dem Jahr {Year} erschienen";

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            Movie movie = (Movie)validationContext.ObjectInstance;


            int releaseYear = (int)value!;

          

            if (movie.Genre == GenreType.Classic && releaseYear > Year)
            {
                return new ValidationResult(GetErrorMessage());
            }
            
            return ValidationResult.Success;
        }

    }
}
