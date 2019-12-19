// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Directive.cs" company="MLambda">
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

namespace MLambda.Actors.Abstraction.Supervision
{
    /// <summary>
    /// The supervision directive.
    /// </summary>
    public enum Directive
    {
        /// <summary>
        /// Restart the actual actor.
        /// </summary>
        Restart,

        /// <summary>
        /// Resume the actual actor.
        /// </summary>
        Resume,

        /// <summary>
        /// Kill the actual actor.
        /// </summary>
        Stop,

        /// <summary>
        /// Delegate the responsibility to the parent.
        /// </summary>
        Escalate,
    }
}