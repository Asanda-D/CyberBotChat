using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberBotChat.Modules
{
    public class KeywordResponder
    {
        private readonly Dictionary<string, List<string>> keywordResponses;
        private readonly Random random;

        public KeywordResponder()
        {
            random = new Random();
            keywordResponses = SeedKeywordResponses();
        }

        private Dictionary<string, List<string>> SeedKeywordResponses()
        {
            return new Dictionary<string, List<string>>(StringComparer.OrdinalIgnoreCase)
            {
                {
                    "password", new List<string>
                    {
                        "Use long, complex passwords and don’t reuse them.",
                        "Avoid personal information in passwords like your name or birthdate.",
                        "Consider using a password manager for better security."
                    }
                },
                {
                    "phishing", new List<string>
                    {
                        "Phishing emails often look legitimate. Always double-check the sender’s address.",
                        "Avoid clicking suspicious links or downloading attachments from unknown sources.",
                        "Report phishing attempts to your service provider or company IT team."
                    }
                },
                {
                    "scam", new List<string>
                    {
                        "Online scams come in many forms — never share your OTP or password with anyone.",
                        "If something seems too good to be true, it usually is.",
                        "Always verify unknown requests before responding."
                    }
                },
                {
                    "privacy", new List<string>
                    {
                        "Check app permissions regularly and disable those you don’t need.",
                        "Limit personal information shared on social media.",
                        "Use privacy-focused browsers or extensions when browsing the web."
                    }
                },
                {
                    "malware", new List<string>
                    {
                        "Keep your antivirus software updated regularly.",
                        "Avoid downloading software from untrusted websites.",
                        "Scan USB devices before using them on your PC."
                    }
                }

            };//return

        }//end of SeedKeywordResponses()

        public bool TryGetResponse(string userInput, out string response, out string matchedKeyword)
        {
            foreach (var entry in keywordResponses)
            {
                if (userInput.Contains(entry.Key, StringComparison.OrdinalIgnoreCase))
                {
                    var responses = entry.Value;
                    response = responses[random.Next(responses.Count)];
                    matchedKeyword = entry.Key;
                    return true;
                }
            }

            response = null;
            matchedKeyword = null;
            return false;

        }//end of TryGetResponse()

        public string GetFollowUpResponse(string keyword)
        {
            return keyword.ToLower() switch
            {
                "password" => "Using a password manager can make managing strong passwords much easier and more secure.",
                "phishing" => "Be cautious of emails that create urgency, like 'Your account will be locked!' — that's a common phishing trick.",
                "scam" => "Scammers often impersonate companies you trust. Always verify by contacting the company directly.",
                "privacy" => "Consider using a VPN when connecting to public Wi-Fi to protect your personal information.",
                "malware" => "Ransomware is a dangerous type of malware. Regular backups can save you if your files are locked.",
                _ => "Let’s go deeper into that topic — what specifically do you want to know?"
            };

        }//end of GetFollowUpResponse()

    }//end of class KeywordResponder

}//end of namespace
