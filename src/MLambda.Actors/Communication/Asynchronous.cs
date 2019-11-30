// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Asynchronous.cs" company="MLambda">
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

namespace MLambda.Actors.Communication
{
    using MLambda.Actors.Abstraction;

    /// <summary>
    /// The Asynchronous message.
    /// </summary>
    public class Asynchronous : IMessage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Asynchronous"/> class.
        /// </summary>
        /// <param name="payload">The payload.</param>
        public Asynchronous(object payload)
        {
            this.Payload = payload;
        }

        /// <summary>
        /// Gets the message.
        /// </summary>
        public object Payload { get; }

        /// <summary>
        /// Responses to the observable.
        /// </summary>
        /// <param name="response">the response.</param>
        public void Response(object response)
        {
            ////Ignoring the response.
        }
    }
}