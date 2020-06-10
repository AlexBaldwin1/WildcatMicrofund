using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WildcatMicroFund.Data.Models
{
    public class Question
    {
        public int ID { get; set; }
        public SurveyCode SurveyCode { get; set; }
        public int SurveyCodeID { get; set; }
        [Column(TypeName = "varchar(500)")]
        public string QuestionText { get; set; }
        [Required]
        public int QuestionNumber { get; set; }
        public QuestionType QuestionType { get; set; }
        public int QuestionTypeID{get; set;}

        public List<DateResponse> DateResponses { get; set; }
        public List<TextResponse> TextResponses { get; set; }
        public List<NumericResponse> NumericResponses { get; set; }
        public List<YesNoResponse> YesNoResponses { get; set; }
        public List<Choice > Choices { get; set; } 
        public List<ChoiceMultipleChoiceResponse> ChoiceMultipleChoiceResponses { get; set; }
        public List<SingleChoiceResponse> SingleChoiceResponses { get; set; }
    }
}