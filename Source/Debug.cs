using System;
using ColossalFramework;

namespace DistrictStats
{
	public class Debug{
#if DEBUG
        static bool DEBUG = true;
#else
        static bool  DEBUG = false;
#endif
        public static void Print(object obj){
			if(DEBUG){
                		CODebug.Log(LogChannel.Modding, "[DistrictStats] "+obj.ToString());
			}
		}
	}
}

