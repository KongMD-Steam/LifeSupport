using RimWorld;
using System.Linq;
using Verse;

namespace LifeSupport
{
    public static class LifeSupportUtility
    {
        public static bool ValidLifeSupportNearby(this Pawn pawn)
        {
            return pawn.CurrentBed() is Building_Bed bed &&
                GenAdj.CellsAdjacent8Way(bed).Any(cell => cell.GetThingList(bed.Map).Any(cellThing => cellThing.TryGetComp<LifeSupportComp>() is LifeSupportComp lifeSupport && lifeSupport.Active));
        }
    }
}
