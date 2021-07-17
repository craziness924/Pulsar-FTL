using HarmonyLib;
using PulsarPluginLoader.Patches;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using UnityEngine;

namespace Pulsar_FTL
{
    class SectorPatches
    {
        [HarmonyPatch(typeof(PLGalaxy), "CreateDefaultSector")]
        internal class AddEpicSectorsPatch
        {
            private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions, ILGenerator generator)
            {
                LocalBuilder walter = generator.DeclareLocal(typeof(object));
                LocalBuilder walterX = generator.DeclareLocal(typeof(float));
                LocalBuilder walterY = generator.DeclareLocal(typeof(float));
                LocalBuilder walterZ = generator.DeclareLocal(typeof(float));

                LocalBuilder boss = generator.DeclareLocal(typeof(object));
                LocalBuilder bossX = generator.DeclareLocal(typeof(float));
                LocalBuilder bossY = generator.DeclareLocal(typeof(float));
                LocalBuilder bossZ = generator.DeclareLocal(typeof(float));

                List<CodeInstruction> TargetSequence = new List<CodeInstruction>()
            {
                new CodeInstruction(OpCodes.Stfld, AccessTools.Field(typeof(PLSectorInfo), "Name")),
                new CodeInstruction(OpCodes.Ldloc_0),
                new CodeInstruction(OpCodes.Ldc_I4_6),
                new CodeInstruction(OpCodes.Callvirt)
            };
                List<CodeInstruction> InjectedSequence = new List<CodeInstruction>()
            {

                new CodeInstruction(OpCodes.Newobj, AccessTools.Constructor(typeof(PLSectorInfo))),
                new CodeInstruction(OpCodes.Stloc_S, walter), //4 is walter
                new CodeInstruction(OpCodes.Ldloc_S, walter),
                new CodeInstruction(OpCodes.Ldc_I4_1),
                new CodeInstruction(OpCodes.Stfld, AccessTools.Field(typeof(PLSectorInfo), "Discovered")),
                new CodeInstruction(OpCodes.Ldloc_S, walter),
                new CodeInstruction(OpCodes.Ldc_I4_0),
                new CodeInstruction(OpCodes.Callvirt, AccessTools.Method(typeof(PLSectorInfo), "set_Visited", new Type[] { typeof(bool)})),
                new CodeInstruction(OpCodes.Ldc_R4, -.2f),
                new CodeInstruction(OpCodes.Stloc_S, walterX),
                new CodeInstruction(OpCodes.Ldc_R4, 0f),
                new CodeInstruction(OpCodes.Stloc_S, walterY),
                new CodeInstruction(OpCodes.Ldc_R4, 0f),
                new CodeInstruction(OpCodes.Stloc_S, walterZ),
                new CodeInstruction(OpCodes.Ldloc_S, walter),
                new CodeInstruction(OpCodes.Ldloc_S, walterX),
                new CodeInstruction(OpCodes.Ldloc_S, walterY),
                new CodeInstruction(OpCodes.Ldloc_S, walterZ),
                new CodeInstruction(OpCodes.Newobj, AccessTools.Constructor(typeof(Vector3), new Type[] { typeof(float), typeof(float), typeof(float) })),//may need to add parameters??
                new CodeInstruction(OpCodes.Ldarg_0),
                new CodeInstruction(OpCodes.Ldfld, AccessTools.Field(typeof(PLGalaxy), "m_GenGalaxyScale")),
                new CodeInstruction(OpCodes.Call, AccessTools.Method(typeof(Vector3), "op_Multiply", new Type[] { typeof(Vector3), typeof(float) } )),
                new CodeInstruction(OpCodes.Callvirt, AccessTools.Method(typeof(PLSectorInfo), "set_Position", new Type[] { typeof(Vector3) })),
                new CodeInstruction(OpCodes.Ldarg_0),
            //    new CodeInstruction(OpCodes.Ldfld, AccessTools.Field(typeof(PLGalaxy), "m_GenGalaxyScale")),
            //    new CodeInstruction(OpCodes.Call, AccessTools.Method(typeof(Vector3), "op_Multiply")),
                new CodeInstruction(OpCodes.Ldfld, AccessTools.Field(typeof(PLGalaxy), "m_AllSectorInfos")),
                new CodeInstruction(OpCodes.Ldc_I4, 20000),
                new CodeInstruction(OpCodes.Ldloc_S, walter),
                new CodeInstruction(OpCodes.Callvirt, AccessTools.Method(typeof(Dictionary<int, PLSectorInfo>), "Add")),
                new CodeInstruction(OpCodes.Ldloc_S, walter),
                new CodeInstruction(OpCodes.Ldc_I4, 20000),
                new CodeInstruction(OpCodes.Stfld, AccessTools.Field(typeof(PLSectorInfo), "ID")),
                new CodeInstruction(OpCodes.Ldloc_S, walter),
                new CodeInstruction(OpCodes.Ldarg_0),
                new CodeInstruction(OpCodes.Ldloca_S, walter),
                new CodeInstruction(OpCodes.Ldc_I4, 20000),
                new CodeInstruction(OpCodes.Call, AccessTools.Method(typeof(SectorProceduralInfo), "Create")),
                new CodeInstruction(OpCodes.Stfld, AccessTools.Field(typeof(PLSectorInfo), "MySPI")),
                new CodeInstruction(OpCodes.Ldloc_S, walter),
                new CodeInstruction(OpCodes.Ldfld, AccessTools.Field(typeof(PLSectorInfo), "MySPI")),
                new CodeInstruction(OpCodes.Ldc_I4_2),
                new CodeInstruction(OpCodes.Stfld, AccessTools.Field(typeof(SectorProceduralInfo), "Faction")),
                new CodeInstruction(OpCodes.Ldloc_S, walter),
                new CodeInstruction(OpCodes.Ldc_R4, 7800f),
                new CodeInstruction(OpCodes.Stfld, AccessTools.Field(typeof(PLSectorInfo), "FactionStrength")),
                new CodeInstruction(OpCodes.Ldloc_S, walter),
                new CodeInstruction(OpCodes.Ldc_I4_1),
                new CodeInstruction(OpCodes.Stfld, AccessTools.Field(typeof(PLSectorInfo), "LockedToFaction")),
                new CodeInstruction(OpCodes.Ldloc_S, walter),
                new CodeInstruction(OpCodes.Ldc_I4_0),
                new CodeInstruction(OpCodes.Callvirt, AccessTools.Method(typeof(PLSectorInfo), "set_IsPartOfLongRangeWarpNetwork", new Type[] { typeof(bool)})),
                new CodeInstruction(OpCodes.Ldloc_S, walter),
                new CodeInstruction(OpCodes.Ldstr, "Rebel Base"),
                new CodeInstruction(OpCodes.Stfld, AccessTools.Field(typeof(PLSectorInfo), "Name")),
                new CodeInstruction(OpCodes.Ldloc_S, walter),
                new CodeInstruction(OpCodes.Ldc_I4_0),
                new CodeInstruction(OpCodes.Callvirt, AccessTools.Method(typeof(PLSectorInfo), "set_VisualIndication", new Type[] { typeof(ESectorVisualIndication)})),
                // end walter sector generator!
                
                // start boss sector generator!
                new CodeInstruction(OpCodes.Newobj, AccessTools.Constructor(typeof(PLSectorInfo))),
                new CodeInstruction(OpCodes.Stloc_S, boss), //object of sector
                new CodeInstruction(OpCodes.Ldloc_S, boss),
                new CodeInstruction(OpCodes.Ldc_I4_1),
                new CodeInstruction(OpCodes.Stfld, AccessTools.Field(typeof(PLSectorInfo), "Discovered")),
                new CodeInstruction(OpCodes.Ldloc_S, boss),
                new CodeInstruction(OpCodes.Ldc_I4_0),
                new CodeInstruction(OpCodes.Callvirt, AccessTools.Method(typeof(PLSectorInfo), "set_Visited", new Type[] { typeof(bool)})),
                new CodeInstruction(OpCodes.Ldc_R4, 0.8f),
                new CodeInstruction(OpCodes.Stloc_S, bossX), //epic (x position of sector)
                new CodeInstruction(OpCodes.Ldc_R4, 0.1f),
                new CodeInstruction(OpCodes.Stloc_S, bossY), //epic2 (y position of sector)
                new CodeInstruction(OpCodes.Ldc_R4, 0f),
                new CodeInstruction(OpCodes.Stloc_S, bossZ), //epic3 (z position of sector) 
                new CodeInstruction(OpCodes.Ldloc_S, boss),
                new CodeInstruction(OpCodes.Ldloc_S, bossX),
                new CodeInstruction(OpCodes.Ldloc_S, bossY),
                new CodeInstruction(OpCodes.Ldloc_S, bossZ),
                new CodeInstruction(OpCodes.Newobj, AccessTools.Constructor(typeof(Vector3), new Type[] { typeof(float), typeof(float), typeof(float)  })),
                new CodeInstruction(OpCodes.Ldarg_0),
                new CodeInstruction(OpCodes.Ldfld, AccessTools.Field(typeof(PLGalaxy), "m_GenGalaxyScale")),
                new CodeInstruction(OpCodes.Call, AccessTools.Method(typeof(Vector3), "op_Multiply", new Type[] { typeof(Vector3), typeof(float) } )),
                new CodeInstruction(OpCodes.Callvirt, AccessTools.Method(typeof(PLSectorInfo), "set_Position", new Type[] { typeof(Vector3) })),
                
           //   new CodeInstruction(OpCodes.Ldfld, AccessTools.Field(typeof(PLGalaxy), "m_GenGalaxyScale")), // uncomment if you'd like to multiply position by galaxy scale, may not work I removed it before bug fixing
           //   new CodeInstruction(OpCodes.Call, AccessTools.Method(typeof(Vector3), "op_Multiply")),
                new CodeInstruction(OpCodes.Ldarg_0),
                new CodeInstruction(OpCodes.Ldfld, AccessTools.Field(typeof(PLGalaxy), "m_AllSectorInfos")),
                new CodeInstruction(OpCodes.Ldc_I4, 0x4E21),
                new CodeInstruction(OpCodes.Ldloc_S, boss),
                new CodeInstruction(OpCodes.Callvirt, AccessTools.Method(typeof(Dictionary<int, PLSectorInfo>), "Add")),
                new CodeInstruction(OpCodes.Ldloc_S, boss),
                new CodeInstruction(OpCodes.Ldc_I4, 0x4E21),
                new CodeInstruction(OpCodes.Stfld, AccessTools.Field(typeof(PLSectorInfo), "ID")),
                new CodeInstruction(OpCodes.Ldloc_S, boss),
                new CodeInstruction(OpCodes.Ldarg_0),
                new CodeInstruction(OpCodes.Ldloca_S, boss),
                new CodeInstruction(OpCodes.Ldc_I4, 0x4E21),
                new CodeInstruction(OpCodes.Call, AccessTools.Method(typeof(SectorProceduralInfo), "Create")),
                new CodeInstruction(OpCodes.Stfld, AccessTools.Field(typeof(PLSectorInfo), "MySPI")),
                new CodeInstruction(OpCodes.Ldloc_S, boss),
                new CodeInstruction(OpCodes.Ldfld, AccessTools.Field(typeof(PLSectorInfo), "MySPI")),
                new CodeInstruction(OpCodes.Ldc_I4_0),
                new CodeInstruction(OpCodes.Stfld, AccessTools.Field(typeof(SectorProceduralInfo), "Faction")),
                new CodeInstruction(OpCodes.Ldloc_S, boss),
                new CodeInstruction(OpCodes.Ldc_R4, 7800f),
                new CodeInstruction(OpCodes.Stfld, AccessTools.Field(typeof(PLSectorInfo), "FactionStrength")),
                new CodeInstruction(OpCodes.Ldloc_S, boss),
                new CodeInstruction(OpCodes.Ldc_I4_1),
                new CodeInstruction(OpCodes.Stfld, AccessTools.Field(typeof(PLSectorInfo), "LockedToFaction")),
                new CodeInstruction(OpCodes.Ldloc_S, boss),
                new CodeInstruction(OpCodes.Ldc_I4_0),
                new CodeInstruction(OpCodes.Callvirt, AccessTools.Method(typeof(PLSectorInfo), "set_IsPartOfLongRangeWarpNetwork", new Type[] { typeof(bool)})),
                new CodeInstruction(OpCodes.Ldloc_S, boss),
                new CodeInstruction(OpCodes.Ldstr, "Flagship"),
                new CodeInstruction(OpCodes.Stfld, AccessTools.Field(typeof(PLSectorInfo), "Name")),
                new CodeInstruction(OpCodes.Ldloc_S, boss),
                new CodeInstruction(OpCodes.Ldc_I4_S, 17), //grim cutlass sector indicator atm
                new CodeInstruction(OpCodes.Callvirt, AccessTools.Method(typeof(PLSectorInfo), "set_VisualIndication", new Type[] { typeof(ESectorVisualIndication)})),
            };
                return HarmonyHelpers.PatchBySequence(instructions, TargetSequence, InjectedSequence, HarmonyHelpers.PatchMode.AFTER, HarmonyHelpers.CheckMode.NONNULL);
            }

