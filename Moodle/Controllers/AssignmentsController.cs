using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Contracts;
using AutoMapper;
using Entities.DataTransferObject;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Moodle.Controllers
{
    [Route("api/courses/{courseId}/assignments")]
    public class AssignmentsController : Controller
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;


        public AssignmentsController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAssignmentsForCourse(Guid courseId)
        {
            var course = _repository.Course.GetCourse(courseId, trackChanges: false);
            if (course == null)
            {
                _logger.LogInfo($"Course with id: {courseId} doesn't exist in the database.");
                return NotFound();
            }

            var assignmentsFromDb = _repository.Assignment.GetAssignments(courseId, trackChanges: false);
            var assignmentDto = _mapper.Map<IEnumerable<AssignmentDto>>(assignmentsFromDb);

            return Ok(assignmentDto);
        }
        [HttpGet("{id}")]
        public IActionResult GetAssignmentForCourse(Guid courseId, Guid id)
        {
            var course = _repository.Course.GetCourse(courseId, trackChanges: false); 
            if (course == null) 
            { 
                _logger.LogInfo($"Course with id: {courseId} doesn't exist in the database."); 
                return NotFound(); }

            var assignmentDb = _repository.Assignment.GetAssignment(courseId, id, trackChanges: false); 
            if (assignmentDb == null) 
            { 
                _logger.LogInfo($"Assignment with id: {id} doesn't exist in the database."); 
                return NotFound(); }

            var assignment = _mapper.Map<AssignmentDto>(assignmentDb);

            return Ok(assignment);
        }
    }
}
