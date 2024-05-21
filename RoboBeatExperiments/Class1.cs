using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MelonLoader;
using RoboBeatExperiments;
using UnityEngine;
using System.Reflection;
using HarmonyLib;

[assembly: MelonInfo(typeof(RoboBeater), "DeathMaxxing", "1.0", "shady")]
[assembly: MelonGame("Inzanity", "ROBOBEAT")]

namespace RoboBeatExperiments
{
    public class RoboBeater : MelonMod
    {
        public static RoboBeater instance;

        // setup
        public override void OnEarlyInitializeMelon()
        {
            instance = this;
        }
    }

    // instakill player
    [HarmonyPatch(typeof(Player), nameof(Player.Damage))]
    public static class Player_Damage_Patch
    {
        static bool Prefix(ref DamageInfo info)
        {
            info.Damage = 100f;
            MelonLogger.Msg("Overrided damage. Have fun dying!");
            return true;
        }
    }
}
