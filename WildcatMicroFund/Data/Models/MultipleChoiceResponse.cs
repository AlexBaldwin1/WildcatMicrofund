﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace WildcatMicroFund.Data.Models
{
    public class MultipleChoiceResponse

    {
        public int ID { get; set; }
        public int? ChoiceID { get; set; }
        public Choice Choice { get; set; }
        public int ResponseID { get; set; }
        public Response Response { get; set; }
        public int QuestionID { get; set; }
        public Question Question { get; set; }
    }

}