using System.Collections.Generic;

namespace BlazorPagination
{
    public class PagedResultGeneric<T> : PagedResultBase 
    {
        public T[] Results { get; set; }
    }
}