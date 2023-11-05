using educational_practice.models;
using System.Collections.Generic;
using System.Linq;

namespace educational_practice.data
{
    public class CRUD
    {
        public void addOrder(Order order)
        {
            DB.orders.Add(order);
        }

        public List<string> getFaults()
        {
            return DB.faults;
        }

        public User getUserByName(string name) {
            
            return DB.users.FirstOrDefault(x => x.Login.Equals(name));
        }

        public User getUserById(int id)
        {
            return DB.users.FirstOrDefault(x => x.Id == id);
        }

        public List<User> getUsers()
        {
            return DB.users;
        }

        public List<Order> getOrders()
        {
            var orders = DB.orders.OrderByDescending(x => x.date).ToList();

            return orders;
        }

        public Order getOrderById(int id)
        {
            return DB.orders.FirstOrDefault(x => x.Id == id);
        }

        public List<Order> getOrdersByParam(string param)
        {
            param = param.ToLower();
            
            var orders = DB.orders.Where(x =>
            x.Status.ToLower().Contains(param) ||
            x.Type.ToLower().Contains(param) ||
            x.Description.ToLower().Contains(param) ||
            x.Model.ToLower().Contains(param) ||
            param.ToLower().Contains(x.Id.ToString())).ToList();

            return orders;
        }

        public void saveOrder(Order order)
        {
            DB.orders.Remove(order);
            DB.orders.Add(order);
        }

    }
}
