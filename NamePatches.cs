using System;
using System.Collections.Generic;

using HarmonyLib;
using XRL.World;

namespace Qudmoji
{
    [HarmonyPatch]
    class HarmonyPatches
    {
        // map of mod names
        // key is the mod name as defined in base game code
        // value is a tuple containing the original adjective/clauses and the new replacement value
        public static readonly Dictionary<string, (string original, string adjective, bool skip)> AdjectiveMap = new Dictionary<string, (string original, string adjective, bool skip)>
        {
            // these mods have complex EventHandler functions, usually for some extra information like "Counterweighted (3)"
            // you should still be able to override them, but be aware of the lost information
            // if you'd like to add definitions for these, you'll need to copy and rename the standard functions at the bottom of this file
            // -- ModCounterweighted
            // -- ModDisguise
            // -- ModFlexiweaved
            // -- ModGigantic
            // -- ModJewelEncrusted
            // -- ModLiquidCooled
            // -- ModPsionic

            // normal mods
            // if there's no value it's because I couldn't think of a good symbol/color
            // or it's not used in game
            {"ModAirfoil", ("{{Y|airfoil}}", "{{G|\u001A}}", Qudmoji.Options.SkipModAirfoil)},
            {"ModAntiGravity", ("{{K|anti-gravity}}", "{{K|\u0018}}", Qudmoji.Options.SkipModAntiGravity)},
            {"ModBeamsplitter", ("{{R-R-r-r-g-g-G-G-B-B-b-b sequence|beamsplitter}}", "{{Y|\u00F6}}", Qudmoji.Options.SkipModBeamsplitter)},
            {"ModCleated", ("cleats", "{{G|\u001F}}", Qudmoji.Options.SkipModCleated)},
            {"ModCoProcessor", ("{{brainbrine|co-processor}}", "{{w|\u0025}}", Qudmoji.Options.SkipModCoProcessor)},
            {"ModDisplacer", ("{{displacer|displacer}}", "{{B|\u0015}}", Qudmoji.Options.SkipModDisplacer)},
            {"ModDrumLoaded", ("drum-loaded", "{{K|\u00F0}}", Qudmoji.Options.SkipModDrumLoaded)},
            {"ModElectrified", ("{{electrical|electrified}}", "{{W|\u002F}}", Qudmoji.Options.SkipModElectrified)},
            {"ModExtradimensional", ("{{extradimensional|extradimensional}}", "{{m|\u00EB}}", Qudmoji.Options.SkipModExtradimensional)},
            {"ModFeathered", ("{{feathered|feathered}}", "{{G|\u009F}}", Qudmoji.Options.SkipModFeathered)},
            {"ModFilters", ("{{Y|filters}}", "{{B|\u00B0}}", Qudmoji.Options.SkipModFilters)},
            {"ModFlaming", ("{{fiery|flaming}}", "{{R|\u002F}}", Qudmoji.Options.SkipModFlaming)},
            {"ModFreezing", ("{{freezing|freezing}}", "{{C|\u002F}}", Qudmoji.Options.SkipModFreezing)},
            {"ModHardened", ("{{mercurial|electromagnetic}} shielding", "{{W|\u0004}}", Qudmoji.Options.SkipModHardened)},
            {"ModHighCapacity", ("{{c|high-capacity}}", "{{W|\u002B}}", Qudmoji.Options.SkipModHighCapacity)},
            {"ModIlluminated", ("[{{illuminated|illuminated}}]", "{{Y|\u00EB}}", Qudmoji.Options.SkipModIlluminated)},
            {"ModJacked", ("{{c|jacked}}", "{{W|\u00EE}}", Qudmoji.Options.SkipModJacked)},
            {"ModLacquered", ("{{lacquered|lacquered}}", "{{B|\u007E}}", Qudmoji.Options.SkipModLacquered)},
            {"ModLanterned", ("{{lanterned|lanterned}}", "{{Y|\u000F}}", Qudmoji.Options.SkipModLanterned)},
            {"ModMagnetized", ("magnetized", "{{K|\u00EF}}", Qudmoji.Options.SkipModMagnetized)},
            {"ModMasterwork", ("{{Y|masterwork}}", "{{M|\u002B}}", Qudmoji.Options.SkipModMasterwork)},
            {"ModMetered", ("{{c|metered}}", "{{W|\u0023}}", Qudmoji.Options.SkipModMetered)},
            {"ModMorphogenetic", ("{{m|morphogenetic}}", "{{m|\u003D}}", Qudmoji.Options.SkipModMorphogenetic)},
            {"ModNanon", ("{{K|nanon}}", "{{B|\u00AB}}", Qudmoji.Options.SkipModNanon)},
            {"ModGesticulating", ("{{m|gesticulating}}", "{{m|\u0014}}", Qudmoji.Options.SkipModGesticulating)},
            {"ModNav", ("{{r|nav}}", "{{r|\u001D}}", Qudmoji.Options.SkipModNav)},
            {"ModNulling", ("{{K|nulling}}", "{{K|\u0015}}", Qudmoji.Options.SkipModNulling)},
            {"ModOverloaded", ("{{overloaded|overloaded}}", "{{o|\u00FB}}", Qudmoji.Options.SkipModOverloaded)},
            {"ModPadded", ("padded", "{{B|\u0005}}", Qudmoji.Options.SkipModPadded)},
            {"ModPhaseConjugate", ("{{K|phase-conjugate}}", "{{K|\u001D}}", Qudmoji.Options.SkipModPhaseConjugate)},
            {"ModPhaseHarmonic", ("{{phase-harmonic|phase-harmonic}}", "{{m|\u00F7}}", Qudmoji.Options.SkipModPhaseHarmonic)},
            {"ModPolarized", ("{{polarized|polarized}}", "{{K|\u00EC}}", Qudmoji.Options.SkipModPolarized)},
            {"ModRadioPowered", ("{{C|radio-powered}}", "{{W|\u00EC}}", Qudmoji.Options.SkipModRadioPowered)},
            {"ModRecycling", ("{{B|recycling}}", "{{B|\u0040}}", Qudmoji.Options.SkipModRecycling)},
            {"ModRefractive", ("{{refractive|refractive}}", "{{Y|\u003C}}", Qudmoji.Options.SkipModRefractive)},
            {"ModReinforced", ("reinforced", "{{b|\u0004}}", Qudmoji.Options.SkipModReinforced)},
            {"ModScaled", ("{{scaled|scaled}}", "{{g|\u0011}}", Qudmoji.Options.SkipModScaled)},
            {"ModScoped", ("scoped", "{{g|\u00E9}}", Qudmoji.Options.SkipModScoped)},
            {"ModSereneVisage", ("{{Y|serene}} visage", "{{Y|\u0002}}", Qudmoji.Options.SkipModSereneVisage)},
            {"ModSerrated", ("{{Y|serra{{R|t}}ed}}", "{{R|\u000F}}", Qudmoji.Options.SkipModSerrated)},
            {"ModSharp", ("sharp", "{{c|\u001A}}", Qudmoji.Options.SkipModSharp)},
            {"ModSixFingered", ("{{G|six-fingered}}", "{{G|\u0036}}", Qudmoji.Options.SkipModSixFingered)},
            {"ModSlender", ("slender", "{{y|\u0023}}", Qudmoji.Options.SkipModSlender)},
            {"ModSnailEncrusted", ("{{snail-encrusted|snail-encrusted}}", "{{w|\u0040}}", Qudmoji.Options.SkipModSnailEncrusted)},
            {"ModSpiked", ("{{spiked|spiked}}", "{{R|\u001E}}", Qudmoji.Options.SkipModSpiked)},
            {"ModSpringLoaded", ("spring-loaded", "{{G|\u00AF}}", Qudmoji.Options.SkipModSpringLoaded)},
            {"ModSturdy", ("sturdy", "{{r|\u0004}}", Qudmoji.Options.SkipModSturdy)},
            {"ModSuspensor", ("{{watery|suspensors}}", "{{B|\u0017}}", Qudmoji.Options.SkipModSuspensor)},
            {"ModTerrifyingVisage", ("{{K|terrifying}} visage", "{{K|\u0002}}", Qudmoji.Options.SkipModTerrifyingVisage)},
            {"ModTwoFaced", ("two-faced", "{{m|\u0001}}", Qudmoji.Options.SkipModTwoFaced)},
            {"ModVisored", ("visored", "{{G|\u0009}}", Qudmoji.Options.SkipModVisored)},
            {"ModWillowy", ("willowy", "{{B|\u0023}}", Qudmoji.Options.SkipModWillowy)},
            {"ModWooly", ("{{Y|wooly}}", "{{Y|\u00F1}}", Qudmoji.Options.SkipModWooly)},

            // intentionally left unmodified for visibility
            // {"ModEngraved", ("{{engraved|engraved}}", "{{|\u00}}", Qudmoji.Options.SkipModEngraved)},
            // {"ModPainted", ("{{painted|painted}}", "{{|\u00}}", Qudmoji.Options.SkipModPainted)},
            // {"ModQuantumReverb", ("{{quantumreverb|quantum reverb}}", "{{|\u00}}", Qudmoji.Options.SkipModQuantumReverb)},

            // furniture/wall/etc. mods
            // {"ModDesecrated", ("{{K|desecrated}}", "{{|\u00}}", Qudmoji.Options.SkipModDesecrated)},
            // {"ModGearbox", ("gearbox", "{{|\u00}}", Qudmoji.Options.SkipModGearbox)},
            // {"ModPiping", ("piping", "{{|\u00}}", Qudmoji.Options.SkipModPiping)},
            // {"ModWired", ("{{c|wired}}", "{{|\u00}}", Qudmoji.Options.SkipModWired)},

            // seemingly unused mods
            // {"ModBiomech", ("{{biomech|biomech}}", "{{|\u00}}", Qudmoji.Options.SkipModBiomech)},
            // {"ModCamo", ("{{camouflage|camo}}", "{{|\u00}}", Qudmoji.Options.SkipModCamo)},
            // {"ModCybrid", ("{{biomech|cybrid}}", "{{|\u00}}", Qudmoji.Options.SkipModCybrid)},
            // {"ModDefib", ("{{love|defib}}", "{{|\u00}}", Qudmoji.Options.SkipModDefib)},
            // {"ModFlareCompensating", ("{{K|flare-compensating}}", "{{|\u00}}", Qudmoji.Options.SkipModFlareCompensating)},
            // {"ModHeartstopper", ("{{lovesickness|heartstopper}}", "{{|\u00}}", Qudmoji.Options.SkipModHeartstopper)},
            // {"ModHeatSeeking", ("homing", "{{|\u00}}", Qudmoji.Options.SkipModHeatSeeking)},
            // {"ModHUD", ("HUD", "{{|\u00}}", Qudmoji.Options.SkipModHUD)},
            // {"ModHypervelocity", ("{{hypervelocity|hypervelocity}}", "{{|\u00}}", Qudmoji.Options.SkipModHypervelocity)},
            // {"ModInduction", ("{{Y|induction}}", "{{|\u00}}", Qudmoji.Options.SkipModInduction)},
            // {"ModKeen", ("keen", "{{|\u00}}", Qudmoji.Options.SkipModKeen)},
            // {"ModLegendary", ("{{Y|lege{{W|n}}dary}}", "{{|\u00}}", Qudmoji.Options.SkipModLegendary)},
            // {"ModMassivelyOverloaded", ("{{overloaded|massively overloaded}}", "{{|\u00}}", Qudmoji.Options.SkipModMassivelyOverloaded)},
            // {"ModMercurial", ("{{Y|mercurial}}", "{{|\u00}}", Qudmoji.Options.SkipModMercurial)},
            // {"ModMetallized", ("{{c|metallized}}", "{{|\u00}}", Qudmoji.Options.SkipModMetallized)},
            // {"ModMicroserrated", ("{{Y|mi{{R|c}}roserra{{R|t}}ed}}", "{{|\u00}}", Qudmoji.Options.SkipModMicroserrated)},
            // {"ModMighty", ("mighty", "{{|\u00}}", Qudmoji.Options.SkipModMighty)},
            // {"ModNanochelated", ("{{K|nanochelated}}", "{{|\u00}}", Qudmoji.Options.SkipModNanochelated)},
            // {"ModOrthopedic", ("orthopedic", "{{|\u00}}", Qudmoji.Options.SkipModOrthopedic)},
            // {"ModOverbuilt", ("overbuilt", "{{|\u00}}", Qudmoji.Options.SkipModOverbuilt)},
            // {"ModSmart", ("{{c|smart}}", "{{|\u00}}", Qudmoji.Options.SkipModSmart)},
            // {"ModUrbanCamo", ("{{urban camouflage|urban camo}}", "{{|\u00}}", Qudmoji.Options.SkipModUrbanCamo)},
            // {"ModWeightless", ("{{y-K sequence|weightless}}", "{{|\u00}}", Qudmoji.Options.SkipModWeightless)},
        };

