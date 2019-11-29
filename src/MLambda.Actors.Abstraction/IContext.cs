// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IContext.cs" company="MLambda">
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
    /// The actor context interface.
    /// </summary>
    public interface IContext
    {
        /// <summary>
        /// Creates the actor proxy.
        /// </summary>
        /// <typeparam name="T">The type of the actor</typeparam>
        /// <returns>The actor proxy.</returns>
        IObservable<IAddress> Spawn<T>()
            where T : IActor;
    }
}