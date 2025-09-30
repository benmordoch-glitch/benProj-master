using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace benProj
{
    internal class ServiceRegister
    {
        public static ServiceRegister serviceRegister = new ServiceRegister();

        public string Name { get; set; }
        public string FamilyName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateOnly BirthDate { get; set; }

        private ServiceRegister()
        {
            Name = string.Empty;
            FamilyName = string.Empty;
            UserName = string.Empty;
            Password = string.Empty;
            BirthDate = new DateOnly(2000,1,1);
        }
        public static ServiceRegister GetInstance()
        {
            return serviceRegister;
        }
    }
}
