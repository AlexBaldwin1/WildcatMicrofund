using System;
using System.ComponentModel.DataAnnotations;

namespace WildcatMicroFund.Data.Models
{
    public class Response
    {
        public int ID { get; set; }
        [Required]
        public DateTime ResponseDate { get; set; }
        [Required]
        public int UserID;       
        public User User;
        [Required]
        public int SurveyID { get; set; }
        public Survey Survey { get; set; }
        
        // Different types of responses
        public DateResponse DateResponse { get; set; }
        public int DateResponseID { get; internal set; }
        public TextResponse TextResponse { get; set; }
        public int TextResponseID { get; set; }
        
    }
}