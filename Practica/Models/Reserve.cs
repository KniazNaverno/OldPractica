using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Models
{
    public class Reserve
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey(nameof(Dish))]
        public int IdDish { get; set; }
        [InverseProperty("Reserve")]
        public Dish Dish { get; set; }

        [ForeignKey(nameof(Order))]
        public int IdOrder { get; set; }
        [InverseProperty("Reserve")]
        public Order Order { get; set; }

    }
}
