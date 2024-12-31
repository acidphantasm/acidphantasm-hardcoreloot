using acidphantasm_hardcoreloot.Patches;
using BepInEx;

namespace acidphantasm_hardcoreloot
{
    [BepInPlugin("phantasm.acid.hardcoreloot", "acidphantasm-hardcoreloot", "1.1.2")]
    [BepInDependency("com.SPT.core", "3.10.0")]
    public class Plugin : BaseUnityPlugin
    {
        public static bool enable;
        public static bool fullUnlootable;
        public static bool slotPrimary;
        public static bool slotSecondPrimary;
        public static bool slotHolster;
        public static bool slotMelee;
        public static bool slotHelmet;
        public static bool slotFacecover;
        public static bool slotEarpiece;
        public static bool slotEyewear;
        public static bool slotArmband;
        public static bool slotRig;
        public static bool slotArmour;
        public static bool slotBackpack;
        public static bool pmc;
        public static bool scav;

        private void Awake()
        {
            Logger.LogInfo("[HardcoreLoot] loading...");

            HardcoreLootConfig.InitConfig(Config);

            new ItemTemplatePrefixPatch().Enable();
            new IsUnlootableFromPrefixPatch().Enable();
            new PlayerOnDeadPostfixPatch().Enable();

            Logger.LogInfo("[HardcoreLoot] loaded!");
        }
    }
}
