using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar_FTL
{
    class FactionPatches
    {
        [HarmonyPatch(typeof(PLNetworkManager), "MasterClientPickStartingSpotFromShipType", new Type[] { typeof(int) })]
        class ShipStartingPointChanger
        {
            [HarmonyPrefix]
            static bool Prefix(int inShipType, ref int __result)
            {
                __result = 0;
                return false;
            }
        }
    }
}
