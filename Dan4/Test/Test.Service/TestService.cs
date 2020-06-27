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
using Test.Common;



namespace Test.Service
{
    public class TestService : ITestService
    {
        protected ITestRepository Repository { get; private set; }

        public TestService(ITestRepository repository)
        {
            this.Repository = repository;
        }


        public List<Users> osobe = new List<Users>();

        public List<Adresses> adrese = new List<Adresses>();

        //TestRepository repository = new TestRepository();

        public TestService() { }

        public async Task <List<Users>> ReadUsersAsync()
        {
           return await Repository.GetAllOsobeAsync();
        }


        public async  Task<List<Adresses>> ReadAdressesAsync()
        {
            return await Repository.GetAllAdreseAsync();
        }


        public async Task<List<Users>> FilteringMethod(Filter filter, Page page, Sort sort)
        {
            
            return await Repository.FilteringMethod(filter, page, sort);
            
        }

        public async Task UpdateDataAsync(Users user)
        {
            await Repository.UpdateUserAsync(user);
        }


        public async Task AddDataAsync(Users user)
        {
            await Repository.AddNewUserAsync(user);
        }


        public async Task RemoveDataAsync(int Id)
        {
            await Repository.DeleteUserAsync(Id);
        }
    }
}

