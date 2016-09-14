using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using UnityEngine;
using Verse;

namespace MeleeHunting
{
    [StaticConstructorOnStartup]
    public class ModInitializer : ITab
    {
        private static GameObject obj;

        public ModInitializer()
        {
            if (!(ModInitializer.obj != null))
            {
                Log.Message("Initializing " + this.GetType().Namespace + ".");
                ModInitializer.obj = new GameObject(this.GetType().Namespace + "Loader");
                UnityEngine.Object.DontDestroyOnLoad(ModInitializer.obj);

                //Detours
                MethodInfo coreHasHuntingWeaponMethod = typeof(WorkGiver_HunterHunt).GetMethod("HasHuntingWeapon", BindingFlags.Static | BindingFlags.Public);
                MethodInfo modHasHuntingWeaponTabMethod = typeof(WorkGiver_HunterHuntDetour).GetMethod("HasHuntingWeaponDetour", BindingFlags.Static | BindingFlags.Public);
                bool detourResult = Detours.TryDetourFromTo(coreHasHuntingWeaponMethod, modHasHuntingWeaponTabMethod);

                if (!detourResult)
                {
                    Log.Error(this.GetType().Namespace + " - Error when trying to detour methods.");
                }
            }
        }

        protected override void FillTab()
        {
        }
    }

}
