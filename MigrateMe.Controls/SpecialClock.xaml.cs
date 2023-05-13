using System;
using System.Windows.Controls;
using System.Windows.Threading;

namespace MigrateMe.Controls
{
    public partial class SpecialClock : UserControl
    {
        public SpecialClock()
        {
            InitializeComponent();
            DispatcherTimer timer = new DispatcherTimer();
            timer.Tick += Timer_Tick;
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            txtClock.Text = DateTime.Now.ToLongTimeString();
        }
    }
}