using WildcatMicroFund.Data.Models;

namespace WildcatMicroFund.ViewModels
{
    public class TakeSurveyViewModel
    {
        public Survey Survey { get; set; }
        public SurveyCode SurveyCode { get; set; }
        public Response[] Responses { get; set; }


    }
}