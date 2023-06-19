using AutoMapper;
using Practitioner.Domain.DTOs;
using Practitioner.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practitioner.Domain
{
    public class Automapper : Profile
    {
        public Automapper()
        {
            CreateMap<PracBalanceDto, PracBalance>();
            CreateMap<PracBalance, PracBalanceDto>();

            CreateMap<PracContactDto, PracContact>();
            CreateMap<PracContact, PracContactDto>();

            CreateMap<PracCpdPointDto, PracCpdPoint>();
            CreateMap<PracCpdPoint, PracCpdPointDto>();

            CreateMap<PracDocumentDto, PracDocument>();
            CreateMap<PracDocument, PracDocumentDto>();

            CreateMap<PracEmployerDto, PracEmployer>();
            CreateMap<PracEmployer, PracEmployerDto>();

            CreateMap<PracExperienceDto, PracExperience>();
            CreateMap<PracExperience, PracExperienceDto>();

            CreateMap<PracPaymentInformationDto, PracPaymentInformation>();
            CreateMap<PracPaymentInformation, PracPaymentInformationDto>();

            CreateMap<PracPlacementDto, PracPlacement>();
            CreateMap<PracPlacement, PracPlacementDto>();

            CreateMap<PracQualificationDto, PracQualification>();
            CreateMap<PracQualification, PracQualificationDto>();

            CreateMap<PracRequirementDto, PracRequirement>();
            CreateMap<PracRequirement, PracRequirementDto>();

            CreateMap<PracStudentApprovalDto, PracStudentApproval>();
            CreateMap<PracStudentApproval, PracStudentApprovalDto>();

        }
    }
}
