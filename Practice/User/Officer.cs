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
            // 사용자가 사용 할 서비스들의 등록
            needs = new Computer.Services[]{ Computer.Services.Internet };
        }
    }
}
