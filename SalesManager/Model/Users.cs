using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManager.Model
{
    [Serializable]
    class Users
    {
        public String Name { get; set; }
        public string Password { get; set; }

        public string Rights { get; set; }//Admin or worker
    }
}
