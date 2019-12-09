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
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reactive;
    using System.Reactive.Linq;
    using MLambda.Actors.Abstraction;
    using MLambda.Actors.Abstraction.Annotation;
    using MLambda.Actors.Abstraction.Guardian;
    using MLambda.Actors.Guardian.Messages;

    /// <summary>
    /// The system actor class.
    /// </summary>
    [Route("")]
    public class RootActor : IRootActor
    {
        private readonly IBucket bucket;

        /// <summary>
        /// Initializes a new instance of the <see cref="RootActor"/> class.
        /// </summary>
        /// <param name="bucket">the bucket.</param>
        public RootActor(IBucket bucket)
        {
            this.bucket = bucket;
        }

        /// <summary>
        /// Receives the message.
        /// </summary>
        /// <param name="data">the data.</param>
        /// <returns>the behavior.</returns>
        public Behavior Receive(object data) =>
            data switch
            {
                Kill message => Actor.Behavior(this.Kill, message),
                ProcessCount _ => Actor.Behavior(this.Count),
                ProcessFilter message => Actor.Behavior(this.Filter, message),
                _ => Actor.Ignore
            };

        private IObservable<int> Count()
        {
            return this.bucket.Count();
        }

        private IObservable<IEnumerable<Pid>> Filter(ProcessFilter filter)
        {
            if (filter.Route == "*")
            {
                return Observable.Return(this.bucket.Filter(c => true).Select(c => new Pid(c.Id, c.Route, c.Status)));
            }

            return Observable.Return(this.bucket.Filter(c => c.Route == filter.Route)
                .Select(c => new Pid(c.Id, c.Route, c.Status)));
        }

        private IObservable<Unit> Kill(Kill message)
        {
          return this.bucket.Release(message.Id);
        }
    }
}