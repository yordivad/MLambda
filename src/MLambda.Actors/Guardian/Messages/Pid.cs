// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Pid.cs" company="MLambda">
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

namespace MLambda.Actors.Guardian.Messages
{
    using System;

    /// <summary>
    /// The process id.
    /// </summary>
    public class Pid
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Pid"/> class.
        /// </summary>
        /// <param name="id">the id.</param>
        /// <param name="route">the route.</param>
        /// <param name="status">the status.</param>
        public Pid(Guid id, string route, string status)
        {
            this.Id = id;
            this.Route = route;
            this.Status = status;
        }

        /// <summary>
        /// Gets the id.
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// Gets the status.
        /// </summary>
        public string Status { get;  }

        /// <summary>
        /// Gets the route.
        /// </summary>
        public string Route { get; }
    }
}