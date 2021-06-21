using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using System.ComponentModel.DataAnnotations.Schema;
namespace Certificates.Models
{
	public class ACSPersonCME
	{
        public int ID { get; set; }
        public int PersonID { get; set; }

        public int ACSCMEEventID { get; set; }

        public DateTime CMEDateGranted { get; set; }

        public decimal CMEType1 { get; set; }

        //public decimal CMEType2 { get; set; }

        public string CMELevel { get; set; }

        public Guid ACSUniqueId { get; set; }

        [NotMapped]
        public string EventName { get; set; }

    }

}
