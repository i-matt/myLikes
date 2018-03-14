using System.Collections.Generic;

namespace NewProject.Models.Response
{
    public class ItemListResponse<T> : SuccessResponse
    {
        public List<T> Items { get; set; }
    }
}
