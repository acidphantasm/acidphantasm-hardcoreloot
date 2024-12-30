using EFT;
using Comfort.Common;

namespace acidphantasm_hardcoreloot.Utils
{
    public static class MainUtils
    {
        public static Player GetMainPlayer()
        {
            var gameWorld = Singleton<GameWorld>.Instance;
            return gameWorld?.MainPlayer;
        }
        public static bool IsGroupedWithMainPlayer(this Player player)
        {
            var mainPlayerGroupId = GetMainPlayer().GroupId;
            return !string.IsNullOrEmpty(mainPlayerGroupId) && player.GroupId == mainPlayerGroupId;
        }
    }
}
