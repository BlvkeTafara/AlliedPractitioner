using Microsoft.EntityFrameworkCore;
using Practitioner.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practitioner.DataAccess.Context
{
    public class AlliedPractitionerDbContext: DbContext
    {
        public AlliedPractitionerDbContext()
        {
        }

        public AlliedPractitionerDbContext(DbContextOptions<AlliedPractitionerDbContext>options): base(options) { }
        public DbSet<PracBalance> PracBalances { get; set; }
        public DbSet<PracContact> PracContacts { get; set; }
        public DbSet<PracCpdPoint> PracCpdPoints { get; set; }
        public DbSet<PracDocument> PracDocuments { get; set; }
        public DbSet<PracEmployer> PracEmployers { get; set; }
        public DbSet<PracExperience> PracExperiences { get; set; }
        public DbSet<PracPaymentInformation> PracPaymentInformation { get; set; }
        public DbSet<PracPlacement> PracPlacement { get; set; }
        public DbSet<PracQualification> PracQualifications { get; set; }
        public DbSet<PracRequirement> PracRequirements { get; set; }
        public DbSet<PracStudentApproval> PracStudentApproval { get; set; }
    }
}
