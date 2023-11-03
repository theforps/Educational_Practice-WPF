using educational_practice.data;
using educational_practice.models;
using System.Linq;
using System.Windows;

namespace educational_practice.windows
{

    public partial class Login : Window
    {
        CRUD crud = new CRUD();

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
            User user = crud.getUserByName(Nick.Text);

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

                MainMenu mainMenu = new MainMenu();
                mainMenu.Show();
                this.Close();
            }
        }
    }
}
