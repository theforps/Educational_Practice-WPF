using educational_practice.models;
using System.Collections.Generic;
using System.Linq;

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
            x.Status.ToLower().Contains(param) ||
            x.Type.ToLower().Contains(param) ||
            x.Description.ToLower().Contains(param) ||
            x.Model.ToLower().Contains(param) ||
            param.ToLower().Contains(x.Id.ToString())).ToList();

            return orders;
        }

        public void saveOrder(Order order)
        {
            db.orders.Remove(order);
            db.orders.Add(order);
        }

    }
}
