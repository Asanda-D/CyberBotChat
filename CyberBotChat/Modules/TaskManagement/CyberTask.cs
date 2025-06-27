using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberBotChat.Modules.TaskManagement
{
    class CyberTask
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? ReminderDate { get; set; }
        public bool IsCompleted { get; set; }

        public override string ToString()
        {
            string status = IsCompleted ? "✅ Completed" : "⏳ In Progress";
            string reminder = ReminderDate.HasValue ? $" | ⏰ {ReminderDate.Value:dd MMM yyyy}" : "";
            return $"{Title} - {Description}{reminder} [{status}]";
        }
    }
}
