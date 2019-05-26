using System;
using Verse;
using RimWorld;
using Harmony;
using System.Reflection;
using Verse.AI;

namespace LifeSupport
{
    [StaticConstructorOnStartup]
    public static class HarmonyPatches
    {
        static HarmonyPatches()
        {
            //Harmony
            HarmonyInstance harmony = HarmonyInstance.Create("KongMD.LifeSupport");

            //Template
            /*{
                Type type = typeof(HarmonyPatches);
                MethodInfo originalMethod = type.GetMethod("MethodName");
                HarmonyMethod patchMethod = new HarmonyMethod(typeof(HarmonyPatches).GetMethod(nameof(Patch_Example_Example)));
                harmony.Patch(
                    originalMethod,
                    null,
                    null);
            }*/

            {
                if(!CompatibilityTracker.DeathRattleActive)
                {
                    Type type = typeof(Pawn_HealthTracker);
                    MethodInfo originalMethod = AccessTools.Method(type, "ShouldBeDeadFromRequiredCapacity");
                    HarmonyMethod patchMethod = new HarmonyMethod(typeof(HarmonyPatches).GetMethod(nameof(Patch_ShouldBeDeadFromRequiredCapacity)));
                    harmony.Patch(
                        originalMethod,
                        patchMethod,
                        null);
                }
                else
                {
                    Log.Message("Life Support: Death Rattle mod detected, not patching Pawn_HealthTracker.ShouldBeDeadFromRequiredCapacity()");
                }
            }

            {
                Type type = typeof(Toils_LayDown);
                MethodInfo originalMethod = AccessTools.Method(type, "LayDown");
                HarmonyMethod patchMethod = new HarmonyMethod(typeof(HarmonyPatches).GetMethod(nameof(Patch_LayDown)));
                harmony.Patch(
                    originalMethod,
                    null,
                    patchMethod);
            }

            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }

        public static bool Patch_ShouldBeDeadFromRequiredCapacity(PawnCapacityDef __result, Pawn ___pawn)
        {
            Pawn pawn = ___pawn;
            if(pawn.health.hediffSet.HasHediff(LifeSupportDefOf.QE_LifeSupport) && pawn.ValidLifeSupportNearby())
            {
                //Check if consciousness is there. If it is then its okay.
                PawnCapacityDef pawnCapacityDef = PawnCapacityDefOf.Consciousness;
                bool flag = (!pawn.RaceProps.IsFlesh) ? pawnCapacityDef.lethalMechanoids : pawnCapacityDef.lethalFlesh;
                if (flag && pawn.health.capacities.CapableOf(pawnCapacityDef))
                {
                    __result = pawnCapacityDef;
                    return false;
                }

                __result = null;
                return false;
            }

            return true;
        }

        public static void Patch_LayDown(ref Toil __result)
        {
            Toil toil = __result;
            if (toil == null)
                return;
            /*toil.AddPreInitAction(delegate()
            {
                Pawn actor = toil.actor;
                if(actor.ValidLifeSupportNearby())
                {
                    actor.health.AddHediff(LifeSupportDefOf.QE_LifeSupport);
                }
            });*/
            toil.AddPreTickAction(delegate()
            {
                Pawn actor = toil.actor;
                if(actor != null && !actor.Dead)
                {
                    if (actor.ValidLifeSupportNearby())
                    {
                        if (!actor.health.hediffSet.HasHediff(LifeSupportDefOf.QE_LifeSupport))
                        {
                            actor.health.AddHediff(LifeSupportDefOf.QE_LifeSupport);
                        }
                    }
                    else
                    {
                        if (actor.health.hediffSet.GetFirstHediffOfDef(LifeSupportDefOf.QE_LifeSupport, false) is Hediff hediff)
                        {
                            actor.health.RemoveHediff(hediff);
                        }
                    }
                }
            });
        }
    }
}
