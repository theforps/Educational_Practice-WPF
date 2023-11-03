using educational_practice.data;
using educational_practice.models;
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

            User user = crud.getUserById(db.idOfUser);

            orderId = order.Id;

            OrderNumber.Text = "Номер заявки " + order.Id;
            Disc.Text = order.Description;

            Status.ItemsSource = db.status;
            Status.Text = order.Status;

            Date.Text = order.date.ToString();
            Model.Text = order.Model;

            Type.ItemsSource = db.faults;
            Type.Text = order.Type;

            Client.Text = crud.getUserById(order.idUser).Name + " " + order.idUser;

            Executor.ItemsSource = crud.getUsers().Where(x => x.Roles == Roles.EXECUTOR.ToString()).Select(x => x.Name);
            
            if(order.idExecuter > -1)
                Executor.Text = crud.getUserById(order.idExecuter).Name;

            Comment.Text = order.Comment;

            if (user.Roles == Roles.EXECUTOR.ToString())
            {
                Type.IsEnabled = false;
                Executor.IsEnabled = false;

                Disc.IsReadOnly = true;
            }
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

        private void SaveBut(object sender, RoutedEventArgs e)
        {
            Order order = crud.getOrderById(orderId);

            order.Status = Status.Text;
            order.idExecuter = crud.getUserByName(Executor.Text).Id;
            order.Comment = Comment.Text;
            order.Description = Disc.Text;
            order.Type = Type.Text;

            crud.saveOrder(order);

            MainMenu mainMenu = new MainMenu();
            mainMenu.Show();
            this.Close();
        }
    }
}
