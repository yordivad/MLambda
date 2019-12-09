// <copyright file="HelloWorld.cs" company="MLambda">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MLambda.Actors.HelloWorld
{
    using System;
    using System.Reactive;
    using System.Threading.Tasks;
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
                string message => Actor.Behavior(this.Show, message),
                _ => Actor.Ignore
            };
    }
}