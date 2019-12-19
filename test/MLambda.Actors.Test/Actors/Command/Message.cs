namespace MLambda.Actors.Test.Actors.Command
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