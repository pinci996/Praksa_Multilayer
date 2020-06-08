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
using Test.WebApi.Models;
using AutoMapper;
using System.Threading.Tasks;

namespace Test.WebApi.Controllers
{
    public class EmployeesController : ApiController
    {
        public List<Users> osobe = new List<Users>();
        public List<Adresses> adrese = new List<Adresses>();
        public List<Osoba> osobaREST = new List<Osoba>();
        public List<Adresa> adresaREST = new List<Adresa>();
        TestService service = new TestService();


        [HttpGet]
        [Route("api/users")]
        public async Task<HttpResponseMessage> ReadFromUsers()
        {
            osobe = await service.ReadUsersAsync();
            

            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Users, Osoba>();
            });
            IMapper iMapper = config.CreateMapper();

            foreach (Users users in osobe)
            {
                Osoba osoba = iMapper.Map<Users, Osoba>(users);
                osobaREST.Add(osoba);
            }

            return Request.CreateResponse(HttpStatusCode.OK, osobaREST);

        }


        [HttpGet]
        [Route("api/adresses")]
        public async Task<HttpResponseMessage> ReadFromAdresses()
        {
            adrese = await service.ReadAdressesAsync();
            

            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Adresses, Adresa>();
            });
            IMapper iMapper = config.CreateMapper();

            foreach (Adresses adress in adrese)
            {
                Adresa adresa = iMapper.Map<Adresses, Adresa>(adress);
                adresaREST.Add(adresa);
            }

            return Request.CreateResponse(HttpStatusCode.OK, adresaREST);
        }


        [HttpPost]
        [Route("api/adduser")]
        public async Task <HttpResponseMessage> AddNewUser ([FromBody] Users user)
        {
            await service.AddDataAsync(user);
            return Request.CreateResponse(HttpStatusCode.OK);
        }


        [HttpPut]
        [Route("api/updateuser")]
        public async Task<HttpResponseMessage> UserUpdate([FromBody] Users user)
        {
            await service.UpdateDataAsync(user);
            return Request.CreateResponse(HttpStatusCode.OK);
        }


        [HttpDelete]
        [Route("api/deleteuser/{Id}")]
        public async Task <HttpResponseMessage> UserDelete (int Id)
        {
            await service.RemoveDataAsync(Id);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    } 
}
