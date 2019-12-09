// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MailBox.cs" company="MLambda">
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

namespace MLambda.Actors.MailBox
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using MLambda.Actors.Abstraction;

    /// <summary>
    /// The mail box class.
    /// </summary>
    public class MailBox : IMailBox
    {
        private readonly Queue<IMessage> messages;

        private readonly object locker;

        /// <summary>
        /// Initializes a new instance of the <see cref="MailBox"/> class.
        /// </summary>
        public MailBox()
        {
            this.Id = Guid.NewGuid();
            this.locker = new object();
            this.messages = new Queue<IMessage>();
        }

        /// <summary>
        /// Gets the id.
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// Add the message to the mailbox.
        /// </summary>
        /// <param name="message">The message.</param>
        public void Add(IMessage message)
        {
            lock (this.locker)
            {
                this.messages.Enqueue(message);
                Monitor.Pulse(this.locker);
            }
        }

        /// <summary>
        /// Takes the message in the queue.
        /// </summary>
        /// <returns>The feature.</returns>
        public IMessage Take()
        {
            lock (this.locker)
            {
                while (!this.messages.Any())
                {
                    Monitor.Wait(this.locker);
                }

                return this.messages.Dequeue();
            }
        }
    }
}