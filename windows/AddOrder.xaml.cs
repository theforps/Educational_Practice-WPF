using educational_practice.data;
using educational_practice.models;
using educational_practice.scripts;
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

        private void SaveOrder(object sender, RoutedEventArgs e)
        {
            if (Model.Text.Trim().Equals("") || Desc.Text.Trim().Equals("") || Bads.Text.Trim().Equals(""))
            {
                MessageBox.Show("Все поля должны быть заполнены");
            }
            else
            {
                Order order = new Order
                {
                    Id = ++DB.counterOrder,
                    Model = Model.Text.Trim(),
                    Description = Desc.Text.Trim(),
                    Type = Bads.Text.Trim(),
                    Status = "Не выполнено",
                    date = DateTime.Now,
                    idUser = Consts.ID_CURRENT_USER,
                    idExecuter = -1
                };

                crud.addOrder(order);

                Buttons.Back(this, new MainMenu());
            }
        }
    }
}
