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
   public class PracPaymentInformationRepository : IPracPaymentInformationRepository
    {
        private readonly AlliedPractitionerDbContext _context;
        private readonly IMapper _mapper;

        public PracPaymentInformationRepository(AlliedPractitionerDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Add(PracPaymentInformationDto dto)
        {
            var entity = _mapper.Map<PracPaymentInformation>(dto);
            _context.PracPaymentInformation.Add(entity);
            _context.SaveChanges();
        }

        public void AddRange(IEnumerable<PracPaymentInformationDto> dto)
        {
            var entities = _mapper.Map<IEnumerable<PracPaymentInformation>>(dto);
            _context.PracPaymentInformation.AddRange(entities);
        }

        public IEnumerable<PracPaymentInformationDto> GetAll()
        {
            var entities = _context.PracPaymentInformation.ToList();
            var Dtos = _mapper.Map<IEnumerable<PracPaymentInformationDto>>(entities);
            return Dtos;
        }

        public PracPaymentInformationDto GetById(int id)
        {
            var entity = _context.PracPaymentInformation.Where(x => x.Id == id).FirstOrDefault();

            var dto = _mapper.Map<PracPaymentInformationDto>(entity);
            return dto;
        }
            public void Remove(int id)
        {
            var pracPaymentInformationdel = _context.PracPaymentInformation.Where(pracPaymentInformation => pracPaymentInformation.Id == id).FirstOrDefault();

            _context.PracPaymentInformation.Remove(pracPaymentInformationdel);
            _context.SaveChanges();
        }

        public void RemoveRange(IEnumerable<PracPaymentInformationDto> entities)
        {
            var entitties = _context.PracPaymentInformation.ToList();
            var Dtos = _mapper.Map<IEnumerable<PracPaymentInformationDto>>(entities);
        }

        public void Update(PracPaymentInformationDto dto)
        {
            var pracPaymentInformationupt = _context.PracPaymentInformation.Where(pracPaymentInformation => pracPaymentInformation.Id == dto.Id).FirstOrDefault();

            if (pracPaymentInformationupt != null)
            {
                pracPaymentInformationupt.RenewalCategoryId = dto.RenewalCategoryId;
                pracPaymentInformationupt.RegisterCategoryId = dto.RegisterCategoryId;
                pracPaymentInformationupt.PaymentMethodId = dto.PaymentMethodId;
               
            }


            _context.SaveChanges();
        }
    }
}
