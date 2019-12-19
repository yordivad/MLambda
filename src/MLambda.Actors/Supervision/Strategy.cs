namespace MLambda.Actors.Supervision
{
    using System;
    using MLambda.Actors.Abstraction;
    using MLambda.Actors.Abstraction.Supervision;

    /// <summary>
    /// The strategy builder.
    /// </summary>
    public static class Strategy
    {
        /// <summary>
        /// Create an one to one supervision.
        /// </summary>
        /// <param name="builder">the decider builder.</param>
        /// <returns>the supervisor.</returns>
        public static ISupervisor OneForOne(Func<Decider, Decider> builder)
        {
            return new OneForOne(builder(new Decider()));
        }
    }
}