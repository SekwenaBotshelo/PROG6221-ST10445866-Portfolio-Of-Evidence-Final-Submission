# CybersecurityAssistantApp

Author: Botshelo Koketso Sekwena - ST10445866
Github Link: https://github.com/SekwenaBotshelo/PROG6221-ST10445866-Portfolio-Of-Evidence-Final-Submission.git
YouTube Video Presentation Link: 

Description:
A Windows desktop application designed to educate South African citizens on cybersecurity awareness. This chatbot offers interactive guidance, task management, mini-quizzes, natural language processing simulation, and activity logging to improve user engagement and learning.

Features:
- Voice-Over Greeting: Plays a welcoming audio message on startup.
- Chat Interface: Conversational UI with personalized responses.
- Task Assistant: Manage cybersecurity-related tasks and reminders.
- Mini-Game Quiz: Interactive cybersecurity knowledge quizzes.
- NLP Simulation: Basic natural language processing for dynamic responses.
- Activity Log: Tracks and displays all chatbot interactions and user activities.
- Sentiment & Intent Recognition: Adapts responses based on user input tone.

Setup Instructions:
- Prerequisites:
  - Windows OS (supports Windows 10 or later)
  - .NET 6.0 Desktop Runtime or higher installed
  - Visual Studio 2022 (recommended) or newer with .NET Desktop Development workload installed
 
- Installation:
  - Clone the repository:
      - /// git clone https://github.com/yourusername/cybersecurity-chatbot.git
cd cybersecurity-chatbot ///
  - Open the solution file:
      - Open CybersecurityAssistantApp.sln in Visual Studio.
  - Restore NuGet packages:
      - Visual Studio will automatically restore the packages on build. Alternatively, run:
          - /// dotnet restore ///
  - Build the project:
      - Use Visual Studio’s Build > Build Solution or run:
          - dotnet build
       
  - Run the application:
      - Start the application via Visual Studio (F5) or from command line:
          - dotnet run --project CybersecurityAssistantApp

Usage Instructions:
Starting the Chatbot
- When the app starts, a voice greeting plays.
- You will be prompted to enter your name.
- Use the chat interface to ask cybersecurity questions or navigate features.

Task Assistant
- Create, view, and delete cybersecurity-related tasks.
- Set reminders and get notifications.

Mini-Game Quiz
- Select the quiz from the main menu.
- Answer multiple-choice questions.
- Get immediate feedback and scores.

NLP Simulation
- Type natural language questions or statements about cybersecurity.
- The chatbot will respond dynamically based on detected intent and sentiment.

Activity Log
- View recent actions and chatbot interactions.
- Access the activity log anytime from the main menu.

____________________________________________________________________________________________ 
Example Interaction:
____________________________________________________________________________________________ 
User: Hi, what is phishing?
Chatbot: Phishing is a cyber attack where attackers trick you into revealing sensitive information...                                                                          

User: Remind me to update my password tomorrow.
Chatbot: Reminder set for updating your password tomorrow.

User: Start quiz.
Chatbot: Great! Here is your first question...
____________________________________________________________________________________________

Project Structure:
CybersecurityAssistantApp/
│
├── Assets/                          # Icons, ASCII art, WAV audio
│
├── Data/                            # Logs and local storage
│   └── ActivityLog.cs
│
├── NLP/                             # NLP response manager
│   └── ResponseManager.cs
│
├── Tasks/                           # Reminders and Task Assistant logic
│   └── TaskManager.cs
│
├── Game/                            # Cybersecurity quiz logic
│   └── QuizManager.cs
│
├── Views/                           # All XAML forms and UI screens
│   ├── MainWindow.xaml
│   ├── QuizWindow.xaml
│   ├── TaskWindow.xaml
│   ├── NLPWindow.xaml
│   └── LogWindow.xaml
│
├── App.xaml                         # Application configuration
├── App.config                       # Additional settings (if used)
├── MainWindow.xaml.cs               # Main screen backend logic
├── CybersecurityAssistantApp.csproj # .NET project configuration
└── README.md                        # Documentation file

Development Notes

The chatbot uses basic keyword matching and sentiment analysis for NLP simulation.
- Tasks and activity logs are stored locally (extend to cloud storage if needed).
- The mini-game quiz questions are customizable in the source code.

Troubleshooting
- If the voice greeting does not play, ensure your sound drivers are up to date.
- For build errors related to missing dependencies, verify your .NET SDK installation and restore    NuGet packages.
- If UI elements do not appear correctly, rebuild the project and check for XAML errors.

Contact:

For questions or support, please contact:

Botshelo Sekwena — st10445866@imconnect.edu.za

Referances:

1.) Andrew Troelsen, Phil Japikse. (2022). Pro C# 10 with .NET 6 - 
	Foundational Principles and Practices in Programming .
	Bhambersburg, PA, USA - West Chester, OH, USA: Apress.

2.) Farrell, J. (2022). JAVA Programming. Tenth ed. 200 Pier 4 Boulevard Boston,
	MA 02210 USA: Cengage 

3.) OpenAI. “ChatGPT.” Chatgpt.com, OpenAI, 2025, chatgpt.com.
