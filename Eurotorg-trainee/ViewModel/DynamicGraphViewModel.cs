using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

using Eurotorg_trainee.Intefaces;
using Eurotorg_trainee.Models;

namespace Eurotorg_trainee.ViewModel
{
    public class DynamicGraphViewModel : NotifyPropertyChanged
    {
        private IExRatesAPI DynamicsAPI { get; }

        private List<Dynamics> _dynamicsList;
        private Point _panOffset = new Point(0, 100000);
        private Size _zoom = new Size(3, 1);

        public DynamicGraphViewModel(IExRatesAPI dynamicApi)
        {
            DynamicsAPI = dynamicApi;
        }

        public List<Dynamics> DynamicsList
        {
            get => _dynamicsList;
            set => SetProperty(ref _dynamicsList, value);
        }

        public Point PanOffset
        {
            get => _panOffset;
            set => SetProperty(ref _panOffset, value);
        }

        public Size Zoom
        {
            get => _zoom;
            set => SetProperty(ref _zoom, value);
        }

        public async ValueTask GetDynamicsInfoAsync(int id, DateTime date)
        {
            _dynamicsList = null;
            var dynamicsFromApi = await DynamicsAPI.GetDynamics(id, date).ConfigureAwait(false);
            DynamicsList = dynamicsFromApi.ToList();
        }
    }
}
