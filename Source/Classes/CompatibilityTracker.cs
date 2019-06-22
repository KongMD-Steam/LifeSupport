using System.Linq;
using Verse;

namespace LifeSupport
{
    [StaticConstructorOnStartup]
    public static class CompatibilityTracker
    {
        private static bool deathRattleActiveInt = false;
        private static string[] incompatibleModArr = { "Questionable Ethics" };

        public static bool DeathRattleActive
        {
            get
            {
                return deathRattleActiveInt;
            }
        }

        public static string[] IncompatibleMods
        {
            get
            {
                return incompatibleModArr;
            }
            set
            {
                incompatibleModArr = value;
            }
        }

        static CompatibilityTracker()
        {
            foreach (string s in incompatibleModArr)
            {
                if (ModsConfig.ActiveModsInLoadOrder.Any((ModMetaData m) => m.Name == s))
                {
                    switch(s)
                    {
                        case "Questionable Ethics":
                            Log.Error("Life Support is incompatible with " + s + ". Download and use Questionable Ethics Enhanced, instead!");
                            break;
                        default:  Log.Error("Life Support is incompatible with " + s);
                            break;
                    }
                }
            }

            //Check for Death Rattle Compatiblity.
            if (GenTypes.AllTypes.Any(type => type.FullName == "DeathRattle.DeathRattleBase"))
            {
                deathRattleActiveInt = true;
                Log.Message("LifeSupport: DeathRattle mod detected");
            }
        }
    }
}
