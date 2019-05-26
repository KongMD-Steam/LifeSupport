using System.Linq;
using Verse;

namespace LifeSupport
{
    [StaticConstructorOnStartup]
    public static class CompatibilityTracker
    {
        private static bool deathRattleActiveInt = false;

        public static bool DeathRattleActive
        {
            get
            {
                return deathRattleActiveInt;
            }
        }

        static CompatibilityTracker()
        {
            //Check for Death Rattle Compatiblity.
            if (GenTypes.AllTypes.Any(type => type.FullName == "DeathRattle.DeathRattleBase"))
            {
                deathRattleActiveInt = true;
                Log.Message("LifeSupport: DeathRattle mod detected");
            }
        }
    }
}
