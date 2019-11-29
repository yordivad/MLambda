// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StackMailBox.cs" company="MLambda">
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
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using Actors.Abstraction;

    /// <summary>
    /// The mail box class.
    /// </summary>
    public class StackMailBox : IMailBox
    {
        private readonly Mutex mutex;

        private readonly Stack<Promise> stack;

        /// <summary>
        /// Initializes a new instance of the <see cref="StackMailBox"/> class.
        /// </summary>
        public StackMailBox()
        {
            this.stack = new Stack<Promise>();
            this.mutex = new Mutex();
        }

        /// <summary>
        /// Add the message to the mailbox.
        /// </summary>
        /// <param name="message">The message.</param>
        public void Add(Promise message)
        {
            lock (this.stack)
            {
                this.stack.Push(message);
                this.mutex.ReleaseMutex();
            }
        }

        /// <summary>
        /// Takes the message in the queue.
        /// </summary>
        /// <returns>The feature.</returns>
        public Promise Take()
        {
            lock (this.stack)
            {
                while (!this.stack.Any())
                {
                    this.mutex.WaitOne();
                }

                return this.stack.Pop();
            }
        }
    }
}