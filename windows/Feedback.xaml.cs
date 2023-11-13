using educational_practice.scripts;
using System.Windows;

namespace educational_practice.windows
{

    public partial class Feedback : Window
    {
        public Feedback()
        {
            InitializeComponent();
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            Buttons.Exit(this);
        }
    }
}
