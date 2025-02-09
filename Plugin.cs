﻿using BepInEx;
using BepInEx.Configuration;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace SailwindDifficulty
{
    [BepInPlugin(PLUGIN_ID, PLUGIN_NAME, PLUGIN_VERSION)]
    //[BepInDependency("com.app24.sailwindmoddinghelper", "2.0.3")]
    public class Plugin : BaseUnityPlugin
    {
        public const string PLUGIN_ID = "com.nandbrew.sailwinddifficulty";
        public const string PLUGIN_NAME = "Sailwind Difficulty";
        public const string PLUGIN_VERSION = "1.1.0";

        internal static Array[] defaultDiffs = new Array[]
        {
            new float[5] { 0f, 0f, 0f, 0f, 0f},
            new float[5] { 0.7f, 0.7f, 0.7f, 0.7f, 0.7f },
            new float[5] { 1f, 1f, 1f,1f, 1f },
            new float[5] { 1f, 1f, 1f, 1f, 1f },
        };

        //--settings--
        //internal ConfigEntry<bool> someSetting;
        internal static ConfigEntry<Difficulty> difficulty;
        internal static ConfigEntry<bool> hardCam;
        //internal static ConfigEntry<bool> godMode;
        internal static ConfigEntry<bool> instantTrade;

        internal static ConfigEntry<float> sleepMult;
        internal static ConfigEntry<float> foodMult;
        internal static ConfigEntry<float> waterMult;
        internal static ConfigEntry<float> vitaminsMult;

        private void Awake()
        {
            Harmony.CreateAndPatchAll(Assembly.GetExecutingAssembly(), PLUGIN_ID);
            difficulty = Config.Bind("", "Difficulty", Difficulty.Normal, new ConfigDescription("casual: start with more money, sleep/hunger/thirst don't deplete\n easy: start with more supplies/money, don't pass out from hunger/thirst\nnormal: standard starting supplies (aestrin gets a crate of cheese instead of 1 piece)\nhard: start with very little food and no tools."));
            instantTrade = Config.Bind("", "Enable trade book at 0 reputation", true, new ConfigDescription("", null));
            hardCam = Config.Bind("", "Disable external camera on hard", true, new ConfigDescription("", null));
            //godMode = Config.Bind("", "Allow casual mode", false, new ConfigDescription("", null));

            sleepMult = Config.Bind("Needs Multipliers", "sleep multiplier", 1f, new ConfigDescription("Depletion rate. Ignored on Casual", new AcceptableValueRange<float>(0f, 2f), new ConfigurationManagerAttributes { IsAdvanced = true }));
            foodMult = Config.Bind("Needs Multipliers", "food multiplier", 1f, new ConfigDescription("Depletion rate. Ignored on Casual", new AcceptableValueRange<float>(0f, 2f), new ConfigurationManagerAttributes { IsAdvanced = true }));
            waterMult = Config.Bind("Needs Multipliers", "water multiplier", 1f, new ConfigDescription("Depletion rate. Ignored on Casual", new AcceptableValueRange<float>(0f, 2f), new ConfigurationManagerAttributes { IsAdvanced = true }));
            vitaminsMult = Config.Bind("Needs Multipliers", "vitamins multiplier", 1f, new ConfigDescription("Depletion rate. Ignored on Casual", new AcceptableValueRange<float>(0f, 2f), new ConfigurationManagerAttributes { IsAdvanced = true }));

            difficulty.SettingChanged += (sender, args) => UpdateMultipliers();
            difficulty.Value = Difficulty.Normal;
            //UpdateMultipliers();
        }
        internal static void UpdateMultipliers()
        {
            float[] multipliers = (float[])Plugin.defaultDiffs.ElementAt((int)Plugin.difficulty.Value);
            sleepMult.Value = multipliers[0];
            foodMult.Value = multipliers[1];
            waterMult.Value = multipliers[2];
            vitaminsMult.Value = multipliers[3];

        }
    }
    public enum Difficulty
    {
        Casual,
        Easy,
        Normal,
        Hard
    }
}
