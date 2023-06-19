using Practitioner.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practitioner.Domain.DTOs
{
    public class PracEmployerDto
    {
        public int Id { get; set; } 
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

        
    }
}
