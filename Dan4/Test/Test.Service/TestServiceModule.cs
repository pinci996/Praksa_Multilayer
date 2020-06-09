using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Autofac.Core;
using Test.Service.Common;

namespace Test.Service
{
    public class TestServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder) => builder.RegisterType<TestService>().As<ITestService>().InstancePerDependency();
    }
}
