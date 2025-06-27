using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberBotChat.Modules.CoreChat
{
    public static class IntentDetector
    {
        public static string DetectIntent(string input)
        {
            string lowered = input.ToLower();

            if (lowered.Contains("add task") || lowered.Contains("task") || lowered.Contains("create task") || lowered.Contains("make task") || lowered.Contains("set reminder") || lowered.Contains("reminder"))
                return "add_task";

            if (lowered.Contains("quiz") || lowered.Contains("start quiz") || lowered.Contains("take quiz") || lowered.Contains("test"))
                return "start_quiz";

            return "unknown";
        }
    }
}
