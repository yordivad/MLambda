// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Startup.cs" company="MLambda">
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see https://www.gnu.org/licenses/.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace MLambda.Actors.Test.Config
{
    using System;
    using System.Linq;
    using Autofac;
    using Microsoft.Extensions.DependencyInjection;
    using MLambda.Actors.Abstraction.Context;
    using MLambda.Actors.Abstraction.Core;
    using MLambda.Actors.Core;
    using MLambda.Actors.Test.Actors;
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
        public static ContainerBuilder CreateContainer()
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