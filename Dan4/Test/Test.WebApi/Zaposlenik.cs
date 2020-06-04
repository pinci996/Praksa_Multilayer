using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Test.WebApi
{
    public class Zaposlenik
	{
        
		public string Name { get; set; }
		public int Age	{ get; set; }

		public Zaposlenik(string name, int age)
		{
			this.Name = name;
			this.Age =  age;
		}

	}

}
