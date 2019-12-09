// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Process.cs" company="MLambda">
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
    using System.Reflection;
    using System.Threading.Tasks;
    using MLambda.Actors.Abstraction;
    using MLambda.Actors.Abstraction.Annotation;

    /// <summary>
    /// The process class.
    /// </summary>
    public class Process : IProcess
    {
        private readonly IScheduler scheduler;

        private readonly IDependency dependency;

        private readonly ICollector collector;

        private string path;

        private Address address;

        private string parentId;

        /// <summary>
        /// Initializes a new instance of the <see cref="Process"/> class.
        /// </summary>
        /// <param name="dependency">The dependency.</param>
        public Process(IDependency dependency)
        {
            this.dependency = dependency;
            this.scheduler = this.dependency.Resolve<IScheduler>();
            this.collector = this.dependency.Resolve<ICollector>();
            this.Id = this.scheduler.Id;
            this.scheduler.Subscribe(this.Handler);
            this.scheduler.Start();
        }

        /// <summary>
        /// Gets the parent actor.
        /// </summary>
        public IActor Parent { get; private set; }

        /// <summary>
        /// Gets the child actor.
        /// </summary>
        public IActor Child { get; private set; }

        /// <summary>
        /// Gets the status.
        /// </summary>
        public string Status => this.scheduler.IsRunning ? "run" : "stop";

        /// <summary>
        /// Gets the id.
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// Gets the path.
        /// </summary>
        public string Route => this.path ??= this.parentId.EndsWith("/")
            ? $"{this.parentId}{this.ChildId}"
            : $"{this.parentId}/{this.ChildId}";

        /// <summary>
        /// Gets the address.
        /// </summary>
        public IAddress Address => this.address ??= new Address(this.scheduler.MailBox, this.collector);

        private string ChildId => this.Child.GetType().GetCustomAttribute<RouteAttribute>()?.Name ??
                                  this.Child.GetType().Name;

        /// <summary>
        /// Setups the actors.
        /// </summary>
        /// <param name="process">the parent actor.</param>
        /// <param name="childActor">the child actor.</param>
        public void Setup(IProcess process, IActor childActor)
        {
            this.parentId = process?.Route ?? string.Empty;
            this.Parent = process?.Child;
            this.Child = childActor;
        }

        /// <summary>
        /// Stops the scheduler.
        /// </summary>
        public void Stop()
        {
            this.scheduler.Stop();
        }

        private async Task Handler(IMessage message)
        {
            try
            {
                var context = this.dependency.Resolve<IMainContext>();
                context.SetProcess(this);
                message.Response(await this.Child.Receive(message.Payload)(context));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}