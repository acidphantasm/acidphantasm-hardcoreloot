using EFT.InventoryLogic;
using EFT;
using HarmonyLib;
using SPT.Reflection.Patching;
using System.Reflection;
using System;

namespace acidphantasm_hardcoreloot.Patches
{
    internal class IsUnlootableFromPrefixPatch : ModulePatch
    {
        protected override MethodBase GetTargetMethod()
        {
            return AccessTools.Method(typeof(UnlootableComponent), nameof(UnlootableComponent.IsUnlootableFrom));
        }

        [PatchPrefix]
        static bool Prefix(IContainer container, ref bool __result)
        {
            if (Plugin.enable)
            {
                if (container as Slot == null)
                {
                    return true;
                }

                Slot slot = container as Slot;

                switch (slot.Name)
                {
                    case "FirstPrimaryWeapon":
                        if (Plugin.slotPrimary)
                        {
                            __result = true;
                            return false;
                        }
                        break;
                    case "SecondPrimaryWeapon":
                        if (Plugin.slotSecondPrimary)
                        {
                            __result = true;
                            return false;
                        }
                        break;
                    case "Holster":
                        if (Plugin.slotHolster)
                        {
                            __result = true;
                            return false;
                        }
                        break;
                    case "Scabbard":
                        if (Plugin.slotMelee)
                        {
                            __result = true;
                            return false;
                        }
                        break;
                    case "Headwear":
                        if (Plugin.slotHelmet)
                        {
                            __result = true;
                            return false;
                        }
                        break;
                    case "FaceCover":
                        if (Plugin.slotFacecover)
                        {
                            __result = true;
                            return false;
                        }
                        break;
                    case "Earpiece":
                        if (Plugin.slotEarpiece)
                        {
                            __result = true;
                            return false;
                        }
                        break;
                    case "Eyewear":
                        if (Plugin.slotEyewear)
                        {
                            __result = true;
                            return false;
                        }
                        break;
                    case "ArmBand":
                        if (Plugin.slotArmband)
                        {
                            __result = true;
                            return false;
                        }
                        break;
                    case "TacticalVest":
                        if (Plugin.slotRig)
                        {
                            __result = true;
                            return false;
                        }
                        break;
                    case "ArmorVest":
                        if (Plugin.slotArmour)
                        {
                            __result = true;
                            return false;
                        }
                        break;
                    case "Backpack":
                        if (Plugin.slotBackpack)
                        {
                            __result = true;
                            return false;
                        }
                        break;
                    default:
                        return true;
                }
            }
            return true;
        }
    }
    internal class ItemTemplatePrefixPatch : ModulePatch
    {
        protected override MethodBase GetTargetMethod()
        {
            return AccessTools.Constructor(typeof(Item), new Type[] { typeof(string), typeof(ItemTemplate)});
        }

        [PatchPrefix]
        static void Prefix(string id, ref ItemTemplate template)
        {
            if (Plugin.enable)
            {
                template.Unlootable = true;
                template.UnlootableFromSide = EPlayerSideMask.All;
                template.UnlootableFromSlot = "Scabbard";
            }
        }
    }
}
