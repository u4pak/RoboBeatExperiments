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

[assembly: MelonInfo(typeof(RoboBeater), "MiniRobo", "1.0", "shady")]
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

        // gameplay scene checks
        public override void OnSceneWasLoaded(int buildIndex, string sceneName)
        {
            if (sceneName == "AlwaysGameplay" || sceneName == "DontDestroyOnLoad" || sceneName == "HideAndDontSave")
            {
                LoggerInstance.Msg($"Ignoring persistent scene. ({sceneName})");
                return;
            }
            if (sceneName == "Main_Menu" || sceneName == "ROBOBEAT_INTRODUCTION" || sceneName == "ROBOBEAT_ENDLESS")
            {
                LoggerInstance.Msg($"Blacklisted scene loaded, normalizing size. ({sceneName})");
                SetSize(1f);
            }
            else { LoggerInstance.Msg($"Entered valid gameplay scene, shrinking player size. ({sceneName})"); SetSize(0.25f); }
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
    }
}
