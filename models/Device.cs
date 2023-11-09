using System.ComponentModel.DataAnnotations;

namespace educational_practice.models
{
    
    public class Device
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
