// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Register.cs" company="MLambda">
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

namespace MLambda.Actors.Core
{
    using Microsoft.Extensions.DependencyInjection;
    using MLambda.Actors.Abstraction;
    using MLambda.Actors.Abstraction.Context;
    using MLambda.Actors.Abstraction.Core;
    using MLambda.Actors.Abstraction.Supervision;
    using MLambda.Actors.Guardian;
    using MLambda.Actors.Supervision;

    /// <summary>
    /// The register class for Dotnet core.
    /// </summary>
    public static class Register
    {
        /// <summary>
        /// Add the actor services.
        /// </summary>
        /// <param name="services">the service collection.</param>
        /// <returns>The service collection.</returns>
        public static IServiceCollection AddActor(this IServiceCollection services)
        {
            services.AddScoped<IDependency>(provider => new Dependency(provider));
            services.AddScoped<IBucket, Bucket>();
            services.AddScoped<ICollector, Collector>();
            services.AddScoped(provider => provider.GetService<IBucket>() as IUserContext);
            services.AddScoped(provider => provider.GetService<IBucket>() as ISystemContext);
            services.AddSingleton(Strategy.OneForOne(decider => decider.Default(Directive.Resume)));
            services.AddTransient<RootActor>();
            services.AddTransient<SystemActor>();
            services.AddTransient<UserActor>();
            services.AddTransient<IMainContext, Context>();
            services.AddTransient<IProcess, Process>();
            services.AddTransient<IMailBox, MailBox>();
            services.AddTransient<IScheduler, Scheduler>();
            return services;
        }

        /// <summary>
        /// Add the actor.
        /// </summary>
        /// <param name="services">the service collection.</param>
        /// <typeparam name="T">the type of the actor.</typeparam>
        /// <returns>The actor.</returns>
        public static IServiceCollection AddActor<T>(this IServiceCollection services)
            where T : class, IActor
        {
            services.AddTransient<T>();
            return services;
        }
    }
}