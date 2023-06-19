using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practitioner.Domain.Entity
{
    public class PracContact
    {
        public int Id { get; set; }
        public int PractitionerId { get; set; } //Primary Key ///onetomany
        public int PrimaryPhone { get; set; }

        public int SecondaryPhone { get; set; }
        public int ProvinceId { get; set; }
        public int CityId { get; set; }
        public string Email { get; set; }
        public string PhysicalAddress { get; set; }


        //navigation properties
        public ICollection<PracEmployer> pracEmployers { get; set; }
        public ICollection<PracExperience> pracExperiences { get; set; }
        public ICollection<PracCpdPoint> pracCpdPoints { get; set; }
        public ICollection<PracPaymentInformation> pracPaymentInformation { get; set; }

        public ICollection<PracPlacement> pracPlacements { get; set; }
        public ICollection<PracQualification> pracQualifications { get; set; }
        public ICollection<PracRequirement> pracRequirements { get; set; }
        public ICollection<PracStudentApproval> pracStudentApproval { get; set; }
    }
}
