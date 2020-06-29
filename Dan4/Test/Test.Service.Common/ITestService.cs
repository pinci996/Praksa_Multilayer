using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Model;
using Test.Common;



namespace Test.Service.Common
{
    public interface ITestService
    {
        //Task<List<Users>> ReadUsersAsync();

        Task<List<Adresses>> ReadAdressesAsync();

        Task<List<Users>> FilteringMethod(Filter filter, Page page, Sort sort);

        Task UpdateDataAsync(Users user);

        Task AddDataAsync(Users user);
        
        Task RemoveDataAsync(int Id);
    }
}
