using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CybersecurityAssistantApp.Models
{
    public class LogEntry
    {
        public string Message { get; set; }
        public DateTime Timestamp { get; set; }

        public override string ToString()
        {
            return $"{Timestamp:G}: {Message}";
        }
    }
}
