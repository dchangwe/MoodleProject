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
    [Route("api/courses/{courseId}/sections")]
    public class SectionsController : Controller
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        public SectionsController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }


        [HttpGet]
        public IActionResult GetSectionsForCourse(Guid courseId)
        {
            var course = _repository.Course.GetCourse(courseId, trackChanges: false);
            if (course == null)
            {
                _logger.LogInfo($"Course with id: {courseId} doesn't exist in the database.");
                return NotFound();
            }

            var sectionsFromDb = _repository.Section.GetSections(courseId, trackChanges: false);
            var sectionDto = _mapper.Map<IEnumerable<SectionDto>>(sectionsFromDb);

            return Ok(sectionDto);
        }
        [HttpGet("{id}")]
        public IActionResult GetSectionForCourse(Guid courseId, Guid id)
        {
            var course = _repository.Course.GetCourse(courseId, trackChanges: false);
            if (course == null)
            {
                _logger.LogInfo($"Course with id: {courseId} doesn't exist in the database.");
                return NotFound();
            }

            var sectionDb = _repository.Section.GetSection(courseId, id, trackChanges: false);
            if (sectionDb == null)
            {
                _logger.LogInfo($"Section with id: {id} doesn't exist in the database.");
                return NotFound();
            }

            var section = _mapper.Map<SectionDto>(sectionDb);

            return Ok(section);
        }
    }
}
