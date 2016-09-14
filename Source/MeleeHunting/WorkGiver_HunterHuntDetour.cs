using RimWorld;
using System;
using System.Collections.Generic;
using Verse;

namespace MeleeHunting
{
	/// <summary>
	/// Description of MyClass.
	/// </summary>
	public class WorkGiver_HunterHuntDetour : WorkGiver_HunterHunt
    {
		
        //public override bool ShouldSkip(Pawn pawn)
        //{
        //    return !WorkGiver_HunterHuntMeleeAllowed.HasHuntingWeapon(pawn) || WorkGiver_HunterHunt.HasShieldAndRangedWeapon(pawn);
        //}

        public static bool HasHuntingWeaponDetour(Pawn p)
        {
            //return p.equipment.Primary != null; && p.equipment.Primary.def.IsRangedWeapon;
            return true; //always true so even unarmed colonists can hunt, useful if they have scyther blades.
        }

    }
}