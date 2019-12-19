// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RootActorSteps.cs" company="MLambda">
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
    using System.Collections.Generic;
    using System.Linq;
    using System.Reactive.Linq;
    using MLambda.Actors.Abstraction.Context;
    using MLambda.Actors.Guardian.Messages;
    using MLambda.Actors.Test.Actors;
    using Shouldly;
    using TechTalk.SpecFlow;

    [Binding]
    public class RootActorSteps
    {
        private readonly ISystemContext system;

        private readonly IUserContext user;

        private readonly ScenarioContext scenario;

        public RootActorSteps(ScenarioContext scenario, ISystemContext system, IUserContext user)
        {
            this.system = system;
            this.user = user;
            this.scenario = scenario;
        }

        [Given(@"a demo actor")]
        public async void GivenADemoActor()
        {
            await this.system.Self.Send(new object());
            await this.user.Self.Send(new object());

            var processes = await this.system.Self.Send<ProcessFilter, IEnumerable<Pid>>(new ProcessFilter("*"));

            this.scenario["expected_actors"] = processes.Count();
            var actor = this.user.Spawn<ConsoleActor>();
            this.scenario["actor"] = actor;
        }

        [When(@"Kill the process")]
        public async void WhenKillTheProcess()
        {
            var processes =
                await this.system.Self.Send<ProcessFilter, IEnumerable<Pid>>(new ProcessFilter("/user/console"));
            var console = processes.FirstOrDefault();
            await this.system.Self.Send(new Kill(console.Id));
            processes = await this.system.Self.Send<ProcessFilter, IEnumerable<Pid>>(new ProcessFilter("*"));
            this.scenario["actual_actors"] = processes.Count();
        }

        [Then(@"the Actor is removed from the bucket")]
        public void ThenTheActorIsRemovedFromTheBucket()
        {
            var actualActors = this.scenario.Get<int>("actual_actors");
            var expectedActors = this.scenario.Get<int>("expected_actors");
            actualActors.ShouldBe(expectedActors);
        }
    }
}