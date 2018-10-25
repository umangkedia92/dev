using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnowyAlexa.Data
{
    public class SnowGetIncidents
    {
        public IncidentResult result { get; set; }
        
    }
    public class IncidentResult
    {
        public List<Incident> Result { get; set; }
    }
    public class Incident
    {
        public string IncidentNumber { get; set; }
        public string ContactType { get; set; }
        public string Caller { get; set; }
        public string State { get; set; }
        public string Category { get; set; }
        public string SubCategory { get; set; }
        public string Impact { get; set; }
        public string AssignmentGroup { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string CreatedOn { get; set; }
        public string UpdatedOn { get; set; }
    }

}