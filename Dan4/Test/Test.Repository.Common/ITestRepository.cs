using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Model.Common;
using Test.Model;
using Test.WebApi.Models;

namespace Test.Repository.Common
{
    public interface ITestRepository
    {
        List<Osoba> GetAllOsobe();

        List<Adresa> GetAllAdrese();
    }
}
