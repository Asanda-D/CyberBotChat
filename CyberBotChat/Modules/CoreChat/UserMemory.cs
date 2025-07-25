﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberBotChat.Modules
{
    // Stores user memory such as discussed topics, past questions, and interest patterns.

    public class UserMemory
    {
        private readonly HashSet<string> discussedTopics = new(StringComparer.OrdinalIgnoreCase);
        private readonly List<string> pastQuestions = new();
        private readonly Dictionary<string, int> interestScores = new(StringComparer.OrdinalIgnoreCase);

        // Adds a topic to memory and increases its interest score.

        public void RememberTopic(string topic)
        {
            discussedTopics.Add(topic);

            if (interestScores.ContainsKey(topic))
                interestScores[topic]++;
            else
                interestScores[topic] = 1;
        }

        // Checks if the topic has already been discussed.

        public bool HasDiscussed(string topic)
        {
            return discussedTopics.Contains(topic);
        }

        // Saves a user question to memory.

        public void AddPastQuestion(string question)
        {
            pastQuestions.Add(question);
        }

        // Returns the full list of questions the user has asked.

        public IEnumerable<string> GetPastQuestions()
        {
            return pastQuestions;
        }

        // Displays a summary of all discussed topics and asked questions using a delegate.

        public void ShowMemorySummary(string userName, Action<string> output)
        {
            output($"\nCyberlock: Here's what we've covered so far, {userName}:");

            if (discussedTopics.Count == 0)
            {
                output("- We haven’t really talked about any topics yet.");
            }
            else
            {
                output("- Topics we've covered:");
                foreach (var topic in discussedTopics)
                {
                    output($"  • {topic}");
                }
            }

            if (pastQuestions.Count == 0)
            {
                output("- No specific questions from you have been saved.");
            }
            else
            {
                output("- Questions you've asked:");
                foreach (var question in pastQuestions)
                {
                    output($"  • {question}");
                }
            }

            var topInterests = GetTopInterests(3);
            if (topInterests.Count > 0)
            {
                output("- Based on our chats, you're most interested in:");
                foreach (var (topic, score) in topInterests)
                {
                    output($"  • {topic} (mentioned {score} times)");
                }
            }
        }

        // Returns the most discussed topics with the highest interest scores.

        public List<KeyValuePair<string, int>> GetTopInterests(int count)
        {
            return interestScores
                .OrderByDescending(kvp => kvp.Value)
                .Take(count)
                .ToList();
        }
    }
}