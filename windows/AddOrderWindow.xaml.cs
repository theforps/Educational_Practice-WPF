using educational_practice.data;
using educational_practice.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace educational_practice.windows
{
    /// <summary>
    /// Логика взаимодействия для AddOrderWindow.xaml
    /// </summary>
    public partial class AddOrderWindow : Window
    {
        public AddOrderWindow()
        {
            InitializeComponent();

            Bads.ItemsSource = db.faults;
            Bads.SelectedIndex = 0;
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            MainMenuUser mainMenuUser = new MainMenuUser();
            mainMenuUser.Show();
            this.Close();
        }

        private void SignOut(object sender, RoutedEventArgs e)
        {
            db.idOfUser = -1;
            Login login = new Login();
            login.Show();
            this.Close();
        }

        private void AddOrder(object sender, RoutedEventArgs e)
        {
            Order order = new Order
            {
                Id = ++db.counter,
                Model = Model.Text,
                Description = Desc.Text,
                Type = Bads.Text,
                Status = "В ожидании",
                date = DateTime.Now,
                idUser = db.idOfUser
                
            };

            db.orders.Add(order);

            MainMenuUser user = new MainMenuUser();
            user.Show();
            this.Close();
        }
    }
}
