using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Eurotorg_trainee.Intefaces;

namespace Eurotorg_trainee.ViewModel
{
    public class MainViewModel
    {
        private IEnumerable<ICommandBinding> CommandBindings { get; }

        public MainViewModel(
            IEnumerable<ICommandBinding> commandBindings
        )
        {
            CommandBindings = commandBindings;
        }
        
        public void Initialize(Window window)
        {
            window.CommandBindings.AddRange(CommandBindings.Select(cb => cb.CommandBinding()).ToArray());   
        }
    }
}
