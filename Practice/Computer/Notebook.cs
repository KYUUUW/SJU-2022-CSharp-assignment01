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
            // 가격 정보와 서비스 등록
            price = 10000;
            this.availableServices = new Services[] { Services.Internet, Services.Scientific };
        }

        // type id 의 이름
        public override string GetIdType()
        {
            return "NoteId";
        }
    }
}
