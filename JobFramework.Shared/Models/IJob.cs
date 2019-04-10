using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JetBrains.Annotations;
using NFive.SDK.Core.Models;

namespace MercuryWorks.BusinessFramework.Shared.Models
{
	[PublicAPI]
	public interface IJob : IIdentityModel
	{
		string Title { get; set; }

		string Description { get; set; }

		IBusiness Business { get; set; }

		CompensationType CompensationType { get; set; }

		AccessLevel AccessLevel { get; set; }

		float CompensationValue { get; set; }
	}

	public enum CompensationType
	{
		Salary,
		Comission
	}

	public enum AccessLevel
	{
		Owner = 5,
		CoOwner = 4,
		Finance = 3,
		Manager = 2,
		Employee = 1,
		Trainee = 0
	}
}
