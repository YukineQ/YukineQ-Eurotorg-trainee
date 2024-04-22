using Eurotorg_trainee.ViewModel;
using System.Windows.Controls;

namespace Eurotorg_trainee.View
{
    /// <summary>
    /// Логика взаимодействия для DatePickerView.xaml
    /// </summary>
    public partial class DatePickerView : UserControl
    {
        public DatePickerView()
        {
            InitializeComponent();
            DataContext = App.Container.GetService<DatePickerModelView>();
        }
    }
}
