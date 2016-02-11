namespace BulBike.Web.Hubs
{
    using BulBike.Models;
    using Data;
    using Data.Repositories;
    using Microsoft.AspNet.SignalR;
    using Services;
    using Services.Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public class ChatHub : Hub
    {
        static List<User> ConnectedUsers = new List<User>();
        static List<ChatMessage> CurrentMessage = new List<ChatMessage>();

        public void Connect(string userName)
        {

            var id = Context.ConnectionId;

            if (ConnectedUsers.Count(x => x.UserName == userName) == 0)
            {
                ConnectedUsers.Add(new User { ConnectionId = id, UserName = userName });

                // send to caller
                Clients.Caller.onConnected(id, userName, ConnectedUsers, CurrentMessage);

                // send to all except caller client
                Clients.AllExcept(id).onNewUserConnected(id, userName);

            }

        }

        public void SendMessageToAll(string userName, string message)
        {
            // store last 100 messages in cache
            AddMessageinCache(userName, message);

            // Broad cast message
            Clients.All.messageReceived(userName, message);
        }

        public void SendPrivateMessage(string toUserId, string message)
        {

            string fromUserId = Context.ConnectionId;

            var toUser = ConnectedUsers.FirstOrDefault(x => x.ConnectionId == toUserId);
            var fromUser = ConnectedUsers.FirstOrDefault(x => x.ConnectionId == fromUserId);

            if (toUser != null && fromUser != null)
            {
                // send to 
                Clients.Client(toUserId).sendPrivateMessage(fromUserId, fromUser.UserName, message);

                // send to caller user
                Clients.Caller.sendPrivateMessage(toUserId, fromUser.UserName, message);
            }

        }

        public override System.Threading.Tasks.Task OnDisconnected(bool test)
        {
            var item = ConnectedUsers.FirstOrDefault(x => x.ConnectionId == Context.ConnectionId);
            if (item != null)
            {
                ConnectedUsers.Remove(item);

                var id = Context.ConnectionId;
                Clients.All.onUserDisconnected(id, item.UserName);

            }

            return base.OnDisconnected(test);
        }


        private void AddMessageinCache(string userName, string message)
        {
            var user = ConnectedUsers.Where(x => x.UserName == userName).FirstOrDefault();
            CurrentMessage.Add(new ChatMessage { Author = user, Message = message });

            if (CurrentMessage.Count > 100)
                CurrentMessage.RemoveAt(0);
        }
    }
}