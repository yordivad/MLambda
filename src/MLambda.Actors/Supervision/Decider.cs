// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Decider.cs" company="MLambda">
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
    using System.Collections.Generic;
    using MLambda.Actors.Abstraction.Supervision;

    /// <summary>
    /// The decider class.
    /// </summary>
    public class Decider : IDecider
    {
        private readonly Dictionary<Type, Directive> decisions;

        private Directive @default;

        /// <summary>
        /// Initializes a new instance of the <see cref="Decider"/> class.
        /// </summary>
        public Decider()
        {
            this.@default = Directive.Restart;
            this.decisions = new Dictionary<Type, Directive>();
        }

        /// <summary>
        /// Match the type of the exception to the directive.
        /// </summary>
        /// <param name="directive">The directive.</param>
        /// <typeparam name="T">The type of the exception.</typeparam>
        /// <returns>The actual decider.</returns>
        public Decider When<T>(Directive directive)
        {
            this.decisions.Add(typeof(T), directive);
            return this;
        }

        /// <summary>
        /// Sets the default value for any exception.
        /// </summary>
        /// <param name="directive">The directive.</param>
        /// <returns>the actual decider.</returns>
        public Decider Default(Directive directive)
        {
            this.@default = directive;
            return this;
        }

        /// <summary>
        /// The decision for the type of exception.
        /// </summary>
        /// <param name="fail">the fail exception.</param>
        /// <returns>the directive.</returns>
        public Directive Decision(Exception fail)
        {
            return !this.decisions.ContainsKey(fail.GetType())
                ? this.@default
                : this.decisions[fail.GetType()];
        }
    }
}