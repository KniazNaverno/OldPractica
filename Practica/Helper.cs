using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class Helper
    {
        private static Context _context;
        public static Context GetContext()
        {
            if(_context==null)
                _context = new Context();
            return _context;
        }
    }
}
