namespace BulBike.Web.Hubs
{
    using Microsoft.AspNet.SignalR;

    public class ChatHub : Hub
    {
        public void Send(string message)
        {
            var username = Context.User.Identity.Name;
            Clients.All.addNewMessageToPage(username, message);
        }
    }
}