﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Contracts;
using Entities.DataTransferObject;
using AutoMapper;
using Repository;
using Entities.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Moodle.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public UsersController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            //throw new Exception("Exception");
            var users = _repository.User.GetAllUsers(trackChanges: false);

            var usersDto = _mapper.Map<IEnumerable<UserDto>>(users);

            return Ok(usersDto);

        }
        [HttpGet("{id}", Name = "UserById")]
        public IActionResult GetUser(Guid id)
        {
            var user = _repository.User.GetUser(id, trackChanges: false);
            if (user == null)
            {
                _logger.LogInfo($"User with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            else
            {
                var userDto = _mapper.Map<UserDto>(user);
                return Ok(userDto);
            }
        }


        [HttpPost]
        public IActionResult CreateUser([FromBody]UserForCreationDto user)
        {
            if (user == null)
            {
                _logger.LogError("UserForCreationDto object sent from client is null.");

                return BadRequest("UserForCreationDto object is null");
            }


            var userEntity = _mapper.Map<User>(user);

            _repository.User.CreateUser(userEntity);
            _repository.Save();

            var userToReturn = _mapper.Map<UserDto>(userEntity);

            return CreatedAtRoute("UserById", new
            {
                id = userToReturn.Id
            }, userToReturn);
        }
    }
}