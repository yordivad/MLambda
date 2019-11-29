// --------------------------------------------------------------------------------------------------------------------
// <copyright file="/home/roy/workspace/research/MActor/src/MLambda.Actors/Actors/UserActor.cs" company="MLambda">
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
    using Actors.Abstraction;
    using MLambda.Actors.Annotation;

    [Address("user")]
    public class UserActor : IActor
    {
        public Match Receive => data =>
            data switch
            {
                _ => Actor.Ignore
            };
    }
}