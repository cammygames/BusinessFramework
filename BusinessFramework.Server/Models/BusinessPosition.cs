using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CitizenFX.Core;
using MercuryWorks.BusinessFramework.Shared.Models;
using NFive.SDK.Core.Models;

namespace MercuryWorks.BusinessFramework.Server.Models
{
	public class BusinessPosition: IdentityModel, IBusinessPosition
	{
		[Required]
		public Guid BusinessId { get; set; }

		public virtual IBusiness Business { get; set; }

		[Required]
		public Position Position { get; set; }

		[Required]
		public PositionType PositionType { get; set; }

		[Required]
		public long MarkerTypeId { get; set; }

		[Required]
		public Position MarkerRotation { get; set; }

		[Required]
		public Position MarkerDirection { get; set; }

		[Required]
		public Position MarkerScale { get; set; }

		[Required]
		public Color MarkerColor { get; set; }
	}
}
