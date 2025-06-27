using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
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
using CyberBotChat.Modules.Logging;

namespace CyberBotChat.Views.Controls
{
    // Interaction logic for ActivityLogControl.xaml
    public partial class ActivityLogControl : UserControl, INotifyPropertyChanged
    {
        private ListCollectionView limitedView;
        private bool _showAllLogs;

        public bool ShowAllLogs
        {
            get => _showAllLogs;
            set
            {
                if (_showAllLogs != value)
                {
                    _showAllLogs = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ShowAllLogs)));
                    UpdateView(); // Refresh log visibility when toggled
                }
            }
        }

        public ActivityLogControl()
        {
            InitializeComponent();

            limitedView = new ListCollectionView(ActivityLogger.LogEntries);
            limitedView.Filter = _ => true;

            ShowAllLogs = false;

            DataContext = this;

            UpdateView();

            LogItemsControl.ItemsSource = limitedView;

            ActivityLogger.LogEntries.CollectionChanged += LogEntries_CollectionChanged;
        }

        private void LogEntries_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            UpdateView();
        }

        private void UpdateView()
        {
            limitedView.Filter = (item) =>
            {
                if (ShowAllLogs)
                    return true;

                int index = ActivityLogger.LogEntries.IndexOf(item as string);
                return index >= Math.Max(0, ActivityLogger.LogEntries.Count - 10);
            };

            limitedView.Refresh();
        }

        private void ToggleShowMore_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            ShowAllLogs = !ShowAllLogs;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
