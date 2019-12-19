// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="MLambda">
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

namespace MLambda.Actors.HelloWorld
{
    using System;
    using System.Reactive.Linq;
    using System.Threading.Tasks;
    using Microsoft.Extensions.DependencyInjection;
    using MLambda.Actors.Abstraction.Context;
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
            await hello.Send("Other Message");
            Console.Read();
        }
    }
}