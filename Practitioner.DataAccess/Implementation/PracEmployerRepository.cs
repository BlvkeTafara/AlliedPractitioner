using AutoMapper;
using Practitioner.DataAccess.Context;
using Practitioner.Domain.DTOs;
using Practitioner.Domain.Entity;
using Practitioner.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Practitioner.DataAccess.Implementation
{
    public class PracEmployerRepository : IPracEmployerRepository
    {
        private readonly AlliedPractitionerDbContext _context;
        private readonly IMapper _mapper;

        public PracEmployerRepository(AlliedPractitionerDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void Add(PracEmployerDto dto)
        {
            var entity = _mapper.Map<PracEmployer>(dto);
            _context.PracEmployers.Add(entity);
            _context.SaveChanges();
        }


        public void AddRange(IEnumerable<PracEmployerDto> dto)
        {
            var entities = _mapper.Map<IEnumerable<PracEmployer>>(dto);
            _context.PracEmployers.AddRange(entities);
        }

        public IEnumerable<PracEmployerDto> GetAll()
        {
            var entities = _context.PracEmployers.ToList();
            var Dtos = _mapper.Map<IEnumerable<PracEmployerDto>>(entities);
            return Dtos;
        }

        public PracEmployerDto GetById(int id)
        {
            var entity = _context.PracEmployers.Where(x => x.Id == id).FirstOrDefault();

            var dto = _mapper.Map<PracEmployerDto>(entity);
            return dto;
        }

        public void Remove(int id)
        {
            var pracEmployerdel = _context.PracEmployers.Where(pracEmployer => pracEmployer.Id == id).FirstOrDefault();

            _context.PracEmployers.Remove(pracEmployerdel);
            _context.SaveChanges();
        }



        public void RemoveRange(IEnumerable<PracEmployerDto> entities)
        {
            var entitties = _context.PracEmployers.ToList();
            var Dtos = _mapper.Map<IEnumerable<PracEmployerDto>>(entities);
        }

        public void Update(PracEmployerDto dto)
        {
            var pracEmployerupt = _context.PracEmployers.Where(pracEmployer => pracEmployer.Id == dto.Id).FirstOrDefault();

            if (pracEmployerupt != null)
            {
                pracEmployerupt.BusinessAddress = dto.BusinessAddress;
                pracEmployerupt.ProvinceId = dto.ProvinceId;
                pracEmployerupt.CityId = dto.CityId;
                pracEmployerupt.PhoneNumber = dto.PhoneNumber;
                pracEmployerupt.Name = dto.Name;
            }


            _context.SaveChanges();
        }
    }
}

       

     

    

