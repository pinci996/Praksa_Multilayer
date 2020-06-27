using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Common
{
    public class Page
    {
        public int Records { get; set; }
        public int Current { get; set; }

        public Page(int RecordsPerPage, int CurrentPage = 1)
        {
            this.Records = Records;
            this.Current = Current;
        }
    }
}
