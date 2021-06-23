using System;

namespace Certificates.Models
{
	public class ACSCMEEvent
	{
        public int ID { get; set; }

        public string Name { get; set; }

        public string CME_Program { get; set; }

        public string CME_Location { get; set; }

        public DateTime CME_Start_Date { get; set; }

        public DateTime CME_End_Date { get; set; }

        public int ACSCMECertTemplate_ID { get; set; }

        public string CertLine1 { get; set; }
        public string CertLine2 { get; set; }
    }
}
