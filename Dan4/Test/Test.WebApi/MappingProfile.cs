using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Results;
using AutoMapper;
using Test.Model;
using Test.Model.Common;
using static Test.WebApi.Controllers.EmployeesController;

namespace Test.WebApi
{
    public class MappingProfile : Profile
    {
     public MappingProfile()
        {
            CreateMap<Osoba, Users>().ReverseMap(); 
            CreateMap<Osoba, IUsers>().ReverseMap();
            CreateMap<Adresa, Adresses>().ReverseMap();
            CreateMap<Adresa, IAdresses>().ReverseMap();
        }
    }
}