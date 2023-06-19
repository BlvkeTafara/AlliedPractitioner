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
  public class PracRequirementRepository : IPracRequirementRepository
    {
        private readonly AlliedPractitionerDbContext _context;
        private readonly IMapper _mapper;

        public PracRequirementRepository(AlliedPractitionerDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Add(PracRequirementDto dto)
        {
            var entity = _mapper.Map<PracRequirement>(dto);
            _context.PracRequirements.Add(entity);
            _context.SaveChanges();
        }

        public void AddRange(IEnumerable<PracRequirementDto> dto)
        {
            var entities = _mapper.Map<IEnumerable<PracRequirement>>(dto);
            _context.PracRequirements.AddRange(entities);
        }

        public IEnumerable<PracRequirementDto> GetAll()
        {
            var entities = _context.PracRequirements.ToList();
            var Dtos = _mapper.Map<IEnumerable<PracRequirementDto>>(entities);
            return Dtos;
        }

        public PracRequirementDto GetById(int id)
        {
            var entity = _context.PracRequirements.Where(x => x.Id == id).FirstOrDefault();

            var dto = _mapper.Map<PracRequirementDto>(entity);
            return dto;
        }

        public void Remove(int id)
        {
            var pracRequirementdel = _context.PracRequirements.Where(pracRequirement => pracRequirement.Id == id).FirstOrDefault();

            _context.PracRequirements.Remove(pracRequirementdel);
            _context.SaveChanges();
        }

        public void RemoveRange(IEnumerable<PracRequirementDto> entities)
        {
            var entitties = _context.PracRequirements.ToList();
            var Dtos = _mapper.Map<IEnumerable<PracRequirementDto>>(entities);
        }

        public void Update(PracRequirementDto dto)
        {
            var pracRequirementupt = _context.PracRequirements.Where(pracRequirement => pracRequirement.Id == dto.Id).FirstOrDefault();

            if (pracRequirementupt != null)
            {
                pracRequirementupt.PracRequirementsId = dto.PracRequirementsId;
             

            }


            _context.SaveChanges();
        }
    }
}
