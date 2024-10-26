using System;
using Harmony;
using HarmonyLib;
using BoneLib;
using Il2CppSLZ.AI;
using Il2CppSLZ.Marrow.AI;
using Il2CppSLZ.VRMK;
using Il2CppTriangleNet;
using Il2CppPuppetMasta;
using Il2CppSLZ.Marrow.PuppetMasta;
using UnityEngine;
using Il2CppSLZ.Marrow;
using MelonLoader;

namespace NullBodyFriends.Patches
{
    [HarmonyLib.HarmonyPatch(typeof(RigManager), "SwitchAvatar")]
    public class TriggerRefPatch
    {
        public static void Postfix(TriggerRefProxy __instance)
        {
            MelonLogger.Msg("TriggerRefProxy Avatar Switched");

            if (BoneLib.Player.RigManager.AvatarCrate.Crate.Title != "PolyBlank")
            {
                __instance.triggerType = TriggerRefProxy.TriggerType.Player;
                if (NullBodyFriends.Core.avatarIsNullBody)
                {
                    MelonLogger.Msg("npcType swapped to FordHair");
                    __instance.npcType = TriggerRefProxy.NpcType.FordHair;
                }
                else
                {
                    MelonLogger.Msg("npcType swapped to nullbody");
                    __instance.npcType = TriggerRefProxy.NpcType.NullBody;
                }
            }
        }
    }

    [HarmonyLib.HarmonyPatch(typeof(RigManager), "SwitchAvatar")]
    public class PowerLegsPatch
    {
        public static void Postfix(BehaviourPowerLegs __instance)
        {
            MelonLogger.Msg("BehaviourPowerLegs Avatar Switched");

            if (BoneLib.Player.RigManager.AvatarCrate.Crate.Title != "PolyBlank")
            {
                if (NullBodyFriends.Core.avatarIsNullBody)
                {
                    MelonLogger.Msg("agroOnNpcType Swaped");
                    __instance.agroOnNpcType -= TriggerRefProxy.NpcType.FordHair;
                    __instance.agroOnNpcType = TriggerRefProxy.NpcType.NullBody;
                }
                else
                {
                    MelonLogger.Msg("agroOnNpcType Swaped AGAIN");
                    __instance.agroOnNpcType = TriggerRefProxy.NpcType.FordHair;
                    __instance.agroOnNpcType -= TriggerRefProxy.NpcType.NullBody;
                }
            }
        }
    }

    [HarmonyLib.HarmonyPatch(typeof(RigManager), "SwitchAvatar")]
    public class SubBehaviourPatch
    {
        public static void Postfix(SubBehaviourHealth __instance)
        {
            MelonLogger.Msg(NullBodyFriends.Core.avatarIsNullBody);
            MelonLogger.Msg(BoneLib.Player.RigManager.AvatarCrate.Crate.Title);
            MelonLogger.Msg("AvatarSwitched");
            if (BoneLib.Player.RigManager.AvatarCrate.Crate.Title != "PolyBlank")
            {
                if (NullBodyFriends.Core.avatarIsNullBody)
                {
                    MelonLogger.Msg("Aggression 0");
                    __instance.aggression = 0;
                }
                else
                {
                    MelonLogger.Msg("Aggression 1");
                    __instance.aggression = 1;
                }
            }
        }
    }
}