using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberBotChat.Modules.Logging
{
    class ActivityLogger
    {
        // Observable collection so UI updates automatically when bound
        public static ObservableCollection<string> LogEntries { get; } = new ObservableCollection<string>();

        // Add a new log entry with timestamp
        public static void Log(string message)
        {
            string timestamp = DateTime.Now.ToString("dd MMM yyyy, HH:mm");
            string entry = $"[{timestamp}] {message}";
            LogEntries.Add(entry);
        }
    }
}
