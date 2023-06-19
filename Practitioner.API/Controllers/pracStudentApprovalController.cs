using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Practitioner.Domain.DTOs;
using Practitioner.Domain.Repository;

namespace Practitioner.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class pracStudentApprovalController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public pracStudentApprovalController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]

        public ActionResult Get()
        {
            var pracstudentapprovalFromRepo = _unitOfWork.PracStudentApproval.GetAll();
            return Ok(pracstudentapprovalFromRepo);
        }
        [HttpGet("{id}")]
        public ActionResult Getbycode(int id)
        {
            var pracstudentapprovalFromRepo = _unitOfWork.PracStudentApproval.GetById(id);
            return Ok(pracstudentapprovalFromRepo);
        }
        [HttpPost("Create")]
        public ActionResult Post(PracStudentApprovalDto data)
        {
            _unitOfWork.PracStudentApproval.Add(data);

            return Ok();
        }
        [HttpPut("Update")]
        public ActionResult Put(PracStudentApprovalDto data)
        {
            _unitOfWork.PracStudentApproval.Update(data);

            return Ok();
        }
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _unitOfWork.PracStudentApproval.Remove(id);

            return Ok();
        }
    }
}
