using Eurotorg_trainee.Service;

namespace Eurotorg_trainee.Intefaces
{
    public interface IDialogService
    {
        string GetFileNameToSave(Filters filter = Filters.Json);

        string GetFileNameToOpen(Filters filter = Filters.Json);
    }
}
