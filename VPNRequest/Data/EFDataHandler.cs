using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VPNRequest.Data
{
	public class EFDataHandler
	{
		

		public static List<Capability> GetCapabilities()
		{
			using (VPNRequestEntities db = new VPNRequestEntities())
			{
				return db.Capabilities.ToList();
			}
		}

		public static void AddRequest(Request request)
		{
			using (VPNRequestEntities db = new VPNRequestEntities())
			{
				db.Requests.Add(request);

				int[] capabilities = new[] { 1, 2 };

				foreach (var cap in capabilities)
				{
					var capability = db.Capabilities.Where(x => x.Id == cap).SingleOrDefault();
					request.Capabilities.Add(capability);
				}

				SQDNApprovalStatu sqdn = new SQDNApprovalStatu();
				sqdn.RequestId = request.Id;

				db.SQDNApprovalStatus.Add(sqdn);

				db.SaveChanges();
			}
		}
		
		public static List<Request> GetAllRequests()
		{
			using (VPNRequestEntities db = new VPNRequestEntities())
			{
				return db.Requests
					.Include("Capabilities")
					.Include("Contact")
					.Include("EquipmentType")
					.Include("SQDNApprovalStatu")
					.Include("CSMApprovalStatu")
					.Include("SIGApprovalStatu")
					.ToList();
			}
		}

		public static void DeleteRequestById(int requestId)
		{
			using (VPNRequestEntities db = new VPNRequestEntities())
			{
				var request = db.Requests
					.Where(x => x.Id == requestId)
					.SingleOrDefault();

				if (request != null)
				{
					db.Requests.Remove(request);
					db.SaveChanges();
				}
			}
		}

	}
}
