using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CitizenFX.Core;
using IgiCore.Characters.Shared.Models;
using MercuryWorks.BusinessFramework.Shared.Models;
using Newtonsoft.Json;
using NFive.SDK.Core.Models;

namespace MercuryWorks.BusinessFramework.Client.Models
{
	public class Business : IdentityModel, IBusiness
	{
		public string Name { get; set; }

		public Guid? CharacterId { get; set; }

		public virtual ICharacter Character { get; set; }

		public Position MarkerPosition { get; set; }

		public int MarkerColorId { get; set; }

//		[JsonIgnore]
//		public virtual BlipColor MarkerColor
//		{
//			get => (BlipColor)this.MarkerColorId;
//			set => this.MarkerColorId = (int)value;
//		}

		public int MarkerSpriteId { get; set; }

//		[JsonIgnore]
//		public virtual BlipSprite MarkSprite
//		{
//			get => (BlipSprite) this.MarkerSpriteId;
//			set => this.MarkerSpriteId = (int) value;
//		}

		public Boolean Default { get; set; }
	}
}
