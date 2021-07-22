using HarmonyLib;
using Pulsar_FTL;
using PulsarPluginLoader.Patches;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace FogOfWar
{
    public class Blindfolding
    {
        [HarmonyPatch(typeof(PLStarmap), "ShouldShowSectorBG")]
        class StarmapSectorDotRemoval // removes all normal sectors from the map if they aren't discovered or other conditions
        {
            static void Postfix(ref bool __result, PLSectorInfo sectorInfo)
            {
                if (Global.ShouldBlockStarmap)
                {
                    if (PhotonNetwork.isMasterClient)
                    {
                        int crewFactionID = PLServer.Instance.CrewFactionID;
                        bool shouldshowestate = (crewFactionID == 1);
                        if (sectorInfo.VisualIndication == ESectorVisualIndication.GENTLEMEN_START)
                        {
                            __result = (shouldshowestate || sectorInfo.Discovered);
                            return;
                        }
                        else if (sectorInfo.VisualIndication == ESectorVisualIndication.AOG_HUB)
                        {
                            __result = (shouldshowestate || sectorInfo.Discovered);
                            return;
                        }
                        else if (sectorInfo.MySPI.Faction == crewFactionID)
                        {
                            __result = (sectorInfo.MissionSpecificID == -1 || PLServer.Instance.HasActiveMissionWithID(sectorInfo.MissionSpecificID));
                            return;
                        }
                        else
                        {
                            __result = (sectorInfo != null && sectorInfo.VisualIndication != ESectorVisualIndication.COMET && sectorInfo.VisualIndication != ESectorVisualIndication.TOPSEC && sectorInfo.VisualIndication != ESectorVisualIndication.LCWBATTLE && (sectorInfo.MissionSpecificID == -1 || PLServer.Instance.HasActiveMissionWithID(sectorInfo.MissionSpecificID)) && (sectorInfo.IsThisSectorWithinPlayerWarpRange() || sectorInfo.Visited || sectorInfo.Discovered || (((sectorInfo.Name != sectorInfo.ID.ToString() && !sectorInfo.Name.Contains("Sys") && !sectorInfo.Name.Contains("Karattis")) || sectorInfo.VisualIndication == ESectorVisualIndication.AOG_MISSIONCHAIN_PRISONBREAK || sectorInfo.VisualIndication == ESectorVisualIndication.RACING_SECTOR_3 || sectorInfo.VisualIndication == ESectorVisualIndication.RACING_SECTOR_2 || sectorInfo.VisualIndication == ESectorVisualIndication.RACING_SECTOR || sectorInfo.VisualIndication == ESectorVisualIndication.ALCHEMIST || sectorInfo.VisualIndication == ESectorVisualIndication.DESERT_HUB || sectorInfo.VisualIndication == ESectorVisualIndication.SWARM_CMDR || sectorInfo.VisualIndication == ESectorVisualIndication.DEATHSEEKER_COMMANDER || sectorInfo.VisualIndication == ESectorVisualIndication.INTREPID_SECTOR_CMDR || sectorInfo.VisualIndication == ESectorVisualIndication.SPACE_SCRAPYARD || sectorInfo.VisualIndication == ESectorVisualIndication.AOG_HUB || sectorInfo.VisualIndication == ESectorVisualIndication.ANCIENT_SENTRY || sectorInfo.VisualIndication == ESectorVisualIndication.GENERAL_STORE || /* sectorInfo.VisualIndication == ESectorVisualIndication.EXOTIC1 || sectorInfo.VisualIndication == ESectorVisualIndication.EXOTIC2 || sectorInfo.VisualIndication == ESectorVisualIndication.EXOTIC3 || */ sectorInfo.VisualIndication == ESectorVisualIndication.WARP_NETWORK_STATION || PLServer.Instance.m_ShipCourseGoals.Contains(sectorInfo.ID) || sectorInfo.MissionSpecificID != -1) && (sectorInfo.MissionSpecificID == -1 || PLServer.Instance.HasActiveMissionWithID(sectorInfo.MissionSpecificID)) && sectorInfo.VisualIndication != ESectorVisualIndication.COMET)));
                        }
                    }
                }
                else
                {
                    __result = sectorInfo != null && sectorInfo.VisualIndication != ESectorVisualIndication.COMET && sectorInfo.VisualIndication != ESectorVisualIndication.TOPSEC && sectorInfo.VisualIndication != ESectorVisualIndication.LCWBATTLE && (sectorInfo.MissionSpecificID == -1 || PLServer.Instance.HasActiveMissionWithID(sectorInfo.MissionSpecificID));
                }
            }
        }
        [HarmonyPatch(typeof(PLStarmap), "ShouldShowSector")]
        class StarmapSectorIconRemoval // removes sector icons (like a circle that says "The Estate" from the Starmap
        {
            static void Postfix(ref bool __result, PLSectorInfo sectorInfo)
            {
                bool isGWG = (sectorInfo.VisualIndication == ESectorVisualIndication.GWG) && (PLServer.Instance != null);
                if (Global.ShouldBlockStarmap)
                {
                    if (PhotonNetwork.isMasterClient)
                    {
                        int crewFactionID = PLServer.Instance.CrewFactionID;
                        bool shouldshowestate = (crewFactionID == 1);
                        if (sectorInfo.VisualIndication == ESectorVisualIndication.GENTLEMEN_START)
                        {
                            __result = (shouldshowestate || sectorInfo.Discovered);
                            return;
                        }
                        else if (sectorInfo.VisualIndication == ESectorVisualIndication.AOG_HUB)
                        {
                            __result = (shouldshowestate || sectorInfo.Discovered);
                            return;
                        }
                        else if (sectorInfo.MySPI.Faction == crewFactionID)
                        {
                            __result = (sectorInfo.MissionSpecificID == -1 || PLServer.Instance.HasActiveMissionWithID(sectorInfo.MissionSpecificID));
                            return;
                        }
                        __result = ((sectorInfo.Name != sectorInfo.ID.ToString() && !sectorInfo.Name.Contains("Sys") && !sectorInfo.Name.Contains("Karattis")) || isGWG || sectorInfo.VisualIndication == ESectorVisualIndication.AOG_MISSIONCHAIN_PRISONBREAK || sectorInfo.VisualIndication == ESectorVisualIndication.RACING_SECTOR_3 || sectorInfo.VisualIndication == ESectorVisualIndication.RACING_SECTOR_2 || sectorInfo.VisualIndication == ESectorVisualIndication.RACING_SECTOR || sectorInfo.VisualIndication == ESectorVisualIndication.ALCHEMIST || sectorInfo.VisualIndication == ESectorVisualIndication.DESERT_HUB || sectorInfo.VisualIndication == ESectorVisualIndication.SWARM_CMDR || sectorInfo.VisualIndication == ESectorVisualIndication.DEATHSEEKER_COMMANDER || sectorInfo.VisualIndication == ESectorVisualIndication.INTREPID_SECTOR_CMDR || sectorInfo.VisualIndication == ESectorVisualIndication.SPACE_SCRAPYARD || sectorInfo.VisualIndication == ESectorVisualIndication.AOG_HUB || sectorInfo.VisualIndication == ESectorVisualIndication.ANCIENT_SENTRY || sectorInfo.VisualIndication == ESectorVisualIndication.GENERAL_STORE /*  sectorInfo.VisualIndication == ESectorVisualIndication.EXOTIC1 || sectorInfo.VisualIndication == ESectorVisualIndication.EXOTIC2 || sectorInfo.VisualIndication == ESectorVisualIndication.EXOTIC3 */ || sectorInfo.VisualIndication == ESectorVisualIndication.WARP_NETWORK_STATION || PLServer.Instance.m_ShipCourseGoals.Contains(sectorInfo.ID) || sectorInfo.MissionSpecificID != -1) && (sectorInfo.MissionSpecificID == -1 || PLServer.Instance.HasActiveMissionWithID(sectorInfo.MissionSpecificID)) && sectorInfo.VisualIndication != ESectorVisualIndication.COMET;
                    }
                }
                else
                {
                    __result = (sectorInfo.Name != sectorInfo.ID.ToString() || sectorInfo.VisualIndication == ESectorVisualIndication.AOG_MISSIONCHAIN_PRISONBREAK || isGWG || sectorInfo.VisualIndication == ESectorVisualIndication.RACING_SECTOR_3 || sectorInfo.VisualIndication == ESectorVisualIndication.RACING_SECTOR_2 || sectorInfo.VisualIndication == ESectorVisualIndication.RACING_SECTOR || sectorInfo.VisualIndication == ESectorVisualIndication.ALCHEMIST || sectorInfo.VisualIndication == ESectorVisualIndication.DESERT_HUB || sectorInfo.VisualIndication == ESectorVisualIndication.SWARM_CMDR || sectorInfo.VisualIndication == ESectorVisualIndication.DEATHSEEKER_COMMANDER || sectorInfo.VisualIndication == ESectorVisualIndication.INTREPID_SECTOR_CMDR || sectorInfo.VisualIndication == ESectorVisualIndication.SPACE_SCRAPYARD || sectorInfo.VisualIndication == ESectorVisualIndication.AOG_HUB || sectorInfo.VisualIndication == ESectorVisualIndication.ANCIENT_SENTRY || sectorInfo.VisualIndication == ESectorVisualIndication.GENERAL_STORE || sectorInfo.VisualIndication == ESectorVisualIndication.EXOTIC1 || sectorInfo.VisualIndication == ESectorVisualIndication.EXOTIC2 || sectorInfo.VisualIndication == ESectorVisualIndication.EXOTIC3 || sectorInfo.VisualIndication == ESectorVisualIndication.WARP_NETWORK_STATION || PLServer.Instance.m_ShipCourseGoals.Contains(sectorInfo.ID) || sectorInfo.MissionSpecificID != -1) && (sectorInfo.MissionSpecificID == -1 || PLServer.Instance.HasActiveMissionWithID(sectorInfo.MissionSpecificID)) && sectorInfo.VisualIndication != ESectorVisualIndication.COMET;
                }
            }
        }
        /*    [HarmonyPatch(typeof(PLStarmap), "Update")]
            class RemoveFactionColorsOnMap // removes the colors that surround each faction's area on the map
            {
                static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
                {
                    List<CodeInstruction> TargetSequence = new List<CodeInstruction>()
                {
                    new CodeInstruction(OpCodes.Ldsfld, AccessTools.Field(typeof(PLGlobal), "Instance")),
                    new CodeInstruction(OpCodes.Ldfld, AccessTools.Field(typeof(PLGlobal), "Galaxy")),
                    new CodeInstruction(OpCodes.Ldarg_0),
                    new CodeInstruction(OpCodes.Call, AccessTools.Method(typeof(PLStarmap), "UpdateFactionAreaDisplays")),
                    new CodeInstruction(OpCodes.Callvirt),
                    new CodeInstruction(OpCodes.Pop),
                };
                    List<CodeInstruction> InjectedSequence = new List<CodeInstruction>()
                {
                    new CodeInstruction(OpCodes.Nop),
                };
                    return HarmonyHelpers.PatchBySequence(instructions, TargetSequence, InjectedSequence, HarmonyHelpers.PatchMode.REPLACE, HarmonyHelpers.CheckMode.NONNULL);
                }
            }
            [HarmonyPatch(typeof(PLStarmap), "ClearStarmap")]
            class RemoveFactionColorsAfterDeath // similar to above patch, however it targets ClearStarmap which updates the faction displays once you die
            {
                static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
                {
                    List<CodeInstruction> TargetSequence = new List<CodeInstruction>()
                {
                    new CodeInstruction(OpCodes.Ldsfld, AccessTools.Field(typeof(PLGlobal), "Instance")),
                    new CodeInstruction(OpCodes.Ldfld, AccessTools.Field(typeof(PLGlobal), "Galaxy")),
                    new CodeInstruction(OpCodes.Ldarg_0),
                    new CodeInstruction(OpCodes.Call, AccessTools.Method(typeof(PLStarmap), "UpdateFactionAreaDisplays")),
                    new CodeInstruction(OpCodes.Callvirt),
                    new CodeInstruction(OpCodes.Pop),
                };
                    List<CodeInstruction> InjectedSequence = new List<CodeInstruction>()
                {
                    new CodeInstruction(OpCodes.Nop),
                };
                    return HarmonyHelpers.PatchBySequence(instructions, TargetSequence, InjectedSequence, HarmonyHelpers.PatchMode.REPLACE, HarmonyHelpers.CheckMode.NONNULL);
                }
            } */
    }
}

/* PLShipInfoBase pLShipInfoBase = new PLShipInfoBase();
               PLShipStats pLShipStats = new PLShipStats(pLShipInfoBase);
               PLGalaxy pLGalaxy = new PLGalaxy();
               float warprange = pLShipStats.WarpRange * pLShipStats.WarpRange; */