using System.Data.Entity;
using MercuryWorks.BusinessFramework.Server.Models;
using NFive.SDK.Core.Models.Player;
using NFive.SDK.Server.Storage;

namespace MercuryWorks.BusinessFramework.Server.Storage
{
	public class StorageContext : EFContext<StorageContext>
	{
		public DbSet<User> Users { get; set; }

		public DbSet<Business> Businesses { get; set; }

		public DbSet<Job> Jobs { get; set; }

		public DbSet<Employee> Employees { get; set; }

		public DbSet<BusinessPosition> BusinessPositions { get; set; }
	}
}
