using Eurotorg_trainee.Service;
using System.Windows;

namespace Eurotorg_trainee
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static Container Container { get; } = new Container();

        public App(){}

        private void ApplicationStartup(object sender, StartupEventArgs e)
        {
            Container.GetService<MainWindow>().Show();
        }
    }
}
