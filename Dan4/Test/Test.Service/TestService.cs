using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Model.Common;
using Test.Repository.Common;
using Test.Service.Common;
using Test.Repository;
using Test.Model;
using Test.Service;
using Test.WebApi.Controllers;
using Test.WebApi.Models;

namespace Test.Service
{
    public class TestService : ITestService
    {
        public List<Osoba> osobe = new List<Osoba>();
        public List<Osoba> GetAllOsobe()
        {
            return null;
        }

        public List<Adresa> adrese = new List<Adresa>();
        public List<Adresa> GetAllAdrese()
        {
            return null;
        }
    }
}
