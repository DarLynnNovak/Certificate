using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Certificates.Data;
using Certificates.Models;
namespace Certificates.Controllers
{
	public class CertificateController : Controller
	{
		private CertificateContext _context;


		public CertificateController(CertificateContext certificateContext)
		{
			_context = certificateContext;

		}
		public IActionResult Index()
		{
			var auid = Convert.ToString(User.Identity.Name);
			ACSCertificateViewModel vm = new ACSCertificateViewModel();
			
			var CertificateInfo = (from pc in _context.ACSPersonCME
								   join e in _context.ACSCMEEvent
									 on pc.ACSCMEEventID equals e.ID
								   join c in _context.ACSCertificate
								   on e.ACSCMECertTemplate_ID equals c.ID
								   where Convert.ToString(pc.ACSUniqueId) == auid
								   select new ACSCertificate()
								   {
									   ID = c.ID,
									   Name = c.Name,
									   CertBody = c.CertBody

								   });
			vm.ACSCertificate = CertificateInfo;
			return View(vm);
		}
	}
}
