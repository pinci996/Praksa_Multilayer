using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Deployment.Internal;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace Test.WebApi.Controllers
{
    public class EmployeesController : ApiController
    {
        static List<Zaposlenik> popis = new List<Zaposlenik>() { };
        SqlConnection connectionStr = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Praksa;Integrated Security=True");


        [HttpGet]
        public HttpResponseMessage Get()
        {
            DataReader reader = new DataReader();

            popis = reader.HasRows(connectionStr);
            bool isEmpty = !popis.Any();
            if (isEmpty)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No employees");
            }
            return Request.CreateResponse(HttpStatusCode.OK, popis);
        }


        [HttpPost]
        public IHttpActionResult Post([FromBody] Zaposlenik zaposlenik)
        {
            AddData.AddToDb(connectionStr, zaposlenik);
            return Ok();
        }



        [HttpPut]
        public IHttpActionResult Put(int id, string newName = "", int newAge = 0)
        {
            int check = DataUpdate.Update(connectionStr, id, newName, newAge);
            if (check != 0)
            {
                return Ok();
            }
            return NotFound();
        }

        [HttpDelete]
        public IHttpActionResult Delete([FromUri] int id)
        {
            DeleteData.Delete(connectionStr, id);
            return Ok();

        }

    }
}

