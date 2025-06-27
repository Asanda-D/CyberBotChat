using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CyberBotChat.Modules.Startup;

namespace CyberBotChat.Modules.Quiz
{

    public class QuizQuestion
    {
        public string QuestionText { get; set; }
        public List<string> Options { get; set; }
        public int CorrectOptionIndex { get; set; }
        public string Explanation { get; set; }
        public bool IsTrueFalse => Options?.Count == 2 && Options.Contains("True") && Options.Contains("False");
    }

    public class CyberQuizCore
    {
        private readonly List<QuizQuestion> questions;
        private int currentQuestionIndex;
        private int score;

        public CyberQuizCore()
        {
            questions = GetQuizQuestions();
            currentQuestionIndex = 0;
            score = 0;
        }

        public QuizQuestion GetCurrentQuestion()
        {
            if (currentQuestionIndex < questions.Count)
                return questions[currentQuestionIndex];
            return null;
        }

        public bool SubmitAnswer(int selectedOptionIndex, out string feedback)
        {
            var currentQuestion = GetCurrentQuestion();
            if (currentQuestion == null)
            {
                feedback = "No more questions available.";
                return false;
            }

            bool isCorrect = selectedOptionIndex == currentQuestion.CorrectOptionIndex;

            if (isCorrect)
            {
                score++;
                feedback = $"✅ Correct! {currentQuestion.Explanation}";
            }
            else
            {
                string correctAnswer = currentQuestion.Options[currentQuestion.CorrectOptionIndex];
                feedback = $"❌ Incorrect. The correct answer is: \"{correctAnswer}\".\n{currentQuestion.Explanation}";
            }

            return isCorrect;
        }

        public int GetCurrentIndex() => currentQuestionIndex;

        public bool HasMoreQuestions => currentQuestionIndex < questions.Count;
        public void MoveToNextQuestion()
        {
            currentQuestionIndex++;
        }

        public bool IsQuizComplete()
        {
            return currentQuestionIndex >= questions.Count;
        }

        public int GetScore() => score;

        public string GetFinalFeedback()
        {
            if (score == 15)
                return $"🌟 WOW! {AppState.UserName}, You might actually be better than me at this thing. You're a cybersecurity wizard!";
            else if (score >= 11)
                return $"🎉 Well done {AppState.UserName}!! You’re making me proud – your cybersecurity game is strong!";
            else if (score >= 6)
                return $"👍 Not too bad {AppState.UserName}. But I still think you can do better!";
            else
                return $"😅 Boo hoo {AppState.UserName}, you need to keep learning buddy. Let’s level up your cyber skills!";
        }

