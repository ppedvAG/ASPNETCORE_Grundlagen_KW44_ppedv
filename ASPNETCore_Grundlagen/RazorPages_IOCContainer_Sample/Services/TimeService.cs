namespace RazorPages_IOCContainer_Sample.Services
{
    public class TimeService : ITimeService
    {
        private string currentTime; 
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
