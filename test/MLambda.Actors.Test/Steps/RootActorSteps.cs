// <copyright file="RootActorSteps.cs" company="MLambda">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MLambda.Actors.Test.Steps
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Reactive.Linq;
    using MLambda.Actors.Abstraction;
    using MLambda.Actors.Guardian.Messages;
    using MLambda.Actors.Test.Specimen;
    using Shouldly;
    using TechTalk.SpecFlow;

    /// <summary>
    /// The root actor steps.
    /// </summary>
    [Binding]
    public class RootActorSteps
    {
        private readonly IRootContext root;

        private readonly IUserContext user;

        private readonly ScenarioContext scenario;


        public RootActorSteps(ScenarioContext scenario, IRootContext root, IUserContext user)
        {
            this.root = root;
            this.user = user;
            this.scenario = scenario;
        }

        [Given(@"a demo actor")]
        public async void GivenADemoActor()
        {
            this.root.Self.Send(new object());
            this.user.Self.Send(new object());

            var processes = await this.root.Self.Send<ProcessFilter, IEnumerable<Pid>>(new ProcessFilter("*"));

            this.scenario["expected_actors"] = processes.Count();
            var actor = this.user.Spawn<ConsoleActor>();
            this.scenario["actor"] = actor;
        }

        [When(@"Kill the process")]
        public async void WhenKillTheProcess()
        {
            var processes =
                await this.root.Self.Send<ProcessFilter, IEnumerable<Pid>>(new ProcessFilter("/user/console"));
            var console = processes.FirstOrDefault();
            this.root.Self.Send(new Kill(console.Id));
            processes = await this.root.Self.Send<ProcessFilter, IEnumerable<Pid>>(new ProcessFilter("*"));
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