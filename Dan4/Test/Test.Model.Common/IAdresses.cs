using System;
using System.Collections.Generic;
using System.Text;

namespace Test.Model.Common
{
    public interface IAdresses
    {
        int Id { get; set; }
        string Street { get; set; }
        string City { get; set; }
    }
}
