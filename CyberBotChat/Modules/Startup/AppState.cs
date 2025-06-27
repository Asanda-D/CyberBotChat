using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberBotChat.Modules.Startup
{
    public static class AppState
    {
        public static string UserName { get; set; } = "User"; // Default fallback

        // This delegate allows any view to subscribe to navigation requests
        public static Action<string> NavigationRequested;
    }
}