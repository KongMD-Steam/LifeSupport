using RimWorld;
using Verse;

namespace LifeSupport
{
    /// <summary>
    /// Simply removes itself if the pawn no longer is in a bed.
    /// </summary>
    public class Hediff_LifeSupport : HediffWithComps
    {
        public override bool ShouldRemove => pawn.CurrentBed() == null;
    }
}
