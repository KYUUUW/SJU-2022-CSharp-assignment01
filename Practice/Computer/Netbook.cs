using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    class NetBook : Computer
    {
        public NetBook()
        {
            price = 7000;
            availableServices = new Services[] { Services.Internet };
        }

        public override string GetIdType()
        {
            return "NetId";
        }
    }
}
