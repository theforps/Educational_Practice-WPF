using educational_practice.data;
using educational_practice.models;
using educational_practice.scripts;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace educational_practice.windows
{
    public partial class MainMenu : Window
    {
        CRUD crud = new CRUD();

        public MainMenu()
        {
            InitializeComponent();

            var user = crud.getUserById(Consts.ID_CURRENT_USER);
            TitleBar.Text = user.Name.ToUpper();

            if (user.Roles == Roles.USER.ToString())
            {
                AddNewOrderBut.Visibility = Visibility.Visible;
                Orders.ItemsSource = crud.getOrders().Where(x => x.idUser == user.Id);
            }
            else if (user.Roles == Roles.EXECUTOR.ToString())
            {
                Orders.ItemsSource = crud.getOrders().Where(x => x.idExecuter == user.Id);
            }
            else if (user.Roles == Roles.MANAGER.ToString())
            {
                Orders.ItemsSource = crud.getOrders();
            }
        }

        private void SearchOrder(object sender, RoutedEventArgs e)
        {
            var orders = crud.getOrdersByParam(Search.Text.ToLower());

            Orders.ItemsSource = orders;
        }

        private void Info(object sender, RoutedEventArgs e)
        {
            var selectedOrder = (Order)Orders.SelectedItem;

            if (selectedOrder != null)
            {
                Buttons.Back(this, new OrderInfo(selectedOrder.Id));
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
