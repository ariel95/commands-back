using System.Collections.Generic;
using Commands.Models;

namespace Commands.Data
{
    public class MockCommandRepo : ICommandRepo
    {
        private List<Command> _repository = new List<Command> {
            new Command() { Id = 1, HowTo = "Hola1Howto", Line = "Hola1Line", Platform = "Net Core" },
            new Command() { Id = 2, HowTo = "Hola2Howto", Line = "Hola2Line", Platform = "Net Core" },
            new Command() { Id = 3, HowTo = "Hola3Howto", Line = "Hola3Line", Platform = "Net Core" }
        };

        public void AddCommand(Command command)
        {
            throw new System.NotImplementedException();
        }

        public void CreateCommand(Command command)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteCommand(Command command)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Command> GetAllCommands()
        {
            return _repository;
        }

        public Command GetCommandById(int id)
        {
            return _repository.Find(x => x.Id == id);
        }

        public bool SaveChanges()
        {
            throw new System.NotImplementedException();
        }

        public void UpdateCommand(Command command)
        {
            throw new System.NotImplementedException();
        }
    }
}