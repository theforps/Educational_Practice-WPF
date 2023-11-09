using System.ComponentModel.DataAnnotations;

namespace educational_practice.models
{
    public class Defect
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
    }
}
