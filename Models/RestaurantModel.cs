using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoChef.Models
{
    [Table("RESTAURANTE")]
    public class RestaurantModel
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string NAME { get; set; }
        [Required]
        public string CNPJ { get; set; }
        [Required]
        public string EMAIL { get; set; }
        [Required]
        public string PASSWORD { get; set; }

    }
}
