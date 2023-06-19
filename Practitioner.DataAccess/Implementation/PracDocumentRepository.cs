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
    public class PracDocumentRepository : IPracDocumentRepository
    {
        private readonly AlliedPractitionerDbContext _context;
        private readonly IMapper _mapper;

        public PracDocumentRepository(AlliedPractitionerDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Add(PracDocumentDto dto)
        {
            var entity = _mapper.Map<PracDocument>(dto);
            _context.PracDocuments.Add(entity);
            _context.SaveChanges();
        }

        public void AddRange(IEnumerable<PracDocumentDto> dto)
        {
            var entities = _mapper.Map<IEnumerable<PracDocument>>(dto);
            _context.PracDocuments.AddRange(entities);
        }

        public IEnumerable<PracDocumentDto> GetAll()
        {
            var entities = _context.PracDocuments.ToList();
            var Dtos = _mapper.Map<IEnumerable<PracDocumentDto>>(entities);
            return Dtos;
        }

        public PracDocumentDto GetById(int id)
        {
            var entity = _context.PracDocuments.Where(x => x.Id == id).FirstOrDefault();

            var dto = _mapper.Map<PracDocumentDto>(entity);
            return dto;
        }

        public void Remove(int id)
        {
            var pracDocumentdel = _context.PracDocuments.Where(pracDocument => pracDocument.Id == id).FirstOrDefault();

            _context.PracDocuments.Remove(pracDocumentdel);
            _context.SaveChanges();
        }

        public void RemoveRange(IEnumerable<PracDocumentDto> entities)
        {
            var entitties= _context.PracDocuments.ToList();
            var Dtos = _mapper.Map<IEnumerable<PracDocumentDto>>(entities);
        }

        public void Update(PracDocumentDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
