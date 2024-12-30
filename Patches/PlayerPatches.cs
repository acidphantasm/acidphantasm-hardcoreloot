using HarmonyLib;
using SPT.Reflection.Patching;
using System.Reflection;
using EFT;
using acidphantasm_hardcoreloot.Utils;
using EFT.InventoryLogic;
using System.Collections.Generic;
using static EFT.Player;
using GPUInstancer;
using System.Linq;
using EFT.Interactive;

namespace acidphantasm_hardcoreloot.Patches
{
    internal class PlayerPatches : ModulePatch
    {

        private static FieldInfo playerCorpse;

        protected override MethodBase GetTargetMethod()
        {
            playerCorpse = AccessTools.Field(typeof(Player), "Corpse");
            return AccessTools.Method(typeof(Player), nameof(Player.OnDead));
        }

        [PatchPostfix]
        static void Postfix(Player __instance)
        {
            if (!__instance.IsYourPlayer || !MainUtils.IsGroupedWithMainPlayer(__instance))
            {
                Corpse corpse = (Corpse)playerCorpse.GetValue(__instance);
                corpse.IsZombieCorpse = true;
            }
        }
    }
}
