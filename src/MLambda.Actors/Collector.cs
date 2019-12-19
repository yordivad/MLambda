// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Collector.cs" company="MLambda">
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

using MLambda.Actors.Abstraction.Core;

namespace MLambda.Actors
{
    using System;
    using MLambda.Actors.Abstraction;
    using MLambda.Actors.Guardian.Messages;

    /// <summary>
    /// The collector class.
    /// </summary>
    public class Collector : ICollector
    {
        private readonly ISystemContext system;

        /// <summary>
        /// Initializes a new instance of the <see cref="Collector"/> class.
        /// </summary>
        /// <param name="system">the root context.</param>
        public Collector(ISystemContext system)
        {
            this.system = system;
        }

        /// <summary>
        /// Collects the actors.
        /// </summary>
        /// <param name="id">the id.</param>
        public void Collect(Guid id)
        {
            this.system.Self.Send(new Kill(id));
        }
    }
}