// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IScheduler.cs" company="MLambda">
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

namespace MLambda.Actors.Abstraction.Core
{
    using System;
    using System.Reactive;
    using System.Threading.Tasks;

    /// <summary>
    /// The dispatcher interface.
    /// </summary>
    public interface IScheduler
    {
        /// <summary>
        /// Gets a value indicating whether gets the running flag.
        /// </summary>
        bool IsRunning { get;  }

        /// <summary>
        /// Subscribes the notification.
        /// </summary>
        /// <param name="notify">the method to notify.</param>
        void Subscribe(Func<IMessage, Task> notify);

        /// <summary>
        /// Starts the scheduler.
        /// </summary>
        /// <returns>the result of the start.</returns>
        IObservable<Unit> Start();

        /// <summary>
        /// Stops the scheduler.
        /// </summary>
        /// <returns>The result of the stop.</returns>
        IObservable<Unit> Stop();
    }
}