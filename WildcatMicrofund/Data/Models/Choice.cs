using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WildcatMicroFund.Data.Models
{
    public class Choice

    {
        public int ID { get; set; }
        [Column(TypeName = "varchar(500)")]
        public string ChoiceText { get; set; }
        public int QuestionID { get; set; }
        [Required]
        Question Question { get; set; }
    }
}