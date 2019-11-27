using System;
using System.Collections.Generic;

namespace RazorSample
{
    public class PaginatedList<T> : List<T>
    {
        public PaginatedList(IEnumerable<T> source, int pageIndex, int pageSize, int count)
        {
            PageIndex = pageIndex;
            TotalPage = (int)Math.Ceiling(count / (double)pageSize);

            this.AddRange(source);
        }

        public PaginatedList(IEnumerable<T> source)
        {
            this.AddRange(source);
        }

        public int PageIndex { get; set; }
        public int TotalPage { get; set; }
        public bool HasNext
        {
            get { return PageIndex < TotalPage; }
        }
        public bool HasPrevious
        {
            get { return PageIndex > 1; }
        }
    }
}
