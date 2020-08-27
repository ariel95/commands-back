using System.Collections.Generic;
using Commands.Models;

namespace Commands.Data
{
    public interface ICommandRepo
    {
        bool SaveChanges();

        //COMMANDS
        IEnumerable<Command> GetAllCommands();
        Command GetCommandById(int id);
        void CreateCommand(Command command);
        void DeleteCommand(Command command);
        void UpdateCommand(Command command); 

        //PLATFORMS
        IEnumerable<Platform> GetAllPlatforms();
        Platform GetPlatformById(int id);
        void CreatePlatform(Platform platform);
        void DeletePlatform(Platform platform);
        void UpdatePlatform(Platform platform); 
    } 
}