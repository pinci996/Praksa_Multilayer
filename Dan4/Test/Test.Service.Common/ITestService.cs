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
        Task<List<Users>> ReadUsersAsync();

        Task<List<Adresses>> ReadAdressesAsync();

        Task UpdateDataAsync(Users user);

        Task AddDataAsync(Users user);
        
        Task RemoveDataAsync(int Id);
    }
}
