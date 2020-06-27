using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Common
{
    public class Sort
    {
        public string sortBy { get; set; }
        public string sortProperty { get; set; }

        public Sort (string sortBy, string sortProperty)
        {
            this.sortBy = sortBy;
            this.sortProperty = sortProperty;
        }
    }
}
