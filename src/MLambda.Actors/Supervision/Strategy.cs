// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Strategy.cs" company="MLambda">
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

namespace MLambda.Actors.Supervision
{
    using System;
    using MLambda.Actors.Abstraction.Supervision;

    /// <summary>
    /// The strategy builder.
    /// </summary>
    public static class Strategy
    {
        /// <summary>
        /// Create an one to one supervision.
        /// </summary>
        /// <param name="builder">the decider builder.</param>
        /// <returns>the supervisor.</returns>
        public static ISupervisor OneForOne(Func<Decider, Decider> builder)
        {
            return new OneForOne(builder(new Decider()));
        }
    }
}