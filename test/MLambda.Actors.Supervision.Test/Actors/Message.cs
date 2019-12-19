namespace MLambda.Actors.Supervision.Test.Actors
{
    public class Message
    {
        public Message(string action)
        {
            this.Action = action;
        }

        public string Action { get; }
    }
}