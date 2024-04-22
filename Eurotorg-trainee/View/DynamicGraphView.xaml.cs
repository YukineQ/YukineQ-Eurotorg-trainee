using System.Windows.Controls;
using Telerik.Windows.Controls.ChartView;

using Eurotorg_trainee.Models;
using Eurotorg_trainee.ViewModel;

namespace Eurotorg_trainee.View
{
    /// <summary>
    /// Логика взаимодействия для DynamicGraphView.xaml
    /// </summary>
    public partial class DynamicGraphView : UserControl
    {
        public DynamicGraphView()
        {
            DataContext = App.Container.GetService<DynamicGraphViewModel>();
            InitializeComponent();
        }

        private void ChartTrackBallBehavior_TrackInfoUpdated(object sender, TrackBallInfoEventArgs e)
        {
            DataPointInfo closestDataPoint = e.Context.ClosestDataPoint;
            if (closestDataPoint != null)
            {
                Dynamics data = closestDataPoint.DataPoint.DataItem as Dynamics;
                this.date.Text = data.Date.ToString("MMM dd, yyyy");
                this.price.Text = data.OfficialRate.ToString("0,0.00");
            }
        }
    }
}
