using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManager.Model
{
    [Serializable]
    class Admin
    {
        public String Name { get; set; }
        public string Password { get; set; }

        public string Rights { get; set; }//Admin or worker

        
        //Making it a singleton
        private static Admin instance = null;

       

        //A static property that returns the single user object in memory
        public static Admin Instance { 
            get 
            {
                if (instance == null)
                {
                    instance = new Admin();
                }
                return instance;
                    
            } }

        //Other would be added later on.
    }
}
