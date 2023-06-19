using AutoMapper;
using Practitioner.DataAccess.Context;
using Practitioner.Domain.DTOs;
using Practitioner.Domain.Entity;
using Practitioner.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practitioner.DataAccess.Implementation
{
    public class PracStudentApprovalRepository : IPracStudentApprovalRepository
    {
        private readonly AlliedPractitionerDbContext _context;
        private readonly IMapper _mapper;

        public PracStudentApprovalRepository(AlliedPractitionerDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Add(PracStudentApprovalDto dto)
        {
            var entity = _mapper.Map<PracStudentApproval>(dto);
            _context.PracStudentApproval.Add(entity);
            _context.SaveChanges();
        }

        public void AddRange(IEnumerable<PracStudentApprovalDto> dto)
        {
            var entities = _mapper.Map<IEnumerable<PracStudentApproval>>(dto);
            _context.PracStudentApproval.AddRange(entities);
        }

        public IEnumerable<PracStudentApprovalDto> GetAll()
        {
            var entities = _context.PracStudentApproval.ToList();
            var Dtos = _mapper.Map<IEnumerable<PracStudentApprovalDto>>(entities);
            return Dtos;
        }

        public PracStudentApprovalDto GetById(int id)
        {
            var entity = _context.PracStudentApproval.Where(x => x.Id == id).FirstOrDefault();

            var dto = _mapper.Map<PracStudentApprovalDto>(entity);
            return dto;
        }

        public void Remove(int id)
        {
            var pracStudentApprovaldel = _context.PracStudentApproval.Where(pracStudentApproval => pracStudentApproval.Id == id).FirstOrDefault();

            _context.PracStudentApproval.Remove(pracStudentApprovaldel);
            _context.SaveChanges();
        }

        public void RemoveRange(IEnumerable<PracStudentApprovalDto> entities)
        {
            var entitties = _context.PracStudentApproval.ToList();
            var Dtos = _mapper.Map<IEnumerable<PracStudentApprovalDto>>(entities);
        }

        public void Update(PracStudentApprovalDto dto)
        {
            var pracPracStudentApprovalupt = _context.PracStudentApproval.Where(pracPracStudentApproval => pracPracStudentApproval.Id == dto.Id).FirstOrDefault();

            if (pracPracStudentApprovalupt != null)
            {
                pracPracStudentApprovalupt.RegistrationOfficer = dto.RegistrationOfficer;
                pracPracStudentApprovalupt.Member = dto.Member;
                pracPracStudentApprovalupt.Accountant = dto.Accountant;

            }


            _context.SaveChanges();
        }
    }
}
