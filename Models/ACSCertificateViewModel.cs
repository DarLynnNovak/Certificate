using System;
using System.Collections.Generic;

namespace Certificates.Models
{
	public class ACSCertificateViewModel
	{
		//public IEnumerable<ACSPersonCME> ACSPersonCMEs { get; set; }
		public IEnumerable<ACSCertificate> ACSCertificate { get; set; }
        public IEnumerable<ACSCertificateFields> ACSCertificateFields { get; set; }
        public int CertificateID { get; set; }
        public string CertBody { get; set; }
        public int EventID { get; set; }

        public string EventName { get; set; }

        public string CME_Program { get; set; }

        public string CME_Location { get; set; }

        public DateTime CME_Start_Date { get; set; }

        public DateTime CME_End_Date { get; set; }

        public int ACSCMECertTemplate_ID { get; set; }

        public string CertLine1 { get; set; }
        public string CertLine2 { get; set; }
        public string ACSUniqueId { get; set; }

    }
}
