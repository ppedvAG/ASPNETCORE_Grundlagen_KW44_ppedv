namespace LizkovischesPrincipe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }

    #region AntiCode

    public class Erdbeere
    {
        public string GetColor()
            => "red";
    }

    public class Kirsche : Erdbeere
    {
        public string GetColor()
            => base.GetColor();
    }


    #endregion

    #region Mit Open Close

    public abstract class Fruits
    {
        public abstract string GetColor();
    }

    public class Erdbeer : Fruits
    {
        public override string GetColor()
        {
            return "red";
        }
    }

    public class Cheery : Fruits
    {
        public override string GetColor()
        {
            return "red";
        }
    }

    #endregion
}