        static void SharedAdjectiveOverride(GetDisplayNameEvent E, string key, bool Trivial = false, bool ShowOnNamed = false)
        {
            // don't apply to unidentified items unless trivial (engraved, painted, etc.)
            if (!Trivial && !E.Understood()) { return; }

            // don't apply to named items unless that's vanilla behavior (illuminated)
            bool ShowNamed = ShowOnNamed || Qudmoji.Options.ShowOnNamed;
            if (!ShowNamed && E.Object.HasProperName) { return; }

            (string original, string adjective, bool skip) value = (original: null, adjective: null, skip: false);
            if (AdjectiveMap.TryGetValue(key, out value))
            {
                // skip if user has set override in options
                if (value.skip) { return; }

                // remove original adjective from underlying DescriptionBuilder
                E.DB.Remove(value.original);
                E.Add(value.adjective);
            }
        }

        static void SharedWithClauseOverride(GetDisplayNameEvent E, string key)
        {
            if (E.Understood() && !E.Object.HasProperName)
            {
                (string original, string adjective, bool skip) value = (original: "", adjective: "", skip: false);
                if (!value.skip && AdjectiveMap.TryGetValue(key, out value))
                {

                    // E.DB.Remove(value.original);
                    int index = E.DB.WithClauses?.IndexOf(value.original) ?? -1;
                    if (index >= 0)
                    {
                        E.DB.WithClauses.RemoveAt(index);
                        E.Add(value.adjective);
                    }
                }
            }
        }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(XRL.World.Parts.ModAirfoil), "HandleEvent", new Type[] { typeof(GetDisplayNameEvent) })]
        static void ModAirfoilPatch(GetDisplayNameEvent E)
        {
            SharedAdjectiveOverride(E, "ModAirfoil");
        }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(XRL.World.Parts.ModAntiGravity), "HandleEvent", new Type[] { typeof(GetDisplayNameEvent) })]
        static void ModAntiGravityPatch(GetDisplayNameEvent E)
        {
            SharedAdjectiveOverride(E, "ModAntiGravity");
        }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(XRL.World.Parts.ModBeamsplitter), "HandleEvent", new Type[] { typeof(GetDisplayNameEvent) })]
        static void ModBeamsplitterPatch(GetDisplayNameEvent E)
        {
            SharedWithClauseOverride(E, "ModBeamsplitter");
        }

        // [HarmonyPostfix]
        // [HarmonyPatch(typeof(XRL.World.Parts.ModBiomech), "HandleEvent", new Type[] { typeof(GetDisplayNameEvent) })]
        // static void ModBiomechPatch(GetDisplayNameEvent E)
        // {
        //     SharedAdjectiveOverride(E, "ModBiomech");
        // }

        // [HarmonyPostfix]
        // [HarmonyPatch(typeof(XRL.World.Parts.ModCamo), "HandleEvent", new Type[] { typeof(GetDisplayNameEvent) })]
        // static void ModCamoPatch(GetDisplayNameEvent E)
        // {
        //     SharedAdjectiveOverride(E, "ModCamo");
        // }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(XRL.World.Parts.ModCleated), "HandleEvent", new Type[] { typeof(GetDisplayNameEvent) })]
        static void ModCleatedPatch(GetDisplayNameEvent E)
        {
            SharedWithClauseOverride(E, "ModCleated");
        }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(XRL.World.Parts.ModCoProcessor), "HandleEvent", new Type[] { typeof(GetDisplayNameEvent) })]
        static void ModCoProcessorPatch(GetDisplayNameEvent E)
        {
            SharedWithClauseOverride(E, "ModCoProcessor");
        }

        // [HarmonyPostfix]
        // [HarmonyPatch(typeof(XRL.World.Parts.ModCybrid), "HandleEvent", new Type[] { typeof(GetDisplayNameEvent) })]
        // static void ModCybridPatch(GetDisplayNameEvent E)
        // {
        //     SharedAdjectiveOverride(E, "ModCybrid");
        // }

        // [HarmonyPostfix]
        // [HarmonyPatch(typeof(XRL.World.Parts.ModDefib), "HandleEvent", new Type[] { typeof(GetDisplayNameEvent) })]
        // static void ModDefibPatch(GetDisplayNameEvent E)
        // {
        //     SharedAdjectiveOverride(E, "ModDefib");
        // }

        // [HarmonyPostfix]
        // [HarmonyPatch(typeof(XRL.World.Parts.ModDesecrated), "HandleEvent", new Type[] { typeof(GetDisplayNameEvent) })]
        // static void ModDesecratedPatch(GetDisplayNameEvent E)
        // {
        //     SharedAdjectiveOverride(E, "ModDesecrated", Trivial: true);
        // }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(XRL.World.Parts.ModDisplacer), "HandleEvent", new Type[] { typeof(GetDisplayNameEvent) })]
        static void ModDisplacerPatch(GetDisplayNameEvent E)
        {
            SharedAdjectiveOverride(E, "ModDisplacer");
        }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(XRL.World.Parts.ModDrumLoaded), "HandleEvent", new Type[] { typeof(GetDisplayNameEvent) })]
        static void ModDrumLoadedPatch(GetDisplayNameEvent E)
        {
            SharedAdjectiveOverride(E, "ModDrumLoaded");
        }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(XRL.World.Parts.ModElectrified), "HandleEvent", new Type[] { typeof(GetDisplayNameEvent) })]
        static void ModElectrifiedPatch(GetDisplayNameEvent E)
        {
            SharedAdjectiveOverride(E, "ModElectrified");
        }

        // [HarmonyPostfix]
        // [HarmonyPatch(typeof(XRL.World.Parts.ModEngraved), "HandleEvent", new Type[] { typeof(GetDisplayNameEvent) })]
        // static void ModEngravedPatch(GetDisplayNameEvent E)
        // {
        //     SharedAdjectiveOverride(E, "ModEngraved", Trivial: true);
        // }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(XRL.World.Parts.ModExtradimensional), "HandleEvent", new Type[] { typeof(GetDisplayNameEvent) })]
        static void ModExtradimensionalPatch(GetDisplayNameEvent E)
        {
            SharedAdjectiveOverride(E, "ModExtradimensional");
        }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(XRL.World.Parts.ModFeathered), "HandleEvent", new Type[] { typeof(GetDisplayNameEvent) })]
        static void ModFeatheredPatch(GetDisplayNameEvent E)
        {
            SharedAdjectiveOverride(E, "ModFeathered", Trivial: true);
        }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(XRL.World.Parts.ModFilters), "HandleEvent", new Type[] { typeof(GetDisplayNameEvent) })]
        static void ModFiltersPatch(GetDisplayNameEvent E)
        {
            SharedWithClauseOverride(E, "ModFilters");
        }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(XRL.World.Parts.ModFlaming), "HandleEvent", new Type[] { typeof(GetDisplayNameEvent) })]
        static void ModFlamingPatch(GetDisplayNameEvent E)
        {
            SharedAdjectiveOverride(E, "ModFlaming");
        }

        // [HarmonyPostfix]
        // [HarmonyPatch(typeof(XRL.World.Parts.ModFlareCompensating), "HandleEvent", new Type[] { typeof(GetDisplayNameEvent) })]
        // static void ModFlareCompensatingPatch(GetDisplayNameEvent E)
        // {
        //     SharedAdjectiveOverride(E, "ModFlareCompensating");
        // }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(XRL.World.Parts.ModFreezing), "HandleEvent", new Type[] { typeof(GetDisplayNameEvent) })]
        static void ModFreezingPatch(GetDisplayNameEvent E)
        {
            SharedAdjectiveOverride(E, "ModFreezing");
        }

        // [HarmonyPostfix]
        // [HarmonyPatch(typeof(XRL.World.Parts.ModGearbox), "HandleEvent", new Type[] { typeof(GetDisplayNameEvent) })]
        // static void ModGearboxPatch(GetDisplayNameEvent E)
        // {
        //     SharedWithClauseOverride(E, "ModGearbox");
        // }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(XRL.World.Parts.ModGesticulating), "HandleEvent", new Type[] { typeof(GetDisplayNameEvent) })]
        static void ModGesticulatingPatch(GetDisplayNameEvent E)
        {
            SharedAdjectiveOverride(E, "ModGesticulating");
        }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(XRL.World.Parts.ModHardened), "HandleEvent", new Type[] { typeof(GetDisplayNameEvent) })]
        static void ModHardenedPatch(GetDisplayNameEvent E)
        {
            SharedWithClauseOverride(E, "ModHardened");
        }

        // [HarmonyPostfix]
        // [HarmonyPatch(typeof(XRL.World.Parts.ModHeartstopper), "HandleEvent", new Type[] { typeof(GetDisplayNameEvent) })]
        // static void ModHeartstopperPatch(GetDisplayNameEvent E)
        // {
        //     SharedAdjectiveOverride(E, "ModHeartstopper");
        // }

        // [HarmonyPostfix]
        // [HarmonyPatch(typeof(XRL.World.Parts.ModHeatSeeking), "HandleEvent", new Type[] { typeof(GetDisplayNameEvent) })]
        // static void ModHeatSeekingPatch(GetDisplayNameEvent E)
        // {
        //     SharedAdjectiveOverride(E, "ModHeatSeeking");
        // }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(XRL.World.Parts.ModHighCapacity), "HandleEvent", new Type[] { typeof(GetDisplayNameEvent) })]
        static void ModHighCapacityPatch(GetDisplayNameEvent E)
        {
            SharedAdjectiveOverride(E, "ModHighCapacity");
        }

        // [HarmonyPostfix]
        // [HarmonyPatch(typeof(XRL.World.Parts.ModHUD), "HandleEvent", new Type[] { typeof(GetDisplayNameEvent) })]
        // static void ModHUDPatch(GetDisplayNameEvent E)
        // {
        //     SharedAdjectiveOverride(E, "ModHUD");
        // }

        // [HarmonyPostfix]
        // [HarmonyPatch(typeof(XRL.World.Parts.ModHypervelocity), "HandleEvent", new Type[] { typeof(GetDisplayNameEvent) })]
        // static void ModHypervelocityPatch(GetDisplayNameEvent E)
        // {
        //     SharedAdjectiveOverride(E, "ModHypervelocity");
        // }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(XRL.World.Parts.ModIlluminated), "HandleEvent", new Type[] { typeof(GetDisplayNameEvent) })]
        static void ModIlluminatedPatch(GetDisplayNameEvent E)
        {
            SharedAdjectiveOverride(E, "ModIlluminated", ShowOnNamed: true);
        }

        // [HarmonyPostfix]
        // [HarmonyPatch(typeof(XRL.World.Parts.ModInduction), "HandleEvent", new Type[] { typeof(GetDisplayNameEvent) })]
        // static void ModInductionPatch(GetDisplayNameEvent E)
        // {
        //     SharedAdjectiveOverride(E, "ModInduction");
        // }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(XRL.World.Parts.ModJacked), "HandleEvent", new Type[] { typeof(GetDisplayNameEvent) })]
        static void ModJackedPatch(GetDisplayNameEvent E)
        {
            SharedAdjectiveOverride(E, "ModJacked");
        }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(XRL.World.Parts.ModKeen), "HandleEvent", new Type[] { typeof(GetDisplayNameEvent) })]
        static void ModKeenPatch(GetDisplayNameEvent E)
        {
            SharedAdjectiveOverride(E, "ModKeen");
        }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(XRL.World.Parts.ModLacquered), "HandleEvent", new Type[] { typeof(GetDisplayNameEvent) })]
        static void ModLacqueredPatch(GetDisplayNameEvent E)
        {
            SharedAdjectiveOverride(E, "ModLacquered", Trivial: true);
        }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(XRL.World.Parts.ModLanterned), "HandleEvent", new Type[] { typeof(GetDisplayNameEvent) })]
        static void ModLanternedPatch(GetDisplayNameEvent E)
        {
            SharedAdjectiveOverride(E, "ModLanterned");
        }

        // [HarmonyPostfix]
        // [HarmonyPatch(typeof(XRL.World.Parts.ModLegendary), "HandleEvent", new Type[] { typeof(GetDisplayNameEvent) })]
        // static void ModLegendaryPatch(GetDisplayNameEvent E)
        // {
        //     SharedAdjectiveOverride(E, "ModLegendary");
        // }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(XRL.World.Parts.ModMagnetized), "HandleEvent", new Type[] { typeof(GetDisplayNameEvent) })]
        static void ModMagnetizedPatch(GetDisplayNameEvent E)
        {
            SharedAdjectiveOverride(E, "ModMagnetized");
        }

        // [HarmonyPostfix]
        // [HarmonyPatch(typeof(XRL.World.Parts.ModMassivelyOverloaded), "HandleEvent", new Type[] { typeof(GetDisplayNameEvent) })]
        // static void ModMassivelyOverloadedPatch(GetDisplayNameEvent E)
        // {
        //     SharedAdjectiveOverride(E, "ModMassivelyOverloaded");
        // }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(XRL.World.Parts.ModMasterwork), "HandleEvent", new Type[] { typeof(GetDisplayNameEvent) })]
        static void ModMasterworkPatch(GetDisplayNameEvent E)
        {
            SharedAdjectiveOverride(E, "ModMasterwork");
        }

        // [HarmonyPostfix]
        // [HarmonyPatch(typeof(XRL.World.Parts.ModMercurial), "HandleEvent", new Type[] { typeof(GetDisplayNameEvent) })]
        // static void ModMercurialPatch(GetDisplayNameEvent E)
        // {
        //     SharedAdjectiveOverride(E, "ModMercurial");
        // }

        // [HarmonyPostfix]
        // [HarmonyPatch(typeof(XRL.World.Parts.ModMetallized), "HandleEvent", new Type[] { typeof(GetDisplayNameEvent) })]
        // static void ModMetallizedPatch(GetDisplayNameEvent E)
        // {
        //     SharedAdjectiveOverride(E, "ModMetallized");
        // }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(XRL.World.Parts.ModMetered), "HandleEvent", new Type[] { typeof(GetDisplayNameEvent) })]
        static void ModMeteredPatch(GetDisplayNameEvent E)
        {
            SharedAdjectiveOverride(E, "ModMetered");
        }

        // [HarmonyPostfix]
        // [HarmonyPatch(typeof(XRL.World.Parts.ModMicroserrated), "HandleEvent", new Type[] { typeof(GetDisplayNameEvent) })]
        // static void ModMicroserratedPatch(GetDisplayNameEvent E)
        // {
        //     SharedAdjectiveOverride(E, "ModMicroserrated");
        // }

        // [HarmonyPostfix]
        // [HarmonyPatch(typeof(XRL.World.Parts.ModMighty), "HandleEvent", new Type[] { typeof(GetDisplayNameEvent) })]
        // static void ModMightyPatch(GetDisplayNameEvent E)
        // {
        //     SharedAdjectiveOverride(E, "ModMighty");
        // }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(XRL.World.Parts.ModMorphogenetic), "HandleEvent", new Type[] { typeof(GetDisplayNameEvent) })]
        static void ModMorphogeneticPatch(GetDisplayNameEvent E)
        {
            SharedAdjectiveOverride(E, "ModMorphogenetic");
        }

        // [HarmonyPostfix]
        // [HarmonyPatch(typeof(XRL.World.Parts.ModNanochelated), "HandleEvent", new Type[] { typeof(GetDisplayNameEvent) })]
        // static void ModNanochelatedPatch(GetDisplayNameEvent E)
        // {
        //     SharedAdjectiveOverride(E, "ModNanochelated");
        // }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(XRL.World.Parts.ModNanon), "HandleEvent", new Type[] { typeof(GetDisplayNameEvent) })]
        static void ModNanonPatch(GetDisplayNameEvent E)
        {
            SharedAdjectiveOverride(E, "ModNanon");
        }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(XRL.World.Parts.ModNav), "HandleEvent", new Type[] { typeof(GetDisplayNameEvent) })]
        static void ModNavPatch(GetDisplayNameEvent E)
        {
            SharedAdjectiveOverride(E, "ModNav");
        }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(XRL.World.Parts.ModNulling), "HandleEvent", new Type[] { typeof(GetDisplayNameEvent) })]
        static void ModNullingPatch(GetDisplayNameEvent E)
        {
            SharedAdjectiveOverride(E, "ModNulling");
        }

        // [HarmonyPostfix]
        // [HarmonyPatch(typeof(XRL.World.Parts.ModOrthopedic), "HandleEvent", new Type[] { typeof(GetDisplayNameEvent) })]
        // static void ModOrthopedicPatch(GetDisplayNameEvent E)
        // {
        //     SharedAdjectiveOverride(E, "ModOrthopedic");
        // }

        // [HarmonyPostfix]
        // [HarmonyPatch(typeof(XRL.World.Parts.ModOverbuilt), "HandleEvent", new Type[] { typeof(GetDisplayNameEvent) })]
        // static void ModOverbuiltPatch(GetDisplayNameEvent E)
        // {
        //     SharedAdjectiveOverride(E, "ModOverbuilt");
        // }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(XRL.World.Parts.ModOverloaded), "HandleEvent", new Type[] { typeof(GetDisplayNameEvent) })]
        static void ModOverloadedPatch(GetDisplayNameEvent E)
        {
            SharedAdjectiveOverride(E, "ModOverloaded");
        }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(XRL.World.Parts.ModPadded), "HandleEvent", new Type[] { typeof(GetDisplayNameEvent) })]
        static void ModPaddedPatch(GetDisplayNameEvent E)
        {
            SharedAdjectiveOverride(E, "ModPadded");
        }

        // [HarmonyPostfix]
        // [HarmonyPatch(typeof(XRL.World.Parts.ModPainted), "HandleEvent", new Type[] { typeof(GetDisplayNameEvent) })]
        // static void ModPaintedPatch(GetDisplayNameEvent E)
        // {
        //     SharedAdjectiveOverride(E, "ModPainted", Trivial: true);
        // }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(XRL.World.Parts.ModPhaseConjugate), "HandleEvent", new Type[] { typeof(GetDisplayNameEvent) })]
        static void ModPhaseConjugatePatch(GetDisplayNameEvent E)
        {
            SharedAdjectiveOverride(E, "ModPhaseConjugate");
        }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(XRL.World.Parts.ModPhaseHarmonic), "HandleEvent", new Type[] { typeof(GetDisplayNameEvent) })]
        static void ModPhaseHarmonicPatch(GetDisplayNameEvent E)
        {
            SharedAdjectiveOverride(E, "ModPhaseHarmonic");
        }

        // [HarmonyPostfix]
        // [HarmonyPatch(typeof(XRL.World.Parts.ModPiping), "HandleEvent", new Type[] { typeof(GetDisplayNameEvent) })]
        // static void ModPipingPatch(GetDisplayNameEvent E)
        // {
        //     SharedWithClauseOverride(E, "ModPiping");
        // }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(XRL.World.Parts.ModPolarized), "HandleEvent", new Type[] { typeof(GetDisplayNameEvent) })]
        static void ModPolarizedPatch(GetDisplayNameEvent E)
        {
            SharedAdjectiveOverride(E, "ModPolarized");
        }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(XRL.World.Parts.ModQuantumReverb), "HandleEvent", new Type[] { typeof(GetDisplayNameEvent) })]
        static void ModQuantumReverbPatch(GetDisplayNameEvent E)
        {
            SharedWithClauseOverride(E, "ModQuantumReverb");
        }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(XRL.World.Parts.ModRadioPowered), "HandleEvent", new Type[] { typeof(GetDisplayNameEvent) })]
        static void ModRadioPoweredPatch(GetDisplayNameEvent E)
        {
            SharedAdjectiveOverride(E, "ModRadioPowered");
        }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(XRL.World.Parts.ModRecycling), "HandleEvent", new Type[] { typeof(GetDisplayNameEvent) })]
        static void ModRecyclingPatch(GetDisplayNameEvent E)
        {
            SharedAdjectiveOverride(E, "ModRecycling");
        }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(XRL.World.Parts.ModRefractive), "HandleEvent", new Type[] { typeof(GetDisplayNameEvent) })]
        static void ModRefractivePatch(GetDisplayNameEvent E)
        {
            SharedAdjectiveOverride(E, "ModRefractive");
        }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(XRL.World.Parts.ModReinforced), "HandleEvent", new Type[] { typeof(GetDisplayNameEvent) })]
        static void ModReinforcedPatch(GetDisplayNameEvent E)
        {
            SharedAdjectiveOverride(E, "ModReinforced");
        }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(XRL.World.Parts.ModScaled), "HandleEvent", new Type[] { typeof(GetDisplayNameEvent) })]
        static void ModScaledPatch(GetDisplayNameEvent E)
        {
            SharedAdjectiveOverride(E, "ModScaled", Trivial: true);
        }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(XRL.World.Parts.ModScoped), "HandleEvent", new Type[] { typeof(GetDisplayNameEvent) })]
        static void ModScopedPatch(GetDisplayNameEvent E)
        {
            SharedAdjectiveOverride(E, "ModScoped");
        }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(XRL.World.Parts.ModSereneVisage), "HandleEvent", new Type[] { typeof(GetDisplayNameEvent) })]
        static void ModSereneVisagePatch(GetDisplayNameEvent E)
        {
            SharedWithClauseOverride(E, "ModSereneVisage");
        }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(XRL.World.Parts.ModSerrated), "HandleEvent", new Type[] { typeof(GetDisplayNameEvent) })]
        static void ModSerratedPatch(GetDisplayNameEvent E)
        {
            SharedAdjectiveOverride(E, "ModSerrated");
        }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(XRL.World.Parts.ModSharp), "HandleEvent", new Type[] { typeof(GetDisplayNameEvent) })]
        static void ModSharpPatch(GetDisplayNameEvent E)
        {
            SharedAdjectiveOverride(E, "ModSharp");
        }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(XRL.World.Parts.ModSixFingered), "HandleEvent", new Type[] { typeof(GetDisplayNameEvent) })]
        static void ModSixFingeredPatch(GetDisplayNameEvent E)
        {
            SharedAdjectiveOverride(E, "ModSixFingered");
        }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(XRL.World.Parts.ModSlender), "HandleEvent", new Type[] { typeof(GetDisplayNameEvent) })]
        static void ModSlenderPatch(GetDisplayNameEvent E)
        {
            SharedAdjectiveOverride(E, "ModSlender");
        }

        // [HarmonyPostfix]
        // [HarmonyPatch(typeof(XRL.World.Parts.ModSmart), "HandleEvent", new Type[] { typeof(GetDisplayNameEvent) })]
        // static void ModSmartPatch(GetDisplayNameEvent E)
        // {
        //     SharedAdjectiveOverride(E, "ModSmart");
        // }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(XRL.World.Parts.ModSnailEncrusted), "HandleEvent", new Type[] { typeof(GetDisplayNameEvent) })]
        static void ModSnailEncrustedPatch(GetDisplayNameEvent E)
        {
            SharedAdjectiveOverride(E, "ModSnailEncrusted", Trivial: true);
        }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(XRL.World.Parts.ModSpiked), "HandleEvent", new Type[] { typeof(GetDisplayNameEvent) })]
        static void ModSpikedPatch(GetDisplayNameEvent E)
        {
            SharedAdjectiveOverride(E, "ModSpiked");
        }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(XRL.World.Parts.ModSpringLoaded), "HandleEvent", new Type[] { typeof(GetDisplayNameEvent) })]
        static void ModSpringLoadedPatch(GetDisplayNameEvent E)
        {
            SharedAdjectiveOverride(E, "ModSpringLoaded");
        }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(XRL.World.Parts.ModSturdy), "HandleEvent", new Type[] { typeof(GetDisplayNameEvent) })]
        static void ModSturdyPatch(GetDisplayNameEvent E)
        {
            SharedAdjectiveOverride(E, "ModSturdy");
        }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(XRL.World.Parts.ModSuspensor), "HandleEvent", new Type[] { typeof(GetDisplayNameEvent) })]
        static void ModSuspensorPatch(GetDisplayNameEvent E)
        {
            SharedWithClauseOverride(E, "ModSuspensor");
        }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(XRL.World.Parts.ModTerrifyingVisage), "HandleEvent", new Type[] { typeof(GetDisplayNameEvent) })]
        static void ModTerrifyingVisagePatch(GetDisplayNameEvent E)
        {
            SharedAdjectiveOverride(E, "ModTerrifyingVisage");
        }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(XRL.World.Parts.ModTwoFaced), "HandleEvent", new Type[] { typeof(GetDisplayNameEvent) })]
        static void ModTwoFacedPatch(GetDisplayNameEvent E)
        {
            SharedAdjectiveOverride(E, "ModTwoFaced");
        }

        // [HarmonyPostfix]
        // [HarmonyPatch(typeof(XRL.World.Parts.ModUrbanCamo), "HandleEvent", new Type[] { typeof(GetDisplayNameEvent) })]
        // static void ModUrbanCamoPatch(GetDisplayNameEvent E)
        // {
        //     SharedAdjectiveOverride(E, "ModUrbanCamo");
        // }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(XRL.World.Parts.ModVisored), "HandleEvent", new Type[] { typeof(GetDisplayNameEvent) })]
        static void ModVisoredPatch(GetDisplayNameEvent E)
        {
            SharedAdjectiveOverride(E, "ModVisored");
        }

        // [HarmonyPostfix]
        // [HarmonyPatch(typeof(XRL.World.Parts.ModWeightless), "HandleEvent", new Type[] { typeof(GetDisplayNameEvent) })]
        // static void ModWeightlessPatch(GetDisplayNameEvent E)
        // {
        //     SharedAdjectiveOverride(E, "ModWeightless");
        // }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(XRL.World.Parts.ModWillowy), "HandleEvent", new Type[] { typeof(GetDisplayNameEvent) })]
        static void ModWillowyPatch(GetDisplayNameEvent E)
        {
            SharedAdjectiveOverride(E, "ModWillowy");
        }

        // [HarmonyPostfix]
        // [HarmonyPatch(typeof(XRL.World.Parts.ModWired), "HandleEvent", new Type[] { typeof(GetDisplayNameEvent) })]
        // static void ModWiredPatch(GetDisplayNameEvent E)
        // {
        //     SharedAdjectiveOverride(E, "ModWired");
        // }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(XRL.World.Parts.ModWooly), "HandleEvent", new Type[] { typeof(GetDisplayNameEvent) })]
        static void ModWoolyPatch(GetDisplayNameEvent E)
        {
            SharedAdjectiveOverride(E, "ModWooly");
        }
    }
}
