using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Practitioner.Domain.DTOs;
using Practitioner.Domain.Repository;

namespace Practitioner.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class pracDocumentController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public pracDocumentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]

        public ActionResult Get()
        {
            var pracdocumentFromRepo = _unitOfWork.PracDocument.GetAll();
            return Ok(pracdocumentFromRepo);
        }
        [HttpGet("{id}")]
        public ActionResult Getbycode(int id)
        {
            var pracdocumentFromRepo = _unitOfWork.PracDocument.GetById(id);
            return Ok(pracdocumentFromRepo);
        }
        [HttpPost("Create")]
        public ActionResult Post(PracDocumentDto data)
        {
            _unitOfWork.PracDocument.Add(data);

            return Ok();
        }
        [HttpPut("Update")]
        public ActionResult Put(PracDocumentDto data)
        {
            _unitOfWork.PracDocument.Update(data);

            return Ok();
        }
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _unitOfWork.PracDocument.Remove(id);

            return Ok();
        }
    }
}
