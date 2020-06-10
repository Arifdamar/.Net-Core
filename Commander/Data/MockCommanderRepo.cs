using System.Collections.Generic;
using Commander.Models;

namespace Commander.Data
{
    public class MockCommanderRepo : ICommanderRepo
    {
        public IEnumerable<Command> GetAll()
        {
            var commands = new List<Command>
            {
                new Command { Id = 1, HowTo = "Boil an egg", Line = "Boil water", Platform = "Kettle & Pan" },
                new Command { Id = 2, HowTo = "Cut bread", Line = "Get a knife", Platform = "Knife & Chopping Board" },
                new Command { Id = 3, HowTo = "Make a cup of tea", Line = "Place teabag in cup", Platform = "Kettle & Cup" }
            };

            return commands;
        }

        public Command GetCommandById()
        {
            return new Command { Id = 1, HowTo = "Boil an egg", Line = "Boil water", Platform = "Kettle & Pan" };
        }
    }
}