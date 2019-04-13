using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using JetBrains.Annotations;
using MercuryWorks.BusinessFramework.Server.Models;
using MercuryWorks.BusinessFramework.Server.Storage;
using NFive.SDK.Core.Diagnostics;
using NFive.SDK.Server.Controllers;
using NFive.SDK.Server.Events;
using NFive.SDK.Server.Rcon;
using NFive.SDK.Server.Rpc;
using MercuryWorks.BusinessFramework.Shared;
using NFive.SDK.Core.Helpers;
using NFive.SDK.Core.Models;

namespace MercuryWorks.BusinessFramework.Server
{
	[PublicAPI]
	public class BusinessFrameworkController : ConfigurableController<Configuration>
	{
		public BusinessFrameworkController(ILogger logger, IEventManager events, IRpcHandler rpc, IRconManager rcon, Configuration configuration) : base(logger, events, rpc, rcon, configuration)
		{
			// Send configuration when requested
			this.Rpc.Event(BusinessFrameworkEvents.Configuration).On(e => e.Reply(this.Configuration));
			this.Rpc.Event(BusinessFrameworkEvents.BusinessRequestDefault).On(FetchDefaults);

			//SeedDefaults();
		}

		public override void Reload(Configuration configuration)
		{
			// Update local configuration
			base.Reload(configuration);

			// Send out new configuration
			this.Rpc.Event(BusinessFrameworkEvents.Configuration).Trigger(this.Configuration);
		}

		private async void SeedDefaults()
		{
			using (var context = new StorageContext())
			using (var transaction = context.Database.BeginTransaction())
			{
				try
				{
					var test = new Business()
					{
						Id = GuidGenerator.GenerateTimeBasedGuid(),
						Default = true,
						CharacterId = new Guid("39ed1ea1-4d56-d230-ddfb-f44aed8d0d37"),
						MarkerPosition = new Position(901.97290f, -172.13090f, 73.56619f),
						Name = "Downtown Cab Co."
					};

					context.Businesses.Add(test);

					await context.SaveChangesAsync();
					transaction.Commit();

					this.Logger.Debug($"Saved new Businesses: {test.Id}");
				}
				catch (Exception ex)
				{
					this.Logger.Error(ex);

					transaction.Rollback();

					// TODO: Reply with an error so client doesn't hang
				}
			}
		}

		private void FetchDefaults(IRpcEvent e)
		{
			List<BusinessPacket> packets = new List<BusinessPacket>();

			using (var context = new StorageContext())
			{
				var businesses = context.Businesses.Where(c => c.Default == true && c.Deleted == null).ToList();

				foreach (var business in businesses)
				{
//					var locations = context.BusinessPositions
//						.Where(c => c.BusinessId == business.Id && c.Deleted == null).ToList();

					var packet = new BusinessPacket(business, new List<BusinessPosition>());

					packets.Add(packet);
				}

			}

			e.Reply(packets);
		}

		private void DefaultsExist()
		{

		}
	}
}
