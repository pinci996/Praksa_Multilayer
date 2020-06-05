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



namespace Test.Service
{
    public class TestService : ITestService
    {
        public List<Users> osobe = new List<Users>();

        public List<Adresses> adrese = new List<Adresses>();

        TestRepository repository = new TestRepository();

        public TestService() { }

        public List<Users> ReadUsers()
        {
            osobe = repository.GetAllOsobe();
            return osobe;
        }


        public List<Adresses> ReadAdresses()
        {
            adrese = repository.GetAllAdrese();
            return adrese;
        }

        public void UpdateData(Users user)
        {
            repository.UpdateUser(user);
        }


        public void AddData (Users user)
        {
            repository.AddNewUser(user);
        }


        public void RemoveData(int Id)
        {
            repository.DeleteUser(Id);
        }
    }
}
