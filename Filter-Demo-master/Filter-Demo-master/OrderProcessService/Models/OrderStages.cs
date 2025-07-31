using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderProcessService.Models
{
    public class OrderStages
    {
        [Key]
        public int OrderId { get; set; }
        [Column(TypeName = "varchar(20) null")]
        public string Stage { get; set; } = "";
        [Column(TypeName = "varchar(50) null")]
        public string Remarks { get; set; } = "";
        [Column(TypeName = "varchar(50) null")]
        public string Image { get; set; } = "";
        [Column(TypeName = "datetime null")]
        public DateTime StartDate { get; set; } 
        [Column(TypeName = "datetime null")]
        public DateTime EndDate { get; set; }
        public int EmpId { get; set; }

    }
}
