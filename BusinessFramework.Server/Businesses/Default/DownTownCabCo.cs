using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MercuryWorks.BusinessFramework.Server.Models;
using NFive.SDK.Core.Models;

namespace MercuryWorks.BusinessFramework.Server.Businesses.Default
{
	public class DownTownCabCo : Business
	{
		public DownTownCabCo()
		{
			this.Default = true;
			this.MarkerPosition = new Position(901.97290f, -172.13090f, 73.56619f);
			this.Name = "Downtown Cab Co.";

			//interaction position 895.11410f, -179.23070f, 74.17712f
		}
	}
}
