using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using CyberBotChat.Modules.Startup;
using System.IO;


namespace CyberBotChat.Views
{
    /// <summary>
    /// Interaction logic for StartupWindow.xaml
    /// </summary>
    public partial class StartupWindow : Window
    {
        public StartupWindow()
        {
            InitializeComponent();
            PlayGreetingAudio();
        }

        private void PlayGreetingAudio()
        {
            try
            {
#pragma warning disable CA1416
                string audioPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Cassidy", "greeting.wav");
                if (File.Exists(audioPath))
                {
                    using (SoundPlayer player = new SoundPlayer(audioPath))
                    {
                        player.Load();
                        player.Play();
                    }
#pragma warning restore CA1416
                }
                else
                {
                    MessageBox.Show("Greeting audio file not found.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error playing audio: {ex.Message}");
            }
        }

        private void Continue_Click(object sender, RoutedEventArgs e)
        {
            string userName = NameInput.Text.Trim();

            if (string.IsNullOrEmpty(userName))
            {
                MessageBox.Show("Please enter your name before continuing.", "Missing Name", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Store user name globally (we’ll handle this with a static AppState class)
            AppState.UserName = userName;

            // Open the main window
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();

            this.Close();
        }
    }
}
