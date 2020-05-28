using System.Collections.Generic;

namespace WildcatMicroFund.Data.Models
{
    public class SurveyCode
    {
        public int ID { get; set; }
        public string SurveyName { get; set; }
        public List<Survey> Surveys { get; set; }
    }
}