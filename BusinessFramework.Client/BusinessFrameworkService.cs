using JetBrains.Annotations;
using NFive.SDK.Client.Commands;
using NFive.SDK.Client.Events;
using NFive.SDK.Client.Interface;
using NFive.SDK.Client.Rpc;
using NFive.SDK.Client.Services;
using NFive.SDK.Core.Diagnostics;
using NFive.SDK.Core.Models.Player;
using System;
using System.Threading.Tasks;
using CitizenFX.Core;
using MercuryWorks.BusinessFramework.Client.Overlays;
using MercuryWorks.BusinessFramework.Shared;

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

			//test memes
			Blip test = World.CreateBlip(new Vector3(-717, -156, 36));
			test.Sprite = BlipSprite.Barber;
			test.Color = BlipColor.Red;
			test.IsShortRange = true;
			test.Name = "Test Marker 1";
		}

		private async Task OnTick()
		{
			this.Logger.Debug("Hello World!");
			// Do something every frame

			await Delay(TimeSpan.FromSeconds(1));
		}
	}
}
