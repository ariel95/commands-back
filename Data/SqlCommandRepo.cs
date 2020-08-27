using System;
using System.Collections.Generic;
using System.Linq;
using Commands.Models;

namespace Commands.Data
{
    public class SqlCommandRepo : ICommandRepo
    {
        private readonly CommandContext _repository;

        public SqlCommandRepo(CommandContext repository)
        {
            _repository = repository;
        }

        
        public bool SaveChanges()
        {
            return _repository.SaveChanges() >= 0;
        }

        public void CreateCommand(Command command)
        {
            if(command == null){
                throw new ArgumentNullException(nameof(command));
            }

            _repository.Commands.Add(command);
        }

        public void DeleteCommand(Command command)
        {
            if(command == null){
                throw new ArgumentNullException(nameof(command));
            }

            _repository.Commands.Remove(command);
        }

        public IEnumerable<Command> GetAllCommands()
        {
            return _repository.Commands.ToList();
        }

        public Command GetCommandById(int id)
        {
            return _repository.Commands.FirstOrDefault(x => x.Id == id);
        }



        public void UpdateCommand(Command command)
        {
            _repository.Commands.Update(command);
        }
    }
}