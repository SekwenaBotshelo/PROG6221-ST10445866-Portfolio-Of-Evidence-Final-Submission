using System;
using System.Linq;
using System.Windows;
using CybersecurityAssistantApp.Models;

namespace CybersecurityAssistantApp
{
    // Implementing Natural Language Processing(NLP) Simulation(GUI)
    public partial class NlpChatbot : Window
    {
        private MainWindow mainWindow;

        public NlpChatbot(MainWindow caller)
        {
            InitializeComponent();
            mainWindow = caller;
            LogBot("Hello! I’m your Cybersecurity Assistant. How can I help you today?");
        }

        private void BtnSend_Click(object sender, RoutedEventArgs e)
        {
            string userInput = txtUserInput.Text.Trim();

            if (string.IsNullOrEmpty(userInput))
                return;

            AppendChat("You: " + userInput);
            txtUserInput.Clear();

            string botResponse = ProcessInput(userInput);

            AppendChat("Bot: " + botResponse);
            LogBot(botResponse);
        }

        private void AppendChat(string message)
        {
            txtChatLog.AppendText(message + Environment.NewLine);
            txtChatLog.ScrollToEnd();
        }

        private void LogBot(string message)
        {
            mainWindow.LogActivity("NLPChatbot: " + message);
        }

        private string ProcessInput(string input)
        {
            input = input.ToLower();

            if (input.Contains("activity log") || input.Contains("what have you done") || input.Contains("show log"))
            {
                var recent = mainWindow.GetRecentActivities(5);
                if (recent.Any())
                {
                    string response = "Here's a summary of recent actions:\n" + string.Join("\n", recent);
                    mainWindow.LogActivity("💬 NLP response: Displayed activity log.");
                    return response;
                }
                else
                {
                    return "No recent activities to show.";
                }
            }

            // Basic keyword detection with flexible phrasing
            if (input.Contains("add task") || input.Contains("add a task") || input.Contains("task"))
            {
                return "To add a task, please use the Task Assistant section.";
            }
            if (input.Contains("quiz") || input.Contains("test"))
            {
                return "You can test your knowledge in the Cybersecurity Quiz section.";
            }
            if (input.Contains("remind me") || input.Contains("reminder"))
            {
                return "Reminders can be set up in the Task Assistant.";
            }
            if (input.Contains("password"))
            {
                return "Use strong passwords and consider enabling two-factor authentication.";
            }
            if (input.Contains("phishing"))
            {
                return "Be cautious of emails asking for personal information or passwords.";
            }
            if (input.Contains("hello") || input.Contains("hi") || input.Contains("hey"))
            {
                return "Hello! How can I assist you with cybersecurity today?";
            }

            return "Sorry, I didn’t understand that. Try asking about tasks, quiz, reminders, passwords, or phishing.";
        }
    }
}
