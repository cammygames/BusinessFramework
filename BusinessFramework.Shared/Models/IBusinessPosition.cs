using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JetBrains.Annotations;
using NFive.SDK.Core.Models;

namespace MercuryWorks.BusinessFramework.Shared.Models
{
	[PublicAPI]
	public interface IBusinessPosition : IIdentityModel
	{
		IBusiness Business { get; set; }

		Position Position { get; set; }

		PositionType PositionType { get; set; }
	}

	public enum PositionType
	{
		Interaction,
		Spawn
	}
}
