using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Deployment.Internal;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Test.Model;
using Test.Model.Common;
using Test.Service;
using Test.Service.Common;

namespace Test.WebApi.Controllers
{
    public class EmployeesController : ApiController
    {
        public List<Users> osobe = new List<Users>();
        public List<Adresses> adrese = new List<Adresses>();
        TestService service = new TestService();


        [HttpGet]
        [Route("api/users")]
        public HttpResponseMessage ReadFromUsers()
        {
            osobe = service.ReadUsers();
            return Request.CreateResponse(HttpStatusCode.OK);
        }


        [HttpGet]
        [Route("api/adresses")]
        public HttpResponseMessage ReadFromAdresses()
        {
            adrese = service.ReadAdresses();
            return Request.CreateResponse(HttpStatusCode.OK);
        }


        [HttpPost]
        [Route("api/adduser")]
        public HttpResponseMessage CreateNewUser ([FromBody] Users user)
        {
            service.AddData(user);
            return Request.CreateResponse(HttpStatusCode.OK);
        }


        [HttpPut]
        [Route("api/updateuser")]
        public HttpResponseMessage UserUpdate([FromBody] Users user)
        {
            service.UpdateData(user);
            return Request.CreateResponse(HttpStatusCode.OK);
        }


        [HttpDelete]
        [Route("api/deleteuser/{Id}")]
        public HttpResponseMessage UserDelete (int Id)
        {
            service.RemoveData(Id);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    } 
}
