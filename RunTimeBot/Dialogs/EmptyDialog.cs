using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using RunTimeBot.Utils;
using RunTimeBot.Models;

namespace RunTimeBot.Dialogs
{
    public class EmptyDialog : IDialog<object>
    {
        public async Task StartAsync(IDialogContext context)
        {
            LuisResult luisResult = null;
            string luisType = "";
            context.ConversationData.TryGetValue("EmptyLuisResult", out luisResult);
            context.ConversationData.TryGetValue("LuisType", out luisType);

            string intentName = luisResult.Intents[0].Intent;
            DataModels.AnswerRelation answer = Utils.Utils.getRandomAnswer(luisType, intentName);
            
            await context.SayAsync(answer.answer.text);
            context.Done<object>(null);
        }

        
    }
}