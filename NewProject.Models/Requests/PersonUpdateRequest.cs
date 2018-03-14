using System.ComponentModel.DataAnnotations;

namespace NewProject.Models.Requests
{
    public class PersonUpdateRequest: PersonAddRequest
    {
        [Required]
        public int AccountId { get; set; }
    }
}
