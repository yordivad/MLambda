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
    using MLambda.Actors.Abstraction.Context;
    using MLambda.Actors.Abstraction.Core;
    using MLambda.Actors.Guardian;

    /// <summary>
    /// The actor container class.
    /// </summary>
    public class Bucket : IBucket, IUserContext, ISystemContext
    {
        private readonly IDependency dependency;

        private readonly IDictionary<Guid, IProcess> processes;

        private Guardians guardians;

        /// <summary>
        /// Initializes a new instance of the <see cref="Bucket"/> class.
        /// </summary>
        /// <param name="dependency">the dependency.</param>
        public Bucket(IDependency dependency)
        {
            this.dependency = dependency;
            this.processes = new Dictionary<Guid, IProcess>();
        }

        /// <summary>
        /// Gets the root.
        /// </summary>
        IAddress ISystemContext.Self => this.System;

        /// <summary>
        /// Gets the user.
        /// </summary>
        IAddress IUserContext.Self => this.User;

        /// <summary>
        /// Gets the root link.
        /// </summary>
        public IAddress Root => this.Guards.Root.Current.Address;

        /// <summary>
        /// Gets the user link.
        /// </summary>
        public IAddress User => this.Guards.User.Current.Address;

        /// <summary>
        /// Gets the system link.
        /// </summary>
        public IAddress System => this.Guards.System.Current.Address;

        private Guardians Guards
        {
            get
            {
                if (this.guardians != null)
                {
                    return this.guardians;
                }

                this.guardians = new Guardians();
                this.guardians.Load(this, this.dependency);
                return this.guardians;
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
            var process = this.CreateProcess<T>(parent);
            return process.Current.Address;
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

        /// <summary>
        /// Counts the number of the process.
        /// </summary>
        /// <returns>the count of process.</returns>
        public IObservable<int> Count() => Observable.Return(this.processes.Count());

        /// <summary>
        /// Gets the parent of the current process.
        /// </summary>
        /// <param name="process">the current process.</param>
        /// <returns>the parent.</returns>
        public IProcess Parent(IProcess process) =>
            this.processes.Select(c => c.Value).FirstOrDefault(c => c.Id == process.Id);

        /// <inheritdoc/>
        IObservable<IAddress> IUserContext.Spawn<T>() => Observable.Return(this.Spawn<T>(this.Guards.User));

        /// <inheritdoc/>
        IObservable<IAddress> ISystemContext.Spawn<T>() => Observable.Return(this.Spawn<T>(this.Guards.System));

        private IProcess CreateProcess<T>(IProcess parent)
            where T : IActor
        {
            var job = new WorkUnit(this.dependency, typeof(T));
            var process = new Process(this, parent.Current, job);
            this.processes.Add(process.Id, process);
            process.Start();
            return process;
        }
    }
}