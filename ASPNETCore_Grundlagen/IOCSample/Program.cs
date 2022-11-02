using Microsoft.Extensions.DependencyInjection;

namespace IOCSample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Was verwendet man in einem IOC Container 
            //Anwort: Services 

            //Bitte nicht sauer sein -> ich verwende jetzt einen einfachen Datensatz um einfach das 
            //ergebnis schneller zu präsentieren 



            #region Initialisierungs-Part IOC-Container: DIE SERVICECOLLECTION 

            IServiceCollection services = new ServiceCollection();  

            //ICar mockCar = new MockCar();
            services.AddSingleton<ICar, MockCar>();


            //Initialisierungphase ist 'services.BuildServiceProvider();' fertig

            IServiceProvider serviceProvider = services.BuildServiceProvider();
            #endregion



            #region Der Zugriff auf den IOC Container

            //Bei nichtfinden von ICar im IOC Container, wird eine NULL zurück gegeben
            ICar? mockCar = serviceProvider.GetService<ICar>();

            //Bei nichtfinden von ICar im IOC Container, wird eine Exception geworfen
            ICar mockCar2 = serviceProvider.GetRequiredService<ICar>();

            #endregion
        }
    }


    #region Dependency Inversion

    public interface ICar
    {
        string Id { get; set; }
        string Brand { get; set; }
        string Model { get; set; }
    }

    public interface ICarV2 : ICar
    {
        public string Color { get; set; }
    }



    public interface ICarService
    {
        void Repair(ICar car);
    }




    //Programmierer A (5Tage) -> (Tag 1 -> Tag 5)

    public class Car : ICar
    {
        public string Id { get; set; }
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
        public string Id { get; set; } = 1;
        public string Brand { get; set; } = "BMW";
        public string Model { get; set; } = "Z8";
    }




    #endregion
}