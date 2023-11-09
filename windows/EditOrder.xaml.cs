using educational_practice.data.repos;
using educational_practice.models;
using educational_practice.scripts;
using System;
using System.Linq;
using System.Windows;

namespace educational_practice.windows
{
    public partial class EditOrder : Window
    {
        private BaseRepository db;
        private Invoice order;

        public EditOrder()
        {
            InitializeComponent();
        }

        public EditOrder(Invoice order)
        {
            InitializeComponent();

            db = new BaseRepository();
            this.order = order;
            FillForm();
        }

        private void FillForm()
        {
            User user = db.getUserById(Consts.ID_CURRENT_USER);

            OrderNumber.Text = "Номер заявки " + order.Id;
            Disc.Text = order.Description;
            Status.ItemsSource = db.getStatuses().Select(x => x.Name);
            Status.Text = order.Status.Name;
            Date.Text = order.StartDate.ToString();
            Type.ItemsSource = db.getDefects().Select(x => x.Name);
            Type.Text = order.Defect.Name;
            Comment.Text = order.Comment;
            Client.Text = order.Client.Name + " " + order.Client.Surname;
            Executor.ItemsSource = db.getExecutors().Select(x => x.Name + " " + x.Surname);

            if (order.Executor != null)
            {
                Executor.Text = order.Executor.Name + " " + order.Executor.Surname;
            }

            if (user.Role.Name.Equals("executor"))
            {
                Type.IsEnabled = false;
                Executor.IsEnabled = false;
                Disc.IsReadOnly = true;
            }
        }

        private void SaveBut(object sender, RoutedEventArgs e)
        {
            User executor = db.getUserByName(Executor.Text);

            if (executor == null ||
                Status.Text.Trim().Equals("") ||
                Disc.Text.Trim().Equals("") ||
                Type.Text.Trim().Equals(""))
            {
                MessageBox.Show("Все поля должны быть заполнены");
            }
            else
            {
                order.Executor = executor;
                order.Status = db.getStatusByName(Status.Text.Trim());
                order.Comment = Comment.Text.Trim();
                order.Description = Disc.Text.Trim();
                order.Defect = db.getDefectByName(Type.Text.Trim());

                if(order.Status.Name.Equals("Выполнено"))
                    order.EndDate = DateTime.Now;

                db.updateInvoice(order);

                Buttons.Back(this, new MainMenu());
            }
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
    }
}
