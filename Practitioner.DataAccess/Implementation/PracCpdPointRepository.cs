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
    public class PracCpdPointRepository : IPracCpdPointRepository
    {
        private readonly AlliedPractitionerDbContext _context;
        private readonly IMapper _mapper;

        public PracCpdPointRepository(AlliedPractitionerDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Add(PracCpdPointDto dto)
        {
            var entity = _mapper.Map<PracCpdPoint>(dto);
            _context.PracCpdPoints.Add(entity);
            _context.SaveChanges();
        }

        public void AddRange(IEnumerable<PracCpdPointDto> dto)
        {
            var entities = _mapper.Map<IEnumerable<PracCpdPoint>>(dto);
            _context.PracCpdPoints.AddRange(entities);
        }

        public IEnumerable<PracCpdPointDto> GetAll()
        {

            var entities = _context.PracCpdPoints.ToList();
            var Dtos = _mapper.Map<IEnumerable<PracCpdPointDto>>(entities);
            return Dtos;
        }

        public PracCpdPointDto GetById(int id)
        {
            var entity = _context.PracCpdPoints.Where(x => x.Id == id).FirstOrDefault();

            var dto = _mapper.Map<PracCpdPointDto>(entity);
            return dto;
        }

        public void Remove(int id)
        {
            var pracCpdPointdel = _context.PracCpdPoints.Where(pracCpdPoint => pracCpdPoint.Id == id).FirstOrDefault();

            _context.PracCpdPoints.Remove(pracCpdPointdel);
            _context.SaveChanges();
        }

        public void RemoveRange(IEnumerable<PracCpdPointDto> entities)
        {
            var entitties = _context.PracCpdPoints.ToList();
            var Dtos = _mapper.Map<IEnumerable<PracCpdPointDto>>(entities);
        }

        public void Update(PracCpdPointDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
