using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberBotChat.Modules
{
    public class TopicManager
    {
        public string CurrentTopic { get; private set; }

        public void UpdateTopic(string topic)
        {
            CurrentTopic = topic;
        }

        public void ClearTopic()
        {
            CurrentTopic = null;
        }

        public bool HasCurrentTopic()
        {
            return !string.IsNullOrWhiteSpace(CurrentTopic);
        }

    }//end of class TopicManager

}//end of namespace
