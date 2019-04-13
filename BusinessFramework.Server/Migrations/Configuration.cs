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
					CharacterId = new Guid("39ed1ea1-4d56-d230-ddfb-f44aed8d0d37"),
					MarkerPosition = new Position(901.97290f, -172.13090f, 73.56619f),
					Name = "Downtown Cab Co.",
					MarkerSpriteId = 198,
					MarkerColorId = 66
				}
			};

			context.Businesses.AddRange(businesses);

			base.Seed(context);
		}
	}
}
