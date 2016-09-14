using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;

namespace MeleeHunting
{
    //this class provides a new alert for unarmed hunters, since the Core one has been indirectly disabled
    public class Alert_HunterIsUnarmed : Alert_High
    {
        public override AlertReport Report
        {
            get
            {
                foreach (Pawn current in Find.MapPawns.FreeColonistsSpawned)
                {
                    if (current.workSettings.WorkIsActive(WorkTypeDefOf.Hunting) && !Alert_HunterIsUnarmed.HasAnyWeapon(current) && !current.Downed)
                    {
                        return current;
                    }
                }
                return false;
            }
        }

        public static bool HasAnyWeapon(Pawn p)
        {
            if (p.equipment.Primary != null)
            {
                return true;
            }

            //check for scyther blades, which don't count as equipment
            List<Hediff> pawnHediffs = p.health.hediffSet.hediffs;
            foreach (Hediff healthDiff in pawnHediffs)
            {
                if (healthDiff.def.defName.Equals("ScytherBlade"))
                {
                    return true;
                }
            }

            //if neither of the above, consider unarmed
            return false;
        }

        public Alert_HunterIsUnarmed()
        {
            this.baseLabel = "Hunter lacks weapon";
            this.baseExplanation = "A colonist is assigned as a hunter but does not have any weapon.\n\nWhile they will still perform hunting tasks, it is highly recommended to give them a weapon to minimize injuries.";
        }
    }
}
