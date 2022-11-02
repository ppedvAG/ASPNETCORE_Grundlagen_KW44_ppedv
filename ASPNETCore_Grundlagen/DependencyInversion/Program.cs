namespace DependencyInversion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ICarService service = new CarService();
            service.Repair(new MockCar());
        }
    }

    #region BadCode

    //Programmierer A: 5 Tage (Von Tag 1 bis Tag 5)
    public class BadCar
    {
        public int Id { get; set; } 
        public string Brand { get; set; }
        public string Type { get; set; }
    }

    //Programmierer B: 3 Tage (Von Tag 5 bis 8) Zeitgleiche Programmierung geht weniger -> Modifizierungen bei BadCar führen zur Überprüfungen in den bestehenden Implementierungen (Wechselwirkungen) 

    public class BadCarService
    {

        //Feste Kopplung -> BadCarService Klasse, kennt BadCar
        public void Repair (BadCar car) 
        {
            //repariere das Auto 
        }
    }
    #endregion

    #region Dependency Inversion

    public interface ICar
    {
        int Id { get; set; }
        string Brand { get; set; }  
        string Model { get; set; }
    }

    public interface ICarV2 : ICar
    {
        public string Color { get; set; }
    }



    public interface ICarService
    {
        void Repair (ICar car); 
    }




    //Programmierer A (5Tage) -> (Tag 1 -> Tag 5)

    public class Car : ICar
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
    }

    //Programmierer B (3 Tage) -> (Tag 1 -> Tag 3)
    public class CarService : ICarService
    {
        public void Repair(ICar car) //lose Kopplung 
        {
            //Auto repariert 
        }
    }

    //Programmierer B baut an Tag 4 ein Mock-Objekt und testet seine Repair-Methode

    public class MockCar : ICar
    {
        public int Id { get; set; } = 1;
        public string Brand { get; set; } = "BMW";
        public string Model { get; set; } = "Z8";
    }




    #endregion
}