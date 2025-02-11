using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using SailwindModdingHelper;
using static OVRPlugin;
using static OVRHeadsetEmulator;
using System.Globalization;

namespace SailwindDifficulty
{
    internal class Patches
    {

        [HarmonyPatch(typeof(StarterSet), "InitiateStarterSet")]
        internal static class StarterSetPatches
        {
            public static void Prefix(StarterSet __instance, PortRegion ___region)
            {
                if (Plugin.difficulty.Value == Difficulty.Easy || Plugin.difficulty.Value == Difficulty.Casual)
                {
                    PlayerGold.currency[(int)___region] *= 2;
                }

                if (___region == PortRegion.medi)
                {
                    var mug = __instance.transform.Find("100 mug wood");
                    Vector3 pos = mug.localPosition;
                    Quaternion rot = mug.localRotation;
                    mug.GetComponent<ShipItem>().DestroyItem();
                    var mug2 = UnityEngine.Object.Instantiate(SaveLoadManager.instance.GetComponent<PrefabsDirectory>().directory[102], __instance.transform);
                    mug2.transform.localPosition = pos;
                    mug2.transform.localRotation = rot;

                    if (Plugin.difficulty.Value == Difficulty.Hard)
                    {
                        __instance.transform.Find("10 barrel water").GetComponent<ShipItem>().DestroyItem();
                        __instance.transform.Find("82 compass M").GetComponent<ShipItem>().DestroyItem();
                        __instance.transform.Find("114 lantern M").GetComponent<ShipItem>().DestroyItem();
                        __instance.transform.Find("91 scroll tutorial M").GetComponent<ShipItem>().DestroyItem();
                        __instance.transform.Find("118 map M").GetComponent<ShipItem>().DestroyItem();
                        mug2.GetComponent<ShipItemBottle>().amount = 1;
                        mug2.GetComponent<ShipItemBottle>().health = 3;
                    }
                    else if (Plugin.difficulty.Value == Difficulty.Casual)
                    {
                        __instance.transform.Find("52 cheese").GetComponent<ShipItem>().DestroyItem();
                        var water = __instance.transform.Find("10 barrel water");
                        Vector3 barrelPos = water.transform.localPosition;
                        Quaternion barrelRot = water.transform.localRotation;
                        water.GetComponent<ShipItem>().DestroyItem();

                        var booze = UnityEngine.Object.Instantiate(SaveLoadManager.instance.GetComponent<PrefabsDirectory>().directory[11], __instance.transform);
                        booze.transform.localPosition = barrelPos;
                        booze.transform.localRotation = barrelRot;
                        booze.GetComponent<ShipItem>().sold = true;
                        booze.GetComponent<SaveablePrefab>().RegisterToSave();
                        booze.GetComponent<Good>().RegisterAsMissionless();
                    }
                    else
                    {
                        __instance.transform.Find("52 cheese").GetComponent<ShipItem>().DestroyItem();
                        GameObject cheeseCrate = UnityEngine.Object.Instantiate(SaveLoadManager.instance.GetComponent<PrefabsDirectory>().directory[7], __instance.transform);
                        cheeseCrate.transform.localPosition = new Vector3(-5.179f, 1.7333f, -2.289f);
                        cheeseCrate.transform.localEulerAngles = new Vector3(0f, 75.478f, 0f);
                        cheeseCrate.GetComponent<ShipItem>().sold = true;
                        cheeseCrate.GetComponent<SaveablePrefab>().RegisterToSave();
                        cheeseCrate.GetComponent<Good>().RegisterAsMissionless();

                    }
                }
                if (___region == PortRegion.alankh)
                {
                    if (Plugin.difficulty.Value == Difficulty.Hard)
                    {
                        __instance.transform.Find("80 compass A").GetComponent<ShipItem>().DestroyItem();
                        __instance.transform.Find("110 lantern A").GetComponent<ShipItem>().DestroyItem();
                        __instance.transform.Find("91 scroll tutorial A").GetComponent<ShipItem>().DestroyItem();
                        __instance.transform.Find("116 map A").GetComponent<ShipItem>().DestroyItem();
                        __instance.transform.Find("10 barrel water").GetComponent<ShipItem>().DestroyItem();
                        __instance.transform.Find("8 crate goat cheese (good)").GetComponent<ShipItem>().DestroyItem();

                        var mug = __instance.transform.Find("101 mug clay").gameObject.GetComponent<ShipItemBottle>();
                        mug.amount = 1;
                        mug.health = 3;

                        GameObject goatCheese = UnityEngine.Object.Instantiate(SaveLoadManager.instance.GetComponent<PrefabsDirectory>().directory[53], __instance.transform);
                        goatCheese.transform.localPosition = new Vector3(3.33f, 1.8f, 1.47f);
                        goatCheese.GetComponent<ShipItem>().sold = true;
                        goatCheese.GetComponent<SaveablePrefab>().RegisterToSave();

                    }
                    else if (Plugin.difficulty.Value == Difficulty.Casual)
                    {
                        __instance.transform.Find("8 crate goat cheese (good)").GetComponent<ShipItem>().DestroyItem();
                        var water = __instance.transform.Find("10 barrel water");
                        Vector3 pos = water.transform.localPosition;
                        Quaternion rotation = water.transform.localRotation;
                        water.GetComponent<ShipItem>().DestroyItem();

                        var booze = UnityEngine.Object.Instantiate(SaveLoadManager.instance.GetComponent<PrefabsDirectory>().directory[11], __instance.transform);
                        booze.transform.localPosition = pos;
                        booze.transform.localRotation = rotation;
                        booze.GetComponent<ShipItem>().sold = true;
                        booze.GetComponent<SaveablePrefab>().RegisterToSave();
                        booze.GetComponent<Good>().RegisterAsMissionless();
                    }
                }
                if (___region == PortRegion.emerald)
                {
                    if (Plugin.difficulty.Value == Difficulty.Hard)
                    {
                        __instance.transform.Find("81 compass E").GetComponent<ShipItem>().DestroyItem();
                        __instance.transform.Find("111 lantern E yellow").GetComponent<ShipItem>().DestroyItem();
                        __instance.transform.Find("91 scroll tutorial E").GetComponent<ShipItem>().DestroyItem();
                        __instance.transform.Find("117 map E").GetComponent<ShipItem>().DestroyItem();

                        __instance.transform.Find("10 barrel water").GetComponent<ShipItem>().DestroyItem();
                        __instance.transform.Find("1 crate salmon (E)").GetComponent<ShipItem>().DestroyItem();
                        var mug = __instance.transform.Find("100 mug wood").GetComponent<ShipItemBottle>();
                        mug.amount = 1;
                        mug.health = 3;

                        GameObject salmon = UnityEngine.Object.Instantiate(SaveLoadManager.instance.GetComponent<PrefabsDirectory>().directory[33], __instance.transform);
                        salmon.transform.localPosition = new Vector3(1f, 0.43f, 1f);
                        salmon.GetComponent<ShipItem>().amount = 1.1f;
                        salmon.GetComponent<ShipItem>().sold = true;
                        salmon.GetComponent<SaveablePrefab>().RegisterToSave();

                    }
                    else if (Plugin.difficulty.Value == Difficulty.Casual)
                    {
                        __instance.transform.Find("1 crate salmon (E)").GetComponent<ShipItem>().DestroyItem();
                        var water = __instance.transform.Find("10 barrel water");
                        Vector3 pos = water.transform.localPosition;
                        Quaternion rotation = water.transform.localRotation;
                        water.GetComponent<ShipItem>().DestroyItem();

                        var booze = UnityEngine.Object.Instantiate(SaveLoadManager.instance.GetComponent<PrefabsDirectory>().directory[11], __instance.transform);
                        booze.transform.localPosition = pos;
                        booze.transform.localRotation = rotation;
                        booze.GetComponent<ShipItem>().sold = true;
                        booze.GetComponent<SaveablePrefab>().RegisterToSave();
                        booze.GetComponent<Good>().RegisterAsMissionless();

                    }
                }
                //Plugin.sleepMult.Value = Plugin.defaultMultipliers.ElementAt((int)Plugin.difficulty.Value);


                Debug.Log("SailwindDifficulty: adjusted starter set");
            }

        }

