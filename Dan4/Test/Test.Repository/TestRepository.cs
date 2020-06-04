using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Model.Common;
using Test.Repository.Common;
using Test.Model;
using Test.WebApi;
using System.Data.SqlClient;
using Test.WebApi.Models;
using System.Runtime.Remoting.Messaging;

namespace Test.Repository
{
    public class TestRepository : ITestRepository
    {
        public List<Osoba> osobe = new List<Osoba>();
        public List<Adresa> adrese = new List<Adresa>();
        string ConnectionStr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Praksa;Integrated Security=True";
        public List<Osoba> GetAllOsobe()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionStr))
            {

                string queryString = "SELECT * FROM osobe;";

                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    osobe.Add(new Osoba { Id = reader.GetInt32(0), Name = reader.GetString(1), Age = reader.GetInt32(2) });
                }
                reader.Close();
                connection.Close();
            }
            return osobe;
        }
        public List<Adresa> GetAllAdrese()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionStr))
            {

                string queryString = "SELECT * FROM adresses;";

                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    adrese.Add(new Adresa { Id = reader.GetInt32(0), Street = reader.GetString(1), City = reader.GetString(2) });
                }
                reader.Close();
                connection.Close();
            }
            return adrese;
        }

        public void AddNewUser()
        {
            
        }

        public void UpdateUser()
        {

        }

        public void DeleteUser(int id)
        {

        }
    }
        
}
        
    

