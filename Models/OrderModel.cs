using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoChef.Models
{
    [Table("PEDIDO")]
    public class OrderModel
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string STATUS { get; set; }

        [Required]
        public string PRODUCTS { get; set; }

        public string? FEEDBACK { get; set; }

        public int? RATING { get; set; }
    }
}
