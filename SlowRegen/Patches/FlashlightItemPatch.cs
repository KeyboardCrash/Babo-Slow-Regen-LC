using GameNetcodeStuff;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace SlowRegen.Patches
{
    public enum Flashlights
    {
        ProFlashlight,
        Flashlight,
    }

    [HarmonyPatch(typeof(FlashlightItem))]
    internal class FlashlightItemPatch
    {
        [HarmonyPatch("ItemActivate")]
        [HarmonyPrefix]
        static void modifyFlashlightDuration(ref FlashlightItem __instance)
        {
/*
            switch ((Flashlights)__instance.flashlightTypeID)
            {
                case Flashlights.ProFlashlight:
                    ((GrabbableObject)__instance).itemProperties.batteryUsage = 285f;
                    break;
                case Flashlights.Flashlight:
                    ((GrabbableObject)__instance).itemProperties.batteryUsage = 140f;
                    break;
            }
*/
        }

    }
}
