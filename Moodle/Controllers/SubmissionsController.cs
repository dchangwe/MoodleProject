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
    [Route("api/[controller]")]
    public class SubmissionsController : Controller
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public SubmissionsController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetSubmissions()
        {
            
                var submissions = _repository.Submission.GetAllSubmissions(trackChanges: false);
                var submissionsDto = _mapper.Map<IEnumerable<SubmissionDto>>(submissions);

                return Ok(submissionsDto);

                
           
        }
    }
}
