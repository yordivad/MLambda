// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Promise.cs" company="MLambda">
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

namespace MLambda.Actors.Abstraction
{
    using System;
    using System.Reactive.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// The feature class.
    /// </summary>
    public class Promise
    {
        private readonly TaskCompletionSource<object> callback;

        /// <summary>
        /// Initializes a new instance of the <see cref="Promise"/> class.
        /// </summary>
        /// <param name="message">the message to propagate.</param>
        /// <param name="wait">it should wait.</param>
        public Promise(object message, bool wait)
        {
            this.Wait = wait;
            this.Message = message;
            this.callback = new TaskCompletionSource<object>();
        }

        /// <summary>
        /// Gets a value indicating whether gets for wait for the response.
        /// </summary>
        public bool Wait { get; }

        /// <summary>
        /// Gets the message.
        /// </summary>
        public object Message { get; }

        /// <summary>
        /// Change the feature to a observable.
        /// </summary>
        /// <typeparam name="TO">The type of the response.</typeparam>
        /// <returns>The response.</returns>
        public IObservable<TO> ToObservable<TO>()
        {
            return Observable.FromAsync(async () => (TO)await this.callback.Task);
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