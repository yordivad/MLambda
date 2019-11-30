// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IMessage.cs" company="MLambda">
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
    /// The message interface.
    /// </summary>
    public interface IMessage
    {
        /// <summary>
        /// Gets the payload of the message.
        /// </summary>
        object Payload { get; }

        /// <summary>
        /// The response of the message.
        /// </summary>
        /// <param name="response">the response.</param>
        void Response(object response);
    }
}