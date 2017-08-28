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
    // This Class is the main core of the bot, here the new answers for the created intents are fetched
    // from the database. In the constructor you can see a detailed explanation of the code.

    public class EmptyDialog : IDialog<object>
    {
        
        public async Task StartAsync(IDialogContext context)
        {
            LuisResult luisResult = null;
            string luisType = "";
            //Getting the Luis precessed result.
            context.ConversationData.TryGetValue("EmptyLuisResult", out luisResult);

            // Getting the Name of the luis to look in. 
            context.ConversationData.TryGetValue("LuisType", out luisType);

            // Name of the intent triggered by Luis.
            string intentName = luisResult.Intents[0].Intent;

            //Getting the random answer from database.
            DataModels.AnswerRelation answer = Utils.Utils.getRandomAnswer(luisType, intentName);
            
            //Sending the reply to the user.
            await context.SayAsync(answer.answer.text);
            context.Done<object>(null);
        }

        
    }
}