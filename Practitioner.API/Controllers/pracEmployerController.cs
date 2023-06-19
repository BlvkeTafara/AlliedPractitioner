using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Practitioner.Domain.DTOs;
using Practitioner.Domain.Repository;

namespace Practitioner.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class pracEmployerController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public pracEmployerController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]

        public ActionResult Get()
        {
            var pracemployerFromRepo = _unitOfWork.PracEmployer.GetAll();
            return Ok(pracemployerFromRepo);
        }
        [HttpGet("{id}")]
        public ActionResult Getbycode(int id)
        {
            var pracemployerFromRepo = _unitOfWork.PracEmployer.GetById(id);
            return Ok(pracemployerFromRepo);
        }
        [HttpPost("Create")]
        public ActionResult Post(PracEmployerDto data)
        {
            _unitOfWork.PracEmployer.Add(data);

            return Ok();
        }
        [HttpPut("Update")]
        public ActionResult Put(PracEmployerDto data)
        {
            _unitOfWork.PracEmployer.Update(data);

            return Ok();
        }
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _unitOfWork.PracEmployer.Remove(id);

            return Ok();
        }
    }
}
