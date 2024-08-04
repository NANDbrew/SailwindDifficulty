using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using SailwindModdingHelper;
using static OVRPlugin;
using static OVRHeadsetEmulator;

namespace SailwindDifficulty
{
    internal class Patches
    {
        [HarmonyPatch(typeof(StartMenu), "Start")]
        internal static class FPatcher
        {
            [HarmonyPostfix]
            public static void UpdatePatch(ref bool ___fPressed)
            {
                ___fPressed = true;

            }
        }

        [HarmonyPatch(typeof(StarterSet), "InitiateStarterSet")]
        internal static class StarterSetPatches
        {
            public static void Prefix(StarterSet __instance, PortRegion ___region, Transform ___starterBoat)
            {

                if (Plugin.difficulty.Value == "hard")
                {
                    if (___region == PortRegion.medi)
                    {
                        UnityEngine.Object.Destroy(__instance.transform.Find("10 barrel water").gameObject);
                        UnityEngine.Object.Destroy(__instance.transform.Find("82 compass M").gameObject);
                        UnityEngine.Object.Destroy(__instance.transform.Find("114 lantern M").gameObject);
                        UnityEngine.Object.Destroy(__instance.transform.Find("91 scroll tutorial M").gameObject);
                        UnityEngine.Object.Destroy(__instance.transform.Find("118 map M").gameObject);
                        //UnityEngine.Object.Destroy(__instance.transform.Find("7 crate cheese (good)").gameObject);

                        /*var mug = __instance.transform.Find("100 mug wood");
                        mugPos = mug.localPosition;
                        UnityEngine.Object.Destroy(mug.gameObject);*/

                        var mug = __instance.transform.Find("100 mug wood");

                        //mug.gameObject.SetActive(false);

                        var mug2 = UnityEngine.Object.Instantiate(SaveLoadManager.instance.GetComponent<PrefabsDirectory>().directory[102], __instance.transform);
                        mug2.transform.localPosition = mug.transform.localPosition;
                        mug2.transform.localRotation = mug.transform.localRotation;
                        UnityEngine.Object.Destroy(mug.gameObject);
                        mug2.GetComponent<ShipItemBottle>().amount = 1;
                        mug2.GetComponent<ShipItemBottle>().health = 3;

                    }
                    if (___region == PortRegion.alankh)
                    {
                        UnityEngine.Object.Destroy(__instance.transform.Find("10 barrel water").gameObject);
                        UnityEngine.Object.Destroy(__instance.transform.Find("80 compass A").gameObject);
                        UnityEngine.Object.Destroy(__instance.transform.Find("110 lantern A").gameObject);
                        UnityEngine.Object.Destroy(__instance.transform.Find("91 scroll tutorial A").gameObject);
                        UnityEngine.Object.Destroy(__instance.transform.Find("116 map A").gameObject);
                        UnityEngine.Object.Destroy(__instance.transform.Find("8 goat cheese (good)").gameObject);

                        /*var mug = __instance.transform.Find("101 mug clay");
                        mugPos = mug.localPosition;
                        UnityEngine.Object.Destroy(mug.gameObject);*/

                        //__instance.transform.Find("101 mug clay").gameObject.GetComponent<ShipItemBottle>().FillBottle(1f, 3f);
                        var mug = __instance.transform.Find("101 mug clay").gameObject.GetComponent<ShipItemBottle>();
                        mug.amount = 1;
                        mug.health = 3;

                    }
                    if (___region == PortRegion.emerald)
                    {
                        UnityEngine.Object.Destroy(__instance.transform.Find("10 barrel water").gameObject);
                        UnityEngine.Object.Destroy(__instance.transform.Find("81 compass E").gameObject);
                        UnityEngine.Object.Destroy(__instance.transform.Find("111 lantern E yellow").gameObject);
                        UnityEngine.Object.Destroy(__instance.transform.Find("91 scroll tutorial E").gameObject);
                        UnityEngine.Object.Destroy(__instance.transform.Find("117 map E").gameObject);
                        UnityEngine.Object.Destroy(__instance.transform.Find("1 crate salmon (E)").gameObject);
                        //UnityEngine.Object.Destroy(__instance.transform.Find("100 mug wood").gameObject);
                        /*var mug = __instance.transform.Find("100 mug wood");
                        mugPos = mug.localPosition;
                        UnityEngine.Object.Destroy(mug.gameObject);*/

                        //__instance.transform.Find("100 mug wood").gameObject.GetComponent<ShipItemBottle>().FillBottle(1f, 3f);
                        var mug = __instance.transform.Find("100 mug wood").gameObject.GetComponent<ShipItemBottle>();
                        mug.amount = 1;
                        mug.health = 3;

                    }
                }
                if (Plugin.difficulty.Value == "easy" || Plugin.difficulty.Value == "normal")
                {
                    /*                if (___region == PortRegion.emerald)
                                    {
                                        var crate = __instance.transform.Find("1 crate salmon (E)");
                                        emCratePos = crate.position;
                                        emCrateRot = crate.rotation;
                                        UnityEngine.Object.Destroy(crate);
                                    }*/
                    if (___region == PortRegion.medi)
                    {
                        UnityEngine.Object.Destroy(__instance.transform.Find("52 cheese").gameObject);
                    }

                }
            }

