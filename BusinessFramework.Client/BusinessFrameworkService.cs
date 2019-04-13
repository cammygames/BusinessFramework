using JetBrains.Annotations;
using NFive.SDK.Client.Commands;
using NFive.SDK.Client.Events;
using NFive.SDK.Client.Interface;
using NFive.SDK.Client.Rpc;
using NFive.SDK.Client.Services;
using NFive.SDK.Core.Diagnostics;
using NFive.SDK.Core.Models.Player;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CitizenFX.Core;
using MercuryWorks.BusinessFramework.Client.Models;
using MercuryWorks.BusinessFramework.Client.Overlays;
using MercuryWorks.BusinessFramework.Shared;
using NFive.SDK.Client.Extensions;

namespace MercuryWorks.BusinessFramework.Client
{
	[PublicAPI]
	public class BusinessFrameworkService : Service
	{
		private Configuration config;
		private BusinessFrameworkOverlay overlay;

		public BusinessFrameworkService(ILogger logger, ITickManager ticks, IEventManager events, IRpcHandler rpc, ICommandManager commands, OverlayManager overlay, User user) : base(logger, ticks, events, rpc, commands, overlay, user) { }

		public override async Task Started()
		{
			// Request server configuration
			this.config = await this.Rpc.Event(BusinessFrameworkEvents.Configuration).Request<Configuration>();

			this.Logger.Debug($"From server config: {this.config.Example}");

			// Update local configuration on server configuration change
			this.Rpc.Event(BusinessFrameworkEvents.Configuration).On<Configuration>((e, c) => this.config = c);

			// Create overlay
			this.overlay = new BusinessFrameworkOverlay(this.OverlayManager);

			// Attach a tick handler
			this.Ticks.Attach(OnTick);

			//Request Businesses marked as default.
			SetupDefaultBusinesses(await this.Rpc.Event(BusinessFrameworkEvents.BusinessRequestDefault).Request<List<BusinessPacket>>());
		}

		private void SetupDefaultBusinesses(List<BusinessPacket> packets)
		{
			foreach (var packet in packets)
			{
				//Create Marker Blip
				Blip blip = World.CreateBlip(packet.Business.MarkerPosition.ToVector3());
				blip.Sprite = (BlipSprite)packet.Business.MarkerSpriteId;
				blip.Color = (BlipColor)packet.Business.MarkerColorId;
				blip.IsShortRange = true;
				blip.Name = packet.Business.Name;
			}
		}

		private async Task OnTick()
		{
			//this.Logger.Debug("Hello World!");
			// Do something every frame

			await Delay(TimeSpan.FromSeconds(1));
		}
	}
}
