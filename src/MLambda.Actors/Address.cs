// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Address.cs" company="MLambda">
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
    using MLambda.Actors.Abstraction;
    using MLambda.Actors.Communication;

    /// <summary>
    /// The actor proxy implementation.
    /// </summary>
    public class Address : IAddress
    {
        private readonly IMailBox mailBox;

        private readonly ICollector collector;

        /// <summary>
        /// Initializes a new instance of the <see cref="Address"/> class.
        /// </summary>
        /// <param name="mailBox">the mail box.</param>
        /// <param name="collector">the actor collector.</param>
        public Address(IMailBox mailBox, ICollector collector)
        {
            this.mailBox = mailBox;
            this.collector = collector;
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="Address"/> class.
        /// </summary>
        ~Address() => this.Dispose(false);

        /// <summary>
        /// Tells to the actor the message.
        /// </summary>
        /// <param name="message">The emit message.</param>
        /// <typeparam name="TI">The in type.</typeparam>
        /// <typeparam name="TO">The out type.</typeparam>
        /// <returns>The response of the object.</returns>
        public IObservable<TO> Send<TI, TO>(TI message)
        {
            var future = new Synchronous(message);
            this.mailBox.Add(future);
            return future.ToObservable<TO>();
        }

        /// <summary>
        /// Tells the message to the actor.
        /// </summary>
        /// <param name="message">the message.</param>
        /// <typeparam name="T">The type of the message.</typeparam>
        /// <returns>The response of the the actor.</returns>
        public IObservable<Unit> Send<T>(T message)
        {
            var future = new Asynchronous(message);
            this.mailBox.Add(future);
            return Observable.Return(Unit.Default);
        }

        /// <summary>
        /// Disposed the actor.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Disposed the actor model.
        /// </summary>
        /// <param name="disposing">disposing the actor.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.collector.Collect(this.mailBox.Id);
            }
        }
    }
}