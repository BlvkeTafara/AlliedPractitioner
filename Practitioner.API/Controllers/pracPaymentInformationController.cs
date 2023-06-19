using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Practitioner.Domain.DTOs;
using Practitioner.Domain.Entity;
using Practitioner.Domain.Repository;

namespace Practitioner.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class pracPaymentInformationController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public pracPaymentInformationController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]

        public ActionResult Get()
        {
            var pracpaymentinformationFromRepo = _unitOfWork.PracPaymentInformation.GetAll();
            return Ok(pracpaymentinformationFromRepo);
        }
        [HttpGet("{id}")]
        public ActionResult Getbycode(int id)
        {
            var pracpaymentinformationFromRepo = _unitOfWork.PracPaymentInformation.GetById(id);
            return Ok(pracpaymentinformationFromRepo);
        }
        [HttpPost("Create")]
        public ActionResult Post(PracPaymentInformationDto data)
        {
            _unitOfWork.PracPaymentInformation.Add(data);

            return Ok();
        }
        [HttpPut("Update")]
        public ActionResult Put(PracPaymentInformationDto data)
        {
            _unitOfWork.PracPaymentInformation.Update(data);

            return Ok();
        }
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _unitOfWork.PracPaymentInformation.Remove(id);

            return Ok();
        }
    }
}
