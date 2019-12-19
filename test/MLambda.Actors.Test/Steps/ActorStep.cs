// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ActorStep.cs" company="MLambda">
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

namespace MLambda.Actors.Test.Steps
{
    using System;
    using System.Reactive.Linq;
    using MLambda.Actors.Abstraction.Context;
    using MLambda.Actors.Test.Actors;
    using TechTalk.SpecFlow;

    [Binding]
    public class ActorStep
    {
        private readonly IUserContext user;

        public ActorStep(IUserContext user, ScenarioContext scenario)
        {
            this.user = user;
        }

        [Given(@"a context")]
        public void GivenAContext()
        {
        }

        [When(@"Create the actor")]
        public async void WhenCreateTheActor()
        {
            var address = await this.user.Spawn<ConsoleActor>();
            await address.Send("Hello World");
            var x = await address.Send<(string a, string b), string>(("a", "b"));
            Console.WriteLine(x);
        }
    }
}