// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConsoleActor.cs" company="MLambda">
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

namespace MLambda.Actors.Test.Actors
{
    using System;
    using System.Reactive;
    using System.Reactive.Linq;
    using MLambda.Actors.Abstraction;
    using MLambda.Actors.Abstraction.Annotation;
    using MLambda.Actors.Abstraction.Context;

    /// <summary>
    /// The console actor.
    /// </summary>
    [Route("console")]
    public class ConsoleActor : Actor
    {
        /// <inheritdoc/>
        protected override Behavior Receive(object data) =>
            data switch
            {
                (string a, string b) => Actor.Behavior(this.Sum, a, b),
                string message when message == "Hola" => Actor.Behavior(this.Print, message),
                string message => Actor.Behavior(this.Print, message),
                _ => Actor.Ignore
            };

        private IObservable<string> Sum(IContext context, string a, string b)
        {
            return Observable.Return(a + b);
        }

        private IObservable<Unit> Print(string message)
        {
            Console.WriteLine(message);
            return Actor.Done;
        }
    }
}