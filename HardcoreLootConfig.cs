using BepInEx.Configuration;
using System;

namespace acidphantasm_hardcoreloot
{
    internal static class HardcoreLootConfig
    {
        private static int loadOrder = 100;
        private const string ConfigGeneral = "1. General";
        public static ConfigEntry<bool> enable;
        public static ConfigEntry<bool> fullUnlootable;
        private const string SlotConfig = "2. Unlootable Slots";
        public static ConfigEntry<bool> slotPrimary;
        public static ConfigEntry<bool> slotSecondPrimary;
        public static ConfigEntry<bool> slotHolster;
        public static ConfigEntry<bool> slotMelee;
        public static ConfigEntry<bool> slotFacecover;
        public static ConfigEntry<bool> slotEarpiece;
        public static ConfigEntry<bool> slotEyewear;
        public static ConfigEntry<bool> slotArmband;
        public static ConfigEntry<bool> slotHelmet;
        public static ConfigEntry<bool> slotArmour;
        public static ConfigEntry<bool> slotRig;
        public static ConfigEntry<bool> slotBackpack;
        private const string SideConfig = "3. Applicable Factions";
        public static ConfigEntry<bool> pmc;
        public static ConfigEntry<bool> scav;


        public static void InitConfig(ConfigFile config)
        {
            // General Settings
            enable = config.Bind(ConfigGeneral, "Enable Mod", true, new ConfigDescription("Enable or disable this mod.", null, new ConfigurationManagerAttributes { Order = loadOrder-- }));
            fullUnlootable = config.Bind(ConfigGeneral, "Enable Full Unlootable", false, new ConfigDescription("Enable or disable fully unlootable AI Corpses.", null, new ConfigurationManagerAttributes { Order = loadOrder-- }));

            // Slot Settings
            slotPrimary = config.Bind(SlotConfig, "Primary Weapon Slot", true, new ConfigDescription("Enable to mark slot unlootable", null, new ConfigurationManagerAttributes { Order = loadOrder-- }));
            slotSecondPrimary = config.Bind(SlotConfig, "Secondary Weapon Slot", true, new ConfigDescription("Enable to mark slot unlootable.", null, new ConfigurationManagerAttributes { Order = loadOrder-- }));
            slotHolster = config.Bind(SlotConfig, "Holster Slot", true, new ConfigDescription("Enable to mark slot unlootable.", null, new ConfigurationManagerAttributes { Order = loadOrder-- }));
            slotMelee = config.Bind(SlotConfig, "Melee Slot", true, new ConfigDescription("Enable to mark slot unlootable.", null, new ConfigurationManagerAttributes { Order = loadOrder-- }));
            slotFacecover = config.Bind(SlotConfig, "Facecover Slot", true, new ConfigDescription("Enable to mark slot unlootable.", null, new ConfigurationManagerAttributes { Order = loadOrder-- }));
            slotEarpiece = config.Bind(SlotConfig, "Earpiece Slot", true, new ConfigDescription("Enable to mark slot unlootable.", null, new ConfigurationManagerAttributes { Order = loadOrder-- }));
            slotEyewear = config.Bind(SlotConfig, "Eyewear Slot", true, new ConfigDescription("Enable to mark slot unlootable.", null, new ConfigurationManagerAttributes { Order = loadOrder-- }));
            slotArmband = config.Bind(SlotConfig, "Armband Slot", true, new ConfigDescription("Enable to mark slot unlootable.", null, new ConfigurationManagerAttributes { Order = loadOrder-- }));
            slotHelmet = config.Bind(SlotConfig, "Helmet Slot", true, new ConfigDescription("Enable to mark slot unlootable.", null, new ConfigurationManagerAttributes { Order = loadOrder-- }));
            slotArmour = config.Bind(SlotConfig, "Armour Slot", true, new ConfigDescription("Enable to mark slot unlootable.", null, new ConfigurationManagerAttributes { Order = loadOrder-- }));
            slotRig = config.Bind(SlotConfig, "Rig Slot", true, new ConfigDescription("Enable to mark slot unlootable.", null, new ConfigurationManagerAttributes { Order = loadOrder-- }));
            slotBackpack = config.Bind(SlotConfig, "Backpack Slot", true, new ConfigDescription("Enable to mark slot unlootable.", null, new ConfigurationManagerAttributes { Order = loadOrder-- }));

            // Sides
            pmc = config.Bind(SideConfig, "All PMC", true, new ConfigDescription("Unlootable config applies to all PMC Corpses.", null, new ConfigurationManagerAttributes { Order = loadOrder-- }));
            scav = config.Bind(SideConfig, "All Non-PMC", false, new ConfigDescription("Unlootable config applies to all Non-PMC Corpses.", null, new ConfigurationManagerAttributes { Order = loadOrder-- }));

            Plugin.enable = enable.Value;
            Plugin.fullUnlootable = fullUnlootable.Value;
            Plugin.slotPrimary = slotPrimary.Value;
            Plugin.slotSecondPrimary = slotSecondPrimary.Value;
            Plugin.slotHolster = slotHolster.Value;
            Plugin.slotMelee = slotMelee.Value;
            Plugin.slotFacecover = slotFacecover.Value;
            Plugin.slotEarpiece = slotEarpiece.Value;
            Plugin.slotEyewear = slotEyewear.Value;
            Plugin.slotArmband = slotArmband.Value;
            Plugin.slotHelmet = slotHelmet.Value;
            Plugin.slotArmour = slotArmour.Value;
            Plugin.slotRig = slotRig.Value;
            Plugin.slotBackpack = slotBackpack.Value;
            Plugin.pmc = pmc.Value;
            Plugin.scav = scav.Value;

            // Triggers
            enable.SettingChanged += Accessibility_SettingChanged;
            fullUnlootable.SettingChanged += Accessibility_SettingChanged;
            slotPrimary.SettingChanged += Accessibility_SettingChanged;
            slotSecondPrimary.SettingChanged += Accessibility_SettingChanged;
            slotMelee.SettingChanged += Accessibility_SettingChanged;
            slotHolster.SettingChanged += Accessibility_SettingChanged;
            slotFacecover.SettingChanged += Accessibility_SettingChanged;
            slotEarpiece.SettingChanged += Accessibility_SettingChanged;
            slotEyewear.SettingChanged += Accessibility_SettingChanged;
            slotArmband.SettingChanged += Accessibility_SettingChanged;
            slotHelmet.SettingChanged += Accessibility_SettingChanged;
            slotArmour.SettingChanged += Accessibility_SettingChanged;
            slotRig.SettingChanged += Accessibility_SettingChanged;
            slotBackpack.SettingChanged += Accessibility_SettingChanged;
            pmc.SettingChanged += Accessibility_SettingChanged;
            scav.SettingChanged += Accessibility_SettingChanged;
        }

        private static void Accessibility_SettingChanged(object sender, EventArgs e)
        {
            Plugin.enable = enable.Value;
            Plugin.fullUnlootable = fullUnlootable.Value;
            Plugin.slotPrimary = slotPrimary.Value;
            Plugin.slotSecondPrimary = slotSecondPrimary.Value;
            Plugin.slotHolster = slotHolster.Value;
            Plugin.slotMelee = slotMelee.Value;
            Plugin.slotFacecover = slotFacecover.Value;
            Plugin.slotEarpiece = slotEarpiece.Value;
            Plugin.slotEyewear = slotEyewear.Value;
            Plugin.slotArmband = slotArmband.Value;
            Plugin.slotHelmet = slotHelmet.Value;
            Plugin.slotArmour = slotArmour.Value;
            Plugin.slotRig = slotRig.Value;
            Plugin.slotBackpack = slotBackpack.Value;
            Plugin.pmc = pmc.Value;
            Plugin.scav = scav.Value;
        }
    }
}