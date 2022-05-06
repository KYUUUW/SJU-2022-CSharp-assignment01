using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    class Desktop : Computer
    {
        public Desktop()
        {
            price = 13000;
            availableServices = new Services[] {Services.Internet, Services.Scientific, Services.Game };
        }

        public override string GetIdType()
        {
            return "DeskId";
        }
    }
}
