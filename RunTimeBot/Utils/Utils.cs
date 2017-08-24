using RunTimeBot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RunTimeBot.Utils
{
    // [Serializable]
    public class Utils
    {
        //SELECT * FROM INTENT_TYPE AS IT, ANSWERS AS A WHERE IT.Id = A.intent_type_id AND IT.Name = 'RT_JENS'
        /*public static List<Models.ANSWERS> getAnswers(string intentName)
        {
            Models.QRBot_DBEntities DB = new Models.QRBot_DBEntities();

            List<Models.ANSWERS> listOfMatches = (from intentType in DB.INTENT_TYPE
                                                  join answers in DB.ANSWERS on intentType.Id equals answers.intent_type_id
                                                  where intentType.name == intentName
                                                  select answers
                                                 ).ToList();
            return listOfMatches;

        }*/

        public static DataModels.LuisTypeAndTimeline getLastLuisTimeLine()
        {
            Models.QRBot_DBEntities DB = new Models.QRBot_DBEntities();

            DataModels.LuisTypeAndTimeline listOfMatches = (from luisTimeLine in DB.LUIS_TIMELINE
                                                            join luisType in DB.LUIS_TYPE on luisTimeLine.luis_type_id equals luisType.Id
                                                            select new DataModels.LuisTypeAndTimeline
                                                            {
                                                                luisTimeline = luisTimeLine,
                                                                luisType = luisType
                                                            }).OrderByDescending(i => i.luisTimeline.Date).FirstOrDefault();
            return listOfMatches;
        }

        //Get answers depending on luisname, and intent name
        public static List<DataModels.AnswerRelation> getAnswers(string luisName, string intentName)
        {
            Models.QRBot_DBEntities DB = new Models.QRBot_DBEntities();

            List<DataModels.AnswerRelation> listOfMatches = (from luis_type in DB.LUIS_TYPE
                                                             join intentType in DB.INTENT_TYPE on luis_type.Id equals intentType.luis_id
                                                             join answer in DB.ANSWERS on intentType.Id equals answer.intent_type_id
                                                             where luis_type.Name == luisName && intentType.name == intentName
                                                             select new DataModels.AnswerRelation
                                                             {
                                                                 luisType = luis_type,
                                                                 intentType = intentType,
                                                                 answer = answer
                                                             }
                                                 ).ToList();
            return listOfMatches;
        }

        //Get answers depending on luisname, intentname and asnwertype
        public static List<DataModels.FullAnswerRelation> getAnswers(string luisName, string intentName, string answertype)
        {
            Models.QRBot_DBEntities DB = new Models.QRBot_DBEntities();

            List<DataModels.FullAnswerRelation> listOfMatches = (from luis_type in DB.LUIS_TYPE
                                                                 join intentType in DB.INTENT_TYPE on luis_type.Id equals intentType.luis_id
                                                                 join answer in DB.ANSWERS on intentType.Id equals answer.intent_type_id
                                                                 join answersType in DB.ANSWERS_TYPE on answer.answer_type_id equals answersType.Id
                                                                 where luis_type.Name == luisName && intentType.name == intentName && answersType.type == answertype
                                                                 select new DataModels.FullAnswerRelation
                                                                 {
                                                                     luisType = luis_type,
                                                                     intentType = intentType,
                                                                     answer = answer,
                                                                     answersType = answersType
                                                                 }).ToList();
            return listOfMatches;
        }

        public static DataModels.AnswerRelation getRandomAnswer(string luisName, string intentName)
        {
            List<DataModels.AnswerRelation> answers = getAnswers(luisName, intentName);
            int randomNumber = new Random().Next(0, answers.Count);
            return answers[randomNumber];
        }

        public static DataModels.FullAnswerRelation getRandomAnswer(string luisName, string intentName, string answertype)
        {
            List<DataModels.FullAnswerRelation> answers = getAnswers(luisName, intentName, answertype);
            int randomNumber = new Random().Next(0, answers.Count);
            return answers[randomNumber];
        }
    }
}


