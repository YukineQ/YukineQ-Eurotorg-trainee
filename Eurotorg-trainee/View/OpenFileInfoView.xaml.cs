using System.Windows.Controls;

using Eurotorg_trainee.ViewModel;

namespace Eurotorg_trainee.View
{
    /// <summary>
    /// Логика взаимодействия для OpenFileInfoView.xaml
    /// </summary>
    public partial class OpenFileInfoView : UserControl
    {
        public OpenFileInfoView()
        {
            InitializeComponent();
            DataContext = App.Container.GetService<OpenFileInfoViewModel>();
        }
    }
}
