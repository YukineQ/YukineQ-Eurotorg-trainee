using System.Threading.Tasks;
using System.Windows;

using Eurotorg_trainee.Intefaces;

namespace Eurotorg_trainee.Service
{
    public class MessageBoxService : IMessageBoxService
    {
        public void ShowMessageBox(string message)
        {
            var caption = App.GetString("title");
            Application.Current.Dispatcher.Invoke(() => MessageBox.Show(message, caption, MessageBoxButton.OK));
        }

        public async ValueTask ShowMessageBoxAsync(string message)
        {
            await Task.Run(() => ShowMessageBox(message));
        }
    }
}
