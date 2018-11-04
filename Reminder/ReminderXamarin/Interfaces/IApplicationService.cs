namespace ReminderXamarin.Interfaces
{
    /// <summary>
    /// Provide functionality to control application state.
    /// </summary>
    public interface IApplicationService
    {
        /// <summary>
        /// Close application without any error.
        /// </summary>
        void CloseApplication();
    }
}