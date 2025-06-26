using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace CybersecurityAssistantApp
{
    public partial class MainWindow : Window
    {
        private ActivityLog activityLogWindow;

        // Implementing the Task Assistant with Reminders
        public MainWindow()
        {
            InitializeComponent();
        }

        public void LogActivity(string message)
        {
            if (activityLogWindow == null)
            {
                activityLogWindow = new ActivityLog(this);
                activityLogWindow.Show();
            }

            activityLogWindow.AddLogEntry(message);
        }

        public List<string> GetRecentActivities(int count = 5)
        {
            if (activityLogWindow != null)
                return activityLogWindow.GetLatestEntries(count).Select(entry => entry.ToString()).ToList();
            return new List<string>();
        }

        private void BtnOpenTaskAssistant_Click(object sender, RoutedEventArgs e)
        {
            var taskWindow = new TaskAssistant(this);
            taskWindow.Show();
        }

        // Implementing the Cybersecurity Mini-Game(Quiz) - GUI
        private void BtnOpenCyberQuiz_Click(object sender, RoutedEventArgs e)
        {
            var quizWindow = new CyberQuiz(this);
            quizWindow.Show();
        }

        // Implementing Natural Language Processing (NLP) Simulation (GUI)
        private void BtnOpenNlpChat_Click(object sender, RoutedEventArgs e)
        {
            var nlpWindow = new NlpChatbot(this);
            nlpWindow.Show();
        }

        private void BtnOpenActivityLog_Click(object sender, RoutedEventArgs e)
        {
            if (activityLogWindow == null)
            {
                activityLogWindow = new ActivityLog(this);
                activityLogWindow.Show();
            }
            else
            {
                if (!activityLogWindow.IsVisible)
                    activityLogWindow.Show();
                activityLogWindow.Focus();
            }
        }
    }
}