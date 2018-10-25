using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Configuration;
using System.Text;
using System.Web.Http;
using SnowyAlexa.Data;
using System.Threading.Tasks;

namespace SnowyAlexaSkill.Web.Helpers
{
    public class SnowHelper
    {
        private readonly HttpClient _client;
        private readonly string _serviceNowUrl;
        private readonly string _queryUrl;

        public SnowHelper()
        {
            _serviceNowUrl = ConfigurationManager.AppSettings["ServiceNowInstanceUrl"]; 
             _client = new HttpClient
            {
                BaseAddress = new Uri(_serviceNowUrl)
            };

            _queryUrl = "https://dev57638.service-now.com/api/now/table/incident?sysparm_display_value=true&sysparm_fields=number%2Ccontact_type%2Ccaller_id%2Cstate%2Ccategory%2Csubcategory%2Cimpact%2Cassignment_group%2Cshort_description%2Cdescription%2Csys_created_on%2Csys_updated_on";
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            // get user name and password from config
            var username = ConfigurationManager.AppSettings["ServiceNowUserName"];
            var password = ConfigurationManager.AppSettings["ServiceNowPassword"];
            var authHeaderVal = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes($"{username}:{password}")));

            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authHeaderVal.Parameter);
        }

        public async Task<string> CreateSnowIncident(SnowRequest item)
        {
            var jsonInput = JsonConvert.SerializeObject(item,
            Formatting.Indented,
            new JsonSerializerSettings
            {
                DefaultValueHandling = DefaultValueHandling.Ignore,
                NullValueHandling = NullValueHandling.Ignore
            });

            var content = new StringContent(jsonInput, Encoding.UTF8, "application/json");
            //content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await _client.PostAsync(_queryUrl, content);
            if (response.IsSuccessStatusCode)
            {
                dynamic resultContent = JsonConvert.DeserializeObject(
                    await response.Content.ReadAsStringAsync());
                string number = resultContent.result.number;

                return number;

            }
            else
            {
                var statusCode = (int)response.StatusCode;
                if (statusCode == 401)
                {
                    throw new HttpResponseException(new HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized));
                }
                else
                {
                    throw new Exception($"Data access failed, {(int)response.StatusCode} ({response.ReasonPhrase}) method: CreateIncident");
                }
            } 
        }

        public async Task<Incident> GetIncidentById(string incidentTicketId)
        {
        
            var createResponse = await _client.GetAsync(_serviceNowUrl + "api/278192/incidents_custom/getincidents/number/" + incidentTicketId);

            if (createResponse.IsSuccessStatusCode)
            {
                var response = await createResponse.Content.ReadAsAsync<SnowGetIncidents>();
                Incident incident = response.result.Result.FirstOrDefault();

                if (incident != null)
                {
                    return incident;
                }

                return null;
            }
            else
            {
                var statusCode = (int)createResponse.StatusCode;
                if (statusCode == 401)
                {
                    throw new HttpResponseException(new HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized));
                }
                else
                {
                    throw new Exception($"Data access failed ,{(int)createResponse.StatusCode} ({createResponse.ReasonPhrase})");
                }
            }
        }
    }
}