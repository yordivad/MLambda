// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Context.cs" company="MLambda">
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

namespace MLambda.Actors
{
    using System;
    using System.Reactive.Linq;
    using Actors.Abstraction;

    /// <summary>
    /// The actor context task.
    /// </summary>
    public class Context : IMainContex
    {
        private readonly IBucket container;

        private IProcess process;

        /// <summary>
        /// Initializes a new instance of the <see cref="Context"/> class.
        /// </summary>
        /// <param name="container">the container.</param>
        public Context(IBucket container)
        {
            this.container = container;
        }

        /// <summary>
        /// Spawns a new actor.
        /// </summary>
        /// <typeparam name="T">the type of the actor.</typeparam>
        /// <returns>The address.</returns>
        public IObservable<IAddress> Spawn<T>()
            where T : IActor
        {
            return Observable.Return(this.container.Spawn<T>(this.process));
        }

        /// <summary>
        /// Setups the process.
        /// </summary>
        /// <param name="pid">the process.</param>
        public void SetProcess(IProcess pid)
        {
            this.process = pid;
        }
    }
}