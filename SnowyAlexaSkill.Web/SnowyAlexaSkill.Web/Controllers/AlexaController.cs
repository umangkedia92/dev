using Newtonsoft.Json;
using SnowyAlexa.Data;
using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web.Http;
using System.Threading.Tasks;
using SnowyAlexaSkill.Web.Helpers;

namespace SnowyAlexaSkill.Web.Controllers
{
    public class AlexaController : ApiController
    {

        [HttpPost, Route("api/alexa/demo")]
        public async Task<dynamic> Pluralsight(AlexaRequest alexaRequest)
        {
            var request = new Requests().Create(new Request
            {
                MemberId = (alexaRequest.Session.Attributes == null) ? 0 : alexaRequest.Session.Attributes.MemberId,
                TimeStamp = alexaRequest.Request.Timestamp,
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
                DateCreated = DateTime.UtcNow,
                DialogState = alexaRequest.Request.dialogState
            });

            AlexaResponse response = null;

            switch (request.Type)
            {
                case "LaunchRequest":
                    response = LaunchRequestHandler(request);
                    break;
                case "IntentRequest":
                    response = await IntentRequestHandler(request);
                    break;
                case "SessionEndedRequest":
                    response = SessionEndedRequestHandler(request);
                    break;
            }

            return response;
        }

        private AlexaResponse LaunchRequestHandler(Request request)
        {
            var response = new AlexaResponse("Hey..!! This is snowy from Deloitte Help Desk. I can help you to create incidents in Service Now. Tell me, How can I help you today ? ");
            response.Session.MemberId = (int)request.MemberId;
            response.Response.Card.Title = "dAssist Service Desk";
            response.Response.Card.Content = "How can I help you today ? ";
            response.Response.Reprompt.OutputSpeech.Text = "Tell me about the incident";
            response.Response.ShouldEndSession = false;

            return response;
        }

        private async Task<AlexaResponse> IntentRequestHandler(Request request)
        {
            AlexaResponse response = new AlexaResponse(1);
            
              // Dialog is now complete and all required slots should be filled,
                // so call your normal intent handler. 
                //handlePlanMyTripIntent(intent, session, callback);

                switch (request.Intent)
                {
                    case "CreateIncidentIntent":
                        if ((request.DialogState == "STARTED") || (request.DialogState != "COMPLETED"))
                        {
                            // Pre-fill slots: update the intent object with slot values for which
                            // you have defaults, then return Dialog.Delegate with this updated intent
                            // in the updatedIntent property.
                            AlexaResponse.ResponseAttributes.DirectiveAttributes x = new AlexaResponse.ResponseAttributes.DirectiveAttributes()
                            {
                                Type = "Dialog.Delegate"
                            };
                            response.Response.Directives.Add(x);
                            return response;
                        }
                        else
                        {
                            response = await CreateIncidentIntent(request);

                        }
                       
                        break;
                    case "GetIncidentIntent":
                        if ((request.DialogState == "STARTED") || (request.DialogState != "COMPLETED"))
                        {
                            // Pre-fill slots: update the intent object with slot values for which
                            // you have defaults, then return Dialog.Delegate with this updated intent
                            // in the updatedIntent property.
                            AlexaResponse.ResponseAttributes.DirectiveAttributes x = new AlexaResponse.ResponseAttributes.DirectiveAttributes()
                            {
                                Type = "Dialog.Delegate"
                            };
                            response.Response.Directives.Add(x);
                            return response;
                        }
                        else
                        {
                            response = await GetIncidentIntent(request);

                        }
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

        private async Task<AlexaResponse> CreateIncidentIntent(Request request)
        {
            SnowHelper snowHelper = new SnowHelper();
            SnowRequest item = new SnowRequest();
            foreach (var a in request.SlotsList)
            {
                if (a.Key.Equals("IncidentDescription"))
                {
                    item.Description = a.Value;
                    item.ShortDescription = a.Value;
                }
                if (a.Key.Equals("Category")) item.Category = a.Value;
                if (a.Key.Equals("Priority")) item.Impact = a.Value;
            }
            //var number = getIncidentNumber(item);
            var number = await snowHelper.CreateSnowIncident(item);
            var response = new AlexaResponse("Thank you! Your service Request "+number+" is created. We will soon assign this to someone and get it resolved on Priority");
            response.Session.MemberId = (int)request.MemberId;
            response.Response.Card.Title = "Incident NUmber: " + number + " is created";
            response.Response.Card.Content = "We will soon assign this to someone and get it resolved.";
            response.Response.ShouldEndSession = false;
            return response;
        }

        private async Task<AlexaResponse> GetIncidentIntent(Request request)
        {
            SnowHelper snowHelper = new SnowHelper();
            string number = "10001";
            foreach (var a in request.SlotsList)
            {
                if (a.Key.Equals("incidentnumber"))
                {
                     number = a.Value;
                }
            }

            var IncidentNumber = "INC00" + number ; 
            Incident i = await snowHelper.GetIncidentById(IncidentNumber);
            var response = new AlexaResponse("Your ticket is Assigned to " + i.AssignmentGroup + " Assignment Group");
            response.Session.MemberId = (int)request.MemberId;
            response.Response.Card.Title = "Incident NUmber: " + IncidentNumber + " is assigned to " + i.AssignmentGroup + "Assignment Group and is being worked upon.";
            response.Response.Card.Content = "We will soon get it resolved.";
            response.Response.ShouldEndSession = false;
            return response;
        }

            private AlexaResponse HelpIntent(Request request)
        {
            var response = new AlexaResponse("This is Snowy..! You can ask me to create Service Incidents, Get Incident Status, or know all your incidents", false);
            response.Response.Reprompt.OutputSpeech.Text = "Please ask me to Create an Incident ! ";
            return response;
        }

        private AlexaResponse CancelOrStopIntentHandler(Request request)
        {
            return new AlexaResponse("Thanks for listening, let's talk again soon.", true);
        }

        
        private AlexaResponse SessionEndedRequestHandler(Request request)
        {
            return null;
        }

        
    }
}
