using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MercuryWorks.BusinessFramework.Shared.Models;
using NFive.SDK.Core.Models;

namespace MercuryWorks.BusinessFramework.Client.Models
{
	public class BusinessPosition: IdentityModel, IBusinessPosition
	{
		public Guid BusinessId { get; set; }

		public virtual IBusiness Business { get; set; }

		public Position Position { get; set; }

		public PositionType PositionType { get; set; }
	}
}
