using educational_practice.data.repos;
using educational_practice.models;
using educational_practice.scripts;
using System;
using System.Linq;
using System.Windows;

namespace educational_practice.windows
{
    public partial class AddOrder : Window
    {
        private BaseRepository db;

        public AddOrder()
        {
            InitializeComponent();

            db = new BaseRepository();

            Bads.ItemsSource = db.getDefects().Select(x => x.Name);
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
            if (Desc.Text.Trim().Equals("") || Bads.Text.Trim().Equals(""))
            {
                MessageBox.Show("Все поля должны быть заполнены");
            }
            else
            {
                Invoice order = new Invoice
                {
                    Description = Desc.Text.Trim(),
                    Defect = db.getDefectByName(Bads.Text),
                    Status = db.getStatusByName("Не выполнено"),
                    StartDate = DateTime.Now,
                    Client = db.getUserById(Consts.ID_CURRENT_USER),
                };

                db.addInvoice(order);

                Buttons.Back(this, new MainMenu());
            }
        }
    }
}
