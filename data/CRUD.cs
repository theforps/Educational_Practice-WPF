using educational_practice.models;
using System.Collections.Generic;
using System.Linq;

namespace educational_practice.data
{
    public class CRUD
    {
        public void addOrder(Order order)
        {
            Db.orders.Add(order);
        }

        public List<string> getFaults()
        {
            return Db.faults;
        }

        public User getUserByName(string name) {
            
            return Db.users.FirstOrDefault(x => x.Login.Equals(name));
        }

        public User getUserById(int id)
        {
            return Db.users.FirstOrDefault(x => x.Id == id);
        }

        public List<User> getUsers()
        {
            return Db.users;
        }

        public List<Order> getOrders()
        {
            var orders = Db.orders.OrderByDescending(x => x.date).ToList();

            return orders;
        }

        public Order getOrderById(int id)
        {
            return Db.orders.FirstOrDefault(x => x.Id == id);
        }

        public List<Order> getOrdersByParam(string param)
        {
            param = param.ToLower();
            
            var orders = Db.orders.Where(x =>
            x.Status.ToLower().Contains(param) ||
            x.Type.ToLower().Contains(param) ||
            x.Description.ToLower().Contains(param) ||
            x.Model.ToLower().Contains(param) ||
            param.ToLower().Contains(x.Id.ToString())).ToList();

            return orders;
        }

        public void saveOrder(Order order)
        {
            Db.orders.Remove(order);
            Db.orders.Add(order);
        }

    }
}
