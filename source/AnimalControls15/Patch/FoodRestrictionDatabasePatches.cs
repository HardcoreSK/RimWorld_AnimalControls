using System.Linq;
using HarmonyLib;
using RimWorld;
using Verse;

namespace AnimalControls.Patch
{
    [HarmonyPatch(typeof(FoodRestrictionDatabase), "GenerateStartingFoodRestrictions")]
    public static class FoodRestrictionDatabase_GenerateStartingFoodRestrictions_AnimalControlsPatch
    {
        static void Postfix(FoodRestrictionDatabase __instance)
        {
            FoodPolicy foodPolicy = __instance.MakeNewFoodRestriction();
            foodPolicy.label = "FoodRestrictionAnimal".Translate();
            foodPolicy.filter.SetDisallowAll();
            foreach (ThingDef thingDef in DefDatabase<ThingDef>.AllDefs)
            {
                if (thingDef.ingestible != null && (thingDef.ingestible.preferability <= FoodPreferability.RawTasty && !thingDef.IsDrug))
                {
                    foodPolicy.filter.SetAllow(thingDef, true);
                }
            }
        }
    }
}
