using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace SalesManager.Model
{
    [Serializable]
    class Sales
    {
        public int Id { get; set; }
        public ObservableCollection<Product> Products{ get; set; }
        public decimal Amount { get; set; }
        public decimal Balance { get; set; }
        public bool Paid { get; set; }
        //Later things, generate invoice/receipt for products sold

    }
}
