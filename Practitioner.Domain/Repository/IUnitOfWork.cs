using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practitioner.Domain.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        IPracBalanceRepository PracBalance { get; }
        IPracContactRepository PracContact { get; }
        IPracCpdPointRepository PracCpdPoint { get; }
        IPracDocumentRepository PracDocument { get; }
        IPracEmployerRepository PracEmployer { get; }
        IPracExperienceRepository PracExperience { get; }
        IPracPaymentInformationRepository PracPaymentInformation { get; }
        IPracPlacementRepository PracPlacement { get; }
        IPracQualificationRepository PracQualification { get; }
        IPracRequirementRepository PracRequirement { get; }
        IPracStudentApprovalRepository PracStudentApproval { get; }

        int Save();
    }
}
