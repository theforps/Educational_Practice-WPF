using educational_practice.windows;
using System;
using System.Windows;
using System.Windows.Navigation;
using System.Windows.Threading;

namespace educational_practice
{
    public partial class Intro : Window
    {

        DispatcherTimer timer = new DispatcherTimer();

        public Intro()
        {
            InitializeComponent();

            timer.Interval = new System.TimeSpan(0, 0, 2);

            timer.Tick += new EventHandler(introStop);

            timer.Start();
        }

        private void introStop(object obj, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
            timer.Stop();
        }


    }
}
