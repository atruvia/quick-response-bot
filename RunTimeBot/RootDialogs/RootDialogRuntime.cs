using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;
using Microsoft.Bot.Connector;
using RunTimeBot.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace RunTimeBot.RootDialogs
{
    [Serializable]
    [LuisModel("883c95b7-234e-4e35-b819-c9275daa002c", "fc1b1e5e79784e808b89962386b0126a")]
    public class RootDialogRuntime : LuisDialog<object>
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
            await context.SayAsync("Hallo, Ich Bin Quick Response Bot");
        }

        [LuisIntent("")]
        public async Task emptyIntent(IDialogContext context, LuisResult result)
        {
            context.ConversationData.SetValue("EmptyLuisResult", result);
            context.ConversationData.SetValue("LuisType", "Runtime");
            context.Call(new EmptyDialog(), ResumeAfter);
        }

        private async Task ResumeAfter(IDialogContext context, IAwaitable<object> result)
        {
            try
            {
                var res = await result;
            }
            catch (Exception ex)
            {

            }
            finally
            {
                context.Wait(MessageReceived);
            }
        }

    }
}