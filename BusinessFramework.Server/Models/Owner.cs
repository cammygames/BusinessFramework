using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IgiCore.Characters.Shared.Models;
using MercuryWorks.BusinessFramework.Shared.Models;

namespace MercuryWorks.BusinessFramework.Server.Models
{
	public class Owner
	{
		[Required]
		[ForeignKey("Character")]
		public Guid CharacterId { get; set; }

		public virtual ICharacter Character { get; set; }
	}
}
