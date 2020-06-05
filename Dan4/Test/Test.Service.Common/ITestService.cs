using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Model;



namespace Test.Service.Common
{
    public interface ITestService
    {
        List<Users> ReadUsers();
        List<Adresses> ReadAdresses();
        void UpdateData(Users user);
        void AddData(Users user);
        void RemoveData(int Id);
    }
}
