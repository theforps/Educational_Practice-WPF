using educational_practice.data.repos;
using educational_practice.models;
using educational_practice.scripts;
using System.Windows;

namespace educational_practice.windows
{
    public partial class OrderInfo : Window
    {
        private BaseRepository db;
        private Invoice order;
        private int Id;

        public OrderInfo(int Id)
        {
            InitializeComponent();

            db = new BaseRepository();

            this.Id = Id;

            FillForm();
        }

        private void FillForm()
        {
            order = db.getInvoiceById(Id);

            OrderNumber.Text = "Заявка № " + Id.ToString();

            User user = db.getUserById(Consts.ID_CURRENT_USER);
            User executor = null;


            if (order != null)
            {
                Disc.Text = order.Description;
                Status.Text = order.Status.Name;
                DateStart.Text = order.StartDate.ToString();
                Type.Text = order.Defect.Name;
                Client.Text = order.Client.Name + " " + order.Client.Surname;
                Price.Text = order.Defect.Price.ToString() + " руб.";

                if(order.StartDate < order.EndDate)
                {
                    DateEnd.Text = order.EndDate.ToString();
                }
                else
                {
                    DateEnd.Text = "Не завершено";
                }
                if (order.Comment != null)
                {
                    Comment.Text = order.Comment;
                }

                if(order.Executor != null)
                {
                    executor = db.getUserById(order.Executor.Id);
                }

                if (executor != null && executor.Role.Name.Equals("executor"))
                    Executor.Text = executor.Name + " " + executor.Surname;
                else
                    Executor.Text = "Исполнитель не назначен";
            }

            if (user.Role.Name.Equals("executor") || user.Role.Name.Equals("manager"))
                EditBut.Visibility = Visibility.Visible;
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            Buttons.Back(this, new MainMenu());
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            Buttons.Exit(this);
        }

        private void SignOut(object sender, RoutedEventArgs e)
        {
            Buttons.SignOut(this, new Login());
        }

        private void UpdateOrder(object sender, RoutedEventArgs e)
        {
            Buttons.Back(this, new EditOrder(order));
        }
    }
}
