using SalesManager.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManager.DummyDataStruc
{
    class ProductStorage
    {
        
        private static ObservableCollection<Product> instance = null;

        public static ObservableCollection<Product> Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ObservableCollection<Product>();
                }
                return instance;

            }
        }
    }
}
