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
using Moodle.ModelBinders;
using Microsoft.AspNetCore.Mvc.ModelBinding;
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
        public  IActionResult CreateCourse([FromBody]CourseForCreationDto course)
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
        [HttpGet("collection/({ids})", Name = "CourseCollection")]
        public IActionResult GetCourseCollection([ModelBinder(BinderType = typeof(ArrayModelBinder))]IEnumerable<Guid> ids)
        //public IActionResult GetCourseCollection(IEnumerable<Guid> ids)
        {
            if (ids == null) 
            { 
                _logger.LogError("Parameter ids is null");
                return BadRequest("Parameter ids is null"); 
            }

            var courseEntities = _repository.Course.GetByIds(ids, trackChanges: false);

            if (ids.Count() != courseEntities.Count())
            { 
                _logger.LogError("Some ids are not valid in a collection"); 
                return NotFound(); 
            }

            var coursesToReturn = _mapper.Map<IEnumerable<CourseDto>>(courseEntities); 
            return Ok(coursesToReturn);
        }
        [HttpPost("collection")]
        public IActionResult CreateCompanyCollection([FromBody] IEnumerable<CourseForCreationDto> courseCollection)
        {
            if (courseCollection == null) 
            { 
                _logger.LogError("Course collection sent from client is null."); 
                return BadRequest("Course collection is null"); 
            }

            var courseEntities = _mapper.Map<IEnumerable<Course>>(courseCollection); 
            foreach (var course in courseEntities) 
            { 
                _repository.Course.CreateCourse(course); 
            }

            _repository.Save();

            var courseCollectionToReturn = _mapper.Map<IEnumerable<CourseDto>>(courseEntities); 
            var ids = string.Join(",", courseCollectionToReturn.Select(c => c.Id));

            return CreatedAtRoute("CourseCollection", new { ids }, courseCollectionToReturn);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteCourse(Guid id)
        {
            var course = _repository.Course.GetCourse(id, trackChanges: false); 
            if (course == null) 
            { 
                _logger.LogInfo($"Course with id: {id} doesn't exist in the database."); 
                return NotFound();
            }

            _repository.Course.DeleteCourse(course); 
            _repository.Save();

            return NoContent();
        }
        [HttpPut("{id}")]
        public IActionResult UpdateCourse(Guid id, [FromBody] CourseForUpdateDto course)
        {
            if (course == null)
            {
                _logger.LogError("CourseForUpdateDto object sent from client is null.");
                return BadRequest("CourseForUpdateDto object is null");
            }
            var courseEntity = _repository.Course.GetCourse(id, trackChanges: true);
            if (courseEntity == null)
            {
                _logger.LogInfo($"Course with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            _mapper.Map(course, courseEntity);
            _repository.Save();
            return NoContent();
        }
    }
}
