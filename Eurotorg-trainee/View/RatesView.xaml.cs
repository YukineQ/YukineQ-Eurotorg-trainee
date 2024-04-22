using System;
using System.Windows;
using System.Windows.Controls;

using Eurotorg_trainee.ViewModel;

namespace Eurotorg_trainee.View
{
    /// <summary>
    /// Логика взаимодействия для RatesView.xaml
    /// </summary>
    public partial class RatesView : UserControl
    {
        public RatesView()
        {
            DataContext = App.Container.GetService<RateViewModel>();
            InitializeComponent();
            Loaded += OnLoad;
        }

        private async void OnLoad(object sender, RoutedEventArgs e)
        {
            if (DataContext is RateViewModel vm)
            {
                await vm.GetRatesFromApiAsync(DateTime.Now).ConfigureAwait(false);
            }
        }
    }
}
