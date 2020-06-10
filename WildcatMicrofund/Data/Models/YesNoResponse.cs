namespace WildcatMicroFund.Data.Models
{
    public class YesNoResponse

    {
        public int ResponseID { get; set; }
        public Response Response { get; set; }
        public int QuestionID { get; set; }
        public Question Question { get; set; }
        public bool YesNoResponseValue { get; set; }
    }
}