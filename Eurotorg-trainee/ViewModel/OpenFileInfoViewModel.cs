using System.Windows;

using Eurotorg_trainee.Helpers;
using Eurotorg_trainee.Intefaces;

namespace Eurotorg_trainee.ViewModel
{
    public class OpenFileInfoViewModel : NotifyPropertyChanged
    {
        private string _openFileName;

        public string OpenFileName
        {
            get => _openFileName;
            set => SetProperty(ref _openFileName, value);
        }

        private Visibility _visibility = Visibility.Collapsed;

        public Visibility Visibility
        {
            get => _visibility;
            set => SetProperty(ref _visibility, value);
        }

        private SourceService SourceService { get; }

        public OpenFileInfoViewModel(SourceService sourceService)
        {
            SourceService = sourceService;
            SourceService.OnChange += SourceChanged;
        }

        private void SourceChanged(object sender, MessageArgument<Source> e)
        {
            var source = e.Message;
            if (source.SourceType == SourceTypes.File)
            {
                OpenFileName = e.Message.FileName;
                Visibility = Visibility.Visible;
                return;
            }
            Visibility = Visibility.Collapsed;
            OpenFileName = null;
        }
    }
}
