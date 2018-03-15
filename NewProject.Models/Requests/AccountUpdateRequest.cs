using System.ComponentModel.DataAnnotations;

namespace NewProject.Models.Requests
{
    public class AccountUpdateRequest: AccountAddRequest
    {
        [Required]
        public int Id { get; set; }
    }
}
