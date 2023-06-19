using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practitioner.Domain.Entity
{
    public class PracQualification
    {
        public int Id { get; set; }
        public int PractitionerId { get; set; }
        public int PractitonerQualificationId { get; set; }
        public int ProfessionId { get; set; }
        public int AccreditedInstitutionId { get; set; }
        public int QualificationCategoryId { get; set; }
        public string Institution { get; set; }
        public string ProfessionalQualificationName { get; set; }
        public string AwardedBy { get; set; }
        public DateTime CommencementDate { get; set; }
        public DateOnly CompletionDate { get; set; }

        public DateOnly AwardedDate { get; set; }
    }
}
