using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ReminderXamarin.Extensions
{
    public static class ObservableExtension
    {
        public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> source)
        {
            return new ObservableCollection<T>(source);
        }
    }
}