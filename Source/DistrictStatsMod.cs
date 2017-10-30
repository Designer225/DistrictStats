using System;
using ICities;


namespace DistrictStats
{
	public class DistrictStatsMod : IUserMod{
		public string Name{
			get{ return "DistrictStats"; }
		}

		public string Description{
			get{return "Enables the ability to view consumtion demands & production capacities by district (power, water, good import/export, ...)";}
		}
	}
}

