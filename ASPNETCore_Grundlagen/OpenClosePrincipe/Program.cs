namespace OpenClosePrincipe
{
    internal class Program
    {
        static void Main(string[] args)
        {


            PDFReportGenerator<Employee> employeePDFGenerator = new PDFReportGenerator<Employee>();
            employeePDFGenerator.Generate(new Employee());


            CRReportGenerator<Employee> cRReportGenerator = new CRReportGenerator<Employee>();
            cRReportGenerator.Generate(new Employee());
        }

         
    }

    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }


    #region AntiCode

    public class ReportGenerator
    {
        public int ReportType { get; set; }

        public void GenerateReport (Employee em)
        {
            if (ReportType == 1)
            {
                //Verwenden PDF -> (meist ist es eine DLL von einem Drittanbieter) 
            }
            else if (ReportType == 2)
            {
                //Crystal Reports (Drittanbieter mit Dll)
            }
            else if (ReportType == 3)
            {
                //List&Label 10 (Drittanbieter)
            }
            else
            {
                //Default als irgendwas 
            }
        }
    }
    #endregion

    #region Open-Close Principe


    public interface IReportGeneratorBase<T> where T: class
    {
            void Generate(T entity);
    }

    
    //Open Part: Umreißt das Problem
    public abstract class ReportGeneratorBase<T> : IReportGeneratorBase<T>
        where T : class
    {
        public abstract void Generate(T entity);

        //public virtual ReportGeneratorBase FactoryMethode (int type)
        //{
        //}
    }

    //Close Part
    public class PDFReportGenerator<T> : ReportGeneratorBase<T> where T : class
    {
        //Alle Properties sind der PDF.dll ausgerichtet 

        public override void Generate(T entity)
        {
            // T wird erstellt
        }
    }

    public class CRReportGenerator<T> : ReportGeneratorBase<T> where T : class
    {
        //Alle Properties sind der Crystal Report .dll ausgerichtet 

        public override void Generate(T entity)
        {
            // T wird erstellt
        }
    }




    #endregion
}