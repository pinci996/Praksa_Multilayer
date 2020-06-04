using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace Test.Model.Common
{
    public interface IUsers
    {
        int Id { get; set; }
        string Name { get; set; }
        int Age { get; set; }
    }
}
