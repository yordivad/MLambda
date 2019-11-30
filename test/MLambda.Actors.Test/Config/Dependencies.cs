using MLambda.Actors.Core;

namespace MLambda.Actors.Test.Config
{
    using System;
    using System.Linq;
    using Autofac;
    using Microsoft.Extensions.DependencyInjection;
    using MLambda.Actors.Abstraction;
    using MLambda.Actors.Test.Specimen;
    using SpecFlow.Autofac;
    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Configuration.JsonConfig;

    /// <summary>
    /// The dependencies class.
    /// </summary>
    public class Dependencies
    {
        /// <summary>
        /// Create the container builder.
        /// </summary>
        /// <returns>The container builder.</returns>
        [ScenarioDependencies]
        public static ContainerBuilder CreateContainerBuilder()
        {
            var services = new ServiceCollection();
            services.AddActor();
            services.AddActor<ConsoleActor>();
            var provider = services.BuildServiceProvider();

            var builder = new ContainerBuilder();
            builder.RegisterInstance(provider.GetService<IUserContext>());
            builder.RegisterInstance(provider.GetService<IBucket>());
            builder.RegisterTypes(typeof(Dependencies).Assembly.GetTypes()
                .Where(t => Attribute.IsDefined(t, typeof(BindingAttribute))).ToArray()).SingleInstance();

            return builder;
        }
    }
}