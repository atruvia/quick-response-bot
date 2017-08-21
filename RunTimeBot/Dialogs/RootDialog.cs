using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace RunTimeBot.Dialogs
{
    [Serializable]
    [LuisModel("e21fb8de-a053-4f72-834f-79b549733119", "5923a149179a40e0bd3177b3755976b3")]
    public class RootDialog : LuisDialog<object>
    {

        public async Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceived);
        }

        [LuisIntent("None")]
        public async Task noneIntent(IDialogContext context, IAwaitable<IMessageActivity> awaitableResult, LuisResult result)
        {
            /*string answer = Answers.getRandomAnswer(Answers.AnswersTypes.NONE);
            await context.SayAsync(answer);
            MyHttpRequests.SaveInNotUnderstoodIntent(result.Query);
            Util.storageInLogs(result.Query, 4, answer, DateTime.Now);
            context.Wait(MessageReceived);*/
        }

        [LuisIntent("")]
        public async Task emptyIntent(IDialogContext context, LuisResult result)
        {
            context.ConversationData.SetValue("EmptyLuisResult", result);
            context.Call(new EmptyDialog(), ResumeAfter);
        }

    }
}