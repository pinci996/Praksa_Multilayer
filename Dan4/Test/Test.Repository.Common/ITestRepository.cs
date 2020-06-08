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
        Task<List<Users>> GetAllOsobeAsync();

        Task<List<Adresses>> GetAllAdreseAsync();

        Task AddNewUserAsync(Users user);

        Task UpdateUserAsync(Users user);

        Task DeleteUserAsync(int Id);
    }
}
