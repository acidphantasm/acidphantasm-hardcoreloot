using HarmonyLib;
using SPT.Reflection.Patching;
using System.Reflection;
using EFT;
using acidphantasm_hardcoreloot.Utils;
using EFT.Interactive;

namespace acidphantasm_hardcoreloot.Patches
{
    internal class PlayerOnDeadPostfixPatch : ModulePatch
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
            if (!Plugin.enable) return;

            if ((!__instance.IsYourPlayer || !MainUtils.IsGroupedWithMainPlayer(__instance)))
            {
                if (Plugin.fullUnlootable)
                {
                    Corpse thisCorpse = (Corpse)playerCorpse.GetValue(__instance);
                    thisCorpse.IsZombieCorpse = true;
                    return;
                }
            }
        }
    }
}
