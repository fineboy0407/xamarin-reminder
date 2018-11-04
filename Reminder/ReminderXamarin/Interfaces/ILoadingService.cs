namespace ReminderXamarin.Interfaces
{
    /// <summary>
    /// Provides functionality to show loading overlay to user.
    /// </summary>
    public interface ILoadingService
    {
        /// <summary>
        /// Show loading circle indicator with text "Loading..." if no message passed.
        /// </summary>
        void ShowLoading(string message = null);
        /// <summary>
        /// Hide loading overlay.
        /// </summary>
        void HideLoading();
    }
}