namespace MLambda.Actors.Test.Specimen
{
    using System;
    using System.Reactive;
    using System.Reactive.Linq;
    using MLambda.Actors.Abstraction;

    /// <summary>
    /// The console actor.
    /// </summary>
    public class ConsoleActor : IActor
    {
        /// <summary>
        /// Gets the receive match.
        /// </summary>
        public Match Receive => data =>
            data switch
            {
                (string a, string b) => Actor.Behavior(Sum, a, b),
                string message when message == "Hola" => Actor.Behavior(Print, message),
                string message => Actor.Behavior(this.Print, message),
                _ => Actor.Ignore
            };

        private IObservable<string> Sum(IContext context, string a, string b)
        {
            return Observable.Return(a + b);
        }

        private IObservable<Unit> Print(IContext context, string message)
        {
            Console.WriteLine(message);
            return Observable.Return(Unit.Default);
        }
    }
}