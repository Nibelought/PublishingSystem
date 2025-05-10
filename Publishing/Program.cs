using Publishing;
using System;
using System.Windows.Forms;

namespace PublishingSystem.UI
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new LoginForm());
        }
    }
}