using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JetBrains.Annotations;
using NFive.SDK.Core.Models;
using IgiCore.Characters.Shared.Models;

namespace MercuryWorks.BusinessFramework.Shared.Models
{
	[PublicAPI]
	public interface IBusiness : IIdentityModel
	{
		/// <summary>
		/// Gets or sets the name of the job
		/// </summary>
		/// <value>
		///	Name of the job
		/// </value>
		string Name { get; set; }

		/// <summary>
		///	Gets or sets the owner of the buissness
		/// </summary>
		/// <value>
		///	Owner of the job
		/// </value>
		ICharacter Character { get; set; }

		/// <summary>
		/// Gets or sets the position of the marker on the map
		/// </summary>
		/// <value>
		///	Marker position on the map
		/// </value>
		Position MarkerPosition { get; set; }

		BusinessType BusinessType { get; set; }
	}

	public enum BusinessType
	{
		CLOTHING,
		GASSTATION,
		GENERAL,
		GUN,
		DEALERSHIP,
		MECHANIC,
		TOW,
		LIQUOR,
		JEWELER,
		TAXI,
		CUSTOM
	}
}
