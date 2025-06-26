using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using CybersecurityAssistantApp.Models;

namespace CybersecurityAssistantApp
{
    public partial class CyberQuiz : Window
    {
        private List<QuizQuestion> questions;
        private int currentQuestionIndex = 0;
        private int score = 0;
        private RadioButton selectedRadioButton = null;

        private MainWindow mainWindow;

        public CyberQuiz(MainWindow caller)
        {
            InitializeComponent();
            mainWindow = caller;

            LoadQuestions();
            DisplayQuestion();
        }

        private void LoadQuestions()
        {
            questions = new List<QuizQuestion>()
            {
                new QuizQuestion("What should you do if you receive an email asking for your password?",
                    new List<string> { "Reply with your password", "Delete the email", "Report the email as phishing", "Ignore it" },
                    2,
                    "Correct! You should report phishing emails to help protect yourself and others."),

                new QuizQuestion("True or False: Using 'password123' is a strong password.",
                    new List<string> { "True", "False" },
                    1,
                    "Correct! 'password123' is a very weak password and should never be used."),

                // Add 8 more questions similarly...
                new QuizQuestion("Which of these is the safest practice for passwords?",
                    new List<string> { "Use the same password everywhere", "Use complex, unique passwords", "Write passwords on sticky notes", "Share passwords with friends" },
                    1,
                    "Using complex, unique passwords for every account is the safest practice."),

                new QuizQuestion("What is phishing?",
                    new List<string> { "A type of fishing", "A cyber attack to steal information", "A software update", "A firewall feature" },
                    1,
                    "Phishing is a cyber attack where attackers trick you into giving sensitive information."),

                new QuizQuestion("True or False: You should never click on suspicious links in emails.",
                    new List<string> { "True", "False" },
                    0,
                    "Correct! Clicking suspicious links can lead to malware or scams."),

                new QuizQuestion("Which of these is NOT a social engineering tactic?",
                    new List<string> { "Pretexting", "Baiting", "Password cracking", "Tailgating" },
                    2,
                    "Password cracking is a technical attack, not a social engineering tactic."),

                new QuizQuestion("Two-factor authentication (2FA) is:",
                    new List<string> { "Using two passwords", "Adding a second verification step", "Logging in twice", "An antivirus feature" },
                    1,
                    "2FA adds an extra layer of security by requiring a second verification step."),

                new QuizQuestion("What should you do if your computer starts running very slowly after opening an email attachment?",
                    new List<string> { "Ignore it", "Run a malware scan", "Delete the attachment only", "Reboot the computer repeatedly" },
                    1,
                    "Running a malware scan can help detect and remove harmful software."),

                new QuizQuestion("True or False: Public Wi-Fi networks are always safe to use without precautions.",
                    new List<string> { "True", "False" },
                    1,
                    "Correct! Public Wi-Fi can be insecure; use VPNs or avoid sensitive transactions."),

                new QuizQuestion("What is the best way to keep your software secure?",
                    new List<string> { "Ignore updates", "Install updates promptly", "Use pirated software", "Disable firewalls" },
                    1,
                    "Installing updates promptly helps patch security vulnerabilities.")
            };
        }

        private void DisplayQuestion()
        {
            txtFeedback.Visibility = Visibility.Collapsed;
            btnNext.IsEnabled = false;
            btnSubmit.IsEnabled = true;
            spAnswers.Children.Clear();
            selectedRadioButton = null;

            if (currentQuestionIndex < questions.Count)
            {
                QuizQuestion q = questions[currentQuestionIndex];
                txtQuestion.Text = $"Q{currentQuestionIndex + 1}: {q.QuestionText}";

                for (int i = 0; i < q.Options.Count; i++)
                {
                    RadioButton rb = new RadioButton
                    {
                        Content = q.Options[i],
                        Tag = i,
                        GroupName = "Answers",
                        Margin = new Thickness(0, 5, 0, 5),
                        FontSize = 16
                    };

                    rb.Checked += AnswerSelected;
                    spAnswers.Children.Add(rb);
                }
            }
            else
            {
                ShowFinalResults();
            }
        }

        private void AnswerSelected(object sender, RoutedEventArgs e)
        {
            selectedRadioButton = sender as RadioButton;
        }

        private void BtnSubmit_Click(object sender, RoutedEventArgs e)
        {
            if (selectedRadioButton == null)
            {
                MessageBox.Show("Please select an answer before submitting.", "No Answer Selected", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            btnSubmit.IsEnabled = false;
            btnNext.IsEnabled = true;

            int selectedIndex = (int)selectedRadioButton.Tag;
            QuizQuestion currentQ = questions[currentQuestionIndex];

            if (selectedIndex == currentQ.CorrectIndex)
            {
                score++;
                txtFeedback.Foreground = System.Windows.Media.Brushes.Green;
                txtFeedback.Text = $"Correct! {currentQ.Explanation}";
            }
            else
            {
                txtFeedback.Foreground = System.Windows.Media.Brushes.Red;
                txtFeedback.Text = $"Incorrect. {currentQ.Explanation}";
            }

            txtFeedback.Visibility = Visibility.Visible;
        }

        private void BtnNext_Click(object sender, RoutedEventArgs e)
        {
            currentQuestionIndex++;
            DisplayQuestion();
        }

        private void ShowFinalResults()
        {
            txtQuestion.Text = $"Quiz Complete! Your score: {score} out of {questions.Count}";

            string performance;
            double percent = (double)score / questions.Count;

            if (percent >= 0.9)
                performance = "Excellent! You're a cybersecurity pro!";
            else if (percent >= 0.7)
                performance = "Good job! Keep learning.";
            else if (percent >= 0.4)
                performance = "Not bad, but consider reviewing cybersecurity basics.";
            else
                performance = "Needs improvement. Stay vigilant!";

            txtFeedback.Foreground = System.Windows.Media.Brushes.Blue;
            txtFeedback.Text = performance;
            txtFeedback.Visibility = Visibility.Visible;

            spAnswers.Children.Clear();
            btnSubmit.Visibility = Visibility.Collapsed;
            btnNext.Visibility = Visibility.Collapsed;
            btnRestart.Visibility = Visibility.Visible;

            // Log final score
            mainWindow.LogActivity($"CyberQuiz: Quiz completed with score {score}/{questions.Count}.");
        }

        private void BtnRestart_Click(object sender, RoutedEventArgs e)
        {
            currentQuestionIndex = 0;
            score = 0;

            btnSubmit.Visibility = Visibility.Visible;
            btnNext.Visibility = Visibility.Visible;
            btnRestart.Visibility = Visibility.Collapsed;

            DisplayQuestion();

            mainWindow.LogActivity("CyberQuiz: Quiz restarted.");
        }
    }
}
