using System.Collections.Generic;

namespace WildcatMicroFund.Data.Models
{
    public class Survey
    {
        public int ID { get; set; }
        public SurveyCode SurveyCode { get; set; }
        public int SurveyCodeID { get; set; }
        public List<Application>? Applications { get; set; }
        public List<Response> Responses { get; set; }
    }
}