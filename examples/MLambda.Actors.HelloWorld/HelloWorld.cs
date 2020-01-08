// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HelloWorld.cs" company="MLambda">
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
    using System.Reactive;
    using System.Threading.Tasks;
    using MLambda.Actors.Abstraction;
    using MLambda.Actors.Abstraction.Annotation;

    /// <summary>
    /// The hello world actor example.
    /// </summary>
    [Route("/HelloWorld")]
    public class HelloWorld : Actor
    {
        /// <inheritdoc/>
        protected override Behavior Receive(object data) =>
            data switch
            {
                string message => Actor.Behavior(this.Show, message),
                _ => Actor.Ignore
            };

        private IObservable<Unit> Show(string message)
        {
            Console.WriteLine(message);
            Task.Delay(500).Wait();
            return Actor.Done;
        }
    }
}