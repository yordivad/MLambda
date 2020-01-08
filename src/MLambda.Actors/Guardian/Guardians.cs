// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Guardians.cs" company="MLambda">
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
    using MLambda.Actors.Abstraction;
    using MLambda.Actors.Abstraction.Core;

    /// <summary>
    /// The Guardians class.
    /// </summary>
    public class Guardians
    {
        /// <summary>
        /// Gets the root process.
        /// </summary>
        public IProcess Root { get; private set; }

        /// <summary>
        /// Gets the system process.
        /// </summary>
        public IProcess System { get; private set; }

        /// <summary>
        /// Gets the user process.
        /// </summary>
        public IProcess User { get; private set; }

        /// <summary>
        /// Loads the guardians actors.
        /// </summary>
        /// <param name="bucket">the bucket of the process.</param>
        /// <param name="dependency">the dependency resolver.</param>
        public void Load(IBucket bucket, IDependency dependency)
        {
            this.Root = new Process(bucket, null, new WorkUnit(dependency, typeof(RootActor)));
            this.User = new Process(bucket, this.Root, new WorkUnit(dependency, typeof(UserActor)));
            this.System = new Process(bucket, this.Root, new WorkUnit(dependency, typeof(SystemActor)));
            this.Root.Start();
            this.User.Start();
            this.System.Start();
        }
    }
}