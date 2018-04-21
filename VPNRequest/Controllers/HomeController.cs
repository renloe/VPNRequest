using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VPNRequest.Data;

namespace VPNRequest.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			var capabilities = EFDataHandler.GetCapabilities();


			//Request request = new Request
			//{
			//	ContactId = 1,
			//	EquipmentTypeId = 1,
			//};

			//EFDataHandler.AddRequest(request);

			//EFDataHandler.DeleteRequestById(9);

			var requests = EFDataHandler.GetAllRequests();


			return View();
		}

		
	}
}