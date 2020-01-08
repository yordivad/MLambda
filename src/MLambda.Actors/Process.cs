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
    using System.Threading.Tasks;
    using MLambda.Actors.Abstraction;
    using MLambda.Actors.Abstraction.Core;

    /// <summary>
    /// The process class.
    /// </summary>
    public class Process : IProcess
    {
        private readonly IBucket bucket;

        private LifeCycle state;

        /// <summary>
        /// Initializes a new instance of the <see cref="Process"/> class.
        /// </summary>
        /// <param name="bucket">the bucket.</param>
        /// <param name="parent">the parent job.</param>
        /// <param name="current">the current job.</param>
        public Process(IBucket bucket, IProcess parent, IWorkUnit current)
        {
            this.bucket = bucket;
            this.Parent = parent?.Current;
            this.Route = $"{parent?.Route}{current.Name}";
            this.Current = current;
            this.state = LifeCycle.Created;
        }

        /// <summary>
        /// The lifecycle event.
        /// </summary>
        public delegate void LifeCycleHandler();

        /// <summary>
        /// Adds or removes events to on post stop.
        /// </summary>
        public event LifeCycleHandler PostStop
        {
            add => this.OnPostStop += value;
            remove => this.OnPostStop -= value;
        }

        private event LifeCycleHandler OnPostStop;

        /// <summary>
        /// The lifecycle of the process.
        /// </summary>
        public enum LifeCycle
        {
            /// <summary>
            /// The process is initializes.
            /// </summary>
            Starting,

            /// <summary>
            /// The process can receiving the message.
            /// </summary>
            Receiving,

            /// <summary>
            /// The process cleans up the actual state.
            /// </summary>
            Stopping,

            /// <summary>
            /// The process is going to restart and assign new schedulers.
            /// </summary>
            Restarting,

            /// <summary>
            /// The process is dead.
            /// </summary>
            Terminated,

            /// <summary>
            /// The new one state.
            /// </summary>
            Created,
        }

        /// <summary>
        /// Gets the id.
        /// </summary>
        public Guid Id => this.Current.Id;

        /// <summary>
        /// Gets the status.
        /// </summary>
        public string Status => Enum.GetName(typeof(LifeCycle), this.state);

        /// <summary>
        /// Gets the parent job.
        /// </summary>
        public IWorkUnit Parent { get; }

        /// <summary>
        /// Gets the actual job.
        /// </summary>
        public IWorkUnit Current { get; }

        /// <summary>
        /// Gets the path.
        /// </summary>
        public string Route { get; }

        /// <summary>
        /// Stops the scheduler.
        /// </summary>
        public void Stop()
        {
            this.state = LifeCycle.Stopping;
            this.Current.Stop();
            this.OnPostStop?.Invoke();
            this.state = LifeCycle.Terminated;
        }

        /// <summary>
        /// Starts the actor model.
        /// </summary>
        public void Start()
        {
            this.state = LifeCycle.Starting;
            this.Current.Start(this.Receive);
            this.state = LifeCycle.Receiving;
        }

        /// <summary>
        /// Resumes the actor model.
        /// </summary>
        public void Resume()
        {
            ////TODO
        }

        /// <summary>
        /// Escalate the exception to the parent.
        /// </summary>
        /// <param name="exception">The exception.</param>
        public void Escalate(Exception exception) =>
            this.Parent.Supervisor.Handle(exception, this.bucket.Parent(this));


        /// <summary>
        /// Restart the actor model.
        /// </summary>
        public void Restart()
        {
            this.state = LifeCycle.Stopping;
            //// this.PreRestart();
            this.state = LifeCycle.Restarting;
            //// this.PostRestart();
            this.Start();
        }

        /// <summary>
        /// Spawns the actor link.
        /// </summary>
        /// <typeparam name="T">the type of the actor.</typeparam>
        /// <returns>The link of the actor.</returns>
        public IAddress Spawn<T>()
            where T : IActor =>
            this.bucket.Spawn<T>(this);

        private async Task Receive(IMessage message) =>
            await this.Current.Supervisor.Apply(message)(new Context(this));
    }
}