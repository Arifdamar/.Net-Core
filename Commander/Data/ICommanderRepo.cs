using System.Collections.Generic;
using Commander.Models;

namespace Commander.Data
{
    public interface ICommanderRepo
    {
        IEnumerable<Command> GetAll();
        Command GetCommandById();
    }
}