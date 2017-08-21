using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RunTimeBot.Utils
{
    [Serializable]
    public class Utils
    {
        //SELECT * FROM INTENT_TYPE AS IT, ANSWERS AS A WHERE IT.Id = A.intent_type_id AND IT.Name = 'RT_JENS'
        /*public static List<Models.ANSWER> getAnswersForIntent(string intentName)
        {
            Models.RELANA_DBEntities DB = new Models.RELANA_DBEntities();

            List<Models.ANSWER> listOfMatches = (from answers in DB.ANSWERS
                                                 join intentType in DB.INTENT_TYPE on answers.intent_type_id equals intentType.Id
                                                 where intentType.Name == intentName
                                                 select answers
                                                 ).ToList();
            return listOfMatches;

        }

        public static Models.ANSWER getRandomAnswerForIntent(string intentName)
        {
            List<Models.ANSWER> answers = getAnswersForIntent(intentName);
            int randomNumber = new Random().Next(0, answers.Count);
            return answers[randomNumber];
        }*/
    }
}


