using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Test.WebApi
{
    public class AddData
    {
        public static void AddToDb(SqlConnection connectionStr, Zaposlenik zaposlenik)
        {

            string name = zaposlenik.Name;
            int age = zaposlenik.Age;
            int id = 0;

            using (connectionStr)
            {
                SqlCommand command = new SqlCommand(
                  "SELECT id FROM users;",
                  connectionStr);
                connectionStr.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {                   
                    while (reader.Read())
                    {               
                        id= reader.GetInt32(0);

            }
                }
                id = id + 1;
                reader.Close();

                string queryString =
                $"Insert into users values ({id},'{name}',{age});";
                SqlDataAdapter adapter = new SqlDataAdapter(queryString, connectionStr);
                DataSet newZaposlenik = new DataSet();
                adapter.Fill(newZaposlenik, "users");
            }
             connectionStr.Close();
            return;

        }
    }
}