            public static void Postfix(StarterSet __instance, PortRegion ___region, Transform ___starterBoat)
            {
                if (Plugin.difficulty.Value == "hard")
                {
                    if (___region == PortRegion.medi)
                    {

                    }
                    if (___region == PortRegion.alankh)
                    {
                        GameObject obj = UnityEngine.Object.Instantiate(SaveLoadManager.instance.GetComponent<PrefabsDirectory>().directory[53], __instance.transform);
                        obj.transform.localPosition = new Vector3(3.33f, 1.75f - 15f, 1.43f);
                        //obj.transform.localEulerAngles = new Vector3(0f, 75f, 180f);
                        obj.GetComponent<ShipItem>().sold = true;
                        obj.GetComponent<SaveablePrefab>().RegisterToSave();
                        //obj.GetComponent<Good>().RegisterAsMissionless();
                        //obj.GetComponent<ShipItem>().InvokePrivateMethod("EnterBoat", ___starterBoat.GetComponent<BoatEmbarkCollider>());
                        //if (mug) mug.FillBottle(1f, 3f);
                    }
                    if (___region == PortRegion.emerald)
                    {
                        GameObject obj = UnityEngine.Object.Instantiate(SaveLoadManager.instance.GetComponent<PrefabsDirectory>().directory[33], __instance.transform);
                        obj.transform.localPosition = new Vector3(1.05f, 0.43f - 15f, 1.14f);
                        //obj.transform.localEulerAngles = new Vector3(0f, 75f, 180f);
                        obj.GetComponent<ShipItem>().amount = 1.1f;
                        obj.GetComponent<ShipItem>().sold = true;
                        obj.GetComponent<SaveablePrefab>().RegisterToSave();
                        //obj.GetComponent<Good>().RegisterAsMissionless();
                        //obj.GetComponent<ShipItem>().InvokePrivateMethod("EnterBoat", ___starterBoat.GetComponent<BoatEmbarkCollider>());

                    }
                    /*GameObject bottle = UnityEngine.Object.Instantiate(SaveLoadManager.instance.GetComponent<PrefabsDirectory>().directory[55], __instance.transform);
                    bottle.transform.localPosition = new Vector3(mugPos.x, mugPos.y - 15f, mugPos.z);
                    bottle.GetComponent<ShipItem>().sold = true;
                    bottle.GetComponent<SaveablePrefab>().RegisterToSave();*/

                }
                if (Plugin.difficulty.Value == "easy" || Plugin.difficulty.Value == "normal")
                {
                    if (___region == PortRegion.medi)
                    {

                        GameObject obj = UnityEngine.Object.Instantiate(SaveLoadManager.instance.GetComponent<PrefabsDirectory>().directory[7], __instance.transform);
                        obj.transform.localPosition = new Vector3(-5f, 2.1f - 14f, -2.25f);
                        obj.transform.localEulerAngles = new Vector3(0f, 75f, 180f);
                        obj.GetComponent<ShipItem>().sold = true;
                        obj.GetComponent<SaveablePrefab>().RegisterToSave();
                        obj.GetComponent<Good>().RegisterAsMissionless();
                        //obj.GetComponent<ShipItem>().InvokePrivateMethod("EnterBoat", ___starterBoat.GetComponent<BoatEmbarkCollider>());

                        if (obj) Debug.Log("testbed: spawned object");
                        else Debug.Log("Testbed: failed to spawn object");
                    }

                    if (___region == PortRegion.emerald)
                    {
                    }

                    if (___region == PortRegion.alankh)
                    {
                    }

                }
                if (Plugin.difficulty.Value == "easy")
                {
                    if (___region == PortRegion.alankh)
                    {
                        PlayerGold.currency[0] *= 2;
                    }
                    if (___region == PortRegion.emerald)
                    {
                        PlayerGold.currency[1] *= 2;
                    }
                    if (___region == PortRegion.medi)
                    {
                        PlayerGold.currency[2] *= 2;
                    }
                }
                //GameObject shipItemCrate = SaveLoadManager.instance.GetComponent<PrefabsDirectory>().directory[8];
                GameState.modData.Add("nandbrew.difficulty", Plugin.difficulty.Value);
            }
        }

