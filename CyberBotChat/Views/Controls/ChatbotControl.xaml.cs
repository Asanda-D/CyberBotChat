using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CyberBotChat.Modules.CoreChat;
using CyberBotChat.Modules.Logging;
using CyberBotChat.Modules.Startup;
using MaterialDesignThemes.Wpf;

namespace CyberBotChat.Views.Controls
{
    /// <summary>
    /// Interaction logic for ChatbotControl.xaml
    /// </summary>
    public partial class ChatbotControl : UserControl
    {
        private CyberBot bot;

        public ChatbotControl()
        {
            InitializeComponent();

            bot = new CyberBot(DisplayBotMessage);
            bot.Initialize(AppState.UserName);

            SendButton.Click += SendButton_Click;

            DisplayBotMessage($"{AppState.UserName}! 😉 My name is CyberLock Guard. How can I assist you today?");
        }

        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            string userInput = UserInputBox.Text.Trim();

            if (!string.IsNullOrEmpty(userInput))
            {
                DisplayUserMessage(userInput);
                HandleIntent(userInput); // ⬅️ Handle NLP first
                bot.ProcessInput(userInput);
                UserInputBox.Clear();
            }
        }

        private void DisplayUserMessage(string message)
        {
            ChatStackPanel.Children.Add(new TextBlock
            {
                Text = $"{AppState.UserName}: {message}",
                FontWeight = FontWeights.SemiBold,
                Margin = new Thickness(5)
            });

            ChatScrollViewer.ScrollToEnd();
        }

        private void DisplayBotMessage(string message)
        {
            ChatStackPanel.Children.Add(new TextBlock
            {
                Text = $"CyberLock: {message}",
                Margin = new Thickness(5)
            });

            ChatScrollViewer.ScrollToEnd();
        }

        private void ResetChatButton_Click(object sender, RoutedEventArgs e)
        {
            ChatStackPanel.Children.Clear();

            bot = new CyberBot(DisplayBotMessage);
            bot.Initialize(AppState.UserName);

            DisplayBotMessage($"Hi again, {AppState.UserName}! 🔄 Let's start fresh.");
            ActivityLogger.Log("Chatbot conversation cleared by user.");
        }

        // ✅ NLP + DialogHost
        private void HandleIntent(string userInput)
        {
            string intent = IntentDetector.DetectIntent(userInput);

            if (intent == "add_task")
            {
                var result = MessageBox.Show("Would you like to open the Task Manager to add a task?", "Task Manager", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    AppState.NavigationRequested?.Invoke("TaskManager");
                    DisplayBotMessage("Okay! Redirecting you to the Task Manager...");
                }
                else
                {
                    DisplayBotMessage("Alright, let me know if you'd like to do it later.");
                }
            }
            else if (intent == "start_quiz")
            {
                var result = MessageBox.Show("Would you like to start the Cybersecurity Quiz now?", "Cyber Quiz", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    AppState.NavigationRequested?.Invoke("CyberQuiz");
                    DisplayBotMessage("Great! Launching the quiz now...");
                }
                else
                {
                    DisplayBotMessage("Okay, no problem. Just let me know when you're ready!");
                }
            }
        }
    }
}

