using System;
using System.Collections.Generic;
using Test.Model.Common;

namespace Test.Model
{
    public class Users : IUsers
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

    }
}
