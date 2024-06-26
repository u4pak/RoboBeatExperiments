﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MelonLoader;
using RoboBeatExperiments;
using UnityEngine;
using System.Reflection;
using HarmonyLib;

[assembly: MelonInfo(typeof(RoboBeater), "RoboBeatExperiments", "1.0", "shady")]
[assembly: MelonGame("Inzanity", "ROBOBEAT")]

namespace RoboBeatExperiments
{
    public class RoboBeater : MelonMod
    {
        public static RoboBeater instance;

        // private static KeyCode noClipToggleKey;
        // private static KeyCode cheatMenuToggleKey;

        // private static bool isNoClipping = false;
        // private static bool isCheatMenuShowing = false;

        // setup
        public override void OnEarlyInitializeMelon()
        {
            instance = this;
            GameManager.CheatEngineEnabled = true;
            // noClipToggleKey = KeyCode.N;
            // cheatMenuToggleKey = KeyCode.Backslash;
        }

        
        // keybind press check
        public override void OnLateUpdate()
        {
            /*
            if (Input.GetKeyDown(noClipToggleKey))
            {
                ToggleNoClip();
            }
            
            if (Input.GetKeyDown(cheatMenuToggleKey))
            {
                ToggleCheatMenu();
            }
            */
        }


        // gameplay scene checks
        /*
        public override void OnSceneWasLoaded(int buildIndex, string sceneName)
        {
            if (sceneName == "AlwaysGameplay" || sceneName == "DontDestroyOnLoad" || sceneName == "HideAndDontSave")
            {
                LoggerInstance.Msg($"Ignoring persistent scene. ({sceneName})");
                return;
            }
            if (sceneName == "Main_Menu" || sceneName == "ROBOBEAT_INTRODUCTION" || sceneName == "ROBOBEAT_ENDLESS")
            {
                // LoggerInstance.Msg($"Blacklisted scene loaded, normalizing size. ({sceneName})");
                // SetSize(1f);
                LoggerInstance.Msg($"Blacklisted scene loaded, doing nothing. ({sceneName})");
            }
            // else { LoggerInstance.Msg($"Entered valid gameplay scene, shrinking player size. ({sceneName})"); SetSize(0.25f); }
            else { LoggerInstance.Msg($"Entered valid gameplay scene, setting player health to one. ({sceneName})"); SetHealth(1f); }
        }
        

        // shrinker
        private static void SetSize(float size)
        {

            GameObject[] allObjects = UnityEngine.Object.FindObjectsOfType<GameObject>(true);

            foreach (GameObject obj in allObjects)
            {
                if (obj.name == "Player")
                {
                    obj.transform.localScale = new Vector3(size, size, size);
                }
            }
        }

        // noclip
        private static void ToggleNoClip()
        {
            GameObject[] allObjects = UnityEngine.Object.FindObjectsOfType<GameObject>(true);

            foreach (GameObject obj in allObjects)
            {
                if (obj.name == "Player")
                {
                    PlayerController playerController = obj.GetComponent<PlayerController>();

                    playerController.NoClipping = !isNoClipping;
                }
            }

            isNoClipping = !isNoClipping;
        }
        */

        // cheat menu
        /*
        private static void ToggleCheatMenu()
        {
            GameObject[] allObjects = UnityEngine.Object.FindObjectsOfType<GameObject>(true);
            
            foreach (GameObject obj in allObjects)
            {
                if (obj.name == "Cheat Menu")
                {
                    if (!isCheatMenuShowing)
                    {
                        UserInterfaceReferences.Instant.UI_ModeSwapper.SwapToMode(UI_Mode.CheatMenu, false, false);
                    }
                    else
                    {
                        UserInterfaceReferences.Instant.UI_ModeSwapper.SwapToMode(UI_Mode.InGame, false, false);
                    }

                    isCheatMenuShowing = !isCheatMenuShowing;
                }
            }
        }
        */

        /*
        // TODO: fix this cause it just doesn't work lol
        private static void SetHealth(float health)
        {
            GameObject[] allObjects = UnityEngine.Object.FindObjectsOfType<GameObject>(true);

            foreach (GameObject obj in allObjects)
            {
                if (obj.name == "Player")
                {
                    Player player = obj.GetComponent<Player>();

                    player.CurrentHealth = 1f;
                }
            }
        }
        */
    }

    /*
    // instakill enemies
    [HarmonyPatch(typeof(Spell), nameof(Spell.CreateDamageInfo))]
    public static class Spell_CreateDamageInfo_Patch
    {
        static void Postfix(ref DamageInfo __result)
        {
            __result.Damage = 99999f;
        }
    }
    

    // instakill player
    [HarmonyPatch(typeof(Player), nameof(Player.Damage))]
    public static class Player_Damage_Patch
    {
        static bool Prefix(ref DamageInfo info)
        {
            info.Damage = 100f;
            MelonLogger.Msg("modified dmg");
            return true;
        }
    }
    */
}
