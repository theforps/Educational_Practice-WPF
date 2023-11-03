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
    /// Логика взаимодействия для OrderInfo.xaml
    /// </summary>
    public partial class OrderInfo : Window
    {
        public OrderInfo()
        {
            InitializeComponent();
        }

        public OrderInfo(int Id)
        {
            InitializeComponent();

            OrderNumber.Text = "Номер заявки " + Id.ToString();

            var order = db.orders.FirstOrDefault(x => x.Id == Id);
            var client = db.users.FirstOrDefault(x => x.Id == order.idUser).Name;
            var executor = db.users.Find(x => x.Id == order.idExecuter && x.Roles == Roles.EXECUTOR.ToString());


            if (order != null)
            {
                Disc.Text = order.Description;
                Status.Text = order.Status;
                Date.Text = order.date.ToString();
                Model.Text = order.Model;
                Type.Text = order.Type;
                Client.Text = client + " " + order.idUser;

                if (executor != null)
                {
                    Executor.Text = executor.Name + " " + executor.Id;
                }
                else
                    Executor.Text = "Исполнитель не назначен";

            }




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
    }
}