        [HarmonyPatch(typeof(PortDude))]
        internal static class PortDudePatches
        {
            [HarmonyPatch("ActivateMissionListUI")]
            [HarmonyPrefix]
            public static bool ActivateMissionListUIPatch(bool openEconomyUI, Port ___port)
            {
                if (openEconomyUI && Plugin.instantTrade.Value)
                {
                    EconomyUI.instance.OpenUI(___port.GetComponent<IslandMarket>());
                    return false;
                }
                return true;
            }
        }

        [HarmonyPatch(typeof(PlayerNeeds))]
        internal static class PlayerNeedsPatches
        {
            [HarmonyPatch("DrainEnergyFromMovement")]
            [HarmonyPrefix]
            public static bool DrainEnergyPatch(float ___sleepDebt, float ___water, float ___sleep, float ___food, float ___foodDebt)
            {
                bool limitingSpeed = false;
                //LimitSpeed();
                bool coolDown = (bool)PlayerNeedsUI.instance.GetPrivateField("warningActive");

                if (___sleep < 1 || ___food < 1 || ___water < 5)
                {
                    if (___sleepDebt < 5 || ___foodDebt < 5 || ___water < 1)
                    {
                        if (!Refs.ovrController.IsWalking())
                        {
                            Refs.ovrController.SetMoveScaleMultiplier(0.5f);
                            Debug.Log("testbed: setting MoveScaleMult to 0.5");
                            limitingSpeed = true;
                        }
                        if (Refs.ovrController.IsRunning())
                        {
                            Refs.ovrController.SetMoveScaleMultiplier(0.3f);
                            Debug.Log("testbed: setting MoveScaleMult to 0.3");
                            limitingSpeed = true;
                        }

                    }
                    else if (Refs.ovrController.IsRunning())
                    {
                        Refs.ovrController.SetMoveScaleMultiplier(0.6f);
                        Debug.Log("testbed: setting MoveScaleMult to 0.6");
                        limitingSpeed = true;
                    }

                    if (!coolDown && limitingSpeed)
                    {
                        if (___sleep < 1)
                        {
                            PlayerNeedsUI.instance.InvokePrivateMethod("PlayWarning", PlayerNeedsUI.instance.GetPrivateField("sleepBar"), false);
                        }
                        if (___water < 5 && !coolDown)
                        {
                            PlayerNeedsUI.instance.InvokePrivateMethod("PlayWarning", PlayerNeedsUI.instance.GetPrivateField("waterBar"), false);
                        }
                        if (___food < 1)
                        {
                            PlayerNeedsUI.instance.InvokePrivateMethod("PlayWarning", PlayerNeedsUI.instance.GetPrivateField("foodBar"), false);
                        }
                    }
                }
                if (limitingSpeed == false)
                {
                    Refs.ovrController.SetMoveScaleMultiplier(1f);
                }
                if (Plugin.difficulty.Value == Difficulty.Normal || Plugin.difficulty.Value == Difficulty.Hard || limitingSpeed)
                {
                    return false;
                }
                return true;
            }
        }

