using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using MercuryWorks.BusinessFramework.Server.Models;
using NFive.SDK.Server.Migrations;
using MercuryWorks.BusinessFramework.Server.Storage;
using NFive.SDK.Core.Helpers;
using NFive.SDK.Core.Models;

namespace MercuryWorks.BusinessFramework.Server.Migrations
{
	[UsedImplicitly]
	public sealed class Configuration : MigrationConfiguration<StorageContext>
	{
		protected override void Seed(StorageContext context)
		{
			List<Business> businesses = new List<Business>
			{
				new Business()
				{
					Id = GuidGenerator.GenerateTimeBasedGuid(),
					Default = true,
					CharacterId = Guid.Empty,
					MarkerPosition = new Position(901.97290f, -172.13090f, 73.56619f),
					Name = "Downtown Cab Co.",
					MarkerSpriteId = 198,
					MarkerColorId = 66
				},
				new Business()
				{
					Id = GuidGenerator.GenerateTimeBasedGuid(),
					Default = true,
					CharacterId = Guid.Empty,
					MarkerPosition = new Position(-712.19260f, -154.33080f, 36.93108f),
					Name = "PONSONBYS",
					MarkerSpriteId = 73,
					MarkerColorId = 0
				}
			};

			context.Businesses.AddRange(businesses);

			base.Seed(context);
		}
	}
}
