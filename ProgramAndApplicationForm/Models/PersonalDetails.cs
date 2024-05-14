using ProgramAndApplicationForm.Models.Common;

namespace ProgramAndApplicationForm.Models
{
    public class PersonalDetails : BaseModel
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required string Phone { get; set; }
        public required string Gender { get; set; }
        public required string Nationality { get; set; }
        public required string CurrentResidence { get; set; }
        public int IdNumber { get; set; }
        public required string DateOfBirth { get; set; }
    }
}
