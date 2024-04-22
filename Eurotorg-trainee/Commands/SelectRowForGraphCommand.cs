using System;
using System.Windows.Input;
using Telerik.Windows.Controls;

using Eurotorg_trainee.Intefaces;
using Eurotorg_trainee.Models;
using Eurotorg_trainee.ViewModel;
using Eurotorg_trainee.Service;

namespace Eurotorg_trainee.Commands
{
    public class SelectRowForGraphCommand : ICommandBinding
    {
        public static readonly RoutedCommand Command = new RoutedUICommand();

        private DynamicGraphViewModel GraphViewModel { get; }

        public SelectRowForGraphCommand(DynamicGraphViewModel graphViewModel)
        {
            GraphViewModel = graphViewModel;
        }

        public CommandBinding CommandBinding()
        {
            return new CommandBinding(Command, CommandHandler);
        }

        private async void CommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            try
            {
                var addetItems = (e.Parameter as SelectionChangeEventArgs).AddedItems;
                var lastSelected = addetItems[0] as Rate;
                await GraphViewModel.GetDynamicsInfoAsync(lastSelected.ID, lastSelected.Date);
            }
            catch (Exception ex)
            {
                TraceService.Message(ex.Message);
            }
        }
    }
}
