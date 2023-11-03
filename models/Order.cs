using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace educational_practice.models
{
    public class Order
    {
        public int Id {  get; set; }
        public string Model { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
        public string Comment { get; set; }
        public DateTime date { get; set; }
        public int idUser { get; set; }
        public int idExecuter { get; set; }
    }
}
