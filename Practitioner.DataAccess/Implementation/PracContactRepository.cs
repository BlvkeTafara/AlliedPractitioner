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
    public class PracContactRepository : IPracContactRepository
    {
        private readonly AlliedPractitionerDbContext _context;
        private readonly IMapper _mapper;

        public PracContactRepository(AlliedPractitionerDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Add(PracContactDto dto)
        {
            var entity = _mapper.Map<PracContact>(dto);
            _context.PracContacts.Add(entity);
            _context.SaveChanges();
        }

        public void AddRange(IEnumerable<PracContactDto> dto)
        {
            var entities = _mapper.Map<IEnumerable<PracContact>>(dto);
            _context.PracContacts.AddRange(entities);
        }

        public IEnumerable<PracContactDto> GetAll()
        {
            var entities = _context.PracContacts.ToList();
            var Dtos = _mapper.Map<IEnumerable<PracContactDto>>(entities);
            return Dtos;
        }

        public PracContactDto GetById(int id)
        {
            var entity = _context.PracContacts.Where(x => x.Id == id).FirstOrDefault();

            var dto = _mapper.Map<PracContactDto>(entity);
            return dto;
        }

        public void Remove(int id)
        {
            var pracContactdel = _context.PracContacts.Where(pracContact => pracContact.Id == id).FirstOrDefault();

            _context.PracContacts.Remove(pracContactdel);
            _context.SaveChanges();
        }

        public void RemoveRange(IEnumerable<PracContactDto> entities)
        {
            var entitties = _context.PracContacts.ToList();
            var Dtos = _mapper.Map<IEnumerable<PracContactDto>>(entities);
        }

        public void Update(PracContactDto dto)
        {
            var pracContactupt = _context.PracContacts.Where(pracContact => pracContact.Id == dto.Id).FirstOrDefault();

            if (pracContactupt != null)
            {
                pracContactupt.PrimaryPhone = dto.PrimaryPhone;
                pracContactupt.PhysicalAddress = dto.PhysicalAddress;
                pracContactupt.ProvinceId = dto.ProvinceId;
                pracContactupt.Email = dto.Email;
                pracContactupt.CityId = dto.CityId;
            }


            _context.SaveChanges();
        }
    }
    }

