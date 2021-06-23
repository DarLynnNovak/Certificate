using System.ComponentModel.DataAnnotations.Schema;
namespace Certificates.Models
{
	public class ACSCertificate
	{
		public int ID { get; set; }
		//public string Name { get; set; }
		public string CertBody { get; set; }
		[NotMapped]
		public string ACSUniqueId { get; set; }
	}
}
