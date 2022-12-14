using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfApp1;
using WpfApp1.Models;

namespace Practica.ViewModels
{
    public class WaiterVM : BaseViewModel
    {
        private Order _order=new Order();
        private RelayCommand _submitCommand;
        private ObservableCollection<Place> _places;
        private Place _place;
        private Dish _dish;
        private ObservableCollection<Dish> _dishs;
        private ObservableCollection<Dish> _dishesInReserve = new ObservableCollection<Dish>();
        private Reserve _reserve = new Reserve();
        public Dish Ordering
        {
            get => null;
            set
            {
                DishesInReserve.Add(value);
                OnPropertyChanged();
            }
        }
        public Dish Remove
        {
            get => null;
            set
            {
                DishesInReserve.Remove(value);
                OnPropertyChanged();
            }
        }
        public Dish Dish
        {
            get => _dish;
            set
            {
                _dish = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<Dish> DishesInReserve
        {
            get => _dishesInReserve;
            set
            {
                _dishesInReserve = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<Dish> Dishs
        {
            get => _dishs;
            set
            {
                _dishs = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<Place> Places
        {
            get => _places;
            set
            {
                _places = value;
                OnPropertyChanged();
            }
        }
        public Reserve Reserve
        {
            get => _reserve;
            set 
            {
                _reserve = value;
                OnPropertyChanged();
            }
        }
        public Place Place
        {
            get => _place;
            set
            {
                _place = value;
                OnPropertyChanged();
            }
        }
        public RelayCommand SumbitCommand
        {
            get
            {
                return _submitCommand ??
                    (_submitCommand = new RelayCommand((x) =>
                    {
                        if (_order.Id == 0)
                        {
                            var timeOfDay = DateTime.Now.TimeOfDay;
                            var time = TimeSpan.Parse($"{timeOfDay.Hours}:{timeOfDay.Minutes}:{timeOfDay.Seconds}");
                            _order.TimeOrder = time;
                            _order.IdUser = MainWindowVM.id;
                            _order.IdStatusOrder = 1;
                            _order.Place = _place;
                            _order.Reserve = DishesInReserve.Select(x=>new Reserve() { Dish=x,Order=_order}).ToList();
                            Helper.GetContext().Orders.Add(_order);
                            Helper.GetContext().SaveChanges();
                        }
                        MessageBox.Show("Заказ добавлен", "Добавлен", MessageBoxButton.OK, MessageBoxImage.Information);
                    }));
            }
        }
        public Order Order
        {
            get => _order;
            set
            {
                _order = value;
                OnPropertyChanged();
            }
        }
        public WaiterVM()
        {
            _places=new ObservableCollection<Place>(Helper.GetContext().Places);
            _dishs = new ObservableCollection<Dish>(Helper.GetContext().Dishs);
        }
    }
}
