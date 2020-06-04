using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Test.WebApi
{
    public class DataUpdate
    {
        public static int Update(SqlConnection connectionStr, int id, string newName, int newAge)
        {

            int check = 0;
            string queryString;

            using (connectionStr)
            {

                if (newName != "")
                {
                    queryString = $"Update users set username='{newName}' where id={id};";
                    SqlDataAdapter adapter = new SqlDataAdapter(queryString, connectionStr);
                    DataSet newEmployee = new DataSet();
                    adapter.Fill(newEmployee, "users");
                     check = 1;
                    
                }


                if (newAge != -1)
                {
                    queryString = $"Update users set age='{newAge}' where id = {id};";    
                    SqlDataAdapter adapter = new SqlDataAdapter(queryString, connectionStr);
                    DataSet newEmployee = new DataSet();
                    adapter.Fill(newEmployee, "users");
                     check = 1;

                }

            }
            connectionStr.Close();
            if (check == 0)
            {
                return check;
            }return check;
        }
    }
}