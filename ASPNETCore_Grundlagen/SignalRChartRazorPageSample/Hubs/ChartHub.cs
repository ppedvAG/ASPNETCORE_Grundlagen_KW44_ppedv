using Microsoft.AspNetCore.SignalR;

namespace SignalRChartRazorPageSample.Hubs
{
    public class ChartHub : Hub
    {
        public const string Url = "/chart";
    }
}
