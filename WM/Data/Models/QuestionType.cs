using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WildcatMicroFund.Data.Models
{
    public class QuestionType
    {
        public int ID { get; set; }
        [Required]
        [Column(TypeName = "varchar(500)")]
        public string QuestionTypeName {get; set;}
        [DefaultValue("false")]
        public bool QuestionTypeHasChoices { get; set; }
        
        public List<Question> Questions { get; set; }
    }
}