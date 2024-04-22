using System;
using System.Windows;

using Eurotorg_trainee.ViewModel;

namespace Eurotorg_trainee
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            DataContext = App.Container.GetService<MainViewModel>();
            InitializeComponent();
        }

        private MainViewModel ViewModel => (MainViewModel)DataContext;

        protected override void OnSourceInitialized(EventArgs e)
        {
            ViewModel.Initialize(this);
            base.OnSourceInitialized(e);
        }
    }
}