        [HarmonyPatch(typeof(Sleep))]
        internal static class SleepPatches
        {
            /*[HarmonyPatch("FallAsleep")]
            [HarmonyPrefix]
            public static bool Prefix()
            {
                if (Plugin.difficulty.Value == "easy" && !GameState.inBed)
                {
                    return false;
                }
                return true;
            }*/
            [HarmonyPatch("Update")]
            [HarmonyPostfix]
            public static void Postfix(float ___currentSleepDuration)
            {
                if (Plugin.difficulty.Value == Difficulty.Easy && GameState.sleeping && !GameState.inBed && !GameState.recovering && ___currentSleepDuration > 2f)
                {
                    Sleep.instance.WakeUp();
                }   
            }
        }

        [HarmonyPatch(typeof(PlayerNeeds))]
        internal static class NeedsPatches
        {
            [HarmonyPatch("PassOut")]
            [HarmonyPrefix]
            public static bool PassOut()
            {
                if (Plugin.difficulty.Value == Difficulty.Easy || Plugin.difficulty.Value == Difficulty.Casual)
                {
                    return false;
                }
                return true;
            }

            [HarmonyPatch("LateUpdate")]
            [HarmonyPrefix]
            public static bool LateUpdate(ref float ___alcohol, ref float ___sleepDebt, ref float ___sleep, ref float ___food, ref float ___water, ref float ___vitamins, ref float ___protein)
            {
                if (!GameState.playing || GameState.recovering || (bool)GameState.currentShipyard || (EconomyUI.instance.uiActive && !Debugger.buildDebugModeOn))
                {
                    return true;
                }


                if (Plugin.difficulty.Value == Difficulty.Casual)
                {
                    ___alcohol -= Time.deltaTime * 12f * Sun.sun.timescale;
                    if (___alcohol > 100f)
                    {
                        ___alcohol = 100f;
                    }

                    if (___alcohol < 0f)
                    {
                        ___alcohol = 0f;
                    }

                    if (GameState.sleeping)
                    {
                        float num = Time.deltaTime * 8f * Sun.sun.timescale;
                        if (GameState.sleepingInTavern)
                        {
                            num *= 4f;
                        }

                        if (___sleepDebt < 100f)
                        {
                            ___sleepDebt += num;
                            num *= 0.2f;
                        }

                        ___sleep = Mathf.Min(___sleep + num, 100f);
                    }
                    else
                    {
                        //___sleep -= Time.deltaTime * Sun.sun.timescale * 5f;
                        ___sleep -= Time.deltaTime * Sun.sun.timescale * 15f * (___alcohol / 100f);
                    }
                    return false;
                }
                ___sleep += Time.deltaTime * Sun.sun.timescale * 5f * (1 - Plugin.sleepMult.Value);
                ___food += Time.deltaTime * Sun.sun.timescale * 3f * (1 - Plugin.foodMult.Value);
                ___water += Time.deltaTime * Sun.sun.timescale * 4f * (1 - Plugin.waterMult.Value);
                ___vitamins += Time.deltaTime * Sun.sun.timescale * 0.2f * (1 - Plugin.nutritionMult.Value);
                ___protein += Time.deltaTime * Sun.sun.timescale * 0.2f * (1 - Plugin.nutritionMult.Value);

                return true;
            }
        }


