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
    using System.Linq;
    using System.Reactive;
    using System.Reactive.Linq;
    using MLambda.Actors.Abstraction;
    using MLambda.Actors.Abstraction.Guardian;

    /// <summary>
    /// The actor container class.
    /// </summary>
    public class Bucket : IBucket, IUserContext, IRootContext
    {
        private readonly IDependency dependency;

        private readonly IDictionary<Guid, IProcess> processes;

        private readonly object locker;

        private IProcess root;

        private IProcess user;

        /// <summary>
        /// Initializes a new instance of the <see cref="Bucket"/> class.
        /// </summary>
        /// <param name="dependency">the dependency.</param>
        public Bucket(IDependency dependency)
        {
            this.locker = new object();
            this.dependency = dependency;
            this.processes = new Dictionary<Guid, IProcess>();
        }

        /// <summary>
        /// Gets the root.
        /// </summary>
        IAddress IRootContext.Self => this.Root;

        /// <summary>
        /// Gets the user.
        /// </summary>
        IAddress IUserContext.Self => this.User;

        /// <summary>
        /// Gets the root address.
        /// </summary>
        public IAddress Root => this.RootProcess.Address;

        /// <summary>
        /// Gets the user address.
        /// </summary>
        public IAddress User => this.UserProcess.Address;

        private IProcess RootProcess
        {
            get
            {
                lock (this.locker)
                {
                    if (this.root != null)
                    {
                        return this.root;
                    }

                    this.root = this.SetProcess<IRootActor>(null);
                    return this.root;
                }
            }
        }

        private IProcess UserProcess
        {
            get
            {
                lock (this.locker)
                {
                    if (this.user != null)
                    {
                        return this.user;
                    }

                    this.user = this.SetProcess<IUserActor>(this.RootProcess);
                    return this.user;
                }
            }
        }

        /// <summary>
        /// Spawns the new actor address.
        /// </summary>
        /// <param name="parent">the parent process.</param>
        /// <typeparam name="T">the type of the actor.</typeparam>
        /// <returns>The address actor.</returns>
        public IAddress Spawn<T>(IProcess parent)
            where T : IActor
        {
            var process = this.SetProcess<T>(parent);
            return process.Address;
        }

        /// <summary>
        /// Releases the process.
        /// </summary>
        /// <param name="id">the process id.</param>
        /// <returns>The unit.</returns>
        public IObservable<Unit> Release(Guid id)
        {
            var process = this.processes[id];
            process.Stop();
            this.processes.Remove(id);
            return Observable.Return(Unit.Default);
        }

        /// <summary>
        /// Filters the process.
        /// </summary>
        /// <param name="filter">the filter.</param>
        /// <returns>The list of process.</returns>
        public IEnumerable<IProcess> Filter(Func<IProcess, bool> filter) => this.processes.Values.Where(filter);

        public IObservable<int> Count() => Observable.Return(this.processes.Count());

        IObservable<IAddress> IUserContext.Spawn<T>() => Observable.Return(this.Spawn<T>(this.UserProcess));

        IObservable<IAddress> IRootContext.Spawn<T>() => Observable.Return(this.Spawn<T>(this.RootProcess));

        private IProcess SetProcess<T>(IProcess parent)
            where T : IActor
        {
            var actor = this.dependency.Resolve<T>();
            var process = this.dependency.Resolve<IProcess>();
            process.Setup(parent, actor);
            this.processes.Add(process.Id, process);
            return process;
        }
    }
}