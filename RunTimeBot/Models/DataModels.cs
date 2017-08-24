using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RunTimeBot.Models
{
    public class DataModels
    {
        public class AnswerRelation
        {
            public Models.LUIS_TYPE luisType { get; set; }
            public Models.INTENT_TYPE intentType { get; set; }
            public Models.ANSWERS answer { get; set; }
        }

        public class FullAnswerRelation
        {
            public Models.LUIS_TYPE luisType { get; set; }
            public Models.INTENT_TYPE intentType { get; set; }
            public Models.ANSWERS answer { get; set; }
            public Models.ANSWERS_TYPE answersType { get; set; }
        }

        public class LuisTypeAndTimeline
        {
            public Models.LUIS_TYPE luisType { get; set; }
            public Models.LUIS_TIMELINE luisTimeline { get; set; }
        }
        
    }
}