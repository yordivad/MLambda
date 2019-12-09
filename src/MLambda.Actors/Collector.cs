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
        private readonly IRootContext root;

        /// <summary>
        /// Initializes a new instance of the <see cref="Collector"/> class.
        /// </summary>
        /// <param name="root">the root context.</param>
        public Collector(IRootContext root)
        {
            this.root = root;
        }

        /// <summary>
        /// Collects the actors.
        /// </summary>
        /// <param name="id">the id.</param>
        public void Collect(Guid id)
        {
            this.root.Self.Send(new Kill(id));
        }
    }
}