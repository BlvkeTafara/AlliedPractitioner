using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Practitioner.Domain.DTOs;
using Practitioner.Domain.Repository;

namespace Practitioner.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class pracBalanceController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public pracBalanceController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]

        public ActionResult Get()
        {
            var pracbalanceFromRepo = _unitOfWork.PracBalance.GetAll();
            return Ok(pracbalanceFromRepo);
        }
        [HttpGet("{id}")]
        public ActionResult Getbycode(int id)
        {
            var pracbalanceFromRepo = _unitOfWork.PracBalance.GetById(id);
            return Ok(pracbalanceFromRepo);
        }
        [HttpPost("Create")]
        public ActionResult Post(PracBalanceDto data)
        {
            _unitOfWork.PracBalance.Add(data);

            return Ok();
        }
        [HttpPut("Update")]
        public ActionResult Put(PracBalanceDto data)
        {
            _unitOfWork.PracBalance.Update(data);

            return Ok();
        }
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _unitOfWork.PracBalance.Remove(id);

            return Ok();
        }
    }
}
