// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SupervisionActor.cs" company="MLambda">
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

namespace MLambda.Actors.Test.Actors
{
    using System;
    using System.Reactive;
    using MLambda.Actors.Abstraction;
    using MLambda.Actors.Abstraction.Supervision;
    using MLambda.Actors.Supervision;
    using MLambda.Actors.Test.Actors.Command;

    /// <summary>
    /// The supervisor actor.
    /// </summary>
    public class SupervisionActor : Actor
    {
        /// <summary>
        /// Gets the supervisor.
        /// </summary>
        public override ISupervisor Supervisor => Strategy.OneForOne(decider =>
            decider
                .When<InvalidOperationException>(Directive.Resume)
                .When<InvalidCastException>(Directive.Restart)
                .When<InsufficientMemoryException>(Directive.Stop)
                .Default(Directive.Escalate));

        /// <inheritdoc/>
        protected override Behavior Receive(object data)
            =>
                data switch
                {
                    Message message when message.Action == "Resume" => Actor.Behavior(this.Resume),
                    Message message when message.Action == "Stop" => Actor.Behavior(this.Stop),
                    Message message when message.Action == "Restart" => Actor.Behavior(this.Restart),
                    Message message when message.Action == "Escalate" => Actor.Behavior(this.Escalate),
                    _ => Actor.Ignore
                };

        private IObservable<Unit> Resume()
        {
            throw new InvalidOperationException();
        }

        private IObservable<Unit> Stop()
        {
            throw new InsufficientMemoryException();
        }

        private IObservable<Unit> Restart()
        {
            throw new InvalidCastException();
        }

        private IObservable<Unit> Escalate()
        {
            throw new Exception();
        }
    }
}