using AutoMapper;
using Practitioner.DataAccess.Context;
using Practitioner.Domain.Entity;
using Practitioner.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practitioner.DataAccess.Implementation
{
   public class UnitOfWork : IUnitOfWork
    {
        private readonly AlliedPractitionerDbContext _context;
        private readonly IMapper _mapper;

        public UnitOfWork(AlliedPractitionerDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            PracBalance = new PracBalanceRepository(_context, _mapper);

            PracContact = new PracContactRepository(_context, _mapper);

            PracCpdPoint = new PracCpdPointRepository(_context, _mapper);

            PracDocument = new PracDocumentRepository(_context, _mapper);

            PracEmployer = new PracEmployerRepository(_context, _mapper);

            PracExperience = new PracExperienceRepository(_context, _mapper);

            PracPaymentInformation = new PracPaymentInformationRepository(_context, _mapper);

            PracPlacement = new PracPlacementRepository(_context, _mapper);

            PracQualification = new PracQualificationRepository(_context, _mapper);

            PracRequirement = new PracRequirementRepository(_context, _mapper);

            PracStudentApproval = new PracStudentApprovalRepository(_context, _mapper);
        }
        public IPracBalanceRepository PracBalance { get; private set; }
        public IPracContactRepository PracContact { get; private set; }
        public IPracCpdPointRepository PracCpdPoint { get; private set; }
        public IPracDocumentRepository PracDocument { get; private set; }
        public IPracEmployerRepository PracEmployer { get; private set; }
        public IPracExperienceRepository PracExperience { get; private set; }
        public IPracPaymentInformationRepository PracPaymentInformation { get; private set; }
        public IPracPlacementRepository PracPlacement { get; private set; }
        public IPracQualificationRepository PracQualification { get; private set; }
        public IPracRequirementRepository PracRequirement { get; private set; }
        public IPracStudentApprovalRepository PracStudentApproval { get; private set; }
        public int Save()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
