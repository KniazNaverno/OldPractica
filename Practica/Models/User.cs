using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Models;

namespace WpfApp1.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string MiddleName{ get; set; }
        [Required]
        public string Status { get; set; }
        public byte[] Contract { get; set; }
        public byte[] Photo { get; set; }

        [ForeignKey(nameof(Post))]
        public int IdPost { get; set; }
        [InverseProperty("User")]
        public Post Post { get; set; }
        [InverseProperty("User")]
        public ICollection<Order> Order { get; set; }
    }
}
