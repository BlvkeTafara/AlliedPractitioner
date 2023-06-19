using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Practitioner.Domain.DTOs;
using Practitioner.Domain.Repository;

namespace Practitioner.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class pracQualificationController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public pracQualificationController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]

        public ActionResult Get()
        {
            var pracqualificationFromRepo = _unitOfWork.PracQualification.GetAll();
            return Ok(pracqualificationFromRepo);
        }
        [HttpGet("{id}")]
        public ActionResult Getbycode(int id)
        {
            var pracqualificationFromRepo = _unitOfWork.PracQualification.GetById(id);
            return Ok(pracqualificationFromRepo);
        }
        [HttpPost("Create")]
        public ActionResult Post(PracQualificationDto data)
        {
            _unitOfWork.PracQualification.Add(data);

            return Ok();
        }
        [HttpPut("Update")]
        public ActionResult Put(PracQualificationDto data)
        {
            _unitOfWork.PracQualification.Update(data);

            return Ok();
        }
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _unitOfWork.PracQualification.Remove(id);

            return Ok();
        }
    }
}
