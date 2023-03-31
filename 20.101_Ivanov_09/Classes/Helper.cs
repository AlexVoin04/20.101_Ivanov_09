using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20._101_Ivanov_09.Classes
{
    internal class Helper
    {
        private static Entity.Entities s_Entities;
        public static Entity.Entities GetContext()
        {
            if (s_Entities == null)
            {
                s_Entities = new Entity.Entities();
            }
            return s_Entities;
        }
    }
}
