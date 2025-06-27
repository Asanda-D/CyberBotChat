using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberBotChat.Modules
{
    public class SentimentDetector
    {
        private readonly Dictionary<string, string> sentimentKeywords;

        public SentimentDetector()
        {
            sentimentKeywords = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
            {
                { "angry", "frustrated" }, { "upset", "frustrated" }, { "annoyed", "frustrated" }, { "hate", "frustrated" },
                { "confused", "confused" }, { "don’t get it", "confused" }, { "lost", "confused" },
                { "thank you", "grateful" }, { "thank", "grateful" }, { "appreciate", "grateful" },
                { "help", "help" }, { "urgent", "help" }, { "please", "help" }
            };
        }//end of SentimentDetector()

        public string DetectSentiment(string input)
        {
            foreach (var pair in sentimentKeywords)
            {
                if (input.Contains(pair.Key, StringComparison.OrdinalIgnoreCase))
                {
                    return pair.Value;
                }
            }

            return "neutral";

        }//end of DetectSentiment()

    }//end of SentimentDetector class

}//end of namespace
