using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace MultiModel_API.Models
{
    [Table("QuestionsAnswer_Tb")]
    public class QuestionModel
    {
        [Key]
        public int Id { get; set; }
        public string QuestionDescription { get; set; }
        public string Answer { get; set; }
    }
}