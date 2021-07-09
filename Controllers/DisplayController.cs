using Certificates.Data;
using Certificates.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq; 
namespace Certificates.Controllers
{
	public class DisplayController : Controller
	{
		private CertificatesContext _context;


		public DisplayController(CertificatesContext certificateContext) 
		{
			_context = certificateContext;

		}
		public IActionResult Index(Guid auid)
		{
			ACSCertificateViewModel vm = new ACSCertificateViewModel();
			var CertInfo = (from pcme in _context.ACSPersonCME.Where(pcme => pcme.ACSUniqueId == auid)
							from p in _context.Person.Where(p => p.Id == pcme.PersonID)
							from e in _context.ACSCMEEvent.Where(e => e.ID == pcme.ACSCMEEventID)
							from et in _context.ACSCMEEventType.Where(et=> et.ID == e.EventType)
							from c in _context.ACSCertificate.Where(c => c.ID == e.ACSCMECertTemplate_ID)
							
							select new ACSCertificateFields
							{
								
								ID = c.ID,
								CertVersion = e.CertificateVersion,
								CertBody = c.CertBody.Replace("&lt;&lt;Prefix&gt;&gt;", p.Prefix)
													.Replace("&lt;&lt;FirstName&gt;&gt;",p.FirstName)
													.Replace("&lt;&lt;LastName&gt;&gt;", p.LastName)
													.Replace("&lt;&lt;Suffix&gt;&gt;", p.Suffix)
													.Replace("&lt;&lt;NameTitle&gt;&gt;", p.NameTitle)
													.Replace("&lt;&lt;EventName&gt;&gt;", e.Name)
													.Replace("&lt;&lt;EventType&gt;&gt;", et.Name)
													.Replace("&lt;&lt;CME_Max_Credits&gt;&gt;", e.CME_Max_Credits)
													.Replace("&lt;&lt;SACME_MAX_CREDITS&gt;&gt;", e.SACME_Max_Credits) 
							}).ToList();

			var TranscriptInfo = (from pcme in _context.ACSPersonCME.Where(pcme => pcme.ACSUniqueId == auid)
							from p in _context.Person.Where(p => p.Id == pcme.PersonID)
							from e in _context.ACSCMEEvent.Where(e => e.ParentID == pcme.ACSCMEEventID)
							from et in _context.ACSCMEEventType.Where(et => et.ID == e.EventType)
							from c in _context.ACSCertificate.Where(c => c.ID == e.ACSCMECertTemplate_ID)
							select new ACSCMEEvent
								  {
										ID = e.ParentID,
										Name = e.Name,
										DateGranted = pcme.CMEDateGranted
									 
								  }).ToList();
			vm.ACSCertificateFields = CertInfo;
			if (TranscriptInfo != null)
			{ vm.ACSEventTranscript = TranscriptInfo; }

			return View(vm);
		}
	}
}
