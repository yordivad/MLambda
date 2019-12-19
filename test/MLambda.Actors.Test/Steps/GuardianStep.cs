// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GuardianStep.cs" company="MLambda">
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
    using MLambda.Actors.Abstraction;
    using MLambda.Actors.Abstraction.Core;
    using TechTalk.SpecFlow;

    [Binding]
    public class GuardianStep
    {
        private readonly ScenarioContext scenario;

        private readonly IBucket bucket;

        public GuardianStep(ScenarioContext scenario, IBucket bucket)
        {
            this.scenario = scenario;
            this.bucket = bucket;
        }

        [Given(@"an root context")]
        public void GivenAnRootContext()
        {
            this.scenario["context"] = this.bucket.Root;
        }

        [Given(@"an user context")]
        public void GivenAnUserContext()
        {
            this.scenario["context"] = this.bucket.User;
        }

        [When(@"Send a Stop Message")]
        public async void WhenSendAStopMessage()
        {
            await this.scenario.Get<ILink>("context").Send(new object());
        }

        [When(@"Send a Not Valid Message")]
        public async void WhenSendANotValidMessage()
        {
            await this.scenario.Get<ILink>("context").Send(new object());
        }

        [Then(@"Verify it Handle the message")]
        public void ThenVerifyItHandleTheMessage()
        {
        }
    }
}