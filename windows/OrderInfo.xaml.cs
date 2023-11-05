using educational_practice.data;
using educational_practice.models;
using educational_practice.scripts;
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

            {
                OrderNumber.Text = "Заявка № " + Id.ToString();
                order = crud.getOrderById(Id);
                var client = crud.getUserById(order.idUser);
                var executor = crud.getUserById(order.idExecuter);
                var user = crud.getUserById(Consts.ID_CURRENT_USER);

                if (order != null)
                {
                    Disc.Text = order.Description;
                    Status.Text = order.Status;
                    Date.Text = order.date.ToString();
                    Model.Text = order.Model;
                    Type.Text = order.Type;
                    Client.Text = client.Name + "\n" + client.Email;

                    if (order.Comment != null)
                    {
                        Comment.Text = order.Comment;
                    }

                    if (executor != null && executor.Roles == Roles.EXECUTOR.ToString())
                        Executor.Text = executor.Name;
                    else
                        Executor.Text = "Исполнитель не назначен";
                }

                if (user.Roles == Roles.EXECUTOR.ToString() || user.Roles == Roles.MANAGER.ToString())
                    EditBut.Visibility = Visibility.Visible;
            }
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            Buttons.Back(this, new MainMenu());
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            Buttons.Exit(this);
        }

        private void SignOut(object sender, RoutedEventArgs e)
        {
            Buttons.SignOut(this, new Login());
        }

        private void UpdateOrder(object sender, RoutedEventArgs e)
        {
            Buttons.Back(this, new EditOrder(order));
        }
    }
}
