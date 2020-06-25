using System;

namespace WildcatMicroFund.Data.Models
{
    public class DateResponse
    {
        public int ID { get; set; }
        public int ResponseID { get; set; }
        public Response Response { get; set; }
        public int QuestionID { get; set; }
        public Question Question { get; set; }
        public DateTime ResponseDate{get; set;}

    }
}