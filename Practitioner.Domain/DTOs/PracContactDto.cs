using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practitioner.Domain.DTOs
{
    public class PracContactDto
    {
        public int Id { get; set; }
        public int PractitionerId { get; set; } 
        public int PrimaryPhone { get; set; }

        public int SecondaryPhone { get; set; }
        public int ProvinceId { get; set; }
        public int CityId { get; set; }
        public string Email { get; set; }
        public string PhysicalAddress { get; set; }
    }
}
