namespace Qudmoji
{

    class Options
    {
        private static string GetOption(string ID, string Default = "")
        {
            return XRL.UI.Options.GetOption(ID, Default: Default);
        }

        public static bool ShowOnNamed => GetOption("Option_Qudmoji_ShowOnNamed").EqualsNoCase("Yes");

        public static bool SkipModAirfoil => GetOption("Option_Qudmoji_ModAirfoil").EqualsNoCase("Yes");
        public static bool SkipModAntiGravity => GetOption("Option_Qudmoji_ModAntiGravity").EqualsNoCase("Yes");
        public static bool SkipModBeamsplitter => GetOption("Option_Qudmoji_ModBeamsplitter").EqualsNoCase("Yes");
        public static bool SkipModCleated => GetOption("Option_Qudmoji_ModCleated").EqualsNoCase("Yes");
        public static bool SkipModCoProcessor => GetOption("Option_Qudmoji_ModCoProcessor").EqualsNoCase("Yes");
        public static bool SkipModDisplacer => GetOption("Option_Qudmoji_ModDisplacer").EqualsNoCase("Yes");
        public static bool SkipModDrumLoaded => GetOption("Option_Qudmoji_ModDrumLoaded").EqualsNoCase("Yes");
        public static bool SkipModElectrified => GetOption("Option_Qudmoji_ModElectrified").EqualsNoCase("Yes");
        public static bool SkipModExtradimensional => GetOption("Option_Qudmoji_ModExtradimensional").EqualsNoCase("Yes");
        public static bool SkipModFeathered => GetOption("Option_Qudmoji_ModFeathered").EqualsNoCase("Yes");
        public static bool SkipModFilters => GetOption("Option_Qudmoji_ModFilters").EqualsNoCase("Yes");
        public static bool SkipModFlaming => GetOption("Option_Qudmoji_ModFlaming").EqualsNoCase("Yes");
        public static bool SkipModFreezing => GetOption("Option_Qudmoji_ModFreezing").EqualsNoCase("Yes");
        public static bool SkipModHardened => GetOption("Option_Qudmoji_ModHardened").EqualsNoCase("Yes");
        public static bool SkipModHighCapacity => GetOption("Option_Qudmoji_ModHighCapacity").EqualsNoCase("Yes");
        public static bool SkipModIlluminated => GetOption("Option_Qudmoji_ModIlluminated").EqualsNoCase("Yes");
        public static bool SkipModJacked => GetOption("Option_Qudmoji_ModJacked").EqualsNoCase("Yes");
        public static bool SkipModLacquered => GetOption("Option_Qudmoji_ModLacquered").EqualsNoCase("Yes");
        public static bool SkipModLanterned => GetOption("Option_Qudmoji_ModLanterned").EqualsNoCase("Yes");
        public static bool SkipModMagnetized => GetOption("Option_Qudmoji_ModMagnetized").EqualsNoCase("Yes");
        public static bool SkipModMasterwork => GetOption("Option_Qudmoji_ModMasterwork").EqualsNoCase("Yes");
        public static bool SkipModMetered => GetOption("Option_Qudmoji_ModMetered").EqualsNoCase("Yes");
        public static bool SkipModMorphogenetic => GetOption("Option_Qudmoji_ModMorphogenetic").EqualsNoCase("Yes");
        public static bool SkipModNanon => GetOption("Option_Qudmoji_ModNanon").EqualsNoCase("Yes");
        public static bool SkipModNav => GetOption("Option_Qudmoji_ModNav").EqualsNoCase("Yes");
        public static bool SkipModNulling => GetOption("Option_Qudmoji_ModNulling").EqualsNoCase("Yes");
        public static bool SkipModOverloaded => GetOption("Option_Qudmoji_ModOverloaded").EqualsNoCase("Yes");
        public static bool SkipModPadded => GetOption("Option_Qudmoji_ModPadded").EqualsNoCase("Yes");
        public static bool SkipModPhaseConjugate => GetOption("Option_Qudmoji_ModPhaseConjugate").EqualsNoCase("Yes");
        public static bool SkipModPhaseHarmonic => GetOption("Option_Qudmoji_ModPhaseHarmonic").EqualsNoCase("Yes");
        public static bool SkipModPolarized => GetOption("Option_Qudmoji_ModPolarized").EqualsNoCase("Yes");
        public static bool SkipModRadioPowered => GetOption("Option_Qudmoji_ModRadioPowered").EqualsNoCase("Yes");
        public static bool SkipModRecycling => GetOption("Option_Qudmoji_ModRecycling").EqualsNoCase("Yes");
        public static bool SkipModRefractive => GetOption("Option_Qudmoji_ModRefractive").EqualsNoCase("Yes");
        public static bool SkipModReinforced => GetOption("Option_Qudmoji_ModReinforced").EqualsNoCase("Yes");
        public static bool SkipModScaled => GetOption("Option_Qudmoji_ModScaled").EqualsNoCase("Yes");
        public static bool SkipModScoped => GetOption("Option_Qudmoji_ModScoped").EqualsNoCase("Yes");
        public static bool SkipModSereneVisage => GetOption("Option_Qudmoji_ModSereneVisage").EqualsNoCase("Yes");
        public static bool SkipModSerrated => GetOption("Option_Qudmoji_ModSerrated").EqualsNoCase("Yes");
        public static bool SkipModSharp => GetOption("Option_Qudmoji_ModSharp").EqualsNoCase("Yes");
        public static bool SkipModSixFingered => GetOption("Option_Qudmoji_ModSixFingered").EqualsNoCase("Yes");
        public static bool SkipModSlender => GetOption("Option_Qudmoji_ModSlender").EqualsNoCase("Yes");
        public static bool SkipModSnailEncrusted => GetOption("Option_Qudmoji_ModSnailEncrusted").EqualsNoCase("Yes");
        public static bool SkipModSpiked => GetOption("Option_Qudmoji_ModSpiked").EqualsNoCase("Yes");
        public static bool SkipModSpringLoaded => GetOption("Option_Qudmoji_ModSpringLoaded").EqualsNoCase("Yes");
        public static bool SkipModSturdy => GetOption("Option_Qudmoji_ModSturdy").EqualsNoCase("Yes");
        public static bool SkipModSuspensor => GetOption("Option_Qudmoji_ModSuspensor").EqualsNoCase("Yes");
        public static bool SkipModTerrifyingVisage => GetOption("Option_Qudmoji_ModTerrifyingVisage").EqualsNoCase("Yes");
        public static bool SkipModTwoFaced => GetOption("Option_Qudmoji_ModTwoFaced").EqualsNoCase("Yes");
        public static bool SkipModVisored => GetOption("Option_Qudmoji_ModVisored").EqualsNoCase("Yes");
        public static bool SkipModWillowy => GetOption("Option_Qudmoji_ModWillowy").EqualsNoCase("Yes");
        public static bool SkipModWooly => GetOption("Option_Qudmoji_ModWooly").EqualsNoCase("Yes");
        public static bool SkipModEngraved => GetOption("Option_Qudmoji_ModEngraved").EqualsNoCase("Yes");
        public static bool SkipModPainted => GetOption("Option_Qudmoji_ModPainted").EqualsNoCase("Yes");
        public static bool SkipModQuantumReverb => GetOption("Option_Qudmoji_ModQuantumReverb").EqualsNoCase("Yes");
        public static bool SkipModDesecrated => GetOption("Option_Qudmoji_ModDesecrated").EqualsNoCase("Yes");
        public static bool SkipModGearbox => GetOption("Option_Qudmoji_ModGearbox").EqualsNoCase("Yes");
        public static bool SkipModPiping => GetOption("Option_Qudmoji_ModPiping").EqualsNoCase("Yes");
        public static bool SkipModWired => GetOption("Option_Qudmoji_ModWired").EqualsNoCase("Yes");
        public static bool SkipModBiomech => GetOption("Option_Qudmoji_ModBiomech").EqualsNoCase("Yes");
        public static bool SkipModCamo => GetOption("Option_Qudmoji_ModCamo").EqualsNoCase("Yes");
        public static bool SkipModCybrid => GetOption("Option_Qudmoji_ModCybrid").EqualsNoCase("Yes");
        public static bool SkipModDefib => GetOption("Option_Qudmoji_ModDefib").EqualsNoCase("Yes");
        public static bool SkipModFlareCompensating => GetOption("Option_Qudmoji_ModFlareCompensating").EqualsNoCase("Yes");
        public static bool SkipModGesticulating => GetOption("Option_Qudmoji_ModGesticulating").EqualsNoCase("Yes");
        public static bool SkipModHeartstopper => GetOption("Option_Qudmoji_ModHeartstopper").EqualsNoCase("Yes");
        public static bool SkipModHeatSeeking => GetOption("Option_Qudmoji_ModHeatSeeking").EqualsNoCase("Yes");
        public static bool SkipModHUD => GetOption("Option_Qudmoji_ModHUD").EqualsNoCase("Yes");
        public static bool SkipModHypervelocity => GetOption("Option_Qudmoji_ModHypervelocity").EqualsNoCase("Yes");
        public static bool SkipModInduction => GetOption("Option_Qudmoji_ModInduction").EqualsNoCase("Yes");
        public static bool SkipModKeen => GetOption("Option_Qudmoji_ModKeen").EqualsNoCase("Yes");
        public static bool SkipModLegendary => GetOption("Option_Qudmoji_ModLegendary").EqualsNoCase("Yes");
        public static bool SkipModMassivelyOverloaded => GetOption("Option_Qudmoji_ModMassivelyOverloaded").EqualsNoCase("Yes");
        public static bool SkipModMercurial => GetOption("Option_Qudmoji_ModMercurial").EqualsNoCase("Yes");
        public static bool SkipModMetallized => GetOption("Option_Qudmoji_ModMetallized").EqualsNoCase("Yes");
        public static bool SkipModMicroserrated => GetOption("Option_Qudmoji_ModMicroserrated").EqualsNoCase("Yes");
        public static bool SkipModMighty => GetOption("Option_Qudmoji_ModMighty").EqualsNoCase("Yes");
        public static bool SkipModNanochelated => GetOption("Option_Qudmoji_ModNanochelated").EqualsNoCase("Yes");
        public static bool SkipModOrthopedic => GetOption("Option_Qudmoji_ModOrthopedic").EqualsNoCase("Yes");
        public static bool SkipModOverbuilt => GetOption("Option_Qudmoji_ModOverbuilt").EqualsNoCase("Yes");
        public static bool SkipModSmart => GetOption("Option_Qudmoji_ModSmart").EqualsNoCase("Yes");
        public static bool SkipModUrbanCamo => GetOption("Option_Qudmoji_ModUrbanCamo").EqualsNoCase("Yes");
        public static bool SkipModWeightless => GetOption("Option_Qudmoji_ModWeightless").EqualsNoCase("Yes");
    }
}
