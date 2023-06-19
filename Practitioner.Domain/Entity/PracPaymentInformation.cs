﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practitioner.Domain.Entity
{
    public class PracPaymentInformation
    {
        public int Id { get; set; }
        public int PractitionerId { get; set; }
        public int RenewalCategoryId { get; set; }
        public int RegisterCategoryId { get; set; }
        public int PaymentMethodId { get; set; }
    }
}
