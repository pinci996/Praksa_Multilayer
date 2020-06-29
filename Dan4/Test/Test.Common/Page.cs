using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Common
{
    public class Page : IPage
    {
        public Page()
        {
            this.PageSize = recordsOnPage;
            this.PageIndex = currentPage;
        }
        // default values 
        public int recordsOnPage { get; set; } = 5;
        public int currentPage { get; set; } = 1;

        public int PageIndex { get; set; }
        public int PageSize { get; set; } 
        public int TotalPages { get; set; }
    }
}
