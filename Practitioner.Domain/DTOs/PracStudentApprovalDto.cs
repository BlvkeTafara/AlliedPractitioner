using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practitioner.Domain.DTOs
{
    public class PracStudentApprovalDto
    {
        public int Id { get; set; }
        public int PractitionerId { get; set; }
        public string RegistrationOfficer { get; set; }
        public string Registrar { get; set; }
        public string Accountant { get; set; }
        public string Member { get; set; }
    }
}
