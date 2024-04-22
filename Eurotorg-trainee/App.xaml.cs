using System;
using System.Windows;
using Telerik.Windows.Controls;

using Eurotorg_trainee.Service;

namespace Eurotorg_trainee
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static Container Container { get; } = new Container();

        private void ApplicationStartup(object sender, StartupEventArgs e)
        {
            Container.GetService<MainWindow>().Show();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            StyleManager.ApplicationTheme = new Windows11Theme();
        }

        public static string GetString(string resourceName)
        {
            return Current.FindResource(resourceName) as string ?? throw new InvalidOperationException();
        }
    }
}
