using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CyberBotChat.Modules.Startup;
using CyberBotChat.Modules;


namespace CyberBotChat
{
    public class CyberBot
    {
        private readonly Action<string> outputAction;
        private readonly Action<string> navigateAction;
        private readonly KeywordResponder keywordResponder;
        private readonly TopicManager topicManager;
        private readonly UserMemory memory;
        private readonly SentimentDetector sentimentDetector;
        private string currentTopic = "";

        public CyberBot(Action<string> outputCallback, Action<string> navigate = null)
        {
            outputAction = outputCallback;
            navigateAction = navigate;
            keywordResponder = new KeywordResponder();
            topicManager = new TopicManager();
            memory = new UserMemory();
            sentimentDetector = new SentimentDetector();
        }

        public void Initialize(string name)
        {
            outputAction($"Welcome, {AppState.UserName}! I'm your Cybersecurity Awareness Assistant.");
            outputAction("Ask me anything about staying safe online. Here are some examples:");
            outputAction("- How are you?\n- What's your purpose?\n- What can I ask you about?");
            outputAction("- Tell me about password safety\n- What is phishing?\n- How do I browse safely?");
            outputAction("- What is malware?\n- What should I do if I'm hacked?\n- What is a firewall?");
            outputAction("- Why are software updates important?\n- How do I create a strong password?");
            outputAction("Type 'exit' or 'quit' to end the chat.");
        }

        public void ProcessInput(string userInput)
        {
            if (string.IsNullOrWhiteSpace(userInput))
            {
                outputAction("Please enter something for me to respond to!");
                return;
            }

            memory.AddPastQuestion(userInput);
            string sentiment = sentimentDetector.DetectSentiment(userInput);
            AdjustTone(sentiment);

            switch (userInput.ToLower())
            {
                case "how are you?":
                    outputAction("I'm fully patched and running smoothly! 😉 Always on guard to keep you safe!");
                    break;

                case "what's your purpose?":
                    outputAction("I'm here to empower you with cybersecurity knowledge and help you protect your digital world from threats.");
                    break;

                case "what can i ask you about?":
                    outputAction("You can ask me:\n- How are you?\n- Tell me about password safety\n- What is phishing?\n- How do I browse safely?\n" +
                        "- What is malware?\n- What should I do if I'm hacked?\n- What is a firewall?\n- Why are software updates important?\n- How do I create a strong password?");
                    break;

                case "tell me about password safety":
                    outputAction("Passwords should be long and complex — at least 12 characters. Use numbers, symbols, and upper/lowercase letters. Avoid personal info like birthdays.");
                    ShowRandomCyberTip();
                    break;

                case "what is phishing?":
                    outputAction("Phishing is a cyberattack where criminals pretend to be trustworthy sources to steal your personal info. Always double-check links and emails before clicking.");
                    ShowRandomCyberTip();
                    break;

                case "how do i browse safely?":
                    outputAction("Use trusted websites, look for 'https' in the URL, and avoid downloading files or clicking popups from unknown sources. Also, use privacy-focused browsers when possible.");
                    ShowRandomCyberTip();
                    break;

                case "what is malware?":
                    outputAction("Malware is any software designed to harm your computer or steal your data. It includes viruses, spyware, trojans, and more. Keep your antivirus up to date!");
                    ShowRandomCyberTip();
                    break;

                case "what should i do if i'm hacked?":
                    outputAction("Change your passwords immediately, enable two-factor authentication, and scan your devices with security software. Alert your bank or contacts if needed.");
                    ShowRandomCyberTip();
                    break;

                case "what is a firewall?":
                    outputAction("A firewall acts like a digital security guard — it monitors incoming and outgoing network traffic and blocks threats before they reach you.");
                    ShowRandomCyberTip();
                    break;

                case "why are software updates important?":
                    outputAction("Updates often include patches for new security holes. If you delay them, hackers can exploit those weaknesses to gain access to your data.");
                    ShowRandomCyberTip();
                    break;

                case "how do i create a strong password?":
                    outputAction("Use a mix of letters, numbers, and symbols. Avoid dictionary words. For example: 'B3@chW4lker!2025'. Also, use a password manager to keep track.");
                    ShowRandomCyberTip();
                    break;

                case "thanks":
                case "thank you":
                    outputAction($"You’re absolutely welcome, {AppState.UserName}! Happy to help you anytime :)");
                    break;

                case "show memory":
                case "show summary":
                case "what have we talked about?":
                    memory.ShowMemorySummary(AppState.UserName, outputAction);
                    break;

                case "exit":
                case "quit":
                    outputAction($"Stay safe out there, {AppState.UserName}! Goodbye.");
                    break;

                default:
                    if (keywordResponder.TryGetResponse(userInput, out string keywordResponse, out string matchedKeyword))
                    {
                        if (memory.HasDiscussed(matchedKeyword))
                        {
                            outputAction($"Hey {AppState.UserName}, we've already touched on '{matchedKeyword}' — but here's something else on it:");
                        }
                        else
                        {
                            outputAction($"Let's explore something new: '{matchedKeyword}'.");
                            memory.RememberTopic(matchedKeyword);
                        }

                        currentTopic = matchedKeyword;
                        outputAction(keywordResponse);
                        ShowRandomCyberTip();
                    }
                    else if (IsFollowUp(userInput) && !string.IsNullOrEmpty(currentTopic))
                    {
                        string followUpResponse = keywordResponder.GetFollowUpResponse(currentTopic);
                        outputAction(followUpResponse);
                        ShowRandomCyberTip();
                    }
                    else
                    {
                        outputAction("I'm sorry I didn’t quite understand that. Could you rephrase or try a different question?");
                    }
                    break;
            }
        }

