// <copyright file="/home/roy/workspace/MLambda/test/MLambda.Actors.Test/Config/Dependencies.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using MLambda.Actors.Abstraction.Core;
using MLambda.Actors.Core;
using MLambda.Actors.Supervision.Test.Actors;
using MLambda.Actors.Test.Actors;

namespace MLambda.Actors.Test.Config
{
    using System;
    using System.Linq;
    using Autofac;
    using Microsoft.Extensions.DependencyInjection;
    using MLambda.Actors.Abstraction;
    using SpecFlow.Autofac;
    using TechTalk.SpecFlow;

    /// <summary>
    /// The dependencies class.
    /// </summary>
    public class Startup
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
            services.AddActor<SupervisionActor>();
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