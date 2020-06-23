 using System;
using System.Collections.Generic;
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
        public TextResponse TextResponse { get; set; }
        public NumericResponse NumericResponse { get; set; }
        public YesNoResponse  YesNoResponse { get; set; }
        public List<MultipleChoiceResponse> MultipleChoiceResponses { get; set; }
        public SingleChoiceResponse SingleChoiceResponse { get; set; }


    }
}