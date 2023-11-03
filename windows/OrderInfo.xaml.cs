using educational_practice.data;
using educational_practice.models;
using System.Windows;

namespace educational_practice.windows
{
    public partial class OrderInfo : Window
    {
        CRUD crud = new CRUD();
        Order order;

        public OrderInfo()
        {
            InitializeComponent();
        }

        public OrderInfo(int Id)
        {
            InitializeComponent();

            OrderNumber.Text = "Номер заявки " + Id.ToString();

            order = crud.getOrderById(Id);
            var client = crud.getUserById(order.idUser);
            var executor = crud.getUserById(order.idExecuter);
            var user = crud.getUserById(db.idOfUser);

            if (order != null)
            {
                Disc.Text = order.Description;
                Status.Text = order.Status;
                Date.Text = order.date.ToString();
                Model.Text = order.Model;
                Type.Text = order.Type;
                Client.Text = client.Name + " " + order.idUser;

                if(order.Comment != null)
                {
                    Comment.Text = order.Comment;
                }

                if (executor != null && executor.Roles == Roles.EXECUTOR.ToString())
                    Executor.Text = executor.Name + " " + executor.Id;
                else
                    Executor.Text = "Исполнитель не назначен";
            }

            if(user.Roles == Roles.EXECUTOR.ToString() || user.Roles == Roles.MANAGER.ToString())
                EditBut.Visibility = Visibility.Visible;
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            MainMenu mainMenu = new MainMenu();
            mainMenu.Show();
            this.Close();
        }

        private void SignOut(object sender, RoutedEventArgs e)
        {
            db.idOfUser = -1;

            Login login = new Login();
            login.Show();
            this.Close();
        }

        private void UpdateOrder(object sender, RoutedEventArgs e)
        {
            EditOrder editOrder = new EditOrder(order);
            editOrder.Show();
            this.Close();
        }
    }
}