            // this will setup moving the CU hub to a far off place idk
            [HarmonyPatch(typeof(PLGalaxy), "CreateDefaultSector")]
            internal class CUHubMover
            {
                private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
                {
                    List<CodeInstruction> TargetSequence = new List<CodeInstruction>()
                    {
                        new CodeInstruction(OpCodes.Ldc_R4, .04f),
                        new CodeInstruction(OpCodes.Ldarg_0),
                        new CodeInstruction(OpCodes.Ldfld),
                        new CodeInstruction(OpCodes.Callvirt),
                        new CodeInstruction(OpCodes.Conv_R4),
                        new CodeInstruction(OpCodes.Ldc_R4, 0.02f),
                        new CodeInstruction(OpCodes.Mul),
                        new CodeInstruction(OpCodes.Add),
                        new CodeInstruction(OpCodes.Stloc_1),
                        new CodeInstruction(OpCodes.Ldc_R4, 0.04f),
                        new CodeInstruction(OpCodes.Ldarg_0),
                        new CodeInstruction(OpCodes.Ldfld),
                        new CodeInstruction(OpCodes.Callvirt),
                        new CodeInstruction(OpCodes.Conv_R4),
                        new CodeInstruction(OpCodes.Ldc_R4, 0.02f),
                        new CodeInstruction(OpCodes.Mul),
                        new CodeInstruction(OpCodes.Add),
                        new CodeInstruction(OpCodes.Stloc_2),
                        new CodeInstruction(OpCodes.Ldarg_0),
                        new CodeInstruction(OpCodes.Ldfld),
                        new CodeInstruction(OpCodes.Callvirt),
                        new CodeInstruction(OpCodes.Conv_R4),
                        new CodeInstruction(OpCodes.Ldc_R4, .02f),
                        new CodeInstruction(OpCodes.Mul),
                        new CodeInstruction(OpCodes.Stloc_3)
                    };
                    List<CodeInstruction> InjectedSequence = new List<CodeInstruction>()
                    {
                        new CodeInstruction(OpCodes.Ldc_R4, -.80f), //new x position
                        new CodeInstruction(OpCodes.Ldarg_0),
                        new CodeInstruction(OpCodes.Ldfld, AccessTools.Field(typeof(PLGalaxy), "m_GenGalaxyScale")),
                        new CodeInstruction(OpCodes.Ldc_R4, .05f),
                        new CodeInstruction(OpCodes.Mul),
                        new CodeInstruction(OpCodes.Add),
                        new CodeInstruction(OpCodes.Stloc_1),
                        new CodeInstruction(OpCodes.Ldc_R4, 0.3f), //new y position
                        new CodeInstruction(OpCodes.Ldarg_0),
                        new CodeInstruction(OpCodes.Ldfld, AccessTools.Field(typeof(PLGalaxy), "m_GenGalaxyScale")),
                        new CodeInstruction(OpCodes.Ldc_R4, .05f),
                        new CodeInstruction(OpCodes.Mul),
                        new CodeInstruction(OpCodes.Sub),
                        new CodeInstruction(OpCodes.Stloc_2),
                        new CodeInstruction(OpCodes.Ldc_R4, .2f), //new z position
                        new CodeInstruction(OpCodes.Stloc_3)
                    };
                    return HarmonyHelpers.PatchBySequence(instructions, TargetSequence, InjectedSequence, HarmonyHelpers.PatchMode.REPLACE, HarmonyHelpers.CheckMode.NONNULL);
                }

            }
        }
        [HarmonyPatch(typeof(PLFactionInfo_Infected), "OnSectorAcquired")]
        class InfectedNameChanger
        {
            private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
            {
                List<CodeInstruction> TargetSequence = new List<CodeInstruction>()
                    {
                        new CodeInstruction(OpCodes.Callvirt, AccessTools.Method(typeof(PLSectorInfo), "ClearAndRemovePSIs")),
                        new CodeInstruction(OpCodes.Ldarg_1),
                        new CodeInstruction(OpCodes.Callvirt, AccessTools.Method(typeof(PLSectorInfo), "ServerSetChanged")),
                    };
                List<CodeInstruction> InjectedSequence = new List<CodeInstruction>()
                    {
                        new CodeInstruction(OpCodes.Ldarg_1),
                        new CodeInstruction(OpCodes.Ldstr, "Rebels"),
                        new CodeInstruction(OpCodes.Stfld, AccessTools.Field(typeof(PLSectorInfo), "Name")),
                    };
                return HarmonyHelpers.PatchBySequence(instructions, TargetSequence, InjectedSequence, HarmonyHelpers.PatchMode.AFTER, HarmonyHelpers.CheckMode.NONNULL);
            }
        }
        [HarmonyPatch(typeof(PLFactionInfo_WD), "CreateStartingPoints")]
        internal class WDStartingPoint // adds the WD Hub and the surrounding areas
        {
            [HarmonyPrefix]
            public static bool Prefix()
            {
                PLGalaxy plgalaxy = new PLGalaxy();
                PLFactionInfo_WD plFactionInfoWD = new PLFactionInfo_WD();
                PLFactionInfo pLFactioninfo = new PLFactionInfo();
                int num = 200;
                for (int i = 0; i < num; i++)
                {
                    for (int j = 0; j < 1200; j++)
                    {
                        PLSectorInfo randomFreeSectorInfo = PLServer.GetSectorWithID(20000);
                        if (randomFreeSectorInfo != null && (j > 1000 || Vector2.SqrMagnitude(randomFreeSectorInfo.Position) > 0.2f * plgalaxy.GenGalaxyScale * UnityEngine.Random.Range(1f, 2f)))
                        {
                            randomFreeSectorInfo.MySPI.Faction = 2;
                            randomFreeSectorInfo.LockedToFaction = true;
                            randomFreeSectorInfo.FactionStrength = 200f * plgalaxy.GenerationSettings.InfectionInitialStrength;
                            plFactionInfoWD.StartingPoints.Add(randomFreeSectorInfo);
                            using (List<PLSectorInfo>.Enumerator enumerator = plgalaxy.GridSearch_FindSectorsWithinRange(randomFreeSectorInfo.Position, 0.0016f, randomFreeSectorInfo).GetEnumerator())
                            {
                                while (enumerator.MoveNext())
                                {
                                    PLSectorInfo plsectorInfo = enumerator.Current;
                                    if (plsectorInfo != null && plsectorInfo.MySPI.Faction == -1)
                                    {
                                        plsectorInfo.MySPI.Faction = 2;
                                        plsectorInfo.Name = "Rebels";
                                        PulsarPluginLoader.Utilities.Logger.Info(plsectorInfo.ID.ToString() + " has been converted to the Rebels!");
                                    }
                                    //if (plsectorInfo != null)
                                    //{
                                    //    PLServer.Instance.AllPSIs.Add(new PLPersistantShipInfo(EShipType.E_INFECTED_CARRIER, 4, randomFreeSectorInfo, 0, false, false, false, -1, -1));
                                    //}
                                }
                                break;
                            }
                        }
                    }
                }
                return false;
            }
        }
        [HarmonyPatch(typeof(PLFactionInfo), "ShouldTakeSector")]
        class WDTakesAllSectors // changes result of ShouldTakeSector to true if it's W.D.
        {
            static void Postfix(PLSectorInfo mySector, PLSectorInfo otherSector, PLFactionInfo otherFaction, ref bool __result)
            {
                if (!__result)
                {
                    if (mySector.MySPI.Faction == 2 && mySector.MySPI.Faction != otherSector.MySPI.Faction)
                    {
                        __result = true;
                        otherSector.Name = "Rebels";
                        return;
                    }
                    else if (otherSector.MySPI.Faction == 2)
                    {
                        __result = false;
                        return;
                    }
                    return;
                }
            }
        }
        [HarmonyPatch(typeof(PLFactionInfo), "OnSectorAcquired")]
        class WDSectorAcquiredNameChanger // changes the name of each acquired sector
        {
            static void Postfix(PLSectorInfo inSector)
            {
                PLEncounterManager.Instance.ClearPersistantEncounterInstanceForSector(inSector.ID);
                PulsarPluginLoader.Utilities.Logger.Info(inSector.ID.ToString());
                if (inSector.ID == 2)
                {
                    inSector.Name = "Rebels";
                }
            }
        }
        [HarmonyPatch(typeof(PLGalaxy), "SetupLongRangeWarpNetworkSector")]
        class WarpGridRemover // removes all long range warp network stations
        {
            [HarmonyPrefix]
            public static bool Prefix()
            {
                return false;
            }
        }
        [HarmonyPatch(typeof(PLFactionInfo_Infected), "CreateStartingPoints")]
        internal class InfectedStartingPoint // removes all infected sectors
        {
            [HarmonyPrefix]
            public static bool Prefix()
            {
                PLGalaxy plgalaxy = new PLGalaxy();
                PLFactionInfo_Infected plfactioninfoinfected = new PLFactionInfo_Infected();
                PLFactionInfo pLFactioninfo = new PLFactionInfo();
                int num = 0;
                for (int i = 0; i < num; i++)
                {
                    for (int j = 0; j < 1200; j++)
                    {
                        PLSectorInfo randomFreeSectorInfo = PLServer.GetSectorWithID(20000);
                        if (randomFreeSectorInfo != null && (j > 1000 || Vector2.SqrMagnitude(randomFreeSectorInfo.Position) > 0.2f * plgalaxy.GenGalaxyScale * UnityEngine.Random.Range(1f, 2f)))
                        {
                            randomFreeSectorInfo.MySPI.Faction = 4;
                            randomFreeSectorInfo.LockedToFaction = true;
                            randomFreeSectorInfo.FactionStrength = 200f * plgalaxy.GenerationSettings.InfectionInitialStrength;
                            plfactioninfoinfected.StartingPoints.Add(randomFreeSectorInfo);
                            using (List<PLSectorInfo>.Enumerator enumerator = plgalaxy.GridSearch_FindSectorsWithinRange(randomFreeSectorInfo.Position, 0.0016f, randomFreeSectorInfo).GetEnumerator())
                            {
                                while (enumerator.MoveNext())
                                {
                                    PLSectorInfo plsectorInfo = enumerator.Current;
                                    if (plsectorInfo != null && plsectorInfo.MySPI.Faction == -1)
                                    {
                                        plsectorInfo.MySPI.Faction = 4;
                                    }
                                }
                                break;
                            }
                        }
                    }
                }
                return false;
            }
        }

