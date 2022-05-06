using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    class NoteBook : Computer
    {
        public NoteBook()
        {
            price = 10000;
            this.availableServices = new Services[] { Services.Internet, Services.Scientific };
        }

        public override string GetIdType()
        {
            return "NoteId";
        }
    }
}
