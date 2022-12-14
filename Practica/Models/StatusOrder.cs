using Practica.ViewModels;
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
    public class StatusOrder : BaseViewModel
    {
        private string _nameStatusOrder;
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdStatusOrder { get; set; }
        [Required]
        public string NameStatusOrder
        {
            get { return _nameStatusOrder; }
            set
            {
                _nameStatusOrder = value;
                OnPropertyChanged();
            }
        }
        [InverseProperty("StatusOrder")]
        public ICollection<Order> Order { get; set; }
    }
}
