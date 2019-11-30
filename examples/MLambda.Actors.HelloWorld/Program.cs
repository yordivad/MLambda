using System;
using System.Reactive.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using MLambda.Actors.Abstraction;
using MLambda.Actors.Core;

namespace MLambda.Actors.HelloWorld
{
    public class Program
    {
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