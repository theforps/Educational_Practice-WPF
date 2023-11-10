using educational_practice.data.repos;
using educational_practice.models;
using educational_practice.scripts;
using System.Windows;
using System.Windows.Controls;

namespace educational_practice.windows
{
    public partial class MainMenu : Window
    {
        private BaseRepository db;

        public MainMenu()
        {
            InitializeComponent();

            db = new BaseRepository();

            FillMenu();
        }

        private void FillMenu()
        {
            User user = db.getUserById(Consts.ID_CURRENT_USER);
            TitleBar.Text = user.Name + " " + user.Surname;

            if (user.Role.Name.Equals("user"))
            {
                AddNewOrderBut.Visibility = Visibility.Visible;
                Orders.ItemsSource = db.getInvoicesByClient(user.Id);
            }
            else if (user.Role.Name.Equals("executor"))
            {
                Orders.ItemsSource = db.getInvoicesByExecutor(user.Id);
            }
            else if (user.Role.Name.Equals("manager"))
            {
                State1.Visibility = Visibility.Visible;
                State2.Visibility = Visibility.Visible;

                CompletedCount.Text = db.completedInvoices().ToString();
                AvgCompleted.Text = db.avgExecution().ToString();
                Orders.ItemsSource = db.getAllInvoices();
            }
        }

        private void SearchOrder(object sender, RoutedEventArgs e)
        {
            int id; 
            
            if(int.TryParse(Search.Text, out id))
            {
                var orders = db.getInvoicesById(id);

                Orders.ItemsSource = orders;
            }
            else
            {
                MessageBox.Show("Не найдено");
            }
        }

        private void Info(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            Invoice choosenInvoice = (Invoice)button.DataContext;

            if (choosenInvoice != null)
            {
                Buttons.Back(this, new OrderInfo(choosenInvoice.Id));
            }
        }

        private void AddOrder(object sender, RoutedEventArgs e)
        {
            Buttons.Back(this, new AddOrder());
        }
        private void Exit(object sender, RoutedEventArgs e)
        {
            Buttons.Exit(this);
        }

        private void SignOut(object sender, RoutedEventArgs e)
        {
            Buttons.SignOut(this, new Login());
        }
    }
}
