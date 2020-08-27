using System;
using System.Collections.Generic;
using System.Linq;
using Commands.Models;
using Microsoft.EntityFrameworkCore;

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

        #region Command
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
            return _repository.Commands.Include(x=>x.Platform).ToList();
        }

        public Command GetCommandById(int id)
        {
            return _repository.Commands.Include(x=>x.Platform).FirstOrDefault(x => x.Id == id);
        }

        public void UpdateCommand(Command command)
        {
            _repository.Commands.Update(command);
        }

        #endregion

        #region Platform
        public IEnumerable<Platform> GetAllPlatforms()
        {
            return _repository.Platforms.ToList();
        }

        public Platform GetPlatformById(int id)
        {
            return _repository.Platforms.FirstOrDefault(x=>x.Id == id);
        }

        public void CreatePlatform(Platform platform)
        {
            _repository.Platforms.Add(platform);
        }

        public void DeletePlatform(Platform platform)
        {
            _repository.Platforms.Remove(platform);
        }

        public void UpdatePlatform(Platform platform)
        {
             _repository.Platforms.Update(platform);
        }
        #endregion
    }
}