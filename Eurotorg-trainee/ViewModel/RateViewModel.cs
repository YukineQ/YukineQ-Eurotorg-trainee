using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

using Eurotorg_trainee.Helpers;
using Eurotorg_trainee.Intefaces;
using Eurotorg_trainee.Models;
using Eurotorg_trainee.Service;

namespace Eurotorg_trainee.ViewModel
{
    public class RateViewModel : NotifyPropertyChanged
    {
        private IExRatesAPI RateAPI { get; }
        private SourceService SourceService { get; }

        private bool _isReadOnly = true;

        public bool IsReadOnly
        {
            get => _isReadOnly;
            set => SetProperty(ref _isReadOnly, value);
        }

        private ObservableCollection<Rate> _rateList;

        public ObservableCollection<Rate> RateList
        {
            get => _rateList;
            set => SetProperty(ref _rateList, value);
        }

        public RateViewModel(SourceService sourceService, IExRatesAPI ratesAPI)
        {
            SourceService = sourceService;
            RateAPI = ratesAPI;
            SourceService.OnChange += SourceChanged;
        }

        public async ValueTask GetRatesFromApiAsync(DateTime date)
        {
            _rateList = null;
            var ratesFromApi = await RateAPI.GetRatesList(date).ConfigureAwait(false);
            RateList = new ObservableCollection<Rate>(ratesFromApi);
            SourceService.ChangeSource(new Source(SourceTypes.Api, null));
        }

        public async ValueTask GetRatesFromFileAsync(string filePath)
        {
            var dataFromFile = await JsonFileService.ReadFromJson<Rate[]>(filePath);
            RateList = new ObservableCollection<Rate>(dataFromFile);
            SourceService.ChangeSource(new Source(SourceTypes.File, filePath));
        }

        private void SourceChanged(object sender, MessageArgument<Source> e)
        {
            if(e.Message.SourceType == SourceTypes.Api)
            {
                IsReadOnly = true;
                return;
            }
            IsReadOnly = false;
        }
    }
}
