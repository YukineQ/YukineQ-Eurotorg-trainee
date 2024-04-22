using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

using Eurotorg_trainee.Intefaces;
using Eurotorg_trainee.Service;
using Eurotorg_trainee.ViewModel;

namespace Eurotorg_trainee.Commands
{
    public class SaveToJsonCommand : ICommandBinding
    {
        public static readonly RoutedCommand Command = new RoutedUICommand();

        private RateViewModel RateViewModel { get; }
        private IDialogService DialogService { get; }
        private IMessageBoxService MessageBoxService { get; }

        public SaveToJsonCommand(
            RateViewModel rateViewModel, 
            IDialogService dialogService,
            IMessageBoxService messageBoxService)
        {
            RateViewModel = rateViewModel;
            DialogService = dialogService;
            MessageBoxService = messageBoxService;
        }

        public CommandBinding CommandBinding()
        {
            return new CommandBinding(Command, CommandHandler);
        }

        private async void CommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            try
            {
                var fileNameFromParameter = (string)e.Parameter;
                var fileName = fileNameFromParameter ?? DialogService.GetFileNameToSave();
                await SaveToJson(fileName);
            }
            catch (Exception ex)
            {
                await MessageBoxService.ShowMessageBoxAsync(ex.Message);
            }
        }

        private async ValueTask SaveToJson(string fileName)
        {
            var data = RateViewModel.RateList.ToList();
            await JsonFileService.WriteJson(data, fileName);
        }
    }
}
