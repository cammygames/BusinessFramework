using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IgiCore.Characters.Shared.Models;
using MercuryWorks.BusinessFramework.Shared.Models;
using NFive.SDK.Core.Models;

namespace MercuryWorks.BusinessFramework.Client.Models
{
	public class Employee: IdentityModel, IEmployee
	{
		public Guid BusinessId { get; set; }

		public virtual IBusiness Business { get; set; }

		public Guid CharacterId { get; set; }

		public virtual ICharacter Character { get; set; }

		public IJob Job { get; set; }
	}
}
