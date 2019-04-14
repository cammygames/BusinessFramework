using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CitizenFX.Core;
using MercuryWorks.BusinessFramework.Shared.Models;
using Newtonsoft.Json;
using NFive.SDK.Core.Models;

namespace MercuryWorks.BusinessFramework.Client.Models
{
	public class BusinessPosition: IdentityModel, IBusinessPosition
	{
		public Guid BusinessId { get; set; }

		public virtual IBusiness Business { get; set; }

		public Position Position { get; set; }

		public PositionType PositionType { get; set; }

		public long MarkerTypeId { get; set; }

		[JsonIgnore]
		public virtual MarkerType MarkerType
		{
			get => (MarkerType)this.MarkerTypeId;
			set => this.MarkerTypeId = (int)value;
		}

		public Position MarkerRotation { get; set; }

		public Position MarkerDirection { get; set; }

		public Position MarkerScale { get; set; }

		public Color MarkerColor { get; set; }
	}
}
