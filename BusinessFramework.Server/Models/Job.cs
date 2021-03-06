using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IgiCore.Characters.Server.Models;
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
		public Guid BusinessId { get; set; }

		public virtual IBusiness Business { get; set; }

		[Required]
		public CompensationType CompensationType { get; set; }

		[Required]
		public AccessLevel AccessLevel { get; set; }

		[Required]
		public float CompensationValue { get; set; }
	}
}
