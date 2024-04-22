using System;
using System.Windows.Input;

using Eurotorg_trainee.ViewModel;
using Eurotorg_trainee.Intefaces;

namespace Eurotorg_trainee.Commands
{
    public class ReadFromJsonCommand : ICommandBinding
    {
        public static readonly RoutedCommand Command = new RoutedUICommand();

        private RateViewModel RateViewModel { get; }
        private IDialogService DialogService { get; }
        private IMessageBoxService MessageBoxService { get; }

        public ReadFromJsonCommand(
            RateViewModel rateViewModel, 
            IDialogService dialogService,
            IMessageBoxService messageBoxService
        )
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
                var fileName = DialogService.GetFileNameToOpen();
                await RateViewModel.GetRatesFromFileAsync(fileName);
            }
            catch (Exception ex)
            {
                await MessageBoxService.ShowMessageBoxAsync(ex.Message);
            }
        }
    }
}
