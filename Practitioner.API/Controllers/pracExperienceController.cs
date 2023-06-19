using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Practitioner.Domain.DTOs;
using Practitioner.Domain.Repository;

namespace Practitioner.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class pracExperienceController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public pracExperienceController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]

        public ActionResult Get()
        {
            var pracexperienceFromRepo = _unitOfWork.PracExperience.GetAll();
            return Ok(pracexperienceFromRepo);
        }
        [HttpGet("{id}")]
        public ActionResult Getbycode(int id)
        {
            var pracexperienceFromRepo = _unitOfWork.PracExperience.GetById(id);
            return Ok(pracexperienceFromRepo);
        }
        [HttpPost("Create")]
        public ActionResult Post(PracExperienceDto data)
        {
            _unitOfWork.PracExperience.Add(data);

            return Ok();
        }
        [HttpPut("Update")]
        public ActionResult Put(PracExperienceDto data)
        {
            _unitOfWork.PracExperience.Update(data);

            return Ok();
        }
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _unitOfWork.PracExperience.Remove(id);

            return Ok();
        }
    }
}
