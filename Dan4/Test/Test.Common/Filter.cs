using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Common
{
    public class Filter
    {
        public string filterBy { get; set; }
        public string filterCondition { get; set; }

        public Filter(string filterBy, string filterCondition)
        {
            this.filterBy = filterBy;
            this.filterCondition = filterCondition;
           
        }
    }
}
