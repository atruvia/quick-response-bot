using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Bot_Application3
{
    public class ConversationStarter
    {
        //Note: Of course you don't want these here. Eventually you will need to save these in some table
        //Having them here as static variables means we can only remember one user :)
        private static string fromId;
        private static string fromName;
        private static string toId;
        private static string toName;
        private static string serviceUrl;
        private static string channelId;
        private static string conversationId;

        private static ChannelAccount userAccount;
        private static ChannelAccount botAccount;
        private static ConnectorClient connector;


        public static void forceSendingInformation(IMessageActivity message)
        {
            //We need to keep this data so we know who to send the message to. Assume this would be stored somewhere, e.g. an Azure Table
            toId = message.From.Id;
            toName = message.From.Name;
            fromId = message.Recipient.Id;
            fromName = message.Recipient.Name;
            serviceUrl = message.ServiceUrl;
            channelId = message.ChannelId;
            conversationId = message.Conversation.Id;

            botAccount = new ChannelAccount(toId, toName);
            userAccount = new ChannelAccount(fromId, fromName);

            /*userAccount = new ChannelAccount(toId, toName);
            botAccount = new ChannelAccount(fromId, fromName);*/
            connector = new ConnectorClient(new Uri(serviceUrl));
        }

        public static void sendingInformation(IMessageActivity message)
        {
            
            if (string.IsNullOrEmpty(toId) && string.IsNullOrEmpty(toName) &&
                string.IsNullOrEmpty(fromId) && string.IsNullOrEmpty(fromName) &&
                string.IsNullOrEmpty(serviceUrl) && string.IsNullOrEmpty(channelId) &&
                string.IsNullOrEmpty(conversationId))
            {
                toId = message.From.Id;
                toName = message.From.Name;
                fromId = message.Recipient.Id;
                fromName = message.Recipient.Name;
                serviceUrl = message.ServiceUrl;
                channelId = message.ChannelId;
                conversationId = message.Conversation.Id;

                /*botAccount = new ChannelAccount(toId, toName);
                userAccount = new ChannelAccount(fromId, fromName);*/

                userAccount = new ChannelAccount(toId, toName);
                botAccount = new ChannelAccount(fromId, fromName);
                connector = new ConnectorClient(new Uri(serviceUrl));
            }
        }



        //This will send an adhoc message to the user
        public static async Task SendToConversationAsync(string text)
        {
            IMessageActivity message = Activity.CreateMessageActivity();
            if (!string.IsNullOrEmpty(conversationId) && !string.IsNullOrEmpty(channelId))
            {
                message.ChannelId = channelId;
            }
            else
            {
                conversationId = (await connector.Conversations.CreateDirectConversationAsync(botAccount, userAccount)).Id;
            }

            message.From = botAccount;
            message.Recipient = userAccount;
            message.Conversation = new ConversationAccount(id: conversationId);
            message.Text = text;
            message.Locale = "de-De";
            Activity activity = (Activity)message;
            await connector.Conversations.SendToConversationAsync(activity);

        }

        public static async Task SayToConversationAsync(Activity message)
        {
            if (!string.IsNullOrEmpty(conversationId) && !string.IsNullOrEmpty(channelId))
            {
                message.ChannelId = channelId;
            }
            else
            {
                conversationId = (await connector.Conversations.CreateDirectConversationAsync(botAccount, userAccount)).Id;
            }

            await connector.Conversations.ReplyToActivityAsync(message);
        }

    }
}