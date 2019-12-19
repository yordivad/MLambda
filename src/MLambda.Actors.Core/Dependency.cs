// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Dependency.cs" company="MLambda">
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

namespace MLambda.Actors.Core
{
    using System;
    using Microsoft.Extensions.DependencyInjection;
    using MLambda.Actors.Abstraction.Core;

    /// <summary>
    /// The dependency class.
    /// </summary>
    public class Dependency : IDependency
    {
        private readonly IServiceProvider provider;

        /// <summary>
        /// Initializes a new instance of the <see cref="Dependency"/> class.
        /// </summary>
        /// <param name="provider">The provider.</param>
        public Dependency(IServiceProvider provider)
        {
            this.provider = provider;
        }

        /// <summary>
        /// Revolve the instance of type T.
        /// </summary>
        /// <typeparam name="T">The type of the instance.</typeparam>
        /// <returns>The instance.</returns>
        public T Resolve<T>()
        {
            return this.provider.GetService<T>();
        }

        /// <summary>
        /// Resolve the instance of the type.
        /// </summary>
        /// <param name="type">the type of the instance.</param>
        /// <returns>The instance as object.</returns>
        public object Resolve(Type type)
        {
            return this.provider.GetService(type);
        }
    }
}