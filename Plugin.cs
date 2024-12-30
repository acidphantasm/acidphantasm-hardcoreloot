using acidphantasm_hardcoreloot.Patches;
using BepInEx;

namespace acidphantasm_hardcoreloot
{
    [BepInPlugin("phantasm.acid.hardcoreloot", "acidphantasm-hardcoreloot", "1.0.0")]
    [BepInDependency("com.SPT.core", "3.10.0")]
    public class Plugin : BaseUnityPlugin
    {
        private void Awake()
        {
            Logger.LogInfo("[HardcoreLoot] loading...");

            new PlayerPatches().Enable();

            Logger.LogInfo("[HardcoreLoot] loaded!");
        }
    }
}
