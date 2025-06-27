using System.Configuration;
using System.Data;
using System.Windows;
using CyberBotChat.Modules.Startup;
using CyberBotChat.Views;

namespace CyberBotChat
{
    // Interaction logic for App.xaml
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var startupWindow = new StartupWindow();
            startupWindow.ShowDialog(); // This will block until the window closes

            var mainWindow = new MainWindow();
            mainWindow.Show();
        }
    }
}

/* REFERENCES mainly used in part 1 & 2
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
 * Logic & Chaos(2023) Animate Text in C# Console Applications: A Step-by-Step Tutorial. Available at: https://logicandchaos.itch.io/endless-prose/devlog/488908/animate-text-in-c-console-applications-a-step-by-step-tutorial (Accessed: 19 May 2025).
 * Stack Overflow (2018) C# Write to console slowly. Available at: https://stackoverflow.com/questions/51370620/c-sharp-write-to-console-slowly (Accessed: 20 May 2025).
 * Stack Overflow (2021) Can it be possible to add delay in Console.WriteLine or in Console.ReadKey for hiding text for a few seconds?. Available at: https://stackoverflow.com/questions/66805849/can-it-be-possible-to-add-delay-in-console-writeline-or-in-console-readkey-for-h (Accessed: 14 May 2025).
 *Stack Overflow(2013) Text animation, creating typewriting-like effect in c#. Available at: https://stackoverflow.com/questions/18469061/text-animation-creating-typewriting-like-effect-in-c-sharp (Accessed: 15 May 2025).
 * Stack Overflow (2011) How Do You Simulate Typing in c#?. Available at: https://stackoverflow.com/questions/4959126/how-do-you-simulate-typing-in-c (Accessed: 16 May 2025).
 * Microsoft Learn. (2024) Use dictionaries to store data. Available at: https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/generics/dictionary-type (Accessed: 23 May 2025).
 *TutorialsTeacher. (2023) C# Dictionary (Key-Value Pair). Available at: https://www.tutorialsteacher.com/csharp/csharp-dictionary (Accessed: 22 May 2025).
 * GeeksforGeeks. (2023) Object - Oriented Programming in C#. Available at: https://www.geeksforgeeks.org/object-oriented-programming-in-c-sharp/ (Accessed: 25 May 2025).
 * Microsoft Docs. (2024) Accessing classes from another namespace in C#. Available at: https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/namespaces/ (Accessed: 20 May 2025).
 * Stack Overflow. (2019) Best way to implement typing effect in console application.Available at: https://stackoverflow.com/questions/1318933/typing-effect-in-c-sharp (Accessed: 24 May 2025).
 * Dot Net Perls. (2023) C# Switch Statement Examples. Available at: https://www.dotnetperls.com/switch (Accessed: 22 May 2025).
 * Code Maze. (2023) Dependency injection in C# console apps. Available at: https://code-maze.com/net-core-console-app-dependency-injection/ (Accessed: 25 May 2025).
 * C# Corner. (2022) How to Use Classes and Objects in C#. Available at: https://www.c-sharpcorner.com/UploadFile/mahesh/classes-and-objects-in-C-Sharp/ (Accessed: 21 May 2025).
 */

/* REFERENCES mainly used in part 3
 * Norton (2025) Phishing protection: 11 tips to protect yourself from phishing. Available at: https://us.norton.com/blog/how-to/how-to-protect-against-phishing (Accessed: 16 June 2025).
 * Microsoft Docs (2024) DialogHost class (MaterialDesignThemes.Wpf). Available at: https://github.com/MaterialDesignInXAML/MaterialDesignInXamlToolkit (Accessed: 17 June 2025).
 * Microsoft Learn (2024) WPF .NET 8 overview. Available at: https://learn.microsoft.com/en-us/dotnet/desktop/wpf/overview/?view=netdesktop-8.0 (Accessed: 18 June 2025).
 * UXPin (2024) UX Design Frameworks – What Are The Most Useful Ones?. Available at: https://www.uxpin.com/studio/blog/design-frameworks/ (Accessed: 19 June 2025).
 * GeeksforGeeks (2024) C# String Manipulation Techniques. Available at: https://www.geeksforgeeks.org/string-manipulation-in-c-sharp/ (Accessed: 20 June 2025).
 * FreeCodeCamp (2023) GitHub Actions Tutorial – Basic CI/CD Workflow. Available at: https://www.freecodecamp.org/news/github-actions-ci-cd-pipeline/ (Accessed: 21 June 2025).
 * Codecademy (2023) How to Handle User Input in C#. Available at: https://www.codecademy.com/learn/learn-c-sharp/modules/csharp-user-input (Accessed: 22 June 2025).
 * OWASP (2025) Top 10 Security Tips for Developers. Available at: https://owasp.org/www-project-top-ten/ (Accessed: 23 June 2025).
 * Cybernews (2025) What is NLP and How is it Used in Chatbots?. Available at: https://cybernews.com/security/natural-language-processing-chatbots/ (Accessed: 24 June 2025).
 * IBM (2024) Natural Language Processing (NLP) explained. Available at: https://www.ibm.com/cloud/learn/natural-language-processing (Accessed: 25 June 2025).
 * Material Design in XAML Toolkit (2025) Material Design Components and DialogHost. Available at: https://materialdesigninxaml.net (Accessed: 26 June 2025).
 * Baeldung (2023) C# Boolean Converters in WPF. Available at: https://www.baeldung.com/csharp/wpf-boolean-converter (Accessed: 15 June 2025).
 * Microsoft Learn (2024) INotifyPropertyChanged interface. Available at: https://learn.microsoft.com/en-us/dotnet/api/system.componentmodel.inotifypropertychanged (Accessed: 17 June 2025).
 * JetBrains (2023) Best Practices for Clean Code in C#. Available at: https://blog.jetbrains.com/dotnet/2023/07/clean-code-best-practices/ (Accessed: 18 June 2025).
 * DotnetCurry (2023) Logging in WPF Applications – Best Practices. Available at: https://www.dotnetcurry.com/wpf/1518/logging-wpf-application (Accessed: 19 June 2025).
 * GitHub Docs (2024) Understanding workflows in GitHub Actions. Available at: https://docs.github.com/en/actions/using-workflows/about-workflows (Accessed: 20 June 2025).
 * Stack Overflow (2024) How to use DialogHost with multiple windows in WPF?. Available at: https://stackoverflow.com/questions/39275498/how-to-use-dialoghost-materialdesign-with-multiple-windows (Accessed: 22 June 2025).
 */