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
    public class PracPlacementRepository : IPracPlacementRepository
    {
        private readonly AlliedPractitionerDbContext _context;
        private readonly IMapper _mapper;

        public PracPlacementRepository(AlliedPractitionerDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Add(PracPlacementDto dto)
        {
            var entity = _mapper.Map<PracPlacement>(dto);
            _context.PracPlacement.Add(entity);
            _context.SaveChanges();
        }

        public void AddRange(IEnumerable<PracPlacementDto> dto)
        {
            var entities = _mapper.Map<IEnumerable<PracPlacement>>(dto);
            _context.PracPlacement.AddRange(entities);
        }

        public IEnumerable<PracPlacementDto> GetAll()
        {
            var entities = _context.PracPlacement.ToList();
            var Dtos = _mapper.Map<IEnumerable<PracPlacementDto>>(entities);
            return Dtos;
        }

        public PracPlacementDto GetById(int id)
        {
            var entity = _context.PracPlacement.Where(x => x.Id == id).FirstOrDefault();

            var dto = _mapper.Map<PracPlacementDto>(entity);
            return dto;
        }

        public void Remove(int id)
        {
            var pracPlacementdel = _context.PracPlacement.Where(pracPlacement => pracPlacement.Id == id).FirstOrDefault();

            _context.PracPlacement.Remove(pracPlacementdel);
            _context.SaveChanges();
        }

        public void RemoveRange(IEnumerable<PracPlacementDto> entities)
        {
            var entitties = _context.PracPlacement.ToList();
            var Dtos = _mapper.Map<IEnumerable<PracPlacementDto>>(entities);
        }

        public void Update(PracPlacementDto dto)
        {
            var pracPlacementupt = _context.PracPlacement.Where(pracPlacement => pracPlacement.Id == dto.Id).FirstOrDefault();

            if (pracPlacementupt != null)
            {
                pracPlacementupt.RenewalPeriodId = dto.RenewalPeriodId;
               
            }


            _context.SaveChanges();
        }
    }
}