        /*  [HarmonyPatch(typeof(PLStarmap), "ShouldShowSector")]
          class StarmapBlinder
          {
              [HarmonyPrefix]
              public static bool Prefix(PLSectorInfo sectorInfo)
              {
                  if (sectorInfo != null && sectorInfo.IsThisSectorWithinPlayerWarpRange())
                  {
                      bool shouldshow = sectorInfo.VisualIndication == ESectorVisualIndication.GWG && PLServer.Instance != null;

                     // return (sectorInfo.Name != sectorInfo.ID.ToString() || sectorInfo.VisualIndication == ESectorVisualIndication.AOG_MISSIONCHAIN_PRISONBREAK || shouldshow || sectorInfo.VisualIndication == ESectorVisualIndication.RACING_SECTOR_3 || sectorInfo.VisualIndication == ESectorVisualIndication.RACING_SECTOR_2 || sectorInfo.VisualIndication == ESectorVisualIndication.RACING_SECTOR || sectorInfo.VisualIndication == ESectorVisualIndication.ALCHEMIST || sectorInfo.VisualIndication == ESectorVisualIndication.DESERT_HUB || sectorInfo.VisualIndication == ESectorVisualIndication.SWARM_CMDR || sectorInfo.VisualIndication == ESectorVisualIndication.DEATHSEEKER_COMMANDER || sectorInfo.VisualIndication == ESectorVisualIndication.INTREPID_SECTOR_CMDR || sectorInfo.VisualIndication == ESectorVisualIndication.SPACE_SCRAPYARD || sectorInfo.VisualIndication == ESectorVisualIndication.AOG_HUB || sectorInfo.VisualIndication == ESectorVisualIndication.ANCIENT_SENTRY || sectorInfo.VisualIndication == ESectorVisualIndication.GENERAL_STORE || sectorInfo.VisualIndication == ESectorVisualIndication.EXOTIC1 || sectorInfo.VisualIndication == ESectorVisualIndication.EXOTIC2 || sectorInfo.VisualIndication == ESectorVisualIndication.EXOTIC3 || sectorInfo.VisualIndication == ESectorVisualIndication.WARP_NETWORK_STATION || PLServer.Instance.m_ShipCourseGoals.Contains(sectorInfo.ID) || sectorInfo.MissionSpecificID != -1) && (sectorInfo.MissionSpecificID == -1 || PLServer.Instance.HasActiveMissionWithID(sectorInfo.MissionSpecificID)) && sectorInfo.VisualIndication != ESectorVisualIndication.COMET;
                  }
                  else
                  {
                      return false;
                  }
              }
          } */


