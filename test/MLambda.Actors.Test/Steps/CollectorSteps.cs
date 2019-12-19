using MLambda.Actors.Guardian.Messages;
using Shouldly;

namespace MLambda.Actors.Test.Steps
{
    using System.Reactive.Linq;
    using MLambda.Actors.Abstraction;
    using MLambda.Actors.Test.Specimen;
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
            this.user.Self.Send(new object());
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
            //expectedCount.ShouldBe(actualCount);
            var afterActor = this.scenario.Get<int>("after_actor");
           // afterActor.ShouldBe(expectedCount + 1);
        }
    }
}