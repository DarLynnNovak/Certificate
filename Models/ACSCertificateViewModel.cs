using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Certificates.Models
{
	public class ACSCertificateViewModel
	{
		public IEnumerable<ACSPersonCME> ACSPersonCMEs { get; set; }
		public IEnumerable<ACSCertificate> ACSCertificate { get; set; }
	}
}
