using educational_practice.data;
using educational_practice.models;
using System;
using System.Windows;

namespace educational_practice.windows
{
    public partial class AddOrder : Window
    {
        CRUD crud = new CRUD();

        public AddOrder()
        {
            InitializeComponent();

            Bads.ItemsSource = crud.getFaults();
            Bads.SelectedIndex = 0;
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

        private void SaveOrder(object sender, RoutedEventArgs e)
        {
            Order order = new Order
            {
                Id = ++db.counter,
                Model = Model.Text,
                Description = Desc.Text,
                Type = Bads.Text,
                Status = "Не выполнено",
                date = DateTime.Now,
                idUser = db.idOfUser,
                idExecuter = -1
            };

            crud.addOrder(order);

            MainMenu user = new MainMenu();
            user.Show();
            this.Close();
        }
    }
}
