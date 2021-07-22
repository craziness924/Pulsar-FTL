using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Pulsar_FTL
{
    class Global
    {
        /*
        public static ??? walter;
        public static float walterX = .8f;  
        public static float walterY = 0f;
        public static float walterZ = 0f; */
        public static bool ShouldBlockStarmap = true; // controls whether or not the starmap uses the vanilla or plugin starmap behavior. uses vanilla starmap behavior when false 
        public static bool ShouldBlinkStarmapSectors = true; // enables/disables sectors (Like W.D.) blinking their color
        public static Color WDColor = new Color(1.000f, 0.476f, 0.000f, 1.000f);
    }
}
