using Practica.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfApp1.Models;

namespace Practica
{
    /// <summary>
    /// Логика взаимодействия для Waiter.xaml
    /// </summary>
    public partial class Waiter : Window
    {
        public Waiter()
        {
            InitializeComponent();
            DataContext = new { Waiter = new WaiterVM(), MainVM = new MainWindowVM() };
        }
        //public Waiter(Order order)
        //{
        //    InitializeComponent();
        //    DataContext = new WaiterVM(order);
        //    DataContext = new MainWindowVM();
        //}
    }
}
