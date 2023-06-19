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
    public class PracQualificationRepository : IPracQualificationRepository
    {
        private readonly AlliedPractitionerDbContext _context;
        private readonly IMapper _mapper;

        public PracQualificationRepository(AlliedPractitionerDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Add(PracQualificationDto dto)
        {
            var entity = _mapper.Map<PracQualification>(dto);
            _context.PracQualifications.Add(entity);
            _context.SaveChanges();
        }

        public void AddRange(IEnumerable<PracQualificationDto> dto)
        {
            var entities = _mapper.Map<IEnumerable<PracQualification>>(dto);
            _context.PracQualifications.AddRange(entities);
        }

        public IEnumerable<PracQualificationDto> GetAll()
        {
            var entities = _context.PracQualifications.ToList();
            var Dtos = _mapper.Map<IEnumerable<PracQualificationDto>>(entities);
            return Dtos;
        }

        public PracQualificationDto GetById(int id)
        {
            var entity = _context.PracQualifications.Where(x => x.Id == id).FirstOrDefault();

            var dto = _mapper.Map<PracQualificationDto>(entity);
            return dto;
        }

        public void Remove(int id)
        {
            var pracQualificationdel = _context.PracQualifications.Where(pracQualification => pracQualification.Id == id).FirstOrDefault();

            _context.PracQualifications.Remove(pracQualificationdel);
            _context.SaveChanges();
        }

        public void RemoveRange(IEnumerable<PracQualificationDto> entities)
        {
            var entitties = _context.PracQualifications.ToList();
            var Dtos = _mapper.Map<IEnumerable<PracQualificationDto>>(entities);
        }

        public void Update(PracQualificationDto dto)
        {
            var pracQualificationupt = _context.PracQualifications.Where(pracQualification => pracQualification.Id == dto.Id).FirstOrDefault();

            if (pracQualificationupt != null)
            {
                pracQualificationupt.Institution = dto.Institution;
                pracQualificationupt.QualificationCategoryId = dto.QualificationCategoryId;
                pracQualificationupt.PractitonerQualificationId = dto.PractitonerQualificationId;
                
            }


            _context.SaveChanges();
        }
    }
}
