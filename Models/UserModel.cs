using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoChef.Models
{

    [Table("USUARIO")]
    public class UserModel
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string NAME { get; set; }
        [Required]
        public string EMAIL { get; set; }
        [Required]
        public string PASSWORD { get; set; }
        [Required]
        public string CPF { get; set; }
        [Required]
        public DateTime BIRTHDATE { get; set; }
    }
}

