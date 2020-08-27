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
    [ApiController]
    [Route("api/platforms")]
    public class PlatformsController : ControllerBase
    {
        private readonly ICommandRepo _repository;
        private readonly IMapper _mapper;

        public PlatformsController(ICommandRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        //GET api/platforms
        [HttpGet]
        public ActionResult<IEnumerable<PlatformReadDto>> GetAllPlatforms(){
            try
            {
                var platforms = _repository.GetAllPlatforms();       
                return Ok(_mapper.Map<IEnumerable<PlatformReadDto>>(platforms));
            }
            catch (System.Exception)
            {
                return NotFound();
            }
        }

        //GET api/platforms/{id}
        [HttpGet("{id}", Name="GetPlatformById")]
        public ActionResult<PlatformReadDto> GetPlatformById(int id){
            try
            {
                var platform = _repository.GetPlatformById(id);

                if(platform == null){
                    return NotFound();
                }

                return Ok(_mapper.Map<PlatformReadDto>(platform));
            }
            catch (System.Exception)
            {
                return NotFound();
            }
        }

        //POST api/platforms
        [HttpPost]
        public ActionResult<PlatformReadDto> CreatePlatform(PlatformCreateDto platformCreate){
            try
            {
                //Validations
                if(platformCreate == null){
                    return NotFound();
                }
                
                //Create
                var platform = _mapper.Map<Platform>(platformCreate);
                _repository.CreatePlatform(platform);
                _repository.SaveChanges();

                //Read
                var platformRead = _repository.GetPlatformById(platform.Id);

                //Response
                return CreatedAtRoute(nameof(GetPlatformById), new { Id = platformRead.Id }, platformRead);
                
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        //DELETE api/platforms/{id}
        [HttpDelete("{id}")]
        public ActionResult DeletePlatform(int id){
            try
            {
                //Validations
                var platform = _repository.GetPlatformById(id);
                if(platform == null){
                    return NotFound();
                }

                //Delete 
                _repository.DeletePlatform(platform);
                _repository.SaveChanges();

                //Response
                return Ok();

            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        //PATCH api/platforms/{id}
        [HttpPatch("{id}")]
        public ActionResult UpdatePlatform(int id, JsonPatchDocument<PlatformUpdateDto> patchDoc){
            try
            {
                //Validations
                var platform = _repository.GetPlatformById(id);
                if(platform == null){
                    return NotFound();
                }

                //Mapper
                var platformToPatch = _mapper.Map<PlatformUpdateDto>(platform);
                patchDoc.ApplyTo(platformToPatch, ModelState);
            
                //Validate model to patch
                if(!TryValidateModel(platformToPatch)){
                    return ValidationProblem(ModelState);
                }

                _mapper.Map(platformToPatch, platform);
                _repository.UpdatePlatform(platform);
                _repository.SaveChanges();

                return Ok();


            }
            catch (System.Exception)
            {
                return NotFound();
            }
        }
    }
}