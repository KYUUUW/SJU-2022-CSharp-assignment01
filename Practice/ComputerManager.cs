using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Practice
{
    class ComputerManager
    {
        // 유저들
        private User[] arrUser;
        // 컴퓨터들
        private Computer[] arrComp;
        // 수익
        private int balance = 0;

        // 유저 생성 시 id 부여 용
        private int studentCnt = 0;
        private int gamerCnt = 0;
        private int officerCnt = 0;

        // 컴퓨터 매니저를 생성할 때 컴퓨터의 수를 받음
       public ComputerManager(int nUsers, int nNotebook, int nDesktop, int nNetbook)
        {
            // 유저 생성시 id 부여용
            int cntUsers = 0;
            // 컴퓨터 생성 시 id 부여용
            int cntCom = 0;
            int cntNotebook = 0;
            int cntDesktop = 0;
            int cntNetbook = 0;

            // 리스트
            var userList = new List<User>();
            var computerList = new List<Computer>();

            for(int i = 0; i < nUsers; i++)
            {
                userList.Add(new User{ id = ++cntUsers});
            }

            for (int i = 0; i < nNetbook; i++)
            {
                computerList.Add(new NetBook { Id = ++cntNetbook, Cid = ++cntCom });
            }
            for(int i = 0; i < nNotebook; i++)
            {
                computerList.Add(new NoteBook { Id = ++cntNotebook, Cid = ++cntCom });
            }
            for (int i = 0; i < nDesktop; i++)
            {
                computerList.Add(new Desktop { Id = ++cntDesktop, Cid = ++cntCom });
            }

            // 요구사항에 따라 배열로 생성
            arrComp = computerList.ToArray();
            arrUser = userList.ToArray();
        }

        // 유저 이름을 
        public User setUserName(int id, string type, string name)
        {
            int idx = -1;
            for(var i = 0; i < arrUser.Length; i++)
            {
                if(arrUser[i].id == id)
                {
                    idx = i;
                    break;
                }
            }
            if(idx == -1)
            {
                throw new Exception("No idx");
            }

            // 유저의 타입을 바꾼다
            if(type == "Student")
            {
                arrUser[idx] = new Student{ id = ++studentCnt, uid = id, Name = name };
            }
            else if (type == "Officer")
            {
                arrUser[idx] = new Officer { id = ++officerCnt, uid = id, Name = name };
            }
            else if (type == "Gamer")
            {
                arrUser[idx] = new Gamer { id = ++gamerCnt, uid = id, Name = name };
            }
            else
            {
                throw new Exception("No category user");
            }
            return arrUser[idx];
        }

        // 컴퓨터를 렌탈 시 자동으로 부여한다.
        public void AssignComputer(int id, int reqDate)
        {
            var user = FindUser(id);
            // 대여되지 않은 컴퓨터 중 조건이 맞는 컴퓨터 중 가장 저렴한 순서로 정렬
            var c1 = arrComp
                .Where(computer => computer.dayRequested <= 0);

            // 컴퓨터의 서비스와 유저의 니즈를 맞춘다
            var c2 = new List<Computer>();
            foreach (var com in c1)
            {
                var isAvailable = true;
                foreach(var need in user.needs)
                {
                    // 하나라도 니즈가 안맞는다면 available 를 false 로
                    if (!com.availableServices.Contains(need)) {
                        isAvailable = false;
                        break;
                    }
                }
                if(isAvailable)
                {
                    c2.Add(com);
                }
            }

           
            // 가격을 싼것으로 정렬
            var c3 = c2
                .OrderBy(comps => comps.price);

            // 컴퓨터를 부여
            user.computer = c3.FirstOrDefault();
            user.computer.StartRent(reqDate);

            File.AppendAllText("./output.txt", $"Computer #{user.computer.Cid} has been assigned to User #{user.uid}" + "\n");
            File.AppendAllText("./output.txt", "===========================================================" + "\n");

        }

        // 컴퓨터 반납
        public void ReturnComputer(int userId)
        {
            // 특정 유저를 찾는다
            var user = FindUser(userId);

            // 대여를 마치고 정산
            var price = user.computer.EndRent();
            balance += price;

            File.AppendAllText("./output.txt", $"User #{user.uid} has returned Computer #{user.computer.Cid} and paid {price} won." + "\n");
            File.AppendAllText("./output.txt", "===========================================================" + "\n");
            user.computer = null;
        }

        public void PrintStatus()
        {
            // 아래는 명세에 나온것을 따름
            File.AppendAllText("./output.txt", $"Total Cost: {balance}" + "\n");
            File.AppendAllText("./output.txt", $"Computer List:" + "\n");
            foreach (var comp in arrComp) 
            {
                var isAvailable = 'Y';
                foreach (var u in arrUser)
                {
                    if (u.computer == comp)
                    {
                        isAvailable = 'N';
                    }
                }
                File.AppendAllText("./output.txt", $"({comp.Cid}) type: {comp.GetInstanceTypeToString()}, ComId: {comp.Cid}, {comp.GetIdType()}:{comp.Id}, Used for: {comp.GetServicesToString()}Avail: {isAvailable}" + "\n");
            }

            File.AppendAllText("./output.txt", $"User List:" + "\n");
            foreach(var u in arrUser)
            {
                var isRent = 'Y';
                if(u.computer != null)
                {
                    isRent = 'N';
                }
                var uid = u.uid;
                var type = u.GetInstanceTypeToString();
                var name = u.Name;
                var tWithId = u.GetTypeWithId();
                var str = $"({uid}) type: {type}, Name: {name}, UserId: {uid}, {u.GetTypeWithId()} Used for: {u.GetServicesToString()} Rent: {isRent}" + "\n";
                File.AppendAllText("./output.txt", str);
            }
            File.AppendAllText("./output.txt", "===========================================================" + "\n");
        }

        // 다음 날로 이동
        public void MoveToNextDay()
        {
            File.AppendAllText("./output.txt", "It has passed one day..." + "\n");
            // 대여일이 지난 컴퓨터가 있는지 확인
            foreach (var user in arrUser)
           {
                var com = user.computer;
                if(com == null)
                {
                    continue;
                }

                var result = com.MoveToNextDay();
                if(result == -1) // 아직 대여 잔여일이 남은 경우
                {
                    continue; 
                }

                // 대여 잔여일이 0일인 경우
                balance += result;

                File.AppendAllText("./output.txt", $"Time for Computer #{com.Cid} has expired. User #{user.uid} has returned Computer #{com.Cid} and paid {result} won." + "\n");
            }
            File.AppendAllText("./output.txt", "===========================================================" + "\n");
        }

        // 특정 id 의 유저를 찾는다
        public User FindUser(int uid)
        {
            var user = arrUser.Where(user => user.uid == uid).FirstOrDefault();
            if(user == null)
            {
                throw new Exception("User not found");
            }
            return user;
        }
    }
}