        [HarmonyPatch(typeof(PortDude))]
        internal static class PortDudePatches
        {
            [HarmonyPatch("ActivateMissionListUI")]
            [HarmonyPrefix]
            public static bool ActivateMissionListUIPatch(bool openEconomyUI, Port ___port)
            {
                if (openEconomyUI)
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
                if (Plugin.difficulty.Value == "easy")
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
                if (Plugin.difficulty.Value == "easy" && GameState.sleeping && !GameState.inBed && !GameState.recovering && ___currentSleepDuration > 2f)
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
                if (Plugin.difficulty.Value == "easy")
                {
                    return false;
                }
                return true;
            }

            [HarmonyPatch("LateUpdate")]
            [HarmonyPrefix]
            public static bool LateUpdate(ref float ___alcohol, bool ___godMode, ref float ___sleepDebt, ref float ___sleep, ref float ___food, ref float ___water)
            {
                if (Plugin.difficulty.Value != "easy" || !GameState.playing || GameState.recovering || (bool)GameState.currentShipyard || (EconomyUI.instance.uiActive && !Debugger.buildDebugModeOn))
                {
                    return true;
                }
                if (!___godMode) 
                {
                    ___sleep += Time.deltaTime * Sun.sun.timescale * 1f;
                    ___food += Time.deltaTime * Sun.sun.timescale * 1.3f;
                    ___water += Time.deltaTime * Sun.sun.timescale * 1.6f;
                    return true;
                }

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

                    ___sleep += num;
                }
                else
                {
                    //___sleep -= Time.deltaTime * Sun.sun.timescale * 5f;
                    ___sleep -= Time.deltaTime * Sun.sun.timescale * 15f * (___alcohol / 100f);
                }
                return false;
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
                    if (Plugin.difficulty.Value == "hard" && Plugin.hardCam.Value)
                    {
                        return false;
                    }

                    return true;
                }
            }
        }



        /*    [HarmonyPatch(typeof(OVRPlayerController))]
            internal static class MovementPatches
            {
                [HarmonyPatch("UpdateMovement")]
                [HarmonyPrefix]
                public static void Prefix(OVRPlayerController __instance)
                {
                    if (PlayerNeeds.sleep < 50)
                    {
                        __instance.SetMoveScaleMultiplier(0.6f);
                    }
                }
            }  */

        [HarmonyPatch(typeof(SaveLoadManager))]
        internal static class LoadPatch
        {
            [HarmonyPatch("LoadModData")]
            [HarmonyPrefix]
            public static void Prefix()
            {
                GameState.modData.TryGetValue("nandbrew.difficulty", out var difficulty);
                Debug.Log("Testbed difficulty = " + Plugin.difficulty.Value);
                Plugin.difficulty.Value = difficulty;

                //Plugin.UpdateGodMode(Plugin.godMode.Value);
            }
        }
    }
}
