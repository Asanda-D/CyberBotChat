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
using CyberBotChat.Modules.Logging;
using CyberBotChat.Modules.Quiz;
using CyberBotChat.Modules.Startup;

namespace CyberBotChat.Views.Controls
{
    /// <summary>
    /// Interaction logic for CyberQuizControl.xaml
    /// </summary>
    public partial class CyberQuizControl : UserControl
    {

        private CyberQuizCore quizCore;
        private bool answeredCurrentQuestion;

        public CyberQuizControl()
        {
            InitializeComponent();
            quizCore = new CyberQuizCore();
            ActivityLogger.Log("Quiz started: Cybersecurity Basics"); // ✅ Log quiz start
            LoadCurrentQuestion();
        }

        private void LoadCurrentQuestion()
        {
            var question = quizCore.GetCurrentQuestion();
            if (question == null)
            {
                // ✅ Log final score when quiz completes
                string finalFeedback = quizCore.GetFinalFeedback();
                int finalScore = quizCore.GetScore();
                ActivityLogger.Log($"Quiz completed: Score {finalScore}/15 — \"{finalFeedback}\"");

                QuestionTextBlock.Text = "Quiz Complete!";
                OptionsListBox.Items.Clear();
                FeedbackTextBlock.Text = $"\n\n\nYour final score is {finalScore} out of 15.\n{finalFeedback}";

                SubmitButton.IsEnabled = false;
                NextButton.IsEnabled = false;
                SubmitButton.Visibility = Visibility.Collapsed;
                NextButton.Visibility = Visibility.Collapsed;
                return;
            }

            QuestionTextBlock.Text = question.QuestionText;
            OptionsListBox.Items.Clear();

            for (int i = 0; i < question.Options.Count; i++)
            {
                var item = new ListBoxItem
                {
                    Content = question.Options[i],
                    Tag = i
                };
                OptionsListBox.Items.Add(item);
            }

            FeedbackTextBlock.Text = "";
            SubmitButton.IsEnabled = true;
            NextButton.IsEnabled = false;
            answeredCurrentQuestion = false;
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            if (answeredCurrentQuestion)
                return;

            if (OptionsListBox.SelectedItem is ListBoxItem selectedItem)
            {
                int selectedIndex = (int)selectedItem.Tag;

                var question = quizCore.GetCurrentQuestion();
                bool isCorrect = quizCore.SubmitAnswer(selectedIndex, out string feedback);
                FeedbackTextBlock.Text = feedback;

                ActivityLogger.Log($"{AppState.UserName} answered the question: \"{question.QuestionText}\"");
                ActivityLogger.Log($"CyberBot marked: \"{feedback}\"");


                // ✅ Log whether user got the answer right or wrong
                int currentQuestionNumber = quizCore.GetCurrentIndex(); // Add this getter in CyberQuizCore
                string result = isCorrect ? "✅" : "❌";
                string status = isCorrect ? "correctly" : "incorrectly";
                ActivityLogger.Log($"Answered Q{currentQuestionNumber} {status}: \"{question.QuestionText}\" {result}");

                SubmitButton.IsEnabled = false;
                NextButton.IsEnabled = true;
                answeredCurrentQuestion = true;
            }
            else
            {
                MessageBox.Show("Please select an answer before submitting.", "Select an Option", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            quizCore.MoveToNextQuestion();
            LoadCurrentQuestion();
        }

        private void ResetQuizButton_Click(object sender, RoutedEventArgs e)
        {
            quizCore = new CyberQuizCore();
            answeredCurrentQuestion = false;
            ActivityLogger.Log($"Quiz reset by {AppState.UserName}.");

            SubmitButton.Visibility = Visibility.Visible;
            NextButton.Visibility = Visibility.Visible;

            LoadCurrentQuestion();
        }

    }
}