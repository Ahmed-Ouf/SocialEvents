using Beneficiary.Web.Models;
using Microsoft.AspNet.SignalR;

namespace Beneficiary.Web.Helpers
{
    public class NotificationHub : Hub
    {
        public void Notify(RequestViewModel request)
        {
            Clients.All.Notify(request);
        }
    }
}