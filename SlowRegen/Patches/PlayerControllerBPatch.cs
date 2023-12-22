using GameNetcodeStuff;
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
    [HarmonyPatch(typeof(PlayerControllerB))]
    internal class PlayerControllerBPatch
    {
        [HarmonyPatch("LateUpdate")]
        [HarmonyPrefix]
        static void regenerateHpPatch(ref PlayerControllerB __instance)
        {
            if (((NetworkBehaviour)__instance).IsOwner)
            {
                if (GameNetworkManager.Instance.localPlayerController.health < 100)
                {
                    if (GameNetworkManager.Instance.localPlayerController.healthRegenerateTimer <= 0f)
                    {
                        if (__instance.health < 20)
                        {
                            GameNetworkManager.Instance.localPlayerController.healthRegenerateTimer = 1f;
                        }
                        else if (__instance.health < 50)
                        {
                            GameNetworkManager.Instance.localPlayerController.healthRegenerateTimer = 2f;
                        }
                        else if (__instance.health < 75)
                        {
                            GameNetworkManager.Instance.localPlayerController.healthRegenerateTimer = 3f;
                        }
                        if (__instance.IsServer)
                        {
                            __instance.DamagePlayerClientRpc(-1, GameNetworkManager.Instance.localPlayerController.health + 1);
                        }
                        else
                        {
                            __instance.DamagePlayerServerRpc(-1, GameNetworkManager.Instance.localPlayerController.health + 1);
                        }

                        if (__instance.health >= 20)
                        {
                            GameNetworkManager.Instance.localPlayerController.MakeCriticallyInjured(enable: false);
                        }
                        HUDManager.Instance.UpdateHealthUI((int)__instance.health, hurtPlayer: false);
                    }
                    else
                    {
                        GameNetworkManager.Instance.localPlayerController.healthRegenerateTimer -= Time.deltaTime;
                    }
                }
            }

        }

    }
}
