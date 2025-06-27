using System.Configuration;
using System.Data;
using System.Windows;
using CyberBotChat.Modules.Startup;
using CyberBotChat.Views;

namespace CyberBotChat
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var startupWindow = new StartupWindow();
            startupWindow.ShowDialog(); // This will block until the window closes

            var mainWindow = new MainWindow();
            mainWindow.Show();
        }
    }
}