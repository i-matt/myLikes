using System;
using System.ComponentModel.DataAnnotations;

namespace NewProject.Models.Requests
{
    public class PersonAddRequest
    {
        [Required]
        public int AccountId { get; set; }

        //[Required]
        public int PhotoId { get; set; }

        [Required, MaxLength(15)]
        public string Username { get; set; }

        [Required]
        public bool Gender { get; set; }

        [MaxLength(128)]
        public string ModifiedBy { get; set; }
    }
}
