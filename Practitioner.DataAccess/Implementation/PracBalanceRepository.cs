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
    public class PracBalanceRepository : IPracBalanceRepository
    {
        private readonly AlliedPractitionerDbContext _context;
        private readonly IMapper _mapper;

        public PracBalanceRepository(AlliedPractitionerDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Add(PracBalanceDto dto)
        {
            var entity = _mapper.Map<PracBalance>(dto);
            _context.PracBalances.Add(entity);
            _context.SaveChanges();
        }

        public void AddRange(IEnumerable<PracBalanceDto> dto)
        {
            var entities = _mapper.Map<IEnumerable<PracBalance>>(dto);
            _context.PracBalances.AddRange(entities);
        }

        public IEnumerable<PracBalanceDto> GetAll()
        {
            var entities = _context.PracBalances.ToList();
            var Dtos = _mapper.Map<IEnumerable<PracBalanceDto>>(entities);
            return Dtos;

        }

        public PracBalanceDto GetById(int id)
        {
            var entity = _context.PracBalances.Where(x => x.Id == id).FirstOrDefault();

            var dto = _mapper.Map<PracBalanceDto>(entity);
            return dto;
        }

        public void Remove(int id)
        {
            var pracBalancedel = _context.PracBalances.Where(pracBalance => pracBalance.Id == id).FirstOrDefault();

            _context.PracBalances.Remove(pracBalancedel);
            _context.SaveChanges();
        }

        public void RemoveRange(IEnumerable<PracBalanceDto> entities)
        {
            var entitties = _context.PracBalances.ToList();
            var Dtos = _mapper.Map<IEnumerable<PracBalanceDto>>(entities);
        }

        public void Update(PracBalanceDto entity)
        {
            throw new NotImplementedException();
        }
    }
    }

