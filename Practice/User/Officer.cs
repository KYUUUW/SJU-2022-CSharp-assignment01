using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    class Officer : User
    {
        public Officer()
        {
            needs = new Computer.Services[]{ Computer.Services.Internet };
        }
    }
}
