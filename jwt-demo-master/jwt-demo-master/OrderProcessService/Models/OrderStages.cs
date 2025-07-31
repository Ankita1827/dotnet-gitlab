using System.ComponentModel.DataAnnotations;

namespace OrderProcessService.Models
{
    public class OrderStages
    {
        [Key]
        public int OrderId { get; set; }
        public string Status { get; set; }
        public string Remarks { get; set; }
        public string Image { get; set; } // Assuming this is a URL or file path
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int EmpId { get; set; }

    }
}
