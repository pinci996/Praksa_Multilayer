using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Model.Common;
using Test.Repository.Common;
using Test.Model;
using System.Data.SqlClient;
using System.Runtime.Remoting.Messaging;
using Test.Common;

namespace Test.Repository
{
    public class TestRepository : ITestRepository
    {
        public List<Users> osobe = new List<Users>();
        public List<Adresses> adrese = new List<Adresses>();
        

        string ConnectionStr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Praksa;Integrated Security=True";
        

        public async Task<List<Users>> GetAllOsobeAsync()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionStr))
            {

                string queryString = "SELECT * FROM users;";

                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    osobe.Add(new Users { Id = reader.GetInt32(0), Name = reader.GetString(1), Age = reader.GetInt32(2) });
                }
                reader.Close();
            }
            return await Task.FromResult(osobe);
        }


        public async  Task<List<Adresses>> GetAllAdreseAsync()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionStr))
            {

                string queryString = "SELECT * FROM adresses;";

                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    adrese.Add(new Adresses { Id = reader.GetInt32(0), Street = reader.GetString(1), City = reader.GetString(2) });
                }
                reader.Close();
                }
                 return await Task.FromResult(adrese);
        }

        public async Task<List<Users>> FilteringMethod (Filter filter, Page page, Sort sort)
        {

            using (SqlConnection connection = new SqlConnection(ConnectionStr))
            {
                SqlCommand command = new SqlCommand($"WITH Ordered AS(SELECT *, ROW_NUMBER() OVER(ORDER BY {sort.sortProperty} {sort.sortBy}) AS 'RowNumber'FROM users where {filter.filterBy} like '%{filter.filterCondition}%') SELECT id,username,age FROM Ordered WHERE RowNumber BETWEEN {page.Current }*{page.Records} AND {page.Current}*{page.Records}+{page.Records};",
                connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    osobe.Add(new Users { Id = reader.GetInt32(0), Name = reader.GetString(1), Age = reader.GetInt32(2) });
                }
                reader.Close();
                connection.Close();
            }
            return await Task.FromResult(osobe);
        }

        public async Task AddNewUserAsync(Users user)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionStr))
            {
                string queryString = "INSERT INTO users (id, username, age) VALUES ('" + user.Id + "','" + user.Name + "','" + user.Age + "' );";

                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                reader.Close();
                connection.Close();
            }
            await Task.Delay(1000);
        }


        public async Task UpdateUserAsync(Users user)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionStr))
            {
                string queryString = "UPDATE users SET username = '" + user.Name + "', age = '" + user.Age + "' WHERE id = '" + user.Id + "';";

                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                reader.Close();
                connection.Close();
            }
            await Task.Delay(2000);
        }


        public async Task DeleteUserAsync(int Id)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionStr))
            {
                string queryString = "DELETE FROM adresses WHERE id = '" + Id + "'; " +
                                     "DELETE FROM checkouts WHERE id = '" + Id + "';";

                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                reader.Close();
                connection.Close();
            }
            await Task.Delay(1000);
        }
    }
        
}
        
    

