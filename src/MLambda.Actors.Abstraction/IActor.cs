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

    /// <summary>
    /// The Rule delegate.
    /// </summary>
    /// <param name="context">the context.</param>
    /// <returns>The response.</returns>
    public delegate IObservable<object> Behaivor(IContext context);

    /// <summary>
    /// The match delegate.
    /// </summary>
    /// <param name="message">the message to match.</param>
    /// <returns>The rule to apply the match.</returns>
    public delegate Behaivor Match(object message);

    /// <summary>
    /// The actor interface.
    /// </summary>
    public interface IActor
    {
        /// <summary>
        /// Gets the receives match.
        /// </summary>
        Match Receive { get; }
    }
}