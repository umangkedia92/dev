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
        string _fullName = "";
        string _username = "";
        string _sysid = "";

        [HttpPost, Route("api/alexa/demo")]
        public async Task<dynamic> Snowy(AlexaRequest alexaRequest)
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

        public bool Authenticate()
        {
            using (var db = new snowyAlexa_Entities())
            {
                var dataset = db.UserAuthenticateds
                .Select(x => new { x.FullName, x.UserId, x.SysId }).ToList();
                _fullName = dataset.Count > 0 ? dataset?.First()?.FullName ?? "" : "";
                _username = dataset.Count > 0 ? dataset.First()?.UserId ?? "" : "";
                _sysid = dataset.Count > 0 ? dataset.First()?.SysId ?? "" : "";
            }
            if (_fullName == "" || _username == "" || _sysid == "")
            {
                return false;
            }
            else return true;

        }
        private AlexaResponse LaunchRequestHandler(Request request)
        {

            bool _authenticated = Authenticate();

            if (!_authenticated)
            {
                var response = new AlexaResponse("Please Authenticate yourself and try again! Make sure you look in the WebCam Properly!");
                response.Session.MemberId = (int)request.MemberId;
                response.Response.Card.Title = "dAssist Service Desk";
                response.Response.Card.Content = "Please Authenticate Yourself ";
                response.Response.Reprompt.OutputSpeech.Text = "I was not able to authenticate, Please authenticate.";
                response.Response.ShouldEndSession = true;
                return response;

            }
            else
            {
                var response = new AlexaResponse("Hey " + _fullName + " !! This is snowy from Deloitte Help Desk. I can help you to create incidents in Service Now. Tell me, How can I help you today ? ");
                response.Session.MemberId = (int)request.MemberId;
                response.Response.Card.Title = "dAssist Service Desk";
                response.Response.Card.Content = "How can I help you today ? ";
                response.Response.Reprompt.OutputSpeech.Text = "Tell me about the incident";
                response.Response.ShouldEndSession = false;

                return response;
            }
        }

        private async Task<AlexaResponse> IntentRequestHandler(Request request)
        {
            bool _authenticated = Authenticate();

            if (!_authenticated)
            {
                var response = new AlexaResponse("Please Authenticate yourself and try again! Make sure you look in the WebCam Properly!");
                response.Session.MemberId = (int)request.MemberId;
                response.Response.Card.Title = "dAssist Service Desk";
                response.Response.Card.Content = "Please Authenticate Yourself ";
                response.Response.Reprompt.OutputSpeech.Text = "I was not able to authenticate, Please authenticate.";
                response.Response.ShouldEndSession = true;
                return response;

            }
            else
            {
                AlexaResponse response;

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
                            response = new AlexaResponse(1);
                            response.Response.Directives.Add(x);
                            return response;
                        }
                        else
                        {
                            response = new AlexaResponse();
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
                            response = new AlexaResponse(1);
                            response.Response.Directives.Add(x);
                            return response;
                        }
                        else
                        {
                            response = new AlexaResponse();
                            response = await GetIncidentIntent(request);

                        }
                        break;
                    case "AMAZON.CancelIntent":
                    case "AMAZON.StopIntent":
                        response = new AlexaResponse();
                        response = CancelOrStopIntentHandler(request);
                        break;
                    case "AMAZON.YesIntent":
                        response = new AlexaResponse();
                        response = YesIntentHandler(request);
                        break;
                    case "AMAZON.NoIntent":
                        response = new AlexaResponse();
                        response = NoIntentHandler(request);
                        break;
                    case "AMAZON.HelpIntent":
                        response = new AlexaResponse();
                        response = HelpIntent(request);
                        break;
                    default:
                        response = new AlexaResponse();
                        response = FallBack(request);
                        break;

                }

                return response;
            }
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
            item.CallerId = _sysid;
            var number = await snowHelper.CreateSnowIncident(item);
            var response = new AlexaResponse("Thank you "+_fullName+"! Your service Request " + number + " is created. We will soon assign this to someone and get it resolved on Priority. Should I help you with anything else?");
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

            var IncidentNumber = "INC00" + number;
            Incident i = await snowHelper.GetIncidentById(IncidentNumber);
            var response = new AlexaResponse("Thank you "+_fullName+" ,your ticket is Assigned to " + i.AssignmentGroup + " Assignment Group and is being worked upon. Do you need any additional help ?");
            response.Session.MemberId = (int)request.MemberId;
            response.Response.Card.Title = "Incident NUmber: " + IncidentNumber + " is assigned to " + i.AssignmentGroup + "Assignment Group and is being worked upon. Do you need any additional help?";
            response.Response.Card.Content = "We will soon get it resolved.";
            response.Response.ShouldEndSession = false;
            return response;
        }

        private AlexaResponse HelpIntent(Request request)
        {
            var response = new AlexaResponse("You can ask me to create an Incident or Get Incident Status from Service Now, I would be happy to help.", false);
            response.Response.Reprompt.OutputSpeech.Text = "Please ask me to Create an Incident ! ";
            return response;
        }
        private AlexaResponse FallBack(Request request)
        {
            var response = new AlexaResponse("Sorry..! I didn't understand you..! Can you say that again ?", false);
            response.Response.Reprompt.OutputSpeech.Text = "Please ask me to Create an Incident ! ";
            return response;
        }
        private AlexaResponse CancelOrStopIntentHandler(Request request)
        {
            return new AlexaResponse("Thanks for listening, let's talk again soon.", true);

        }
        private AlexaResponse YesIntentHandler(Request request)
        {
           return HelpIntent(request);
           

        }
        private AlexaResponse NoIntentHandler(Request request)
        {
            using (var db = new snowyAlexa_Entities())
            {
                var all = from c in db.UserAuthenticateds select c;
                db.UserAuthenticateds.RemoveRange(all);
                db.SaveChanges();
            }

            return new AlexaResponse("Thanks for listening, let's talk again soon.", true);

        }


        private AlexaResponse SessionEndedRequestHandler(Request request)
        {
            return null;
        }




    }
}
