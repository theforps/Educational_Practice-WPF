using educational_practice.models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace educational_practice.data.repos
{
    public class BaseRepository
    {
        private DataContext db;

        public BaseRepository()
        {
            db = new DataContext();
        }

        public List<User> getUsers()
        {
            return db.users.Include(x => x.Role).ToList();
        }

        public async Task<bool> checkUserExist(string login, string Password)
        {
            User user = await db.users.FirstOrDefaultAsync(x => x.Login.Equals(login.ToLower()));

            if(user != null && user.Password.Equals(Password.ToLower()))
                return true;

            return false;
        }

        public async Task<User> getUserByLogin(string login)
        {
            User user = await db.users.FirstOrDefaultAsync(x => x.Login.Equals(login.ToLower()));

            return user;
        }

        public User getUserByName(string name)
        {
            return getUsers().FirstOrDefault(x => name.Equals(x.Name + " " + x.Surname));
        }

        public User getUserById(int id)
        {
            User user = db.users.Include(x => x.Role).FirstOrDefault(x => x.Id == id);

            return user;
        }

        public List<Role> getRoles()
        {
            return db.roles.ToList();
        }

        public List<Invoice> getInvoicesByClient(int id)
        {
            return getAllInvoices().Where(x => x.Client.Id == id).ToList();
        }

        public List<Invoice> getInvoicesByExecutor(int id)
        {
            return getAllInvoices().Where(x => x.Executor.Id == id).ToList();
        }

        public List<Invoice> getAllInvoices()
        {
            return db.invoices
                .Include(x => x.Status)
                .Include(x => x.Device)
                .Include(x => x.Client)
                .Include(x => x.Defect)
                .Include(x => x.Executor)
                .OrderByDescending(x => x.Id)
                .ToList();
        }

        public List<Invoice> getInvoicesById(int id)
        {
            return getAllInvoices().Where(x => x.Id == id).ToList();
        }

        public List<Defect> getDefects()
        {
            return db.defects.ToList();
        }

        public Defect getDefectByName(string name)
        {
            return db.defects.FirstOrDefault(x => x.Name.Equals(name));
        }

        public Status getStatusByName(string name)
        {
            return db.statuses.FirstOrDefault(x => x.Name.Equals(name));
        }

        public List<Status> getStatuses()
        {
            return db.statuses.ToList();
        }

        public void addInvoice(Invoice invoice)
        {
            db.invoices.Add(invoice);
            db.SaveChanges();
        }

        public void updateInvoice(Invoice invoice)
        {
            Invoice oldInvoice = db.invoices.FirstOrDefault(x => x.Id == invoice.Id);

            {
                oldInvoice.Executor = invoice.Executor;
                oldInvoice.Status = invoice.Status;
                oldInvoice.Comment = invoice.Comment;
                oldInvoice.Description = invoice.Description;
                oldInvoice.Defect = invoice.Defect;
                oldInvoice.EndDate = invoice.EndDate;
            }

            db.SaveChanges();
        }

        public Invoice getInvoiceById(int id)
        {
            return getAllInvoices()
                .FirstOrDefault(x => x.Id == id);
        }

        public List<User> getExecutors()
        {
            return getUsers()
                .Where(x => x.Role.Name.Equals("executor"))
                .ToList();
        }

        public int completedInvoices()
        {
            int count = db.invoices
                .Include(x => x.Status)
                .Where(x => x.Status.Name.Equals("Выполнено"))
                .Count();

            return count;
        }

        public int avgExecution()
        {
            var list = db.invoices.Where(x => x.Status.Name.Equals("Выполнено") && x.EndDate > x.StartDate).ToList();

            var result = list
                .Select(x => (x.EndDate - x.StartDate).Hours)
                .Average();

            return (int)result;
        }
    }
}
