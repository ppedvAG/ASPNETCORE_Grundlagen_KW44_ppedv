namespace RazorPages_IOCContainer_Sample.Services
{
    public class TimeService : ITimeService
    {
        private string currentTime; 


        //Wenn Konstruktor auferufen wird, soll die Uhrzeit festgehalten werden
        public TimeService()
        {
            currentTime = DateTime.Now.ToShortTimeString();
        }

        public string GetCurrentTime()
        {
            return currentTime;
        }
    }
}
