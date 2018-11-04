namespace ReminderXamarin.Interfaces
{
    /// <summary>
    /// Implement this interface in Android and iOS projects to get current device orientation.
    /// </summary>
    public interface IDeviceOrientation
    {
        /// <summary>
        /// Get device current orientation
        /// </summary>
        DeviceOrientations GetOrientation();
    }

    public enum DeviceOrientations
    {
        Undefined,
        Landscape,
        Portrait
    }
}