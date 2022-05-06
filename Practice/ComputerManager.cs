using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    class ComputerManager
    {
        private User[] arrUser;
        private Computer[] arrComp;
        private int balance = 0;

        private int studentCnt = 0;
        private int gamerCnt = 0;
        private int officerCnt = 0;

       public ComputerManager(int nUsers, int nNotebook, int nDesktop, int nNetbook)
        {
            int cntUsers = 0;
            int cntCom = 0;
            int cntNotebook = 0;
            int cntDesktop = 0;
            int cntNetbook = 0;

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

            arrComp = computerList.ToArray();
            arrUser = userList.ToArray();
        }

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

        public void AssignComputer(int id, int reqDate)
        {
            var user = FindUser(id);
            // 대여되지 않은 컴퓨터 중 조건이 맞는 컴퓨터 중 가장 저렴한 순서로 정렬
            var c1 = arrComp
                .Where(computer => computer.dayRequested <= 0);
            var c2 = new List<Computer>();
            foreach (var com in c1)
            {
                var isAvailable = true;
                foreach(var need in user.needs)
                {
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

           
            var c3 = c2
                .OrderBy(comps => comps.price);

            user.computer = c3.FirstOrDefault();
            user.computer.StartRent(reqDate);

            Console.WriteLine($"Computer #{user.computer.Cid} has been assigned to User #{user.uid}");
            Console.WriteLine("===========================================================");

        }

        public void ReturnComputer(int userId)
        {
            var user = FindUser(userId);

            var price = user.computer.EndRent();
            balance += price;

            Console.WriteLine($"User #{user.uid} has returned Computer #{user.computer.Cid} and paid {price} won.");
            Console.WriteLine("===========================================================");
            user.computer = null;
        }

        public void PrintStatus()
        {
            Console.WriteLine($"Total Cost: {balance}");
            Console.WriteLine($"Computer List:");
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
                Console.WriteLine($"({comp.Cid}) type: {comp.GetInstanceTypeToString()}, ComId: {comp.Cid}, {comp.GetIdType()}:{comp.Id}, Used for: {comp.GetServicesToString()}Avail: {isAvailable}");
            }

            Console.WriteLine($"User List:");
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
                var str = $"({uid}) type: {type}, Name: {name}, UserId: {uid}, {u.GetTypeWithId()} Used for: {u.GetServicesToString()} Rent: {isRent}";
                Console.WriteLine(str);
            }
            Console.WriteLine("===========================================================");
        }

        public void MoveToNextDay()
        {
            Console.WriteLine("It has passed one day...");
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

                Console.WriteLine($"Time for Computer #{com.Cid} has expired. User #{user.uid} has returned Computer #{com.Cid} and paid {result} won.");
            }
            Console.WriteLine("===========================================================");
        }

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
