using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practitioner.Domain.DTOs
{
    public class PracRequirementDto
    {
        public int Id { get; set; }
        public int PractitionerId { get; set; }
        public int PracRequirementsId { get; set; }
        public Boolean Status { get; set; }
        public Boolean MemberStatus { get; set; }
    }
}
