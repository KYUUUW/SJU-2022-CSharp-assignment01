using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    abstract class Computer
    {
        public int Id { get; init; }
        public int Cid { get; init; }

        public int dayRequested = -1;
        public int dayLeft = -1;
        public int dayUsed = -1;
        public int price = 0;
        public Services[] availableServices;

        /**
         * 컴퓨터에서 사용 가능한 서비스들 목록의 나열
         */
        public enum Services { Internet, Scientific, Game };

        /**
         * 장비의 렌탈이 시작됨. 대여일들을 설정함
         */
        public void StartRent(int requestDays)
        {
            ResetDate(requestDays);
        }

        /**
         * 대여일을 초기화하고 사용 일수만큼 가격을 지불함
         */
        public int EndRent()
        {
            int payment = price * dayUsed;
            ResetDate();
            return payment;
        }

        public int MoveToNextDay()
        {
            if(dayRequested == -1) {
                return -1; // -1 을 return 하면 아직 기한이 남은 것임
            }
            dayLeft -= 1;
            dayUsed += 1;
            if(dayLeft == 0)
            {
                return EndRent();
            }
            return -1;
        }

        public string GetInstanceTypeToString()
        {
            if(this is NetBook)
            {
                return "Netbook";
            }
            else if (this is NoteBook)
            {
                return "Notebook";
            }
            else if(this is Desktop)
            {
                return "Desktop";
            }
            else
            {
                return "Not Defined";
            }
        }

        public string GetServicesToString()
        {
            var services = "";
            if(availableServices.Contains(Services.Internet))
            {
                services += "internet, ";
            }
            if(availableServices.Contains(Services.Scientific))
            {
                services += "scientific, ";
            }
            if(availableServices.Contains(Services.Game))
            {
                services += "game, ";
            }
            return services;
        }

        /**
         * IdType을 받아옴
         */
        public virtual string GetIdType()
        {
            return "CompId";
        }

        /**
         * 대여일을 초기화함: Overriding
         */
        private void ResetDate()
        {
            dayRequested = -1;
            dayLeft = -1;
            dayUsed = -1;
        }
        private void ResetDate(int req)
        {
            dayRequested = req;
            dayLeft = req;
            dayUsed = 0;
        } 

    }
}
