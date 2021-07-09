using System.ComponentModel.DataAnnotations.Schema;
namespace Certificates.Models
{
	public class ACSCertificateFields
	{
		public int ID { get; set; }
		[NotMapped]
		public string CertBody { get; set; }
		public string Prefix { get; set; }
		public string FirstName { get; set; }

		public string LastName { get; set; }

		public string Suffix { get; set; }

		public string NameTitle { get; set; }

		public int EventID { get; set; }

		[NotMapped]
		public string CertVersion { get; set; }
	}
}
