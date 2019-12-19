using MLambda.Actors.Abstraction.Core;

namespace MLambda.Actors.Supervision.Test.Config
{
    using System;
    using System.Linq;
    using Autofac;
    using Microsoft.Extensions.DependencyInjection;
    using MLambda.Actors.Abstraction;
    using MLambda.Actors.Core;
    using MLambda.Actors.Supervision.Test.Actors;
    using SpecFlow.Autofac;
    using TechTalk.SpecFlow;

    public class Startup
    {
        [ScenarioDependencies]
        public static ContainerBuilder CreateBuilder()
        {
            var services = new ServiceCollection();
            services.AddActor();
            services.AddActor<ConsoleActor>();
            var provider = services.BuildServiceProvider();

            var builder = new ContainerBuilder();
            builder.RegisterInstance(provider.GetService<IUserContext>());
            builder.RegisterInstance(provider.GetService<IBucket>());
            builder.RegisterTypes(typeof(Startup).Assembly.GetTypes()
                .Where(t => Attribute.IsDefined(t, typeof(BindingAttribute))).ToArray()).SingleInstance();

            builder.RegisterInstance(provider.GetService<ISystemContext>());
            return builder;
        }
    }
}