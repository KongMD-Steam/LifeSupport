# Life Support
Life Support is a mod that adds the **Life Support System** building. It's a linkable to beds that will prevent a pawn from dying if they lose organs. I took this building from the mod 'Questionable Ethics' and made it a standalone mod to increase mod compatibility.

## Building the Life Support System
1. Research the Vitals Monitor
2. Research the Life Support System
3. Build it from the 'Misc' Architect tab

## How the Life Support Hediff works
In the current implementation, any number of organs can be removed, with the exception of the brain, without the pawn dying. However, if a pawn missing an internal organ loses connection to the Life Support System or is removed from the bed, they will die instantly. Only conditions that would kill the pawn in the vanilla game will cause them to die, upon removal from Life Support. The Life Support hediff will be applied to any pawn in a bed adjacent to the Life Support System.

How you utilize this machine is up to you; you can use it to ruthlessly harvest the organs of hapless victims, or use it as a temporary stopgap before getting a replacement organ. Perhaps you'll use it for both of those purposes!

## Changes from Questionable Ethics
* New art for the Life Support building
* Life Support Hediff won't be cured by Healer Mech Serum
* Life Support System building research now requires Vital Monitor as only pre-requisite

## Can I use this on an existing save?
Yes. 

If you built the Life Support System in a save with Questionable Ethics enabled, the building will function after adding this mod. Same deal with the Life Support hediff.

## Compatibility
This mod makes no changes to vanilla defs. It should be compatible with virtually everything. Specific compatibility notes below:

* All mods that add beds - No changes/patches required
* Death Rattle - If you use this mod, you'll need [Death Rattle - Comatose](https://steamcommunity.com/sharedfiles/filedetails/?id=1553099486) to make the Life Support machine function as designed. Death Rattle Comatose provides an 'Artifical Coma' surgery that will slow down the negative effects from Death Rattle, buying you time. If you put a pawn on Life Support and they are in an artifical coma, their Death Rattle condition (like 'no pulse') will decrease to a very low severity. They will be stable until the artificial coma expires in 10 game days, at which point they will die. Use Wake-Up to get them out of the artificial coma.
* Questionable Ethics - **Incompatible**. Both mods patch the same Harmony methods. Use Questionable Ethics Enhanced, instead.

### Harmony Patches
* Pawn_HealthTracker.ShouldBeDeadFromRequiredCapacity() Prefix
* Toils_LayDown.LayDown() Postfix

## Credits ## 
* KongMD - XML, C#, Art
* ChJees - Concept & implementation in the mod 'Questionable Ethics'. Used with permission.