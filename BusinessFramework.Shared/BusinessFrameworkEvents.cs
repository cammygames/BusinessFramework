namespace MercuryWorks.BusinessFramework.Shared
{
	public static class BusinessFrameworkEvents
	{
		public const string Configuration = "mercuryworks:businessframework:configuration";

		public const string BusinessRequestDefault = "mercuryworks:businessframework:business:request:default";
		public const string BusinessRequestNonDefault = "mercuryworks:businessframework:business:request:custom";
		public const string BusinessRequestId = "mercuryworks:businessframework:business:request:id";

		public const string BusinessSave = "mercuryworks:businessframework:business:save:all";
		public const string BusinessSaveInventory = "mercuryworks:businessframework:business:save:inventory";
		public const string BusinessSaveBank = "mercuryworks:businessframework:business:save:bank";
		public const string BusinessSaveJobs = "mercuryworks:businessframework:business:save:jobs";
		public const string BusinessSaveEmployees = "mercuryworks:businessframework:business:save:employees";
		public const string BusinessSaveOwner = "mercuryworks:businessframework:business:save:owner";
	}
}
