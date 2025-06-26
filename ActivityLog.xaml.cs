using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using CybersecurityAssistantApp.Models;

namespace CybersecurityAssistantApp
{
    // Implementing Natural Language Processing(NLP) Simulation(GUI)
    // Implementing Activity Log Feature(GUI)
    public partial class ActivityLog : Window
    {
        private MainWindow mainWindow;
        private List<LogEntry> logEntries = new List<LogEntry>();

        public ActivityLog(MainWindow caller)
        {
            InitializeComponent();
            mainWindow = caller;
        }

        public void AddLogEntry(string message)
        {
            var entry = new LogEntry
            {
                Message = message,
                Timestamp = DateTime.Now
            };

            logEntries.Add(entry);
            txtLog.AppendText(entry + "\n");
            txtLog.ScrollToEnd();
        }

        public List<LogEntry> GetLatestEntries(int count = 5)
        {
            int skip = Math.Max(0, logEntries.Count - count);
            return logEntries.Skip(skip).ToList();
        }
    }
}
