using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HourTrackerBackend.Modals.Request
{
    public class UserLogin
    {
        public string username { get; set; }
        public string password { get; set; }
    }
}
