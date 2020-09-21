using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeManagementSystem.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string UserName {get;set;}
        public string SecondName { get; set; }
        public int UserAge { get; set; }
        public string UserLogin { get; set; }
        public string UserPassword { get; set; }
    }
}
