using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

		public ICharacter Owner { get; set; }

		[Required]
		public Position MarkerPosition { get; set; }

		public List<Position> InteractionPositions { get; set; }

		public List<Position> SpawnPositions { get; set; }
	}
}
