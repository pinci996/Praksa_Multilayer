using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Common
{
    public class Filter : IFilter
    {
        public string Name { get; set; } = "";
        public int Age { get; set; } = 0;

        //public Filter(string filterBy, string filterCondition)
        //{
        //    this.filterBy = filterBy;
        //    this.filterCondition = filterCondition;
           
        //}
    }
}
