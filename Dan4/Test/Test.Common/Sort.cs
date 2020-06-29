using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Common
{
        public class Sort : ISort
        {
            // default values
            public string OrderBy { get; set; } = "Age";
            public string AscDesc { get; set; } = "ASC";
        }
}

