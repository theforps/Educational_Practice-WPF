using educational_practice.data.repos;
using educational_practice.models;
using educational_practice.scripts;
using System.Windows;

namespace educational_practice.windows
{

    public partial class Login : Window
    {
        private BaseRepository db;

        public Login()
        {
            InitializeComponent();

            db = new BaseRepository();
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            Buttons.Exit(this);
        }

        private async void Enter(object sender, RoutedEventArgs e)
        {
            string login = Nick.Text;
            string password = Password.Text;
            bool userExist = await db.checkUserExist(login, password);

            if (login.Length < 4)
            {
                MessageBox.Show("Логин должен содержать минимум 4 символов");
            }
            else if (password.Length < 4)
            {
                MessageBox.Show("Пароль должен содержать минимум 4 символов");
            }
            else if (!userExist)
            {
                MessageBox.Show("Неправильный логин или пароль");
            }
            else
            {
                User user = await db.getUserByLogin(login);
                Consts.ID_CURRENT_USER = user.Id;

                Buttons.Back(this, new MainMenu());
            }
        }
    }
}