        internal static class DisableSwitchCamPatches
        {
            [HarmonyPatch(typeof(BoatCamera), "SwitchOn")]
            private static class UpdatePatch
            {
                [HarmonyPrefix]
                public static bool Prefix()
                {
                    if (Plugin.difficulty.Value == Difficulty.Hard && Plugin.hardCam.Value && !GameState.currentShipyard)
                    {
                        return false;
                    }

                    return true;
                }
            }
        }

        [HarmonyPatch(typeof(SaveLoadManager))]
        internal static class LoadPatch
        {
            const char sep = '\u001f';
            //static char test = '\u001e';
            [HarmonyPatch("LoadModData")]
            [HarmonyPostfix]
            public static void LoadData()
            {
                if (GameState.modData.ContainsKey(Plugin.PLUGIN_ID))
                {
                    GameState.modData.TryGetValue(Plugin.PLUGIN_ID, out string slug);

                    string[] strings = slug.Split(sep);

                    Enum.TryParse(strings[0], out Difficulty diff);
                    Plugin.difficulty.Value = diff;
                    Debug.Log("difficulty = " + Plugin.difficulty.Value);

                    if (strings.Length >= 5)
                    {
                        float[] floats = new float[4];
                        for (int i = 0; i < floats.Length; i++)
                        {
                            floats[i] = Mathf.Max(float.Parse(strings[i + 1], CultureInfo.InvariantCulture), 0f);
#if DEBUG
                            Debug.Log("float " + i + " = " + floats[i].ToString());
#endif
                        }
                        Plugin.sleepMult.Value = floats[0];
                        Plugin.foodMult.Value = floats[1];
                        Plugin.waterMult.Value = floats[2];
                        Plugin.nutritionMult.Value = floats[3];
                        Debug.Log("SailwindDifficulty set needs multipliers from save");
                    }

                }
                
            }

