// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IWorkUnit.cs" company="MLambda">
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

namespace MLambda.Actors.Abstraction
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using MLambda.Actors.Abstraction.Supervision;

    /// <summary>
    /// The work unit interface.
    /// </summary>
    public interface IWorkUnit
    {
        /// <summary>
        /// Gets the id.
        /// </summary>
        Guid Id { get; }

        /// <summary>
        /// Gets the route of the actor.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets the actor.
        /// </summary>
        IActor Actor { get; }

        /// <summary>
        /// Gets the link.
        /// </summary>
        IAddress Address { get; }

        /// <summary>
        /// Gets the children.
        /// </summary>
        IEnumerable<IWorkUnit> Children { get; }

        /// <summary>
        /// Gets the Mailbox.
        /// </summary>
        IMailBox MailBox { get; }

        /// <summary>
        /// Gets the supervisor.
        /// </summary>
        ISupervisor Supervisor { get; }

        /// <summary>
        /// Starts the actor model.
        /// </summary>
        /// <param name="receiver">The receiver.</param>
        void Start(Func<IMessage, Task> receiver);

        /// <summary>
        /// Stops the work unit.
        /// </summary>
        void Stop();
    }
}