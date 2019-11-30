// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Bucket.cs" company="MLambda">
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
    using System.Collections.Generic;
    using System.Reactive.Linq;
    using MLambda.Actors.Abstraction;
    using MLambda.Actors.Guardian;

    /// <summary>
    /// The actor container class.
    /// </summary>
    public class Bucket : IBucket, IUserContext, IRootContext
    {
        private readonly IDependency dependency;

        private readonly IDictionary<string, IProcess> processes;

        /// <summary>
        /// Initializes a new instance of the <see cref="Bucket"/> class.
        /// </summary>
        /// <param name="dependency">the dependency.</param>
        public Bucket(IDependency dependency)
        {
            this.dependency = dependency;
            this.processes = new Dictionary<string, IProcess>();
            this.Root = this.Spawn<RootActor>(null);
            this.User = this.Spawn<UserActor>(this.processes["/"]);
        }

        /// <summary>
        /// Gets the root.
        /// </summary>
        public IAddress Root { get; }

        /// <summary>
        /// Gets the user.
        /// </summary>
        public IAddress User { get; }

        /// <summary>
        /// Spawns the new actor address.
        /// </summary>
        /// <param name="parent">the parent process.</param>
        /// <typeparam name="T">the type of the actor.</typeparam>
        /// <returns>The address actor.</returns>
        public IAddress Spawn<T>(IProcess parent)
            where T : IActor
        {
            var actor = this.dependency.Resolve<T>();
            var process = this.dependency.Resolve<IProcess>();
            process.Setup(parent, actor);
            this.processes.Add(process.Id, process);
            return process.Address;
        }

        IObservable<IAddress> IUserContext.Spawn<T>()
        {
            var process = this.processes["/user"];
            return Observable.Return(this.Spawn<T>(process));
        }

        IObservable<IAddress> IRootContext.Spawn<T>()
        {
            var process = this.processes["/"];
            return Observable.Return(this.Spawn<T>(process));
        }
    }
}