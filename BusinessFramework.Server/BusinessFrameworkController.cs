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
using NFive.SDK.Core.Rpc;

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

		private void FetchDefaults(IRpcEvent e)
		{
			this.Logger.Debug("GOT REQUEST FOR DATA FROM SOMEONE");

			List<BusinessPacket> packets = new List<BusinessPacket>();

			using (var context = new StorageContext())
			{
				var businesses = context.Businesses.Where(c => c.Default && c.Deleted == null).ToList();

				foreach (var business in businesses)
				{
					var locations = context.BusinessPositions
						.Where(c => c.BusinessId == business.Id && c.Deleted == null).ToList();

					var packet = new BusinessPacket(business, locations);

					packets.Add(packet);

					this.Logger.Debug($"ADDED BUSINESS WITH ID: {business.Id}");
				}

			}

			e.Reply(packets);
		}

		private void DefaultsExist()
		{

		}
	}
}
