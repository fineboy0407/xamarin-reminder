using Microsoft.AppCenter;
using Microsoft.AppCenter.Push;
using ReminderXamarin.Helpers;
using ReminderXamarin.Interfaces;
using ReminderXamarin.Models;
using ReminderXamarin.Pages;
using Xamarin.Forms;
using Device = Xamarin.Forms.Device;

namespace ReminderXamarin
{
    public partial class App : Application
    {
        public const string NotificationReceivedKey = "NotificationReceived";

        public App()
        {
            InitializeComponent();
            string dbPath = DependencyService.Get<IFileHelper>().GetLocalFilePath(ConstantsHelper.SqLiteDataBaseName);

            NoteRepository = new NoteRepository(dbPath);
            ToDoRepository = new ToDoRepository(dbPath);
            AchievementRepository = new AchievementRepository(dbPath);
            UserRepository = new UserRepository(dbPath);
            BirthdaysRepository = new BirthdaysRepository(dbPath);

            bool.TryParse(Settings.UsePin, out bool shouldUsePin);
            if (shouldUsePin)
            {
                MainPage = new PinPage();
            }
            else
            {
                MainPage = new LoginPage();
            }

            MessagingCenter.Subscribe<object, string>(this, NotificationReceivedKey, OnMessageReceived);
        }

        // TODO: implement notification logic here
        private void OnMessageReceived(object sender, string msg)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                var alertService = DependencyService.Get<IAlertService>();
                alertService.ShowYesNoAlert("Notification received", "Ok", "Cancel");
            });
        }

        /// <summary>
        /// Get Note repository with help dependency service.
        /// </summary>
        /// <value>The database.</value>
        public static NoteRepository NoteRepository { get; private set; }

        /// <summary>
        /// Get To-do models repository with help of dependency service.
        /// </summary>
        /// <value>The database.</value>
        public static ToDoRepository ToDoRepository { get; private set; }

        /// <summary>
        /// Get achievement models repository with help dependency service.
        /// </summary>
        /// <value>The database.</value>
        public static AchievementRepository AchievementRepository { get; private set; }

        /// <summary>
        /// Get users repository with help dependency service.
        /// </summary>
        /// <value>The database.</value>
        public static UserRepository UserRepository { get; private set; }

        /// <summary>
        /// Get birthday repository with help dependency service.
        /// </summary>
        /// <value>The database.</value>
        public static BirthdaysRepository BirthdaysRepository { get; private set; }

        protected override void OnStart()
        {
            // Handle when your app starts
            AppCenter.Start("dbcc1105-ebfa-4b6a-8fec-8ea02bd5454e", typeof(Push));
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
