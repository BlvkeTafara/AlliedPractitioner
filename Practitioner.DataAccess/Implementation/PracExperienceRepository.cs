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
    public class PracExperienceRepository : IPracExperienceRepository
    {
        private readonly AlliedPractitionerDbContext _context;
        private readonly IMapper _mapper;

        public PracExperienceRepository(AlliedPractitionerDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Add(PracExperienceDto dto)
        {
            var entity = _mapper.Map<PracExperience>(dto);
            _context.PracExperiences.Add(entity);
            _context.SaveChanges();
        }

        public void AddRange(IEnumerable<PracExperienceDto> dto)
        {
            var entities = _mapper.Map<IEnumerable<PracExperience>>(dto);
            _context.PracExperiences.AddRange(entities);
        }

        public IEnumerable<PracExperienceDto> GetAll()
        {
            var entities = _context.PracExperiences.ToList();
            var Dtos = _mapper.Map<IEnumerable<PracExperienceDto>>(entities);
            return Dtos;
        }

        public PracExperienceDto GetById(int id)
        {
            var entity = _context.PracExperiences.Where(x => x.Id == id).FirstOrDefault();

            var dto = _mapper.Map<PracExperienceDto>(entity);
            return dto;
        }

        public void Remove(int id)
        {
            var pracExperiencedel = _context.PracExperiences.Where(pracExperience => pracExperience.Id == id).FirstOrDefault();

            _context.PracExperiences.Remove(pracExperiencedel);
            _context.SaveChanges();
        }

        public void RemoveRange(IEnumerable<PracExperienceDto> entities)
        {
            var entitties = _context.PracExperiences.ToList();
            var Dtos = _mapper.Map<IEnumerable<PracExperienceDto>>(entities);
        }

        public void Update(PracExperienceDto dto)
        {
            var pracExperienceupt = _context.PracExperiences.Where(pracExperience => pracExperience.Id == dto.Id).FirstOrDefault();

            if (pracExperienceupt != null)
            {
                pracExperienceupt.BusinessAddress = dto.BusinessAddress;
                pracExperienceupt.ProvinceId = dto.ProvinceId;
                pracExperienceupt.CityId = dto.CityId;
                pracExperienceupt.Email = dto.Email;
                pracExperienceupt.Name = dto.Name;
            }


            _context.SaveChanges();
        }
    }
    
}
