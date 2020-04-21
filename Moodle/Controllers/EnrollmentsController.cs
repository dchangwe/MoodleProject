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
    //[Route("api/users/{userId}/sections/{sectionId}/enrollments")]
    [Route("api/[controller]")]
    public class EnrollmentsController : Controller
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        public EnrollmentsController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }
        [HttpGet]
       
        public IActionResult GetEnrollments()
        {
            //throw new Exception("Exception");
            var enrollments = _repository.Enrollment.GetAllEnrollments(trackChanges: false);

            var enrollmentsDto = _mapper.Map<IEnumerable<EnrollmentDto>>(enrollments);

            return Ok(enrollmentsDto);

        }

        //[HttpGet]
        //public IActionResult GetEnrollmentsForUser(Guid userId, Guid sectionId, Guid id)
        //{
        //    var user = _repository.User.GetUser(userId, trackChanges: false);
        //    var section = _repository.Section.GetSection(sectionId, id, trackChanges: false);
        //    if (user == null && section == null)
        //    {
        //        _logger.LogInfo($"User with id: {userId} doesn't exist in the database.");
        //        return NotFound();
        //    }

        //    var enrollmentsFromDb = _repository.Enrollment.GetEnrollments(userId, sectionId, trackChanges: false);
        //    var enrollmentDto = _mapper.Map<IEnumerable<EnrollmentDto>>(enrollmentsFromDb);

        //    return Ok(enrollmentDto);
        //}
        //[HttpGet("{id}")]
        //public IActionResult GetEmployeeForCompany(Guid userId, Guid id, Guid sectionId)
        //{
        //    var user = _repository.User.GetUser(userId, trackChanges: false) ;
        //    var section = _repository.Section.GetSection(sectionId, id, trackChanges: false);
        //    if (user == null && section == null)
        //    {
        //        _logger.LogInfo($"user with id: {userId} doesn't exist in the database.");
        //        return NotFound();
        //    }

        //    var enrollmentDb = _repository.Enrollment.GetEnrollment(userId, sectionId, id, trackChanges: false);
        //    if (enrollmentDb == null)
        //    {
        //        _logger.LogInfo($"Enrollment with id: {id} doesn't exist in the database.");
        //        return NotFound();
        //    }

        //    var enrollment = _mapper.Map<EnrollmentDto>(enrollmentDb);

        //    return Ok(enrollment);
        //}
    }
}