        private List<QuizQuestion> GetQuizQuestions()
        {
            return new List<QuizQuestion>
            {
                new QuizQuestion
                {
                    QuestionText = "True or False: You should use the same password for all your online accounts.",
                    Options = new List<string> { "True", "False" },
                    CorrectOptionIndex = 1,
                    Explanation = "Using different passwords for each account helps prevent a breach from affecting multiple accounts."
                },
                new QuizQuestion
                {
                    QuestionText = "Which of the following is a strong password?",
                    Options = new List<string> { "123456", "qwerty", "P@ssw0rd!", "password" },
                    CorrectOptionIndex = 2,
                    Explanation = "Strong passwords include a mix of letters, numbers, and symbols."
                },
                new QuizQuestion
                {
                    QuestionText = "What does 2FA stand for?",
                    Options = new List<string> { "Two-Factor Authentication", "Two-Face Activation", "Two-Fire Alarm", "Too Fast Access" },
                    CorrectOptionIndex = 0,
                    Explanation = "2FA adds an extra layer of security by requiring a second form of verification."
                },
                new QuizQuestion
                {
                    QuestionText = "True or False: Clicking on pop-up ads is a safe way to get free software.",
                    Options = new List<string> { "True", "False" },
                    CorrectOptionIndex = 1,
                    Explanation = "Pop-up ads can often be malicious and lead to scams or viruses."
                },
                new QuizQuestion
                {
                    QuestionText = "Phishing is:",
                    Options = new List<string> {
                        "A cybersecurity tool", "A way to catch fish online",
                        "A scam where attackers trick you into giving personal info", "A software update"
                    },
                    CorrectOptionIndex = 2,
                    Explanation = "Phishing scams often involve fake emails or websites designed to steal your information."
                },
                new QuizQuestion
                {
                    QuestionText = "Which of these should you NOT share online?",
                    Options = new List<string> { "Your favorite food", "Your home address", "Your favorite movie", "Your pet's name" },
                    CorrectOptionIndex = 1,
                    Explanation = "Personal details like your home address can be used to target you."
                },
                new QuizQuestion
                {
                    QuestionText = "True or False: Using public Wi-Fi to log into your bank account is perfectly safe.",
                    Options = new List<string> { "True", "False" },
                    CorrectOptionIndex = 1,
                    Explanation = "Public Wi-Fi can be intercepted by hackers, making it unsafe for sensitive activity."
                },
                new QuizQuestion
                {
                    QuestionText = "Which is the best way to protect your device?",
                    Options = new List<string> { "Keep it in your pocket", "Install antivirus and keep software updated", "Use it only during the day", "Always charge it fully" },
                    CorrectOptionIndex = 1,
                    Explanation = "Antivirus and software updates protect against the latest threats."
                },
                new QuizQuestion
                {
                    QuestionText = "Which of these is an example of social engineering?",
                    Options = new List<string> {
                        "A hacker using brute-force", "An email asking for your password pretending to be your bank",
                        "Installing antivirus", "Restarting your router"
                    },
                    CorrectOptionIndex = 1,
                    Explanation = "Social engineering tricks people into giving up personal information."
                },
                new QuizQuestion
                {
                    QuestionText = "True or False: It's safe to click a link in an email without checking the sender.",
                    Options = new List<string> { "True", "False" },
                    CorrectOptionIndex = 1,
                    Explanation = "Always verify the sender before clicking links – phishing emails may look legitimate."
                },
                new QuizQuestion
                {
                    QuestionText = "What is a VPN used for?",
                    Options = new List<string> {
                        "Speeding up your internet", "Protecting your identity online", "Downloading games", "Watching cat videos"
                    },
                    CorrectOptionIndex = 1,
                    Explanation = "VPNs help secure your internet connection and protect your privacy."
                },
                new QuizQuestion
                {
                    QuestionText = "Which password is the most secure?",
                    Options = new List<string> {
                        "mybirthday", "password123", "IlovePizza!", "8@T!m#P2q$L"
                    },
                    CorrectOptionIndex = 3,
                    Explanation = "Long, random passwords with symbols and numbers are hardest to crack."
                },
                new QuizQuestion
                {
                    QuestionText = "True or False: It's okay to reuse passwords as long as they're strong.",
                    Options = new List<string> { "True", "False" },
                    CorrectOptionIndex = 1,
                    Explanation = "Even strong passwords shouldn’t be reused across sites. A breach on one can affect others."
                },
                new QuizQuestion
                {
                    QuestionText = "How often should you update your passwords?",
                    Options = new List<string> { "Every week", "Only when you forget them", "Every 3-6 months", "Never" },
                    CorrectOptionIndex = 2,
                    Explanation = "Regularly updating your passwords helps keep accounts secure."
                },
                new QuizQuestion
                {
                    QuestionText = "What should you do if you receive a suspicious email?",
                    Options = new List<string> {
                        "Reply to ask what it’s about", "Click the link to investigate", "Mark it as spam or report it", "Ignore it and delete it"
                    },
                    CorrectOptionIndex = 2,
                    Explanation = "Report suspicious emails to help stop phishing and alert your email provider."
                }
            };
        }
    }
}
