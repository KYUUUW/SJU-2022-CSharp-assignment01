using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    class User
    {
        // 유저 별 id
        public int id { get; init; }
        // 유저 전체의  id
        public int uid { get; init; }
        // 이름
        public string Name { get; init; }
        // 유저가 컴퓨터를 대여했다면 null 이 아님ㄷ
        public Computer? computer;
        // 사용자가 사용 할 서비스들의 등록
        public Computer.Services[] needs = { };

        // 서브클래스의 타입을 return
        public string GetInstanceTypeToString()
        {
            if (this is Student)
            {
                return "Students";
            }
            else if (this is Officer)
            {
                return "OfficeWorkers";
            }
            else if (this is Gamer)
            {
                return "Gamers";
            }
            else
            {
                return "Not Defined";
            }
        }

        // 서브클래스 타입의 id 를포함한 id
        public string GetTypeWithId()
        {
            if (this is Student)
            {
                return $"StuId: {id},";
            }
            else if (this is Officer)
            {
                return $"WorkerId: {id},";
            }
            else if (this is Gamer)
            {
                return $"GamerId: {id},";
            }
            else
            {
                return "Not Defined";
            }
        }

        // 서비스 종류에 대한 string
        public string GetServicesToString()
        {
            var services = "";
            if (needs.Contains(Computer.Services.Internet))
            {
                services += "internet, ";
            }
            if (needs.Contains(Computer.Services.Scientific))
            {
                services += "scientific, ";
            }
            if (needs.Contains(Computer.Services.Game))
            {
                services += "game, ";
            }
            return services;
        }
    }
}

