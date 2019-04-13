using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercuryWorks.BusinessFramework.Server.Models
{
	class BusinessPacket
	{
		public Business Business { get; set; }

		public List<BusinessPosition> Positions { get; set; }

		public BusinessPacket(Business business, List<BusinessPosition> businessPosition)
		{
			this.Business = business;
			this.Positions = businessPosition;
		}
	}
}
