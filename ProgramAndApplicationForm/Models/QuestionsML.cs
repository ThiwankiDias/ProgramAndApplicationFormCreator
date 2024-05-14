using Microsoft.AspNetCore.Mvc.RazorPages;
using ProgramAndApplicationForm.Models.Common;

namespace ProgramAndApplicationForm.Models
{
    public class QuestionsML : BaseModel
    {
        public int Id { get; set; }
        public required string QuestionName { get; set; }
        public required string QuestionType { get; set; }

    }
}
