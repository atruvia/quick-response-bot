using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Microsoft.Bot.Connector;
using Newtonsoft.Json;
using Bot_Application3;
using Microsoft.Bot.Builder.Dialogs;
using RunTimeBot.Dialogs;
using RunTimeBot.RootDialogs;

namespace RunTimeBot
{
    [BotAuthentication]
    public class MessagesController : ApiController
    {
        /// <summary>
        /// POST: api/Messages
        /// Receive a message from a user and reply to it
        /// </summary>
        /// 

        

        public async Task<HttpResponseMessage> Post([FromBody]Activity activity)
        {
            ConversationStarter.sendingInformation(activity.AsMessageActivity());

            if (activity != null && activity.GetActivityType() == ActivityTypes.Message)
            {
                activity.Locale = "de-DE";
                ConnectorClient connector = new ConnectorClient(new Uri(activity.ServiceUrl));

                Activity reply = activity.CreateReply();
                reply.Type = ActivityTypes.Typing;
                reply.Text = null;
                await ConversationStarter.SayToConversationAsync(reply);
                string luisSelection = Utils.Utils.getLastLuisTimeLine().luisType.Name;
                // return our reply to the user
                switch (luisSelection.ToLower())
                {
                    case "ewi":
                        await Conversation.SendAsync(activity, () => new RootDialogEWI());
                        break;
                    case "host":
                        await Conversation.SendAsync(activity, () => new RootDialogHost());
                        break;
                    case "runtime":
                        await Conversation.SendAsync(activity, () => new RootDialogRuntime());
                        break;
                }
            }
            else
            {
                HandleSystemMessage(activity);
            }
            var response = Request.CreateResponse(HttpStatusCode.OK);
            return response;
        }

        private Activity HandleSystemMessage(Activity message)
        {
            if (message.Type == ActivityTypes.DeleteUserData)
            {
                // Implement user deletion here
                // If we handle user deletion, return a real message
            }
            else if (message.Type == ActivityTypes.ConversationUpdate)
            {
                // Handle conversation state changes, like members being added and removed
                // Use Activity.MembersAdded and Activity.MembersRemoved and Activity.Action for info
                // Not available in all channels
            }
            else if (message.Type == ActivityTypes.ContactRelationUpdate)
            {
                // Handle add/remove from contact lists
                // Activity.From + Activity.Action represent what happened
            }
            else if (message.Type == ActivityTypes.Typing)
            {
                // Handle knowing tha the user is typing
            }
            else if (message.Type == ActivityTypes.Ping)
            {
            }

            return null;
        }
    }
}