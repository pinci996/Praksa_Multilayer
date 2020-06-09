using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using Autofac;
using AutoMapper;
using Test.Service;
using Test.Service.Common;
using Autofac.Extensions.DependencyInjection;
using Autofac.Integration.WebApi;
using Test.Repository;
using Test.Repository.Common;

namespace Test.WebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            var builder = new ContainerBuilder();

            builder.RegisterType<TestService>().As<ITestService>();
            builder.RegisterType<TestRepository>().As<ITestRepository>();
            builder.RegisterType<ApiController>();

            var container = builder.Build();
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            //using (var scope = container.BeginLifetimeScope())
            //{
            //    var service = scope.Resolve<ITestService>();
            //}
            
        }
    }
}
