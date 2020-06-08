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

        public async Task <List<Users>> ReadUsersAsync()
        {
           return await repository.GetAllOsobeAsync();
        }


        public async  Task<List<Adresses>> ReadAdressesAsync()
        {
            return await repository.GetAllAdreseAsync();
        }

       public async Task UpdateDataAsync(Users user)
        {
            await repository.UpdateUserAsync(user);
        }


        public async Task AddDataAsync(Users user)
        {
            await repository.AddNewUserAsync(user);
        }


        public async Task RemoveDataAsync(int Id)
        {
            await repository.DeleteUserAsync(Id);
        }
    }
}
