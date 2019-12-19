namespace MLambda.Actors.Supervision.Test.Steps
{
    using System.Reactive.Linq;
    using System.Threading.Tasks;
    using MLambda.Actors.Abstraction;
    using MLambda.Actors.Supervision.Test.Actors;
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
            var actor = await this.user.Spawn<ConsoleActor>();
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
          //  this.scenario.Pending();
        }
    }
}