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
            // 가격과 사용 가능한 정보
            price = 13000;
            availableServices = new Services[] {Services.Internet, Services.Scientific, Services.Game };
        }

        // id 에 대한 타입
        public override string GetIdType()
        {
            return "DeskId";
        }
    }
}
