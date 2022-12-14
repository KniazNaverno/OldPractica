using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfApp1;
using WpfApp1.Models;
using Practica;
using Microsoft.EntityFrameworkCore;

namespace Practica.ViewModels
{
    public class MainWindowVM : BaseViewModel
    {
        private ObservableCollection<Order> _orders;
        
        private ObservableCollection<Place> _places;
        private RelayCommand _authorization;
        private RelayCommand _openWindow;
        private Order _order;
        private Place _place;
        private RelayCommand _changeOrder;
        private string _password;
        private string _login;

        public string Login
        {
            get { return _login; }
            set
            {
                _login = value;
                OnPropertyChanged();
            }
        }
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }
        public RelayCommand OpenWindow
        {
            get
            {
                return _openWindow ??
                    (_openWindow = new RelayCommand((x) =>
                    {
                        CurrentOrder currentOrder = new CurrentOrder();
                        currentOrder.Show();
                    }));
            }
        }
        public static int id;
        public RelayCommand Authorization
        {
            get
            {
                return _authorization ??
                    (_authorization = new RelayCommand((x) =>
                    {
                        var user = Helper.GetContext().Users.SingleOrDefault(x => x.Login == Login & x.Password == Password);
                        if (user == null)
                        {
                            MessageBox.Show("Данные введены неверно", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }
                        if (user.IdPost == 1)
                        {
                            Cook cook = new Cook();
                            cook.Show();
                        }
                        if (user.IdPost == 2)
                        {
                            Waiter wаiter = new Waiter();
                            wаiter.Show();
                        }
                        id = user.Id;
                    ((Window)x).Close();
                    }));
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
        public Order Order
        {
            get => _order;
            set
            {
                _order = value;
                OnPropertyChanged();
            }
        }
        public RelayCommand ChangeOrder
        {
            get
            {
                return _changeOrder ??
                (_changeOrder = new RelayCommand((x) =>
                {
                    if (Order.IdStatusOrder == 1 | Order.IdStatusOrder == 2)
                    {
                        if (Order.IdStatusOrder == 1)
                        {
                            Order.IdStatusOrder = 2;
                            Order.StatusOrder = Helper.GetContext().StatusOrders.Find(2);
                        }
                        else
                        {
                            Order.IdStatusOrder = 1;
                            Order.StatusOrder = Helper.GetContext().StatusOrders.Find(1);
                        }
                    }
                    else
                    {
                        if (Order.IdStatusOrder == 3)
                        {
                            Order.IdStatusOrder = 4;
                            Order.StatusOrder = Helper.GetContext().StatusOrders.Find(4);
                        }
                        else
                        {
                            Order.IdStatusOrder = 3;
                            Order.StatusOrder = Helper.GetContext().StatusOrders.Find(3);
                        }
                    }
                    Helper.GetContext().SaveChanges();
                }));
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
        public ObservableCollection<Order> Orders
        {
            get => _orders;
            set
            {
                _orders = value;
                OnPropertyChanged();
            }
        }
        
        public MainWindowVM()
        {
            _orders = new ObservableCollection<Order>(Helper.GetContext().Orders.Include(x => x.User).Include(x => x.StatusOrder).Include(x => x.Place).
                Include(x => x.Reserve).ThenInclude(x => x.Dish));
            
        }
    }
}