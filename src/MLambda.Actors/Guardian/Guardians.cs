namespace MLambda.Actors.Guardian
{
    using MLambda.Actors.Abstraction;
    using MLambda.Actors.Abstraction.Core;

    public class Guardians
    {
        public IProcess Root { get; private set; }

        public IProcess System { get; private set; }

        public IProcess User { get; private set; }


        public void Load(IBucket bucket, IDependency dependency)
        {
            var rootJob = new WorkUnit(dependency, typeof(RootActor));
            this.Root = new Process(bucket, null, rootJob);
            this.User = new Process(bucket, rootJob, new WorkUnit(dependency, typeof(UserActor)));
            this.System = new Process(bucket, rootJob, new WorkUnit(dependency, typeof(SystemActor)));
            this.Root.Start();
            this.User.Start();
            this.System.Start();
        }
    }
}