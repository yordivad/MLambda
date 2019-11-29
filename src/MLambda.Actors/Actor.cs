// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Actor.cs" company="MLambda">
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

namespace MLambda.Actors
{
    using System;
    using System.Reactive;
    using System.Reactive.Linq;
    using System.Reactive.Observable.Aliases;
    using MLambda.Actors.Abstraction;

    /// <summary>
    /// The actor implementation.
    /// </summary>
    public static class Actor
    {
        /// <summary>
        /// Gets The default value.
        /// </summary>
        public static IObservable<object> Default => Observable.Return((object)Unit.Default);

        /// <summary>
        /// Gets The ignore behavior.
        /// </summary>
        public static Behaivor Ignore => _ => Default;

        /// <summary>
        /// The Behavior handler for the message.
        /// </summary>
        /// <param name="apply">the lambda method.</param>
        /// <param name="a">the value a.</param>
        /// <typeparam name="Ta">The type of a.</typeparam>
        /// <typeparam name="To">The type of the response.</typeparam>
        /// <returns>The behavior.</returns>
        public static Behaivor Behavior<To>(Func<IContext, IObservable<To>> a)
        {
            return ctx => a(ctx).Map(val => (object) val);
        }

        /// <summary>
        /// The Behavior handler for the message.
        /// </summary>
        /// <param name="apply">the lambda method.</param>
        /// <param name="a">the value a.</param>
        /// <typeparam name="Ta">The type of a.</typeparam>
        /// <typeparam name="To">The type of the response.</typeparam>
        /// <returns>The behavior.</returns>
        public static Behaivor Behavior<To, Ta>(Func<IContext, Ta, IObservable<To>> apply, Ta a)
        {
            return ctx => apply(ctx, a).Map(val => (object) val);
        }

        /// <summary>
        /// The Behavior handler for the message.
        /// </summary>
        /// <param name="apply">the lambda method.</param>
        /// <param name="a">the value a.</param>
        /// <param name="b">the value b.</param>
        /// <typeparam name="To">The type of the response.</typeparam>
        /// <typeparam name="Ta">The type of a.</typeparam>
        /// <typeparam name="Tb">The type of b.</typeparam>
        /// <returns>The behavior.</returns>
        public static Behaivor Behavior<To, Ta, Tb>(Func<IContext, Ta, Tb, IObservable<To>> apply, Ta a, Tb b)
        {
            return ctx => apply(ctx, a, b).Map(val => (object) val);
        }

        /// <summary>
        /// The Behavior handler for the message.
        /// </summary>
        /// <param name="apply">the lambda method.</param>
        /// <param name="a">the value a.</param>
        /// <param name="b">the value b.</param>
        /// <param name="c">the value c.</param>
        /// <typeparam name="To">The type of the response.</typeparam>
        /// <typeparam name="Ta">The type of a.</typeparam>
        /// <typeparam name="Tb">The type of b.</typeparam>
        /// <typeparam name="Tc">The type of c.</typeparam>
        /// <returns>The behavior.</returns>
        public static Behaivor Behavior<To, Ta, Tb, Tc>(Func<IContext, Ta, Tb, Tc, IObservable<To>> apply, Ta a, Tb b,
            Tc c)
        {
            return ctx => apply(ctx, a, b, c).Map(val => (object) val);
        }

        /// <summary>
        /// The Behavior handler for the message.
        /// </summary>
        /// <param name="apply">the lambda method.</param>
        /// <param name="a">the value a.</param>
        /// <param name="b">the value b.</param>
        /// <param name="c">the value c.</param>
        /// <param name="d">the value d.</param>
        /// <typeparam name="To">The type of the response.</typeparam>
        /// <typeparam name="Ta">The type of a.</typeparam>
        /// <typeparam name="Tb">The type of b.</typeparam>
        /// <typeparam name="Tc">The type of c.</typeparam>
        /// <typeparam name="Td">The type of d.</typeparam>
        /// <returns>The behavior.</returns>
        public static Behaivor Behavior<To, Ta, Tb, Tc, Td>(Func<IContext, Ta, Tb, Tc, Td, IObservable<To>> apply, Ta a,
            Tb b, Tc c, Td d)
        {
            return ctx => apply(ctx, a, b, c, d).Map(val => (object) val);
        }
    }
}