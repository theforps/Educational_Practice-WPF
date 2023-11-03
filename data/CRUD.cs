using educational_practice.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace educational_practice.data
{
    public class CRUD
    {
        public void addOrder(Order order)
        {
            db.orders.Add(order);
        }

        public List<string> getFaults()
        {
            return db.faults;
        }

        public User getUserByName(string name) {
            
            return db.users.FirstOrDefault(x => x.Login.Equals(name));
        }

        public User getUserById(int id)
        {
            return db.users.FirstOrDefault(x => x.Id == id);
        }

        public List<User> getUsers()
        {
            return db.users;
        }

        public List<Order> getOrders()
        {
            var orders = db.orders.OrderByDescending(x => x.date).ToList();

            return orders;
        }

        public Order getOrderById(int id)
        {
            return db.orders.FirstOrDefault(x => x.Id == id);
        }

        public List<Order> getOrdersByParam(string param)
        {
            param = param.ToLower();
            
            var orders = db.orders.Where(x =>
            x.Status.Contains(param) ||
            x.Type.Contains(param) ||
            x.Description.Contains(param) ||
            x.Model.Contains(param) ||
            param.Contains(x.Id.ToString())).ToList();

            return orders;
        }

        public void saveOrder(Order order)
        {
            db.orders.Remove(order);
            db.orders.Add(order);
        }

    }
}
