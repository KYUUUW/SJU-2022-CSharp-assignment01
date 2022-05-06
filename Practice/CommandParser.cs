using System;

namespace Practice
{
    class CommandParser
    {
        public ComputerManager manager { get; init; }
        private int userCnt = 0;
        public void ParseNewUserInput(string input)
        {
            var splited = input.Split(' ');
            var type = splited[0];
            var name = splited[1];
            Console.WriteLine(type);
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
                Console.WriteLine("Wrong Input");
            }
        }

        public int Execute(string input)
        {
            if (input[0] == 'Q')
            {
                return -1;
            }

            if (input[0] == 'A')
            {
                var splited = input.Split(' ');
                int userId = Int32.Parse(splited[1]);
                int days = Int32.Parse(splited[2]);

                manager.AssignComputer(userId, days);
            }

            if (input[0] == 'T')
            {
                manager.MoveToNextDay();
            }

            if (input[0] == 'S')
            {
                manager.PrintStatus();
            }

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
