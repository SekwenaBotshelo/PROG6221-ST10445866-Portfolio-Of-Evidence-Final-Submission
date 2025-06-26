using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CybersecurityAssistantApp.Models
{
    // Implementing the Task Assistant with Reminders
    public class CyberTask
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? ReminderDate { get; set; }
        public bool IsCompleted { get; set; }

        public override string ToString()
        {
            string status = IsCompleted ? "✅ Completed" : "🕒 Pending";
            string reminder = ReminderDate.HasValue ? ReminderDate.Value.ToShortDateString() : "No reminder";
            return $"{Title} [{status}]\n{Description} | Reminder: {reminder}";
        }
    }
}
