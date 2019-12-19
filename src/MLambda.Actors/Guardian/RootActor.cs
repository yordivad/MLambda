// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RootActor.cs" company="MLambda">
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

namespace MLambda.Actors.Guardian
{
    using MLambda.Actors.Abstraction;
    using MLambda.Actors.Abstraction.Annotation;

    /// <summary>
    /// The system actor class.
    /// </summary>
    [Route("/")]
    public class RootActor : Actor
    {
        /// <summary>
        /// Receives the data message.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns>The Behavior.</returns>
        protected override Behavior Receive(object data)
            => data switch
            {
                _ => Actor.Ignore,
            };
    }
}