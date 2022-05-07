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
            // 가격과 서비스 등록
            price = 7000;
            availableServices = new Services[] { Services.Internet };
        }

        // id 받기
        public override string GetIdType()
        {
            return "NetId";
        }
    }
}
