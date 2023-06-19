using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Practitioner.Domain.DTOs;
using Practitioner.Domain.Repository;

namespace Practitioner.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class pracRequirementController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public pracRequirementController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]

        public ActionResult Get()
        {
            var pracrequirementFromRepo = _unitOfWork.PracRequirement.GetAll();
            return Ok(pracrequirementFromRepo);
        }
        [HttpGet("{id}")]
        public ActionResult Getbycode(int id)
        {
            var pracrequirementFromRepo = _unitOfWork.PracRequirement.GetById(id);
            return Ok(pracrequirementFromRepo);
        }
        [HttpPost("Create")]
        public ActionResult Post(PracRequirementDto data)
        {
            _unitOfWork.PracRequirement.Add(data);

            return Ok();
        }
        [HttpPut("Update")]
        public ActionResult Put(PracRequirementDto data)
        {
            _unitOfWork.PracRequirement.Update(data);

            return Ok();
        }
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _unitOfWork.PracRequirement.Remove(id);

            return Ok();
        }
    }
}
