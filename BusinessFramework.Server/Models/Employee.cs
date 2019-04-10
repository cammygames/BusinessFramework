using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IgiCore.Characters.Shared.Models;
using MercuryWorks.BusinessFramework.Shared.Models;
using NFive.SDK.Core.Models;

namespace MercuryWorks.BusinessFramework.Server.Models
{
	public class Employee: IdentityModel, IEmployee
	{
		[Required]
		public IBusiness Business { get; set; }

		[Required]
		public ICharacter Character { get; set; }

		[Required]
		public IJob Job { get; set; }
	}
}
