// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IActor.cs" company="MLambda">
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
    using MLambda.Actors.Abstraction.Supervision;

    /// <summary>
    /// The Behavior delegate.
    /// </summary>
    /// <param name="context">the context.</param>
    /// <returns>The response.</returns>
    public delegate IObservable<object> Behavior(IContext context);

    /// <summary>
    /// The actor interface.
    /// </summary>
    public interface IActor
    {
        /// <summary>
        /// Gets the supervisor strategy.
        /// </summary>
        ISupervisor Supervisor { get; }

        /// <summary>
        /// Receives the message.
        /// </summary>
        /// <param name="data">the data.</param>
        /// <returns>The match rules.</returns>
        Behavior Receive(object data);
    }
}