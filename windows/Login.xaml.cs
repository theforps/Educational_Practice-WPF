using educational_practice.data;
using educational_practice.models;
using educational_practice.scripts;
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
            Buttons.Exit(this);
        }

        private void Enter(object sender, RoutedEventArgs e)
        {
            string login = Nick.Text;
            string password = Password.Text;

            if (login.Length < 4)
            {
                MessageBox.Show("Логин должен содержать минимум 4 символов");
            }
            else if (password.Length < 4)
            {
                MessageBox.Show("Пароль должен содержать минимум 4 символов");
            }
            else if (check(login, password))
            {
                MessageBox.Show("Неправильный логин или пароль");
            }
            else
            {
                User user = crud.getUserByName(login);
                Consts.ID_CURRENT_USER = user.Id;

                Buttons.Back(this, new MainMenu());
            }
        }

        public bool check(string login, string password)
        {
            var user = crud.getUserByName(login);
            if (user != null && user.Password.Equals(password))
            {
                return true;
            }

            return false;
        }
    }
}
