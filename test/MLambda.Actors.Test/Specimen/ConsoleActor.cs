using MLambda.Actors.Abstraction.Annotation;

namespace MLambda.Actors.Test.Specimen
{
    using System;
    using System.Reactive;
    using System.Reactive.Linq;
    using MLambda.Actors.Abstraction;

    /// <summary>
    /// The console actor.
    /// </summary>
    [Route("console")]
    public class ConsoleActor : IActor
    {
        private IObservable<string> Sum(IContext context, string a, string b)
        {
            return Observable.Return(a + b);
        }

        private IObservable<Unit> Print(string message)
        {
            Console.WriteLine(message);
            return Actor.Done;
        }

        public Behavior Receive(object data) =>
            data switch
            {
                (string a, string b) => Actor.Behavior(Sum, a, b),
                string message when message == "Hola" => Actor.Behavior(Print, message),
                string message => Actor.Behavior(this.Print, message),
                _ => Actor.Ignore
            };
    }
}