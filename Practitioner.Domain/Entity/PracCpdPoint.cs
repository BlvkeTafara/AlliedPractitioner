using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practitioner.Domain.Entity
{
    public class PracCpdPoint
    {
        public int Id { get; set; }
        public int PractitionerId { get; set; }
        public int RenewalPeriodId { get; set; }
        public string Point { get; set; }
        public string Path { get; set; }
    }
}
