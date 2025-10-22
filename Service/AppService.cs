using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace benProj.Service
{
    internal class AppService
    {
        public static AppService serviceRegister = new AppService();

        public string Name { get; set; }
        public string FamilyName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateOnly BirthDate { get; set; }

        private AppService()
        {
            Name = string.Empty;
            FamilyName = string.Empty;
            UserName = string.Empty;
            Password = string.Empty;
            BirthDate = new DateOnly(2000,1,1);
        }
        public static AppService GetInstance()
        {
            return serviceRegister;
        }
    }
}
