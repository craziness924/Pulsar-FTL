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
                    /*
                new CodeInstruction(OpCodes.Newobj, AccessTools.Constructor(typeof(PLSectorInfo))),
                new CodeInstruction(OpCodes.Stloc_S, walter), //4 is walter
                new CodeInstruction(OpCodes.Ldloc_S, walter),
                new CodeInstruction(OpCodes.Ldc_I4_1),
                new CodeInstruction(OpCodes.Stfld, AccessTools.Field(typeof(PLSectorInfo), "Discovered")),
                new CodeInstruction(OpCodes.Ldloc_S, walter),
                new CodeInstruction(OpCodes.Ldc_I4_0),
                new CodeInstruction(OpCodes.Callvirt, AccessTools.Method(typeof(PLSectorInfo), "set_Visited", new Type[] { typeof(bool)})),
                new CodeInstruction(OpCodes.Ldc_R4, 0.1f),
                new CodeInstruction(OpCodes.Stloc_S, walterX), //5 is epic (x position of sector)
                new CodeInstruction(OpCodes.Ldc_R4, -0.04f),
                new CodeInstruction(OpCodes.Stloc_S, walterY), //6 is epic2 (y position of sector)
                new CodeInstruction(OpCodes.Ldc_R4, 0f),
                new CodeInstruction(OpCodes.Stloc_S, walterZ), //7 is epic3 (z position of sector) 
                new CodeInstruction(OpCodes.Ldloc_S, walter),
                new CodeInstruction(OpCodes.Ldloc_S, walterX),
                new CodeInstruction(OpCodes.Ldloc_S, walterY),
                new CodeInstruction(OpCodes.Ldloc_S, walterZ),
                new CodeInstruction(OpCodes.Newobj, AccessTools.Constructor(typeof(Vector3), new Type[] { typeof(float), typeof(float), typeof(float)  })), //may need to add parameters??
                new CodeInstruction(OpCodes.Callvirt, AccessTools.Method(typeof(PLSectorInfo), "set_Position", new Type[] { typeof(UnityEngine.Vector3)})),
                new CodeInstruction(OpCodes.Ldarg_0),
            //    new CodeInstruction(OpCodes.Ldfld, AccessTools.Field(typeof(PLGalaxy), "m_GenGalaxyScale")),
            //    new CodeInstruction(OpCodes.Call, AccessTools.Method(typeof(Vector3), "op_Multiply")),
                new CodeInstruction(OpCodes.Ldfld, AccessTools.Field(typeof(PLGalaxy), "m_AllSectorInfos")),
                new CodeInstruction(OpCodes.Ldc_I4, 0x4E20),
                new CodeInstruction(OpCodes.Ldloc_S, walter),
                new CodeInstruction(OpCodes.Callvirt, AccessTools.Method(typeof(Dictionary<int, PLSectorInfo>), "Add")),
                new CodeInstruction(OpCodes.Ldloc_S, walter),
                new CodeInstruction(OpCodes.Ldc_I4, 0x4E20),
                new CodeInstruction(OpCodes.Stfld, AccessTools.Field(typeof(PLSectorInfo), "ID")),
                new CodeInstruction(OpCodes.Ldloc_S, walter),
                new CodeInstruction(OpCodes.Ldarg_0),
                new CodeInstruction(OpCodes.Ldloca_S, walter),
                new CodeInstruction(OpCodes.Ldc_I4, 0x4E20),
                new CodeInstruction(OpCodes.Call, AccessTools.Method(typeof(SectorProceduralInfo), "Create")),
                new CodeInstruction(OpCodes.Stfld, AccessTools.Field(typeof(PLSectorInfo), "MySPI")),
                new CodeInstruction(OpCodes.Ldloc_S, walter),
                new CodeInstruction(OpCodes.Ldfld, AccessTools.Field(typeof(PLSectorInfo), "MySPI")),
                new CodeInstruction(OpCodes.Ldc_I4_4),
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
                new CodeInstruction(OpCodes.Ldstr, "Walter"),
                new CodeInstruction(OpCodes.Stfld, AccessTools.Field(typeof(PLSectorInfo), "Name")),
                new CodeInstruction(OpCodes.Ldloc_S, walter),
                new CodeInstruction(OpCodes.Ldc_I4_0),
                new CodeInstruction(OpCodes.Callvirt, AccessTools.Method(typeof(PLSectorInfo), "set_VisualIndication", new Type[] { typeof(ESectorVisualIndication)})),
                // end walter sector generator!
                */
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
                new CodeInstruction(OpCodes.Callvirt, AccessTools.Method(typeof(PLSectorInfo), "set_Position", new Type[] { typeof(UnityEngine.Vector3)})),
                new CodeInstruction(OpCodes.Ldarg_0),
            //    new CodeInstruction(OpCodes.Ldfld, AccessTools.Field(typeof(PLGalaxy), "m_GenGalaxyScale")), uncomment if you'd like to multiply position by galaxy scale, may not work I removed it before bug fixing
            //    new CodeInstruction(OpCodes.Call, AccessTools.Method(typeof(Vector3), "op_Multiply")),
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
                        // feel free to add back in the gen scale multipliers, not a big fan of it tho.
                        new CodeInstruction(OpCodes.Ldc_R4, -.80f), //new x position
                        new CodeInstruction(OpCodes.Ldarg_0),
                        new CodeInstruction(OpCodes.Ldfld, AccessTools.Field(typeof(PLGalaxy), "m_GenGalaxyScale")),
                        new CodeInstruction(OpCodes.Ldc_R4, .02f),
                        new CodeInstruction(OpCodes.Mul),
                        new CodeInstruction(OpCodes.Add),
                        new CodeInstruction(OpCodes.Stloc_1),
                        new CodeInstruction(OpCodes.Ldc_R4, 0.3f), //new y position
                        new CodeInstruction(OpCodes.Ldarg_0),
                        new CodeInstruction(OpCodes.Ldfld, AccessTools.Field(typeof(PLGalaxy), "m_GenGalaxyScale")),
                        new CodeInstruction(OpCodes.Ldc_R4, .02f),
                        new CodeInstruction(OpCodes.Mul),
                        new CodeInstruction(OpCodes.Sub),
                        new CodeInstruction(OpCodes.Stloc_2),
                        new CodeInstruction(OpCodes.Ldc_R4, .2f), //new z position
                        new CodeInstruction(OpCodes.Stloc_3)
                    };
                    return HarmonyHelpers.PatchBySequence(instructions, TargetSequence, InjectedSequence, HarmonyHelpers.PatchMode.REPLACE, HarmonyHelpers.CheckMode.NONNULL);
                }

            }
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
    }
