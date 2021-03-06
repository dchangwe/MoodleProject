﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Contracts;
using AutoMapper;
using Entities.DataTransferObject;
using Entities.Models;
using Microsoft.AspNetCore.JsonPatch;

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
        [HttpGet("{id}" , Name = "GetAssignmentForCourse")]
        public IActionResult GetAssignmentForCourse(Guid courseId, Guid id)
        {
            var course = _repository.Course.GetCourse(courseId, trackChanges: false);
            if (course == null)
            {
                _logger.LogInfo($"Course with id: {courseId} doesn't exist in the database.");
                return NotFound();
            }

            var assignmentDb = _repository.Assignment.GetAssignment(courseId, id, trackChanges: false);
            if (assignmentDb == null)
            {
                _logger.LogInfo($"Assignment with id: {id} doesn't exist in the database.");
                return NotFound();
            }

            var assignment = _mapper.Map<AssignmentDto>(assignmentDb);

            return Ok(assignment);
        }
        [HttpPost]
        public IActionResult CreateAssignmentForCourse(Guid courseId, [FromBody] AssignmentForCreationDto assignment)
        {
            if (assignment == null)
            {
                _logger.LogError("AssignmentForCreationDto object sent from client is null.");
                return BadRequest("AssignmentForCreationDto object is null");
            }

            var course = _repository.Course.GetCourse(courseId, trackChanges: false);
            if (course == null)
            {
                _logger.LogInfo($"Course with id: {courseId} doesn't exist in the database.");
                return NotFound();
            }

            var assignmentEntity = _mapper.Map<Assignment>(assignment);
            _repository.Assignment.CreateAssignmentForCourse(courseId, assignmentEntity);
            _repository.Save();
            var assignmentToReturn = _mapper.Map<AssignmentDto>(assignmentEntity);

            return CreatedAtRoute("GetAssignmentForCourse", new { courseId, id = assignmentToReturn.Id },assignmentToReturn);
        
    }
        [HttpDelete("{id}")]
        public IActionResult DeleteAssignmentForCourse(Guid courseId, Guid id)
        {
            var course = _repository.Course.GetCourse(courseId, trackChanges: false); 
            if (course == null) 
            { 
                _logger.LogInfo($"Course with id: {courseId} doesn't exist in the database."); 
                return NotFound();
            }

            var assignmentForCourse = _repository.Assignment.GetAssignment(courseId, id, trackChanges: false); 
            if (assignmentForCourse == null)
            { 
                _logger.LogInfo($"Assignment with id: {id} doesn't exist in the database.");
                return NotFound();
            }

            _repository.Assignment.DeleteAssignment(assignmentForCourse); 
            _repository.Save();

            return NoContent();
        }
        [HttpPut("{id}")]
        public IActionResult UpdateAssignmentForCourse(Guid courseId, Guid id, [FromBody] AssignmentForUpdateDto assignment)
        {
            if (assignment == null)
            { 
                _logger.LogError("AssignmentForUpdateDto object sent from client is null."); 
                return BadRequest("AssignmentForUpdateDto object is null"); 
            }

            var course = _repository.Course.GetCourse(courseId, trackChanges: false); 
            if (course == null)
            { 
                _logger.LogInfo($"Course with id: {courseId} doesn't exist in the database."); 
                return NotFound(); 
            }

            var assignmentEntity = _repository.Assignment.GetAssignment(courseId, id, trackChanges: true); 
            if (assignmentEntity == null) 
            { 
                _logger.LogInfo($"Assignment with id: {id} doesn't exist in the database."); 
                return NotFound(); 
            }

            _mapper.Map(assignment, assignmentEntity); 
            _repository.Save();

            return NoContent();
        }
        [HttpPatch("{id}")]
        public IActionResult PartiallyUpdateEmployeeForCompany(Guid courseId, Guid id, [FromBody] JsonPatchDocument<AssignmentForUpdateDto> patchDoc)
        {
            if (patchDoc == null)
            {
                _logger.LogError("patchDoc object sent from client is null."); 
                return BadRequest("patchDoc object is null"); }

            var course = _repository.Course.GetCourse(courseId, trackChanges: false); 
            if (course == null) 
            { 
                _logger.LogInfo($"Course with id: {courseId} doesn't exist in the database.");
                return NotFound(); }

            var assignmentEntity = _repository.Assignment.GetAssignment(courseId, id, trackChanges: true);
            if (assignmentEntity == null) 
            { 
                _logger.LogInfo($"Assignment with id: {id} doesn't exist in the database."); 
                return NotFound(); }

            var assignmentToPatch = _mapper.Map<AssignmentForUpdateDto>(assignmentEntity);

            patchDoc.ApplyTo(assignmentToPatch);

            _mapper.Map(assignmentToPatch, assignmentEntity);

            _repository.Save();

            return NoContent();
        }
        }
}

