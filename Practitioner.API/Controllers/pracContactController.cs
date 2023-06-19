using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Practitioner.Domain.DTOs;
using Practitioner.Domain.Repository;

namespace Practitioner.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class pracContactController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public pracContactController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]

        public ActionResult Get()
        {
            var praccontactFromRepo = _unitOfWork.PracContact.GetAll();
            return Ok(praccontactFromRepo);
        }
        [HttpGet("{id}")]
        public ActionResult Getbycode(int id)
        {
            var praccontactFromRepo = _unitOfWork.PracContact.GetById(id);
            return Ok(praccontactFromRepo);
        }
        [HttpPost("Create")]
        public ActionResult Post(PracContactDto data)
        {
            _unitOfWork.PracContact.Add(data);

            return Ok();
        }
        [HttpPut("Update")]
        public ActionResult Put(PracContactDto data)
        {
            _unitOfWork.PracContact.Update(data);

            return Ok();
        }
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _unitOfWork.PracContact.Remove(id);

            return Ok();
        }
    }
}
