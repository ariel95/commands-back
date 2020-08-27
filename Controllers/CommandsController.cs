using System;
using System.Collections.Generic;
using AutoMapper;
using Commands.Data;
using Commands.DTOs;
using Commands.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Commands.Controllers
{
    [Route("/api/commands")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly ICommandRepo _repository;
        private IMapper _mapper;

        public CommandsController(ICommandRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        //GET api/commands
        [HttpGet]
        public ActionResult<IEnumerable<CommandReadDto>> GetAllCommands()
        {
            try
            {
                var commands = _repository.GetAllCommands();
                return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(commands));
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        //GET api/commands/{id}
        [HttpGet("{id}", Name = "GetCommandById")]
        public ActionResult<CommandReadDto> GetCommandById(int id)
        {
            try
            {
                var command = _repository.GetCommandById(id);
                if (command == null)
                {
                    return NotFound();
                }

                return Ok(_mapper.Map<CommandReadDto>(command));
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        //POST api/commands
        [HttpPost]
        public ActionResult<CommandReadDto> CreateCommand(CommandCreateDto commandCreate)
        {
            try
            {
                //Get platform
                var platform = _repository.GetPlatformById(commandCreate.PlatformId);
                if(platform == null){
                    return NotFound();
                }

                //Maper
                var commandModel = _mapper.Map<Command>(commandCreate);
                commandModel.Platform = platform;

                //Create
                _repository.CreateCommand(commandModel);
                _repository.SaveChanges();

                //Read
                var commandReadDto = _mapper.Map<CommandReadDto>(commandModel);
                return CreatedAtRoute(nameof(GetCommandById), new { Id = commandReadDto.Id }, commandReadDto);
                // return Created(commandReadDto, );

            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        //DELETE api/commands/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteCommand(int id)
        {
            try
            {
                //Validation
                var commandModel = _repository.GetCommandById(id);
                if (commandModel == null)
                {
                    return NotFound();
                }

                //Delete
                _repository.DeleteCommand(commandModel);
                _repository.SaveChanges();

                return Ok();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        //PATCH api/commands/{id}
        [HttpPatch("{id}")]
        public ActionResult UpdateCommand(int id, JsonPatchDocument<CommandUpdateDto> patchDoc)
        {
            try
            {
                //Validation
                var commandModel = _repository.GetCommandById(id);
                if (commandModel == null)
                {
                    return NotFound();
                }

                var commandToPatch = _mapper.Map<CommandUpdateDto>(commandModel);

                patchDoc.ApplyTo(commandToPatch, ModelState);
            
                //Validate model to patch
                if(!TryValidateModel(commandToPatch)){
                    return ValidationProblem(ModelState);
                }

                _mapper.Map(commandToPatch, commandModel);
                
                _repository.UpdateCommand(commandModel);

                _repository.SaveChanges();

                return Ok();
            }
            catch (Exception e)
            {
                throw e;
            }

        }
    }

}