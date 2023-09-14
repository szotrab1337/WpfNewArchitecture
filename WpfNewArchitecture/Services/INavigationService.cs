namespace WpfNewArchitecture.Services
{
    public interface INavigationService
    {
        /// <summary>
        /// Navigate to specific Page. It will be displayed in configured Frame.
        /// </summary>
        /// <typeparam name="T">Page registered in _viewMapping</typeparam>
        /// <param name="args">Arguments to pass</param>
        void Navigate<T>(object? args = null);

        /// <summary>
        /// It should be use during initialization. Set main frame used to navigation.
        /// </summary>
        /// <param name="mainFrame">Main frame. Should be placed for example in MainWindow</param>
        void SetFrame(object mainFrame);
    }
}
