using System;
using System.Collections.Generic;
using System.Text;
using Test.Model.Common;

namespace Test.Model
{
    class Adresses : IAdresses
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
    }
}

