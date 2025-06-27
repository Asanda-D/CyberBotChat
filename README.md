# 🛡️CYBERLOCK GUARD – Cybersecurity Awareness Chatbot

**Cyberlock** is a WPF-based educational chatbot designed to teach South African users about cybersecurity. Built with C# and XAML, it offers a friendly interface, guided conversations, quizzes, reminders, and personalized learning — all aligned with the PROG6221 POE Part 3 requirements.

---

## 1. Setting Up the Development Environment
**To run the project locally:**
- **Requirements:**

- Visual Studio 2022 or later

- .NET 8.0 SDK 

- NuGet packages:
  - MaterialDesignThemes
  - MaterialDesignColors

- System.Speech

**Steps:**
- **Clone the repository:**

```git clone https://github.com/Asanda-D/CyberBotChat.git```

- Open the solution in Visual Studio.

- Add missing audio file:
  - Place your greeting.wav in the Cassidy folder.

- Build the solution and run the project.

---

## 2. System Functionality & Features

**Conversational Chatbot (CyberLock):** 
- Provides dynamic and friendly responses to user queries.

**Natural Language Processing (NLP):**
- Detects intent from variations of phrases like “add a task”, “start quiz”.

- Redirects users via confirmation dialogs.

**Task Assistant:**
- Add, complete, and delete tasks with reminder support.

**Cybersecurity Quiz Mini-Game:**
- Multiple-choice questions to test user knowledge.

**Activity Log:**
- Automatically logs all actions.

- Shows last 10 logs by default with a "Show More" toggle.

**Startup Greeting:**
- Splash screen with personalized welcome using speech synthesis.

---

## 3. UI & Styling Features

- Modern WPF GUI using Material Design in XAML.

- Sidebar navigation for Chat, Tasks, Quiz, and Log.

- Color-coded feedback and branding:

- CyberLock in Blue variants

- Alerts and warnings in yellow/red

- Responsive dialog interactions using DialogHost.

- Task and log items styled as Material Design cards.

---

## 4. Improvements Implemented (from Part 2 + Lecturer Feedback)

**Feedback / Requirement	Implementation:**

- Add release tag	GitHub release created for Part 3 final version.
- Improve memory features	User interests are now remembered and recalled in chat.
- Use of delegates	Delegate-based callbacks implemented for dynamic response.
- Enhanced commenting	Code files now include clear XML summaries and inline comments.
- GUI implementation	WPF with modern, responsive interface.
- Task Assistant required features	Fully functional: add, complete, delete tasks.
- Cybersecurity Quiz	Interactive and randomly-selected quiz questions.
- Dialog-based intent handling (NLP)	Custom dialog appears based on detected user intent.
- Activity log constraints	Shows 10 logs by default with "Show More" feature.
- Personalized startup	Splash screen with audio and user name memory.

---

## 5. Folder Structure Overview

```
Solution 'CyberBotChat'
└── Project - CyberBotChat
    ├── Cassidy
    │   └── greeting.wav
    ├── Modules
    │   ├── Converters
    │   │   └── BooleanToTextConverter.cs
    │   ├── CoreChat
    │   │   ├── CyberBot.cs
    │   │   ├── IntentDetector.cs
    │   │   ├── KeywordResponder.cs
    │   │   ├── SentimentDetector.cs
    │   │   ├── TopicManager.cs
    │   │   └── UserMemory.cs
    │   ├── Logging
    │   │   └── ActivityLogger.cs
    │   ├── Quiz
    │   │   └── CyberQuizCore.cs
    │   ├── Startup
    │   │   └── AppState.cs
    │   └── TaskManagement
    │       └── CyberTask.cs
    ├── Views
    │   ├── Controls
    │   │   ├── ActivityLogControl.xaml / .xaml.cs
    │   │   ├── ChatbotControl.xaml / .xaml.cs
    │   │   ├── CyberQuizControl.xaml / .xaml.cs
    │   │   └── TaskManagerControl.xaml / .xaml.cs
    │   ├── MainWindow.xaml / .xaml.cs
    │   └── StartupWindow.xaml / .xaml.cs
    ├── App.xaml / App.xaml.cs
    └── AssemblyInfo.cs
```

---

## 6. Developer Info

- **Developer:** Asanda Dimba

- **Institution:** Varsity College Westville

- **Module:** PROG6221 – POE Part 3

- **Student No:** ST10366285

## 7. Demo Video

[Link: YouTube URL Here]
This video demonstrates the chatbot in action, including task reminders, quizzes, and natural language recognition.

## 8. License
This project is developed for academic purposes as part of the Portfolio of Evidence (POE) submission for ST10366285.
It is not licensed for commercial use.

### FYI
- All references used can be found in file: **App.xaml.cs**
- All emojies were retrived from: https://emojipedia.org/shield
