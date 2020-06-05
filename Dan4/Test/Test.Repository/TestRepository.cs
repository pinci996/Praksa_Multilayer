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

namespace Test.Repository
{
    public class TestRepository : ITestRepository
    {
        public List<Users> osobe = new List<Users>();
        public List<Adresses> adrese = new List<Adresses>();
        

        string ConnectionStr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Praksa;Integrated Security=True";
        

        public List<Users> GetAllOsobe()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionStr))
            {

                string queryString = "SELECT * FROM osobe;";

                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    osobe.Add(new Users { Id = reader.GetInt32(0), Name = reader.GetString(1), Age = reader.GetInt32(2) });
                }
                reader.Close();
            }
            return osobe;
        }


        public List<Adresses> GetAllAdrese()
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
                connection.Close();
            }
            return adrese;
        }


        public void AddNewUser(Users user)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionStr))
            {
                string queryString = "INSERT INTO users (id, username, age) VALUES ('" + user.Id + "','" + user.Name + "','" + user.Age + "' );";

                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
            }
        }


        public void UpdateUser(Users user)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionStr))
            {
                string queryString = "UPDATE users SET username = '" + user.Name + "', age = '" + user.Age + "' WHERE id = '" + user.Id + "';";

                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
            }
        }


        public void DeleteUser(int Id)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionStr))
            {
                string queryString = "DELETE FROM adresses WHERE id = '" + Id + "'; " +
                                     "DELETE FROM checkouts WHERE id = '" + Id + "';";

                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
            }
        }
    }
        
}
        
    

