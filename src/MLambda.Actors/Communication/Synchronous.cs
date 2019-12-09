// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Synchronous.cs" company="MLambda">
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
    using System;
    using System.Reactive.Linq;
    using System.Threading.Tasks;
    using MLambda.Actors.Abstraction;

    /// <summary>
    /// The feature class.
    /// </summary>
    public class Synchronous : IMessage
    {
        private readonly TaskCompletionSource<object> callback;

        /// <summary>
        /// Initializes a new instance of the <see cref="Synchronous"/> class.
        /// </summary>
        /// <param name="message">the message to propagate.</param>
        public Synchronous(object message)
        {
            this.Payload = message;
            this.callback = new TaskCompletionSource<object>();
        }

        /// <summary>
        /// Gets the message.
        /// </summary>
        public object Payload { get; }

        /// <summary>
        /// Change the feature to a observable.
        /// </summary>
        /// <typeparam name="TO">The type of the response.</typeparam>
        /// <returns>The response.</returns>
        public IObservable<TO> ToObservable<TO>()
        {
            return Observable.Return((TO)this.callback.Task.Result);
        }

        /// <summary>
        /// Responses to the observable.
        /// </summary>
        /// <param name="response">the response.</param>
        public void Response(object response)
        {
            this.callback.SetResult(response);
        }
    }
}