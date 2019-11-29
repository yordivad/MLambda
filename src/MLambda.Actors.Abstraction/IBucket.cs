// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IBucket.cs" company="MLambda">
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
    /// <summary>
    /// The actor container.
    /// </summary>
    public interface IBucket
    {
        /// <summary>
        /// Gets the root address.
        /// </summary>
        IAddress Root { get; }

        /// <summary>
        /// Gets the user address.
        /// </summary>
        IAddress User { get; }

        /// <summary>
        /// Creates the actor address.
        /// </summary>
        /// <param name="parent">the parent process.</param>
        /// <typeparam name="T">the type of the actor.</typeparam>
        /// <returns>The address of the actor.</returns>
        IAddress Spawn<T>(IProcess parent)
            where T : IActor;
    }
}