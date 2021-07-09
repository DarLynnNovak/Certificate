using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Certificates.Models
{
	public class ACSPersonCME
	{
        public int ID { get; set; }
        public int PersonID { get; set; }

        public int ACSCMEEventID { get; set; }
        [Column(TypeName = "CMEDateGranted")]
        [DisplayName("Date")]
        [DataType(DataType.Date)]
        public DateTime CMEDateGranted { get; set; }

        public decimal CMEType1 { get; set; }

        //public decimal CMEType2 { get; set; }

        public string CMELevel { get; set; }

        public Guid ACSUniqueId { get; set; }

        [NotMapped]
        public string EventName { get; set; }

    }

}
