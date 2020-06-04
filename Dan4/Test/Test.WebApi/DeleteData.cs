using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Test.WebApi
{
    public class DeleteData
    {
        public static void Delete(SqlConnection connectionStr, [FromUri] int id)
        {

            using (connectionStr)
            {

                string queryString = $"Delete from users where id={id}";
                SqlDataAdapter adapter = new SqlDataAdapter(queryString, connectionStr);
                DataSet newZaposlenik = new DataSet();
                adapter.Fill(newZaposlenik, "users");
            }

            connectionStr.Close();
            

        }
    }
}
