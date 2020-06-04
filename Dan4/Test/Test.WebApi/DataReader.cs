using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Test.WebApi
{
    public class DataReader
    {
        public List<Zaposlenik> popis = new List<Zaposlenik>();
        public List<Zaposlenik> HasRows(SqlConnection connectionStr)
        {
            string name = ""; 
            int age = 0;
            Zaposlenik zaposlenik;


            using (connectionStr)
            {
                SqlCommand command = new SqlCommand(
                  "SELECT username, age FROM users;",
                  connectionStr);
                connectionStr.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        name = reader.GetString(0);
                        age = reader.GetInt32(1);
                        zaposlenik = new Zaposlenik(name, age);
                        popis.Add(zaposlenik);

                    }
                }
                
                reader.Close();
                connectionStr.Close();
            }


            return popis;
        }
    }
}
