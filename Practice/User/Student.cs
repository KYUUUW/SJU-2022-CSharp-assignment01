using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    class Student : User
    {
        public Student()
        {
            needs = new Computer.Services[]
            { Computer.Services.Internet, Computer.Services.Scientific };
        }
    }
}
