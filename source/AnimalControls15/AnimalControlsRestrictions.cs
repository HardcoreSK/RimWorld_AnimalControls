using System.Collections.Generic;
using System.Linq;
using Verse;
using RimWorld;
namespace AnimalControls
{
    //global animal restrictions in a form of gamecomponent, to be used anywhere within one save game
    public class AnimalControlsRestrictions : GameComponent
    {
        public FoodPolicy DefaultRestriction = null;
        public FoodPolicy HandlerRestriction = null;

        public AnimalControlsRestrictions()
        {
        }

        public AnimalControlsRestrictions(Game game)
        {
            DefaultRestriction = game?.foodRestrictionDatabase.AllFoodRestrictions.Where(fr => fr.label == (string)"FoodRestrictionAnimal".Translate()).FirstOrDefault();
            HandlerRestriction = game?.foodRestrictionDatabase.AllFoodRestrictions.Where(fr => fr.label == (string)"FoodRestrictionAnimal".Translate()).FirstOrDefault();
        }

        public override void ExposeData()
        {
            Scribe_References.Look(ref DefaultRestriction, "DefaultRestriction");
            Scribe_References.Look(ref HandlerRestriction, "HandlerRestriction");
        }
    }
}
