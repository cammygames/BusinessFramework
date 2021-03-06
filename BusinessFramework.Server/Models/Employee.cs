using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IgiCore.Characters.Shared.Models;
using MercuryWorks.BusinessFramework.Shared.Models;
using NFive.SDK.Core.Models;

namespace MercuryWorks.BusinessFramework.Server.Models
{
	public class Employee: IdentityModel, IEmployee
	{
		[Required]
		public Guid BusinessId { get; set; }

		public virtual IBusiness Business { get; set; }

		[Required]
		public Guid CharacterId { get; set; }

		[NotMapped]
		public virtual ICharacter Character { get; set; }

		[Required]
		public IJob Job { get; set; }
	}
}
