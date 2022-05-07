using System;
using System.IO;

namespace Practice
{
    class CommandParser
    {
        // 컴퓨터 매니저
        public ComputerManager manager { get; init; }
        private int userCnt = 0;
        // 새로운 유저를 등록하는 input stream 파싱
        public void ParseNewUserInput(string input)
        {
            var splited = input.Split(' '); // 띄어쓰기로 나누기
            var type = splited[0]; // 직업
            var name = splited[1]; // 이름

            // 유저에게 등록
            if (type == "Student")
            {
                manager.setUserName(++userCnt, "Student", name);
            }
            else if (type == "Gamer")
            {
                manager.setUserName(++userCnt, "Gamer", name);
            }
            else if (type == "Worker")
            {
                manager.setUserName(++userCnt, "Officer", name);
            }
            else
            {
                // 잘못된 직업 입력
                Console.WriteLine("./output.txt", "Wrong Input");
            }
        }

        // 명령어 Line 파싱해서 실행
        public int Execute(string input)
        {
            // 종료
            if (input[0] == 'Q')
            {
                return -1;
            }

            // 컴퓨터 대여
            if (input[0] == 'A')
            {
                var splited = input.Split(' ');
                int userId = Int32.Parse(splited[1]);
                int days = Int32.Parse(splited[2]);

                manager.AssignComputer(userId, days);
            }

            // 다음날로 이동
            if (input[0] == 'T')
            {
                manager.MoveToNextDay();
            }

            // 상태 프린트
            if (input[0] == 'S')
            {
                manager.PrintStatus();
            }

            // 컴퓨터 반납
            if (input[0] == 'R')
            {
                var splited = input.Split(' ');
                int userId = Int32.Parse(splited[1]);

                manager.ReturnComputer(userId);
            }
            return 0;
        }
    }
}
