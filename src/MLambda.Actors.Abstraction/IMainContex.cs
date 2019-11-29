namespace MLambda.Actors.Abstraction
{
    /// <summary>
    /// The main context interface.
    /// </summary>
    public interface IMainContex: IContext
    {
        /// <summary>
        /// Sets the process.
        /// </summary>
        /// <param name="pid">the process.</param>
        void SetProcess(IProcess pid);
    }
}