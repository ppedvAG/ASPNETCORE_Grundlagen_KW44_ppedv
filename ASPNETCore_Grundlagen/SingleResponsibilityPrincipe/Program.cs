namespace SingleResponsibilityPrincipe
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
        }
    }


    #region Anti-Code

    public class BadEmployee
    {
        //Datensatz -> Entity haben keine Methoden (POCO - Objects) 
        public int Id { get; set; } 
        public string Name { get; set; }

        //Speicher Datensatz in DB -> DAL z.b in einem Repository - Pattern 
        public void InsertEmployee(BadEmployee employee)
        {
            //Speichere etwas in eine Datenbank
        }

        //
        public void GenerateReport(BadEmployee employee)
        {
            //erstelle ein Report 
        }
    }

    #endregion

    #region Lösung

    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    //Repository Design Pattern: EmployeeRepository bildet das CRUD (Create, Read, Update, Delete) gegenüber
    //der Employee Tabelle. Eine Repository Klasse <-> Eine DB-Tabelle (1:1) 
    public class EmployeeRepository
    {
        public void Insert(Employee employee)
            => Console.WriteLine("Speicher in DB");

        //Update

        //Delete

        //GetById oder GetAll 
    }

    public class ReportGenerator
    {
        public void GenerateReport (Employee em)
            => Console.WriteLine("Erstelle ein Report");
    }
    #endregion
}