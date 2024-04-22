using System;
using System.Windows.Input;

using Eurotorg_trainee.Intefaces;
using Eurotorg_trainee.ViewModel;

namespace Eurotorg_trainee.Commands
{
    public class GetRatesForDateCommand : ICommandBinding
    {
        public static readonly RoutedCommand Command = new RoutedUICommand();
        private RateViewModel RateViewModel { get; }
        private DatePickerModelView DatePickerModelView { get; }
        private IMessageBoxService MessageBoxService { get; } 

        private bool inCommand;

        public GetRatesForDateCommand(
            RateViewModel rateViewModel, 
            DatePickerModelView datePickerModelView,
            IMessageBoxService messageBoxService
        )
        {
            RateViewModel = rateViewModel;
            DatePickerModelView = datePickerModelView;
            MessageBoxService = messageBoxService;
        }

        public CommandBinding CommandBinding()
        {
            return new CommandBinding(Command, CommandHandler);
        }

        private async void CommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            if (inCommand) return;

            try
            {
                inCommand = true;

                var onDate = DatePickerModelView.OnDate;
                await RateViewModel.GetRatesFromApiAsync(onDate).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                await MessageBoxService.ShowMessageBoxAsync(ex.Message);
            }
            finally
            {
                inCommand = false;
            }
        }
    }
}
