namespace InterfaceSegregationPrinciple
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }


    #region bad code
    public interface IVehicle
    {
        void Drive();
        void Fly();
        void Swim();

    }

    public class Vehicle : IVehicle
    {
        public void Drive()
        {
           //Kann fahren
        }

        public void Fly()
        {
            //Kann fliegen
        }

        public void Swim()
        {
            //Kann schwimmen
        }
    }


    public class AmphipischesFahrezeug : IVehicle
    {
        public void Drive()
        {
            //Kann fahren
        }

        public void Swim()
        {
            //Kann schwimmen
        }

        public void Fly()
        {
            throw new NotImplementedException();
        }
    }
    #endregion



    #region Lösung

    public interface IFly
    {
        void Fly();
    }

    public interface IDrive
    {
        void Drive();
    }

    public interface ISwim
    {
        void Swim();
    }

    public class AmphFahrzeug : ISwim, IDrive
    {
        public void Drive()
        {
            //Fahren
        }

        public void Swim()
        {
            //Schwimmen
        }
    }
    #endregion
}