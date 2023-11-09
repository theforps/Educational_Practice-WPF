using educational_practice.data.repos;
using educational_practice.scripts;
using educational_practice.windows;
using System;
using System.Windows;
using System.Windows.Threading;

namespace educational_practice
{
    public partial class Intro : Window
    {

        DispatcherTimer timer = new DispatcherTimer();

        public Intro()
        {
            InitializeComponent();

            timer.Interval = new TimeSpan(0, 0, 2);
            timer.Tick += new EventHandler(introStop);
            timer.Start();
        }

        private void introStop(object obj, EventArgs e)
        {
            Buttons.Back(this, new Login());

            timer.Stop();
        }


    }
}
