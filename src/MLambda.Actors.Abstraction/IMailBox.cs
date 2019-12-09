// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IMailBox.cs" company="MLambda">
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
    /// The mailbox of the actors.
    /// </summary>
    public interface IMailBox
    {
        /// <summary>
        /// Gets the id.
        /// </summary>
        Guid Id { get; }

        /// <summary>
        /// Push the message in the mail box.
        /// </summary>
        /// <param name="message">The future message.</param>
        void Add(IMessage message);

        /// <summary>
        /// Pops the message.
        /// </summary>
        /// <returns>The future message.</returns>
        IMessage Take();
    }
}