using System;
using System.IO;

namespace Practice
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllText("./input.txt");
            var cmds = input.Split("\n");
            var nComs = Int32.Parse(cmds[0]);
            var nComTypes = cmds[1].Split(" ");

            var nNotebook = Int32.Parse(nComTypes[0]);
            var nDesktop = Int32.Parse(nComTypes[1]);
            var nNetbook = Int32.Parse(nComTypes[2]); 

            var nUsers = Int32.Parse(cmds[2]);

            File.WriteAllText("./output.txt", "");
            var manager = new ComputerManager(nUsers, nNotebook, nDesktop, nNetbook);
            var parser = new CommandParser { manager = manager };

            for(var i = 3; i < 3 + nUsers; i++)
            {
                parser.ParseNewUserInput(cmds[i]);
            }

            for (var i = 3 + nUsers; i < cmds.Length; i++) {
                var result = parser.Execute(cmds[i]);
                if(result == -1)
                {
                    return;
                }
            }
        }
    }
}
