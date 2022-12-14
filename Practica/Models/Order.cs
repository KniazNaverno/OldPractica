using Practica.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Models
{
    public class Order:BaseViewModel
    {
        private int _idStatus;
        private StatusOrder _statusOrder;
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public TimeSpan TimeOrder { get; set; }
        [ForeignKey(nameof(StatusOrder))]
        public int IdStatusOrder
        {
            get=> _idStatus;
            set
            {
                _idStatus = value;
                OnPropertyChanged();
            }
        }
        [InverseProperty("Order")]
        public StatusOrder StatusOrder
        {
            get => _statusOrder;
            set
            {
                _statusOrder = value;
                OnPropertyChanged();
            }
        }
        [ForeignKey(nameof(User))]
        public int IdUser { get; set; }
        [InverseProperty("Order")]
        public User User { get; set; }
        [ForeignKey(nameof(Place))]
        public int IdPlace { get; set; }
        [InverseProperty("Order")]
        public Place Place { get; set; }
        public ICollection<Reserve> Reserve { get; set; }
    }
}
