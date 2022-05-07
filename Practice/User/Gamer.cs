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
            // 사용자가 사용 할 서비스들의 등록
            needs =new Computer.Services[]
            { Computer.Services.Internet, Computer.Services.Scientific, Computer.Services.Game };
        }
    }
}
