using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Model.Common;
using Test.Model;



namespace Test.Repository.Common
{
    public interface ITestRepository
    {
        List<Users> GetAllOsobe();

        List<Adresses> GetAllAdrese();
    }
}
