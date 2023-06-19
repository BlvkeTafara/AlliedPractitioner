using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practitioner.Domain.DTOs
{
    public class PracPlacementDto
    {
        public int Id { get; set; }
        public int PractitonerId { get; set; }
        public string RenewalPeriodId { get; set; }
        public string Path { get; set; }
    }
}
