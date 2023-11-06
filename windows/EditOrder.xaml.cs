using educational_practice.data;
using educational_practice.models;
using educational_practice.scripts;
using System;
using System.Linq;
using System.Windows;

namespace educational_practice.windows
{
    public partial class EditOrder : Window
    {
        CRUD crud = new CRUD();
        int orderId;

        public EditOrder()
        {
            InitializeComponent();
        }

        public EditOrder(Order order)
        {
            InitializeComponent();

            User user = crud.getUserById(Consts.ID_CURRENT_USER);

            {
                orderId = order.Id;
                OrderNumber.Text = "Номер заявки " + order.Id;
                Disc.Text = order.Description;
                Status.ItemsSource = DB.status;
                Status.Text = order.Status;
                Date.Text = order.date.ToString();
                Model.Text = order.Model;
                Type.ItemsSource = DB.faults;
                Type.Text = order.Type;
                Comment.Text = order.Comment;
                var client = crud.getUserById(order.idUser);
                Client.Text = client.Name + "\n" + client.Email;
                Executor.ItemsSource = crud.getUsers().Where(x => x.Roles == Roles.EXECUTOR.ToString()).Select(x => x.Name);


                if (order.idExecuter > -1)
                    Executor.Text = crud.getUserById(order.idExecuter).Name;

                if (user.Roles == Roles.EXECUTOR.ToString())
                {
                    Type.IsEnabled = false;
                    Executor.IsEnabled = false;
                    Disc.IsReadOnly = true;
                }
            }
        }

        private void SaveBut(object sender, RoutedEventArgs e)
        {
            Order order = crud.getOrderById(orderId);
            User executor = crud.getUserByUserName(Executor.Text);

            if (executor == null ||
                Status.Text.Trim().Equals("") ||
                Disc.Text.Trim().Equals("") ||
                Type.Text.Trim().Equals(""))
            {
                MessageBox.Show("Все поля должны быть заполнены");
            }
            else
            {
                order.idExecuter = executor.Id;
                order.Status = Status.Text.Trim();
                order.Comment = Comment.Text.Trim();
                order.Description = Disc.Text.Trim();
                order.Type = Type.Text.Trim();

                crud.saveOrder(order);

                Buttons.Back(this, new MainMenu());
            }
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            Buttons.Exit(this);
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            Buttons.Back(this, new MainMenu());
        }

        private void SignOut(object sender, RoutedEventArgs e)
        {
            Buttons.SignOut(this, new Login());
        }
    }
}
