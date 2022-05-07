using System;
using System.IO;

namespace Practice
{
    class Program
    {
        static void Main(string[] args)
        {
            // input 을 가져온다
            var input = File.ReadAllText("./input.txt");
                
            // 명령어를 라인 단위로 나눔
            var cmds = input.Split("\n");

            // 컴퓨터의 수 노트북 등등 컴퓨터 종류별 수
            var nComs = Int32.Parse(cmds[0]);
            var nComTypes = cmds[1].Split(" ");

            var nNotebook = Int32.Parse(nComTypes[0]);
            var nDesktop = Int32.Parse(nComTypes[1]);
            var nNetbook = Int32.Parse(nComTypes[2]); 

            // 유저의 수
            var nUsers = Int32.Parse(cmds[2]);

            // 아웃풋 파일 생성
            File.WriteAllText("./output.txt", "");

            // 매니저와 파서 생성
            var manager = new ComputerManager(nUsers, nNotebook, nDesktop, nNetbook);
            var parser = new CommandParser { manager = manager };

            // 유저의 이름과 종류를 정의
            for(var i = 3; i < 3 + nUsers; i++)
            {
                parser.ParseNewUserInput(cmds[i]);
            }

            // 명령어를 라인 단위로 싱행
            for (var i = 3 + nUsers; i < cmds.Length; i++) {
                var result = parser.Execute(cmds[i]);

                // 종료 명령이 나오면 프로그램 종료
                if(result == -1)
                {
                    return;
                }
            }
        }
    }
}
