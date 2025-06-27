using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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
using CyberBotChat.Modules.TaskManagement;

namespace CyberBotChat.Views.Controls
{
    // Interaction logic for TaskManagerControl.xaml
    public partial class TaskManagerControl : UserControl
    {

        private readonly List<CyberTask> taskList = new();
        private CyberTask selectedTaskForAction;

        public TaskManagerControl()
        {
            InitializeComponent();
            TaskListBox.SelectionChanged += TaskListBox_SelectionChanged;
        }

        private void AddTaskButton_Click(object sender, RoutedEventArgs e)
        {
            string title = TaskTitleBox.Text.Trim();
            string description = TaskDescriptionBox.Text.Trim();
            DateTime? reminder = TaskReminderPicker.SelectedDate;

            if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(description))
            {
                MessageBox.Show("Please enter both title and description.", "Missing Fields", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var task = new CyberTask
            {
                Title = title,
                Description = description,
                ReminderDate = reminder,
                IsCompleted = false
            };

            taskList.Add(task);
            RefreshTaskList();

            ActivityLogger.Log($"Task added: {title} — reminder: {(reminder?.ToShortDateString() ?? "No reminder")}");

            // Clear inputs
            TaskTitleBox.Text = "";
            TaskDescriptionBox.Text = "";
            TaskReminderPicker.SelectedDate = null;
        }

        private void RefreshTaskList()
        {
            TaskListBox.Items.Clear();

            foreach (var task in taskList)
            {
                var item = new ListBoxItem
                {
                    Content = task.ToString(),
                    Tag = task
                };
                TaskListBox.Items.Add(item);
            }
        }

        private void TaskListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TaskListBox.SelectedItem is ListBoxItem item && item.Tag is CyberTask task)
            {
                selectedTaskForAction = task;
                TaskDialogHost.IsOpen = true; // open the dialog
            }
        }

        private void MarkCompleted_Click(object sender, RoutedEventArgs e)
        {
            if (selectedTaskForAction != null)
            {
                selectedTaskForAction.IsCompleted = true;

                // Log task completed
                ActivityLogger.Log($"Task completed: {selectedTaskForAction.Title}");
            }

            RefreshTaskList();
            TaskDialogHost.IsOpen = false;
        }

        private void ConfirmDelete_Click(object sender, RoutedEventArgs e)
        {
            var confirm = MessageBox.Show("Are you sure you want to delete this task permanently?", "Confirm Delete",
                                          MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (confirm == MessageBoxResult.Yes && selectedTaskForAction != null)
            {
                ActivityLogger.Log($"Task deleted: {selectedTaskForAction.Title}");

                taskList.Remove(selectedTaskForAction);
                RefreshTaskList();
            }

            TaskDialogHost.IsOpen = false;
        }

        private void CloseDialog_Click(object sender, RoutedEventArgs e)
        {
            TaskDialogHost.IsOpen = false;
        }
    }
}
