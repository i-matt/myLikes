using NewProject.Models.Requests;
using System;

namespace NewProject.Models.Domain
{
    public class Account : AccountUpdateRequest
    {
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
