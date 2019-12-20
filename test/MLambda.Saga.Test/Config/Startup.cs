using System;
using System.Linq;
using Autofac;
using SpecFlow.Autofac;
using TechTalk.SpecFlow;

namespace MLambda.Actors.Test.Config
{
    public class Startup
    {
        [ScenarioDependencies]
        public static ContainerBuilder CreateContainer()
        {
         
            var builder = new ContainerBuilder();
            builder.RegisterTypes(typeof(Startup).Assembly.GetTypes()
                .Where(t => Attribute.IsDefined(t, typeof(BindingAttribute))).ToArray()).SingleInstance();
            return builder;
        }
    }
}