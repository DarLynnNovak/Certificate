using Certificates.Models;
using Microsoft.EntityFrameworkCore;

namespace Certificates.Data
{
    public class CertificateContext : DbContext
    {
        public CertificateContext(DbContextOptions<CertificateContext> options) : base(options)
        {
        }
        public DbSet<Person> Person { get; set; }
        public DbSet<ACSPersonCME> ACSPersonCME { get; set; }
        public DbSet<ACSCertificate> ACSCertificate { get; set; }
        public DbSet<ACSCMEEvent> ACSCMEEvent { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().ToTable("Person");
            modelBuilder.Entity<ACSPersonCME>().ToTable("acspersoncme");
            modelBuilder.Entity<ACSCertificate>().ToTable("ACSCertificate");
            modelBuilder.Entity<ACSCMEEvent>().ToTable("ACSCMEEvent");
        }
    }
}
