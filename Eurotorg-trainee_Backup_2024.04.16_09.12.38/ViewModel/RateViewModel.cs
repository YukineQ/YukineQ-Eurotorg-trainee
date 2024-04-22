using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using Eurotorg_trainee.Intefaces;
using Eurotorg_trainee.Models;
using Eurotorg_trainee.Service;

namespace Eurotorg_trainee.ViewModel
{
    public class RateViewModel : NotifyPropertyChanged
    {
        ExRatesAPI rateAPI = new ExRatesAPI();

        private List<Rate> _rateList;

        public List<Rate> RateList
        {
            get => _rateList;
            set => SetProperty(ref _rateList, value);
        }

        public async ValueTask GetRatesInfoAsync()
        {
                _rateList = null;
                RateList = (List<Rate>)await rateAPI.GetRatesList().ConfigureAwait(false);
        }
    }
}
