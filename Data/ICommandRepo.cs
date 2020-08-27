using System.Collections.Generic;
using Commands.Models;

namespace Commands.Data
{
    public interface ICommandRepo
    {
        bool SaveChanges();
        IEnumerable<Command> GetAllCommands();
        Command GetCommandById(int id);
        void CreateCommand(Command command);
        void DeleteCommand(Command command);
        void UpdateCommand(Command command); 
    } 
}