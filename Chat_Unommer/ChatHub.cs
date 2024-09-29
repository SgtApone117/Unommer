using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Unommer;
using Unommer.Chat_Unommer;
using Microsoft.AspNet.SignalR;

namespace Unommer.Chat_Unommer
{
    public class ChatHub: Hub
    {
        static List<Users> ConnectedUsers = new List<Users>();
        static List<Messages> CurrentMessage = new List<Messages>();
        ConnClass ConnC = new ConnClass();

        public void Connect(string username, string Userid)
        {
            var id = Context.ConnectionId;


            if (ConnectedUsers.Count(x => x.ConnectionId == id) == 0)
            {
                string UserImg = GetUserImage(Convert.ToInt32(Userid));
                string logintime = DateTime.Now.ToString();
                string Useremail = GetUsermail(Convert.ToInt32(Userid));

                ConnectedUsers.Add(new Users { ConnectionId = id, UserName = username, ID = Convert.ToInt32(Userid), UserImage = UserImg, LoginTime = logintime, Email = Useremail });
                // send to caller
                Clients.Caller.onConnected(id, username, ConnectedUsers, CurrentMessage, Convert.ToInt32(Userid), Useremail);

                // send to all except caller client
                Clients.AllExcept(id).onNewUserConnected(id, username, UserImg, logintime, Useremail);
            }
        }

        public void SendMessageToAll(string Userid, string userName, string message, string time, string email)
        {
            //int Userid1 = Convert.ToInt32(Userid);
            string UserImg = GetUserImage1(userName);
            // store last 100 messages in cache
            AddMessageinCache(userName, message, time, UserImg, email);

            // Broad cast message
            Clients.All.messageReceived(userName, message, time, UserImg);

        }

        private void AddMessageinCache(string userName, string message, string time, string UserImg, string email)
        {
            CurrentMessage.Add(new Messages { UserName = userName, Message = message, Time = time, UserImage = UserImg, Email = email });

            //Messages dataobj = new Messages();
            //dataobj.UserName = userName;
            //dataobj.Message = message;
            //dataobj.Email = email;
            //Chathistory.InsertChatHistory(dataobj);

            if (CurrentMessage.Count > 100)
                CurrentMessage.RemoveAt(0);
        }

        // Clear Chat History
        public void clearTimeout()
        {
            CurrentMessage.Clear();
        }

        public string GetUserImage(int Userid)
        {
            string RetimgName = "Images/dummy.png";
            //int Userid= Convert.ToInt32()
            try
            {
                string query = "select Photo from UMR_Users where ID='" + Userid + "'";
                string ImageName = ConnC.GetColumnVal(query, "Photo");

                if (ImageName != "")
                    RetimgName = "Images/DP/" + ImageName;
            }
            catch (Exception ex)
            { }
            return RetimgName;
        }

        public string GetUsermail(int Userid)
        {
            string Usermail = "";
                    try
                    {
                        string query = "select user_mail from UMR_Users where ID='" + Userid + "'";
                        string ImageName = ConnC.GetColumnVal(query, "user_mail");

                        if (ImageName != "")
                            Usermail = ImageName;
                    }
                    catch (Exception ex)
                    { }
                    return Usermail;

        }

        public string GetUserImage1(string userName)
        {
            string RetimgName = "Images/dummy.png";
            //int Userid= Convert.ToInt32()
            try
            {
                string query = "select Photo from UMR_Users where u_name='" + userName + "'";
                string ImageName = ConnC.GetColumnVal(query, "Photo");

                if (ImageName != "")
                    RetimgName = "Images/DP/" + ImageName;
            }
            catch (Exception ex)
            { }
            return RetimgName;
        }


        public override System.Threading.Tasks.Task OnDisconnected(bool stopCalled)
        {
            var item = ConnectedUsers.FirstOrDefault(x => x.ConnectionId == Context.ConnectionId);
            if (item != null)
            {
                ConnectedUsers.Remove(item);

                var id = Context.ConnectionId;
                Clients.All.onUserDisconnected(id, item.UserName);

            }
            return base.OnDisconnected(stopCalled);
        }

        public void SendPrivateMessage(string toUserId, string message)
        {

            string fromUserId = Context.ConnectionId;

            var toUser = ConnectedUsers.FirstOrDefault(x => x.ConnectionId == toUserId);
            var fromUser = ConnectedUsers.FirstOrDefault(x => x.ConnectionId == fromUserId);

            if (toUser != null && fromUser != null)
            {
                string CurrentDateTime = DateTime.Now.ToString();
                string UserImg = GetUserImage(fromUser.ID);
                // send to 
                Clients.Client(toUserId).sendPrivateMessage(fromUserId, fromUser.UserName, message, UserImg, CurrentDateTime);

                // send to caller user
                Clients.Caller.sendPrivateMessage(toUserId, toUser.UserName, message, UserImg, CurrentDateTime);
                Messages dataobj = new Messages();
                dataobj.FromUserName = fromUser.UserName;
                dataobj.ToUserName = toUser.UserName;
                dataobj.FromEmail = fromUser.Email;
                dataobj.ToEmail = toUser.Email;
                dataobj.Message = message;
                //dataobj.Email = email;
                ChatHistory.InsertPrivateChatHistory(dataobj);
            }

        }
    }
}