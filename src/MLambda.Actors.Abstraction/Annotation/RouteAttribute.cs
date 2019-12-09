// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RouteAttribute.cs" company="MLambda">
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

namespace MLambda.Actors.Abstraction.Annotation
{
    using System;

    /// <summary>
    /// The address attribute.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class RouteAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RouteAttribute"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        public RouteAttribute(string name)
        {
            this.Name = name;
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        public string Name { get; }
    }
}