        /*
        [HarmonyPatch(typeof(PLGalaxy), "CreateExoticShops")]
        internal class FlagshipStronker
        {
            private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
            {
                List<CodeInstruction> TargetSequence = new List<CodeInstruction>()
                {
                    new CodeInstruction(OpCodes.Ldloc_S, 22),
                    new CodeInstruction(OpCodes.Ldc_I4_S, 17),
                    new CodeInstruction(OpCodes.Callvirt, AccessTools.Method(typeof(PLSectorInfo), "set_VisualIndication", new Type[] { typeof(ESectorVisualIndication)})),
                };
                List<CodeInstruction> InjectedSequence = new List<CodeInstruction>()
                {
                    new CodeInstruction(OpCodes.Ldloc_S, 22),
                    new CodeInstruction(OpCodes.Ldc_I4_0),
                    new CodeInstruction(OpCodes.Callvirt, AccessTools.Method(typeof(PLSectorInfo), "set_VisualIndication", new Type[] { typeof(ESectorVisualIndication)})),
                };
                return HarmonyHelpers.PatchBySequence(instructions, TargetSequence, InjectedSequence, HarmonyHelpers.PatchMode.REPLACE, HarmonyHelpers.CheckMode.NONNULL);
            }
        }
            [HarmonyPatch(typeof(PLGalaxy), "CreateExoticShops")]
            internal class GrimCutLassRemover
            {
                private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
                {
                    List<CodeInstruction> TargetSequence = new List<CodeInstruction>()
                    {
                        new CodeInstruction(OpCodes.Ldloc_S, 22),
                        new CodeInstruction(OpCodes.Ldc_I4_S, 17),
                        new CodeInstruction(OpCodes.Callvirt, AccessTools.Method(typeof(PLSectorInfo), "set_VisualIndication", new Type[] { typeof(ESectorVisualIndication)})),
                    };
                    List<CodeInstruction> InjectedSequence = new List<CodeInstruction>()
                    {
                        new CodeInstruction(OpCodes.Ldloc_S, 22),
                        new CodeInstruction(OpCodes.Ldc_I4_0),
                        new CodeInstruction(OpCodes.Callvirt, AccessTools.Method(typeof(PLSectorInfo), "set_VisualIndication", new Type[] { typeof(ESectorVisualIndication)})),
                    };
                    return HarmonyHelpers.PatchBySequence(instructions, TargetSequence, InjectedSequence, HarmonyHelpers.PatchMode.REPLACE, HarmonyHelpers.CheckMode.NONNULL);
                }
        */
    }
}

