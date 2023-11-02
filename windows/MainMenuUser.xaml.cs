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
    public partial class MainMenuUser : Window
    {
        public MainMenuUser()
        {
            InitializeComponent();

            var orders = db.orders.Where(x => x.idUser == db.idOfUser);

            Orders.ItemsSource = orders;

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
            var param = Search.Text;

            var orders = db.orders.Where(x => 
            x.Status.Contains(param) || 
            x.Type.Contains(param) || 
            x.Description.Contains(param) || 
            x.Model.Contains(param) || 
            param.Contains(x.Id.ToString()));

            Orders.ItemsSource = orders;
        }

        private void AddOrder(object sender, RoutedEventArgs e)
        {
            AddOrderWindow addOrder = new AddOrderWindow();
            addOrder.Show();
            this.Close();
        }
    }
}
