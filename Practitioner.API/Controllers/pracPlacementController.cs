using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Practitioner.Domain.DTOs;
using Practitioner.Domain.Repository;

namespace Practitioner.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class pracPlacementController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public pracPlacementController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]

        public ActionResult Get()
        {
            var pracplacementFromRepo = _unitOfWork.PracPlacement.GetAll();
            return Ok(pracplacementFromRepo);
        }
        [HttpGet("{id}")]
        public ActionResult Getbycode(int id)
        {
            var pracplacementFromRepo = _unitOfWork.PracPlacement.GetById(id);
            return Ok(pracplacementFromRepo);
        }
        [HttpPost("Create")]
        public ActionResult Post(PracPlacementDto data)
        {
            _unitOfWork.PracPlacement.Add(data);

            return Ok();
        }
        [HttpPut("Update")]
        public ActionResult Put(PracPlacementDto data)
        {
            _unitOfWork.PracPlacement.Update(data);

            return Ok();
        }
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _unitOfWork.PracPlacement.Remove(id);

            return Ok();
        }
    }
}
