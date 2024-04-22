using Eurotorg_trainee.ViewModel;
using System.Windows;

namespace Eurotorg_trainee
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            DataContext = App.Container.GetService<RateViewModel>();
            InitializeComponent();
            Loaded += OnLoad;
        }

        private async void OnLoad(object sender, RoutedEventArgs e)
        {
                if (DataContext is RateViewModel vm)
                {
                    await vm.GetRatesInfoAsync().ConfigureAwait(false);
                }
        }
    }
}
