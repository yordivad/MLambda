// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ISupervisor.cs" company="MLambda">
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
    using System;
    using System.Threading.Tasks;
    using MLambda.Actors.Abstraction.Context;

    /// <summary>
    /// The supervisor interface.
    /// </summary>
    public interface ISupervisor
    {
        /// <summary>
        /// Applies the message.
        /// </summary>
        /// <param name="message">the message.</param>
        /// <returns>The context function.</returns>
        Func<IMainContext, Task> Apply(IMessage message);

        /// <summary>
        /// Handles the exception.
        /// </summary>
        /// <param name="exception">the exception.</param>
        /// <param name="process">the process.</param>
        void Handle(Exception exception, IProcess process);
    }
}