        private void ShowRandomCyberTip()
        {
            string[] tips = {
                "Tip: Always use 2-factor authentication on your accounts.",
                "Tip: Never reuse the same password across sites.",
                "Tip: Watch out for fake giveaways on social media.",
                "Tip: Use antivirus software and keep it up to date.",
                "Tip: Don’t plug in unknown USB devices — they can carry malware!",
                "Tip: Regularly back up your data in case of ransomware attacks.",
                "Tip: Think before you click — even on social media links.",
            };

            Random rnd = new Random();
            int index = rnd.Next(tips.Length);
            outputAction(tips[index]);
        }

        private void AdjustTone(string sentiment)
        {
            switch (sentiment)
            {
                case "frustrated":
                    outputAction("I sense some frustration — I’m here to help! Let’s break it down simply.");
                    break;
                case "confused":
                    outputAction("It’s okay to feel confused. Let me explain it as clearly as possible.");
                    break;
                case "grateful":
                    outputAction("You’re most welcome! Happy to help anytime :)");
                    break;
                case "help":
                    outputAction("I’m right here with you. Tell me what you need and I’ll do my best to guide you.");
                    break;
            }
        }

        private bool IsFollowUp(string input)
        {
            string[] followUps = new string[]
            {
                "tell me more", "what else", "how", "more info", "next", "continue",
                "why", "details", "more", "you sure", "can you explain"
            };

            foreach (var phrase in followUps)
            {
                if (input.Contains(phrase, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }

            return false;
        }
    }
}


/* REFERENCES
 * CISA (Cybersecurity and Infrastructure Security Agency) (n.d.) Cybersecurity Best Practices. Available at: https://www.cisa.gov/topics/cybersecurity-best-practices (Accessed: 14 May 2025).
 * Norton (2025) Phishing protection: 11 tips to protect yourself from phishing. Available at: https://us.norton.com/blog/how-to/how-to-protect-against-phishing (Accessed: 15 May 2025).
 * Ofcom (2025) Guide for services: complying with the Online Safety Act. Available at: https://www.ofcom.org.uk/online-safety/illegal-and-harmful-content/guide-for-services (Accessed: 16 May 2025).
 * SHI (2023) 10 best practices for building an effective security awareness program. Available at: https://blog.shi.com/cybersecurity/security-awareness-training-best-practices/ (Accessed: 17 May 2025).
 * Kaspersky (n.d.) Phishing Scams & Attacks - How to Protect Yourself. Available at: https://www.kaspersky.com/resource-center/preemptive-safety/phishing-prevention-tips (Accessed: 18 May 2025).
 * National Cyber Security Centre (NCSC). (2022) Phishing attacks: defending your organisation. Available at: https://www.ncsc.gov.uk/guidance/phishing (Accessed: 21 May 2025).
 * Stay Safe Online. (2023) Creating a strong password. Available at: https://staysafeonline.org/stay-safe-online/securing-key-accounts-devices/passwords/ (Accessed: 23 May 2025).
 * Cybersecurity & Infrastructure Security Agency (CISA). (2023) Recognizing and avoiding phishing scams. Available at: https://www.cisa.gov/news-events/news/recognizing-and-avoiding-phishing-scams (Accessed: 22 May 2025).
 * IBM Security. (2021) What is malware? Available at: https://www.ibm.com/topics/malware (Accessed: 25 May 2025).
 * NortonLifeLock. (2023) What is a firewall and why is it important? Available at: https://us.norton.com/blog/how-to/what-is-a-firewall (Accessed: 20 May 2025).
 * European Union Agency for Cybersecurity (ENISA). (2022) Cyber hygiene practices. Available at: https://www.enisa.europa.eu/topics/cyber-hygiene (Accessed: 24 May 2025).
 * Microsoft. (2023) The importance of software updates. Available at: https://support.microsoft.com/en-us/windows/update-windows (Accessed: 21 May 2025).
 */