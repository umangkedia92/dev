using AlexaSkill.Data;
using System;
using System.Linq;
using System.Text;
using System.Web.Http;

namespace AlexaSkill.Controllers
{
    public class AlexaController : ApiController
    {
        [HttpPost, Route("api/alexa/demo")]
        public dynamic Pluralsight(AlexaRequest alexaRequest)
        {
            var request = new Requests().Create(new Data.Request
            {
                MemberId = (alexaRequest.Session.Attributes == null) ? 0 : alexaRequest.Session.Attributes.MemberId,
                Timestamp = alexaRequest.Request.Timestamp,
                Intent = (alexaRequest.Request.Intent == null) ? "" : alexaRequest.Request.Intent.Name,
                AppId = alexaRequest.Session.Application.ApplicationId,
                RequestId = alexaRequest.Request.RequestId,
                SessionId = alexaRequest.Session.SessionId,
                UserId = alexaRequest.Session.User.UserId,
                IsNew = alexaRequest.Session.New,
                Version = alexaRequest.Version,
                Type = alexaRequest.Request.Type,
                Reason = alexaRequest.Request.Reason,
                SlotsList = alexaRequest.Request.Intent.GetSlots(),
                DateCreated = DateTime.UtcNow
            });

            AlexaResponse response = null;

            switch (request.Type)
            {
                case "LaunchRequest":
                    response = LaunchRequestHandler(request);
                    break;
                case "IntentRequest":
                    response = IntentRequestHandler(request);
                    break;
                case "SessionEndedRequest":
                    response = SessionEndedRequestHandler(request);
                    break;
            }

            return response;
        }

        private AlexaResponse LaunchRequestHandler(Request request)
        {
            var response = new AlexaResponse("Welcome to Plural sight. What would you like to hear, the Top Courses or New Courses?");
            response.Session.MemberId = request.MemberId;
            response.Response.Card.Title = "Pluralsight";
            response.Response.Card.Content = "Hello\ncruel world!";
            response.Response.Reprompt.OutputSpeech.Text = "Please pick one, Top Courses or New Courses?";
            response.Response.ShouldEndSession = false;

            return response;
        }

        private AlexaResponse IntentRequestHandler(Request request)
        {
            AlexaResponse response = null;

            switch (request.Intent)
            {
                case "NewCoursesIntent":
                    response = NewCoursesIntentHandler(request);
                    break;
                case "TopCoursesIntent":
                    response = TopCoursesIntentHandler(request);
                    break;
                case "AMAZON.CancelIntent":
                case "AMAZON.StopIntent":
                    response = CancelOrStopIntentHandler(request);
                    break;
                case "AMAZON.HelpIntent":
                    response = HelpIntent(request);
                    break;
            }

            return response;
        }

        private AlexaResponse HelpIntent(Request request)
        {
            var response = new AlexaResponse("To use the Plural sight skill, you can say, Alexa, ask Plural sight for top courses, to retrieve the top courses or say, Alexa, ask Plural sight for the new courses, to retrieve the latest new courses. You can also say, Alexa, stop or Alexa, cancel, at any time to exit the Plural sight skill. For now, do you want to hear the Top Courses or New Courses?", false);
            response.Response.Reprompt.OutputSpeech.Text = "Please select one, top courses or new courses?";
            return response;
        }

        private AlexaResponse CancelOrStopIntentHandler(Request request)
        {
            return new AlexaResponse("Thanks for listening, let's talk again soon.", true);
        }

        private AlexaResponse NewCoursesIntentHandler(Request request)
        {
            var output = new StringBuilder("Here are the latest courses. ");

            using (var db = new alexademo2_dbEntities())
            {
                db.Courses.Take(10).OrderByDescending(c => c.DateCreated).ToList()
                    .ForEach(c => output.AppendFormat("{0} by {1}. ", c.Title, c.Author));
            }

            return new AlexaResponse(output.ToString());
        }

        private AlexaResponse TopCoursesIntentHandler(Request request)
        {
            int limit = 10;
            var criteria = string.Empty;

            if (request.SlotsList.Any())
            {
                int maxLimit = 10;
                var limitValue = request.SlotsList.FirstOrDefault(s => s.Key == "Limit").Value;

                if (!string.IsNullOrWhiteSpace(limitValue) && int.TryParse(limitValue, out limit) && !(limit >= 1 && limit <= maxLimit))
                {
                    limit = maxLimit;
                }

                criteria = request.SlotsList.FirstOrDefault(s => s.Key == "Criteria").Value;
            }

            var output = new StringBuilder();
            output.AppendFormat("Here are the top {0} {1}. ", limit, string.IsNullOrWhiteSpace(criteria) ? "courses" : criteria);

            using (var db = new alexademo2_dbEntities())
            {
                if (criteria == "authors")
                    db.Courses.Take(limit).OrderByDescending(c => c.Votes).ToList()
                        .ForEach(c => output.AppendFormat("{0}. ", c.Author));
                else
                    db.Courses.Take(limit).OrderByDescending(c => c.Votes).ToList()
                        .ForEach(c => output.AppendFormat("{0} by {1}. ", c.Title, c.Author));
            }

            return new AlexaResponse(output.ToString());
        }

        private AlexaResponse SessionEndedRequestHandler(Request request)
        {
            return null;
        }
    }
}
