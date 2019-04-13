using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MercuryWorks.BusinessFramework.Shared.Models;
using NFive.SDK.Core.Models;

namespace MercuryWorks.BusinessFramework.Client.Models
{
	public class Job: IdentityModel, IJob
	{
		public string Title { get; set; }

		public string Description { get; set; }

		public Guid BusinessId { get; set; }

		public virtual IBusiness Business { get; set; }

		public CompensationType CompensationType { get; set; }

		public AccessLevel AccessLevel { get; set; }

		public float CompensationValue { get; set; }
	}
}
