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
    /// <summary>
    /// The process interfaces.
    /// </summary>
    public interface IProcess
    {
        /// <summary>
        /// Gets the path.
        /// </summary>
        string Id { get; }

        /// <summary>
        /// Gets the address.
        /// </summary>
        IAddress Address { get; }

        /// <summary>
        /// Gets the parent.
        /// </summary>
        IActor Parent { get; }

        /// <summary>
        /// Gets the child actor.
        /// </summary>
        IActor Child { get; }

        /// <summary>
        /// Setups the actors.
        /// </summary>
        /// <param name="parentActor">the parent actor.</param>
        /// <param name="childActor">the child actor.</param>
        void Setup(IProcess parentActor, IActor childActor);
    }
}