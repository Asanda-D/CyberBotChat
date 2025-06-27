using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CyberBotChat.Views.Controls;
using CyberBotChat.Modules;
using CyberBotChat.Modules.Startup;

namespace CyberBotChat
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ChatbotControl chatbotControl;
        private TaskManagerControl taskManagerControl;
        private CyberQuizControl cyberQuizControl;
        private ActivityLogControl activityLogControl;

        public MainWindow()
        {
            InitializeComponent();

            // Instantiate all controls once
            chatbotControl = new ChatbotControl();
            taskManagerControl = new TaskManagerControl();
            cyberQuizControl = new CyberQuizControl();
            activityLogControl = new ActivityLogControl();

            // ✅ Hook up navigation
            AppState.NavigationRequested = NavigateTo;

            // Show chatbot by default
            MainContentArea.Content = chatbotControl;
        }

        private void NavigateTo(string destination)
        {
            switch (destination)
            {
                case "TaskManager":
                    MainContentArea.Content = new TaskManagerControl();
                    break;

                case "CyberQuiz":
                    MainContentArea.Content = new CyberQuizControl();
                    break;

                case "ActivityLog":
                    MainContentArea.Content = new ActivityLogControl();
                    break;

                case "Chatbot":
                default:
                    MainContentArea.Content = new ChatbotControl();
                    break;
            }
        }

        private void ChatNav_Click(object sender, RoutedEventArgs e)
        {
            MainContentArea.Content = chatbotControl;
        }

        private void TaskNav_Click(object sender, RoutedEventArgs e)
        {
            MainContentArea.Content = taskManagerControl;
        }

        private void QuizNav_Click(object sender, RoutedEventArgs e)
        {
            MainContentArea.Content = cyberQuizControl;
        }

        private void LogNav_Click(object sender, RoutedEventArgs e)
        {
            MainContentArea.Content = activityLogControl;
        }

        private void ToggleDrawer_Click(object sender, RoutedEventArgs e)
        {
            MainDrawerHost.IsLeftDrawerOpen = !MainDrawerHost.IsLeftDrawerOpen;
        }
    }
}
