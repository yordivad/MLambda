// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Kill.cs" company="MLambda">
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
    /// The kill message class.
    /// </summary>
    public class Kill
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Kill"/> class.
        /// </summary>
        /// <param name="id">the id.</param>
        public Kill(Guid id)
        {
            this.Id = id;
        }

        /// <summary>
        /// Gets the id.
        /// </summary>
        public Guid Id { get; }
    }
}