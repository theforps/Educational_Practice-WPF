using educational_practice.data;
using educational_practice.models;
using System.Linq;
using System.Windows;

namespace educational_practice.windows
{
    public partial class MainMenu : Window
    {
        CRUD crud = new CRUD();

        public MainMenu()
        {
            InitializeComponent();

            var user = crud.getUserById(db.idOfUser);
            Title.Text = user.Name.ToUpper();

            if (user.Roles == Roles.USER.ToString()) {
                AddNewOrderBut.Visibility = Visibility.Visible;
            }

            if(user.Roles == Roles.USER.ToString())
                Orders.ItemsSource = crud.getOrders().Where(x => x.idUser == user.Id);
            else if(user.Roles == Roles.EXECUTOR.ToString())
                Orders.ItemsSource = crud.getOrders().Where(x => x.idExecuter == user.Id);
            else if(user.Roles == Roles.MANAGER.ToString())
                Orders.ItemsSource = crud.getOrders();  
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SignOut(object sender, RoutedEventArgs e)
        {
            db.idOfUser = -1;

            Login login = new Login();
            login.Show();
            this.Close();
        }

        private void SearchOrder(object sender, RoutedEventArgs e)
        {
            var orders = crud.getOrdersByParam(Search.Text.ToLower());

            Orders.ItemsSource = orders;
        }

        private void AddOrder(object sender, RoutedEventArgs e)
        {
            AddOrder addOrder = new AddOrder();
            addOrder.Show();
            this.Close();
        }

        private void Info(object sender, RoutedEventArgs e)
        {
            var selectedOrder = (Order)Orders.SelectedItem;

            if (selectedOrder != null)
            {
                OrderInfo info = new OrderInfo(selectedOrder.Id);
                info.Show();
                this.Close();
            }
        }
    }
}
