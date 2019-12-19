// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Scheduler.cs" company="MLambda">
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
    using System.Reactive;
    using System.Reactive.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using MLambda.Actors.Abstraction;
    using MLambda.Actors.Abstraction.Core;

    /// <summary>
    /// The dispatcher of the Actor.
    /// </summary>
    public class Scheduler : IScheduler
    {
        private readonly Thread consumer;

        private readonly CancellationTokenSource cancellation;

        private Func<IMessage, Task> observer;

        private readonly IMailBox mailBox;

        /// <summary>
        /// Initializes a new instance of the <see cref="Scheduler"/> class.
        /// </summary>
        /// <param name="mailBox">the mailbox.</param>
        public Scheduler(IMailBox mailBox)
        {
            this.mailBox = mailBox;
            this.cancellation = new CancellationTokenSource();
            this.consumer = new Thread(this.Consume) { IsBackground = true };
        }


        /// <summary>
        /// Gets a value indicating whether gets the running flag.
        /// </summary>
        public bool IsRunning => true;

        /// <summary>
        /// Starts the mailbox dispatcher.
        /// </summary>
        /// <returns>The response.</returns>
        public IObservable<Unit> Start()
        {
            this.consumer.Start();
            return Observable.Return(Unit.Default);
        }

        /// <summary>
        /// Stops the mailbox dispatcher.
        /// </summary>
        /// <returns>The response.</returns>
        public IObservable<Unit> Stop()
        {
            this.cancellation.Cancel();
            return Observable.Return(Unit.Default);
        }

        /// <summary>
        /// Subscribes the notification.
        /// </summary>
        /// <param name="notify">the observer.</param>
        public void Subscribe(Func<IMessage, Task> notify)
        {
            this.observer = notify;
        }

        private void Consume()
        {
            while (!this.cancellation.IsCancellationRequested)
            {
                var message = this.mailBox.Take();
                this.observer?.Invoke(message);
            }
        }
    }
}