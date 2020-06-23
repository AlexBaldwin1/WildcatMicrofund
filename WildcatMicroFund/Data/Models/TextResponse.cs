namespace WildcatMicroFund.Data.Models
{
    public class TextResponse

    {
        public int ID { get; set; }
        public int ResponseID { get; set; }
        public Response Response { get; set; }
        public int QuestionID { get; set; }
        public Question Question { get; set; }
        public string ResponseText { get; set; }
    }
}