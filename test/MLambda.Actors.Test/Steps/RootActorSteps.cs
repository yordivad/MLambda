// <copyright file="RootActorSteps.cs" company="MLambda">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using MLambda.Actors.Test.Actors;

namespace MLambda.Actors.Test.Steps
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Reactive.Linq;
    using MLambda.Actors.Abstraction;
    using MLambda.Actors.Guardian.Messages;
    using Shouldly;
    using TechTalk.SpecFlow;

    /// <summary>
    /// The root actor steps.
    /// </summary>
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
            this.system.Self.Send(new object());
            this.user.Self.Send(new object());

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
            this.system.Self.Send(new Kill(console.Id));
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