using BepInEx;
using BepInEx.Configuration;
using HarmonyLib;
using System;
using System.Reflection;

namespace SailwindDifficulty
{
    [BepInPlugin(PLUGIN_ID, PLUGIN_NAME, PLUGIN_VERSION)]
    //[BepInDependency("com.app24.sailwindmoddinghelper", "2.0.3")]
    public class Plugin : BaseUnityPlugin
    {
        public const string PLUGIN_ID = "com.yourname.SailwindDifficulty";
        public const string PLUGIN_NAME = "SailwindDifficulty";
        public const string PLUGIN_VERSION = "0.0.1";

        //--settings--
        //internal ConfigEntry<bool> someSetting;
        internal static ConfigEntry<Difficulty> difficulty;
        internal static ConfigEntry<bool> hardCam;
        internal static ConfigEntry<bool> godMode;
        internal static ConfigEntry<bool> instantTrade;

        private void Awake()
        {
            Harmony.CreateAndPatchAll(Assembly.GetExecutingAssembly(), PLUGIN_ID);
            difficulty = Config.Bind("", "Difficulty", Difficulty.Normal, new ConfigDescription("casual: start with more money, sleep/hunger/thirst don't deplete\n easy: start with more supplies/money, don't pass out from hunger/thirst\nnormal: standard starting supplies (aestrin gets a crate of cheese instead of 1 piece)\nhard: start with very little food and no tools."));
            instantTrade = Config.Bind("", "Enable trade book at 0 reputation", true, new ConfigDescription("", null));
            hardCam = Config.Bind("", "Disable external camera on hard", true, new ConfigDescription("", null));
            godMode = Config.Bind("", "Allow casual mode", false, new ConfigDescription("", null));

            //godMode.SettingChanged += (sender, args) => UpdateGodMode(godMode.Value);
        }

        /*public static void UpdateGodMode(bool value)
        {
            if (difficulty.Value == "easy") PlayerNeeds.instance.godMode = value;
            else
            {
                PlayerNeeds.instance.godMode = false;
            }
        }*/


    }
    public enum Difficulty
    {
        Casual,
        Easy,
        Normal,
        Hard
    }
}
