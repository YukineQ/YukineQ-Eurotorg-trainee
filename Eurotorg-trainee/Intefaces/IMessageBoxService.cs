using System.Threading.Tasks;

namespace Eurotorg_trainee.Intefaces
{
    public interface IMessageBoxService
    {
        void ShowMessageBox(string message);

        ValueTask ShowMessageBoxAsync(string message);
    }
}
