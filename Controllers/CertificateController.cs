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
		public IActionResult Index()
	{

			var auid = Guid.Parse("D1C0C62C-B099-4058-8F57-FD86363AAD24");
			//var auid = Convert.ToString(User.Identity.Name);
			ACSCertificateViewModel vm = new ACSCertificateViewModel();
			var CertInfo = (from pcme in _context.ACSPersonCME.Where(pcme => pcme.ACSUniqueId == auid)
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
	}
}
