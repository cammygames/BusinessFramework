using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MercuryWorks.BusinessFramework.Shared.Models;
using NFive.SDK.Core.Models;

namespace MercuryWorks.BusinessFramework.Server.Models
{
	public class Job: IdentityModel, IJob
	{
		[Required]
		[StringLength(100, MinimumLength = 2)]
		public string Title { get; set; }

		public string Description { get; set; }

		[Required]
		public IBusiness Business { get; set; }

		[Required]
		public CompensationType CompensationType { get; set; }

		[Required]
		public AccessLevel AccessLevel { get; set; }

		[Required]
		public float CompensationValue { get; set; }
	}
}
