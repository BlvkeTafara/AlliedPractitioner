using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practitioner.Domain.Entity
{
    public class PracExperience
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string BusinessAddress { get; set; }
        public string ContactPerson { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string JobTitle { get; set; }
        public int PractitionerId { get; set; }
        public int ProvinceId { get; set; }
        public int CityId { get; set; } //Primary Key ///onetomany
        public DateOnly CommencementDate { get; set; }
        public DateOnly ResignationDate { get; set; }

        //navigation properties
        public ICollection<PracContact> pracContacts { get; set; }
        public ICollection<PracEmployer> pracEmployers { get; set; }
    }
}
