using System;
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
    public class CoursesController : Controller
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public CoursesController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetCourses()
        {
           
                var courses = _repository.Course.GetAllCourses(trackChanges: false);
                var courseDto = _mapper.Map<IEnumerable<CourseDto>>(courses);
                //var courseDto = courses.Select(c => new CourseDto { Id = c.Id, Course = string.Join(' ', c.CourseName, c.Description) }).ToList();

                return Ok(courseDto);
            
        }
        [HttpGet("{id}", Name = "CourseById")]
        public IActionResult GetCourse(Guid id)
        {
            var course = _repository.Course.GetCourse(id, trackChanges: false);
            if (course == null)
            {
                _logger.LogInfo($"Course with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            else
            {
                var courseDto = _mapper.Map<CourseDto>(course);
                return Ok(courseDto);
            }
        }
        [HttpPost]
        public IActionResult CreateCourse([FromBody]CourseForCreationDto course)
        {
            if (course == null)
            {
                _logger.LogError("CourseForCreationDto object sent from client is null.");
                return BadRequest("CourseForCreationDto object is null");
            }

            var courseEntity = _mapper.Map<Course>(course);

            _repository.Course.CreateCourse(courseEntity); 
            _repository.Save();

            var courseToReturn = _mapper.Map<CourseDto>(courseEntity);

            return CreatedAtRoute("CourseById", new { id = courseToReturn.Id }, 
                courseToReturn);
        }
    }
}
