using System;
using System.Collections.Generic;
using ReminderXamarin.Pages;
using ReminderXamarin.Resx;

namespace ReminderXamarin.Helpers
{
    /// <summary>
    /// Helper class. Provide list of MasterPageItem for MenuPage.
    /// </summary>
    public static class MenuHelper
    {
        public static List<MasterPageItem> GetMenu()
        {
            var masterPageItems = new List<MasterPageItem>
            {
                new MasterPageItem
                {
                    Title = AppResources.Notes,
                    IconSource = ConstantsHelper.NotesListIcon,
                    TargetType = typeof(NotesPage),
                    IsDisplayed = true
                },
                new MasterPageItem
                {
                    Title = AppResources.ToDoSection,
                    IconSource = ConstantsHelper.ToDoListIcon,
                    TargetType = typeof(ToDoTabbedPage),
                    IsDisplayed = true
                },
                new MasterPageItem
                {
                    Title = AppResources.Birthdays,
                    IconSource = ConstantsHelper.BirthdaysIcon,
                    TargetType = typeof(BirthdaysPage),
                    IsDisplayed = true
                },
                new MasterPageItem
                {
                    Title = AppResources.Achievements,
                    IconSource = ConstantsHelper.AchievementsIcon,
                    TargetType = typeof(AchievementsPage),
                    IsDisplayed = true
                },
                new MasterPageItem
                {
                    Title = AppResources.Settings,
                    IconSource = ConstantsHelper.SettingsIcon,
                    TargetType = typeof(SettingsPage),
                    IsDisplayed = true
                }
            };
            return masterPageItems;
        }
    }

    public class MasterPageItem
    {
        /// <summary>
        /// Title that will be displayed in side menu.
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Icon source that will be displayed in side menu.
        /// </summary>
        public string IconSource { get; set; }
        /// <summary>
        /// Page on which user will be redirected.
        /// </summary>
        public Type TargetType { get; set; }
        /// <summary>
        /// Show this item in side menu or not.
        /// </summary>
        public bool IsDisplayed { get; set; }
    }

    public enum MenuPageIndex
    {
        NotesPage,
        ToDoPage,
        BirthdaysPage,
        AchievementsPage,
        SettingsPage
    }
}