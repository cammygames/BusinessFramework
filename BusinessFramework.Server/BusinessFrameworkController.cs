using JetBrains.Annotations;
using NFive.SDK.Core.Diagnostics;
using NFive.SDK.Server.Controllers;
using NFive.SDK.Server.Events;
using NFive.SDK.Server.Rcon;
using NFive.SDK.Server.Rpc;
using MercuryWorks.BusinessFramework.Shared;

namespace MercuryWorks.BusinessFramework.Server
{
	[PublicAPI]
	public class BusinessFrameworkController : ConfigurableController<Configuration>
	{
		public BusinessFrameworkController(ILogger logger, IEventManager events, IRpcHandler rpc, IRconManager rcon, Configuration configuration) : base(logger, events, rpc, rcon, configuration)
		{
			// Send configuration when requested
			this.Rpc.Event(BusinessFrameworkEvents.Configuration).On(e => e.Reply(this.Configuration));
		}

		public override void Reload(Configuration configuration)
		{
			// Update local configuration
			base.Reload(configuration);

			// Send out new configuration
			this.Rpc.Event(BusinessFrameworkEvents.Configuration).Trigger(this.Configuration);
		}

		private void Setup()
		{

		}

		private void DefaultsExist()
		{

		}
	}
}
