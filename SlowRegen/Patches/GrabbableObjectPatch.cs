using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Netcode;
using UnityEngine;

namespace SlowRegen.Patches
{

    [HarmonyPatch(typeof(GrabbableObject))]
    internal class GrabbableObjectPatch
    {
        [HarmonyPatch("Update")]
        [HarmonyPrefix]
        static void regenerateBatteryUsage(ref GrabbableObject __instance)
        {
            if (((NetworkBehaviour)__instance).IsOwner)
            {
                if (!__instance.isBeingUsed && __instance.itemProperties.requiresBattery)
                {
                    if (__instance.insertedBattery.charge < 1f)
                    {
                        if (!__instance.itemProperties.itemIsTrigger)
                        {
                            __instance.insertedBattery.charge += (Time.deltaTime / (__instance.itemProperties.batteryUsage)) / 2f;
                        }
                    }
                }
            }

        }
    }
}
