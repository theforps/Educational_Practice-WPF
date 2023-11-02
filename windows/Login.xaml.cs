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
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Enter(object sender, RoutedEventArgs e)
        {
            User user = db.users.FirstOrDefault(x => x.Login.Equals(Nick.Text));

            if (Password.Text.Length < 4) {
                MessageBox.Show("Пароль должен содержать минимум 4 символов");
            }
            else if (Nick.Text.Length < 4)
            {
                MessageBox.Show("Логин должен содержать минимум 4 символов");
            }
            else if(user == null)
            {
                MessageBox.Show("Пользователя не существует");
            }
            else if(!user.Password.Equals(Password.Text))
            {
                MessageBox.Show("Неправильный пароль");
            }
            else
            {
                db.idOfUser = user.Id;

                if(user.Roles == Roles.USER.ToString())
                {
                    MainMenuUser mainMenu = new MainMenuUser();
                    mainMenu.Show();
                }
                this.Close();
            }
        }
    }
}
