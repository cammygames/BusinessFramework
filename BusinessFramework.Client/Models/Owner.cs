using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IgiCore.Characters.Shared.Models;
using MercuryWorks.BusinessFramework.Shared.Models;

namespace MercuryWorks.BusinessFramework.Client.Models
{
	public class Owner
	{
		public Guid CharacterId { get; set; }

		public virtual ICharacter Character { get; set; }
	}
}
