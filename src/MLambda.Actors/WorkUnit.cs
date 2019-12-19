// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WorkUnit.cs" company="MLambda">
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
    using System.Reflection;
    using System.Threading.Tasks;
    using MLambda.Actors.Abstraction;
    using MLambda.Actors.Abstraction.Annotation;
    using MLambda.Actors.Abstraction.Core;
    using MLambda.Actors.Abstraction.Supervision;

    /// <summary>
    /// The job class.
    /// </summary>
    public class WorkUnit : IWorkUnit
    {
        private readonly IDependency dependency;

        private readonly Type type;

        private readonly IBucket bucket;

        /// <summary>
        /// Initializes a new instance of the <see cref="WorkUnit"/> class.
        /// </summary>
        /// <param name="dependency">The dependency.</param>
        /// <param name="type">the actor type.</param>
        public WorkUnit(IDependency dependency, Type type)
        {
            this.Id = Guid.NewGuid();
            this.dependency = dependency;
            this.type = type;
            this.Name = type.GetCustomAttribute<RouteAttribute>()?.Name ?? type.Name;
            this.Actor = (IActor)this.dependency.Resolve(this.type);
            this.Supervisor = this.Actor.Supervisor ?? this.dependency.Resolve<ISupervisor>();
            this.MailBox = this.dependency.Resolve<IMailBox>();
            this.Link = new Link(this.MailBox);
            this.bucket = this.dependency.Resolve<IBucket>();
        }

        /// <summary>
        /// Gets the scheduler.
        /// </summary>
        public IScheduler Scheduler { get;  private set; }

        /// <summary>
        /// Gets the id.
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// Gets the Route Name.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the Actor.
        /// </summary>
        public IActor Actor { get; private set; }

        /// <summary>
        /// Gets the Link.
        /// </summary>
        public ILink Link { get; private set; }

        /// <summary>
        /// Gets the Children.
        /// </summary>
        public IEnumerable<IWorkUnit> Children => this.bucket.Filter(c => c.Parent == this).Select(c => c.Current);

        /// <summary>
        /// Gets the MailBox.
        /// </summary>
        public IMailBox MailBox { get; private set; }

        /// <summary>
        /// Gets the supervisor.
        /// </summary>
        public ISupervisor Supervisor { get; private set; }

        /// <summary>
        /// Starts the work unit.
        /// </summary>
        /// <param name="receiver">The receiver.</param>
        public void Start(Func<IMessage, Task> receiver)
        {
            this.Actor = (IActor)this.dependency.Resolve(this.type);
            this.Scheduler = new Scheduler(this.MailBox);
            this.Scheduler.Subscribe(receiver);
            this.Scheduler.Start();
        }

        /// <summary>
        /// Stops the work unit.
        /// </summary>
        public void Stop()
        {
            this.Scheduler.Stop();
            this.MailBox.Stop();
        }
    }
}