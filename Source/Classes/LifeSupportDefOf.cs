using RimWorld;
using Verse;

namespace LifeSupport
{
    [DefOf]
    public static class LifeSupportDefOf
    {
        public static HediffDef QE_LifeSupport;

        static LifeSupportDefOf()
        {
            DefOfHelper.EnsureInitializedInCtor(typeof(LifeSupportDefOf));
        }
    }
}
