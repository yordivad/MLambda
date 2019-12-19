using MLambda.Actors.Test.Actors.Command;

namespace MLambda.Actors.Supervision.Test.Actors
{
    using System;
    using System.Reactive;
    using MLambda.Actors.Abstraction;
    using MLambda.Actors.Abstraction.Supervision;

    public class SupervisionActor : Actor
    {
        public ISupervisor Supervisor => Strategy.OneForOne(decider =>
            decider
                .When<InvalidOperationException>(Directive.Resume)
                .When<InvalidCastException>(Directive.Restart)
                .When<InsufficientMemoryException>(Directive.Stop)
                .Default(Directive.Escalate));

        protected override Behavior Receive(object data)
            =>
                data switch
                {
                    Message message when message.Action == "Resume" => Actor.Behavior(this.Resume),
                    Message message when message.Action == "Stop" => Actor.Behavior(this.Stop),
                    Message message when message.Action == "Restart" => Actor.Behavior(this.Restart),
                    Message message when message.Action == "Escalate" => Actor.Behavior(this.Escalate),
                    _ => Actor.Ignore
                };


        private IObservable<Unit> Resume()
        {
            throw new InvalidOperationException();
        }

        private IObservable<Unit> Stop()
        {
            throw new InsufficientMemoryException();
        }

        private IObservable<Unit> Restart()
        {
            throw new InvalidCastException();
        }

        private IObservable<Unit> Escalate()
        {
            throw new Exception();
        }
    }
}