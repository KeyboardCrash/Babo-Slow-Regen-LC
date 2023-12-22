using BepInEx;
using BepInEx.Logging;
using SlowRegen.Patches;
using GameNetcodeStuff;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlowRegen
{
    [BepInPlugin(PluginInfo.MOD_GUID, PluginInfo.MOD_NAME, PluginInfo.MOD_VERSION)]
    public class Plugin: BaseUnityPlugin
    {
        private readonly Harmony harmony = new Harmony(PluginInfo.MOD_GUID);

        private static Plugin Instance;

        public static ManualLogSource mls;

        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }

            mls = BepInEx.Logging.Logger.CreateLogSource(PluginInfo.MOD_GUID);

            mls.LogInfo("Babo's SlowRegen has started");

            harmony.PatchAll(typeof(Plugin));
            harmony.PatchAll(typeof(PlayerControllerBPatch));
            harmony.PatchAll(typeof(FlashlightItemPatch));
            harmony.PatchAll(typeof(GrabbableObjectPatch));
        }

    }
}
