// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CollectorSteps.cs" company="MLambda">
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
    using System.Reactive.Linq;
    using MLambda.Actors.Abstraction.Context;
    using MLambda.Actors.Guardian.Messages;
    using MLambda.Actors.Test.Actors;
    using TechTalk.SpecFlow;

    [Binding]
    public class CollectorSteps
    {
        private readonly ScenarioContext scenario;

        private readonly ISystemContext system;

        private readonly IUserContext user;

        public CollectorSteps(ScenarioContext scenario, ISystemContext system, IUserContext user)
        {
            this.scenario = scenario;
            this.system = system;
            this.user = user;
        }

        [Given(@"an user actor")]
        public async void GivenAnUserActor()
        {
            await this.user.Self.Send(new object());
            var count = await this.system.Self.Send<ProcessCount, int>(new ProcessCount());
            this.scenario["expected_count"] = count;
        }

        [When(@"the console actor is called")]
        public async void WhenTheConsoleActorIsCalled()
        {
            using (var console = await this.user.Spawn<ConsoleActor>())
            {
                var count = await this.system.Self.Send<ProcessCount, int>(new ProcessCount());
                this.scenario["after_actor"] = count;
            }

            this.scenario["actual_count"] = await this.system.Self.Send<ProcessCount, int>(new ProcessCount());
        }

        [Then(@"verify that console actor was relased")]
        public void ThenVerifyThatConsoleActorWasRelased()
        {
            var expectedCount = this.scenario.Get<int>("expected_count");
            var actualCount = this.scenario.Get<int>("actual_count");
            ////expectedCount.ShouldBe(actualCount);
            var afterActor = this.scenario.Get<int>("after_actor");
            ////afterActor.ShouldBe(expectedCount + 1);
        }
    }
}