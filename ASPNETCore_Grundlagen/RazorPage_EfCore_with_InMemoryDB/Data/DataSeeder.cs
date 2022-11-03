namespace RazorPage_EfCore_with_InMemoryDB.Data
{
    public static class DataSeeder
    {
        public static void SeedMoviesInDB(MovieDbContext context)
        {
            //Ist die Movie Tabelle leer?
            if (!context.Movies.Any())
            {
                //UnitOfPattern -> Bedeutet: Speichern/Updaten und Löschen in zwei Schritten:

                //Schritt1: Datensatz wird mit Add z.B vorgemerkt, dass dieser Datensatz bei SaveChanges an die DB übertragen wird
                //Schritt2: SaveChanges generiert SQL und überträgt die Änderungen an die DB 

                context.Movies.Add(new Models.Movie { Id = 1, Title = "Coda", Description = "Singtalent", Genre = Models.GenreType.Family, Preis = 10 });
                context.Movies.Add(new Models.Movie { Id = 2, Title = "Batman", Description = "Harley Quinn und Batman heiraten", Genre = Models.GenreType.ScieneFiction, Preis = 12 });
                context.Movies.Add(new Models.Movie { Id = 3, Title = "Jurassic Park", Description = "T-Rex wird Veganer", Genre = Models.GenreType.ScieneFiction, Preis = 11 });
                context.SaveChanges();
            }
        }
    }
}
