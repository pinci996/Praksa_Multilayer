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
using AutoMapper;
using System.Threading.Tasks;
using Test.Common;
using Autofac;

namespace Test.WebApi.Controllers
{
    public class EmployeesController : ApiController
    {
        public List<Users> osobe = new List<Users>();
        public List<Adresses> adrese = new List<Adresses>();
        //TestService service = new TestService();

        protected ITestService Service { get; private set; }
        protected IMapper Mapper { get; private set; }

        public EmployeesController (ITestService Service, IMapper Mapper)
        {
            this.Service = Service;
            this.Mapper = Mapper;
        }


        [HttpGet]
        [Route("api/users")]
        public async Task<HttpResponseMessage> ReadFromUsers(int current, int records, string filterBy, string filterCondition, string sortBy, string sortProperty)
        {
            Page page = new Page(current,records);
            Filter filter = new Filter(filterBy,filterCondition);
            Sort sort = new Sort(sortBy, sortProperty);


            var osobe = await Service.FilteringMethod(filter,page,sort);
            var mapOsobe = Mapper.Map<List<Osoba>>(osobe);



            if (osobe != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, mapOsobe);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "Not Found");
        }

    


        [HttpGet]
        [Route("api/adresses")]
        public async Task<HttpResponseMessage> ReadFromAdresses()
        {
            var adrese = await Service.ReadAdressesAsync();
            var mapAdrese = Mapper.Map<List<Adresa>>(adrese);



            if (adrese != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, mapAdrese);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "Not Found");
        }


        [HttpPost]
        [Route("api/adduser")]
        public async Task <HttpResponseMessage> AddNewUser ([FromBody] Users user)
        {
            await Service.AddDataAsync(user);
            return Request.CreateResponse(HttpStatusCode.OK);
        }


        [HttpPut]
        [Route("api/updateuser")]
        public async Task<HttpResponseMessage> UserUpdate([FromBody] Users user)
        {
            await Service.UpdateDataAsync(user);
            return Request.CreateResponse(HttpStatusCode.OK);
        }


        [HttpDelete]
        [Route("api/deleteuser/{Id}")]
        public async Task <HttpResponseMessage> UserDelete (int Id)
        {
            await Service.RemoveDataAsync(Id);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        public class Adresa
        {

            public string Street { get; set; }
            public string City { get; set; }
        }

        public class Osoba
        {

            public string Name { get; set; }
            public int Age { get; set; }
        }
    }
} 

