using System.Threading.Tasks;

namespace MLambda.Actors.HelloWorld
{
    using System;
    using System.Reactive;
    using MLambda.Actors.Abstraction;

    public class HelloWorld : IActor
    {
        public IObservable<Unit> Show(string message)
        {
            Console.WriteLine(message);
            Task.Delay(5000).Wait();
            return Actor.Done;
        }

        public Behavior Receive(object data) =>
            data switch
            {
                string message => Actor.Behavior(Show, message),
                _ => Actor.Ignore
            };
    }
}