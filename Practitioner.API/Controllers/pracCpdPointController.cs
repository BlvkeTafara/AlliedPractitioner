using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Practitioner.Domain.DTOs;
using Practitioner.Domain.Repository;

namespace Practitioner.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class pracCpdPointController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public pracCpdPointController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]

        public ActionResult Get()
        {
            var praccpdpointFromRepo = _unitOfWork.PracCpdPoint.GetAll();
            return Ok(praccpdpointFromRepo);
        }
        [HttpGet("{id}")]
        public ActionResult Getbycode(int id)
        {
            var praccpdpointFromRepo = _unitOfWork.PracCpdPoint.GetById(id);
            return Ok(praccpdpointFromRepo);
        }
        [HttpPost("Create")]
        public ActionResult Post(PracCpdPointDto data)
        {
            _unitOfWork.PracCpdPoint.Add(data);

            return Ok();
        }
        [HttpPut("Update")]
        public ActionResult Put(PracCpdPointDto data)
        {
            _unitOfWork.PracCpdPoint.Update(data);

            return Ok();
        }
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _unitOfWork.PracCpdPoint.Remove(id);

            return Ok();
        }
    }
}
