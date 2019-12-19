// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OneForOneSteps.cs" company="MLambda">
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
    using System.Threading.Tasks;
    using MLambda.Actors.Abstraction;
    using MLambda.Actors.Abstraction.Context;
    using MLambda.Actors.Test.Actors;
    using MLambda.Actors.Test.Actors.Command;
    using TechTalk.SpecFlow;

    [Binding]
    public class OneForOneSteps
    {
        private readonly ScenarioContext scenario;

        private readonly IUserContext user;

        public OneForOneSteps(ScenarioContext scenario, IUserContext user)
        {
            this.scenario = scenario;
            this.user = user;
        }

        [Given(@"a actor with one to one strategy")]
        public async Task GivenAActorWithOneToOneStrategy()
        {
            var actor = await this.user.Spawn<SupervisionActor>();
            this.scenario["actor"] = actor;
        }

        [When(@"the actor send a restart message")]
        public void WhenTheActorSendARestartMessage()
        {
            var actor = this.scenario.Get<ILink>("actor");
            actor.Send(new Message("Restart"));
        }

        [Then(@"Create a new actor and replace it\.")]
        public void ThenCreateANewActorAndReplaceIt_()
        {
          ////  this.scenario.Pending();
        }
    }
}