            [HarmonyPatch("SaveModData")]
            [HarmonyPostfix]
            public static void SavaData()
            {
                string text = Plugin.difficulty.Value.ToString();
                if (Plugin.sleepMult.Value != Plugin.defaultMultipliers[(int)Plugin.difficulty.Value][0] || Plugin.foodMult.Value != Plugin.defaultMultipliers[(int)Plugin.difficulty.Value][1] || Plugin.waterMult.Value != Plugin.defaultMultipliers[(int)Plugin.difficulty.Value][2] || Plugin.nutritionMult.Value != Plugin.defaultMultipliers[(int)Plugin.difficulty.Value][3])
                {
                    text += sep + Plugin.sleepMult.Value.ToString(CultureInfo.InvariantCulture);
                    text += sep + Plugin.foodMult.Value.ToString(CultureInfo.InvariantCulture);
                    text += sep + Plugin.waterMult.Value.ToString(CultureInfo.InvariantCulture);
                    text += sep + Plugin.nutritionMult.Value.ToString(CultureInfo.InvariantCulture);
                }
                if (GameState.modData.ContainsKey(Plugin.PLUGIN_ID))
                {
                    GameState.modData[Plugin.PLUGIN_ID] = text;
                }
                else
                {
                    GameState.modData.Add(Plugin.PLUGIN_ID, text);
                }
                Debug.Log(text);
            }
        }

        #region menu patches
        [HarmonyPatch(typeof(StartMenu))]
        internal static class StartMenuPatch
        {
            [HarmonyPatch("Awake")]
            [HarmonyPostfix]
            public static void Postfix(GameObject ___decoMedi, GameObject ___chooseIslandUI)
            {
                Transform panelParent = UnityEngine.Object.Instantiate(new GameObject() { name = "diffPanel" }.transform, ___chooseIslandUI.transform);
                var newButton = UnityEngine.Object.Instantiate(___chooseIslandUI.transform.GetChild(2), panelParent);
                newButton.name = "button difficulty";
                var newPanel = UnityEngine.Object.Instantiate(___decoMedi.transform.GetChild(6), panelParent);
                var newText = UnityEngine.Object.Instantiate(___decoMedi.transform.GetChild(2), panelParent);
                newText.name = "description";
                newText.GetComponent<TextMesh>().anchor = TextAnchor.UpperLeft;
                newText.GetComponent<TextMesh>().fontSize = 70;
                var newTitle = UnityEngine.Object.Instantiate(___decoMedi.transform.GetChild(8), panelParent);
                newTitle.name = "title";
                newTitle.gameObject.SetActive(false);

                newPanel.localPosition = new Vector3(0, 0, 0);
                newPanel.localScale = new Vector3(3.65f, 3f, 4.8457f);
                newText.localPosition = new Vector3(-0.69f, 0.2f, -0.1f);
                newTitle.localPosition = new Vector3(1.5f, 0.55f, -0.3f);

                newButton.localPosition = new Vector3(0.09f, 0.4f, -0.1f);
                newButton.localScale = new Vector3(0.9f, 0.9f, 0.9f);
                var trigger = newButton.GetChild(0);
                UnityEngine.Object.Destroy(trigger.GetComponent<StartMenuButton>());
                var component = trigger.gameObject.AddComponent<DifficultyButton>();
                component.difficultyDesc = newText.GetComponent<TextMesh>();

                panelParent.localPosition = new Vector3(2.1f, -0.3f, 0);
            }
        }
        #endregion
    }
}
