using System;
using System.Collections.Generic;
using System.Text;

namespace DDDDemo.DTO
{
    public class PagingResult<T>
    {
        public IEnumerable<T> Items { get; set; }
        public int TotalCount { get; set; }
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
    }
}
