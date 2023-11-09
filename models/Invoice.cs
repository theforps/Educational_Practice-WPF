using System;
using System.ComponentModel.DataAnnotations;

namespace educational_practice.models
{
    public class Invoice
    {
        [Key]
        public int Id {  get; set; }
        public Device Device { get; set; }
        public User Client { get;set; }
        public User Executor { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Status Status { get; set; }
        public Defect Defect { get; set; }
        public string Comment { get; set; }
    }
}
