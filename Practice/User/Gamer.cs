using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    class Gamer: User
    {
        public Gamer()
        {
            needs =new Computer.Services[]
            { Computer.Services.Internet, Computer.Services.Scientific, Computer.Services.Game };
        }
    }
}
