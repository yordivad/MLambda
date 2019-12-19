// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IProcess.cs" company="MLambda">
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

    /// <summary>
    /// The work interface.
    /// </summary>
    public interface IProcess
    {
        /// <summary>
        /// Gets the id.
        /// </summary>
        Guid Id { get; }

        /// <summary>
        /// Gets the status.
        /// </summary>
        string Status { get; }

        /// <summary>
        /// Gets the route.
        /// </summary>
        string Route { get; }

        /// <summary>
        /// Gets the parent reckon.
        /// </summary>
        IWorkUnit Parent { get; }

        /// <summary>
        /// Gets the child reckon.
        /// </summary>
        IWorkUnit Current { get; }

        /// <summary>
        /// Spawns the actor link.
        /// </summary>
        /// <typeparam name="T">the type T of the actor.</typeparam>
        /// <returns>The link.</returns>
        ILink Spawn<T>()
            where T : IActor;

        /// <summary>
        /// Stops the actor.
        /// </summary>
        void Stop();

        /// <summary>
        /// Starts the actor.
        /// </summary>
        void Start();

        void Restart();
        void Resume();
        void Escalate(Exception exception);
    }
}