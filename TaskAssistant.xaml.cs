using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using CybersecurityAssistantApp.Models;

namespace CybersecurityAssistantApp
{
    // Implementing the Task Assistant with Reminders
    public partial class TaskAssistant : Window
    {
        private ObservableCollection<CyberTask> tasks = new ObservableCollection<CyberTask>();
        private MainWindow mainWindow;

        public TaskAssistant(MainWindow caller)
        {
            InitializeComponent();
            mainWindow = caller;

            lvTasks.ItemsSource = tasks;
        }

        private void AddTask_Click(object sender, RoutedEventArgs e)
        {
            string title = txtTitle.Text.Trim();
            string description = txtDescription.Text.Trim();

            if (string.IsNullOrEmpty(title))
            {
                MessageBox.Show("Please enter a task title.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            DateTime? reminderDate = null;

            if (dpReminder.SelectedDate.HasValue)
            {
                reminderDate = dpReminder.SelectedDate.Value;

                if (!string.IsNullOrEmpty(txtReminderTime.Text))
                {
                    if (TimeSpan.TryParse(txtReminderTime.Text, out TimeSpan time))
                    {
                        reminderDate = reminderDate.Value.Date + time;
                    }
                    else
                    {
                        MessageBox.Show("Invalid time format. Please enter time as HH:mm (24-hour).", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }
                }
            }

            CyberTask newTask = new CyberTask()
            {
                Title = title,
                Description = description,
                ReminderDate = reminderDate,
                IsCompleted = false
            };

            tasks.Add(newTask);

            mainWindow.LogActivity($"Task added: '{title}'{(reminderDate.HasValue ? $" with reminder on {reminderDate.Value:G}" : "")}.");

            ClearInputs();
        }

        private void ClearInputs()
        {
            txtTitle.Clear();
            txtDescription.Clear();
            dpReminder.SelectedDate = null;
            txtReminderTime.Clear();
        }

        private void MarkComplete_Click(object sender, RoutedEventArgs e)
        {
            if (sender is CheckBox cb && cb.DataContext is CyberTask task)
            {
                task.IsCompleted = cb.IsChecked == true;
                string status = task.IsCompleted ? "completed" : "marked as pending";
                mainWindow.LogActivity($"Task '{task.Title}' {status}.");
                lvTasks.Items.Refresh();
            }
        }

        private void DeleteTask_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn && btn.DataContext is CyberTask task)
            {
                if (MessageBox.Show($"Are you sure you want to delete the task '{task.Title}'?", "Confirm Delete", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    tasks.Remove(task);
                    mainWindow.LogActivity($"Task deleted: '{task.Title}'.");
                }
            }
        }
    }
}
