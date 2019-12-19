// <copyright file="HelloWorld.cs" company="MLambda">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using MLambda.Actors.Abstraction.Supervision;

namespace MLambda.Actors.HelloWorld
{
    using System;
    using System.Reactive;
    using System.Threading.Tasks;
    using MLambda.Actors.Abstraction;

    public class HelloWorld : Actor
    {
        private IObservable<Unit> Show(string message)
        {
            Console.WriteLine(message);
            Task.Delay(500).Wait();
            return Actor.Done;
        }


        protected override Behavior Receive(object data) =>
            data switch
            {
                string message => Actor.Behavior(this.Show, message),
                _ => Actor.Ignore
            };
    }
}