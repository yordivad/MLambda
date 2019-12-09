namespace MLambda.Actors.Test.Steps
{
    using System;
    using System.Reactive.Linq;
    using MLambda.Actors.Abstraction;
    using MLambda.Actors.Test.Specimen;
    using TechTalk.SpecFlow;

    /// <summary>
    /// The actor steps scenario.
    /// </summary>
    [Binding]
    public class ActorStep
    {
        private readonly IUserContext user;

        private readonly ScenarioContext scenario;


        /// <summary>
        /// Initializes a new instance of the <see cref="ActorStep"/> class.
        /// </summary>
        /// <param name="user">The user context.</param>
        /// <param name="scenario">the scenario.</param>
        public ActorStep(IUserContext user, ScenarioContext scenario)
        {
            this.user = user;
            this.scenario = scenario;
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