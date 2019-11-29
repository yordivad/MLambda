namespace MLambda.Actors.Test.Steps
{
    using System.Reactive.Linq;
    using Actors.Abstraction;
    using Actors.Test.Specimen;
    using TechTalk.SpecFlow;

    [Binding]
    public class ActorStep
    {
        private readonly ScenarioContext scenario;

        public ActorStep(ScenarioContext scenario)
        {
            this.scenario = scenario;
        }

        [Given(@"a context")]
        public void GivenAContext()
        {
        }

        [When(@"Create the actor")]
        public async void WhenCreateTheActor()
        {
            var user = this.scenario.Get<IUserContext>("provider");
            var address = await user.Spawn<ConsoleActor>();
            await address.Send("Hello World");
        }

    }
}