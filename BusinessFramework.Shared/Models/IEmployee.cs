using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IgiCore.Characters.Shared.Models;
using JetBrains.Annotations;
using NFive.SDK.Core.Models;

namespace MercuryWorks.BusinessFramework.Shared.Models
{
	[PublicAPI]
	public interface IEmployee : IIdentityModel
	{
		IBusiness Business { get; set; }

		ICharacter Character { get; set; }

		IJob Job { get; set; }
	}
}
