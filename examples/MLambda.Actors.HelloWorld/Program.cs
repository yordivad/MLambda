// <copyright file="Program.cs" company="MLambda">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MLambda.Actors.HelloWorld
{
    using System;
    using System.Reactive.Linq;
    using System.Threading.Tasks;
    using Microsoft.Extensions.DependencyInjection;
    using MLambda.Actors.Abstraction;
    using MLambda.Actors.Core;

    /// <summary>
    /// The program class.
    /// </summary>
    public static class Program
    {
       /// <summary>
       /// The main.
       /// </summary>
       /// <param name="args">the arguments.</param>
       /// <returns>The async response.</returns>
       public static async Task Main(string[] args)
        {
            var services = new ServiceCollection();
            services.AddActor();
            services.AddActor<HelloWorld>();
            var provider = services.BuildServiceProvider();
            var user = provider.GetService<IUserContext>();
            var hello = await user.Spawn<HelloWorld>();
            await hello.Send("Hello World");
            Console.Read();
        }
    }
}