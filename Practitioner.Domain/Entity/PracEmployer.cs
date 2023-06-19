using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practitioner.Domain.Entity
{
    public class PracEmployer
    {
        public int Id { get; set; } //Primary Key ///onetomany
        public string Name { get; set; }
        public string BusinessAddress { get; set; }
        public int PractitionerId { get; set; }
        public int ProvinceId { get; set; }
        public int CityId { get; set; }
        public string Email { get; set; }
        public string ContactPerson { get; set; }
        public string JobTitle { get; set; }
        public string PhoneNumber { get; set; }
        public DateOnly CommencementDate { get; set; }

        //navigation properties
        public ICollection<PracBalance> pracBalances { get; set; }
        public ICollection<PracContact> pracContacts { get; set; }
        public ICollection<PracExperience> pracExperiences { get; set; }
        public ICollection<PracCpdPoint> pracCpdPoints { get; set; }
        public ICollection<PracPaymentInformation> pracPaymentInformation { get; set; }
        public ICollection<PracDocument> pracDocuments { get; set; }
        public ICollection<PracPlacement> pracPlacements { get; set; }
        public ICollection<PracQualification> pracQualifications { get; set; }
        public ICollection<PracRequirement> pracRequirements { get; set; }
        public ICollection<PracStudentApproval> pracStudentApproval { get; set; }
    }
}
