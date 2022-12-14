using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Models
{
    public class Dish
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string NameDish { get; set; }
        [Required]
        public decimal Price { get; set; }
        public TimeSpan CookingTime { get; set; }
        public ICollection<Reserve> Reserve { get; set; }
    }
}
