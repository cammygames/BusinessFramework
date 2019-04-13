using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CitizenFX.Core;
using IgiCore.Characters.Shared.Models;
using MercuryWorks.BusinessFramework.Shared.Models;
using NFive.SDK.Core.Models;

namespace MercuryWorks.BusinessFramework.Server.Models
{
	public class Business : IdentityModel, IBusiness
	{
		[Required]
		[StringLength(100, MinimumLength = 2)]
		public string Name { get; set; }

		[Required]
		public Guid? CharacterId { get; set; }

		[NotMapped]
		public virtual ICharacter Character { get; set; }

		[Required]
		public Position MarkerPosition { get; set; }

		[Required]
		public long MarkerColorId { get; set; }

		[Required]
		public long MarkerSpriteId { get; set; }

		[Required]
		public Boolean Default { get; set; }
	}
}
