using System.ComponentModel.DataAnnotations;

namespace NewProject.Models.Requests
{
    public class AccountAddRequest
    {
        [Required]
        public string Email { get; set; }

        [MaxLength(128)]
        public string ModifiedBy { get; set; }
    }
}
