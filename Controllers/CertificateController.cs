using Certificates.Data;
using Certificates.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
namespace Certificates.Controllers
{
	public class CertificateController : Controller
	{
		private CertificatesContext _context;


		public CertificateController(CertificatesContext certificateContext)
		{
			_context = certificateContext;

		}
		public IActionResult Index(Guid auid)
	{
			ACSCertificateViewModel vm = new ACSCertificateViewModel();
			var CertInfo = (from pcme in _context.ACSPersonCME.Where(pcme => pcme.ACSUniqueId == auid)
							from p in _context.Person.Where(p => p.Id == pcme.PersonID)
							from e in _context.ACSCMEEvent.Where(e => e.ID == pcme.ACSCMEEventID)
							from c in _context.ACSCertificate.Where(c => c.ID == e.ACSCMECertTemplate_ID)
							select new ACSCertificate
							{
								ID = c.ID,
								CertBody = c.CertBody,
								//ACSUniqueId = auid

							}).ToList();

			vm.ACSCertificate = CertInfo;
			return View(vm);
		}
		public IActionResult Display(Guid auid)
		{
			ACSCertificateViewModel vm = new ACSCertificateViewModel();
			var CertInfo = (from pcme in _context.ACSPersonCME.Where(pcme => pcme.ACSUniqueId == auid)
							from e in _context.ACSCMEEvent.Where(e => e.ID == pcme.ACSCMEEventID)
							from c in _context.ACSCertificate.Where(c => c.ID == e.ACSCMECertTemplate_ID)
							select new ACSCertificateFields
							{
								ID = c.ID,
								CertBody = c.CertBody,
								CertVersion = e.CertificateVersion	
								
							}).ToList();



			var EventTrans = (from pcme in _context.ACSPersonCME.Where(pcme => pcme.ACSUniqueId == auid)
							  from e in _context.ACSCMEEvent.Where(e => e.ParentID == pcme.ACSCMEEventID)
							  from c in _context.ACSCertificate.Where(c => c.ID == e.ACSCMECertTemplate_ID)
							  select new ACSCMEEvent
							  {
								  ID = e.ID,
								  Name = e.Name,
								  CME_Program = e.CME_Program,
								  CME_Start_Date = e.CME_Start_Date,
								  CME_End_Date = e.CME_End_Date,
								  CME_Max_Credits = e.CME_Max_Credits,
								  //ACSUniqueId = auid

							  }).ToList();

			vm.ACSCertificateFields = CertInfo;
			vm.ACSEventTranscript = EventTrans;
			return View(vm);
		}
	}
}
