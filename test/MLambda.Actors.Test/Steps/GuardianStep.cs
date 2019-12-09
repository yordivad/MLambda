using System.Reactive.Linq;
using MLambda.Actors.Abstraction;
using MLambda.Actors.Guardian.Messages;
using TechTalk.SpecFlow;

namespace MLambda.Actors.Test.Steps
{
    [Binding]
    public class GuardianStep
    {
        private ScenarioContext scenario;
        
        private IBucket bucket;

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
            await this.scenario.Get<IAddress>("context").Send(new object());
        }

        [When(@"Send a Not Valid Message")]
        public async void WhenSendANotValidMessage()
        {
            await this.scenario.Get<IAddress>("context").Send(new object());
        }

        [Then(@"Verify it Handle the message")]
        public void ThenVerifyItHandleTheMessage()
        {
        }
    }
}