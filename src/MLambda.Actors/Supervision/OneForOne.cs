// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OneForOne.cs" company="MLambda">
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

namespace MLambda.Actors.Supervision
{
    using System;
    using System.Reactive.Linq;
    using System.Threading.Tasks;
    using MLambda.Actors.Abstraction;
    using MLambda.Actors.Abstraction.Context;
    using MLambda.Actors.Abstraction.Supervision;

    /// <summary>
    /// One for one strategy.
    /// </summary>
    public class OneForOne : ISupervisor
    {
        private readonly IDecider decider;

        /// <summary>
        /// Initializes a new instance of the <see cref="OneForOne"/> class.
        /// </summary>
        /// <param name="decider">the decider.</param>
        public OneForOne(IDecider decider)
        {
            this.decider = decider;
        }

        /// <summary>
        /// Applies the message.
        /// </summary>
        /// <param name="message">the message.</param>
        /// <returns>the function a context.</returns>
        public Func<IMainContext, Task> Apply(IMessage message) =>

            async context =>
            {
                try
                {
                    message.Response(await context.Actor.Receive(message.Payload)(context));
                }
                catch (Exception exception)
                {
                    this.Handle(exception, context.Process);
                }
            };

        /// <summary>
        /// Handles the exception.
        /// </summary>
        /// <param name="exception">the exception.</param>
        /// <param name="process">the process.</param>
        /// <exception cref="ArgumentOutOfRangeException">Invalid enumeration type.</exception>
        public void Handle(Exception exception, IProcess process)
        {
            switch (this.decider.Decision(exception))
            {
                case Directive.Restart:
                    process.Restart();
                    break;
                case Directive.Resume:
                    process.Resume();
                    break;
                case Directive.Stop:
                    process.Stop();
                    break;
                case Directive.Escalate:
                    process.Escalate(exception);
                    break;
                default:
                    throw new InvalidOperationException(nameof(Directive));
            }
        }
    }
}