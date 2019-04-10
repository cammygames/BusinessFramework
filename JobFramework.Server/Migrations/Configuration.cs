using JetBrains.Annotations;
using NFive.SDK.Server.Migrations;
using MercuryWorks.BusinessFramework.Server.Storage;

namespace MercuryWorks.BusinessFramework.Server.Migrations
{
	[UsedImplicitly]
	public sealed class Configuration : MigrationConfiguration<StorageContext> { }
}
