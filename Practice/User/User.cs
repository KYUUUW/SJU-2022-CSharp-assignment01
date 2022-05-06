using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    class User
    {
        public int id { get; init; }
        public int uid { get; init; }
        public string Name { get; init; }
        public Computer? computer;
        public Computer.Services[] needs = { };

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

        public string GetUsages()
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

