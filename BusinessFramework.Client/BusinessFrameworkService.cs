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
using System.Drawing;
using System.Threading.Tasks;
using CitizenFX.Core;
using CitizenFX.Core.Native;
using CitizenFX.Core.UI;
using MercuryWorks.BusinessFramework.Client.Models;
using MercuryWorks.BusinessFramework.Client.Overlays;
using MercuryWorks.BusinessFramework.Shared;
using NFive.SDK.Client.Extensions;
using NFive.SDK.Client.Input;

namespace MercuryWorks.BusinessFramework.Client
{
	[PublicAPI]
	public class BusinessFrameworkService : Service
	{
		private Configuration config;
		private BusinessFrameworkOverlay overlay;

		private List<BusinessPosition> businessPositions = new List<BusinessPosition>();
		private List<Business> businesses = new List<Business>();

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

			//Request Businesses marked as default.
			SetupDefaultBusinesses(await this.Rpc.Event(BusinessFrameworkEvents.BusinessRequestDefault).Request<List<BusinessPacket>>());

			// Attach a tick handler
			this.Ticks.Attach(MarkerDraw);
			this.Ticks.Attach(OnTick);
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

				this.businesses.Add(packet.Business);
	
				foreach (var position in packet.Positions)
				{
					position.Business = packet.Business;
					this.businessPositions.Add(position);
				}
			}
		}

		private async Task MarkerDraw()
		{
			foreach (var position in this.businessPositions)
			{
				var playerPosition = Game.Player.Character.Position;
				var distance = GetDistanceBetweenCoords(playerPosition, position.Position.ToVector3());

				if (distance < 100f)
				{
					World.DrawMarker(position.MarkerType, position.Position.ToVector3(), position.MarkerDirection.ToVector3(), position.MarkerRotation.ToVector3(), position.MarkerScale.ToVector3(), position.MarkerColor.ToCitColor());

					if (distance <= 3f)
					{
						new Text("Press E to Interact", new PointF(50, Screen.Height - 150), 0.4f, Color.FromArgb(255, 255, 255), Font.ChaletLondon, Alignment.Left, false, true).Draw();

						if (!Input.IsControlJustReleased(Control.VehicleHorn)) return;
							new Text($"{position.Business.Name}", new PointF(50, Screen.Height - 200), 0.4f, Color.FromArgb(255, 255, 255), Font.ChaletLondon, Alignment.Left, false, true).Draw();

						//Some how need to figure out what action to call based on the buisness
					}
				}
			}

			await Task.FromResult(0);
		}

		private async Task OnTick()
		{
			//this.Logger.Debug("Hello World!");
			// Do something every frame

			await Delay(TimeSpan.FromSeconds(1));
		}

		private float GetDistanceBetweenCoords(Vector3 first, Vector3 second, bool useZ = true)
		{
			return API.GetDistanceBetweenCoords(first.X, first.Y, first.Z, second.X, second.Y, second.Z, useZ);
		}
	}
}
