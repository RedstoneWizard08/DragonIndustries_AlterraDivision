﻿using System.Collections.Generic;
using System.Linq;

namespace ReikaKalseki.DIAlterra.Api.Registry.VanillaData;

public static class PrefabData
{
    //TODO make prefab list an enum?

    private static readonly Dictionary<string, string> data = new();
    private static readonly Dictionary<string, string> inverse;
    private static readonly Dictionary<string, string> shortName = new();

    static PrefabData()
    {
        data["0001c04a-5bb4-4fb9-adb4-fcc7e3de308c"] = "WorldEntities/Slots/Ship/Loot_ShipInterior_AuxPowerRoom1";
        data["00037e80-3037-48cf-b769-dc97c761e5f6"] = "WorldEntities/Environment/Wrecks/life_pod_exploded_13";
        data["0010bf17-15be-4350-955b-b4ac023815f3"] = "WorldEntities/Doodads/Lost_river/lost_river_monster_skeleton";
        data["002d63ce-76c4-4c96-b26e-71e26b5d4933"] =
            "WorldEntities/Slots/Prison/Aquarium/PrisonAquarium_Creature_Wall";
        data["004c8e2c-284d-4221-9d1b-251af8dc56c9"] = "WorldEntities/Atmosphere/UnderwaterIslands/NormalDark";
        data["0063d51a-de77-438b-a592-61f68d12f4ad"] = "WorldEntities/Doodads/Geometry/SafeShallows/Coral_Clump02b";
        data["007a7c04-0b37-4a43-b561-fc8e8bf2e5af"] = "WorldEntities/Slots/CrashZone/CrashZone_Loot_EscapePod_Small";
        data["0089035b-4717-4975-b437-5b87cc3e2f8e"] =
            "WorldEntities/Doodads/Coral_reef_Light/coral_reef_plant_middle_01_Light";
        data["00891fdf-7264-4c55-b569-732cdcded701"] = "WorldEntities/Environment/Wrecks/life_pod_exploded_12";
        data["00980c3a-4e20-4864-a4ef-d18164e0a647"] =
            "WorldEntities/Atmosphere/LostRiver/BonesField/LostRiver_BonesField_CavePond";
        data["00ba4df5-a2bf-433b-8e7b-bd02c69e1c60"] = "WorldEntities/VFX/xUnderwaterElecSource_aurora_Small";
        data["00eb6018-9026-4267-b08d-b37e6439449e"] =
            "WorldEntities/Slots/SparseReef/SparseReef_Loot_Techsite_Scatter_Medium";
        data["00ef794e-924a-4a84-b197-448024fc2a4c"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/Starship_doors_frame_Aurora";
        data["010a7b79-cec2-48b1-bc99-48bc32ea1524"] = "WorldEntities/Lights/LavaZone/Inactive/Point_Lava_Huge";
        data["013ec2bf-4e86-45bd-b6a9-a59506f54099"] = "WorldEntities/Atmosphere/BloodKelp/Surface";
        data["0167e31d-c8f7-40a7-bfc2-557fb41b90bf"] = "WorldEntities/Atmosphere/SafeShallows/WreckInterior";
        data["017ad475-3c08-4d6d-ac99-407e2d4e8a91"] = "WorldEntities/Doodads/Precursor/PrecursorDoor05";
        data["01872776-2ff8-4214-805b-495001cf183d"] = "WorldEntities/Creatures/RabbitRay";
        data["01afc4fb-a1a4-46e7-883e-bd87523bff24"] = "Submarine/Build/Base_exterior_Planter_Tray_01";
        data["01b42581-d001-468b-9a10-1581a9eba669"] = "WorldEntities/Doodads/Coral_reef/Coral_reef_grass_01_green";
        data["01cdbef6-f07e-422a-b03a-5caf409da6d9"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/docking_clerical_pen1";
        data["01ce2153-aec9-44b4-9337-0237584ec431"] =
            "WorldEntities/Environment/Precursor/LavaCastleBase/Precursor_LavaCastleBase_Entry_Door";
        data["01d1e96d-8889-4251-ac6f-aefeeae9dabf"] =
            "WorldEntities/Slots/UnderwaterIslands/UnderwaterIslands_Loot_ValleyLedge";
        data["01de572d-5549-44c6-97cf-645b07d1c79d"] = "WorldEntities/Natural/LootCube";
        data["0202c252-0e61-4c6b-bf09-779c3313b37a"] =
            "WorldEntities/Environment/Wrecks/ExplorableWreck_SafeShallows_15_WeldablePanelRoot";
        data["02058e05-bdb3-4abb-96ef-b79df26e1a60"] = "WorldEntities/Slots/SafeShallows/SafeShallows_Loot_Grass";
        data["025086b3-14b0-48f8-8d29-e46cc7b927c8"] = "WorldEntities/Slots/Mountains/Mountains_Loot_CaveCeiling";
        data["0256293e-99d8-4db6-817d-b4ae24b2850c"] = "WorldEntities/Slots/Mesa/Mesa_Loot_Side";
        data["02684cd8-dac7-4f50-bc08-ba7f38631de3"] = "WorldEntities/Food/CuredPeeper";
        data["02689703-cae8-4d32-941b-57b2d48a8920"] =
            "WorldEntities/Slots/MushroomForest/MushroomForest_Creature_CaveSand";
        data["026c39c1-d0cc-442c-aa42-e574c9c281b2"] =
            "WorldEntities/Environment/AbandonedBases/AbandonedBaseJellyShroom3";
        data["026d91e2-430b-4c6d-8bd4-b51e270d5eed"] = "WorldEntities/Natural/drillable/DrillableSilver";
        data["02811422-2b55-4aab-998c-7424502956a1"] =
            "WorldEntities/Slots/DeepGrandReef/DeepGrandReef_Creature_ThermalVent";
        data["02937419-3b3e-4a4e-a111-384fb7d970c2"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/docking_bar_cup_02";
        data["02c0e341-6de9-466a-9c25-9a667ddb6158"] =
            "WorldEntities/Environment/DataBoxes/CyclopsSeamothRepairModuleDataBox";
        data["02c83418-e44f-4700-92ac-9283a69f9a94"] = "WorldEntities/Slots/BloodKelp/BloodKelp_Loot_Roots";
        data["02c994a3-9696-435d-86cd-821886d7ceba"] =
            "WorldEntities/Slots/GrassyPlateaus/GrassyPlateaus_Loot_Techsite_Small";
        data["02dbd99a-a279-4678-9be7-a21202862cb7"] = "WorldEntities/Environment/Wrecks/PDAs/EscapePod_19_PDA_Keen2";
        data["02dfa77b-5407-4474-90c6-fcb0003ecf2d"] = "Submarine/Build/Submarine_engine_fragments_02";
        data["02e525a1-dc51-4401-8caa-237eae0e32b8"] =
            "WorldEntities/Environment/Precursor/MushroomForestCache/Precursor_MushroomForestCache_TeleporterAnimatedPillars";
        data["032360a5-4478-4446-92c7-3f631a7f2ba4"] =
            "WorldEntities/Doodads/Coral_reef/coral_reef_small_deco_09_small";
        data["034c7bcb-5a73-407e-8de2-bf0a831222ee"] = "WorldEntities/Lights/Mountains/Mountain_cave_blue ambient";
        data["035288f9-40ac-4ac7-b3bf-d87a893e7ad5"] =
            "WorldEntities/Slots/MushroomForest/MushroomForest_Creature_Sand";
        data["03719702-beaf-4081-b791-bd2e5c118695"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/Base_exterior_Planter_Tray_01_empty_deco";
        data["03809334-e82d-40f5-9ccd-920e753887de"] =
            "WorldEntities/Environment/Precursor/CragFieldCache/Precursor_CragFieldTeleporter_ForceField";
        data["03a0d4b1-2447-44fd-918b-f97354e8d574"] = "Submarine/Build/GilathissHullPlate";
        data["03b14e1b-afe1-4405-be41-18b5b32cc9a9"] =
            "WorldEntities/Doodads/Coral_reef/Coral_reef_small_rocks_seaweed_05";
        data["03b86418-30ed-437c-ba1e-f8425bb78d31"] = "WorldEntities/Slots/CrashZone/CrashZone_Creature_TrenchRock";
        data["03d3e3b9-c8e4-4e05-9b6d-bd626c4f6be4"] =
            "WorldEntities/Slots/MushroomForest/MushroomForest_Creature_GiantTreeInteriorEntrance";
        data["03e0b225-ceb0-40dd-832d-e0e2d63032d0"] = "WorldEntities/Atmosphere/KooshZone/Kooshcave_Dark_green_box";
        data["03e54eb4-eec4-42a4-a492-571279bab382"] = "WorldEntities/Lights/Precursor/Precursor_Cave_Spotlight";
        data["03f7c46f-6fbc-4a90-84d7-c332b231d421"] = "WorldEntities/Doodads/Lava/lava_cliff_plate_01";
        data["043624a7-96c3-4232-b33b-38f9208467a0"] = "Base/Ghosts/BaseCorridorT";
        data["04542c2f-db0c-4aad-9cc9-b8b5f6a85438"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/starfish_04_bend";
        data["04781674-e27a-43ce-891f-a82781314c15"] = "WorldEntities/VFX/xLavaFallBase_15x15";
        data["049ae2d0-a256-48ab-b026-c1c625a4dcd1"] = "Submarine/Build/submarine_hatch_01_fragments";
        data["049d2afa-ae76-4eef-855d-3466828654c4"] = "WorldEntities/Tools/PowerUpgradeModule";
        data["04a07ec0-e3f4-4285-a087-688215fdb142"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/Starship_work_desk_01_empty";
        data["04a2d0ec-8036-4945-812b-5dc51d17c5f6"] =
            "WorldEntities/Doodads/Lost_river/lost_river_canyon_bottom_root_01_a";
        data["04a5b712-30cc-4da0-91a7-93d17ab01b29"] = "WorldEntities/Doodads/Geometry/SafeShallows/Coral_Clump03b";
        data["04ad6244-1766-4622-bb8a-7fa29845bc68"] =
            "WorldEntities/Environment/Precursor/LostRiverBase/Precursor_LostRiver_Junction_Pillar";
        data["04c3c51a-fa9c-4fe4-bc89-24061ffa6f26"] = "WorldEntities/Creatures/BoomerangLava";
        data["04ca9b18-577f-4878-bb7d-377677f9d6f2"] = "WorldEntities/Slots/BloodKelp/BloodKelp_Creature_OpenDeep";
        data["04d69bba-6c65-414d-bdaf-cc9b53fb9f3b"] = "WorldEntities/Doodads/Lost_river/lost_river_plant_01_01";
        data["04f7f423-1c83-4773-bc75-70784ad949d7"] = "WorldEntities/Slots/seaTreaderPath/SeaTreaderPath_Loot_Sand";
        data["0502d043-c3d5-408f-ba3b-7dda261a3b31"] = "WorldEntities/Seeds/WhiteMushroomSpore";
        data["0515430d-18cb-4ac7-bf6d-22bc877a16aa"] =
            "WorldEntities/Doodads/Coral_reef/coral_reef_Stalactites_cluster_01";
        data["0524596f-7f14-4bc2-a784-621fdb23971f"] =
            "WorldEntities/Environment/Precursor/LavaCastleBase/Precursor_LavaCastleBase_ThermalPlant_DoorTerminalRoot";
        data["052aafec-8084-43dc-a557-32818570bb5a"] = "WorldEntities/Natural/MushroomForestEgg";
        data["052cb571-09f1-4a28-9fd4-9878d4252a0c"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/descent_bar_sofa_corner_02";
        data["05400893-7eda-48d0-bd25-3977932f509c"] = "WorldEntities/Doodads/Land/Tropical Plant 6a";
        data["0552b196-d09a-45dd-b064-878966476179"] =
            "WorldEntities/Doodads/Lost_river/Lost_river_sea_dragon_skeleton";
        data["055b3160-f57b-46ba-80f5-b708d0c8180e"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/Starship_doors_frame";
        data["055e2f34-04cb-4081-8a57-9b87d3b184d7"] = "WorldEntities/Slots/Ship/Loot_ShipInterior_Lab";
        data["059c16e4-8f6d-44ad-8236-8f1a75e2253b"] =
            "WorldEntities/Slots/MushroomForest/MushroomForest_Creature_UniqueCreature";
        data["05bdb388-f91f-4043-9ef2-005fb48310dc"] = "WorldEntities/Doodads/Debris/Wrecks/Decoration/DecoPlanterPot2";
        data["05c3df2b-8710-4aec-b2cb-242846e040a5"] = "WorldEntities/Doodads/Land/land_plant_middle_08";
        data["05d9ddc7-2713-4ae4-a773-60642be618c4"] =
            "WorldEntities/Slots/UnderwaterIslands/UnderwaterIslands_Creature_CavePlants";
        data["05e802c0-a25b-4281-8fe8-d2dac8a2422b"] =
            "WorldEntities/Slots/LostRiver/BonesField/BonesField_Loot_Cave_Wall";
        data["05fec79a-402c-49c0-92e5-80bdb3354f2a"] =
            "WorldEntities/Lights/LostRiver/BonesField/LostRiver_BonesField_Ceiling_Spot1";
        data["061af756-643c-42ad-9645-a522f1338084"] =
            "WorldEntities/Doodads/Coral_reef/Coral_reef_slanted_coral_plates_01_01";
        data["062bd45e-7348-4495-84ee-71f08706a168"] = "WorldEntities/Doodads/Coral_reef/Coral_reef_brain_coral_01";
        data["062f48ef-2dcb-4138-9c6e-37d46bc0c4df"] = "WorldEntities/Slots/Dunes/Dunes_Creature_ThermalVent_Grass";
        data["06344fac-b350-4968-91d9-f7d27fa21e5a"] = "WorldEntities/Doodads/Debris/Wrecks/Decoration/DecoPlanterPot3";
        data["0642b532-9433-4f65-aa39-7757d954b7d2"] = "WorldEntities/Doodads/Coral_reef/Crab_snake_mushrooms_06_01";
        data["06456c0a-9283-42fa-918b-ab58607d5082"] = "WorldEntities/Doodads/Land/land_plant_middle_04_03";
        data["06562999-e575-4b02-b880-71d37616b5b9"] = "WorldEntities/Doodads/Coral_reef/Coral_reef_shell_tunnel_01";
        data["066e533d-f854-435d-82c6-b28ba59858e0"] = "WorldEntities/Doodads/Precursor/PrecursorKey_White";
        data["0675505a-4ade-4d1f-9b14-136368881cce"] = "WorldEntities/Structures/Observatory";
        data["06828cc8-578b-4b47-95d9-b2f40230fd27"] =
            "WorldEntities/Environment/Aurora/Consoles/Aurora_DriveRoom_Console";
        data["06856e8b-f612-495d-bc91-e9f629c0f689"] =
            "WorldEntities/Environment/Precursor/SurfaceVents/Precursor_UnderwaterIslands_Vent";
        data["06882740-cf0b-415e-ae9c-b8346cea00c8"] = "WorldEntities/Slots/KelpForest/KelpForest_Creature_ShellTunnel";
        data["06a946d7-58cc-4fc0-8f29-c0db548ef881"] = "WorldEntities/Doodads/Precursor/PrecursorElevator";
        data["06ada673-7d2b-454f-ae11-951d628e64a7"] = "WorldEntities/Natural/drillable/DrillableMercury";
        data["06c172d3-05d8-47f1-ba3f-682813c2c9e8"] =
            "WorldEntities/Slots/MushroomForest/MushroomForest_Loot_GiantTreeInteriorWall";
        data["06c3df8c-89d9-432c-b55f-86432ddbbbb5"] = "WorldEntities/Doodads/Precursor/Precursor_cube_02";
        data["06c5f749-5e38-4a0c-92a3-28783988f907"] =
            "WorldEntities/Doodads/Coral_reef/coral_reef_brown_coral_tubes_02_01";
        data["06cc39eb-af4c-4573-866a-d92e5d4c2bf1"] = "WorldEntities/Environment/Wrecks/Thermal_reactor_damaged_02";
        data["06fd4196-3058-4843-bfbf-9ea1f4985321"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/vent_constructor_junction_horizontal_01";
        data["07109939-90a9-4eae-a63f-d9e302e8c043"] = "WorldEntities/Doodads/Coral_reef/coral_reef_Stalactite_02_03";
        data["0719b0fa-95df-4b37-a581-4f1e07424c62"] =
            "WorldEntities/Doodads/Coral_reef/Coral_reef_jeweled_disk_green_01_03";
        data["071cee67-bcac-486c-acd9-a4413221eee3"] = "WorldEntities/Fragments/exosuit_damaged_06_unscannable";
        data["071fab51-1e04-4aa1-8013-df3707e58e45"] = "Submarine/Build/StarshipCircuitBox";
        data["07365b8b-4d3d-490c-9cbc-83af339a48e7"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/explorable_wreckage_modular_room_details_08";
        data["077ebe13-eb45-4ee4-8f6f-f566cfe11ab2"] = "WorldEntities/Doodads/Lava/lava_leak_01_02";
        data["0782292e-d313-468a-8816-2adba65bfba3"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/wall_monitor_01_01";
        data["078b41f8-968e-4ca3-8a7e-4e3d7d98422c"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/submarine_locker_05";
        data["07a05a2f-de55-4c60-bfda-cedb3ab72b88"] = "Submarine/Build/jacksepticeye";
        data["07db7e6c-79c6-4055-8526-875386bdeac1"] = "Submarine/Build/DoorKeypadConsole";
        data["07df8cba-5183-4d2f-9e04-d9dd8f330e28"] =
            "WorldEntities/Slots/ILZChamber/ILZChamber_Loot_ChamberFloor_Far";
        data["08078333-1a00-42f8-8492-e2640c17a961"] = "WorldEntities/Tools/Pipe";
        data["081c224e-2482-4731-8303-d84ce7dd9198"] = "WorldEntities/Slots/SafeShallows/SafeShallows_Loot_Wall";
        data["081ef6c1-aa78-46fd-a20f-a6b63ca5c5f3"] =
            "WorldEntities/Environment/Precursor/LavaCastleBase/Precursor_LavaCastleBase_AnimatedLight";
        data["083e02b8-9ea2-40e5-b8d1-22d236f284b9"] =
            "WorldEntities/Doodads/Debris/Aurora/Rooms/CrashedShip_interior_T_room";
        data["08733d03-58ec-4dbc-b65c-ee0256d66849"] =
            "WorldEntities/Slots/LostRiver/SkeletonCave/SkeletonCave_Loot_Lake_Floor";
        data["087bbe55-5879-43b8-bb78-0ee52fb013be"] = "WorldEntities/Tools/UltraGlideFins";
        data["088bda17-d77b-4c64-9f2a-42c8bcf9f7a5"] = "WorldEntities/Environment/Wrecks/Bio_reactor_damaged_04";
        data["08a1e11e-6076-4460-a93d-a20e025f18f2"] =
            "WorldEntities/Doodads/Lost_river/LostRiverBase/Lost_river_hanging_plant_04_01";
        data["08a95141-7c00-4d55-b582-306fa2e217ed"] = "WorldEntities/Doodads/Debris/Starship_exploded_debris_07";
        data["08b4a416-2cdf-4c6b-8772-f58255e525d7"] = "WorldEntities/Doodads/Lost_river/Lost_river_generic_bone_12";
        data["08c1c77c-6ca3-49d1-9e4f-608e87d6f90c"] = "WorldEntities/Doodads/Land/land_plant_middle_05_02";
        data["08cb3290-504b-4191-97ee-6af1588af5c0"] = "WorldEntities/Creatures/HoopFishSchool";
        data["08d40d50-af4e-46c4-b0b5-78bd3bd8b77c"] = "WorldEntities/Slots/LostRiver/Canyon/Canyon_Loot_Lake_Floor";
        data["08e6c2a8-76df-41de-87fd-5cba315a8aa4"] = "WorldEntities/Environment/DataBoxes/DataboxLight";
        data["08eab108-0cc1-4ef7-9e6a-faa3e624ba7e"] = "WorldEntities/Slots/Prison/Aquarium/PrisonAquarium_Loot_Sand";
        data["090c2b6a-c2ae-4c42-aa1a-e3ba13921c44"] =
            "WorldEntities/Slots/MushroomForest/MushroomForest_Loot_CaveEntrance";
        data["094cec1a-8687-441d-8522-356eceb77b5c"] = "WorldEntities/Slots/LavaFalls/LavaFalls_Loot_Floor_Far";
        data["09584992-22eb-4138-a126-1960aa9f0aa9"] = "WorldEntities/Slots/SparseReef/SparseReef_Creature_Wall";
        data["097e565a-51a2-43ff-b09d-f16e210341fc"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/descent_bar_sofa_corner_04";
        data["09883a6c-9e78-4bbf-9561-9fa6e49ce766"] = "WorldEntities/Creatures/SeaEmperorBaby";
        data["09bc9a07-7680-4ddf-9ba2-a7da5e7b3287"] = "WorldEntities/Doodads/Precursor/Prison/Relics/Alien_relic_12";
        data["0a203403-d38b-4922-8f82-9d844d73163f"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/docking_food_01_napkin_group";
        data["0a4da380-72c7-43f9-ab65-7fd8e2c227f5"] = "WorldEntities/VFX/xOilLeak_small";
        data["0a55618c-fc01-40f4-96e5-f3f4c9ee71c0"] = "WorldEntities/Lights/Mountains/Mountains_Precursor_Spotlight2";
        data["0a857a31-634f-41ff-9668-d95290e598d1"] =
            "WorldEntities/Environment/AbandonedBases/AbandonedBase PDA/JellyPDABreadCrumb1";
        data["0a9892c9-fdd2-4fa4-9233-81d90c3c4cea"] = "WorldEntities/Slots/SparseReef/SparseReef_Loot_CaveWall";
        data["0a993944-87d3-441e-b21d-6c314f723cc7"] = "WorldEntities/Creatures/HoverFish";
        data["0aaad212-6566-4a70-9cea-adeafc61f790"] =
            "WorldEntities/Slots/JellyshroomCaves/Jellyshroom_Loot_CaveSpecial";
        data["0ae50529-0f64-474a-9e19-5ae3e9020a8c"] = "WorldEntities/Atmosphere/KelpForest/KelpForest_Wreck_Adjust";
        data["0af1b3f6-ed7b-4983-b8c4-b2c4135318d6"] =
            "WorldEntities/Slots/MushroomForest/MushroomForest_Loot_GiantTreeInteriorSpecial";
        data["0af4f71c-fcc7-45dc-a4cd-d1cdb2d6721d"] = "WorldEntities/Slots/KooshZone/KooshZone_Creature_Grass";
        data["0b1cf8d8-65da-4b9d-bf86-bfb96ac35ae0"] =
            "WorldEntities/Environment/Precursor/Prison/PipeRoom/Precursor_Prison_PipeRoom_Tank";
        data["0b1fe733-31c5-44db-b6da-4d84b981b9d9"] = "WorldEntities/Natural/Silicone";
        data["0b203d52-8773-400a-9a74-ac5eed8c303d"] =
            "WorldEntities/Slots/seaTreaderPath/SeaTreaderPath_Loot_Techsite_Barrier_Small";
        data["0b359b03-92e4-40df-81ed-aad488a7f13e"] = "WorldEntities/Lights/Precursor/Precursor_Cave_Light";
        data["0b3e7b94-75a7-4cc3-bb9f-a81ed0dd3447"] = "WorldEntities/Tools/SeamothArmorPlating";
        data["0b6ea118-1c0b-4039-afdb-2d9b26401ad2"] =
            "WorldEntities/Doodads/Lost_river/Lost_river_generic_skeleton_01";
        data["0b8388eb-4337-47f9-ad9a-1988a88da5fa"] = "WorldEntities/Doodads/Lost_river/lost_river_pillar_03";
        data["0b8ad258-604e-40ee-aac8-0d62c5085caa"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/Base_interior_wall_planter_leaves_04";
        data["0b92e9cc-defd-4d2e-8629-eb083e21cdd3"] = "WorldEntities/Slots/Ship/Loot_ShipInterior_PlatformRecess";
        data["0ba2de19-0f6e-4469-bf77-8c0f9db95875"] = "WorldEntities/Environment/Wrecks/cyclopshullfragment3";
        data["0bb81651-f6e6-42f6-9741-70456cad9f4d"] =
            "WorldEntities/Doodads/Debris/Aurora/Decoration/Signs/Aurora_CrewArea_Cabin_01_Sign";
        data["0be47375-933b-4b60-9bab-11b727e48447"] =
            "WorldEntities/Environment/Precursor/LostRiverBase/Precursor_LostRiverBase_SeaDragonEggShell";
        data["0c13f261-4093-47ff-a9ac-8750627ac8f7"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/explorable_wreckage_modular_room_details_10";
        data["0c25f07a-fd44-43f9-83c5-67da751ff3f7"] =
            "WorldEntities/Atmosphere/LostRiver/BonesField/LostRiver_BonesField_Cave_Sphere";
        data["0c2c28c6-d8b6-436b-a767-ab8a573a4f26"] = "WorldEntities/Environment/ExplodedWreckage";
        data["0c65ee6e-a84a-4989-a846-19eb53c13071"] = "WorldEntities/Doodads/Debris/Starship_exploded_debris_20";
        data["0c71110b-8a11-4335-b5a0-94f69d17fc3c"] =
            "WorldEntities/Doodads/Debris/Aurora/Decoration/Signs/Aurora_CrewArea_Cabin_05_Sign";
        data["0c8a460a-3b93-4652-abd1-4a930b32a0a6"] = "WorldEntities/Eggs/ShockerEgg";
        data["0cb22d0e-ba5e-4e4b-b7a7-a67931fb5e0c"] = "WorldEntities/Tools/RegenPowerCell";
        data["0cb9b6b4-5f39-49f2-821e-6490829dad4b"] = "WorldEntities/Tools/Terraformer_damaged";
        data["0cd38e8c-5ba2-4202-8c33-19494df65579"] = "WorldEntities/Tools/LaserCutter_damaged";
        data["0cfea0d8-f5c7-4024-ba26-a7e4039c0b6b"] = "WorldEntities/Slots/KelpForest/KelpForest_Loot_CavePlants";
        data["0d02e5fd-44b1-4c52-b189-f4357a848001"] = "WorldEntities/Slots/LavaLakes/LavaLakes_Creature_Floor";
        data["0d151194-f58d-41d7-82f0-004649d0025e"] = "WorldEntities/Spawns/Spawn_Skyray_Decontaminated";
        data["0d325a65-d90d-4005-99ed-f77ae38777a4"] = "WorldEntities/Slots/KelpForest/KelpForest_Loot_TechSite_Medium";
        data["0d516d8d-3e03-4260-80f4-49f9df5979dd"] = "WorldEntities/Slots/GrandReef/GrandReef_Creature_Grass";
        data["0d798a35-29e8-4ddb-b1be-9d760d3a9eb6"] = "WorldEntities/Doodads/Debris/Starship_exploded_debris_36";
        data["0db5b44d-19f1-4349-9e1f-04da097010f3"] = "WorldEntities/Food/CuredBoomerang";
        data["0dbbd349-bc1e-448d-b143-9b44f6f0d2b1"] = "WorldEntities/Lights/LostRiver/Point_Lostriver_Smokers_Ambient";
        data["0dbd3431-62cc-4dd2-82d5-7d60c71a9edf"] = "WorldEntities/VFX/xBubbleColumn_big";
        data["0dbfbfbf-23f4-4506-9c49-5db80299d072"] =
            "WorldEntities/Environment/Aurora/Consoles/Wreck11_GrandReef_Console1";
        data["0df3f839-6103-4f61-b735-604861e91ef1"] = "WorldEntities/Environment/Wrecks/LEDLight_damaged_worldent";
        data["0e2a3f36-881b-4c84-8a02-5bb1da4b9f29"] = "WorldEntities/Doodads/Coral_reef/Coral_reef_membrain_tree_01";
        data["0e394d55-da8c-4b3e-b038-979477ce77c1"] =
            "WorldEntities/Environment/AbandonedBases/AbandonedBaseFloatingIsland3";
        data["0e481e2c-f82d-46e9-8323-ca49c67d96e6"] =
            "WorldEntities/Environment/Wrecks/ExplorableWreck_KelpForest_19_old";
        data["0e54e72a-3da8-4f5d-8440-f51033fcad8c"] = "WorldEntities/Environment/Wrecks/cyclopsbridgefragment3";
        data["0e67804e-4a59-449d-929a-cd3fc2bef82c"] = "WorldEntities/Environment/Bloom";
        data["0e741fad-4b06-4688-98d4-d7d08a21dd8e"] = "WorldEntities/Slots/Ship/Loot_ShipInterior_AuxPowerRoom2_Small";
        data["0e7cc3b9-cdf2-42d9-9c1f-c11b94277c19"] = "WorldEntities/Doodads/Lost_river/lost_river_cove_tree_01";
        data["0ef5c278-522a-401a-aed0-8610ab32aa26"] =
            "WorldEntities/Slots/Ship/Loot_ShipInterior_AuxPowerRoom1_Barrier";
        data["0f087cb7-e954-42b6-b4f5-e5db3df22fe3"] =
            "WorldEntities/Slots/LostRiver/Corridor/Corridor_Loot_Water_Floor";
        data["0f08f8f7-9319-4c7c-8271-6a982d73ab3a"] = "WorldEntities/Food/CookedSpinefish";
        data["0f1dd54e-b36e-40ca-aa85-d01df1e3e426"] = "WorldEntities/Environment/Wrecks/PDAs/Wreck8_BloodKelp_PDA1";
        data["0f29b3ae-c624-4b00-bb4b-f7a592700f07"] = "WorldEntities/Food/Coffee";
        data["0f3a2d07-8deb-4966-a060-e7e61fec2443"] =
            "WorldEntities/Environment/Aurora/Consoles/Aurora_Office_Console";
        data["0f4b5298-10ae-4ee6-81c2-3bb948ac7817"] =
            "WorldEntities/Slots/LostRiver/SkeletonCave/SkeletonCave_Loot_Grass";
        data["0f52fd6d-ffe4-4bd3-b8cb-2809f7a9ff7d"] = "WorldEntities/Natural/Creepvine_kelp_head";
        data["0f58e8a0-6ef9-4016-bbbf-9eb7e8070ae2"] = "Submarine/Build/ReinforceHull";
        data["0f66677c-8ffe-4dfb-bb8f-442a09339f6b"] =
            "WorldEntities/Slots/LostRiver/BonesField/BonesField_Creature_Cave_Wall";
        data["0f779340-8064-4308-8baa-6be9324a1e05"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/Starship_tech_box_01_02";
        data["0fbf203a-a940-4b6e-ac63-0fe2737d84c2"] = "Submarine/Build/PlanterPot3";
        data["0fd6b231-293e-4652-95fe-9474045da196"] =
            "WorldEntities/Lights/EmperorFacility/Precursor_Aquarium_Ambient_Light_Blue";
        data["0ff4c1c4-47cb-46c0-af9c-2365e095f69a"] =
            "WorldEntities/Slots/UnderwaterIslands/UnderwaterIslands_Creature_IslandCavePlants";
        data["100b164f-f1cc-42ec-9850-f84fad3ae75b"] = "WorldEntities/Slots/Dunes/Dunes_Creature_OpenShallow";
        data["1024a0f7-570f-4c65-8775-b3153a0f6409"] =
            "WorldEntities/Slots/MushroomForest/MushroomForest_Creature_MushroomTreeTrunk";
        data["105f340b-65ac-43c7-b2f0-612d2cf3e400"] =
            "WorldEntities/Doodads/Precursor/LavaBase/Final_Rooms/Precursor_LavaBase_ThermalRoomEntry";
        data["10749723-6f58-4e7f-b328-c36271743c0a"] = "WorldEntities/Environment/Wrecks/PDAs/EscapePod_2_PDA";
        data["107fefd3-d907-4648-8753-a8a8c0a6f293"] = "WorldEntities/Atmosphere/Inactive Lavazone/CastleChamber";
        data["109bbd29-c445-4ad8-a4bf-be7bc6d421d6"] = "WorldEntities/Natural/drillable/DrillableAluminiumOxide";
        data["10a176a9-8762-492f-b1b6-0b32e737b1bc"] = "WorldEntities/Environment/Wrecks/constructorfragment1";
        data["10b24c9a-4449-47da-8ca3-a6a44b9de945"] = "WorldEntities/Natural/FloatingStone4";
        data["10d3c291-f343-4d7c-a68a-ecc64229d086"] = "WorldEntities/Seeds/RedConePlantSeed";
        data["10e085ad-f967-4d14-8102-a47349baa207"] = "WorldEntities/Atmosphere/KelpForest/Normal";
        data["10e9863a-6b3f-4d00-9d1c-633edb122e42"] =
            "WorldEntities/Environment/Precursor/Prison/TeleporterRooms/Precursor_Prison_TeleporterHallway02_Lights";
        data["10e9a222-4be1-4082-aba7-4f7c7fd726cf"] = "WorldEntities/Seeds/KooshChunk";
        data["10ff8700-c95a-44d9-9be6-d16f29332c83"] =
            "WorldEntities/Doodads/Precursor/TempGun_Interiors/Precursor_Gun_TerminalHallway_02";
        data["11085872-1817-4aea-bc1d-d23b22f487f8"] = "WorldEntities/Fragments/Old/cyclopsdockingbayfragment_old";
        data["111c6334-5d1a-488a-8c0b-2f67ce26602e"] =
            "WorldEntities/Slots/Ship/Loot_ShipInterior_AuxPowerRoom2_Barrier_Small";
        data["11242fc2-01f3-40a2-9ea0-2d3403a30ea5"] =
            "WorldEntities/Slots/ILZChamber/ILZChamber_Creature_Chamber_Dragon_Open";
        data["113c69c3-da2a-49fa-af17-68391a2eb9ff"] = "WorldEntities/Slots/GrandReef/GrandReef_Loot_TechSite_Medium";
        data["114e12f4-58c6-4d1d-8fd5-3bff03bca912"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/starship_girder_01";
        data["1160ef75-8bf6-4bf4-a7d7-6718956e22f1"] =
            "WorldEntities/Doodads/Precursor/TempGun_Interiors/Precursor_Gun_Terminal_Room_01";
        data["116b71ea-da9c-46a1-a2fe-f0c07e9ce2be"] = "WorldEntities/Lights/DeepGrandReef/Upward Glow";
        data["118d8708-a7c5-4793-8cb0-33930817fcac"] =
            "WorldEntities/Environment/DataBoxes/SwimChargeFinsDataBoxSpawner";
        data["11b37cfb-53c9-4ce2-b307-1c4478e2aafc"] =
            "WorldEntities/Slots/UnderwaterIslands/UnderwaterIslands_Creature_CaveWall";
        data["11bd0c8e-6d57-46cb-928a-f0e825726674"] = "WorldEntities/Doodads/Coral_reef/Coral_reef_green_reeds_03";
        data["11d1072f-f800-445b-9b51-589b72c8e520"] =
            "WorldEntities/Environment/DataBoxes/CyclopsSeamothRepairModuleDataBoxSpawner";
        data["11e3ab1a-3848-4992-a40c-078eb43431fd"] =
            "WorldEntities/Environment/Precursor/LostRiverBase/Precursor_LostRiverBase_Lab_01";
        data["11e731e7-bc82-4f94-90be-5db7b58b449b"] =
            "WorldEntities/Doodads/Precursor/Prison/Relics/Precursor_lab_container_relic_02";
        data["11ea0dd6-015f-4528-bed7-18de03f54911"] =
            "WorldEntities/Doodads/Coral_reef/Sparse_Reef/coral_reef_plant_middle_01_sparsereef";
        data["11eaf4c6-8bf6-4c0a-a70e-2c6c87c9b4ff"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/explorable_wreckage_modular_room_details_04";
        data["11fcc187-68a5-400a-85f6-09387db86265"] = "WorldEntities/Tools/Floating_storage_cube_damaged";
        data["121af576-93f3-49e5-b515-3ef2c8d4f02b"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/starship_girder_05";
        data["1235093d-3e84-4e98-9823-602db2e8fa5f"] = "WorldEntities/Doodads/Debris/Starship_exploded_debris_12";
        data["12458be9-f541-41e0-94b6-bcc5f077f171"] = "WorldEntities/Slots/KelpForest/KelpForest_Creature_CaveSpecial";
        data["125686ad-18a8-41dd-8d14-ad3118479bd1"] =
            "WorldEntities/Doodads/Precursor/LostRiverBase/Precursor_LostRiverBase_Lab1Glass";
        data["127f22a3-44cd-4341-adb8-8937317f53de"] = "WorldEntities/Fragments/seaglidefragment";
        data["12a7577b-68c4-45ae-8172-42abf649501e"] =
            "WorldEntities/Environment/AbandonedBases/AbandonedBase PDA/IslandsPDAExterior";
        data["12c95e66-fb54-47b3-87f1-8e318394b839"] = "WorldEntities/Tools/Flashlight";
        data["12de58d8-6605-4e00-a1c8-90dd4f7c386c"] =
            "WorldEntities/Lights/Precursor/Aquarium/Aquarium_Platform_Uplight 3";
        data["12e70806-8914-423b-b88f-651e50aa6fdf"] = "WorldEntities/Slots/Ship/Loot_ShipInterior_Corridor";
        data["130457c2-f4b0-4183-842c-5ed1e047cc01"] = "WorldEntities/Tools/ExosuitPropulsionArmModule";
        data["13071f53-7289-4969-a71a-017c3dba86be"] = "WorldEntities/VFX/xBubbleColumn_medium";
        data["1317cce4-0ddb-4e7a-9ee7-f0de3b9e7bbe"] = "WorldEntities/Doodads/Debris/Starship_exploded_debris_30";
        data["133ae1eb-99ec-4b1d-b32b-9c9daf144b8f"] = "WorldEntities/Doodads/Coral_reef/Coral_reef_green_reeds_06";
        data["134af5be-0ab8-42ed-babc-186b4a56b986"] = "WorldEntities/Environment/DataBoxes/RepulsionCannonDataBox";
        data["134b6cca-0955-4cc7-ab66-bc639189f83e"] =
            "WorldEntities/Environment/Precursor/Prison/Aquarium/Precursor_Prison_Aquarium_Teleporter_Final";
        data["138607f4-72c4-4e80-bc4b-2588f52495b4"] = "WorldEntities/Natural/FloatingStoneSmall2";
        data["13b516f6-c038-4207-b30b-766e24911b58"] = "WorldEntities/Environment/Prototype/ThermalVent";
        data["13c351c6-489d-4de1-a49d-c56d1658cfac"] = "WorldEntities/Slots/GrandReef/GrandReef_Loot_RockDeep";
        data["13d0fb01-2957-49e0-b153-6dc88332694c"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/generic_forklift";
        data["141a2a48-7ae1-4b43-be4e-31f90b7990a0"] = "WorldEntities/Atmosphere/TreaderPath/Treader Path Base";
        data["145c29c7-dc51-439f-af21-c3ed0945ec71"] =
            "WorldEntities/Slots/MushroomForest/MushroomForest_Creature_GiantTreeInteriorRecess";
        data["147b6bb6-cee5-46a1-a932-4d1524f79fdc"] = "WorldEntities/Slots/LavaFalls/LavaFalls_Loot_Floor";
        data["1481b2fd-abf8-4965-b979-0751f726adea"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/LEDLight_damaged";
        data["1492fbd2-6978-47d9-9cfd-deb4a48dbb83"] =
            "WorldEntities/Environment/Wrecks/ExplorableWreck_SafeShallows_40";
        data["14bbf7f0-4276-48bf-868b-317b366edd16"] =
            "WorldEntities/Environment/Aurora/Aurora_ExtinguishableFire_Small";
        data["14ca2eee-af46-418d-a08d-5340373cfc09"] =
            "WorldEntities/Doodads/Precursor/LavaBase/Precursor_LavaCastleBase_Flat_Animated_Med";
        data["14cd4cc9-93ef-4104-ae95-f8cee52a5698"] =
            "WorldEntities/Doodads/Precursor/TempGun_Interiors/Gun_LargeHallway";
        data["150d0361-d9e8-4e2b-a930-6398992ba115"] = "WorldEntities/Atmosphere/ActiveLavazone/LavaFalls";
        data["15378df5-5fce-4346-8811-267dd13d54fc"] =
            "WorldEntities/Environment/Precursor/SurfaceVents/Precursor_SparseReef_Vent";
        data["154a88c1-6c7f-44e4-974e-c52d2f48fa28"] = "WorldEntities/Doodads/Land/Tropical Plant 6b";
        data["154c0482-917d-43d0-a872-f467291be796"] = "WorldEntities/Slots/Ship/Loot_ShipInterior_PowerRoomSpecial";
        data["155b385c-7401-47e7-9e9a-62bf7aa50f7a"] =
            "WorldEntities/Doodads/Precursor/LavaBase/Lights/Precursor_LavaCastleBase_Entry02";
        data["155f315f-bc11-40f5-b4d3-87587621fa37"] = "WorldEntities/Environment/Generated/Signal";
        data["1595a25d-2d14-41e3-9a93-629fa86566bf"] = "WorldEntities/Seeds/CreepvinePiece";
        data["159a22bd-8ab9-479b-95c0-35b09ecdd8b7"] = "WorldEntities/Doodads/Coral_reef/Crab_snake_mushrooms_06_02";
        data["15a3e67b-0c76-4e8d-889e-66bc54213dac"] = "WorldEntities/Natural/SupplyCrate_FirstAidKit";
        data["15a6954f-f89b-49b1-a2d7-ac566c6b703e"] =
            "WorldEntities/Slots/KelpForest/KelpForest_Creature_CaveEntrance";
        data["15dc4705-16b1-4903-813a-817bd6447e96"] = "WorldEntities/Doodads/Debris/Starship_exploded_debris_18_Far";
        data["15f55c15-2111-4ea8-bae0-20532029fe79"] =
            "WorldEntities/Environment/Precursor/SurfaceVents/Precursor_Dunes_Vent";
        data["15f5681f-c9fa-49eb-b8fb-28fcab8810b4"] = "Base/Ghosts/BaseHatch";
        data["15fb7630-c2ae-4d34-b40d-9d0f1a5f8ddf"] = "WorldEntities/VFX/xSandFall_SmallNoLoop";
        data["1607277c-65f8-4c82-b739-2c6fd937e0ee"] =
            "WorldEntities/Environment/Precursor/LostRiverBase/Precursor_LostRiverBase_ObservationRoom";
        data["160e99a7-cb46-409d-98e2-360a76ff92da"] = "WorldEntities/Tools/StasisRifle";
        data["1616e69b-110a-4a3d-9c9d-df20c1efcc0c"] = "WorldEntities/Slots/GrandReef/GrandReef_Creature_CaveFloor";
        data["1618a787-67b7-4e35-9869-3ec558ed2835"] = "WorldEntities/Environment/Wrecks/ExplorableWreck_GrandReef_11";
        data["16256a58-f08a-435a-8b9c-518c43d6b214"] = "WorldEntities/Doodads/Lava/lava_rock_01_06";
        data["162d1764-14ec-4447-a994-809b0d48b552"] = "WorldEntities/Slots/KooshZone/KooshZone_Creature_OpenShallow";
        data["1645f35d-af23-4b98-b1e4-44d430421721"] = "WorldEntities/Environment/Coral_reef_floating_stones_small_02";
        data["165066e8-9fca-47fa-beba-7e7a62d8c117"] = "WorldEntities/Lights/JellyshroomCave/Small_Mushroom_Light";
        data["166fc3f0-c7cc-4dcc-8b33-43fa5cbddb8e"] = "WorldEntities/Slots/SafeShallows/SafeShallows_Creature_Wall";
        data["1673ee4a-6c28-4651-8d5e-929de26dc25f"] =
            "WorldEntities/Environment/Precursor/Prison/Antechamber/Final Rooms/Precursor_Prison_EggLab";
        data["16847fda-bb49-4823-baf3-910e4cd25938"] =
            "WorldEntities/Slots/FloatingIsland/FloatingIsland_Loot_AbandonedBase_Outside_Small";
        data["16c60cdf-2a1c-4aff-ba9a-4c9b989cced5"] = "WorldEntities/Environment/Wrecks/ExosuitClawArmdeco";
        data["16c9a905-b015-4deb-8ac0-1f9e59ace7c7"] = "WorldEntities/Slots/LavaLakes/LavaLakes_Loot_Wall";
        data["16d326b7-0cbe-4df9-bc58-3cd26b5458af"] = "WorldEntities/Environment/Wrecks/exosuitfragment5";
        data["16d7068b-36a2-48b1-b694-4ad4cff57e9e"] =
            "WorldEntities/Slots/LostRiver/Corridor/Corridor_Creature_ThermalVent";
        data["16db6d94-c808-4b76-876c-284e57e00b86"] = "WorldEntities/Doodads/Debris/Wrecks/ExplorableWreckRoom06";
        data["17083b5b-b25b-46b2-93c5-f70a7e517082"] = "WorldEntities/Slots/Dunes/Dunes_Creature_CaveCeiling";
        data["171c6a5b-879b-4785-be7a-6584b2c8c442"] = "WorldEntities/Environment/BrainCoral";
        data["172d9440-2670-45a3-93c7-104fee6da6bc"] = "WorldEntities/Doodads/Precursor/Precursor_Lab_infoframe";
        data["176bcfff-624b-4f2b-8fb6-b80a540faa6a"] = "WorldEntities/Atmosphere/KooshZone/Normal";
        data["176d929f-3d86-4627-93ad-b656d4111337"] = "WorldEntities/Environment/Wrecks/ExplorableWreck_SparseReef_20";
        data["1775f8db-7479-40ad-8c69-f2ffaf3b09f8"] =
            "WorldEntities/Environment/Precursor/Gun/Precursor_Gun_MoonPool_SickScanner_old";
        data["1780f206-8787-48f3-ad41-b336a0d1ab99"] = "WorldEntities/Doodads/Coral_reef/coral_reef_small_deco_21_02";
        data["17fd8972-6ba9-4d10-a446-0a28911eda65"] =
            "WorldEntities/Environment/Wrecks/ExplorableWreck_SafeShallows_16_WeldablePanel1";
        data["18028509-764a-4959-950e-df12fc1eb105"] = "WorldEntities/Slots/Dunes/Dunes_Creature_ThermalVent";
        data["18042762-9460-44ca-a2d7-c4932d7d8193"] = "WorldEntities/Doodads/Lost_river/Lost_river_rib";
        data["18229b4b-3ed3-4b35-ae30-43b1c31a6d8d"] = "WorldEntities/Natural/bloodoil";
        data["1826f338-40d2-4b85-8d15-08ea3fa669ad"] = "WorldEntities/Creatures/GhostRayBlue";
        data["182c6757-a306-48c6-abcb-ed6488aa5627"] =
            "WorldEntities/Doodads/Precursor/LavaBase/Lights/Precursor_LavaCastleBase_Teleporter";
        data["18521f9a-4b46-4994-9475-984d64993d9c"] =
            "WorldEntities/Environment/Wrecks/battery_charging_station_damaged_cover";
        data["1862748b-ebc8-4b00-8284-1b7763bee766"] = "WorldEntities/Slots/KelpForest/KelpForest_Creature_Sand";
        data["186cb391-e602-4eda-909a-cbce702fb303"] = "WorldEntities/Doodads/Precursor/Prison/Relics/Alien_relic_04";
        data["18aa16f9-d1d8-4ccd-8a10-7ad32a5fd283"] = "WorldEntities/Doodads/Precursor/precursor_cables_start_01";
        data["18c72c78-af7b-4380-94ce-607eb36e5952"] = "Base/Ghosts/BaseNuclearReactor";
        data["18c78a26-806b-4ffd-bfd5-53eb7975decf"] = "WorldEntities/Environment/ThermalVent_Dark_Small";
        data["18ee2413-63ae-46ba-a357-ec8d89540d52"] = "WorldEntities/Slots/Ship/Loot_ShipInterior_LivingArea_Barrier";
        data["18ee383c-a419-4503-8139-8d783998c063"] =
            "WorldEntities/Slots/UnderwaterIslands/UnderwaterIslands_Loot_IslandCaveFloor";
        data["18f2fbaa-78df-46a9-805a-79ac4d942125"] =
            "WorldEntities/Environment/Precursor/Prison/Antechamber/Precursor_Prison_MainDoor_LockedForceField";
        data["18fcfdd3-ac13-4a52-b8ab-d2f82f8a57b4"] = "WorldEntities/Slots/Dunes/Dunes_Loot_CaveFloor";
        data["18fdab22-2b76-4bd0-b962-0a7f3d79250d"] = "WorldEntities/Doodads/Coral_reef/Crab_snake_Lower_plate_01_02";
        data["1907cccb-99b5-4794-b7a0-e4d39fede815"] = "WorldEntities/Slots/LostRiver/GhostTree/GhostTree_Loot_Grass";
        data["190f8620-b5d2-4799-9b3c-84b7f93fe594"] = "WorldEntities/Doodads/Debris/Starship_exploded_debris_06_Far";
        data["192eb14c-d69e-4df3-bfc5-996597872e72"] = "WorldEntities/Doodads/Coral_reef/Coral_reef_green_mohawk_03";
        data["19524fc9-f1cc-4bc9-9404-94aaaf3e81a0"] =
            "WorldEntities/Doodads/Debris/Aurora/Decoration/Signs/Aurora_CrewArea_Cabin_02_Sign";
        data["19747d62-16c9-4162-89e4-a151ed277500"] = "WorldEntities/Environment/Prototype/Lavaspout";
        data["199894b7-cfd5-4d38-89e8-2117ce43824c"] =
            "WorldEntities/Doodads/Precursor/Precursor_cube_03_damaged_piece_05";
        data["1998daaf-c5de-490f-89b0-2bf336685c46"] =
            "WorldEntities/Doodads/Precursor/precursor_cables_start_LavaCastle";
        data["199e2915-8406-4b8f-9325-a7a3cabac204"] =
            "WorldEntities/Doodads/Precursor/LavaBase/Final_Rooms/Precursor_LavaBase_Extras";
        data["19a28dc6-33d6-4049-808b-b68ba5b3152e"] = "WorldEntities/Atmosphere/UnderwaterIslands/Normal";
        data["19aacea8-b5d7-4e38-9fe5-bd9a34b80093"] = "WorldEntities/Doodads/Coral_reef/Coral_reef_kelp_grow";
        data["19d017a5-2e59-4c1f-bc44-e642f7d7fbd3"] = "WorldEntities/Doodads/Precursor/precursor_doorway_01";
        data["19de8b20-eaa7-4fc5-b678-f846c44a895f"] = "WorldEntities/Fragments/exosuit_03_old";
        data["19e3c9a7-66e5-4849-abc6-11d48d63887a"] = "WorldEntities/Atmosphere/KooshZone/KooshCaveSpecial";
        data["19feccc5-36a0-431c-ae97-16f87c21d5af"] =
            "WorldEntities/Environment/Aurora/Aurora_LivingArea_CaptainsQuarters_Keypad";
        data["19ff11f5-3302-43ce-a80e-45246e5eb9ec"] = "WorldEntities/Slots/SafeShallows/SafeShallows_Creature_Grass";
        data["1a13906d-a61e-45a8-8c9c-79d2c2c642cd"] = "WorldEntities/Slots/GrandReef/GrandReef_Loot_CaveWall";
        data["1a3aa5aa-b3bf-499d-82f8-164a0799c46a"] = "WorldEntities/Slots/LostRiver/TreeCove/TreeCove_Loot_Ceiling";
        data["1a3be11a-6bf4-425a-ac96-850d9268b016"] =
            "WorldEntities/Environment/Precursor/Prison/Aquarium/Precursor_Mountains_Teleporter_Final_ToPrisonAquarium";
        data["1a406cdc-3e96-4ce2-a24a-81404af65619"] = "WorldEntities/Fragments/ThermalPlant_Fragment";
        data["1a485821-923c-418c-9822-d8d5c17c7f53"] = "WorldEntities/Tools/GasTorpedo";
        data["1a62c4d7-0c6b-46a8-9475-00b31ee053d9"] =
            "WorldEntities/Lights/Precursor/Precursor_Cache_Spotlight_Generic";
        data["1a6c4d28-df97-414a-a9e8-4ddc26a351e4"] = "WorldEntities/Slots/SafeShallows/SafeShallows_Creature_Island";
        data["1a806d20-dc8f-4e6e-9281-f353ed155abf"] = "WorldEntities/Doodads/Coral_reef/coral_reef_plant_middle_07";
        data["1a97d459-0b76-4116-9155-43893526a521"] = "WorldEntities/Atmosphere/KooshZone/HugeKooshLoot";
        data["1abc3b6f-0b8e-4066-8288-48e5d06ac8c9"] = "WorldEntities/Fragments/seamoth_fragment_03_aurora";
        data["1ac450d0-bfa3-42f4-b367-debb2981298a"] = "WorldEntities/Environment/Wrecks/ExplorableWreck_Mountains_19";
        data["1aca2ea3-17dd-4219-8c9f-789124a07d29"] =
            "WorldEntities/Slots/LostRiver/Junction/Junction_Loot_Water_Wall";
        data["1af07b41-6122-4fd9-8ea2-5fec50bcf6c5"] = "WorldEntities/Slots/LostRiver/Junction/Junction_Creature_Roots";
        data["1b0b7f6d-9793-469c-9872-dfe690834fee"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/biodome_lab_containers_open_01";
        data["1b32534f-3d8c-45a1-aa56-bb8511e849e5"] = "WorldEntities/Slots/ILZChamber/ILZChamber_Creature_ChamberOpen";
        data["1b3e4b90-9882-4a35-afa9-9fba7b908a4a"] = "WorldEntities/VFX/xLavaSplashes_30x15";
        data["1b414585-d071-48c7-b35c-7ba870989509"] = "WorldEntities/Atmosphere/GrandReef/Normal";
        data["1b72fee8-cf1e-439b-a63e-148e2920c1ca"] =
            "WorldEntities/Slots/LostRiver/BonesField/BonesField_Creature_Corridor_Skeleton";
        data["1b8586bc-cb03-4c87-9db2-2218aab95be1"] = "WorldEntities/Atmosphere/DeepGrandReef/Normal_named(sphere)";
        data["1b85a183-2084-42a6-8d85-7e58dd6864bd"] = "WorldEntities/Doodads/Precursor/Precursor_lab_container_02";
        data["1b8df552-1b3e-4e96-ba1a-3d35afcb2c18"] = "WorldEntities/Fragments/exosuit_damaged_05";
        data["1b8e6f01-e5f0-4ab7-8ba9-b2b909ce68d6"] = "WorldEntities/Environment/DataBoxes/CompassDataBox";
        data["1b968abb-6b50-4679-8793-c66a1ce17e97"] = "WorldEntities/Doodads/Coral_reef/coral_reef_small_deco_21_01";
        data["1bb43d52-19ee-4a3a-85ef-f85a152cc334"] = "WorldEntities/Doodads/Coral_reef/coral_reef_plant_middle_02";
        data["1bb9412e-561d-4b33-a1f6-8facb564999b"] =
            "WorldEntities/Doodads/Debris/Aurora/Decoration/Signs/Aurora_THallway_Office_Sign";
        data["1bdbad41-adcb-47db-ab2c-0dc4a7180860"] =
            "WorldEntities/Environment/AbandonedBases/AbandonedBase PDA/JellyPDAObservatory";
        data["1beda595-bfc0-4843-8565-c6498283c97c"] = "WorldEntities/Doodads/Lava/lava_leak_01_05";
        data["1bf5dc53-a895-4fe9-bcd8-4182dbb9b4af"] =
            "WorldEntities/Environment/DataBoxes/PrecursorIonEnergyDataBox_old";
        data["1c05df94-9cbc-474a-8efe-f80778267aac"] =
            "WorldEntities/Slots/KelpForest/KelpForest_Loot_EscapePod_Medium";
        data["1c147fcd-f727-4404-b10e-a1f03363e5bf"] = "WorldEntities/Doodads/Debris/Starship_exploded_debris_28";
        data["1c28891f-df08-4eee-a081-118955b0d303"] =
            "WorldEntities/Doodads/Coral_reef_Light/Coral_reef_Kelp_blood_01_Light";
        data["1c308d7c-85b9-4d1e-8e16-113a45b3ed35"] = "WorldEntities/Natural/uranium";
        data["1c34945a-656d-4f70-bf86-8bc101a27eee"] = "WorldEntities/Tools/SeaMoth";
        data["1c36157e-7989-4a74-aa53-b9e493c122d0"] = "WorldEntities/Slots/Ship/Loot_ShipInterior_Cargo_Crate_Small";
        data["1c3f8305-c6b2-4640-b799-e535e65a8e15"] = "WorldEntities/Atmosphere/FloatingIslands/FloatingIslandBelow";
        data["1c52f569-1173-4035-a3a1-52db61487b25"] =
            "WorldEntities/Environment/Precursor/MountainIsland/Precursor_Mountain_Columns_FromFloatingIsland";
        data["1c712a10-2ace-478a-a6ff-26dc393bcb7a"] = "WorldEntities/Slots/Dunes/Dunes_Loot_Grass";
        data["1c7b814c-0551-4b4e-9221-35ef18d8568c"] = "Base/Ghosts/BaseObservatory";
        data["1c8bf0ca-687f-44b9-8942-82feaa800a69"] =
            "WorldEntities/Doodads/Coral_reef/Coral_reef_red_seaweed_03_short";
        data["1c953310-8436-4012-8e0d-3b4634f07e57"] = "WorldEntities/Fragments/ExosuitTorpedoArmfragment";
        data["1ca3e2b9-646c-451b-a933-eb84e368310c"] = "WorldEntities/Seeds/EyesPlantSeed";
        data["1ca78598-cfaa-4171-91c7-bd19d8b2dd8a"] =
            "WorldEntities/Environment/Aurora/Wreck_GrassyPlateaus_2_WeldablePanel_Root";
        data["1caa65b3-a534-4651-bf4d-516f59522333"] =
            "WorldEntities/Environment/Wrecks/ExplorableWreck_SafeShallows_36";
        data["1cafd118-47e6-48c4-bfd7-718df9984685"] = "WorldEntities/Environment/Coral_reef_floating_stones_mid_01";
        data["1cc51be0-8ea9-4730-936f-23b562a9256f"] = "WorldEntities/Doodads/Land/Land_tree_01";
        data["1ce074ee-1a58-439b-bb5b-e5e3d9f0886f"] = "WorldEntities/Natural/CrashPowder";
        data["1d1898ca-8436-4fe4-aaf4-a1d9fa6d58cb"] = "Submarine/Build/BarTable";
        data["1d320926-0389-4e63-9a3d-9534b6bb2230"] = "WorldEntities/Doodads/RandomBoulder";
        data["1d5877a7-bc56-46c8-a27c-f9d0ab99cc80"] = "WorldEntities/Doodads/Land/land_plant_middle_04_01";
        data["1d6d89dd-3e49-48b7-90e4-b521fbc3d36f"] = "WorldEntities/Doodads/Land/land_plant_middle_03_02";
        data["1d6e455b-3f4a-4340-b3b1-b69d912b55b1"] =
            "WorldEntities/Doodads/Lost_river/Lost_river_hanging_plant_01_01";
        data["1d756199-d738-4cf4-a672-d5d75c2564d4"] = "WorldEntities/Doodads/Precursor/Cable_05";
        data["1d85aa3f-5ccc-4f48-9409-bbb473a16d71"] = "WorldEntities/Slots/LostRiver/TreeCove/TreeCove_Loot_Ledgewall";
        data["1dbf4801-b2b7-4aaa-bd66-d1d925359d01"] = "WorldEntities/Atmosphere/Inactive Lavazone/CastleTunnel";
        data["1dc2a075-fc2d-49a9-a857-460538d63112"] =
            "WorldEntities/Atmosphere/LostRiver/BonesField/LostRiver_BonesField_BloodKelpEntrance_Pool";
        data["1dc87b04-84d4-42e1-afbf-ee8c2a9a236f"] =
            "WorldEntities/Doodads/Coral_reef/Coral_reef_barnacle_suckers_01";
        data["1de4fe84-4a64-4d80-9572-1b3e97e461d2"] = "WorldEntities/Atmosphere/SafeShallows/Caves";
        data["1e16f0d8-a731-4429-9cfd-e6f362030a2d"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/explorable_wreckage_modular_room_details_01";
        data["1e2b6dd4-15e4-401d-a12c-847c2c6bb0b3"] =
            "WorldEntities/Slots/Ship/Loot_ShipInterior_ExoRoomPipes_Barrier_Small";
        data["1e6569bd-1fc8-461a-b998-5bdf08b1d42e"] = "WorldEntities/Slots/ILZChamber/ILZChamber_Loot_MagmaTree";
        data["1e680e3a-8456-4b7a-a071-bb872b7dcc40"] =
            "WorldEntities/Slots/UnderwaterIslands/UnderwaterIslands_Loot_IslandCavePlants";
        data["1e6a14e8-aa89-497b-87be-cde82944887d"] =
            "WorldEntities/Slots/GrassyPlateaus/GrassyPlateaus_Loot_CaveWall";
        data["1e6dc864-4259-485f-873e-0b65a1c20b15"] = "WorldEntities/Doodads/Lost_river/Lost_river_tree_roots_03";
        data["1eca71a0-6736-481f-be9d-bd5f6fc036a8"] = "WorldEntities/Natural/ComputerChip";
        data["1ecaf823-29af-4631-b4bb-8faf645ec8bc"] =
            "WorldEntities/Slots/LostRiver/BonesField/BonesField_Creature_ThermalVent";
        data["1ed1fcc0-b5db-4518-bfde-317e672bb339"] = "WorldEntities/Natural/rebreather";
        data["1edd7411-8f1d-4e7a-8378-0ce7ccb6ea82"] =
            "WorldEntities/Doodads/Coral_reef/Coral_reef_jeweled_disk_blue_01_02";
        data["1efa1a20-3a39-4f56-ace0-154211d6af12"] = "WorldEntities/Natural/drillable/DrillableLead";
        data["1f0a726f-1078-4e41-ac5d-47ded5fcc9fb"] =
            "WorldEntities/Slots/JellyshroomCaves/Jellyshroom_Loot_InsideShroom";
        data["1f177727-042c-4edc-abf6-f613215b47ab"] = "WorldEntities/Seeds/SpottedLeavesPlantSeed";
        data["1f2643a7-49b5-43df-9b87-e370683fbdbd"] = "WorldEntities/Slots/GrandReef/GrandReef_Loot_ThermalVent";
        data["1f384257-9d4a-4307-829f-024c0e1ce1c0"] =
            "WorldEntities/Doodads/Coral_reef/Coral_reef_jeweled_disk_green_01_02";
        data["1f523e41-26bb-4de2-b596-73bebfd4a397"] = "WorldEntities/Slots/Ship/Loot_ShipInterior_Locker_Small";
        data["1f562c1a-a3e5-416e-a915-dbf47c0d48e7"] =
            "WorldEntities/Lights/Precursor/Aquarium/Aquarium_Platform_Uplight 1";
        data["1f5cee66-a02f-4693-a1bd-928c938c7e77"] = "WorldEntities/Fragments/seamoth_fragment_02";
        data["1f9993c3-3025-4e8d-8805-4f0fc16adaff"] = "WorldEntities/Atmosphere/ActiveLavazone/LavaLakes_LavaPool";
        data["1faf2b57-ff4f-4ea5-a715-7cc5ff6aae60"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/biodome_lab_containers_open_03";
        data["1fcb5195-b760-4311-8666-aaeb9adfda42"] =
            "WorldEntities/Environment/AbandonedBases/AbandonedBase PDA/IslandsPDABase1PrecursorKey";
        data["1fcbf0f8-01fd-4454-a48d-3b3266e5b84e"] = "WorldEntities/Doodads/Coral_reef/Coral_reef_green_reeds_02";
        data["1fd4d86f-3b06-4369-945c-ca65f50b4800"] = "WorldEntities/Doodads/Coral_reef/Coral_reef_kelp_young_01";
        data["1fd81ec0-16be-4667-a818-0ebfcc74170b"] = "WorldEntities/Doodads/Lost_river/lost_river_plant_01_02";
        data["1ff3302c-c954-4afe-a596-8e6327776a5b"] = "WorldEntities/Slots/SparseReef/SparseReef_Creature_OpenDeep";
        data["200be3e2-dd25-4288-81b6-54476c1e210c"] = "WorldEntities/Doodads/Lost_river/Lost_river_tree_roots_01";
        data["2018e281-5012-4d04-8b81-cc3c7f4706ed"] =
            "WorldEntities/Doodads/Debris/Wrecks/ExplorableWreckRoom06_aurora";
        data["202a4db8-99ae-4a55-bf28-64821f2cbe69"] =
            "WorldEntities/Atmosphere/Mountains/Mountains_IslandTeleporter_sph";
        data["204b505c-09c3-46d2-b5c9-08492e89215c"] =
            "WorldEntities/Doodads/Debris/Aurora/Decoration/Signs/Aurora_CrewArea_Cabin_07_Sign";
        data["204fce90-17ae-4d34-a752-e8abfed1aac6"] =
            "WorldEntities/Atmosphere/Mountains/Mountains_IslandCave_Surface_sph";
        data["20637667-05a4-45cd-8e31-b33799f63118"] =
            "WorldEntities/Environment/GrassyPlateaus/Obstruction_Rock_Medium01";
        data["2068541f-3e94-4215-a636-dcd0c044df8c"] = "WorldEntities/VFX/xLavaSplashes_30x6";
        data["207b5534-9df0-48d1-afa5-6777258e2650"] = "WorldEntities/Doodads/Geometry/SafeShallows/Coral_Clump02d";
        data["2086a6af-c8ba-47f6-8e2a-1a4ac88dcd8b"] =
            "WorldEntities/Doodads/Debris/Aurora/Rooms/CrashedShip_seamoth_room";
        data["209caf5e-8823-45a9-b211-c822b4432838"] =
            "WorldEntities/Slots/SafeShallows/SafeShallows_Loot_TechSite_Medium";
        data["209f590b-e45f-43a9-a658-d3f42d2078b5"] =
            "WorldEntities/Doodads/Debris/Wrecks/ExplorableWreck2_clean_atmospherezonetemplate";
        data["20ad299d-ca52-48ef-ac29-c5ec5479e070"] =
            "WorldEntities/Environment/Precursor/Prison/Precursor_Prison_Outpost4";
        data["20b16320-ed22-4d60-8890-93eded9e8e16"] =
            "WorldEntities/Doodads/Coral_reef/coral_reef_Stalactites_cluster_04_01";
        data["20c2703d-ffdf-486f-ba32-d3af9781631f"] = "WorldEntities/Lights/UnderwaterIslands/FloatersSmall";
        data["20e6686f-d5ff-4513-a1e1-e2f15121d007"] =
            "WorldEntities/Environment/Wrecks/ExplorableWreck_KelpForest_18_WeldablePanel1";
        data["2103edc1-7cc0-484a-ade7-79b34af00254"] = "WorldEntities/Food/CookedSpadefish";
        data["210fdf87-54e0-4c83-9bf3-31bbc06f38a6"] = "WorldEntities/Doodads/Coral_reef/coral_reef_plant_small_01_03";
        data["2123161e-09bf-4256-bae0-c17bd2cb3a2b"] = "WorldEntities/Slots/KelpForest/KelpForest_Creature_SandRocky";
        data["21286429-3ae6-46bc-9c06-69e65f6dbf39"] =
            "WorldEntities/Slots/Prison/Aquarium/PrisonAquarium_Loot_CaveWall";
        data["2144c771-8d2d-4908-b1a4-9790ec467e36"] = "WorldEntities/Environment/Cold";
        data["21484999-014a-46b0-b444-f1fde680c655"] = "WorldEntities/Slots/Mountains/Mountains_Loot_Techsite_Small";
        data["214977c9-c4e5-49c6-a32f-f99cb0e0695c"] =
            "WorldEntities/Doodads/Coral_reef/coral_reef_small_deco_12_grass";
        data["21587ad2-c75c-4208-9ea4-c3afd810191f"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/vent_constructor_bend_01";
        data["21588afe-b618-4e15-8bbe-923e32db8afd"] = "WorldEntities/Doodads/Lost_river/lost_river_skull_coral_07";
        data["2160cc96-e1c1-4cfd-8bd9-5e66c745a590"] =
            "WorldEntities/Slots/Prison/Aquarium/PrisonAquarium_Creature_Grass";
        data["216d08fe-2824-4d6e-92cc-705a9c7a2b30"] = "WorldEntities/Natural/GrandReefsEgg";
        data["219c06f2-21f1-4cc7-ba3d-cf4c734483ae"] = "WorldEntities/Slots/LostRiver/GhostTree/GhostTree_Loot_Ground";
        data["21bfce43-12aa-4318-a772-e941c3c86b8d"] =
            "WorldEntities/Slots/MushroomForest/MushroomForest_Creature_MushroomTreeBase";
        data["21c494e6-3688-4d0f-8607-f116b24209ee"] = "WorldEntities/Food/CuredOculus";
        data["21cfd6fe-2f7d-401b-ad26-626fa7a7cce6"] =
            "WorldEntities/Atmosphere/Precursor/EmperorFacility/Precursor_Prison_Moonpool_Atmosphere";
        data["21df8b8f-ae64-4d0e-b838-04f55dd9d72b"] =
            "WorldEntities/Doodads/Coral_reef/Coral_reef_red_seaweed_03_tall";
        data["21e4c817-e3a7-4a0d-a931-0bc68243cb1e"] = "WorldEntities/Fragments/propulsioncannonfragment";
        data["22001838-381d-492d-9f02-aa1233f5a55d"] = "WorldEntities/Tools/RadiationHelmet";
        data["22063314-ff22-4485-b115-b884d26e36b4"] = "WorldEntities/Doodads/Lava/lava_leak_01_04";
        data["2213b907-3231-4c7a-aeaf-03e7c7d349d8"] =
            "WorldEntities/Doodads/Precursor/Cache/IonCrystalPedestal_Cache 1";
        data["221b81d2-8aa6-4dc7-8a30-68305d0db617"] = "WorldEntities/Tools/Grappler";
        data["2224baa1-2f51-48a2-be3b-c7637121195b"] = "WorldEntities/Slots/Dunes/Dunes_Loot_ThermalVent_Rock";
        data["2238c37d-601c-4184-aec0-64a30c419504"] = "Submarine/Build/submarine_steering_console_02_fragments";
        data["2251e1e2-bd05-4182-a859-f0b1e94e89a9"] = "WorldEntities/Slots/KooshZone/KooshZone_Creature_OpenDeep";
        data["228a2cee-6a6a-4c0a-bbc2-a633903619dd"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/biodome_Robot_Arm_wall_start";
        data["228e5af5-a579-4c99-9fb0-04b653f73cd3"] = "WorldEntities/Environment/Coral_reef_floating_stones_small_01";
        data["22b0ce08-61c9-4442-a83d-ba7fb99f26b0"] = "WorldEntities/Food/FilteredWater";
        data["22bf7b03-8154-410b-a6fb-8ba315f68987"] = "WorldEntities/Doodads/Coral_reef/coral_reef_small_deco_15_red";
        data["22c18174-6e54-4f94-8a16-9b08570ce88f"] = "WorldEntities/Doodads/Coral_Decal_01_Projector";
        data["22efb383-4362-45ed-8ced-2347a1397976"] =
            "WorldEntities/Doodads/Lost_river/Lost_river_hanging_plant_03_02";
        data["22fb9ee9-690d-426c-844f-a80e527b5fe6"] = "WorldEntities/Doodads/Precursor/Precursor_gun";
        data["232a8a3e-a501-4148-aa4a-ef6a964cea90"] = "WorldEntities/Environment/Wrecks/EscapePod_7_Cragfield";
        data["232d1968-51c6-4af1-831a-9bb647e91887"] =
            "WorldEntities/Slots/GrandReef/GrandReef_Loot_TechSite_Exterior_Crate_small";
        data["2334eec8-0968-4e0f-8441-25e0f76fc6b6"] =
            "WorldEntities/Doodads/Precursor/precursor_cables_middle_prison_exterior";
        data["233f0235-50b5-4dfe-b5db-a7cdcbeb064e"] =
            "WorldEntities/Environment/AbandonedBases/AbandonedBase PDA/IslandsPDABase1bDesk";
        data["234a33e5-693f-4458-a916-5b1108c33fc2"] = "WorldEntities/Doodads/Coral_reef/Crab_snake_mushrooms_06_03";
        data["2350240a-f039-440b-be51-53b79bc2deea"] =
            "WorldEntities/Environment/LeviathanFacility/Precursor_Prison_EggIncubator";
        data["235f771a-bb5a-4f58-8484-4ad9a6f4e95c"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/vent_constructor_cover_01";
        data["23680ba3-1f93-4ed3-8499-ea67b9f36d66"] =
            "WorldEntities/Slots/MushroomForest/MushroomForest_Loot_GiantTreeInteriorRecess";
        data["237347f9-36ce-4dd4-8a34-f75ccc00fc09"] = "WorldEntities/Environment/Wrecks/ExplorableWreck_Grassy_13";
        data["238f887e-5cfa-4d66-b652-4be27583a4cb"] = "WorldEntities/Environment/Wrecks/ExplorableWreck_KelpForest_18";
        data["23a63afb-dbdd-4b34-b2f8-b423eb8d6f45"] = "WorldEntities/Doodads/Debris/Wrecks/ExplorableWreckRoom01";
        data["23b590fa-f4ac-4eba-a2b7-e10f8c439d07"] = "WorldEntities/Tools/ReinforcedDiveSuit";
        data["23d8c687-d117-4b73-b1ec-ed15359d08e2"] =
            "WorldEntities/Doodads/Coral_reef/Coral_reef_small_blue_fans_01_01";
        data["23d96661-8e2e-4485-9b22-d84707394a0e"] =
            "WorldEntities/Doodads/Precursor/precursor_block_stripe_08_04_09_Gun";
        data["241fc1e4-d045-4462-93dc-d2c8cb91d130"] = "WorldEntities/Atmosphere/Ship/CrashedShip_Interior_ExoPipes";
        data["242b7f63-7553-456b-8d16-b318040097ae"] = "WorldEntities/Doodads/Coral_reef/Coral_reef_green_reeds_01";
        data["24698583-6095-4d8a-b896-898b3ef078c4"] = "WorldEntities/Environment/Kelp Forest/Obstruction_Rock_Small01";
        data["249edffd-6516-4347-93ab-edb295b5bab4"] =
            "WorldEntities/Environment/Wrecks/ExplorableWreck_MushroomForest_9";
        data["24a0621b-6b1a-40fe-ad43-0e95b9d9d4bc"] =
            "WorldEntities/Doodads/Precursor/LostRiverBase/Precursor_LostRiver_BaseInterior";
        data["2515e557-21c3-423e-9cd5-b70a9f6a4e8b"] = "WorldEntities/Tools/Floating_storage_cube";
        data["2517e68c-4f41-4778-b66e-bf8074a0f183"] =
            "WorldEntities/Slots/SafeShallows/SafeShallows_Loot_TechSite_Small";
        data["2519c3f4-5eb1-4e85-9a19-e73477b6259c"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/descent_bar_seat_straight_03";
        data["25522394-6c49-470d-8f48-62f09478aa82"] = "WorldEntities/Tools/Tank";
        data["255ed3c3-1973-40c0-9917-d16dd9a7018d"] =
            "WorldEntities/Environment/AbandonedBases/AbandonedBaseJellyShroom2";
        data["256a06d3-b861-487a-b8ac-050daa0d683d"] =
            "WorldEntities/Environment/AbandonedBases/AbandonedBaseJellyShroom4";
        data["256db677-a0c5-4dc1-aefc-59def4fa4663"] = "WorldEntities/Doodads/Debris/Starship_exploded_debris_26";
        data["258d971e-48b1-4cef-955c-a0222586d0c5"] =
            "WorldEntities/Environment/Precursor/LostRiverBase/Precursor_LostRiverBase_WarperLab";
        data["259506d4-75f7-4391-b847-23abce7b97b9"] = "WorldEntities/Slots/SparseReef/SparseReef_Loot_Techsite_Small";
        data["25adf9c6-8bea-4dd5-baa6-5ede49340aa2"] = "WorldEntities/Atmosphere/Inactive Lavazone/ILZChamber_Dragon";
        data["25be99bf-267a-4598-ab77-95c0af595ab1"] = "WorldEntities/Natural/FloatingStoneMedium1";
        data["25d902a3-7dfa-42b4-b378-8dbb72356bfc"] = "WorldEntities/Seeds/JellyPlantSeed";
        data["26080451-7d22-4822-b0ad-9201e830705f"] = "WorldEntities/Fragments/Old/basebioreactorfragment_old";
        data["2609ad96-9111-44d8-ad80-ee2fc19bef79"] =
            "WorldEntities/Slots/seaTreaderPath/SeaTreaderPath_Creature_Rock";
        data["2613c023-4e16-4989-860d-ce81648f471c"] =
            "WorldEntities/Doodads/Coral_reef/Coral_reef_tree_mushrooms_01_01";
        data["2618af09-411e-4a49-b37b-8424417184a8"] = "WorldEntities/Environment/DisableGlobalWaterVolume";
        data["261edd73-fc6b-46a5-a294-0604b47e3df3"] = "WorldEntities/Atmosphere/CrashZone/CrashZone_Trench";
        data["26363319-0f20-4cb4-8bb5-7a84737064d5"] = "WorldEntities/Natural/drillable/DrillableRock";
        data["26940e53-d3eb-4770-ae99-6ce4335445d3"] = "WorldEntities/Doodads/Coral_reef/coral_reef_small_deco_13";
        data["269dd19e-437d-4bbe-8727-2e239f0603e9"] =
            "WorldEntities/Doodads/Coral_reef/Coral_reef_red_seaweed_02_short";
        data["26a0da27-53a7-4191-82e0-3e2f650a015d"] = "WorldEntities/Slots/KelpForest/KelpForest_Creature_CaveFloor";
        data["26a5d7f4-ac76-4a50-b05e-725d8bbe786b"] = "WorldEntities/Environment/SafeShallowsPDA2";
        data["26cdb865-efbd-403c-8873-92453bcfc935"] = "Submarine/Build/StarshipChair3";
        data["26ce64dd-e703-470d-a0e4-acd43841bdd8"] = "WorldEntities/Slots/BloodKelp/BloodKelp_Loot_Floor";
        data["26d8c91f-3f68-434d-8a45-56c78a4226f7"] = "WorldEntities/Slots/LostRiver/Canyon/Canyon_Creature_Ground";
        data["26db96c3-fc45-4e76-b536-d4e0d07fad5c"] =
            "WorldEntities/Environment/Precursor/Prison/TeleporterRooms/Precursor_Prison_TeleporterRoom_04";
        data["26f5e439-f575-4dbe-9028-27f3a0fb0eca"] =
            "WorldEntities/Doodads/Coral_reef_Light/coral_reef_plant_middle_02_Light";
        data["27486b49-8b28-41d1-bfd1-875fabff0779"] = "WorldEntities/Atmosphere/UnderwaterIslands/IslandCave";
        data["274964eb-b8b0-41f8-947f-f493b342736d"] = "WorldEntities/Slots/KelpForest/KelpForest_Creature_DenseVine";
        data["274bd60f-16c4-4810-911b-c5562fe7c2d8"] = "Submarine/Build/PlanterShelf";
        data["2752d537-465c-4da1-a87d-e9bc2db4f22c"] = "WorldEntities/Environment/SunbeamEventLocalVolume";
        data["275a6441-ed4f-4a1c-bd98-7a9728f8d625"] = "WorldEntities/Doodads/Debris/Starship_exploded_debris_41";
        data["2767b2d8-b9f4-46ef-9ad3-1ba826b0a2ff"] =
            "WorldEntities/Doodads/Lost_river/LostRiverBase/Lost_river_hanging_plant_02_01";
        data["2781e00a-f50d-4905-93c7-ec89bd61de0e"] =
            "WorldEntities/Slots/GrassyPlateaus/GrassyPlateaus_Creature_CaveFloor";
        data["27a51067-e787-4511-b421-7d44640f9a43"] = "WorldEntities/VFX/xLavaSplashes";
        data["27b59918-c41b-4ee0-8bd2-deae81060024"] = "WorldEntities/Doodads/Lava/lava_rock_01_05";
        data["2815cca1-bc1c-46a2-81ef-b11b053aec70"] =
            "WorldEntities/Environment/Wrecks/PDAs/EscapePod_6_PDA_RadiationSuit1";
        data["28220b9d-f7c7-4c63-bf2e-c969145bb6a1"] =
            "WorldEntities/Slots/MushroomForest/MushroomForest_Creature_GiantTreeExteriorBase";
        data["282cdcbc-8670-4f9a-ae1d-9d8a09f9e880"] = "WorldEntities/Doodads/Geometry/RockBlades/RockBlade02";
        data["283267b7-f023-4310-b1b6-99cd24c22afc"] = "WorldEntities/Atmosphere/TreaderPath/Treader_Path_Cave_Tr_Sph";
        data["283409bd-2128-483a-a229-ce86ac6b9cc4"] = "WorldEntities/Slots/KooshZone/KooshZone_Loot_RockWall";
        data["2834aa49-4721-4d4c-9ccf-13fbbd324745"] =
            "WorldEntities/Environment/Precursor/Cache/Precursor_BloodKelpCache_Console";
        data["284573d8-9a80-4867-a09a-85df573c29ef"] = "WorldEntities/Fragments/seamoth_fragment_03";
        data["284ceeb6-b437-4aca-a8bd-d54f336cbef8"] = "WorldEntities/Creatures/HoopFish";
        data["286afd8a-630a-4dd7-aa1e-f95ef9f789aa"] = "WorldEntities/VFX/xLavaSmkColumn_Big_02";
        data["286b44fc-8d89-4c2f-8154-2400624ad259"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/Starship_work_chair_04";
        data["28818d8a-5e50-41f0-8e14-44cb89a0b611"] = "WorldEntities/Doodads/Land/land_plant_small_02_01";
        data["288d2ed8-53a4-480f-9492-d5d05fcc09ae"] = "WorldEntities/Slots/ILZLavaPit/ILZLavaPit_Loot_Floor";
        data["28bed8a7-6d41-4783-bbc4-2243dc2099f7"] = "WorldEntities/Environment/Wrecks/EscapePod_19_SparseReef";
        data["28c73640-a713-424a-91c6-2f5d4672aaea"] = "WorldEntities/Doodads/Land/land_plant_middle_02";
        data["28ec1137-da13-44f3-b76d-bac12ab766d1"] = "WorldEntities/Doodads/Land/land_plant_small_01_01";
        data["28fb4ab7-e1eb-4de3-89a9-98f54394e0f6"] =
            "WorldEntities/Doodads/Coral_reef/Coral_reef_jeweled_disk_green_01_04";
        data["2901ea93-d778-425a-8b34-42dded617cd9"] = "WorldEntities/Fragments/Exosuit_Fragment";
        data["290b2fbd-342c-4c37-a4cf-1414acaf3e33"] =
            "WorldEntities/Slots/UnderwaterIslands/UnderwaterIslands_Loot_IslandTop";
        data["291856e5-9d72-4cc6-b09f-ac09a5a6206e"] =
            "WorldEntities/Doodads/Coral_reef/coral_reef_brown_coral_tubes_01";
        data["2921736c-c898-4213-9615-ea1a72e28178"] =
            "WorldEntities/Environment/AbandonedBases/AbandonedBaseJellyShroom1";
        data["292ba610-ed40-461f-826b-7b2645b37b5f"] = "WorldEntities/Fragments/seamoth_fragment_01";
        data["295c1c89-85c8-4ee0-995a-17db668f4fd9"] = "WorldEntities/Doodads/Lost_river/Lost_river_tree_02";
        data["2963193f-f403-4d0a-b19a-077bc0d53a22"] = "WorldEntities/Natural/FloatingStoneMedium3";
        data["29680106-d337-46ea-a55b-5eb5fd8445f3"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/base_hull_crack_03";
        data["29914c4b-a89c-488b-929d-785b43f9ef2c"] = "Base/Ghosts/BaseCorridorGlassL";
        data["2996a0bf-5faf-468e-8f42-b7cea606ca57"] = "WorldEntities/Slots/Mountains/Mountains_Loot_Sand";
        data["299ee927-82d0-42b8-87e2-558335ccb9c9"] = "WorldEntities/Slots/GrandReef/GrandReef_Loot_TechSite_Barrier";
        data["29ab9e04-a045-413b-886b-e03fa6b86aee"] =
            "WorldEntities/Doodads/Coral_reef/coral_reef_blood_mushrooms_01_02";
        data["29b0ed22-9a16-43be-8d45-3b33a50c2f2d"] =
            "WorldEntities/Environment/SafeShallows/Obstruction_Rock_Small01";
        data["29bcd3d7-48bf-4fd7-955a-23a9523aec47"] = "WorldEntities/Doodads/Lost_river/ReaperSkull";
        data["29bcf57d-4227-4ac7-9adb-e86ba0d2fa82"] =
            "WorldEntities/Doodads/Precursor/Precursor_Interior_Damage_Props_08";
        data["29c0c1f4-0021-42aa-b596-e138f0ca2c86"] =
            "WorldEntities/Atmosphere/LostRiver/BonesField/LostRiver_BonesField_Cave_Pool";
        data["2a257810-206f-42cd-bcd6-de16e4f47829"] = "WorldEntities/Slots/ILZChamber/ILZChamber_Loot_LavaCrevice";
        data["2a275c8d-550f-4b0c-9cbf-88375a18ac15"] = "WorldEntities/Food/CuredHoopfish";
        data["2a347bb2-a20e-4902-a803-4252d9da5c30"] = "WorldEntities/Doodads/Precursor/PrecursorKey_Blue";
        data["2a37dd2f-ee5e-4c3c-a3fe-4f5973055651"] = "WorldEntities/Natural/CreepvineSeedCluster";
        data["2a579d8a-5833-4415-acf9-5d7c4d00c65e"] =
            "WorldEntities/Environment/Precursor/LostRiverBase/Precursor_LostRiverBase_Teleporter_ToPrison";
        data["2a70438f-ecbb-4c2c-9512-848c46b43316"] = "WorldEntities/Environment/Wrecks/exosuitfragment4";
        data["2a7698b9-daa4-43ce-ae48-0f06cc5d476b"] = "WorldEntities/Environment/DataBoxes/CyclopsSonarModuleDataBox";
        data["2a836e22-26fc-4853-98c8-fcb1f639f9ad"] = "WorldEntities/Doodads/Precursor/precursor_block_deco_06_02_06";
        data["2a988b29-caa2-403a-8319-a9c8889345a9"] = "WorldEntities/Doodads/Land/Tallgrass 1";
        data["2aa237f6-2103-4a78-aaa7-104216551f0a"] = "WorldEntities/Environment/Wrecks/life_pod_exploded_3";
        data["2aa6fffa-d353-4210-b1d1-b21fbdf90464"] = "WorldEntities/Environment/Prototype/MediumRock";
        data["2ab96dc4-5201-4a41-aa5c-908f0a9a0da8"] =
            "WorldEntities/Doodads/Coral_reef/Coral_reef_Kelp_blood_small_plants_04";
        data["2ab9f7c4-e4eb-4d1f-a6cd-366d41f85eae"] = "WorldEntities/Doodads/Debris/Wrecks/Decoration/bed_narrow";
        data["2ac73841-95df-4d23-a540-fd035a44d0e6"] =
            "WorldEntities/Slots/LostRiver/GhostTree/GhostTree_Creature_Ground";
        data["2ad19b84-60c1-4719-9c23-1fac4c9d5605"] = "WorldEntities/Food/CuredLavaEyeye";
        data["2ad5aa26-b265-41eb-a350-e7945a95430a"] =
            "WorldEntities/Slots/JellyshroomCaves/Jellyshroom_Creature_CrabSnake";
        data["2ad744bd-d001-4117-a895-7c6863745238"] =
            "WorldEntities/Environment/Precursor/Prison/PipeRoom/Precursor_Prison_PipeRoom_OutgoingPipe5";
        data["2aea1607-0519-44a3-b6c8-ccdf32370fa0"] = "WorldEntities/Doodads/Coral_reef/coral_reef_Stalactite_02_02";
        data["2b0af589-f63d-4f97-9ac0-ea5469712a70"] = "WorldEntities/Lights/LostRiver/Point_Junction_Water_Green_amb";
        data["2b0c5800-87d6-4d0a-8ff9-d2d184abd739"] =
            "WorldEntities/Slots/GrassyPlateaus/GrassyPlateaus_Loot_Techsite_Scatter_Small";
        data["2b1042b8-fc5b-4768-8925-a4382a8bc9c6"] = "WorldEntities/VFX/xOilLeak_medium";
        data["2b24b965-d89b-473c-ae42-24626fe2d425"] = "WorldEntities/Slots/CrashZone/CrashZone_Loot_TrenchRock";
        data["2b313e42-6a26-46e2-98eb-1d56d23cfb92"] = "WorldEntities/Lights/Koosh Zone/Geyser orange light";
        data["2b37ef10-3e60-4bfb-8e19-1ddfb8378b3c"] =
            "WorldEntities/Doodads/Precursor/precursor_block_solid_04_04_08_v2";
        data["2b3be7f1-dd19-4eca-a8c5-519768e1d69f"] =
            "WorldEntities/Slots/GrassyPlateaus/GrassyPlateaus_Creature_CaveEntrance";
        data["2b43dcb7-93b6-4b21-bd76-c362800bedd1"] =
            "WorldEntities/Environment/Precursor/Prison/DissectionRoom/Precursor_Prison_DissectionRoom_Glass";
        data["2b5e9963-2d0e-4002-8652-8c57c4e23167"] = "WorldEntities/Slots/Mountains/Mountains_Loot_Rock";
        data["2b928ace-48fa-428d-8f3d-3d72b8a234b0"] = "WorldEntities/Slots/ILZCastle/ILZCastle_Loot_ChamberWall";
        data["2bbe4cfb-86fa-48f5-9dee-3f6ca7650796"] = "WorldEntities/Environment/Prototype/LavaCube";
        data["2bfcbaf4-1ae6-4628-9816-28a6a26ff340"] =
            "WorldEntities/Doodads/Coral_reef/Coral_reef_Kelp_blood_small_plants_03";
        data["2bfcc0ba-3ea8-4867-8b39-c9f289b7ecd8"] = "WorldEntities/Slots/ILZChamber/ILZChamber_Loot_ChamberCeiling";
        data["2c0635bb-1e62-4b76-8347-d9a1b55e1651"] = "WorldEntities/Doodads/Debris/Wrecks/Decoration/bed_01_immune";
        data["2c11b6b2-c123-43d7-8a2c-4315255333a0"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/SmallLocker_deco";
        data["2c202f90-ad3e-497f-bb1f-31508ec338b9"] = "WorldEntities/Slots/KelpForest/KelpForest_Loot_CaveEntrance";
        data["2c21af26-91a4-4723-b299-99e03e631cc4"] =
            "WorldEntities/Slots/KooshZone/KooshZone_Loot_Techsite_Barrier_Medium";
        data["2c252ff9-4b4e-4759-8fd5-62cf79e7505a"] = "WorldEntities/Food/CuredBladderfish";
        data["2c2d9f88-702b-458b-9ec8-9da1782ded46"] =
            "WorldEntities/Slots/LostRiver/SkeletonCave/SkeletonCave_Creature_Grass";
        data["2c4a802e-a6d4-4280-a803-02fc7555caf1"] = "WorldEntities/Natural/aramidfibers";
        data["2ca1148d-0016-410a-a4a0-fb6bf8833854"] = "WorldEntities/Slots/SparseReef/SparseReef_Loot_Techsite_Medium";
        data["2cab613d-2fc0-4012-ae6e-99f42d4262fd"] = "WorldEntities/Doodads/Land/land_plant_small_01_02";
        data["2cb8def4-3054-44fb-80b2-9ddfa70e3ca7"] = "WorldEntities/Doodads/Coral_reef/Coral_reef_shell_02_01";
        data["2cd64262-7029-4dc2-8fa2-9cd0a025e8fe"] =
            "WorldEntities/Environment/Precursor/Prison/TeleporterRooms/Precursor_Prison_TeleporterTerminal_ToCragField";
        data["2cdffc70-336f-4678-b829-4755311c2048"] =
            "WorldEntities/Environment/AbandonedBases/AbandonedBase PDA/JellyPDAMiniBase";
        data["2cee55bc-6136-47c5-a1ed-14c8f3203856"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/discovery_lab_props_01";
        data["2cfce053-3509-49e0-9e2a-e981436dc9ad"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/Base_interior_Planter_Pot_03_empty_deco";
        data["2d1951c4-49ec-4298-bc1c-b3af75092832"] = "WorldEntities/Environment/Wrecks/exosuitfragment1";
        data["2d3ea578-e4fa-4246-8bc9-ed8e66dec781"] = "WorldEntities/Creatures/HoopFish_02_School";
        data["2d422d6b-3c1f-484d-84ee-a07b5b8e32a4"] =
            "WorldEntities/Doodads/Coral_reef_Light/Coral_reef_sea_crown_Light";
        data["2d61d0b9-0fa7-407e-91ce-468dacce541d"] =
            "WorldEntities/Environment/Precursor/Prison/PipeRoom/Precursor_Prison_PipeRoom_IncomingPipe";
        data["2d649f27-1a73-44bf-919c-2b313c5a7451"] =
            "WorldEntities/Slots/SafeShallows/SafeShallows_Creature_PlateauWallBase";
        data["2d72ad6c-d30d-41be-baa7-0c1dba757b7c"] =
            "WorldEntities/Environment/Precursor/Gun/Precursor_Gun_BeachEntry";
        data["2d7cdc83-c7db-4d19-bb6a-084f18b039ec"] = "WorldEntities/Atmosphere/JellyshroomCaves/Caves";
        data["2d90d46c-592d-4dcc-a803-48ce67287516"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/explorable_wreckage_modular_room_details_11";
        data["2d970c98-6f77-4270-8be2-91dc863d15d5"] =
            "WorldEntities/Doodads/Coral_reef/Coral_reef_jeweled_disk_purple_01_01";
        data["2db600ca-25f7-4000-93a5-f8c2a4ec0387"] =
            "WorldEntities/Doodads/Precursor/LavaBase/Precursor_LavaCastleBase_Drillable_IonCrystalPedestal";
        data["2db757aa-bf0c-433e-8602-98854d640889"] =
            "WorldEntities/Environment/Precursor/LostRiverBase/Precursor_LostRiverBase_BrokenAnchor6";
        data["2dc79b5d-e497-4727-a088-f92ea91b2995"] = "Base/Ghosts/BaseLadder";
        data["2dd42944-a73f-4443-ba90-bf45956e72f0"] = "WorldEntities/Slots/BloodKelp_Cave/BloodKelp_Loot_CaveFloor";
        data["2de0fc33-0386-4b55-84d4-6ad6bffaf74f"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/Starship_work_desk_screen_01";
        data["2e132c67-7be0-4b51-9162-dc8940ac7ecf"] = "WorldEntities/Slots/CrashZone/CrashZone_Loot_Rock";
        data["2e203796-7e60-4f32-a6aa-af42e2c7d77a"] = "WorldEntities/Atmosphere/KooshZone/KooshZoneCaveBiome";
        data["2e3844d4-317d-439e-be1a-f22ff8bbdda2"] = "WorldEntities/Lights/JellyshroomCave/Giant_Mushroom_Light";
        data["2e39e38c-8d3a-4410-9674-bfd779de797e"] =
            "WorldEntities/Slots/UnderwaterIslands/UnderwaterIslands_Creature_OpenDeep";
        data["2e503dd7-6d0e-42b7-b8ea-fc97de717008"] = "WorldEntities/Tools/CyclopsThermalReactorModule";
        data["2e57e9d2-ddda-4063-9540-ca2f0fae775e"] =
            "WorldEntities/Doodads/Coral_reef/Coral_reef_barnacle_suckers_02";
        data["2e58e31f-771e-42fc-9dd2-c0cac3352784"] = "WorldEntities/Atmosphere/MushroomForest/GiantCoralTree_sphere";
        data["2e78d51e-2939-4b3a-90e1-dda362b2acdc"] =
            "WorldEntities/Environment/Precursor/Gun/Precursor_Gun_ControlRoom_ScanDoor_old";
        data["2e9353b8-5c31-4d92-af36-0daa9422f3da"] =
            "WorldEntities/Atmosphere/TreaderPath/Treader_Path_Cave_Dark_Box";
        data["2e9b9389-cfa3-45b1-aee8-ea66b90e841d"] = "WorldEntities/Doodads/Debris/Wrecks/Decoration/Bench_deco";
        data["2eb97d58-829d-4e92-a76a-2974e3547530"] = "WorldEntities/Slots/Ship/Loot_ShipSpecial_ExplodedDebris";
        data["2ed26894-045b-46a3-985e-92278c4dcab2"] = "WorldEntities/Doodads/Land/Fern 04";
        data["2ef10dfb-4228-4415-8919-1c6292ed8fcc"] = "Base/Ghosts/BaseCorridorL";
        data["2ef1bd46-ebf0-459e-a0bf-f941fa94e5d7"] = "WorldEntities/Doodads/Precursor/Gun/IonCrystalPedestal_Small";
        data["2f19d41a-35df-483c-b14b-a848a9c05541"] =
            "WorldEntities/Environment/DataBoxes/CyclopsThermalReactorModuleDataBox";
        data["2f2c944f-96b5-4039-a6b6-841e631e34f6"] =
            "WorldEntities/Environment/Precursor/Prison/TeleporterRooms/Precursor_Prison_Teleporter_ToLostRiver";
        data["2f2d8419-c55b-49ac-9698-ecb431fffed2"] = "Submarine/Build/FiltrationMachine";
        data["2f56b14c-d84c-407e-ad84-eab2df2fc09b"] = "WorldEntities/Doodads/Debris/Starship_exploded_debris_11";
        data["2f734080-71e6-4e63-81d0-0579895c0dbd"] = "WorldEntities/Doodads/Coral_reef/Coral_reef_shell_02_09";
        data["2f7ddbd0-bcb1-41b8-8fcf-ac265640c895"] = "WorldEntities/Slots/CragField/Cragfield_Loot_Ground";
        data["2f90460f-b348-4f49-98b7-6e0611d9239c"] =
            "WorldEntities/Doodads/Precursor/TempGun_Interiors/Precursor_Gun_MoonPool";
        data["2f97d40e-4ca0-44c7-9f8d-2e2111375c66"] =
            "WorldEntities/Doodads/Coral_reef/Coral_reef_barnacle_suckers_03";
        data["2f996953-bd0a-48e2-8aae-57dd6b6a2507"] =
            "WorldEntities/Doodads/Precursor/Precursor_Interior_Damage_Props_11";
        data["2fbb2894-a01a-46b4-8748-e871bf23f646"] = "WorldEntities/Creatures/LavaLizard";
        data["2fc018ae-6dc2-450d-970f-09c0f4bf094d"] = "WorldEntities/Lights/LostRiver/Point_Tree_Cove_Pink_small";
        data["3007c8e8-aeef-4644-ae14-10c08a8e991f"] =
            "WorldEntities/Slots/GrassyPlateaus/GrassyPlateaus_Creature_TowerBigBase";
        data["30189aca-d5b5-4363-8398-11d6a109addb"] = "WorldEntities/Doodads/Fragments/Moon_Pool_fragment_01";
        data["30221413-23f3-49f0-b1bc-db9a5acbfd84"] =
            "WorldEntities/Slots/MushroomForest/MushroomForest_Creature_GiantTreeExterior";
        data["30373750-1292-4034-9797-387cf576d150"] = "WorldEntities/Food/NutrientBlock";
        data["3038bbc0-7d62-44a5-8cbe-c3fa1cccc55e"] =
            "WorldEntities/Doodads/Debris/Wrecks/ExplorableWreckRoom01_aurora";
        data["30530b8d-9408-49aa-a225-1158e3dc45f3"] = "WorldEntities/Doodads/SizeReference";
        data["30590b18-09db-4052-8b36-4231daf09837"] = "WorldEntities/Slots/GrandReef/GrandReef_Loot_PurpleCoral";
        data["306d724e-12ca-45a6-bb35-c42fbafd5a24"] = "WorldEntities/Slots/SafeShallows/SafeShallows_Loot_Plants";
        data["3070f24e-9aba-4655-93a3-d7167acf812d"] =
            "WorldEntities/Doodads/Debris/Aurora/Decoration/Signs/Aurora_Seamoth_Bay1_Sign";
        data["30730b57-d076-4692-bc56-c40bf2aedc13"] = "WorldEntities/Lights/Mushroom Forest/BlueTentacle_light_small";
        data["3076f97a-3e4d-40f6-a737-b9fd3af47552"] = "WorldEntities/Doodads/Coral_reef/coral_reef_small_deco_21_04";
        data["30cf8272-dc8a-4f6e-a7b5-64c65dd2e73c"] =
            "WorldEntities/Atmosphere/Precursor/EmperorFacility/Precursor_Prison_UpperRoom_Atmosphere_LowDetail";
        data["30fb51ee-73b6-4609-8e02-2804201987fb"] = "WorldEntities/Doodads/Debris/Starship_exploded_debris_13";
        data["30fe3c2a-11b8-4a98-9ab0-98239498c564"] = "WorldEntities/VFX/xSteamLeakRandom_small";
        data["31013cc6-24ad-4add-9ad7-42f93ac9bfeb"] =
            "WorldEntities/Environment/Precursor/LostRiverBase/Precursor_LostRiverBase_BrokenAnchor1";
        data["31302e75-dfaa-4d3f-a6c9-6be72ca539e5"] = "WorldEntities/Slots/GrandReef/GrandReef_Loot_RockShallow";
        data["313ead6e-2686-4d68-bd89-99cd990836fd"] = "WorldEntities/Slots/Dunes/Dunes_Loot_Techsite_Barrier_Medium";
        data["314e0fd9-56c5-4f80-9663-15fa077abc15"] = "WorldEntities/Slots/BloodKelp/BloodKelp_Creature_Unique";
        data["314e696f-67bc-4d6c-8ce5-cf9ed7f34746"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/Starship_wires_01";
        data["31632661-2814-4148-bb20-1b0602e71b90"] = "WorldEntities/Environment/Wrecks/tech_light";
        data["31662630-7cba-4583-8456-2fa1c4cc31aa"] = "Submarine/Build/WaterPark";
        data["316705da-ccc6-4ba4-832d-29d49f8db3cf"] = "WorldEntities/Natural/aerogel";
        data["3174e8eb-bdca-4949-ab06-86622d06865f"] =
            "WorldEntities/Doodads/Precursor/Precursor_Prison_EntranceHallway";
        data["31834aae-35ce-49c1-b5ba-ac4227750679"] =
            "WorldEntities/Doodads/Coral_reef/Coral_reef_purple_mushrooms_01_03";
        data["31ccc496-c26b-4ed9-8e86-3334582d8d5b"] =
            "WorldEntities/Doodads/Coral_reef/Coral_reef_blue_barnacles_01_01_breakable";
        data["31d941ee-b00b-437c-abea-c2d42526ba0a"] =
            "WorldEntities/Doodads/Lost_river/Lost_river_hanging_plant_02_02";
        data["31e24eeb-f514-4c33-aa36-7e5b032d4c55"] = "WorldEntities/Doodads/Coral_reef/Crab_snake_Lower_plate_01_01";
        data["31f717b7-b257-4bff-b54b-422bf5008e04"] = "WorldEntities/Doodads/Precursor/Prison/Relics/Alien_relic_11";
        data["31f84eba-d435-438c-a58e-f3f7bae8bfbd"] = "WorldEntities/Doodads/Precursor/precursor_cables_middle_03";
        data["320c9798-9e57-4055-8daa-d73a055c0d28"] = "WorldEntities/Doodads/Coral_reef/coral_reef_plant_middle_01";
        data["32219baf-314f-429b-8327-f492cba760fe"] = "WorldEntities/Doodads/Coral_reef/coral_reef_small_deco_09_big";
        data["3223a0cf-4c89-4718-b0fe-a7c8460a86f1"] = "WorldEntities/Slots/CragField/Cragfield_Creature_Sand";
        data["3265d800-9ae0-478c-973c-ddf5351977c0"] =
            "WorldEntities/Environment/Aurora/Aurora_LivingArea_Bedroom2_Keypad";
        data["3274b205-b153-41b6-9736-f3972e38f0ad"] = "WorldEntities/VFX/xUnderwaterElecSource_aurora_far";
        data["32c8057a-ab28-4405-bcdd-fdf3a2d3cdbe"] = "WorldEntities/Jonas/DummyPlatform";
        data["32d0469d-2452-4e38-919f-2ceeffd034b4"] =
            "WorldEntities/Environment/Precursor/Prison/TeleporterRooms/Precursor_Prison_Teleporter_FromLavaCastleBase_Obsolete";
        data["32e0b9a0-236b-4e03-81cf-921a92ef735d"] =
            "WorldEntities/Atmosphere/LostRiver/TreeCove/LostRiver_TreeCove_Water";
        data["32e48451-8e81-428e-9011-baca82e9cd32"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/docking_clerical_paper7";
        data["32fb101b-b834-4982-a6eb-338ff2f98ea4"] =
            "WorldEntities/Environment/Wrecks/Wrecks_Starship_doors_manual_Aurora";
        data["331741f2-c036-40af-8d84-155fc35e2be8"] =
            "WorldEntities/Slots/ILZChamber/ILZChamber_Loot_CorridorFloor_Far";
        data["3331fe35-7be9-4f59-87ae-9cc54452b136"] =
            "WorldEntities/Doodads/Debris/Aurora/Rooms/CrashedShip_entrance_02_02";
        data["33326895-bab9-4c76-ae29-73b220635f67"] =
            "WorldEntities/Doodads/Coral_reef/Coral_reef_small_blue_fans_small_01_02";
        data["3368afdb-5248-4b4c-8c05-9c0f4c720cee"] = "WorldEntities/Natural/FloatingStone6";
        data["336f276f-9546-40d0-98cb-974994dee3bf"] = "WorldEntities/Environment/Wrecks/poster_exosuit_01";
        data["339d91c3-9203-4c8f-8592-14b72ba7d5cc"] = "WorldEntities/Doodads/Geometry/SafeShallows/Coral_Clump02a";
        data["33acd899-72fe-4a98-85f9-b6811974fbeb"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/biodome_lab_shelf_01";
        data["33c31a89-9d3b-4717-ad26-4cc8106a1f24"] = "WorldEntities/Doodads/Lost_river/Lost_river_rib_04";
        data["33c42808-c360-42b6-954d-5f10d0bffdeb"] = "WorldEntities/Doodads/Lost_river/Lost_river_generic_bone_01";
        data["33c90ac7-eb44-4265-bfed-990893303f4e"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/explorable_wreckage_modular_room_details_17";
        data["33d63e93-e5fd-4911-b7ce-63bf43cc6c95"] =
            "WorldEntities/Environment/Wrecks/battery_charging_station_damaged_base";
        data["33e0d1a0-0b51-4349-9e6c-7ca43df30611"] =
            "WorldEntities/Environment/AbandonedBases/AbandonedBase PDA/IslandsPDABase1Marooned";
        data["33e18dd9-8e50-4e41-9a38-a2681bc10251"] = "WorldEntities/Slots/Dunes/Dunes_Loot_ThermalVent";
        data["3406b655-0390-4ea7-8b75-a5c4705fc568"] = "WorldEntities/Creatures/Bleeder";
        data["344b5156-838c-4054-b9bb-0f065a2488f8"] = "WorldEntities/Eggs/JellyrayEgg";
        data["34601f93-5036-4a7c-81f8-8ccbb9ba731a"] =
            "WorldEntities/Environment/Wrecks/ExplorableWreck_SafeShallows_38";
        data["3460c4a2-f3b6-41d2-814a-3de93534b09e"] = "WorldEntities/Slots/GrassyPlateaus/GrassyPlateaus_Loot_Arch";
        data["34765384-821f-41ad-b716-1b68c507e4f2"] = "WorldEntities/Creatures/ReefbackBaby";
        data["34b00494-3469-4dd9-93f3-2cd00a613edc"] = "WorldEntities/Environment/HeatArea";
        data["34b59c1d-876e-4962-a8f7-e205d189d2be"] =
            "WorldEntities/Doodads/Coral_reef/Coral_reef_jeweled_disk_green_01_01";
        data["34cbf1c2-dd84-48f9-ba0c-46769a5b5159"] = "WorldEntities/Seeds/BluePalmSeed";
        data["34cd5d68-5e30-4751-8233-a2705b7aee9d"] = "WorldEntities/Environment/Wrecks/ExplorableWreck1_Base_0";
        data["34d3f7a1-3516-43c6-99f9-bf4cccc3a30b"] = "WorldEntities/Environment/Wrecks/ExplorableWreck_KelpForest_17";
        data["34fa5064-5338-46d3-a7c1-a0e7ecde0a25"] =
            "WorldEntities/Doodads/Debris/Wrecks/explorable_wreckage_modular_wall_02";
        data["35056c71-5da7-4e73-be60-3c22c5c9e75c"] = "WorldEntities/Doodads/Land/land_plant_middle_05_01";
        data["353e959c-6b73-43de-8b80-8270c120193c"] =
            "WorldEntities/Lights/LostRiver/BonesField/LostRiver_BonesField_Ceiling_Spot2";
        data["354ebf4e-def3-48a6-839d-bf0f478ca915"] = "WorldEntities/Doodads/Debris/Wrecks/Decoration/Starship_cargo";
        data["3556b2cf-f5d7-448f-8443-815128394ee5"] = "WorldEntities/Slots/KelpForest/KelpForest_Loot_CaveFloor";
        data["3556e255-60e0-49bb-bf55-a029608b36a7"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/docking_food_01_tray4";
        data["3561ed08-82f0-4ef7-a1e2-cf11f94aaa17"] = "WorldEntities/Slots/KelpForest/KelpForest_Loot_CaveWall";
        data["3563808f-bca0-43fe-bfd7-d9bc4cfb9370"] = "WorldEntities/Natural/FloatingStone2";
        data["35657a58-4adf-4da9-9058-c4d35f044acb"] =
            "WorldEntities/Slots/SafeShallows/SafeShallows_Loot_PlateauWallBase";
        data["357d0886-f5fb-4883-98e8-c45925b489c3"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/explorable_wreckage_modular_room_details_06";
        data["358012ab-6be8-412d-85ee-263a733c88ba"] =
            "WorldEntities/Doodads/Lost_river/Lost_river_generic_skeleton_03";
        data["3584d354-2499-4846-95b1-be6c446dc6fd"] = "WorldEntities/Doodads/Geometry/SafeShallows/Coral_Clump01b";
        data["35906bd0-cc60-41a2-aee2-0878c43df9e9"] =
            "WorldEntities/Slots/DeepGrandReef/DeepGrandReef_Creature_BlueCoral";
        data["35cd770e-59ed-4592-8b52-ff9f7bab62e8"] = "WorldEntities/Fragments/CyclopsHull_Fragment_Large";
        data["35ee775a-d54c-4e63-a058-95306346d582"] = "WorldEntities/Creatures/SeaTreader";
        data["3616e7f3-5079-443d-85b4-9ad68fcbd924"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/docking_luggage_01_bag4";
        data["361b23ed-58dd-4f45-9c5f-072fa66db88a"] = "WorldEntities/VFX/xSparksElec_1s_Small";
        data["361bea51-183b-4eab-998d-fd61d07d6a65"] =
            "WorldEntities/Doodads/Coral_reef/coral_reef_brown_coral_tubes_02_03";
        data["3648d3a2-127e-45a0-9670-ad4a24c382b1"] = "WorldEntities/Doodads/Coral_reef/coral_reef_grass_04";
        data["3649ee5a-9c6c-4581-9d3d-94de1403de4f"] = "WorldEntities/Slots/KelpForest/KelpForest_Creature_VineBase";
        data["364c6978-6206-4810-91c0-c73530c9acec"] = "WorldEntities/Doodads/Geometry/SafeShallows/Coral_Clump01c";
        data["365c08ca-a623-488e-8f49-21c118abfe21"] = "WorldEntities/Doodads/Lava/lava_plate_01";
        data["3674922a-b937-4684-866b-8b7c875c60b6"] = "WorldEntities/Slots/Prison/Aquarium/PrisonAquarium_Loot_Coral";
        data["367656d6-87d9-42a1-926c-3cf959ea1c85"] = "Submarine/Build/submarine_locker_03";
        data["36bbaa98-7e08-4f74-86f1-5a606c71cecd"] = "WorldEntities/VFX/xLavaSmkColumn_Big_01";
        data["36bbe0f0-8ce5-46b5-8854-209c80e28745"] = "WorldEntities/Fragments/specimenanalyzerfragment";
        data["36c96bd7-86fa-4833-8995-f033190abe26"] = "WorldEntities/Tools/ExosuitThermalReactorModule";
        data["36e85be4-de9a-4438-a538-bc3e5b4e498b"] =
            "WorldEntities/Slots/LostRiver/SkeletonCave/SkeletonCave_Loot_Ceiling";
        data["36eada2e-7fa6-49e2-9808-29cada017294"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/explorable_wreckage_modular_wall_details_04";
        data["36fc8ea4-693f-412e-9f1a-18dee456ace8"] =
            "WorldEntities/Doodads/Debris/Aurora/Decoration/Signs/Aurora_CrewArea_Cabin_06_Sign";
        data["36fcb5c8-07f6-4d20-b026-f8c41b8e2358"] = "WorldEntities/Doodads/Coral_reef/coral_reef_plant_middle_03";
        data["370baf9d-f6d4-4108-bb83-fb3a0d28973c"] = "WorldEntities/Slots/LostRiver/GhostTree/GhostTree_Loot_Wall";
        data["371c2241-7333-4827-a220-39bb4b6686f2"] = "WorldEntities/Atmosphere/SafeShallows/HugeTube (Sphere)";
        data["37462389-11c0-4f0e-b68a-bb5c00ea1437"] =
            "WorldEntities/Slots/FloatingIsland/FloatingIsland_Loot_AbandonedBase_Outside_Medium";
        data["37553c4f-71b6-463d-a28e-c08e6f6a5958"] = "WorldEntities/Slots/SafeShallows/SafeShallows_Loot_CaveRecess";
        data["375a4ade-a7d9-401d-9ecf-08e1dce38d6b"] = "WorldEntities/Doodads/Lost_river/lost_river_plant_04";
        data["3770d41e-6d9d-43f0-986b-e08177cf2720"] = "WorldEntities/Lights/Precursor/Precursor_Cave_Ambient_Large";
        data["37bf8c3e-ece2-4e0e-b112-88eeb0942bdd"] =
            "WorldEntities/Environment/Precursor/LostRiverBase/Precursor_LostRiverBase_Console1_New";
        data["37ea521a-6be4-437c-8ed7-6b453d9218a8"] = "WorldEntities/Environment/FloaterLarge";
        data["37f07c77-ac44-4246-9f53-1d186fb99921"] =
            "WorldEntities/Doodads/Precursor/precursor_cables_middle_01_LavaCastle";
        data["3810601a-53e1-4515-b603-051c5e4c7edc"] =
            "WorldEntities/Environment/Precursor/Gun/Precursor_Gun_ControlRoom_SickScanner_old";
        data["38135f4d-5f31-4438-abce-2c8bbbc5c77c"] = "WorldEntities/Environment/Aurora/Aurora_GenericLab_Keypad";
        data["3816da18-63c6-467e-bd86-1d91a9ddc07c"] = "WorldEntities/Creatures/SeaEmperorBabiesSpawner";
        data["382762c1-4739-4dae-84f3-8ba140274ff2"] =
            "WorldEntities/Slots/Ship/Loot_ShipInterior_LivingArea_Barrier_Small";
        data["383de974-0dba-4702-a322-b74bda0c7c17"] =
            "WorldEntities/Environment/Precursor/Prison/DissectionRoom/Precursor_Prison_DissectionRoom_EmperorBaby";
        data["384b7b62-81dc-4cfe-b908-882f5d9d9f38"] = "WorldEntities/Atmosphere/Dunes/DunesCaveDark20_box";
        data["386deb91-be95-4c09-8dfb-c96c2643c890"] = "WorldEntities/Slots/Ship/Loot_ShipInterior_Lab_Barrier_Small";
        data["386f311e-0d93-44cf-a180-f388820cb35b"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/descent_trashcans_01";
        data["3877d31d-37a5-4c94-8eef-881a500c58bc"] =
            "WorldEntities/Environment/Aurora/Aurora_ExtinguishableFire_Medium";
        data["3894aeaf-e1f9-426a-9249-6a4968ac2d8b"] = "WorldEntities/Environment/Wrecks/life_pod_exploded_19";
        data["38a3c561-d6c9-481b-8eb4-20d8bf6fe839"] =
            "WorldEntities/Atmosphere/Ship/CrashedShip_Interior_Entrance_02_02";
        data["38b1e0d8-d647-4dae-a4ed-52e78977a826"] = "WorldEntities/Environment/DataBoxes/ReinforcedDiveSuitDatabox";
        data["38b89b53-2506-4f90-aaaa-2f0174e6425f"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/submarine_engine_console_01";
        data["38be97b7-d57e-4cc0-8258-ffead8fa7c31"] = "WorldEntities/Atmosphere/MushroomForest/MF_caves_dark_box";
        data["38bfd21a-924d-4c08-87e4-49d88f3b626e"] =
            "WorldEntities/Doodads/Debris/Wrecks/ExplorableWreckRoom04_aurora";
        data["38cdbebf-a4c0-4235-8068-a1f752acee74"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/vent_constructor_section_vertical_01";
        data["38ebd2e5-9dcc-4d7a-ada4-86a22e01191a"] = "WorldEntities/Natural/PrecursorIonCrystal";
        data["38f4a1d4-7cbc-4a21-a953-02b3f667975f"] = "WorldEntities/Environment/Wrecks/ExplorableWreck_Dunes_6";
        data["391f0d6c-c961-4039-a4d6-57b695ab20d3"] =
            "WorldEntities/Lights/LostRiver/Point_Lostriver_pillar_light_large";
        data["3942e6d0-da7a-40a2-b429-297be4da700e"] = "WorldEntities/Atmosphere/BloodKelp/DeepTrench";
        data["394d68dd-8710-49f8-9795-b6d68341c394"] =
            "WorldEntities/Slots/Mountains/Mountains_Loot_Techsite_Barrier_Medium";
        data["3966d5d8-a363-45c1-aa7c-269542a7a39d"] = "WorldEntities/Slots/DeepGrandReef/DeepGrandReef_Loot_Wall";
        data["3981a55f-0754-466a-8932-6e245b4ef846"] = "WorldEntities/Doodads/Debris/Starship_exploded_debris_16";
        data["3a2f4f83-2e56-4a4b-9aad-1cb410e993aa"] =
            "WorldEntities/Doodads/Precursor/Prison/Relics/Precursor_lab_container_relic_01";
        data["3a91dbbb-6e11-4e0c-8370-3aa2b4f06223"] =
            "WorldEntities/Slots/DeepGrandReef/DeepGrandReef_Loot_AbandonedBase_Outside_Small";
        data["3a99ed1b-bedf-4f1b-b9f1-22bedb64b2bd"] =
            "WorldEntities/Slots/LostRiver/Corridor/Corridor_Creature_Water_Floor";
        data["3aa21048-531d-40bc-8e92-846e124762f0"] = "WorldEntities/Slots/GrassyPlateaus/GrassyPlateaus_Loot_Sand";
        data["3ab2094f-cae5-451c-9da1-e719f62c4968"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/Starship_wires_09";
        data["3acb4159-f3a7-4e8e-9e60-d9cf1fc5c248"] =
            "WorldEntities/Slots/LostRiver/BonesField/BonesField_Creature_Corridor_Algae";
        data["3acd2402-0b85-4b94-a408-144e2347aafa"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/Starship_wires_08";
        data["3ad82503-00ac-4b42-9f24-dace1bc23ac1"] = "WorldEntities/Slots/BloodKelp/BloodKelp_Loot_Wall";
        data["3adf441d-01f9-4d35-a3c2-2423c0769be5"] = "WorldEntities/Fragments/Workbench_Fragment";
        data["3b0f9b04-a22f-45f5-a2bd-d098adfb3e7b"] = "WorldEntities/VFX/xLavaSplashes_15x15";
        data["3b332e41-8d1b-4c7d-a132-3c98ab41c63d"] = "WorldEntities/Doodads/Land/land_plant_middle_07";
        data["3b354a10-f24c-43f6-ba92-759b455546c6"] = "WorldEntities/Atmosphere/MushroomForest/Caves (Sphere)";
        data["3b52098a-4b58-467c-a29a-1d1b6d92ec3e"] = "WorldEntities/Natural/uraninitecrystal";
        data["3b633f18-159c-438d-979b-42ca135b0e45"] = "WorldEntities/Environment/Wrecks/PDAs/Wreck11_GrandReef_PDA2";
        data["3b9af4ab-7a5c-4a8e-a2ba-78212e703a5c"] =
            "WorldEntities/Slots/SafeShallows/SafeShallows_Creature_UniqueCreatureCave";
        data["3bb9488b-251f-4f50-af32-1e05b7db32c9"] = "Submarine/Build/BatteryCharger";
        data["3bbf8830-e34f-43a1-bbb3-743c7e6860ac"] = "WorldEntities/Doodads/Precursor/precursor_deco_props_02";
        data["3bc0b7a6-ec25-4662-9f35-af6a4d3d2c65"] =
            "WorldEntities/Slots/JellyshroomCaves/Jellyshroom_Loot_AbandonedBase_Inside_Medium";
        data["3bc112ae-c4b6-440a-ad0c-547c71ec1614"] = "WorldEntities/Slots/ILZChamber/ILZChamber_Creature_LavaCrevice";
        data["3bc7707a-8525-4846-81ff-3ac0713efa10"] = "WorldEntities/Natural/SupplyCrate_Signal";
        data["3bd81d87-52b2-486f-86fc-79ac49899348"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/Base_interior_wall_planter_leaves_01";
        data["3beb5782-3665-4056-a05a-2edf8b60048d"] =
            "WorldEntities/Environment/DataBoxes/CreatureDecoyDataBoxSpawner";
        data["3beeed3e-af09-4d62-9ff5-99392da9ba1f"] = "WorldEntities/Environment/Wrecks/PDAs/EscapePod_17_PDA_Seamoth";
        data["3c056089-bb4e-4967-987a-83d83fd97cbe"] = "WorldEntities/Atmosphere/KooshZone/KooshZoneBiome_box";
        data["3c076458-505e-4683-90c1-34c1f7939a0f"] = "WorldEntities/Environment/Wrecks/cyclopsenginefragment1";
        data["3c12b4b9-018f-45a3-95bf-7b4770b744a1"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/biodome_Robot_Arm_wall_tile";
        data["3c13b3a4-ac02-4601-8030-b9d7482cde1e"] = "WorldEntities/Creatures/Gasopod";
        data["3c2426ba-bff1-4390-bd24-8b34227973e0"] = "WorldEntities/Slots/LostRiver/BonesField/BonesField_Loot_Wall";
        data["3c386af2-9e87-4c8b-b5f3-da8ef107493b"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/Starship_wires_10";
        data["3c39f7ca-663f-49d7-b6c5-818463e1056d"] =
            "WorldEntities/Environment/Wrecks/ExplorableWreck_SafeShallows_15_WeldablePanel";
        data["3c4a120b-13c1-4478-afdf-5ecdd0a825e1"] =
            "WorldEntities/Atmosphere/LostRiver/BonesField/LostRiver_BonesField_LakeBorderFading";
        data["3c5abaf7-b18e-4835-8282-874763343d57"] = "WorldEntities/Doodads/Precursor/Prison/Relics/Alien_relic_06";
        data["3c5ae824-16fc-4e49-ac8b-23b26991baf0"] =
            "WorldEntities/Environment/DataBoxes/CyclopsThermalReactorModuleDataBoxSpawner";
        data["3c5bd4db-953d-4d23-92be-f5a3b76b2e25"] = "WorldEntities/Natural/gold";
        data["3c9344a2-4715-4773-9c58-dc0437002278"] =
            "WorldEntities/Doodads/Precursor/precursor_block_deco_08_04_08_v4";
        data["3ca45d4c-4f45-4a65-b5f3-904ccd1f1f93"] =
            "WorldEntities/Environment/Precursor/LavaCastleBase/Precursor_LavaCastleBase_KeyTerminal_old";
        data["3caf2f09-9cb2-4b9e-9432-6481f83fde4c"] = "WorldEntities/Eggs/MesmerEgg";
        data["3cb1a93f-3650-4259-b0cb-0b179a9bfec6"] =
            "WorldEntities/Doodads/Precursor/LavaBase/Precursor_LavaCastleBase_Flat_Animated_4segment";
        data["3cd6459f-c245-44bc-8c44-8a4c5a94330c"] =
            "WorldEntities/Environment/Precursor/Prison/PipeRoom/Precursor_Prison_PipeRoom";
        data["3cdd8a3a-49fa-4384-9594-782ef1df7f79"] = "WorldEntities/Atmosphere/MushroomForest/MF_caves_dark_sph";
        data["3cf41a48-463a-4589-9a57-e97d19913763"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/PictureFrame_deco";
        data["3cf87a6b-261c-47b9-aae7-e011eaf78c30"] = "WorldEntities/Doodads/Coral_reef/CoralChunk";
        data["3d00dfb5-a002-4df0-8e20-d4aa48d796d6"] = "WorldEntities/Doodads/Coral_reef/Coral_reef_shell_02_04";
        data["3d084c9a-09ea-46b6-85a1-0ea6759fce57"] =
            "WorldEntities/Environment/Precursor/Prison/TeleporterRooms/Precursor_Prison_Teleporter_ToCragField";
        data["3d17d490-9c2a-4705-8e49-6240de1ca915"] =
            "WorldEntities/Atmosphere/Mountains/Mountains_IslandCaveEntrance_Surface_sph";
        data["3d31db70-bfa5-41a8-b372-92a15056644f"] =
            "WorldEntities/Slots/UnderwaterIslands/UnderwaterIslands_Creature_ValleyFloor";
        data["3d33c995-3b01-447f-a624-c30d36154649"] =
            "WorldEntities/Environment/DataBoxes/CyclopsFireSuppressionModuleDataboxSpawner";
        data["3d4c323b-e664-42d2-9c02-0b55481760dd"] = "WorldEntities/Environment/Wrecks/ExplorableWreck_BloodKelp_8";
        data["3d4d3892-e43a-45b1-85b8-4a6462257c79"] =
            "WorldEntities/Doodads/Coral_reef/Coral_reef_jeweled_disk_blue_01_04";
        data["3d5f29de-9b79-421f-9d71-1ca16a3ffb5f"] = "WorldEntities/Doodads/Debris/Wrecks/ExplorableWreck1_clean";
        data["3d625dbb-d15a-4351-bca0-0a0526f01e6e"] =
            "WorldEntities/Environment/Precursor/Gun/Precursor_Gun_ControlRoom_CentralColumn";
        data["3d66864c-16f3-4ae6-b953-9122c575c2ef"] =
            "WorldEntities/Environment/DataBoxes/CyclopsHullModuleDataboxSpawner";
        data["3dbab1b9-cc52-4da4-8633-89b33add18f4"] =
            "WorldEntities/Doodads/Coral_reef/Coral_reef_purple_tentacle_plant_01_02";
        data["3dbe5ecd-0c60-46f5-a310-506817b02670"] = "WorldEntities/Doodads/Coral_reef/Coral_reef_small_deco_06";
        data["3dc40631-2945-4109-acdc-823a9a0a8646"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/descent_plaza_shelf_cap_03";
        data["3ddc848b-082b-46ed-9031-a7060de92f2a"] = "WorldEntities/Slots/Dunes/Dunes_Creature_ThermalVent_Rock";
        data["3dde0891-5ff1-4651-a8cf-8573ad422e96"] = "WorldEntities/Slots/BloodKelp_Cave/BloodKelp_Loot_CaveCeiling";
        data["3e09729a-2c2d-4b93-9089-c62d82963ef3"] = "WorldEntities/Fragments/PowerCellCharger_Fragment";
        data["3e0a11f1-e2b2-4c4f-9a8e-0b0a77dcc065"] = "WorldEntities/Creatures/CaveCrawler";
        data["3e12dd0a-615f-4d04-8bb2-4c1d134831da"] =
            "WorldEntities/Environment/Precursor/Gun/Precursor_Gun_MoonPoolOceanEntry";
        data["3e199d12-2d75-4c58-a819-d78beeb24e2c"] = "WorldEntities/Doodads/Coral_reef/Crab_snake_mushrooms_05_small";
        data["3e24c1a5-8098-490f-8b6b-c34372b645f6"] = "WorldEntities/Slots/GrandReef/GrandReef_Loot_TreaderPath";
        data["3e2d23dd-7a47-4249-8090-9143cfed045c"] =
            "WorldEntities/Slots/GrandReef/GrandReef_Loot_TechSite_Scatter_Medium";
        data["3e4f0d4d-e8c9-4053-bada-980f442d50d1"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/circuit_box_01_02";
        data["3e581d94-c873-4ad7-a2f4-a35ec6ac3ecb"] = "WorldEntities/Doodads/Geometry/SafeShallows/Rock_Small01";
        data["3e8d98be-dc80-4173-9252-37d52836450e"] =
            "WorldEntities/Slots/JellyshroomCaves/Jellyshroom_Loot_Jellyshroom";
        data["3e9ab933-2f9c-45c7-9c2b-3c630576d8d4"] =
            "WorldEntities/Atmosphere/LostRiver/GhostTree/LostRiver_GhostTree_Lake_Loot";
        data["3eba5a45-624a-4d5b-9a4b-0c3bad357a96"] = "WorldEntities/Doodads/Geometry/SafeShallows/Coral_Clump02c";
        data["3ebb4c67-cec3-4f92-ada5-7e1eccb2db85"] =
            "WorldEntities/Slots/MushroomForest/MushroomForest_Creature_GiantTreeInteriorPlants";
        data["3ebe8283-5db0-42b3-a337-9f48020d7076"] = "WorldEntities/Environment/Aurora/PDAs/Aurora_CargoRoom_PDA1";
        data["3ee9a5e5-b855-4b1c-97f6-f4f746ac457c"] =
            "WorldEntities/Atmosphere/LostRiver/BonesField/LostRiver_BonesField_Corridor_StreamFading";
        data["3ef553cf-588c-4ae7-acc3-879f482b767f"] =
            "WorldEntities/Doodads/Coral_reef/Coral_reef_blue_barnacles_01_cluster_02";
        data["3f045eb4-2b49-4aaf-95af-ce91a8f457f3"] =
            "WorldEntities/Atmosphere/LostRiver/GhostTree/LostRiver_GhostTree_Lake";
        data["3f2ae32f-9f80-4dee-af72-2cca5569145c"] =
            "WorldEntities/Environment/Precursor/LostRiverBase/Precursor_LostRiverBase_BrokenAnchor2";
        data["3f2f7e2e-a153-41fc-86bb-c71f2872f524"] =
            "WorldEntities/Slots/seaTreaderPath/SeaTreaderPath_Creature_OpenDeep";
        data["3f88d6ce-a173-49e4-9fb2-53a418fd48f1"] = "WorldEntities/Fragments/Old/KooshZoneFragment";
        data["3f9ee5c6-ac92-43ec-9ae0-b1e6b263e7e2"] = "WorldEntities/Natural/StalkerTooth";
        data["3fa8f191-0eff-456d-bed4-e822094d0921"] = "WorldEntities/Slots/ILZCastle/ILZCastle_Creature_TunnelOpen";
        data["3fba3094-2c41-4f54-81ab-d13e66d42c8c"] = "WorldEntities/Creatures/Unused/TestDrone";
        data["3fbdcee0-a86a-494c-92a9-97499014cde6"] =
            "WorldEntities/Slots/UnderwaterIslands/UnderwaterIslands_Creature_IslandPlants";
        data["3fcd548b-781f-46ba-b076-7412608deeef"] = "WorldEntities/Creatures/Peeper";
        data["3fd9050b-4baf-4a78-a883-e774c648887c"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/discovery_lab_props_03";
        data["3fe6c5a7-25aa-4375-bd99-bb7713ec7e6a"] =
            "WorldEntities/Slots/UnderwaterIslands/UnderwaterIslands_Loot_Techsite_Barrier_Small";
        data["400fa668-152d-4b81-ad8f-a3cef16efed8"] = "WorldEntities/Doodads/Coral_reef/Crab_snake_mushrooms_02";
        data["4021307d-b4d1-4a7d-bf3a-078ff2202aee"] = "WorldEntities/Natural/FiberMesh";
        data["4025fa63-e6bd-4619-ab54-03c3825fd7ca"] = "WorldEntities/Lights/LavaZone/Inactive/Point_Lava_Large_River";
        data["402d43d3-56d6-4c59-993d-6c92cd07feb3"] = "WorldEntities/Doodads/Debris/Wrecks/Decoration/DecoPlanterBox";
        data["403b8d2f-b009-483d-8358-bfcde62daa42"] = "WorldEntities/Environment/Wrecks/Nuclear_reactor_damaged_01";
        data["4064a71a-c464-4db2-942a-56391fe69951"] = "WorldEntities/Creatures/Biter";
        data["4072945b-696d-487d-afcb-c1f767dceed1"] = "WorldEntities/Slots/KelpForest/KelpForest_Loot_EscapePod_Small";
        data["407e40cf-69f2-4412-8ab6-45faac5c4ea2"] = "WorldEntities/VFX/x_LavaCastleSmokeColumn";
        data["40899ee4-018b-43fa-aaf1-70663d7e38fe"] =
            "WorldEntities/Environment/AbandonedBases/AbandonedBase PDA/JellyPDABrokenCorridor";
        data["4092b00d-466d-4592-85f7-023ad4e87d9a"] = "WorldEntities/Fragments/Old/bioreactorfragment";
        data["409f6f77-4fcd-4c4c-b6e6-cf4ca1ca4e9d"] =
            "WorldEntities/Doodads/Coral_reef/coral_reef_Stalactites_cluster_03_02";
        data["40cb0ae5-de47-4b18-9d1c-e572253afef4"] = "WorldEntities/Doodads/Debris/Starship_exploded_debris_18";
        data["40e2a610-19dc-4ae8-b0c1-816230ab1ce3"] = "WorldEntities/Doodads/Debris/Wrecks/Decoration/VendingMachine";
        data["40f365a3-cab6-476a-bc5e-066123471e03"] =
            "WorldEntities/Doodads/Lost_river/LostRiverBase/Lost_river_hanging_plant_03_02";
        data["40fed71c-2ced-4849-b52f-459865a5d613"] = "WorldEntities/Atmosphere/SafeShallows/Normal";
        data["411e144a-d73b-432c-8c5a-facf18aa6db3"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/descent_bar_sofa_str_02";
        data["41305d7c-e47d-4627-83ff-75c0111d3f18"] =
            "WorldEntities/Environment/Precursor/Precursor_OrangeKeyTerminal";
        data["4130f650-bfa6-4d2f-9f5f-6f79f6649ca4"] =
            "WorldEntities/Environment/Precursor/Prison/EggLab/Precursor_Prison_EggLab_Hallway";
        data["413885d8-1f9f-4940-b12d-0dfcdaeaddb7"] = "WorldEntities/Slots/SparseReef/SparseReef_Loot_CaveCoral";
        data["41399588-124d-4e01-92b7-f5b10c882ac8"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/docking_bar_bottle_05";
        data["41406e76-4b4c-4072-86f8-f5b8e6523b73"] = "WorldEntities/Natural/drillable/DrillablePrecursorIonCrystal";
        data["415feea9-8ca4-4ee9-a701-dba7143ad3a2"] =
            "WorldEntities/Slots/LostRiver/GhostTree/GhostTree_Creature_Skeleton_Open";
        data["41919ae1-1471-4841-a524-705feb9c2d20"] = "WorldEntities/Natural/TitaniumIngot";
        data["41a08c65-ad37-4095-bd48-a8025fe4d016"] =
            "WorldEntities/Doodads/Lost_river/lost_river_canyon_bottom_root_02";
        data["41b65694-17a6-4ba7-8b99-a8e733694afd"] = "WorldEntities/DummyWorldEntity";
        data["41bdc366-f386-42f9-a3ab-8dfa88e5b6cb"] = "WorldEntities/Slots/ILZLavaPit/ILZLavaPit_Creature_Open";
        data["41e9c89b-9dea-4054-a59a-38ccb4cde0a6"] =
            "WorldEntities/Slots/Prison/Aquarium/PrisonAquarium_Creature_CaveWall";
        data["420671a1-d03b-4100-b0f7-fde526ff852b"] = "WorldEntities/Atmosphere/BloodKelpTwo/Cave";
        data["422b14d3-69c6-43c9-8ceb-84d29f5c3a8b"] = "WorldEntities/Tools/SeaGlide";
        data["423a8e49-eabe-473b-9b45-4aa52de1596f"] = "WorldEntities/Creatures/LavaLarva";
        data["423ab63d-38e0-4dd8-ab8d-fcd6c9ff0759"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/Starship_cargo_damaged_large_02";
        data["4253e186-fa5a-4035-a258-7ca99c461dbe"] =
            "WorldEntities/Lights/LostRiver/BonesField/LostRiver_BonesField_Lake_Light_Medium";
        data["427c6033-a3b2-4c0f-bbca-a7c26a909849"] =
            "WorldEntities/Environment/Wrecks/ExplorableWreck_SafeShallows_15";
        data["42a0a468-6b94-4fe7-85b9-f6e8b068c550"] =
            "WorldEntities/Doodads/Precursor/TempGun_Interiors/Precursor_Gun_TerminalRoom_02_Lights";
        data["42a80cbc-d9fd-49d2-94b3-b5178024b3cb"] =
            "WorldEntities/Environment/AbandonedBases/DeepGrandReefAbandonedBase";
        data["42b38968-bd3a-4bfd-9d93-17078d161b29"] = "WorldEntities/Environment/CurrentSmall";
        data["42cac266-525a-4a89-9c11-89fd923faf86"] =
            "WorldEntities/Doodads/Debris/Aurora/Rooms/CrashedShip_elevator_room";
        data["42e1ac56-6fab-4a9f-95d9-eec5707fe62b"] = "WorldEntities/Doodads/Lost_river/Lost_river_generic_bone_07";
        data["42eae67f-f31a-45a0-95bf-27e189de65a0"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/biodome_lab_counter_01_cab1";
        data["4300b116-0d44-4925-9230-b20cf3e4c4fe"] = "WorldEntities/Natural/SafeShallowsEgg";
        data["430b36ae-94f3-4289-91ac-25475ad3bf74"] =
            "WorldEntities/Environment/Precursor/Prison/Precursor_Prison_Outpost5";
        data["4322ded1-04ba-44eb-afe5-44b9c4112c64"] = "WorldEntities/Doodads/Debris/Starship_exploded_debris_05";
        data["433f2a42-ad16-41be-8c7b-af4a98a8b3a2"] =
            "WorldEntities/Slots/GrassyPlateaus/GrassyPlateaus_Creature_UniqueCreature";
        data["437229b1-9be7-4fef-93df-12ca315698f1"] =
            "WorldEntities/Atmosphere/Precursor/Gun/Precursor_Gun_ControlRoom_Atmosphere";
        data["439b4b17-2f86-4706-8abd-8d2f68df782b"] = "WorldEntities/Natural/silver";
        data["43a597df-da05-4f5f-92df-29d76c0b2f53"] = "WorldEntities/Doodads/Coral_reef/Coral_reef_green_reeds_05";
        data["43ba333e-2eb6-4b6f-ac74-6b6188e82297"] = "WorldEntities/Eggs/BonesharkEgg";
        data["43c0cea5-fb82-4acf-815a-965d84ed9e37"] = "WorldEntities/Fragments/Old/cyclopsenginefragment_old";
        data["43c94854-300a-4c1f-a3ce-3a5106fcac4c"] = "WorldEntities/Doodads/Debris/Wrecks/Decoration/shelve_02";
        data["43dab3f0-ca6f-4edd-a856-2daf5e49abf5"] = "WorldEntities/Slots/MushroomForest/MushroomForest_Loot_Grass";
        data["43fe5e2b-4ce4-48fd-ac80-8749a9b71e06"] =
            "WorldEntities/Slots/MushroomForest/MushroomForest_Loot_RockWall";
        data["4402bbed-9d63-4560-9e65-44707771394a"] = "WorldEntities/Natural/FloatingStoneSmall4";
        data["4404f4f2-3d65-4338-adb3-a1a2e1f8fac5"] = "WorldEntities/Doodads/Lost_river/Lost_river_rib_01";
        data["441294d5-f4b4-4974-b4d8-1a4d5771fa90"] = "WorldEntities/Tools/SeamothPowerUpgradeModule";
        data["44396d05-0910-4b4d-a046-119fab3512a5"] = "WorldEntities/Natural/FloatingStone7_Floaters";
        data["44910b73-ef96-43f4-86be-4674f7b40c18"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/descent_bar_sofa_str_03";
        data["44974fcd-c47a-41aa-a279-43eaf234bfa6"] =
            "WorldEntities/Environment/Precursor/Prison/DissectionRoom/Precursor_Prison_DissectionRoom_EmperorTank";
        data["449f060e-1f82-4efa-a5e8-c4145a851a8f"] = "WorldEntities/Creatures/Unused/BloodGrass";
        data["44d49e2d-37ab-47b1-9f1d-bb63d16ccfbb"] = "WorldEntities/Environment/Wrecks/exosuitfragment3";
        data["450bf7b5-b6cf-4139-921f-3cb9ea505d5f"] =
            "WorldEntities/Doodads/Coral_reef/coral_reef_small_deco_15_yellow";
        data["451f3437-0f15-417d-afc8-4cdf2fe79193"] =
            "WorldEntities/Slots/BloodKelp_DeepTrench/BloodKelp_Loot_TrenchRoots";
        data["4523f853-704d-4d4f-acde-a1b5e5cef18d"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/explorable_wreckage_modular_room_details_20";
        data["4525e0f3-9c9a-449f-8d6c-48088711ac99"] = "WorldEntities/Doodads/Coral_reef/coral_reef_plant_middle_04";
        data["45510933-8c98-4f65-8a56-f6566bcfb96b"] =
            "WorldEntities/Atmosphere/Ship/CrashedShip_Interior_Entrance_02_01";
        data["45799161-25fd-458b-8420-83d2e06de0d3"] = "WorldEntities/Doodads/Precursor/Prison/Relics/Alien_relic_05";
        data["45838264-9d28-4fc3-9223-d37f6762d882"] = "WorldEntities/Lights/Koosh Zone/KooshCave_green_amb";
        data["4594f9c0-1b4d-4b10-871d-53950de686fb"] = "WorldEntities/Natural/FloatingStone8";
        data["459db0a9-4480-4e2a-b0a6-b6e7708119bd"] = "WorldEntities/Tools/CyclopsDecoyModule";
        data["45a2c0fd-c56d-4946-8234-f48716a34718"] = "WorldEntities/Food/Snack3";
        data["45af7cd6-36a9-4ced-a7b9-2b522022f2c8"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/docking_clerical_card1";
        data["45d57417-b1a9-48c9-8ade-e7258602e972"] = "WorldEntities/Slots/KooshZone/KooshZone_Loot_CaveSpecial";
        data["45e168ee-3d68-4147-bc82-fba859a3dd2b"] =
            "WorldEntities/Environment/AbandonedBases/AbandonedBase PDA/DeepPDA4";
        data["45eee993-3201-4b64-a44d-7348c3217637"] = "WorldEntities/Environment/Prototype/Lavapole";
        data["45f27c22-a33b-4dfe-8044-cad59d514a3e"] = "WorldEntities/Environment/Wrecks/EscapePod_12_KooshZone";
        data["4601400c-5e12-4e4a-9e45-4cab5f06a598"] = "WorldEntities/Doodads/Coral_reef/coral_reef_plant_middle_10";
        data["4605151e-dea4-4ba7-96bf-2f88b3b41bdb"] = "WorldEntities/Doodads/Debris/Wrecks/Decoration/starfish_02";
        data["460af7c1-a0b7-4048-8ef7-a8ca36f0f899"] =
            "WorldEntities/Slots/LostRiver/GhostTree/GhostTree_Creature_Open_Big";
        data["461487ff-aea5-426e-b473-a378dca662b9"] = "WorldEntities/Doodads/Coral_reef/Coral_reef_Kelp_blood_04";
        data["4626f3eb-23c3-4e04-b9df-829cb051758a"] = "WorldEntities/Doodads/Land/land_plant_middle_01";
        data["46271d4e-dcab-4210-abce-04cf1b248464"] =
            "WorldEntities/Environment/Precursor/Precursor_TeleporterStand_ForceField";
        data["463e0571-9599-4d74-81dc-fc7932004554"] = "WorldEntities/Doodads/Coral_reef/Crab_snake_mushrooms_06_05";
        data["4665b512-b098-4dbb-a2ce-ecf30f268ea0"] =
            "WorldEntities/Atmosphere/MushroomForest/MushroomForestBiome_Sphere";
        data["466ee336-aaf0-4142-bff2-8625df5a5b90"] =
            "WorldEntities/Environment/LostRiver/LostRiver_Tree_Cove_Waterfall";
        data["468ed44c-90c7-4691-8c48-8752326e255f"] = "WorldEntities/Tools/PowerGlide";
        data["4698f370-fb13-40b3-a0b4-596edc047b52"] = "WorldEntities/Environment/Wrecks/ExplorableWreck_Dunes_a1";
        data["46b48d31-b605-414d-af3e-e2f24e629e54"] = "WorldEntities/Slots/Ship/Loot_ShipInterior_Platform";
        data["46b8924c-ed31-4770-9a17-8f1863d50840"] =
            "WorldEntities/Doodads/Debris/Aurora/Decoration/Signs/Aurora_THallway_Airlocks_Sign";
        data["46d0473e-d366-4644-8c9c-5fdb65cbacb8"] =
            "WorldEntities/Doodads/Coral_reef/coral_reef_Hanging_Stinger_middle";
        data["46eba0de-7d79-40b9-a5e5-969a84f44f4c"] = "WorldEntities/Doodads/Coral_reef/Coral_reef_small_deco_05";
        data["47027cf0-dca8-4040-94bd-7e20ae1ca086"] =
            "WorldEntities/Environment/Precursor/LavaCastleBase/Precursor_LavaCastleBase_IonBattery_DoorTerminalRoot";
        data["47054a31-5a0b-455d-a35b-0344fb723bec"] = "WorldEntities/Slots/CrashZone/CrashZone_Creature_OpenShallow";
        data["471852d4-03b6-4c47-9d4e-2ae893d63ff7"] = "WorldEntities/Natural/WiringKit";
        data["47294127-6289-4a2a-9ddf-22cdbb13723f"] =
            "WorldEntities/Doodads/Lost_river/LostRiverBase/Lost_river_hanging_plant_04_02";
        data["472c6412-a6b3-48c7-bc0b-57e0c7469f09"] = "WorldEntities/Eggs/CrabSquidEgg";
        data["4732d0e2-e208-4371-bd98-6747582329d7"] = "WorldEntities/Natural/FloatingStone1";
        data["473a8c4d-162f-4575-bbef-16c1c97d1e9d"] =
            "WorldEntities/Doodads/Precursor/Precursor_prison_exterior_box_01_animated_blue";
        data["47716ca0-0109-44b2-9c88-79a26c259d8c"] =
            "WorldEntities/Doodads/Lost_river/lost_river_skull_coral_group_03";
        data["478638da-6686-4d2a-b5d3-7d8af145ffdb"] =
            "WorldEntities/Environment/Precursor_Gun_MoonPool_DisableGlobalWaterVolume";
        data["478aa6d3-3814-4a81-bcbe-27003e15ab21"] =
            "WorldEntities/Slots/UnderwaterIslands/UnderwaterIslands_Creature_ValleyWall";
        data["47c32ae8-b168-4ddf-bbae-7467038e3457"] = "WorldEntities/Environment/Wrecks/Thermal_reactor_damaged_03";
        data["47ca9b30-9bf2-4956-8f30-2407567496ac"] = "WorldEntities/Fragments/reinforcehullfragment";
        data["47cad2e1-73ad-4d08-961b-61061e803370"] = "Submarine/Build/MuyskermHullPlate";
        data["47d72893-026b-488b-95b6-83fb002ea40a"] = "WorldEntities/Unused/CurrentGenerator";
        data["480b5570-8c07-4180-a284-45d2a9a8d152"] = "WorldEntities/Slots/ILZChamber/ILZChamber_Loot_ChamberFloor";
        data["48225ddf-5683-4f69-bdcb-b13067a7f27d"] = "WorldEntities/Slots/GrandReef/GrandReef_Creature_Ground";
        data["482d6e66-c240-493e-ad8e-e32cf33e9331"] = "WorldEntities/Slots/Ship/Loot_ShipInterior_Lab_Small";
        data["4838692b-b93f-4b1f-9d58-11bee5382fc7"] =
            "WorldEntities/Doodads/Coral_reef/coral_reef_Stalactites_cluster_02_03";
        data["484cbbf2-7a37-44c3-8b10-6a3592801c18"] =
            "WorldEntities/Slots/LostRiver/BonesField/BonesField_Loot_Corridor_Stream";
        data["485196ae-a0a0-44a1-9b3e-dabf708ea724"] = "WorldEntities/Fragments/moonpoolfragment";
        data["4856ff40-43d2-4b15-acdc-d6a45f85c157"] = "WorldEntities/Doodads/Coral_reef/coral_reef_plant_middle_12";
        data["4858f3de-00e1-442d-82e9-f4689d5b373f"] = "WorldEntities/Doodads/Land/Land_grass_02";
        data["48841974-38e1-4b53-9386-91c8ef0463f7"] = "WorldEntities/Slots/SafeShallows/SafeShallows_Loot_CavePlants";
        data["4884bcfd-3650-40a8-83f1-708f0f1f40e1"] = "WorldEntities/Slots/Mesa/Mesa_Creature_Open";
        data["48a0ba2e-0526-4826-a634-bcbe5efe61dc"] = "WorldEntities/Atmosphere/SparseReef/Wreck";
        data["48a5564b-e632-4666-9e7c-f377fbc4fd23"] = "WorldEntities/Environment/Aurora/Aurora_CargoRoom_Keypad";
        data["48d6184a-320e-41d2-abca-5b96a94e72e0"] =
            "WorldEntities/Doodads/Coral_reef/Coral_reef_jeweled_disk_blue_01_03";
        data["48daf158-9b1a-4322-a518-a0ea0d91e4a8"] = "WorldEntities/Doodads/Precursor/Cable_Temp";
        data["48e0a1e1-7ee2-43bc-a82d-578d942ed1d9"] = "WorldEntities/Environment/Wrecks/PDAs/Wreck3_KooshZone_PDA1";
        data["48f89019-2623-4ef2-be63-33d4f65f0439"] =
            "WorldEntities/Doodads/Precursor/LavaBase/Precursor_LavaCastleBase_Flat_Animated_Long";
        data["4904e113-8765-4d27-a750-33d89d50a8ae"] = "WorldEntities/Fragments/ExosuitGrapplingArmfragment";
        data["490ac8d2-5810-42e8-a5c8-632488f6432b"] =
            "WorldEntities/Doodads/Precursor/Precursor_Interior_Damage_Props_10";
        data["4913329b-6070-4404-bdef-b569546262af"] =
            "WorldEntities/Slots/LostRiver/BonesField/BonesField_Loot_ThermalVent";
        data["492203cd-212b-4caf-9ed1-c788d53958e7"] =
            "WorldEntities/Slots/GrandReef/GrandReef_Loot_TechSite_Barrier_Medium";
        data["49278e68-fe5f-4576-b0f4-d03c2cd834ff"] =
            "WorldEntities/Doodads/Debris/Aurora/Rooms/CrashedShip_entrance_01_02";
        data["492c1e65-8de3-43b8-9f6f-3509bc41423a"] = "Submarine/Build/Submarine_hull_fragments_09";
        data["493802c8-6232-45b5-a7ea-84710c493481"] = "WorldEntities/Tools/Flashlight_damaged";
        data["494b597d-d93b-4738-bf71-96a10d56cc43"] = "WorldEntities/Fragments/Old/BloodKelpFragment";
        data["495befa0-0e6b-400d-9734-227e5a732f75"] = "WorldEntities/Creatures/HoleFish";
        data["496d2038-2bee-46dc-a67f-2059109934c1"] = "WorldEntities/Tools/CyclopsFireSuppressionModule";
        data["4975aef3-6fb6-4760-9146-eabe6e99d4a8"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/explorable_wreckage_modular_room_details_19";
        data["498905fa-9586-43e8-9c9e-19c081d345dd"] =
            "WorldEntities/Slots/LostRiver/BonesField/BonesField_Loot_Corridor_Wall";
        data["49899698-d309-49cb-b4aa-d1cc8f78cd50"] = "WorldEntities/Slots/LavaLakes/LavaLakes_Loot_Ceiling";
        data["498a843d-efed-4fc0-8243-13453aee2559"] = "WorldEntities/Doodads/Fragments/Moon_Pool_fragment_04";
        data["498f8645-e7c4-4ab2-afce-ad0a2dbbfcc8"] = "WorldEntities/Slots/Mountains/Mountains_Creature_Birds";
        data["49b659d0-d85c-40e6-b2c5-33f18cae703a"] = "WorldEntities/Doodads/Land/Tallgrass 7";
        data["49dd65dd-8a2d-4c07-bb1f-9f28485c58f9"] = "WorldEntities/Slots/Ship/Loot_ShipInterior_PlatformUnderwater";
        data["49e2a2eb-e21b-44e6-b9a5-0dd63ba26dc0"] = "WorldEntities/Slots/BloodKelp/BloodKelp_Loot_TechSite_Barrier";
        data["4a21798b-f539-41be-a7a4-426ed3dcde60"] = "WorldEntities/Seeds/Melon";
        data["4a4b434b-ec77-4217-b41d-bd9cf646d308"] = "WorldEntities/Doodads/Lost_river/Lost_river_generic_bone_03";
        data["4a5670a3-1459-45b9-81b4-44ecc7af5996"] =
            "WorldEntities/Doodads/Precursor/TempGun_Interiors/Precursor_Gun_TerminalHallway_01";
        data["4a75b970-c77b-4ced-82a2-7a0fbff2a18f"] = "WorldEntities/Atmosphere/CrashZone/CrashZonelootexclusion_sph";
        data["4a998153-97a4-4242-b7c6-ab6855a53602"] = "WorldEntities/Atmosphere/Inactive Lavazone/MagmaTree";
        data["4a9bc50b-5de2-43bb-899f-242115dc8b69"] = "WorldEntities/Slots/Dunes/Dunes_Loot_CaveWall";
        data["4abced7f-1ce9-4ac6-97ab-aa389213c0e4"] =
            "WorldEntities/Atmosphere/LostRiver/Canyon/LostRiver_Canyon_Lakes_NoVisual";
        data["4ac0db2a-0486-4eff-8a0a-5c46654b094e"] = "WorldEntities/Seeds/PurpleRattleSpore";
        data["4ac691ba-767d-4f5d-a1a5-9a5b4f0aaa0b"] =
            "WorldEntities/Environment/Precursor/Prison/TeleporterRooms/Precursor_Prison_TeleporterHallway01";
        data["4ad5d64d-6a1d-45fe-86f5-8ad3f384dbd4"] = "WorldEntities/Atmosphere/Mesa/CrashZone_Mesa";
        data["4ae90608-40da-45ce-8480-e2f0133f96b2"] = "WorldEntities/Natural/PlasteelIngot";
        data["4af48036-40ba-46b1-a398-ede0bb106213"] = "WorldEntities/Food/CookedLavaBoomerang";
        data["4b37d24e-ede9-4db8-9b3b-ab79434f6762"] = "WorldEntities/Environment/Wrecks/ExplorableWreck_Grassy_31";
        data["4b6d2bb0-7dbc-419a-821c-31f3397f1acf"] = "WorldEntities/Atmosphere/FloatingIslands/Dark";
        data["4b79418e-b3d7-4c14-923c-f3e47a6284e1"] = "WorldEntities/Fragments/SeaglideJunkFragment";
        data["4b8cd269-6646-42d0-b8a0-9a40ef0c07d0"] = "Submarine/Build/Goldglove_car_02";
        data["4bc33bd6-cfa1-46a7-bac8-074ba3b76044"] =
            "WorldEntities/Doodads/Coral_reef/Coral_reef_blue_barnacles_01_02_breakable";
        data["4bc74b15-6f92-45d2-87de-e82a531ace5e"] = "WorldEntities/Atmosphere/JellyshroomCaves/Caves Entrance";
        data["4bc83dc1-dd91-4478-9b35-fd520ccaeb7c"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/circuit_box_01_01";
        data["4bca54e1-7b7c-4051-869c-4a4bc84da306"] =
            "WorldEntities/Environment/Precursor/Prison/Antechamber/Precursor_Prison_EntranceHallway_AnimatedRampLight";
        data["4be0ae46-d32b-4ae1-a4ba-99a91b1a73e7"] =
            "WorldEntities/Environment/Wrecks/Obsolete/ExplorableWreck_SafeShallows_24_old";
        data["4bf39521-436e-4880-92e5-5811ab0021ec"] = "WorldEntities/Doodads/Precursor/Cable_07";
        data["4bfe1877-1b83-4d5d-9470-3bb2d5f389cc"] =
            "WorldEntities/Doodads/Coral_reef/Coral_reef_cave_root_small_01_blood";
        data["4c0f4775-4fdc-461a-a613-1ea547abbd87"] = "Submarine/Build/Starship_doors_automatic";
        data["4c10bbd6-5100-4632-962e-69306b09222f"] = "WorldEntities/Lights/Precursor/Precursor_Cave_Ambient_Small";
        data["4c16537d-0e52-49a1-a518-bccb2d32330d"] =
            "WorldEntities/Environment/Precursor/LavaCastleBase/Precursor_LavaCastleBase_ThermalPlantConsole2";
        data["4c19a96d-ec33-4ccd-a7b1-0d8835c32cc8"] = "WorldEntities/Fragments/CyclopsBridge_Fragment";
        data["4c2808fe-e051-44d2-8e64-120ddcdc8abb"] = "WorldEntities/Creatures/CrabSquid";
        data["4c339205-480c-48fb-815d-dc886f233288"] = "WorldEntities/Slots/Mountains/Mountains_Loot_IslandGrass";
        data["4c4b7870-a335-49b1-a495-7ffeb22f10c8"] = "WorldEntities/Slots/LostRiver/Canyon/Canyon_Loot_Ceiling";
        data["4c761588-7a7e-4e2b-995b-54f6ad9ac3fe"] =
            "WorldEntities/Slots/MushroomForest/MushroomForest_Loot_Techsite_Barrier_Medium";
        data["4c924ad2-ab9a-4ff8-b2bd-3541b1b9d043"] = "WorldEntities/Fragments/exosuit_damaged_04";
        data["4c943b63-e835-4b1b-adca-91eec6b9b32b"] = "WorldEntities/Atmosphere/Dunes/Sparse Zone Dunes";
        data["4ca2a5fc-a529-4cf1-bf9c-75a1f7a6c128"] = "WorldEntities/Slots/BloodKelp/BloodKelp_Creature_OpenShallow";
        data["4cb154ef-bdb6-4ff4-9107-f378ce21a9b7"] = "Submarine/Build/bench_02";
        data["4cb5f76f-fa06-4da9-bc43-5a07c887e2a1"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/explorable_wreckage_modular_room_details_26";
        data["4cc70e47-a05f-4e27-9920-9a6d0e90083d"] =
            "WorldEntities/Environment/Wrecks/submarine_Workbench_damaged_02";
        data["4cebaad1-e8cc-4499-be79-ef28278614af"] = "Submarine/Build/BaseStatus";
        data["4cf57589-1256-4fc1-8b22-607e6f6129fd"] =
            "WorldEntities/Slots/LostRiver/BonesField/BonesField_Creature_Algae";
        data["4d0c8cbd-6127-4681-9d86-d9175e6df722"] =
            "WorldEntities/Doodads/Coral_reef_Light/coral_reef_plant_small_02_Light";
        data["4d235e67-771e-493d-a6e8-52039ee974c2"] =
            "WorldEntities/Lights/LostRiver/BonesField/LostRiver_BonesField_Stream_Light_Medium";
        data["4d6f11f2-1942-47ef-b7a3-2476c090d9a7"] =
            "WorldEntities/Environment/Precursor/Gun/Precursor_Gun_TeleporterTerminal_ToLavaCastleBase_old";
        data["4d74a7e4-24b2-42b5-850c-bcea4b2038a9"] =
            "WorldEntities/Atmosphere/LostRiver/Junction/LostRiver_DeepGrandReef_Pool";
        data["4da51c85-5f8d-4ab1-a6f4-dc94de58a979"] = "WorldEntities/Environment/Prototype/SandPile";
        data["4db7b460-8fb8-4947-bb7b-faa052b8c263"] = "WorldEntities/Atmosphere/SparseReef/Deep";
        data["4dcf5083-bd10-4de6-ba7c-5119bcac4b89"] =
            "WorldEntities/Environment/Precursor/Prison/Antechamber/Precursor_Prison_Antechamber_Console1";
        data["4e1e9f83-af27-43ed-9714-58cc9c2acfa8"] = "WorldEntities/Environment/FallingRock_typeB";
        data["4e296210-6a8a-4a5f-b731-039dce28814a"] = "WorldEntities/Slots/Ship/Loot_ShipInterior_Cargo_Crate";
        data["4e31161e-c812-4c8c-bfd4-00cf4b743884"] =
            "WorldEntities/Doodads/Coral_reef/Coral_reef_jeweled_disk_red_01_04";
        data["4e36dbfa-fb59-4aa1-a997-d5624d23a350"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/starship_girder_06";
        data["4e372190-a687-49bf-a89a-d134c949546e"] = "Submarine/Build/MapRoomFunctionality";
        data["4e3aa4fd-5b85-4e90-976d-62e6cb73fef0"] =
            "WorldEntities/Slots/GrassyPlateaus/GrassyPlateaus_Loot_TowerSmallBase";
        data["4e4704fc-77f0-46de-a21c-eff0b680c7a3"] = "WorldEntities/Natural/LegacyTitanium";
        data["4e8c0174-777f-4e66-8e0f-f73d0e82015b"] = "Submarine/Build/BaseUpgradeConsoleModule";
        data["4e8d70f2-39d0-4502-8453-b8f4ee0ba389"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/starship_girder_08";
        data["4e8d9640-dd23-46ca-99f2-6924fcf250a4"] = "WorldEntities/Environment/Wrecks/PDAs/PDALight";
        data["4e8f6009-fc9c-4774-9ddc-27a6b0081dde"] = "WorldEntities/Doodads/Debris/Wrecks/Decoration/room_06_wreck";
        data["4ea2e54a-5e0c-4754-a646-793e477a094e"] = "WorldEntities/Slots/Mesa/Mesa_Loot_Top";
        data["4ea69565-60e4-4554-bbdb-671eaba6dffb"] =
            "WorldEntities/Environment/Precursor/Gun/Precursor_Gun_BeachEntry_DoorTerminalsRoot";
        data["4ea97ce2-b0c3-4b75-afb9-d6fce58f3669"] =
            "WorldEntities/Environment/Precursor/Prison/EggLab/Precursor_Prison_EggLab_Console1";
        data["4eaa2e42-f4c2-4192-a6b2-1ee21e3f4d22"] =
            "WorldEntities/Doodads/Precursor/Precursor_Interior_Damage_Props_04";
        data["4ebc0e24-e492-45f1-95c8-7b3d13d5f314"] = "WorldEntities/Slots/Ship/Loot_ShipInterior_ExoRoom_Crate_Small";
        data["4ec3d30d-311e-489d-9ade-07c754b57800"] =
            "WorldEntities/Environment/Precursor/Prison/TeleporterRooms/Precursor_Prison_TeleporterRoom_01";
        data["4ec5aca9-7873-4d5d-9bc9-e27d26d13025"] =
            "WorldEntities/Atmosphere/LostRiver/TreeCove/LostRiver_TreeCove_Water_A(nosurf)";
        data["4ed5f192-029b-44b8-8ecb-756ea6c7a462"] =
            "WorldEntities/Doodads/Coral_reef/Coral_reef_blue_barnacles_01_cluster_04";
        data["4eed16c9-2cad-4c7b-94b2-c0e63f1ed954"] =
            "WorldEntities/Environment/Wrecks/ExplorableWreck_SafeShallows_39";
        data["4f045c69-1539-4c53-b157-767df47c1aa6"] = "Submarine/Build/Starship_tech_box_01_01";
        data["4f08efd5-e265-4a8c-8c15-fccffc5408bf"] =
            "WorldEntities/Slots/GrassyPlateaus/GrassyPlateaus_Loot_Techsite_Barrier_Medium";
        data["4f0e304b-0d25-4f9c-a6ba-1b1a6bf029b0"] = "Submarine/Build/StarshipChair";
        data["4f1c84b0-3a61-4b9d-8911-e7d5498ad4db"] = "WorldEntities/Environment/Slime";
        data["4f441e53-7a9a-44dc-83a4-b1791dc88ffd"] = "WorldEntities/Natural/drillable/DrillableKyanite";
        data["4f4bdec2-67a9-425d-b317-0ee3f949d481"] = "WorldEntities/Eggs/ReefbackEgg";
        data["4f5905f8-ea50-49e8-b24f-44139c6bddcf"] =
            "WorldEntities/Environment/Precursor/SkeletonCave/SkeletonCave_Precursor_Scanner_01";
        data["4f6b9fc1-ce4a-4aa2-af6e-ae55e7655978"] = "WorldEntities/Slots/LostRiver/Canyon/Canyon_Loot_Ground";
        data["4f8348fc-5f94-4e70-8982-1fb1b23afc0f"] = "WorldEntities/Lights/LavaZone/Inactive/ILZChamber_Glow";
        data["4f86f57f-aeb0-45f9-8c20-ceb8227aa80a"] =
            "WorldEntities/Doodads/Precursor/TempGun_Interiors/Precursor_Gun_Terminal_Room_01_Lights";
        data["4f94244f-19fc-4fac-be39-aad1c70f32cc"] = "WorldEntities/Slots/LostRiver/Corridor/Corridor_Creature_Open";
        data["4fa743f9-899c-4199-80b5-880787d74180"] =
            "WorldEntities/Slots/UnderwaterIslands/UnderwaterIslands_Loot_CaveFloor";
        data["4fae8fa4-0280-43bd-bcf1-f3cba97eed77"] = "WorldEntities/Creatures/Precursor_Droid";
        data["4fc74403-d10d-4d97-9d0e-9ad090b71f5a"] = "WorldEntities/Food/CookedBoomerang";
        data["4fce5138-805b-4c09-aeaa-a20fbff4a5b9"] =
            "WorldEntities/Slots/MushroomForest/MushroomForest_Creature_GiantTreeRoot";
        data["4ff6ffcc-1806-4f28-a200-0b94e4ffc41c"] =
            "WorldEntities/Environment/Precursor/MountainIsland/Precursor_Mountain_Teleporter_ToFloatingIsland";
        data["4ffa71b8-340c-4c4b-bc6d-c632c11877ee"] = "WorldEntities/Tools/Constructor_damaged_04";
        data["50031120-ab7a-4f10-b497-3a97f63b4de1"] = "WorldEntities/Doodads/Lost_river/ReaperSkull_LostRiver";
        data["501c0536-7993-4ed6-be77-6287cedd8d02"] = "WorldEntities/Doodads/Lost_river/Lost_river_generic_bone_04";
        data["50206db2-58b0-40a3-a679-ade89e29234a"] = "WorldEntities/Environment/Aurora/PDAs/Aurora_LivingArea_PDA2";
        data["502bf218-b7a4-4391-b472-29418c8926f6"] =
            "WorldEntities/Slots/BloodKelp_DeepTrench/BloodKelp_Creature_TrenchFloor";
        data["502f0c63-b9d7-49bf-8e1e-35b26d6613cb"] = "Submarine/Build/EatMyDictionHullPlate";
        data["50427d2b-7e00-416b-8597-fe5c2351422a"] =
            "WorldEntities/Slots/seaTreaderPath/SeaTreaderPath_Loot_Techsite_Small";
        data["5047f336-5d59-4f7b-9991-32abe29fe1ee"] = "WorldEntities/Slots/LostRiver/Junction/Junction_Loot_Ground";
        data["504ae517-c3c7-4bd6-9767-cd6ae189fab9"] = "WorldEntities/Tools/DiveReelAnchor";
        data["505e7eff-46b3-4ad2-84e1-0fadb7be306c"] = "WorldEntities/Environment/EnzymeCureBall";
        data["50716be9-fb9c-4da4-9f3f-8916cbdbfdaf"] =
            "WorldEntities/Environment/Precursor/CragFieldCache/Precursor_CragFieldCache_Teleporter_ToPrison";
        data["5081937e-5dd7-4b3d-92cb-002f3817c801"] = "WorldEntities/Slots/KooshZone/KooshZone_Loot_Techsite_Medium";
        data["5086a02a-ea6d-41ba-90c3-ea74d97cf6b5"] = "WorldEntities/Doodads/Coral_reef/Coral_reef_ball_clusters_04";
        data["508983a0-151f-49cb-a02c-ef93939de9ef"] =
            "WorldEntities/Doodads/Debris/Aurora/Decoration/Signs/Aurora_JHallway_Robotics_Sign";
        data["50c2a56a-dcd7-4131-8d88-c845b25cbd54"] = "WorldEntities/Atmosphere/Dunes/DunesCaveAtmo_Sph";
        data["50ebde28-dcd9-46be-bafd-9e2b483a1d22"] = "WorldEntities/Doodads/Coral_reef/coral_reef_plant_small_01_02";
        data["50fa916f-d7dd-4516-b8dc-f75ac0aac9ec"] =
            "WorldEntities/Environment/Precursor/Precursor_TeleporterStand_NoFields";
        data["510a71f0-ab6d-4c6a-aa54-a19b3f1c436c"] = "WorldEntities/Creatures/WarperSpawner";
        data["510b2c36-3bae-4748-aab9-00f29ec83be0"] = "WorldEntities/Slots/DeepGrandReef/DeepGrandReef_Loot_BlueCoral";
        data["511be5a0-6e97-4ea0-9c5a-aab011f60c29"] = "WorldEntities/Doodads/Precursor/PrecursorKey02_legacy";
        data["514d2d75-89e9-4209-baa1-7798051ec82a"] =
            "WorldEntities/Environment/Precursor/Gun/Mountain_WaterClip_Cave";
        data["514f45b6-7348-4c40-854b-a5f29ad7c7a4"] = "WorldEntities/Environment/DataBoxes/WaterParkDatabox";
        data["51753f23-1e09-4df8-9564-79e49a3fd086"] = "WorldEntities/Tools/Fins";
        data["51afa357-8ec9-4f45-916f-6998a7c35314"] = "Submarine/Build/Submarine_engine_fragments_01";
        data["51bf1ffe-78e7-4673-9f81-17b02233335c"] =
            "WorldEntities/Slots/UnderwaterIslands/UnderwaterIslands_Loot_Techsite_Small";
        data["51cfdbda-2caf-4656-b873-0bc991ae08ae"] = "WorldEntities/Environment/Aurora/Aurora_Elevator_Surface_Exo";
        data["51e58608-a80b-4135-9143-add4ce77a42f"] =
            "WorldEntities/Doodads/Precursor/TempGun_Interiors/Precursor_Gun_Elevator";
        data["51eba507-317c-46bf-adde-4459dc8e002e"] = "Submarine/Build/VendingMachine";
        data["51f31fe3-848c-46a6-bb42-5214f08dc37c"] =
            "WorldEntities/Slots/DeepGrandReef/DeepGrandReef_Loot_ThermalVent";
        data["52073855-349e-4e73-b907-c9e4146dd603"] = "WorldEntities/Slots/Ship/Creature_ShipSpecial_Wreck";
        data["52175781-b8d5-4956-8d06-650619324934"] =
            "WorldEntities/Doodads/Debris/Aurora/Rooms/CrashedShip_T_hallway";
        data["523879d5-3241-4a94-8588-cb3b38945119"] = "WorldEntities/Doodads/Land/land_plant_middle_03_01";
        data["52561a78-06de-4bc4-b7be-a97c3fa8ae20"] =
            "WorldEntities/Slots/DeepGrandReef/DeepGrandReef_Creature_Ground";
        data["52568520-541c-4a5a-a4fa-b5dbac219915"] = "WorldEntities/Environment/Wrecks/cyclopsenginefragment3";
        data["5284a66b-228e-4605-8ec3-08e18a92e803"] = "WorldEntities/Doodads/Precursor/PrecursorActivatedPillar";
        data["52b2d559-899f-4f45-8283-6f954c515f17"] = "WorldEntities/Environment/Generated/SnoozeBallDeathFX";
        data["52bba765-fdb2-4c4a-96b4-005e1ec54814"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/Starship_wires_05";
        data["53239367-550a-450e-afe3-b792b6288e31"] =
            "WorldEntities/Slots/MushroomForest/MushroomForest_Creature_CaveWall";
        data["5339accf-234c-48a1-8f62-61cdff7ccfe5"] = "WorldEntities/Environment/DataBoxes/PlasteelTankDataboxSpawner";
        data["533d54b0-e54a-4aec-8dd0-a9eb89868c59"] = "WorldEntities/Doodads/Land/farming_plant_02";
        data["5340de25-0481-4239-9702-b9bb0a96cbd2"] =
            "WorldEntities/Atmosphere/LostRiver/BonesField/LostRiver_BonesField_ThermalVent";
        data["53429378-769e-4731-9d6f-e67d0c912165"] =
            "WorldEntities/Environment/Aurora/Aurora_SeamothRoom_WeldablePanel";
        data["536034e1-cf52-4bbd-a87c-c0ff079bd78b"] = "WorldEntities/Environment/Aurora/Aurora_Elevator_Surface";
        data["53874f61-78c8-4f91-a576-b63a19647feb"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/explorable_wreckage_modular_wall_details_01";
        data["539af52c-f4b8-402b-ae88-e641aa031685"] = "WorldEntities/Creatures/HoopFish_02";
        data["53e89f85-44a6-4ccf-9790-efae4b5fcae9"] = "WorldEntities/Slots/BloodKelp/BloodKelp_Loot_Grass";
        data["53f02bc3-5565-43e2-b4ba-75a925a4f5ca"] = "WorldEntities/Slots/LostRiver/Junction/Junction_Loot_Wall";
        data["53ffa3e8-f2f7-43b8-a5c7-946e766aff64"] = "WorldEntities/Environment/Precursor/Precursor_PurpleKey";
        data["542aaa41-26df-4dba-b2bc-3fa3aa84b777"] =
            "WorldEntities/Environment/Precursor/Prison/Precursor_Prison_Outpost2";
        data["5450100f-7ec3-4fa2-a896-5a7599e89710"] =
            "WorldEntities/Environment/DataBoxes/VehicleModificationStationDatabox";
        data["545c54a8-b23e-41bc-9d7c-af0b729e502f"] = "WorldEntities/Food/BigFilteredWater";
        data["5462a145-fdc1-464d-ad61-ec81920ec7e3"] = "WorldEntities/Natural/magnetite";
        data["54701bfc-bb1a-4a84-8f79-ba4f76691bef"] = "WorldEntities/Creatures/GhostLeviathan";
        data["54759572-b554-42d2-9c57-aa58da71296d"] = "WorldEntities/Atmosphere/GrassyPlateaus/Caves (Sphere)";
        data["54845ed4-3212-4f2f-ab1f-e8ec02d32df7"] =
            "WorldEntities/Environment/Aurora/Aurora_ExoRoom_WeldablePanel_Root";
        data["54a55dca-7586-4b59-90d3-c16f04dad425"] = "WorldEntities/Slots/ILZCastle/ILZCastle_Loot_TunnelCeiling";
        data["54a7d6b6-280a-43d5-8bdd-eada3dd5f6c3"] = "WorldEntities/Fragments/exosuit_damaged_01";
        data["54b568b5-f7ef-41a9-b85f-90ce441cadb9"] = "WorldEntities/Doodads/Lost_river/lost_river_skull_coral_04";
        data["54dad6b2-77c8-4f9a-9294-2621ca296754"] = "WorldEntities/Doodads/Coral_reef/Coral_reef_shell_plates_01_02";
        data["54e42cab-849d-46a0-9e86-14e41fff74ca"] = "WorldEntities/Slots/LostRiver/Junction/Junction_Loot_Roots";
        data["55199d49-bd1c-4a21-8317-993ed6c85265"] = "WorldEntities/Environment/Generated/SnoozeBallHurtFX";
        data["551f2ad8-14d8-4b5e-bf26-19e458d95a8b"] =
            "WorldEntities/Slots/SafeShallows/SafeShallows_Creature_ShellTunnel";
        data["552954c9-1700-4b27-8f04-dace9c01e995"] =
            "WorldEntities/Environment/Wrecks/Obsolete/ExplorableWreck_KelpForest_27_old";
        data["5546fb57-c326-4559-914c-be40f4e108d8"] = "WorldEntities/Unused/IncubatorUnused";
        data["5550502d-552b-4f22-8bf2-479d73a7646c"] = "WorldEntities/Creatures/JellyRay";
        data["5565b742-d786-4e7f-88a9-075d0f8afad9"] =
            "WorldEntities/Slots/GrassyPlateaus/GrassyPlateaus_Loot_PlateauTop";
        data["556b2ac6-1e6e-4597-bd1b-b0819ed82c3e"] =
            "WorldEntities/Doodads/Coral_reef/Crab_snake_mushrooms_entrance_06";
        data["5579911b-7b65-4c8e-a520-4288a346a49f"] = "WorldEntities/Slots/DeepGrandReef/DeepGrandReef_Loot_Ground";
        data["557bfe98-28af-4b31-b55b-4a7f6dda5685"] =
            "WorldEntities/Doodads/Coral_reef/coral_reef_Stalactites_cluster_04_04";
        data["558b2a86-52bc-4267-9ee5-22ee4683515a"] = "WorldEntities/Lights/UnderwaterIslands/CavePlant";
        data["559fe0c7-1754-40f5-9453-b537900b3ac4"] = "WorldEntities/Doodads/Land/land_plant_middle_06_01";
        data["55a41eb8-8c37-4d09-a78b-5be1080fb224"] = "WorldEntities/Environment/Wrecks/ExplorableWreck_GrandReef_10";
        data["55a4e0cb-b853-4c2b-8d71-c63553c1c73c"] = "WorldEntities/Environment/DataBoxes/RadiationSuitDataBox_old";
        data["55c08ea2-591a-493e-8a18-68be68b61ffa"] =
            "WorldEntities/Environment/Precursor/Prison/PipeRoom/Precursor_Prison_PipeRoom_OutgoingPipe3";
        data["55d5bf23-b1f4-4c29-8d88-5a9d463369f9"] =
            "WorldEntities/Slots/LostRiver/SkeletonCave/SkeletonCave_Creature_Ground";
        data["55d7ab35-de97-4d95-af6c-ac8d03bb54ca"] = "Misc/CellRoot";
        data["55fe083b-da5f-4dcd-9f8d-e43c1952dce7"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/explorable_wreckage_modular_wall_details_10";
        data["5631b64f-d0f0-47f5-b7ac-f23215432070"] =
            "WorldEntities/Doodads/Precursor/Precursor_prison_exterior_box_01";
        data["5643d0f8-c305-4bdc-b80d-012d8cbfb6e5"] = "WorldEntities/Environment/Wrecks/cyclopshullfragment2";
        data["56531208-8d32-47e9-8207-52acbfb7d8ff"] =
            "WorldEntities/Environment/SafeShallows/Obstruction_Rock_Medium01";
        data["56625a8d-1538-446f-9124-05b4922fafd4"] =
            "WorldEntities/Lights/LostRiver/BonesField/LostRiver_BonesField_Lake_Plant_Light_Medium";
        data["56898c2c-6d9e-459d-ba18-ca7f74c43fbf"] = "WorldEntities/Slots/KelpForest/KelpForest_Creature_CaveRecess";
        data["568a6721-fbc2-4cd0-aa13-64feead4f373"] = "WorldEntities/Slots/KooshZone/KooshZone_Creature_Geyser";
        data["568fbbb0-4baa-4685-90e6-920109250bb0"] = "WorldEntities/Slots/LavaLakes/LavaLakes_Loot_Floor";
        data["569f22e0-274d-49b0-ae5e-21ef0ce907ca"] =
            "WorldEntities/Environment/AbandonedBases/AbandonedBaseFloatingIsland2";
        data["56b5ed17-2bff-4f7e-aba0-275b6a2398f9"] = "WorldEntities/Environment/Wrecks/life_pod_exploded_17";
        data["56b832a3-1c09-4816-bb0a-1db804f2bb07"] = "WorldEntities/Slots/KelpForest/KelpForest_Loot_GrassSparse";
        data["56bc49dc-85ce-4a87-aa7f-9afa99a17c16"] =
            "WorldEntities/Environment/LostRiver/LostRiver_BonesField_Waterfall";
        data["56cdfa77-e7ce-4397-9f8e-fc050e1626d6"] =
            "WorldEntities/Doodads/Precursor/LostRiverBase/Precursor_LostRiverBase_BalconyGlass";
        data["56da7f35-4026-49f5-87f2-793749149e1f"] =
            "WorldEntities/Slots/SafeShallows/SafeShallows_Creature_OpenShallow";
        data["56dd6d16-afc4-4f76-b03b-6ba036f0691a"] =
            "WorldEntities/Doodads/Precursor/precursor_cables_end_prison_exterior";
        data["57029b42-24f8-49b2-9e35-4194f43e847b"] = "WorldEntities/Doodads/Precursor/Cable_03";
        data["570c06d4-72d5-4903-9918-5810cd9da14c"] = "WorldEntities/Lights/LostRiver/Point_Tree_Cove_Blue_small";
        data["57263177-490a-4046-8fa1-2af499cbc216"] = "WorldEntities/Slots/SparseReef/SparseReef_Loot_DeepWall";
        data["573c716a-0ca9-418b-b390-8180677c63f8"] = "WorldEntities/Fragments/Old/cyclopshullfragment_large_old";
        data["573ffb0e-0e96-4843-86bf-aaf097bdc176"] =
            "WorldEntities/Doodads/Debris/Aurora/Decoration/Signs/Aurora_CrewArea_Supply_Sign";
        data["575109e0-0adc-4b73-a8cf-cfb49d1571c3"] = "WorldEntities/Creatures/GhostRayRed";
        data["575d39df-aa65-44e7-bf5a-80eb1d892800"] = "Base/Ghosts/BaseFiltrationMachine";
        data["57749ff8-288b-424d-a3b2-6f87b27e7254"] = "WorldEntities/Slots/BloodKelp_Cave/BloodKelp_Loot_CaveRoots";
        data["57a31bf5-5b86-4bf6-9a14-9291c6e8a79c"] = "WorldEntities/Doodads/Coral_reef/coral_reef_plant_small_01_01";
        data["57bcd1da-606b-4a72-8a7b-cce350fdb183"] =
            "WorldEntities/Doodads/Coral_reef/coral_reef_plant_middle_11_grass";
        data["57bff111-7bfe-4f28-a97c-8c3b206d91fb"] = "WorldEntities/Slots/Mountains/Mountains_Loot_CaveWall";
        data["57c48cfa-867d-4722-8e51-5bf4fee0d9e3"] = "WorldEntities/Fragments/stasisriflefragment";
        data["57c6bd55-f99d-4940-8576-d82a1ef101fc"] =
            "WorldEntities/Slots/MushroomForest/MushroomForest_Creature_CaveFloor";
        data["57d96ba6-729c-4a33-ba3b-777b3c322ee8"] =
            "WorldEntities/Environment/Precursor/SurfaceVents/Precursor_Mountains_Vent";
        data["57ec1c56-a06c-48e3-b4b5-4105c55ffd97"] =
            "WorldEntities/Environment/Precursor/LostRiverBase/Precursor_LostRiverBase_BalconyDoorObstruction";
        data["57f06434-b847-4f08-9dac-cabb339ad526"] = "WorldEntities/Natural/Stone5";
        data["580154dd-b2a3-4da1-be14-9a22e20385c8"] = "WorldEntities/Natural/SupplyCrate_Battery";
        data["580d12a7-9964-425d-adb0-f971a5aaa59b"] =
            "WorldEntities/Doodads/Coral_reef/Crab_snake_mushrooms_entrance_03";
        data["58247109-68b9-411f-b90f-63461df9753a"] = "WorldEntities/Doodads/Precursor/Precursor_DGRAbandonedBase_Key";
        data["583f8885-20fd-4c69-aa5a-5fcd7c58804b"] =
            "WorldEntities/Doodads/Precursor/Precursor_cube_03_damaged_piece_04";
        data["5843d6d0-9c88-4405-9bc0-f4b060ddb5df"] =
            "WorldEntities/Slots/LostRiver/BonesField/BonesField_Loot_Ceiling";
        data["5884d27a-8798-4f09-82ec-c7671a604504"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/descent_plaza_shelf_cap_02";
        data["589bf5a6-6866-4828-90b2-7266661bb6ed"] = "WorldEntities/Fragments/BaseBioReactor_Fragment";
        data["58a521e3-a809-447e-beb1-957c5a7205e5"] =
            "WorldEntities/Environment/Wrecks/Obsolete/ExplorableWreck_KelpForest_23_old";
        data["58b3c65d-1915-497d-b652-f6beba004def"] = "WorldEntities/Atmosphere/BloodKelp/Trench";
        data["58d5c7c2-0e55-42c9-8859-826d6f211eb2"] =
            "WorldEntities/Environment/Wrecks/Obsolete/ExplorableWreck_SafeShallows_21_old";
        data["58e06173-426b-46da-be01-d77fa2ecc749"] =
            "WorldEntities/Doodads/Coral_reef/Coral_reef_small_rocks_seaweed_04";
        data["58eb6068-ec90-457f-92d5-278338931cc0"] = "WorldEntities/Tools/Thermometer";
        data["58f044b5-9ba5-4ea8-b919-bcbb179a015f"] =
            "WorldEntities/Slots/MushroomForest/MushroomForest_Loot_CaveSand";
        data["59258b05-d299-4d93-a6e5-db8406e249b8"] = "WorldEntities/Slots/Dunes/Dunes_Loot_ThermalVent_Sand";
        data["59381275-1f6e-4bb9-8b00-7bbe77f0df1c"] = "WorldEntities/Doodads/Coral_reef_shell_01";
        data["594bc492-ca28-4e75-b4ef-d1272e34a6cd"] = "WorldEntities/Lights/LavaZone/Inactive/ILZCorridor_Glow";
        data["59612435-6a4c-4087-aa03-6cadedf7b026"] =
            "WorldEntities/Slots/UnderwaterIslands/UnderwaterIslands_Loot_IslandSides";
        data["596ceb3c-9c96-431e-b0d4-2c205a8a01fa"] = "WorldEntities/Environment/ThermalVent_Dark_Huge";
        data["596d464c-87a6-4ac0-9955-c15b05722af6"] =
            "WorldEntities/Slots/UnderwaterIslands/UnderwaterIslands_Loot_ValleyWall";
        data["5975d3c5-381c-4f0c-a7f2-a27391d3f46f"] = "WorldEntities/Atmosphere/ActiveLavazone/LavaLakes";
        data["597ca303-3b24-45dc-b3d1-1e450ba5cf32"] =
            "WorldEntities/Doodads/Precursor/Precursor_Prison_Interior_Moon_Pool";
        data["598c95d8-7420-4907-8f70-ba18b4e6adcb"] =
            "WorldEntities/Doodads/Coral_reef/coral_reef_small_deco_17_yellow";
        data["598fa1cc-2dd2-4b00-bc42-ce48d40024d5"] =
            "WorldEntities/Slots/Prison/Aquarium/PrisonAquarium_Creature_Open";
        data["599e5422-e9b5-4d35-9674-9a5edbdee696"] =
            "WorldEntities/Slots/ILZChamber/ILZChamber_Creature_MagmaBubble_Open";
        data["59d1be30-a77f-4722-b42c-4a2db2334654"] = "WorldEntities/Atmosphere/CragField/CragFieldCaveTeleporter";
        data["59d84031-4216-4dcc-8ece-b39aca53f9ad"] =
            "WorldEntities/Atmosphere/LostRiver/BonesField/LostRiver_BonesField";
        data["59eefa74-2dd8-4522-83bd-c498831eb2aa"] = "WorldEntities/Doodads/Precursor/Precursor_Thermal_Reactor";
        data["59f9f106-e2d4-45cc-9211-2d843d456282"] =
            "WorldEntities/Doodads/Lost_river/Lost_river_hanging_plant_04_01";
        data["5a0f53e7-7af5-4ff2-a940-80a5fbea96a1"] = "WorldEntities/Slots/Mountains/Mountains_Creature_ThermalVent";
        data["5a14440b-2e5e-4bbe-8617-51e4e607c50b"] = "WorldEntities/Food/CookedHolefish";
        data["5a461ae6-7db8-46ef-9f89-9ffff2c3bae1"] = "WorldEntities/Atmosphere/SafeShallows/Caves Entrance";
        data["5a6279e2-fab9-48c9-bcb3-fdeb02fd4ce2"] = "WorldEntities/Doodads/Debris/Starship_exploded_debris_38";
        data["5a8b18b4-0970-45b0-b7b2-80919cf5bd16"] =
            "WorldEntities/Doodads/Debris/Aurora/Decoration/Signs/Aurora_THallway_ResourceProcessing_Sign";
        data["5ab14cc5-12bd-4a4a-b0d6-6c9d59a02e45"] = "WorldEntities/Environment/Prototype/Blinker";
        data["5ab49520-ad6b-428d-b961-1c1ea4e59465"] =
            "WorldEntities/Slots/KelpForest/KelpForest_Loot_TechSite_Scatter_Medium";
        data["5ab88ca4-0b25-4012-8a19-03abe72b94b2"] = "WorldEntities/Atmosphere/MushroomForest/MF_caves_light_sph";
        data["5ac911d3-dfcd-423e-a702-ef04ce538301"] = "WorldEntities/Natural/MapRoomUpgradeScanSpeed";
        data["5ae43c48-7f5c-4943-86af-09f50602849e"] = "WorldEntities/Atmosphere/Inactive Lavazone/ILZLava";
        data["5afc6bb3-8a33-4b2f-a18b-02bc0bcc99b5"] = "WorldEntities/Slots/BloodKelp/BloodKelp_Loot_TechSite";
        data["5b2544af-4835-42c2-8a84-e69ac7b9ee02"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/descent_bar_seat_straight_01";
        data["5b456102-1a5f-458c-b11c-d9f79b87162f"] =
            "WorldEntities/Doodads/Precursor/LavaBase/Final_Rooms/Precursor_LavaBase_IonBatteryRoom";
        data["5b702ef7-7403-49ee-99c5-1f67ab04954a"] = "WorldEntities/Natural/sandstone";
        data["5b77807e-1e5a-4e7f-91c5-53ffaeb40193"] =
            "WorldEntities/Doodads/Precursor/TempGun_Interiors/MoonPool_Hallway_01_Lights";
        data["5b985d38-b6e2-4fa9-8f9b-9ba22d5a14f2"] =
            "WorldEntities/Doodads/Coral_reef/coral_reef_Stalactites_cluster_04_02";
        data["5bb543c5-e780-4b4a-8ba3-11d16bed4142"] =
            "WorldEntities/Slots/LostRiver/SkeletonCave/SkeletonCave_Loot_Wall";
        data["5bbc13c4-f421-4995-a419-433852903820"] =
            "WorldEntities/Lights/Treader Path/Treader_Path_Mushrooms_lrgAmb";
        data["5bbd405c-ca10-4da8-832b-87558c42f4dc"] = "WorldEntities/Environment/ThermalVent_Dark_Big";
        data["5bcaefae-2236-4082-9a44-716b0598d6ed"] =
            "WorldEntities/Environment/Precursor/Prison/Precursor_Prison_Outpost3";
        data["5bce4572-ee4a-497f-a992-bfe87d8b9689"] = "WorldEntities/Spawns/Spawn_Skyray_NoRoost";
        data["5be19289-fb9e-4568-8e2d-616cae348efe"] =
            "WorldEntities/Slots/SparseReef/SparseReef_Loot_Techsite_Barrier_Small";
        data["5be64297-0340-4d4b-adce-0841d2b25483"] = "Submarine/Build/Workbench";
        data["5beba896-bccf-4993-8bcb-1cdabb68e706"] =
            "WorldEntities/Doodads/Coral_reef_Light/Coral_reef_cave_root_03_blood_Light";
        data["5c01746d-d2a5-4ae0-b163-b0d5d07e0054"] =
            "WorldEntities/Environment/Precursor/Prison/TeleporterRooms/Precursor_Prison_Teleporter_ToMushroomForest";
        data["5c06baec-0539-4f26-817d-78443548cc52"] = "Submarine/Build/Radio";
        data["5c31f494-6114-41da-8336-946e7dd1d7ab"] =
            "WorldEntities/Slots/Prison/Aquarium/PrisonAquarium_Creature_Sand";
        data["5c541401-e88b-4de1-86a8-1ad28eb05b55"] = "WorldEntities/Lights/Treader Path/Treader_Path_Mushrooms";
        data["5c5598fd-2f20-409e-a6e3-a342e8fdb197"] =
            "WorldEntities/Slots/SafeShallows/SafeShallows_Creature_ShellTunnelHuge";
        data["5c5a1e76-0c37-4e41-a0c7-61cbb1c22001"] =
            "WorldEntities/Slots/MushroomForest/MushroomForest_Creature_CaveSpecial";
        data["5c767a21-a317-4caf-b734-27f614e9a1ee"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/docking_bar_bottle_04";
        data["5c8077fb-62bc-425a-ac53-383db8ac59b4"] =
            "WorldEntities/Lights/LostRiver/BonesField/LostRiver_BonesField_Ceiling_Spot3";
        data["5c8cb04b-9f30-49e7-8687-0cbb338fc7fa"] = "Submarine/Build/PlanterPot2";
        data["5c8ec717-a144-4393-8e98-0851f838a26d"] = "WorldEntities/Atmosphere/UnderwaterIslands/Geyser (Sphere)";
        data["5c9ad2ff-acc2-4a36-8ce3-c2fb002de8ad"] =
            "WorldEntities/Doodads/Precursor/LostRiverBase/Precursor_LostRiverBase_TankGlassLarge";
        data["5ca9d34d-3b1e-46b7-9660-ab3156db7d28"] =
            "WorldEntities/Doodads/Precursor/TempGun_Interiors/Precursor_Gun_Entry";
        data["5cbf39d5-6ce9-4cf8-a5b0-f4b1b64858d6"] = "WorldEntities/Food/CookedEyeye";
        data["5cc19d2a-24b1-4a9f-b382-1c218346721c"] =
            "WorldEntities/Environment/Precursor/Gun/Precursor_Gun_Door_AnimatedLight";
        data["5ccf33e0-6617-4ce9-935a-0dc2146544b8"] =
            "WorldEntities/Environment/Precursor/LostRiverBase/Precursor_LostRiverBase_Lab01_Rays";
        data["5cd34124-935f-4628-b694-a266bc2f5517"] = "WorldEntities/Doodads/Debris/Starship_exploded_debris_01";
        data["5ce9eb7b-064b-46e6-ae7b-43fc4bd016c3"] = "WorldEntities/VFX/xLavaJetSmokeBig";
        data["5cebe7f6-b1ce-4ae0-8008-ccfdac5d5690"] =
            "WorldEntities/Environment/Precursor/MushroomForestCache/Precursor_MushroomForestCache_Teleporter_ToPrison";
        data["5cf44d20-ab07-4787-994b-35c2fd061959"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/starship_girder_04";
        data["5d258b1c-8723-4420-a9b1-95f5e56e2680"] = "WorldEntities/Atmosphere/GrandReef/Cave";
        data["5d26f1e1-acea-4b8c-b9f5-024e6ca903ef"] = "Submarine/Build/PowerCellCharger";
        data["5d51197e-64a8-4c4d-be30-cb3ad5612f41"] =
            "WorldEntities/Environment/Wrecks/ExplorableWreck_SafeShallows_37";
        data["5d5fad52-7783-4107-a68c-6a94c473e25e"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/circuit_box_01_03";
        data["5d63470b-2705-4963-be4b-2e11e8dc6f2e"] = "Submarine/Build/Bench";
        data["5d74624d-7875-49a9-a022-acd230cf6f0c"] = "WorldEntities/Environment/Wrecks/EscapePod_3_KelpForest";
        data["5d7f92ed-997d-46da-8621-9d704066e251"] =
            "WorldEntities/Slots/GrassyPlateaus/GrassyPlateaus_Creature_PlateauTop";
        data["5dd2ccf1-ce52-4792-919a-fc93936828f8"] = "WorldEntities/Seeds/PinkMushroomSpore";
        data["5ddfbbca-3eec-46b6-9cbc-2546f5f7a834"] =
            "WorldEntities/Slots/SafeShallows/SafeShallows_Creature_CaveFloor";
        data["5de7d617-c04c-4a83-b663-ebf1d3dd90a1"] = "WorldEntities/Creatures/GarryFish";
        data["5dfd24ca-72d1-4cc0-b0dc-ab34c3294e1c"] =
            "WorldEntities/Doodads/Precursor/Prison/Aquarium/Precursor_Prison_TeleporterRoom_01_Lights";
        data["5e0c5331-7eeb-4139-9598-96e5ef38afb3"] =
            "WorldEntities/Doodads/Precursor/precursor_column_maze_10_32_10_v3";
        data["5e5958db-f5ec-48a8-89e4-6e08f0f3140b"] = "WorldEntities/Doodads/Precursor/PrecursorDoor01";
        data["5e5f00b4-1531-45c0-8aca-84cbd3b580a4"] = "WorldEntities/Creatures/SandShark";
        data["5e7d2a38-9d14-41a7-9cbd-c83a021965f6"] = "WorldEntities/VFX/xSteamLeakLoop_small";
        data["5e8261d5-acce-4ec6-b77c-0f138770d5cb"] = "WorldEntities/Doodads/Geometry/SafeShallows/Coral_Clump01a";
        data["5ea36b37-300f-4f01-96fa-003ae47c61e5"] = "WorldEntities/Creatures/GhostLeviathanJuvenile";
        data["5eab86a8-ce0f-441f-9b81-c8e156ea9db0"] =
            "WorldEntities/Doodads/Coral_reef/Coral_reef_blue_barnacles_01_cluster_03";
        data["5eb5330a-2e1a-4469-8e8a-4bf17bbfe06f"] = "WorldEntities/Structures/BaseDoor";
        data["5ec8b8a6-b9b1-412b-9048-62701346cca2"] = "WorldEntities/VFX/xBubbleColumn_small";
        data["5ecd846d-1629-4d3c-9119-f4f16179a408"] = "WorldEntities/Doodads/Precursor/precursor_block_deco_08_04_08";
        data["5ed66f98-b6fa-4c30-bd99-88638bad9442"] =
            "WorldEntities/Environment/Precursor/LostRiverBase/Precursor_LostRiverBase_Warper";
        data["5eec7a47-2c38-4431-8306-27e0215d0a35"] = "WorldEntities/Atmosphere/UnderwaterIslands/Island";
        data["5efe116e-b68f-47c7-a034-93e874b4816c"] = "WorldEntities/Food/CuredSpinefish";
        data["5f38e180-2674-4c01-a435-c7eb72790d60"] = "WorldEntities/Food/CuredLavaBoomerang";
        data["5f44a1ca-3cfe-4554-817a-fac0ce9992d0"] =
            "WorldEntities/Atmosphere/Precursor/EmperorFacility/Precursor_Prison_Aquarium_Atmosphere";
        data["5f4a139e-dc70-45a1-bbe5-659c5ee018ca"] = "WorldEntities/Doodads/Precursor/precursor_column_maze_08_08_08";
        data["5f597062-4b99-4323-bcb3-d16c768f7ea8"] =
            "WorldEntities/Environment/Precursor/LavaCastleBase/Precursor_LavaCastleBase_EnableGlobalWaterVolume";
        data["5f5e91e8-4901-4a9c-b8d8-649e17411194"] = "WorldEntities/Doodads/Debris/Starship_exploded_debris_33";
        data["5f6d9ad1-540d-44b1-b62d-2478cd041ae5"] = "WorldEntities/Food/CookedLavaEyeye";
        data["5f891ad9-2544-4d51-8502-bb35039c5b42"] = "WorldEntities/Tools/ExosuitTorpedoArmModule";
        data["5f8a6634-12f4-44b2-8952-19e85747c1e2"] = "WorldEntities/Doodads/Geometry/SafeShallows/Rock_Small02";
        data["5f93851f-cb13-4b99-99a9-15c34c063e13"] =
            "WorldEntities/Environment/AbandonedBases/AbandonedBase PDA/IslandsPDABase1a";
        data["5f96da0b-1e62-4cef-a92f-6127a2f30875"] = "WorldEntities/Slots/KelpForest/KelpForest_Creature_Wall";
        data["5f9f38f9-a7cc-48ee-9e38-6c8624d36c99"] = "Submarine/Build/MarkiplierHullPlate";
        data["5fc7744b-5a2c-4572-8e53-eebf990de434"] = "Submarine/Build/SmallLocker";
        data["5fcbfc1a-5483-4945-af94-133886ddbc2d"] = "WorldEntities/Fragments/Old/cyclopsbridgefragment_old";
        data["5fdaf202-68ed-44d0-850a-934156279d19"] = "WorldEntities/Doodads/Coral_reef/coral_reef_small_deco_18";
        data["5fff71b2-c8a2-4ed6-8d35-d0ff24ef376d"] = "WorldEntities/Atmosphere/BloodKelp/Normal";
        data["601d2007-f7ea-4bfd-822d-4775ec02bf6f"] =
            "WorldEntities/Doodads/Coral_reef/coral_reef_brown_coral_tubes_02_04";
        data["601ee500-1744-4697-8279-59ef35160edb"] = "WorldEntities/Natural/drillable/DrillableCopper";
        data["60bf17dd-1936-47c2-bcd7-394ba7bfc440"] = "WorldEntities/Natural/Stone1";
        data["60f7bcb6-1d0f-40a2-ab68-e1fae7370d4a"] = "WorldEntities/Tools/Gravsphere_damaged";
        data["60fdf752-bc74-4f85-8a9c-72f86031a52f"] =
            "WorldEntities/Doodads/Coral_reef/coral_reef_blood_mushrooms_01_01";
        data["6131f7ce-6a01-4f1a-a954-0e1d597ae493"] =
            "WorldEntities/Slots/LostRiver/Corridor/Corridor_Loot_ThermalVent";
        data["61362077-2ad5-42ad-b6c9-f1a352856d8c"] = "WorldEntities/Fragments/Old/basenuclearreactorfragment_old";
        data["616074ad-ef72-46d1-9ad5-3ca48ba2cb4c"] = "WorldEntities/Slots/LostRiver/Junction/Junction_Creature_Open";
        data["6161c1ed-44fb-40fd-8a7d-1cd94192a1e6"] =
            "WorldEntities/Doodads/Lost_river/LostRiverBase/Lost_river_hanging_plant_02_02";
        data["619a65ad-ced7-4fd7-bcdf-3963885e35dd"] =
            "WorldEntities/Slots/UnderwaterIslands/UnderwaterIslands_Creature_CaveFloor";
        data["61a5e0e6-01d5-4ae2-aea6-1186cd769025"] =
            "WorldEntities/Doodads/Coral_reef/Coral_reef_purple_mushrooms_01_02";
        data["61ac1241-e990-4646-a618-bddb6960325b"] = "WorldEntities/Natural/SeaTreaderPoop";
        data["61b3cad9-8d30-42e1-b2da-0d2c8bd2aa9e"] = "WorldEntities/Slots/KooshZone/KooshZone_Creature_RockWall";
        data["61d7ad84-9544-4e47-84ad-6a5d7040b38a"] = "WorldEntities/Fragments/Old/workbenchfragment_old";
        data["625d01c2-40b7-4c87-a1cc-493ad6101c34"] = "WorldEntities/Doodads/Precursor/Precursor_computer_terminal";
        data["6261cfe6-6ef4-467f-927e-2912f9abcaaa"] =
            "WorldEntities/Slots/seaTreaderPath/SeaTreaderPath_Loot_Techsite_Scatter_Medium";
        data["626f6739-acb0-4dfc-bbab-9b627767403c"] = "WorldEntities/Atmosphere/TreaderPath/Treader_Collision_box";
        data["6276db62-5021-4da8-9ae3-266503630188"] = "WorldEntities/Slots/LostRiver/Corridor/Corridor_Creature_Roots";
        data["627d0380-6202-4820-882e-72363ce20a40"] = "WorldEntities/Atmosphere/Ship/CrashedShip_Interior_THallway";
        data["62a21085-982c-4a2b-ac57-5d465b381f79"] =
            "WorldEntities/Environment/Precursor/Prison/Aquarium/Precursor_Prison_Aquarium_TeleporterAirlock_ToMoonpool";
        data["62a47c16-bf83-46ee-b16b-8cc35e7df97d"] = "WorldEntities/Atmosphere/UnderwaterIslands/ValleyFloor";
        data["62bccd6e-ca6a-40e5-8f02-4a912f76ed5d"] = "WorldEntities/Doodads/Coral_reef/Coral_reef_green_mohawk_01";
        data["630958be-f557-42b6-9a27-0f32376b00b7"] = "WorldEntities/Doodads/Coral_reef/Coral_reef_shell_02_02";
        data["6309b213-aee9-4035-8474-e61248fa2a49"] = "WorldEntities/Lights/JellyshroomCave/Geyser_Light";
        data["6317283a-c90a-44d4-9310-8d82a41eb8cc"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/Starship_wires_12";
        data["63244491-ecd7-448b-af56-b1b989157536"] = "WorldEntities/Seeds/RedRollPlantSeed";
        data["632703e7-2788-449c-9584-4d5f6ae8a856"] = "WorldEntities/Slots/Mesa/Mesa_Creature_Top";
        data["633f6688-b8d7-450e-b8ca-1b5b4a4bb14b"] =
            "WorldEntities/Atmosphere/Mountains/Mountains_IslandCaveEntrance_Surface_cube";
        data["63462cb4-d177-4551-822f-1904f809ec1f"] = "WorldEntities/Environment/GeyserShort";
        data["6349304a-79d5-4dae-9d71-05a1dfe0dd69"] =
            "WorldEntities/Slots/UnderwaterIslands/UnderwaterIslands_Loot_Techsite_Scatter_Small";
        data["63938cee-f576-4280-b075-7be40ccacd0e"] = "WorldEntities/Slots/SparseReef/SparseReef_Creature_CaveFloor";
        data["63a6df43-ca11-4a2f-a55d-7315f83f90b6"] = "WorldEntities/Slots/LostRiver/TreeCove/TreeCove_Creature_Wall";
        data["63e251a6-fb65-454b-84b0-4493e19f73cd"] = "WorldEntities/Natural/copper";
        data["63e69987-7d34-41f0-aab9-1187ea06e740"] =
            "WorldEntities/Environment/Precursor/Prison/TeleporterRooms/Precursor_Prison_TeleporterTerminal_ToKooshZone";
        data["63fadd85-81dc-4086-8800-bcee2a84f014"] =
            "WorldEntities/Environment/Precursor/LostRiverBase/Precursor_LostRiverBase_Console3_New";
        data["640af07c-6fc1-4ca1-bf6a-34965acbe9dd"] =
            "WorldEntities/Slots/DeepGrandReef/DeepGrandReef_Loot_AbandonedBase_Inside_Medium";
        data["640f57a6-6436-4132-a9bb-d914f3e19ef5"] =
            "WorldEntities/Doodads/Precursor/precursor_column_maze_10_32_10_v1";
        data["64351d31-de9a-406a-8061-c7e8be5dd66c"] = "WorldEntities/Fragments/BatteryCharger_Fragment";
        data["643869f2-d506-4d6c-9ac4-78ce840d6707"] =
            "WorldEntities/Environment/Precursor/Prison/PipeRoom/Precursor_Prison_PipeRoom_Extras";
        data["6442c915-5f10-47b0-bd04-9b1521aa88c1"] =
            "WorldEntities/Slots/BloodKelp_DeepTrench/BloodKelp_Creature_ShockerEggs";
        data["644fe732-6ca3-49a3-813d-45d8c6586967"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/starship_girder_11";
        data["6462f600-90c7-4b9a-8e2f-a67d6f858f24"] =
            "WorldEntities/Environment/Wrecks/Obsolete/EscapePod_KelpForest_25_old";
        data["6471a9df-1c83-4d80-a919-0f0e7d8dc2ee"] = "WorldEntities/Doodads/Coral_reef_Light/coral_reef_spiky_trap";
        data["649ff503-126f-47b6-a446-6ac14f3bb533"] =
            "WorldEntities/Environment/Precursor/SurfaceVents/Precursor_MushroomForest_Vent";
        data["64f3581b-68fb-468e-a0c4-6423eb8ebc72"] = "WorldEntities/Slots/BloodKelp/BloodKelp_Creature_Wreck";
        data["6508edb5-93e6-40f1-9f6a-ff32427b0157"] = "WorldEntities/Slots/SparseReef/SparseReef_Loot_CaveFloor";
        data["650b59c2-1b61-468f-8dab-c4c9c4dd3faf"] =
            "WorldEntities/Doodads/Precursor/precursor_block_stripe_08_04_08";
        data["6515e66c-7b2a-4511-8251-942b9ff49bb2"] = "WorldEntities/Atmosphere/Mountains/Mountains_CaveEntrance_sph";
        data["652f26ee-86a1-49ea-ae98-ac4dba0ed16c"] =
            "WorldEntities/Doodads/Coral_reef/Coral_reef_small_blue_fans_01_05";
        data["655ecf78-49d0-4303-8f3a-faf8f867d2a4"] =
            "WorldEntities/Slots/Prison/Aquarium/PrisonAquarium_Creature_SpecialCoral";
        data["6565501f-b2c6-43bb-b36f-eec0e5f3532b"] = "WorldEntities/Slots/Dunes/Dunes_Creature_OpenDeep";
        data["656f6191-214e-4b26-8833-fa47b297219e"] = "WorldEntities/Environment/Wrecks/cyclopshullfragment1";
        data["658c1489-7ace-4a22-a2ab-dde8ca994dd5"] =
            "WorldEntities/Atmosphere/Mountains/Mountains_WreckInterior_Atmosphere";
        data["65b20919-cdc2-449f-a25a-b797e6fe2f4f"] = "WorldEntities/Atmosphere/TreaderPath/TreaderPath_Wreck_Adjust";
        data["65b59f9e-3191-45a9-87b8-f6c5a6d2d6e9"] = "WorldEntities/Fragments/Old/GrassyPlateausFragment";
        data["65c70a93-976c-4e3c-9e80-a77eb08f1caa"] =
            "WorldEntities/Slots/MushroomForest/MushroomForest_Loot_CaveSpecial";
        data["65ccf541-9110-4cc6-bfd2-9b9d3725d170"] = "WorldEntities/Doodads/Debris/Wrecks/Decoration/DecoPlanterPot";
        data["65e8aad0-b391-46cf-a062-dca72ee277d1"] = "WorldEntities/Doodads/Precursor/Prison/Relics/Alien_relic_07";
        data["65edb6a3-c1e6-4aaf-9747-108bd6a9dcc6"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/Starship_cargo_damaged_01";
        data["66072588-f5aa-4a41-a8d4-bb7e8dffee51"] = "WorldEntities/Creatures/BoneShark";
        data["663ac6d7-89c9-4a7c-b8c7-bf0184d921f1"] =
            "WorldEntities/Doodads/Debris/Aurora/Decoration/Signs/Aurora_CrewArea_Canteen_Sign";
        data["663b3aad-09f6-4534-bdee-d55d01033934"] = "WorldEntities/Atmosphere/DeepGrandReef/Normal_named";
        data["6670a49a-95ed-4de9-b805-8bfbadc4bd4b"] =
            "WorldEntities/Atmosphere/Precursor/EmperorFacility/Precursor_Prison_UpperRoom_Atmosphere";
        data["6680ec6a-e9e4-488d-8d90-c83924dbca76"] = "WorldEntities/Slots/Mountains/Mountains_Creature_Grass";
        data["66910d41-da61-4ee6-8bf2-da6a449fe3f4"] = "WorldEntities/Eggs/RabbitRayEgg";
        data["669d26ab-81a0-4e4f-8bba-fac0d6cf8dab"] = "WorldEntities/Doodads/Debris/Starship_exploded_debris_04";
        data["66c6e364-4c28-4a19-8109-807e834a3e65"] =
            "WorldEntities/Slots/LostRiver/BonesField/BonesField_Creature_Corridor_Wall";
        data["66cc5a83-142b-4d8d-8d16-2d6e960f59c3"] = "WorldEntities/Environment/Wrecks/life_pod_exploded_2";
        data["66e052c5-c20f-404a-942a-9e522daf6769"] = "WorldEntities/Doodads/Geometry/FishBones/Fishbone_vert01";
        data["66f2188b-b537-49ac-b6e7-08f446eca9e8"] =
            "WorldEntities/Doodads/Coral_reef_Light/Coral_reef_Kelp_blood_04_Light";
        data["66f23e46-6ddd-46bb-9710-3374c4e0815f"] = "WorldEntities/Atmosphere/Ship/CrashedShip_Interior_Locker";
        data["670c6f10-8702-4141-8ca7-a96a2e5df8d6"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/descent_bar_seat_side_01";
        data["673e9db2-62d7-4b49-a07e-0dc7ebe4203c"] = "WorldEntities/Atmosphere/BloodKelp/Cave(Sphere)";
        data["67644fe7-2775-4a74-89d8-443186946d50"] = "WorldEntities/Environment/DataBoxes/PlasteelTankDataBox";
        data["67663e0a-a6d3-4bcc-8a96-aed305b7f51c"] =
            "WorldEntities/Slots/GrassyPlateaus/GrassyPlateaus_Loot_Techsite_Scatter_Medium";
        data["67667924-3993-45b1-bcd2-62928d83d719"] =
            "WorldEntities/Slots/MushroomForest/MushroomForest_Creature_GiantTreeInteriorSpecial";
        data["67744b32-93c2-4aba-8a18-ffb87204a8eb"] = "WorldEntities/Tools/LEDLight";
        data["677db3b4-2e53-40bb-a422-1ea80d61cae7"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/starfish_02_bend";
        data["679ef7e4-a419-4d4d-9860-6e87555d597a"] =
            "WorldEntities/Slots/JellyshroomCaves/Jellyshroom_Creature_CaveSpecial";
        data["67ac2d03-0f20-421e-9b79-546133eb2f22"] = "WorldEntities/Lights/LostRiver/Point_Tree_Cove_Blue_med";
        data["67acd25f-9e63-45b9-bef2-e6a85dd5eb4b"] =
            "WorldEntities/Environment/Precursor/Gun/Precursor_Gun_Terminal2_AnimatedLight";
        data["67b58229-eaec-4dac-af3f-8e3c5c5362ef"] = "WorldEntities/Doodads/Coral_reef/Coral_reef_shell_02_07";
        data["67bd41ba-f940-4444-929f-cc1f218fb7ce"] = "WorldEntities/Fragments/Old/seamothfragment_old2";
        data["67dd6f15-9ac5-4f87-b71a-ebd16f04f02b"] = "WorldEntities/Doodads/Debris/Wrecks/Decoration/docking_menu_01";
        data["68254d33-2d67-48a8-b485-9929f23a8ba8"] =
            "WorldEntities/Environment/Precursor/Prison/Antechamber/Final Rooms/Precursor_Prison_EggLab_Extras";
        data["68258aac-98c6-4411-9645-314538d1f59f"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/Starship_wires_07";
        data["6843ce38-7ccd-4863-9c17-63284aa680dc"] = "WorldEntities/Atmosphere/SparseZone/Normal";
        data["68462082-f714-4b5e-8d0d-623d2ec6058f"] = "WorldEntities/Tools/SeaGlide_damage";
        data["6889626e-ae7b-4794-bc0f-fe4fbc27d5e1"] =
            "WorldEntities/Slots/Ship/Loot_ShipInterior_PowerRoomReinforcementModule";
        data["688b9ffb-e0d9-4177-8de4-49e1ce9dcfd6"] =
            "WorldEntities/Atmosphere/LostRiver/GhostTree/LostRiver_GhostTree";
        data["689763c4-181a-4a2f-b865-ec0dcb3875ae"] =
            "WorldEntities/Slots/KooshZone/KooshZone_Loot_KooshZone_KooshReefs";
        data["689ac547-d2e3-4fdd-b0ce-88fa57d57969"] =
            "WorldEntities/Slots/SafeShallows/SafeShallows_Loot_TechSite_Scatter_Small";
        data["689fc97b-5ed2-45b9-8249-552d062c3802"] = "WorldEntities/Doodads/Lava/lava_rock_01_01";
        data["68c58fba-bc8d-40fc-a137-544af418f953"] = "WorldEntities/Doodads/Precursor/Precursor_Lab_table";
        data["68e35b94-8868-4bfd-9b38-5be1ebd16ec1"] = "WorldEntities/Doodads/Coral_reef/Coral_reef_shell_04";
        data["68e7dcd8-fe09-4dac-b966-85463c3c58af"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/biodome_Robot_Arm";
        data["690e2455-05db-4c69-a48a-288b0a49082a"] =
            "WorldEntities/Doodads/Lost_river/lost_river_canyon_bottom_root_02_a";
        data["691723cf-d5e9-482f-b5af-8491b2a318b1"] = "WorldEntities/Doodads/Coral_reef/Coral_reef_shell_tunnel_03";
        data["6935e1ca-a963-4852-a44e-ec083e477b6e"] =
            "WorldEntities/Slots/GrassyPlateaus/GrassyPlateaus_Creature_Sand";
        data["69379779-332a-4a88-b4c3-9aa13115b671"] = "WorldEntities/Slots/BloodKelp_Trench/BloodKelp_Creature_Roots";
        data["69669e36-9ac8-4b0c-bf9e-4273c346660d"] =
            "WorldEntities/Doodads/Precursor/precursor_column_maze_10_32_10_v4";
        data["697beac5-e39a-4809-854d-9163da9f997e"] = "WorldEntities/Natural/drillable/DrillableSulphur";
        data["697efe88-f5f1-45c3-a735-60508e66b97e"] =
            "WorldEntities/Doodads/Precursor/precursor_block_corner_02_05_04";
        data["6994b958-a579-44e7-a876-7afc54d6e0ea"] =
            "WorldEntities/Slots/LostRiver/TreeCove/TreeCove_Creature_Water_Floor";
        data["69cd7462-7cd2-456c-bfff-50903c391737"] = "WorldEntities/Doodads/Precursor/precursor_cables_middle_01";
        data["6a01a336-fb46-469a-9f7d-1659e07d11d7"] = "WorldEntities/Doodads/Precursor/Precursor_Lab_surgical_machine";
        data["6a02aa5c-8d4d-4801-aad4-ea61dccddae5"] =
            "WorldEntities/Doodads/Precursor/LavaBase/Precursor_LavaCastleBase_ActivatedPillar";
        data["6a1b444f-138f-46fa-88bb-d673a2ceb689"] = "WorldEntities/Creatures/Skyray";
        data["6a2b577f-5a40-4611-bce1-17cadb1d2500"] = "WorldEntities/Slots/Dunes/Dunes_Loot_Rock";
        data["6a362a19-8dce-45f2-bc56-f980506d8def"] = "WorldEntities/Slots/BloodKelp_Trench/BloodKelp_Creature_Wall";
        data["6a475947-b801-4a3d-b918-f0eea1599bba"] =
            "WorldEntities/Doodads/Coral_reef/Coral_reef_small_blue_fans_01_04";
        data["6a54ea3b-6a98-4b77-bbe7-65b108a0d826"] =
            "WorldEntities/Environment/Precursor/LostRiverBase/Precursor_LostRiverBase_WarperLab_Extras";
        data["6a5a5b1d-9532-4e87-9657-36a203fd569b"] = "WorldEntities/Fragments/transfuserfragment_old";
        data["6a5c9533-75e5-47c6-a16e-0f5f71e14f4f"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/wall_monitor_01_02";
        data["6a69ccc6-db84-45e6-aae8-acc1004ff29f"] =
            "WorldEntities/Environment/Precursor/Prison/TeleporterRooms/Precursor_Prison_Teleporter_FromGun_Obsolete";
        data["6a701511-a46a-4bbd-9db4-4123c061baf7"] = "WorldEntities/Slots/Dunes/Dunes_Loot_Techsite_Medium";
        data["6aa312cb-14ec-4a00-986e-efa2c5fd3d3e"] = "Base/Ghosts/BaseWaterPark";
        data["6ab67109-eea5-407d-81ec-e6e0ae7b76ef"] = "WorldEntities/Atmosphere/ActiveLavazone/LavaPit";
        data["6adcb7e2-88a8-43f8-bea4-85dd9d63818c"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/explorable_wreckage_modular_room_details_16";
        data["6afcb8c0-7f68-4bde-b6d6-ecd68d889e5e"] = "WorldEntities/Slots/GrassyPlateaus/GrassyPlateaus_Loot_Wall";
        data["6b0104e8-979e-46e5-bc17-57c4ac2e6e39"] = "WorldEntities/Doodads/Precursor/Precursor_cube_01";
        data["6b0235d4-a434-45ce-820f-61e87535db59"] =
            "WorldEntities/Slots/LostRiver/BonesField/BonesField_Loot_Corridor_Ceiling";
        data["6b47bc76-d0b0-41ab-a2e5-81a62ebc66b5"] =
            "WorldEntities/Atmosphere/LostRiver/BonesField/LostRiver_BonesField_Skeleton";
        data["6b48da47-f513-4105-a474-a203f6b5f651"] =
            "WorldEntities/Lights/LostRiver/Point_LR_Canyon_Water_bluebranches_small";
        data["6b52f136-0b4f-4e9a-b4a6-f65546bdfefe"] =
            "WorldEntities/Doodads/Precursor/TempGun_Interiors/Teleporter_Hallway_01";
        data["6b54ecc0-d789-45a0-aad8-68e529b65cb0"] = "WorldEntities/Slots/SparseReef/SparseReef_Loot_DeepFloor";
        data["6b66d6e2-1374-49cf-a5f7-391a7130d94b"] =
            "WorldEntities/Environment/Precursor/LostRiverBase/Precursor_LostRiverBase_ObservationRoom_Decals";
        data["6b682116-37a6-4588-a3e8-0defd11696fa"] =
            "WorldEntities/Slots/FloatingIsland/FloatingIsland_Creature_Shallows";
        data["6b965dfc-37bf-4485-ba85-cbdb1ce24999"] =
            "WorldEntities/Slots/Prison/Aquarium/PrisonAquarium_Creature_DeadCoral";
        data["6b9eee61-cb9f-463e-97c4-bfc47b911e06"] = "Submarine/Build/Submarine_engine_fragments_03";
        data["6bbc5b08-a0e9-46b8-a332-fe4188f143c0"] =
            "WorldEntities/Slots/JellyshroomCaves/Jellyshroom_Creature_Geyser";
        data["6bddc3c6-767f-4640-ba41-7afae977d035"] = "WorldEntities/Doodads/Land/land_grass_04";
        data["6be26bed-91eb-42b9-be92-314d3bd028d6"] = "WorldEntities/Doodads/Lost_river/Lost_river_generic_bone_08";
        data["6bf7e935-6e27-4b93-bc9c-25b7ec95c45e"] = "WorldEntities/Doodads/Lost_river/Lost_river_generic_bone_09";
        data["6bfb688d-2271-4f13-b3fc-28a611daf26c"] = "WorldEntities/Doodads/Precursor/PrecursorDoor02";
        data["6c36eec6-b387-4288-9e94-fce73b7e9d8e"] = "WorldEntities/Doodads/Coral_reef/Coral_reef_hanging_seaweed";
        data["6c3b537a-53b6-464a-8a91-ab21e74d58db"] = "WorldEntities/Slots/SparseReef/SparseReef_Creature_DeepCoral";
        data["6c58dc6b-2ae2-41ca-8c43-f953b919f7ab"] = "WorldEntities/Environment/Wrecks/Nuclear_reactor_damaged_02";
        data["6c5a0c27-7eb1-479a-8efe-bc10c49d656d"] = "WorldEntities/Natural/coral_reef_small_deco_10";
        data["6c72dc8e-1b6d-4fd9-9a4a-2566d9826a92"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/explorable_wreckage_modular_room_details_24";
        data["6c81e0b3-c204-4ab2-a3ac-0e9ce9d5cd1f"] =
            "WorldEntities/Environment/Precursor/Prison/PipeRoom/Precursor_Prison_PipeRoom_Hallway";
        data["6c9d1c59-e938-4e6e-b9a4-aeb2b97da2d1"] =
            "WorldEntities/Environment/AbandonedBases/AbandonedBase PDA/IslandsPDABase1Storm";
        data["6ca93e93-5209-4c27-ba60-5f68f36a95fb"] = "Submarine/Build/control_terminal_01";
        data["6cafbcb5-6cb7-4e0f-9934-03133a3772b6"] = "WorldEntities/Natural/Stone3";
        data["6cdcb6ff-94ac-4b98-820f-54047f5482b3"] = "WorldEntities/Tools/ReinforcedGloves";
        data["6d13066f-95c8-491b-965b-79ac3c67e6aa"] = "WorldEntities/Doodads/Land/land_plant_middle_03_03";
        data["6d1d97a5-75b8-49ef-8944-393d387a37a0"] = "WorldEntities/Natural/MapRoomUpgradeScanRange";
        data["6d3698ac-48da-4029-b290-e4cc98988d27"] = "WorldEntities/Food/CuredGarryfish";
        data["6d535e87-a4b1-4044-802b-f99491fe21fd"] =
            "WorldEntities/Doodads/Lost_river/Lost_river_hanging_plant_02_03";
        data["6d632ca7-3dcd-44c2-81ef-fa4e2144e034"] =
            "WorldEntities/Atmosphere/Precursor/Gun/Precursor_Gun_InnerRooms_Atmosphere";
        data["6d71afaa-09b6-44d3-ba2d-66644ffe6a99"] = "Submarine/Build/Aquarium";
        data["6d727949-4f6c-4d0a-a932-e4120c1dccaf"] =
            "WorldEntities/Doodads/Precursor/TempGun_Interiors/Precursor_Gun_TerminalHallway_01_Lights";
        data["6d9e37de-f808-4621-a762-e0d6340b30dc"] = "WorldEntities/Doodads/Coral_reef/Coral_reef_small_deco_03";
        data["6dc84d2b-42fb-4757-9346-6da8627a577e"] =
            "WorldEntities/Doodads/Coral_reef/Coral_reef_small_rocks_seaweed_03";
        data["6defe27f-f055-4871-bbf7-4a26b0beefc8"] = "WorldEntities/Slots/KelpForest/KelpForest_Loot_Wall";
        data["6df06526-2d6a-472e-95dd-0c1e4ff2ae48"] = "WorldEntities/Structures/BaseLadderOld";
        data["6df8ccd1-f3d1-44df-bfe9-df42606ab7f4"] = "WorldEntities/Slots/GrandReef/GrandReef_Creature_PurpleCoral";
        data["6e0f4652-c439-4540-95be-e61384e27692"] = "WorldEntities/Tools/Constructor_drone_damaged";
        data["6e2a3c1c-bab5-4581-8163-3059d0065834"] = "WorldEntities/Tools/CyclopsHullModule3";
        data["6e30649d-e58a-4ce3-924f-9534f0278d88"] =
            "WorldEntities/Slots/MushroomForest/MushroomForest_Loot_MushroomTreeBase";
        data["6e37459e-d880-4da8-8dad-0cc10ff07f00"] = "WorldEntities/Doodads/Lost_river/Lost_river_rib_02";
        data["6e39e2fc-b616-437c-8227-c54128648ec3"] = "WorldEntities/Slots/KooshZone/KooshZone_Loot_EscapePod_Medium";
        data["6e4b4259-becc-4d2c-b56a-03ccedbc4672"] = "WorldEntities/VFX/xUnderwaterElecSource_aurora_medium";
        data["6e4f85c2-ad1d-4d0a-b20c-1158204ee424"] = "WorldEntities/Fragments/GravSphere_Fragment";
        data["6e530f6d-284b-4e81-86d9-60818176853a"] = "WorldEntities/Slots/Mountains/Mountains_Creature_IslandSand";
        data["6e7f3d62-7e76-4415-af64-5dcd88fc3fe4"] = "WorldEntities/Natural/kyanite";
        data["6eae94e5-8fc8-4aef-ae41-ad8c081bcf4b"] = "WorldEntities/Doodads/Land/Tropical Plant 10b";
        data["6eb257c0-aaa4-43e3-b84b-33492ac8ba1c"] = "WorldEntities/Slots/KooshZone/KooshZone_Creature_Generic";
        data["6ebac43c-e63b-480e-bf8e-5c9b3bf91341"] =
            "WorldEntities/Slots/MushroomForest/MushroomForest_Creature_CaveCeiling";
        data["6ec47bde-9a3a-4db3-b3e8-fc509ca23d94"] =
            "WorldEntities/Atmosphere/Mountains/Mountains_IslandCaveEntrance_sph";
        data["6ecd7cee-2f97-445c-b8c7-7d29e825fd41"] =
            "WorldEntities/Slots/SafeShallows/SafeShallows_Creature_CaveWall";
        data["6ee85584-9682-4aea-b2f2-8c1c66477bf9"] = "WorldEntities/Fragments/Old/cyclopshullfragment_medium_old";
        data["6ef6075d-47c8-479a-a5b8-c142a44a9ff8"] = "WorldEntities/Doodads/Debris/Starship_exploded_debris_03";
        data["6f01d2df-03b8-411f-808f-b3f0f37b0d5c"] = "WorldEntities/Environment/Wrecks/Wrecks_Starship_doors_sealed";
        data["6f050a7a-ee38-4b73-aa59-d61cdd5fe34b"] = "WorldEntities/Environment/Generated/Deprecated/Signal";
        data["6f2b134b-c6d1-4d3d-995b-a69e0c7c8cdf"] =
            "WorldEntities/Environment/Precursor/MountainIsland/Precursor_Mountain_TeleporterTerminal_ToFloatingIsland";
        data["6f2de811-b469-46cd-8163-a3029f82fb68"] = "WorldEntities/VFX/xLavaSplashes_15x6";
        data["6f3fca18-65f3-4a73-a7d2-f7be40dc927d"] = "WorldEntities/Slots/Mountains/Mountains_Creature_CaveWall";
        data["6f472c27-894e-4b61-b229-04c4cebbd744"] = "WorldEntities/Doodads/Debris/Starship_exploded_debris_40";
        data["6f5c4850-b8bd-461a-999d-1c49d69ffe3a"] = "WorldEntities/Doodads/Coral_reef/Spiral_blue_thing_cluster_02";
        data["6f5cdc26-c970-4d75-baca-ca7c94393ef3"] = "WorldEntities/Environment/Wrecks/ExplorableWreck2";
        data["6f5fbbaa-998c-407e-af74-2aea9d8b3a92"] = "WorldEntities/Environment/LeviathanFacility/Cube";
        data["6f686868-5b53-498a-8a26-e68aa46b7ff6"] =
            "WorldEntities/Doodads/Debris/Aurora/Decoration/starship_exo_room_gantry_system";
        data["6f7faf8a-aefb-4a8c-a6c2-edf5067ac0fb"] =
            "WorldEntities/Slots/LostRiver/GhostTree/GhostTree_Creature_Ceiling";
        data["6f83287b-a78d-4657-a35d-58cf186dc683"] = "WorldEntities/Slots/Dunes/Dunes_Loot_SandDunes";
        data["6f926416-cc4a-4740-9fdf-df3f5a17c738"] = "WorldEntities/Slots/SafeShallows/SafeShallows_Loot_ShellTunnel";
        data["6f932b93-65e8-4c89-a63b-d105203ab84c"] = "WorldEntities/Seeds/PinkFlowerSeed";
        data["6f9e2e29-9eba-4261-ba7b-ed5eac120b91"] = "WorldEntities/Doodads/Fragments/Map_Room_fragment_01";
        data["6fa9e0f9-4028-4a67-853c-1ae23643e817"] = "WorldEntities/Doodads/Precursor/Cable_06";
        data["6fc8133a-4f99-4be5-a1b7-55374433517c"] = "WorldEntities/Slots/DeepGrandReef/DeepGrandReef_Loot_RockDeep";
        data["6fcf86b5-3eee-400e-8016-41166f0c1a09"] =
            "WorldEntities/Doodads/Precursor/Precursor_Interior_Damage_Props_06";
        data["70227651-a1d5-4958-bd26-a1fb2c5ca46e"] = "WorldEntities/Slots/Ship/Loot_ShipSpecial_SupplyCrate";
        data["702b6e03-0376-4e94-b154-5f64f8017324"] = "WorldEntities/Tools/SwimChargeFins";
        data["70487d73-9fbd-44d5-a784-a3f607aee722"] = "WorldEntities/Environment/Aurora/PDAs/Aurora_LivingArea_PDA4";
        data["7052c646-4f91-46e1-8aa7-2e7310ca813d"] = "Base/Ghosts/BaseConnector";
        data["709b5aed-8b68-4fc7-af2c-f390138f83fc"] = "WorldEntities/Slots/SparseReef/SparseReef_Loot_EscapePod_Small";
        data["70a3c9e3-120e-4356-aa6b-f6967b27d803"] = "WorldEntities/Slots/Ship/Loot_ShipInterior_ExoRoomPipes";
        data["70baf966-87be-4bb5-b1c8-f8277ae0f8e0"] = "Base/Ghosts/BaseUpgradeConsole";
        data["70c0c560-1a47-46ea-9659-30c8072eb792"] = "WorldEntities/Doodads/Lost_river/Lost_river_generic_bone_06";
        data["70dbcec5-e841-42ab-ac69-fea8495c3ea9"] = "WorldEntities/Doodads/Geometry/SafeShallows/Rock_Small03";
        data["70eb6270-bf5e-4d6a-8182-484ffcfd8de6"] =
            "WorldEntities/Doodads/Coral_reef/Coral_reef_jeweled_disk_red_01_01";
        data["710a7f6c-a409-4966-af68-ff46827a2bcc"] =
            "WorldEntities/Doodads/Precursor/LavaBase/Final_Rooms/Precursor_LavaBase_TeleporterRoom";
        data["7116f8b3-c6c6-4ce1-8b22-0d4385d26709"] = "WorldEntities/Slots/KelpForest/KelpForest_Loot_CaveRecess";
        data["712886c4-fe2a-4d6d-8b2c-efdb9be28a6f"] = "Base/Ghosts/BaseMapRoom";
        data["7145a329-1520-43fd-b959-40d33bac1162"] = "WorldEntities/Doodads/Debris/Wrecks/ExplorableWreckRoom03";
        data["71498905-2ce2-4622-8d6f-40212f6202df"] = "WorldEntities/Doodads/Coral_reef/Spiral_blue_thing_cluster_01";
        data["715973b5-6377-4e04-a59f-c417cbf5e0a7"] = "WorldEntities/Slots/KooshZone/KooshZone_Creature_CaveSpecial";
        data["716fbe90-c2c7-4065-9d96-ab1f553f3ed6"] = "WorldEntities/Slots/Dunes/Dunes_Creature_ThermalVent_Sand";
        data["717f9950-e19f-4230-a12f-fa1777b05b53"] = "WorldEntities/Slots/LostRiver/Junction/Junction_Creature_Wall";
        data["7180f59f-42ae-4f93-9c9c-5c9a5feac379"] =
            "WorldEntities/Atmosphere/LostRiver/GhostTree/LostRiver_GhostTree_Lower";
        data["7193a410-ee7b-4bba-85a6-80aa00e2ca68"] =
            "WorldEntities/Doodads/Debris/Aurora/Rooms/CrashedShip_entrance_01_03";
        data["71a164d3-0bf4-4811-a423-65aa88baa4a8"] =
            "WorldEntities/Slots/GrassyPlateaus/GrassyPlateaus_Loot_CaveSpecial";
        data["71bf71c2-ecfb-47c0-aafe-040030d5954f"] = "WorldEntities/Doodads/Lost_river/Lost_river_fish_skeleton";
        data["71d245fb-2136-4194-b750-d4c442b1d6fb"] =
            "WorldEntities/Slots/Prison/Aquarium/PrisonAquarium_Loot_CaveFloor";
        data["723226ac-63b0-4704-8a57-5127da463045"] =
            "WorldEntities/Slots/BloodKelp_DeepTrench/BloodKelp_Creature_TrenchRoots";
        data["7238ff24-5e21-44ea-86ab-603d378ba4bd"] = "WorldEntities/Environment/Wrecks/Wrecks_VentCover_Aurora";
        data["723d0cbc-02ee-433c-a359-30911bf0dba7"] = "WorldEntities/Lights/Mountains/Mountcave_plant_light_small";
        data["72437ebc-7d61-49b8-bac4-cb7f3af3af8e"] = "WorldEntities/Doodads/Debris/Starship_exploded_debris_22";
        data["725bb928-f0b1-4415-919f-3ef14c0ccba3"] = "WorldEntities/Slots/Ship/Loot_ShipInterior_ExoRoomPipes_Small";
        data["72a8c169-ca00-48aa-94f9-d92d932548e0"] = "WorldEntities/Doodads/Fragments/Moon_Pool_fragment_05";
        data["72c26bc6-41ec-42ed-80c0-59424041b920"] =
            "WorldEntities/Atmosphere/Ship/CrashedShip_Interior_THallwayLower";
        data["72d0460c-1b50-416b-8a9d-58e415132d3d"] = "WorldEntities/Environment/Wrecks/cyclopsbridgefragment2";
        data["72d93482-1473-43b1-bfe7-184e2c547764"] = "WorldEntities/Doodads/Land/land_grass_01_green";
        data["72da21f9-f3e2-4183-ac57-d3679fb09122"] = "WorldEntities/Environment/Wrecks/Poster";
        data["72e64ce2-eb55-4e09-955e-684c809f9038"] = "WorldEntities/Doodads/Coral_reef/coral_reef_grass_02";
        data["73100150-0e14-4646-b004-57fff6ccd388"] =
            "WorldEntities/Doodads/Lost_river/lost_river_skull_coral_group_04";
        data["7329db6b-7385-4e77-8afa-71830ead9350"] = "WorldEntities/Doodads/Coral_reef/Coral_reef_kelp_01_mid";
        data["733fd479-0760-4bc2-a03e-281cbf02bfa4"] = "WorldEntities/Tools/MapRoomCamera";
        data["734dde78-9d8d-4414-bc27-cf6b559b01c1"] =
            "WorldEntities/Slots/Ship/Loot_ShipInterior_Corridor_Barrier_Small";
        data["734fc442-ed73-480b-9cd8-f88e5f339752"] = "WorldEntities/Slots/Ship/Loot_ShipInterior_ExoRoom";
        data["73658f8a-7f66-404e-a645-466bc604e15b"] =
            "WorldEntities/Doodads/Coral_reef/Coral_reef_blue_barnacles_01_cluster_01";
        data["736c0a79-c771-45ad-9876-7d18b5ce06c2"] = "WorldEntities/Atmosphere/GrassyPlateaus/Tower";
        data["7370e7a0-ebc0-4c33-9997-7084c11a55b0"] = "Submarine/Build/LabCounter";
        data["737d5c09-1a46-4daf-a2b6-0423fa3f7931"] =
            "WorldEntities/Slots/LostRiver/TreeCove/TreeCove_Creature_TreeOpen";
        data["737e0cdd-5333-4e1a-9b5d-f808340e71ec"] =
            "WorldEntities/Doodads/Debris/Aurora/Rooms/CrashedShip_pipes_room";
        data["73812784-0ba6-4240-80b4-9f822175a1e6"] =
            "WorldEntities/Slots/LostRiver/Junction/Junction_Creature_Water_Wall";
        data["738748a3-74c5-46ce-9711-4286a434ffb2"] = "WorldEntities/Environment/Aurora/Consoles/GenericConsole1";
        data["738892ae-64b0-4240-953c-cea1d19ca111"] =
            "WorldEntities/Doodads/Precursor/Gun/Precursor_Prison_RelicPlatform";
        data["73a14237-46a5-4603-a91e-125a4ed04375"] =
            "WorldEntities/Doodads/Coral_reef/coral_reef_brown_coral_tubes_02_02";
        data["73b99f65-02a4-4bea-a6f6-3f67e2ccf638"] =
            "WorldEntities/Slots/JellyshroomCaves/Jellyshroom_Creature_CaveCeiling";
        data["73cdf3ff-54bb-45fa-9e86-788434c25b75"] =
            "WorldEntities/Doodads/Debris/Aurora/Decoration/Signs/Aurora_JHallway_DriveRoom_Sign";
        data["73d93fd9-ed39-4231-986b-3d261a36fb38"] =
            "WorldEntities/Slots/LostRiver/TreeCove/TreeCove_Creature_Ground";
        data["7400ad61-c4de-4b16-a42b-41253881257a"] = "WorldEntities/Lights/Kelpforest/Stinger_Light_lrg_amb";
        data["740258f8-bf36-484b-bdb8-d9e5dc3f1e3e"] = "WorldEntities/Fragments/exosuit_damaged_02";
        data["740d0849-e73b-4bcb-b07e-dab64a6c89ce"] =
            "WorldEntities/Doodads/Lost_river/Lost_river_hanging_plant_01_02";
        data["740f385f-ae35-4e06-a88f-023db82cbf6b"] = "WorldEntities/Environment/Wreck";
        data["74265e8a-4e84-4aff-8b49-8f1563014106"] =
            "WorldEntities/Atmosphere/Precursor/EmperorFacility/Precursor_Prison_Aquarium_Upper_Atmosphere";
        data["742b410c-14d4-42c6-ac84-0e2bcaff09c1"] =
            "WorldEntities/Doodads/Precursor/Precursor_prison_exterior_box_01_animated_spotlight";
        data["742bee7e-23af-4ac2-927d-b39de510577d"] = "WorldEntities/Slots/KelpForest/KelpForest_Loot_SandRocky";
        data["742d2a09-a2d7-4acd-b9c7-1f97cb793932"] = "WorldEntities/Tools/SeamothTorpedoModule";
        data["7436aeba-f8df-4887-b369-e630fa01f716"] = "WorldEntities/Fragments/powertransmitterfragment";
        data["7444baa0-1416-4cb6-aa9a-162ccd4b98c7"] = "WorldEntities/Environment/Coral_reef_floating_stones_mid_02";
        data["745018a1-28b3-48df-8c57-f668685da3b8"] = "WorldEntities/Environment/Wrecks/ExplorableWreck_Grassy_32";
        data["746f3849-b764-4874-9cd3-66ff8e65d843"] = "WorldEntities/VFX/x_BubblesPlane_01";
        data["74912c22-a383-48c7-8e9e-34b515c6aebb"] = "WorldEntities/Natural/hydrochloricacid";
        data["74d03ee4-8a89-4dfe-904e-4bf380f64866"] =
            "WorldEntities/Doodads/Coral_reef/Coral_reef_small_rocks_seaweed_08";
        data["74d7c18f-ceff-4a1e-8c6f-7d63200efe00"] =
            "WorldEntities/Slots/LostRiver/BonesField/BonesField_Creature_Corridor_Open";
        data["74e459c6-b926-4037-aef4-c6cee5951588"] = "WorldEntities/Doodads/Lava/lava_rock_01_02";
        data["74ec328c-e627-40ad-b373-97e384ec0385"] = "WorldEntities/Tools/SeamothHullModule1";
        data["74ee7292-f385-4063-91e6-d9448e95de6e"] =
            "WorldEntities/Doodads/Precursor/TempGun_Interiors/Precursor_Gun_TerminalRoom_02";
        data["74f368f4-b08f-4b0c-ab96-c97e37911ff0"] = "WorldEntities/Doodads/Coral_reef/Coral_reef_jelly_plant_01_03";
        data["74f544d2-66cf-4deb-a723-4e0a1cd9c6fe"] =
            "WorldEntities/Environment/Precursor/LavaCastleBase/Precursor_LavaCastleBase_TeleporterTerminal_ToGun";
        data["7510b039-c884-4ffa-9622-21970d4b6ee6"] =
            "WorldEntities/Slots/KelpForest/KelpForest_Loot_TechSite_Barrier_Medium";
        data["7518da03-0e05-4d11-b154-8b192a9eab38"] = "WorldEntities/Doodads/Land/Tropical Plant 7a";
        data["75472574-a336-4c64-94af-f2abe1919316"] =
            "WorldEntities/Doodads/Debris/Aurora/Rooms/CrashedShip_entrance_01_01";
        data["75551770-da1f-4fc3-b3c5-ffbb11aaf903"] =
            "WorldEntities/Doodads/Lost_river/lost_river_skull_coral_group_02";
        data["757999b1-6f32-4b13-b2d0-2ad6ceb3bc2e"] =
            "WorldEntities/Doodads/Coral_reef/Coral_reef_blue_barnacles_01_01";
        data["758476f0-c50b-4fc8-aebd-131dd32a9959"] = "WorldEntities/Slots/BloodKelp_Trench/BloodKelp_Loot_Floor";
        data["7598ec81-8e3d-4222-b7a8-f3982b445db8"] = "WorldEntities/VFX/xLavapoleEruption";
        data["75ab087f-9934-4e2a-b025-02fc333a5c99"] = "WorldEntities/Doodads/Land/Tropical Plant 10a";
        data["75ae187a-3b06-402d-a23f-eadd6b9c3131"] = "WorldEntities/Atmosphere/MushroomForest/GiantCoralTree_Box";
        data["75eda95a-4d67-4a75-9e32-8b60dd0b3d15"] = "WorldEntities/Slots/LostRiver/Canyon/Canyon_Creature_Wall";
        data["75f30b7d-d793-4cdb-bbbe-dee5cf796382"] =
            "WorldEntities/Doodads/Coral_reef/Coral_reef_small_blue_fans_01_03";
        data["76017dd0-d7d0-425a-a0fc-36e9d5e64790"] =
            "WorldEntities/Lights/LostRiver/Point_Lostriver_blueplants_small";
        data["7637d968-4878-46a5-adf5-aa9e21fe3ddc"] = "WorldEntities/Natural/FloatingStone6_Floaters";
        data["7646d66b-01c0-4110-b6bf-305df024c2b1"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/Starship_cargo_damaged_02";
        data["76470f15-8918-4194-8191-4a40f1f3e32c"] = "WorldEntities/Doodads/Debris/Wrecks/Decoration/starfish_01";
        data["76825855-c939-48ae-812d-79b6d0529dd9"] = "WorldEntities/Doodads/Debris/Wrecks/ExplorableWreckHull02";
        data["769f9f44-30f6-46ed-aaf6-fbba358e1676"] = "Submarine/Build/BaseBioReactorModule";
        data["76a94e03-741a-4622-a049-4a06782dfe6a"] = "WorldEntities/Tools/Scanner";
        data["76e76754-2537-410e-8ba3-eab48e294631"] =
            "WorldEntities/Atmosphere/LostRiver/TreeCove/LostRiver_Tree_Cove_Treeopen_Sph";
        data["770dd0ea-5473-427b-b3fa-ef38ec2f72c2"] =
            "WorldEntities/Environment/Precursor/Prison/TeleporterRooms/Precursor_Prison_TeleporterHallway03_Lights";
        data["7720bfa4-d470-4826-ba93-ee189c538eb2"] =
            "WorldEntities/Environment/Precursor/LostRiverBase/Precursor_LostRiverBase_Lab01_Bones";
        data["7738c63e-f4e2-475a-99a4-9ef755a60cc9"] = "WorldEntities/Slots/SafeShallows/SafeShallows_Loot_CrashHome";
        data["77561611-a372-480e-aa5a-fdb69acdd52d"] = "Submarine/Build/NuclearReactor";
        data["775b6835-bd08-40d2-b80e-ab0ddc539c45"] =
            "WorldEntities/Doodads/Coral_reef/Coral_reef_tree_mushrooms_01_02";
        data["775e3e0a-9670-43a0-a182-5d000ad8d60a"] =
            "WorldEntities/Atmosphere/LostRiver/BonesField/LostRiver_BonesField_Lake_Nosurface";
        data["775feb4c-dab9-4322-b4a5-a4289ca1cf6a"] = "Submarine/Build/Locker";
        data["777c5fe6-98d5-4d58-9790-ff57fea62e7c"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/starfish_01_bend";
        data["778a732b-159c-42fe-a0c2-2db9e8282519"] = "WorldEntities/Doodads/Coral_reef/Crab_snake_Lower_plate_01_03";
        data["779d4bbe-6e34-4ca5-bee5-b32d65288f5f"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/submarine_locker_04_door";
        data["779ef413-44b0-4eab-b94c-dfaadb1d2df0"] = "WorldEntities/Natural/mercuryore";
        data["77a95f14-434e-46bd-8fbb-0a7c591849c3"] = "WorldEntities/Doodads/Coral_reef/Coral_reef_kelp";
        data["77ce831b-93c1-4567-adcd-2c9827da292c"] = "WorldEntities/Doodads/Debris/Wrecks/ExplorableWreckRoom05";
        data["77cf3938-0707-4ac9-ad3f-ba3d985d433d"] = "WorldEntities/Slots/SafeShallows/SafeShallows_Loot_CaveFloor";
        data["77ea8ae6-db93-43f3-bb30-0e0c45f1587f"] = "WorldEntities/Slots/GrandReef/GrandReef_Loot_Grass";
        data["78009225-a9fa-4d21-9580-8719a3368373"] = "WorldEntities/Doodads/Precursor/precursor_deco_props_01";
        data["7800c39a-e283-4854-ae83-1b97253ecc0d"] =
            "WorldEntities/Slots/JellyshroomCaves/Jellyshroom_Creature_CaveWall";
        data["7815b1b7-2830-418b-9b5d-19949b0ae9ec"] = "WorldEntities/Natural/nickel";
        data["78335ef4-78e2-44d4-9288-b1a6852b0be4"] = "WorldEntities/Fragments/Old/batterychargerfragment_old";
        data["783442e1-d2ad-4967-a452-722a01f20258"] = "Submarine/Build/SolarPanel";
        data["7835815a-da3b-474a-8585-8716c637bae6"] = "WorldEntities/Tools/PlasteelTank";
        data["783da399-4fdb-44e1-b8d8-f0a1abd6a41c"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/docking_food_01_milk_group2";
        data["7842e723-43a0-4579-9d0d-ce4de2bf79d9"] = "WorldEntities/Slots/KelpForest/KelpForest_Creature_CaveWall";
        data["784310de-5416-4cde-9cf1-c7d6694fa477"] = "WorldEntities/Atmosphere/SparseReef/Spikes";
        data["7879c3ab-3165-4f2f-bc52-dcf6a0f393c5"] =
            "WorldEntities/Environment/Precursor/LostRiverBase/Precursor_LostRiverBase_Aquarium";
        data["78868f58-fc67-4b7f-a9c0-ca7f7ad4cd09"] =
            "WorldEntities/Slots/GrassyPlateaus/GrassyPlateaus_Creature_CaveWall";
        data["78afcc32-7963-4939-a894-52a69a8faa9b"] = "WorldEntities/VFX/xSparksOrange_1s_Small";
        data["78c0a62c-1da5-4bcd-9ec4-89310d5b449b"] = "WorldEntities/Doodads/Coral_reef/Coral_reef_shell_02_06";
        data["78c36ef3-ba45-4aa0-a190-f7fdabbc72c6"] = "WorldEntities/Environment/SnoozeBall";
        data["79134868-2f8e-4f43-a99f-a6fb8ce60b48"] =
            "WorldEntities/Doodads/Coral_reef_Light/Coral_reef_Gabe's_Feather";
        data["79134cca-9eb5-4af0-8fa3-ff15565d7117"] = "WorldEntities/Fragments/Seamoth_Fragment";
        data["7935a15e-a9ab-4fc6-90ef-58a65b30a4bd"] =
            "WorldEntities/Doodads/Coral_reef/coral_reef_Hanging_Stinger_short";
        data["793b4079-ef3b-43da-9fc7-3ec5cbc3ae19"] = "WorldEntities/Natural/drillable/DrillableSalt";
        data["79473a2c-0dc6-4131-bb1a-356e63a03ee7"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/Base_interior_Planter_Tray_01_empty_deco";
        data["79527fc2-7037-41c0-9e3d-e003f3cd0b06"] =
            "WorldEntities/Doodads/Coral_reef/Coral_reef_tree_mushrooms_02_02";
        data["7957d621-5a0a-4f98-8c0e-272e7c2cb1b1"] = "WorldEntities/Slots/LavaLakes/LavaLakes_Loot_Floor_Far";
        data["79596c23-0631-494c-a1ee-08c205167d05"] = "WorldEntities/Slots/KooshZone/KooshZone_Loot_EscapePod_Small";
        data["795f152e-6cd6-4b07-aed9-1aa13e448d72"] =
            "WorldEntities/Environment/Wrecks/ExplorableWreck_SafeShallows_16_WeldablePanelRoot";
        data["7965512f-39fe-4770-9060-98bf149bca2e"] = "WorldEntities/Natural/Glass";
        data["7977185e-b949-4a6f-8ed6-95c6dc3c2af9"] = "WorldEntities/Atmosphere/Ship/CrashedShip_Interior_Power";
        data["798821b1-cafd-4e6b-8ae1-a810d34e3d3c"] = "WorldEntities/Food/CookedOculus";
        data["79c1aef0-e505-469c-ab36-c22c76aeae44"] = "WorldEntities/Creatures/Eyeye";
        data["79cba5e2-4322-4ba1-b35b-a2a08db6dd45"] = "WorldEntities/Slots/ILZChamber/ILZChamber_Loot_CorridorWall";
        data["79ce1a3a-a308-47a6-adc5-9dfb662b0850"] = "WorldEntities/Tools/Constructor_damaged_01";
        data["7a08a846-d38c-4d2a-87d2-a9c069963000"] =
            "WorldEntities/Environment/Precursor/Precursor_PurpleKeyTerminal_LavaBase";
        data["7a5a19ed-bbde-4d45-9e44-cbd56784badb"] = "WorldEntities/Slots/JellyshroomCaves/Jellyshroom_Loot_CaveWall";
        data["7a616910-4aa2-4db0-a04c-eea9e72060e3"] = "WorldEntities/Doodads/Coral_reef/Coral_reef_green_mohawk_04";
        data["7a9071d7-e7e7-48cb-8c93-b02621517a65"] = "WorldEntities/Doodads/Debris/Starship_exploded_debris_32";
        data["7a973d10-ad9c-4bdb-8443-7e275d8744b5"] = "WorldEntities/Seeds/PurpleBrainCoralPiece";
        data["7a988879-1136-4035-9e51-a151567417ce"] = "WorldEntities/Fragments/Old/constructorfragment_old";
        data["7abd128f-0952-4ad6-98a8-3bdd570f4281"] = "Submarine/Build/Submarine_hull_fragments_06";
        data["7abfd32b-3501-4f04-b8bd-8e374dbeb3ff"] =
            "WorldEntities/Slots/KooshZone/KooshZone_Loot_KooshZone_Mountains";
        data["7ae6b81a-7c46-4c0b-a895-e056a8a3b2f7"] = "WorldEntities/Environment/Aurora/Aurora_Elevator_Surface_Lower";
        data["7b019de0-db51-4017-8812-2531b808228d"] = "WorldEntities/Tools/Beacon";
        data["7b1a07c6-3795-45a3-b2a0-3cc9f4067a01"] =
            "WorldEntities/Slots/seaTreaderPath/SeaTreaderPath_Loot_Techsite_Medium";
        data["7b37c9ff-fc7d-4a75-b2d5-d44e80bff9cc"] = "WorldEntities/Lights/Mountains/Mountains_YellowPlant_SM";
        data["7b4b90b8-6294-4354-9ebb-3e5aa49ae453"] = "Submarine/Build/BasePipeConnector";
        data["7b4f3dbe-f994-4f95-895a-014ed80f959b"] = "WorldEntities/Slots/Mountains/Mountains_Loot_CaveFloor";
        data["7b5d74e6-8706-4ec6-9b7d-3b72be9193e4"] = "WorldEntities/Seeds/Gabe'sFeatherSeed";
        data["7b6bb412-e8f3-4706-ae6f-1429622edd43"] =
            "WorldEntities/Slots/LostRiver/BonesField/BonesField_Loot_LakePit_Floor";
        data["7b8e9633-45a3-4542-93e2-34001523cac9"] = "WorldEntities/Doodads/Debris/Starship_exploded_debris_15";
        data["7ba62f82-4371-4292-bbe7-b1b095bb21b4"] =
            "WorldEntities/Slots/seaTreaderPath/SeaTreaderPath_Creature_Path";
        data["7bfe0629-a008-43b8-bd16-d69ad056769f"] =
            "WorldEntities/Doodads/Coral_reef/Coral_reef_Kelp_blood_small_plants_01";
        data["7c0a2068-94f1-4f47-8417-c1793fc6997c"] =
            "WorldEntities/Slots/Prison/Aquarium/PrisonAquarium_Creature_CaveCeiling";
        data["7c1aa35f-759e-4861-a871-f58843698298"] = "WorldEntities/Tools/StasisRifle_damaged";
        data["7c5425d4-2339-436c-822a-d6b3922b489a"] = "WorldEntities/Doodads/Lost_river/Lost_river_generic_bone_10";
        data["7c55e785-a250-41ae-869d-c4be026f9ce6"] = "WorldEntities/Doodads/Coral_reef/Coral_reef_green_reeds_04";
        data["7c6d23d1-4d59-49f8-ac12-b12dfa530beb"] =
            "WorldEntities/Doodads/Coral_reef_Light/Coral_reef_purple_tentacle_plant_01_01_Light";
        data["7c7e0e95-8311-4ee0-80dd-30a61b151161"] = "WorldEntities/Doodads/Coral_reef/Coral_reef_small_deco_02";
        data["7cb6f726-dac0-41e8-8d4a-8111b26aa647"] =
            "WorldEntities/Slots/LostRiver/BonesField/BonesField_Loot_Corridor_Ground";
        data["7ccc9ac6-278d-4c25-bcd4-9db9d43a25b5"] =
            "WorldEntities/Doodads/Debris/Aurora/Decoration/Signs/Aurora_JHallway_DriveRoom_Sign2";
        data["7ccfeb6c-d5cd-4006-aa6e-d0a71c614b43"] = "WorldEntities/Atmosphere/JellyshroomCaves/Caves (Sphere)";
        data["7cd0f4c7-7abc-4292-92bc-f2d486d999dd"] = "WorldEntities/Slots/GrandReef/GrandReef_Creature_OpenShallow";
        data["7cd2450b-346c-4996-85d2-7d6b5efa51f8"] = "WorldEntities/Tools/PowerTransmitter_damaged";
        data["7cd86cbf-0708-41dc-84d7-58c648e25b06"] = "WorldEntities/Natural/metal3";
        data["7cdcbed0-7d20-43c4-beb4-f1ad539b2a76"] = "Submarine/Build/Goldglove_car_01";
        data["7ce2ca9d-6154-4988-9b02-38f670e741b8"] = "WorldEntities/Creatures/CaveCrawler_02";
        data["7ce34088-79eb-4d90-9d47-3231c6ee8aab"] = "WorldEntities/Fragments/exosuit_04_old";
        data["7ce83863-b4f2-4d46-9f46-1830799f3e5f"] = "WorldEntities/Doodads/Coral_reef/coral_reef_plant_small_02";
        data["7cf0523e-20f4-4230-aa95-8d98eee2e05b"] = "WorldEntities/Slots/Mountains/Mountains_Loot_IslandSand";
        data["7d11df51-b70f-431a-a68f-495e0cae2459"] =
            "WorldEntities/Doodads/Debris/Wrecks/ExplorableWreckRoom05_aurora";
        data["7d19f47b-6ec6-4a25-9b28-b3fd7f5661b7"] = "WorldEntities/Doodads/Precursor/PrecursorKey_Red";
        data["7d307502-46b7-4f86-afb0-65fe8867f893"] = "WorldEntities/Environment/Crash";
        data["7d36a1fd-8aa1-4b32-9e05-23176e119f5f"] = "WorldEntities/Doodads/Land/Tropical Plant 3b";
        data["7dabf6dc-0746-4aa5-85ee-0842e100cd5d"] =
            "WorldEntities/Slots/SparseReef/SparseReef_Loot_EscapePod_Medium";
        data["7db4c83e-3334-42ed-af73-ce475650e003"] = "WorldEntities/Lights/Koosh Zone/Koosh_huge_blue_grp";
        data["7dc46c79-1907-4161-808a-8d473155a876"] = "WorldEntities/Slots/SparseReef/SparseReef_Creature_DeepFloor";
        data["7e07fce9-0ad6-4c54-9da7-e43eb1e38cea"] = "WorldEntities/Natural/limestone";
        data["7e164f67-f4e7-41fc-98a5-7a84ccaa1d09"] = "WorldEntities/Natural/polyaniline";
        data["7e1e5d12-7169-4ff9-abcd-520f11196764"] = "WorldEntities/Doodads/Precursor/Gun/IonCrystalPedestal";
        data["7e507655-9fbf-42e0-8422-163ddd668747"] = "WorldEntities/Natural/metal2";
        data["7e5d948c-9bf5-4b3d-8f71-9d7cbcf84991"] = "WorldEntities/Environment/Wrecks/ExplorableWreck_Grassy_1";
        data["7e6dd56a-d93e-4df3-974e-bc212f802f04"] = "WorldEntities/Slots/CrashZone/CrashZone_Loot_Sand";
        data["7e710d20-acf0-45e2-a8b8-3b75bd6179a4"] = "Submarine/Build/submarine_steering_console_base_02_fragments";
        data["7e740bc9-6c2f-4597-b302-3129b9d9e28d"] = "WorldEntities/Environment/Prototype/Echo";
        data["7e74d18a-210a-47f1-af04-7b33b7728e93"] = "WorldEntities/Environment/Wrecks/PDAs/Wreck10_GrandReef_PDA1";
        data["7e998b10-d5a1-4e0d-8462-9807963a30c7"] =
            "WorldEntities/Doodads/Debris/Aurora/Decoration/Signs/Aurora_Lockers_Robotics_Sign";
        data["7ea4a91e-80fc-43aa-8ce3-5d52bd19e278"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/descent_arcade_gorgetoy_01";
        data["7eaf11d3-5b65-4325-a249-d69c7cc838b0"] = "WorldEntities/Environment/Wrecks/baseupgradeconsolefragment1";
        data["7eb8e770-0e14-4389-acb2-536b484872b2"] = "WorldEntities/Atmosphere/Dunes/Dunes_Wreck_Adjust";
        data["7eb8fe38-1706-427d-9ee8-fed834c1bb13"] = "WorldEntities/Environment/Wrecks/EscapePod_6_GrassyPlateaus";
        data["7ec3cd94-4981-4877-be57-e7bfdfbbce00"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/starship_girder_09";
        data["7ec6dc08-6324-4269-93a2-5f3974abd7ec"] =
            "WorldEntities/Doodads/Precursor/Precursor_cube_03_damaged_piece_01";
        data["7ecc9cdd-3afc-4005-bff7-01ba62e95a03"] = "WorldEntities/Doodads/Coral_reef/coral_reef_small_deco_12";
        data["7ee19c38-18f4-4a4e-8375-6645d95a15bb"] = "WorldEntities/Slots/ILZCastle/ILZCastle_Loot_TunnelWall";
        data["7f031c45-3f4e-45c3-8fc9-bef318fc2c1d"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/Starship_big_gate_doors_01_R";
        data["7f1e0c09-f34b-4628-842e-11bbd153b79d"] =
            "WorldEntities/Doodads/Lost_river/LostRiverBase/Lost_river_hanging_plant_02_03";
        data["7f4525ec-110b-42fd-9b36-eede1480f07d"] =
            "WorldEntities/Doodads/Coral_reef/Coral_reef_small_blue_fans_01_cluster";
        data["7f601dd4-0645-414d-bb62-5b0b62985836"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/biodome_lab_containers_tube_01";
        data["7f634f58-87a7-48ec-9414-2834d37d2b05"] =
            "WorldEntities/Doodads/Precursor/precursor_cables_start_prison_exterior";
        data["7f63fa1b-2103-47d6-98ee-44dff7c52566"] = "WorldEntities/Natural/AdvancedWiringKit";
        data["7f656699-358a-416d-9ecd-f911e3d51bf1"] = "WorldEntities/Doodads/Coral_reef/Coral_reef_shell_plates_01_01";
        data["7f6694cb-5f4c-4ec1-9001-5c1eacffa725"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/descent_bar_seat_curved_02";
        data["7f673d9f-0d08-4c3b-a229-d3124c0ac197"] = "WorldEntities/Environment/Wrecks/cyclopshullfragment4";
        data["7f69484a-f949-4303-b6f5-f3aad4934fb9"] =
            "WorldEntities/Slots/JellyshroomCaves/Jellyshroom_Creature_CaveSand";
        data["7f7de4d4-045c-4d2f-ad63-222d8b320f25"] = "WorldEntities/Environment/Wrecks/ExplorableWreck_KooshZone_1";
        data["7f8f3765-ed35-4bfc-8804-19392703411a"] = "Base/Ghosts/BaseCorridorI";
        data["7f9a765d-0b4e-4b3f-81b9-38b38beedf55"] = "WorldEntities/Doodads/Land/land_plant_small_03_01";
        data["7f9d8792-67ba-4c1d-b174-ec62c14dfe41"] = "WorldEntities/Natural/KelpForestEgg";
        data["7fa19a25-748c-4090-9243-2eb30b2f06b4"] =
            "WorldEntities/Environment/DataBoxes/CyclopsSonarModuleDataboxSpawner";
        data["7fa8a112-29ed-4b1f-842d-bef241658592"] =
            "WorldEntities/Doodads/Coral_reef/coral_reef_brown_coral_tubes_02_05";
        data["7fc4b842-4b08-4788-9dfb-4e2499ef11c5"] = "WorldEntities/Tools/Constructor_damaged_02";
        data["7fcf1275-0687-491e-a086-d928dd3ba67a"] = "WorldEntities/Seeds/SnakeMushroomSpore";
        data["80122eca-8265-484a-b4ae-0780a3e5d9cb"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/fireextinguisher_holder";
        data["801ca45e-eab9-4602-9e85-de5c708d58d4"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/docking_chalkboard_01";
        data["8029a9ce-ab75-46d0-a8ab-63138f6f83e4"] =
            "WorldEntities/Environment/Wrecks/submarine_Workbench_damaged_01";
        data["80760d84-a744-4427-96d7-ae4c23917955"] = "WorldEntities/Slots/LavaFalls/LavaFalls_Creature_Floor";
        data["807ead20-0974-4684-9be9-525b3f44aa2d"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/Spotlight_rusted";
        data["80b96194-7b5f-4e0a-a75a-83fb8af1af0c"] = "WorldEntities/Doodads/Coral_reef/coral_reef_small_deco_09_huge";
        data["80bf1cc6-d627-47a1-b4b4-33f47e59231c"] = "WorldEntities/Environment/Wrecks/exosuitfragment2";
        data["80cacf79-a7f0-40fe-9d65-f1180777331f"] = "WorldEntities/Atmosphere/FloatingIslands/CaveTeleporter_Sph";
        data["80d3846f-617a-4c4a-9e8f-15db2d55fb04"] = "WorldEntities/Environment/Wrecks/ExplorableWreck_Grassy_35";
        data["80f6c46a-ecfe-4a19-b05f-0466eafde411"] =
            "WorldEntities/Environment/Precursor/LostRiverBase/Precursor_LostRiverBase_Balcony";
        data["811c128d-a85f-4b0a-b9c4-4071db4fb7aa"] = "WorldEntities/Tools/PrecursorIonBattery";
        data["812c84dd-0175-4fbc-95d8-ccc397c6ca91"] = "WorldEntities/Doodads/Precursor/Precursor_Prison_exterior";
        data["814beddb-62cf-4c55-a86d-5da0684932a8"] =
            "WorldEntities/Doodads/Precursor/precursor_column_maze_08_12_08_v3_doodad";
        data["814fa303-8697-48ef-b126-cf22e703cefd"] = "WorldEntities/Natural/shale";
        data["815b7bed-9b94-45fa-bbfe-a8137af84012"] =
            "WorldEntities/Slots/LostRiver/GhostTree/GhostTree_Creature_Ground_Lower";
        data["81713004-b3a1-4fcb-8fa8-ac7b332505d0"] =
            "WorldEntities/Atmosphere/LostRiver/TreeCove/LostRiver_Tree_Cove_Treeopen";
        data["817eef98-97af-4f88-b87b-f489b59c55b8"] = "WorldEntities/Fragments/Constructor_Fragment_InCrate";
        data["8184c355-7517-40f9-8238-0e89da132bbe"] =
            "WorldEntities/Environment/Precursor/LostRiverBase/Precursor_LostRiverBase_Balcony_Decals";
        data["8186126e-6fb0-4fa1-ae50-24dab775860d"] =
            "WorldEntities/Doodads/Coral_reef/Coral_reef_tree_mushrooms_connector_02";
        data["81cf2223-455d-4400-bac3-a5bcd02b3638"] =
            "WorldEntities/Environment/Precursor/LavaCastleBase/Precursor_LavaCastleBase_TechConsole";
        data["81db652d-acdd-444b-9ad6-f58f94776a12"] = "WorldEntities/Atmosphere/KooshZone/Kooshzone_Wreck_Adjust";
        data["81f4c0f8-73b5-453a-a3b9-ce761c023f39"] = "WorldEntities/Doodads/Lost_river/lost_river_skull_coral_06";
        data["822471ff-5e2e-40cb-9407-195222c14375"] =
            "WorldEntities/Slots/Ship/Loot_ShipInterior_AuxPowerRoom1_Barrier_Small";
        data["82287160-87eb-4fdd-ae33-945ba666ae60"] = "WorldEntities/Doodads/Coral_reef/Spiral_blue_thing_cluster_07";
        data["823d390b-65dc-48dd-9f54-824429acd4e2"] = "WorldEntities/Tools/SeamothSolarCharge";
        data["82680915-779d-4a84-8788-7fc92a2f9c39"] = "WorldEntities/Slots/SparseReef/SparseReef_Loot_Spike";
        data["82d02229-5c5d-4c0c-a610-bef8c0c184cd"] =
            "WorldEntities/Environment/Precursor/Prison/DissectionRoom/Precursor_Prison_DissectionRoom_Visblocker";
        data["82db2f2d-317e-48a8-b343-02e979ab8c4c"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/vent_constructor_deadend_01_fan";
        data["82e8faf8-8065-4f2a-bcbb-787cf9c64735"] = "WorldEntities/Slots/LostRiver/Junction/Junction_Loot_Ceiling";
        data["82ec89b3-43c9-42e2-9a6e-b52843cec433"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/descent_bar_sofa_corner_01";
        data["82fb3db2-35b6-484d-9f6b-93f2f04c22ce"] =
            "WorldEntities/Slots/LostRiver/GhostTree/GhostTree_Creature_Grass";
        data["83092048-c4d9-4ef0-9aa9-faf7a38fbcb3"] =
            "WorldEntities/Slots/LostRiver/Junction/Junction_Creature_Ceiling";
        data["830a8fa0-d92d-4683-a193-7531e6968042"] = "WorldEntities/Creatures/CaveCrawler_03";
        data["830c7d77-b3dd-4acf-8413-20d1441c45f2"] = "WorldEntities/Environment/Precursor/Precursor_TeleporterStand";
        data["83190e0d-d632-4b18-9906-6ad1b91f3315"] = "Submarine/Build/Bioreactor";
        data["832c6e91-ff99-4be9-a28e-0a080d58c490"] =
            "WorldEntities/Slots/Mountains/Mountains_Loot_Techsite_Barrier_Small";
        data["834ac899-97b4-4617-b9a1-027ad36c69c1"] = "WorldEntities/Doodads/Coral_reef/Coral_reef_shell_03";
        data["834bff32-e293-41b4-9113-742aa1b30f0a"] = "WorldEntities/Slots/LostRiver/GhostTree/GhostTree_Loot_Ceiling";
        data["837f01e9-d36e-43b3-b886-02db51a82db2"] = "WorldEntities/VFX/xGeyser_Warning";
        data["83832e10-e0aa-4bc7-9257-6d43acd7fc32"] = "WorldEntities/Slots/GrandReef/GrandReef_Loot_TechSite";
        data["838f1b65-1ec4-43d1-b581-4fc476d22b79"] =
            "WorldEntities/Slots/MushroomForest/MushroomForest_Creature_GiantTreeInteriorWall";
        data["83a70a58-f7da-4f18-b9b2-815dc8a7ffb4"] =
            "WorldEntities/Environment/Precursor/Cache/Precursor_SkeletonCaveCache_DoorTerminalsRoot1";
        data["83b5f4fb-00ef-4d0e-8243-693a95685663"] =
            "WorldEntities/Environment/Precursor/Prison/DissectionRoom/Precursor_Prison_Antechamber_UpperEntryRoom_Old";
        data["83b61f89-1456-4ff5-815a-ecdc9b6cc9e4"] = "WorldEntities/Fragments/PrecursorKey_PurpleFragment";
        data["83cd6229-f586-4073-a8cd-0fab70dddb61"] =
            "WorldEntities/Lights/Mushroom Forest/BlueTentacle_light_large_amb";
        data["83f68b50-b037-4654-91db-2b378b67adeb"] = "WorldEntities/Doodads/Land/land_plant_middle_06_02";
        data["8407a3a8-62e0-4733-9a6b-2350d60f3161"] = "WorldEntities/Environment/Wrecks/EscapePod_4_CrashZone";
        data["8409a079-a96c-43d3-a891-af500b04e0af"] = "WorldEntities/Doodads/Coral_reef/Coral_reef_Gabe's_Feather";
        data["84264e4b-1302-48d5-9031-f8f148f63674"] =
            "WorldEntities/Doodads/Precursor/TempGun_Interiors/Precursor_Gun_Teleporter_Room_Lights";
        data["84478cad-1dee-4799-9a93-f357d91a21d6"] =
            "WorldEntities/Environment/Aurora/Consoles/Wreck_Mountains_5_Console";
        data["846c3df6-ffbf-4206-b591-72f5ba11ed40"] = "WorldEntities/Natural/drillable/DrillableLithium";
        data["8478a738-68f1-4f1d-9773-73060858d372"] = "WorldEntities/Slots/KooshZone/KooshZone_Creature_CaveWall";
        data["84794dd0-2c70-4239-9536-230d56811ad4"] = "WorldEntities/Doodads/Coral_reef/Coral_reef_Spike_Plant";
        data["84870949-8029-4971-97f8-f1d740b45e13"] = "WorldEntities/Doodads/Debris/Starship_exploded_debris_27";
        data["849a6641-0f0f-4973-9b86-e249935833b7"] = "WorldEntities/Slots/KooshZone/KooshZone_Loot_Coral";
        data["84bf5910-bbf1-495f-bd41-bb03808936dd"] = "WorldEntities/Slots/CragField/Cragfield_Loot_Grass";
        data["84f47431-8a5e-4f01-895d-3aa30004090f"] =
            "WorldEntities/Slots/ILZChamber/ILZChamber_Creature_ChamberUnique";
        data["85259b00-2672-497e-bec9-b200a1ab012f"] = "WorldEntities/Doodads/Fragments/Moon_Pool_fragment_02";
        data["852ea34b-e474-4ae8-9386-88c9228feffa"] = "WorldEntities/Seeds/SeaCrownSeed";
        data["853a9c5b-aba3-4d6b-a547-34553aa73fa9"] = "WorldEntities/Natural/drillable/DrillableKyanite_Large";
        data["8541a9a6-5fe2-48d9-9fed-23072d71e4b6"] =
            "WorldEntities/Slots/SafeShallows/SafeShallows_Loot_TechSite_Barrier_Medium";
        data["8569a45b-487c-4229-87bc-c11d6fbcdc21"] =
            "WorldEntities/Slots/GrassyPlateaus/GrassyPlateaus_Creature_Grass";
        data["856e37e0-edeb-431f-aca7-696a5ba55787"] = "WorldEntities/Fragments/exosuit_02_old";
        data["858a65ad-036c-4dc7-a99d-958f176fa730"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/explorable_wreckage_modular_wall_details_06";
        data["8591f5a5-0a38-441c-b1a3-03e04b5cc9e2"] =
            "WorldEntities/Doodads/Debris/Aurora/Decoration/Signs/Aurora_Seamoth_Bay2_Sign";
        data["85ae70e0-176c-4de6-8c4d-48c4f504cc79"] = "WorldEntities/Environment/Wrecks/life_pod_exploded_6";
        data["85babb55-9dc6-41a2-8e33-d3117f775bef"] =
            "WorldEntities/Doodads/Lost_river/LostRiverBase/Lost_river_hanging_plant_04_03";
        data["85e70a4c-0df4-4c38-9901-c3f7b4e9c2c1"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/descent_bar_seat_curved_01";
        data["861af739-4f21-4aa6-a3f3-59584f821c1a"] = "WorldEntities/Slots/Ship/Loot_ShipInterior_Corridor_Barrier";
        data["862b4c7c-c2c2-4d7e-a1cd-4d1bb2f2001e"] = "WorldEntities/Atmosphere/SparseReef/Cave";
        data["864f7780-a4c3-4bf2-b9c7-f4296388b70f"] = "Submarine/Build/BaseNuclearReactorModule";
        data["865167a9-e753-4ff4-99cd-0c71694dbc68"] = "WorldEntities/Doodads/Precursor/Cable_02";
        data["86589e2f-bd06-447f-b23a-1f35e6368010"] = "WorldEntities/Natural/EnameledGlass";
        data["867ca1f8-3d85-48e3-b6b4-ac32e3066f06"] = "WorldEntities/Doodads/Lava/lava_rock_01_03";
        data["86847621-c2ed-43ad-98ff-59276552c48f"] = "WorldEntities/Environment/Wrecks/PDAs/Wreck6_Dunes_PDA1";
        data["86cde4b3-0b29-4d03-b20c-de303a005298"] =
            "WorldEntities/Doodads/Precursor/Gun/Precursor_Gun_RampLog_Animated";
        data["86deccd0-7ba0-4011-9491-3d4483a210ed"] = "WorldEntities/Doodads/Debris/Starship_exploded_debris_34";
        data["86e92740-cba0-472a-b73b-85219ed785b1"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/explorable_wreckage_modular_room_details_21";
        data["86f262ce-9f68-4f6a-81da-58e7ad5f3a09"] = "WorldEntities/Slots/Mountains/Mountains_Loot_IslandCaveWall";
        data["86f9c393-1a4b-48a1-b9ca-76b583adaf7e"] = "WorldEntities/Lights/Precursor/Precursor_Cave_Light_Shadows";
        data["871a5ca9-1f2e-4124-8f1e-fac967a464b8"] = "WorldEntities/Doodads/Precursor/precursor_prison";
        data["871b7a1f-1b43-487f-87af-877fb6260613"] = "WorldEntities/Environment/Wrecks/constructorfragment4";
        data["8723387c-c9aa-4f7b-83a9-86afe91b829b"] = "WorldEntities/Doodads/Debris/Starship_exploded_debris_37";
        data["87293f19-cca3-46e6-bb3d-6e8dc579e27b"] = "WorldEntities/Natural/aluminumoxide";
        data["8729579b-209d-4f63-9cae-1c69721dc9b6"] =
            "WorldEntities/Slots/MushroomForest/MushroomForest_Loot_GiantTreeRoot";
        data["872b7c65-7597-4ca2-9c96-03b2405b8784"] = "WorldEntities/Environment/Wrecks/Nuclear_reactor_damaged_04";
        data["872c799a-4de2-4531-a846-3b362d666e0b"] =
            "WorldEntities/Doodads/Debris/Wrecks/explorable_wreckage_modular_wall_01";
        data["875b8533-c60a-4c96-9c66-921240cf873f"] = "WorldEntities/Slots/LostRiver/Canyon/Canyon_Creature_Grass";
        data["8760e64e-4440-4ed6-9084-e40a19f846c5"] = "WorldEntities/Slots/Dunes/Dunes_Loot_Techsite_Scatter_Medium";
        data["876cbea4-b4bf-4311-8264-5118bfef291c"] = "WorldEntities/Environment/Wrecks/poster_aurora";
        data["87768517-0e25-4bb6-8dd3-033215cbcb6c"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/vent_constructor_deadend_01";
        data["8798f4c7-f13d-4a8e-9947-b4f7fc1f1bae"] = "WorldEntities/Doodads/Land/Tropical Plant 7b";
        data["87998059-44ba-4a69-8d74-781164b451ef"] = "Submarine/Build/Submarine_hull_fragments_08";
        data["87a37721-3fb1-47a8-8270-be9309ed7d6d"] = "WorldEntities/Slots/GrandReef/GrandReef_Loot_Ground";
        data["87bed900-023c-4dab-b9c5-3fa75dbae501"] = "WorldEntities/Slots/Ship/Loot_ShipInterior_ExoRoom_Small";
        data["87f5d3e6-e00b-4cf3-be39-0a9c7e951b84"] = "Submarine/Build/PlanterBox";
        data["87f8fd44-43ca-44df-94c6-28b5962a6524"] =
            "WorldEntities/Doodads/Lost_river/Lost_river_hanging_plant_02_01";
        data["88060ec8-9698-40a0-9fbc-4026285d52a0"] = "WorldEntities/Lights/Koosh Zone/KooshCave_blue_amb_lrg";
        data["880b59b7-8fd6-412f-bbcb-a4260b263124"] = "WorldEntities/Doodads/Coral_reef/coral_reef_grass_kelp_01";
        data["880b6978-249f-4cdb-ae35-ca8f0a069f21"] = "WorldEntities/Environment/SandFall_Long";
        data["882a9d32-ef0a-40b2-a636-835ff4dfef6f"] = "WorldEntities/Slots/KelpForest/KelpForest_Creature_GrassSparse";
        data["8861b7cf-3c7b-481e-b4ff-83b49206acb8"] = "WorldEntities/Doodads/Land/Tropical Plant 2a";
        data["886b5161-0830-48e7-9318-af78d613d510"] = "WorldEntities/Atmosphere/KooshZone/Kooshcave_trans_green_box";
        data["8881073d-b91a-480e-a257-47c7ac73b972"] =
            "WorldEntities/Slots/ILZChamber/ILZChamber_Creature_MagmaTree_Open";
        data["88c4c1fa-0b52-44cb-9db5-2ef18447ae5c"] = "WorldEntities/Environment/Wrecks/Thermal_reactor_damaged_01";
        data["88c9a16a-0bcd-4b11-85e1-bd0f510fb777"] = "WorldEntities/Environment/Aurora/PDAs/Aurora_Locker_PDA1";
        data["88cad316-cebe-4ead-aae2-1ab31cae0de6"] =
            "WorldEntities/Doodads/Precursor/LavaBase/Precursor_LavaCastleBase_Ramp_Animated_Long";
        data["88cc155e-6ade-4be5-9946-b702c392495a"] = "WorldEntities/Atmosphere/SafeShallows/Caves (Sphere)";
        data["88e0deb1-e010-43b8-801b-ab5d527818a4"] = "WorldEntities/Environment/Wrecks/PDAs/Wreck2_Grassy_PDA1";
        data["88f282a6-9807-4362-b03a-76aad3210be3"] =
            "WorldEntities/Environment/Precursor/Prison/Moonpool/Precursor_Prison_Moonpool_Teleporter_ToAquarium";
        data["88fe862d-f2ae-4baa-9686-8a5f6db6c161"] = "WorldEntities/Slots/CrashZone/CrashZone_Creature_OpenDeep";
        data["890d44e1-e336-466b-89c8-cb7ea5ccbe83"] = "WorldEntities/Food/Snack1";
        data["890eb3bc-a37b-4aa6-a210-4217293c181d"] =
            "WorldEntities/Doodads/Precursor/TempGun_Interiors/Gun_LargeHallway_Lights";
        data["8914acde-168e-438f-9b2b-6b9332d8c1a1"] =
            "WorldEntities/Doodads/Coral_reef/coral_reef_Hanging_Stinger_long";
        data["8928dc78-e8fe-414d-aeff-e53709eb6930"] = "WorldEntities/Fragments/waterparkfragment";
        data["892b7d29-38b9-482e-83c5-ab324294ab53"] =
            "WorldEntities/Slots/seaTreaderPath/SeaTreaderPath_Loot_CaveFloor";
        data["8931d002-04e8-439a-a7cc-6cb4ee428fad"] = "WorldEntities/Lights/Koosh Zone/Koosh_Large_blue_single";
        data["8937dfc7-32cf-4e82-a604-fdb7e6629e7f"] = "WorldEntities/Slots/BloodKelp/BloodKelp_Creature_Wall";
        data["89422755-ec85-4d68-8005-a0b319346dcd"] = "WorldEntities/Atmosphere/JellyshroomCaves/Normal";
        data["8949b0da-5173-431f-a989-e621af02f942"] = "Submarine/Build/PowerTransmitter";
        data["89623db0-6928-4c61-b5ac-820f7f4890ee"] = "WorldEntities/Doodads/Debris/Starship_exploded_debris_23";
        data["898efb6d-b57b-41a3-9d3e-753fdc537651"] = "WorldEntities/Doodads/Coral_reef/Coral_reef_blue_coral_tubes";
        data["89d280c3-d451-4340-836a-5f82254857d0"] =
            "WorldEntities/Doodads/Coral_reef/Coral_reef_blue_barnacles_01_04";
        data["89db5325-9587-430a-af95-f27b185f9694"] =
            "WorldEntities/Slots/MushroomForest/MushroomForest_Creature_Grass";
        data["89fa1b49-c1dc-4a87-abba-49689f02a60c"] = "WorldEntities/Doodads/Debris/Wrecks/Decoration/starfish_03";
        data["8a1c0c58-6eb2-421a-9ca8-92290d5ad9fb"] = "WorldEntities/Slots/CrashZone/CrashZone_Creature_Sand";
        data["8a20ced7-bb7f-4de2-a51e-5de3e2655e3a"] = "WorldEntities/Fragments/Old/thermalplantfragment_old";
        data["8a211aaf-d471-48f0-b73f-eddc22b8c025"] = "WorldEntities/Eggs/CrabsnakeEgg";
        data["8a36cdf1-0606-4c05-861d-eb6d95d2a497"] = "WorldEntities/Atmosphere/GrandReef/ThermalVent";
        data["8a4a92d7-cef8-4ebc-acd2-5f025311b8a3"] =
            "WorldEntities/Slots/GrassyPlateaus/GrassyPlateaus_Creature_Wall";
        data["8a5fcbf6-e5d6-462d-8c3e-c074cdd0f8e8"] = "WorldEntities/Lights/SafeShallows/Bounce";
        data["8a746653-62b8-43af-b569-ff1e8ed1281f"] =
            "WorldEntities/Doodads/Coral_reef/Coral_reef_small_blue_fans_small_01_04";
        data["8aa03869-6224-4975-9b09-f6f449450caf"] = "WorldEntities/Doodads/Lost_river/Lost_river_tree_01_giant";
        data["8aaa6099-6aba-4129-806e-e8fc214bc0cd"] = "WorldEntities/Atmosphere/MushroomForest/Caves";
        data["8ab168d7-dce9-4a2f-bbbc-79c3b632776f"] = "WorldEntities/Doodads/Coral_reef/Crab_snake_mushrooms_06_06";
        data["8ae33569-27a7-4777-8840-db9b8e859fb0"] = "Submarine/Build/submarine_locker_02";
        data["8ae75c3a-30fb-455b-a2dc-bc21030947b2"] =
            "WorldEntities/Environment/Precursor/Prison/Antechamber/Precursor_Prison_Antechamber_MoonPoolDoor_Root";
        data["8aec9e03-ece1-49d8-81f3-156a2ccce172"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/explorable_wreckage_modular_room_details_03";
        data["8af09887-8da6-4f95-b562-ed217d7eedeb"] = "WorldEntities/Slots/SparseReef/SparseReef_Loot_DeepCoral";
        data["8af9af17-6165-4189-a021-64a6fc083b28"] =
            "WorldEntities/Slots/UnderwaterIslands/UnderwaterIslands_Creature_ValleyLedge";
        data["8b0f061a-2a5e-40b4-aa4c-2905d05e276d"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/docking_clerical_folder1";
        data["8b113c46-c273-4112-b7ef-65c50d2591ed"] = "WorldEntities/Tools/RocketBase";
        data["8b1f82ba-2c7b-48d0-91f0-f5be163af0aa"] = "WorldEntities/Atmosphere/KooshZone/Koosh_Defaultlight_Box";
        data["8b28a530-120d-4bd4-8861-975b48b01570"] = "WorldEntities/Doodads/Land/Tropical Plant 3a";
        data["8b3ba7af-cb8b-433e-9c48-cbff10b17fd3"] =
            "WorldEntities/Atmosphere/LostRiver/BonesField/LostRiver_BonesField_Corridor";
        data["8b3f0b6f-4c8e-466e-b3ae-9902c8ba1730"] = "WorldEntities/Natural/FloatingStoneMedium2";
        data["8b43e753-29a6-4365-bc53-822376d1cfa2"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/Starship_cargo_large";
        data["8b5e6a02-533c-44cb-9f34-d2773aa82dc4"] = "WorldEntities/VFX/x_PrecursorBase_WaterForceFieldEntrance";
        data["8ba14c3e-2264-47b8-8484-042b813ec484"] = "WorldEntities/Environment/Wrecks/ExplorableWreck_KooshZone_3";
        data["8ba3be30-d89f-474b-87ca-94d3bfff25a4"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/Starship_cargo_damaged_large_01";
        data["8baea884-a556-4281-93f6-bf65f195204a"] =
            "WorldEntities/Environment/DataBoxes/ReinforcedDiveSuitDataboxSpawner";
        data["8bc4f11e-17b9-447e-be0c-2fbe324e64f5"] = "WorldEntities/Seeds/PurpleTentacleSeed";
        data["8bcb03cb-02b2-4ad9-b25d-e8f152fe6744"] = "WorldEntities/Food/CookedBladderfish";
        data["8bdb65a9-1057-4e6d-bf40-94cf6dc5a129"] = "WorldEntities/Fragments/StasisRifleJunkFragment";
        data["8bf37c44-ba49-4def-a82b-dc5b65bf6fb3"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/starship_girder_12";
        data["8c0e639f-31ce-418f-a4a4-b5d802d59453"] = "WorldEntities/Environment/MagmaPillar";
        data["8c19ef1b-07d4-437f-8102-39a89285dc76"] = "WorldEntities/Slots/GrandReef/GrandReef_Loot_CaveCeiling";
        data["8c21d402-1767-4266-ada6-b3e40c798e9f"] = "WorldEntities/Natural/SupplyCrate_PowerCell";
        data["8c3cc489-cb05-42a0-830d-b9dc73a841c0"] =
            "WorldEntities/Environment/Precursor/Prison/TeleporterRooms/Precursor_Prison_TeleporterRoom_03";
        data["8c3d54c0-4330-4949-91ad-f046cfd67c7c"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/Starship_cargo_damaged_opened_01";
        data["8c414a71-c6cf-4352-954a-a33364d47b34"] = "WorldEntities/Slots/SafeShallows/SafeShallows_Loot_SandFlat";
        data["8c4ba581-e392-41ab-80a9-a4a2745dcfdb"] = "WorldEntities/Doodads/Coral_reef/Coral_reef_Kelp_blood_01";
        data["8c5c3525-ce67-4c62-99a1-2f1e26ec7df7"] = "WorldEntities/Doodads/Lava/lava_leak_01_07";
        data["8c624e24-e93e-4880-9fca-4d88b38140a4"] =
            "WorldEntities/Slots/MushroomForest/MushroomForest_Loot_GiantTreeInteriorPlants";
        data["8c699838-2876-4900-91f7-33fb69f22911"] =
            "WorldEntities/Slots/GrassyPlateaus/GrassyPlateaus_Loot_Techsite_Medium";
        data["8c7205cd-ba0d-4fc7-b942-aa05d9753d57"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/docking_bar_cup_01";
        data["8c974a0d-c592-47d3-b30f-d7c9e9a0f100"] =
            "WorldEntities/Environment/Precursor/Prison/PipeRoom/Precursor_Prison_PipeRoom_OutgoingPipe2";
        data["8ca26b21-f70b-4de9-9892-f4a382e1a20a"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/base_hull_crack_01";
        data["8cae16e8-f362-4c07-9375-39df60e8ea87"] = "WorldEntities/Environment/DataBoxes/CreatureDecoyModuleDataBox";
        data["8cb5a22e-af68-43af-b467-0dc739a8705c"] =
            "WorldEntities/Slots/MushroomForest/MushroomForest_Creature_UniqueCreatureCave";
        data["8ce870ba-b559-45d7-9c10-a5477967db24"] = "WorldEntities/Environment/Wrecks/tech_light_deco";
        data["8cecc172-293a-46af-9e60-1e2fca4906a9"] =
            "WorldEntities/Atmosphere/LostRiver/TreeCove/LostRiver_Tree_Cove";
        data["8cf785a3-137e-4bc8-abf1-8e193aabc5e9"] = "WorldEntities/Atmosphere/Mountains/Mountains_ThermalVent";
        data["8d01c124-f128-4029-9bbc-18ca528d3bcb"] = "WorldEntities/Slots/Dunes/Dunes_Creature_SandDunes";
        data["8d030466-d78c-41d3-b62b-47fbc8b237b9"] =
            "WorldEntities/Environment/Precursor/Prison/Moonpool/Precursor_Prison_MoonPoolTrigger";
        data["8d0b24b7-c71f-42ab-8df9-7bfe05616ab4"] = "WorldEntities/Doodads/Coral_reef/Crab_snake_mushrooms_03";
        data["8d0e6029-4660-449a-b254-8fe7695e4f54"] =
            "WorldEntities/Slots/GrassyPlateaus/GrassyPlateaus_Creature_TowerBigTop";
        data["8d13d081-431e-4ed5-bc99-2b8b9fabe9c2"] = "WorldEntities/Doodads/Geometry/SafeShallows/Rock01";
        data["8d24a18d-05a5-4fd9-b5d6-59bd51c49bc0"] = "WorldEntities/Slots/KooshZone/KooshZone_Creature_Coral";
        data["8d3d3c8b-9290-444a-9fea-8e5493ecd6fe"] = "WorldEntities/Creatures/Reefback";
        data["8d4148e6-a83f-4018-9c62-dbc10c8d9655"] =
            "WorldEntities/Slots/MushroomForest/MushroomForest_Creature_CaveEntrance";
        data["8d62d89e-8bac-4970-9d4d-bd8465abfb5a"] = "WorldEntities/Slots/Ship/Creature_ShipInterior_Platform";
        data["8d7f308a-21db-4d1f-99c7-38860e5132e7"] =
            "WorldEntities/Doodads/Lost_river/Lost_river_hanging_plant_03_03";
        data["8d8d5286-5297-4039-8dda-8db4f64bf83c"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/Starship_cargo_damaged_large_02_Far";
        data["8d9f79ba-a157-4512-bea5-0867e6772cd8"] =
            "WorldEntities/Doodads/Debris/Wrecks/ExplorableWreckRoom02_aurora";
        data["8de9be7a-55e5-4487-90f8-79326ccfa066"] = "WorldEntities/Doodads/Precursor/Prison/Relics/alien_relic_01";
        data["8df14188-4856-4e42-b8ae-bbc27bfb5e4c"] =
            "WorldEntities/Doodads/Precursor/LavaBase/Final_Rooms/Precursor_LavaBase_ThermalRoom";
        data["8df358b5-a045-4914-9c98-2af62ea35756"] =
            "WorldEntities/Atmosphere/Precursor/Gun/Precursor_Gun_OuterRooms_Atmosphere";
        data["8e2df950-b66a-4a75-b2a6-a77a4955908a"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/Starship_wires_03";
        data["8e3bb2e3-eab7-4766-b8c4-fc0691bf8247"] = "WorldEntities/Tools/Battery_damaged";
        data["8e3c7718-3df8-4b60-8f18-916232dff760"] = "Base/Ghosts/BaseDeconstructable";
        data["8e408075-be8e-46a7-914e-3c3dbacf6528"] = "Submarine/Build/LordMinionHullPlate";
        data["8e491e62-fcaf-472a-8953-eb18d1f7ed99"] =
            "WorldEntities/Slots/UnderwaterIslands/UnderwaterIslands_Creature_IslandCaveFloor";
        data["8e4e640e-4c04-4168-a0cc-4ec86b709345"] = "WorldEntities/Doodads/Land/land_plant_middle_05_03";
        data["8e5dcd45-f5a7-417b-abdc-bfa7d693f8b6"] = "WorldEntities/Slots/SafeShallows/SafeShallows_Loot_CaveSpecial";
        data["8e6db01e-c7be-4182-8e0d-2a7c20341e10"] =
            "WorldEntities/Atmosphere/Ship/CrashedShip_Interior_LockerCorridor";
        data["8e7399ef-c3d4-4d13-b4f8-f5c68376e172"] = "WorldEntities/Slots/seaTreaderPath/SeaTreaderPath_Loot_Path";
        data["8e750cee-8f50-4103-97a3-175624f32750"] =
            "WorldEntities/Atmosphere/LostRiver/GhostTree/LostRiverCaveTeleporter";
        data["8e81cfda-6419-45b9-8050-58eced7a0031"] = "WorldEntities/Fragments/Old/baseroomfragment_old";
        data["8e82dc63-5991-4c63-a12c-2aa39373a7cf"] = "WorldEntities/Creatures/RockGrub";
        data["8e953585-0cc4-4552-b417-3b2593c6395b"] =
            "WorldEntities/Environment/Wrecks/PDAs/Wreck9_MushroomForest_PDA1";
        data["8e96c4a2-6130-4f78-aad9-160cb4d42538"] =
            "WorldEntities/Lights/EmperorFacility/Prison_Exterior_Upper_Spotlight";
        data["8e9b16bb-44c5-4eeb-bafd-dce404e44ba9"] = "WorldEntities/Slots/CragField/Cragfield_Creature_Open";
        data["8ea4856b-a4b3-4710-be23-f86629eb0a4f"] =
            "WorldEntities/Slots/MushroomForest/MushroomForest_Loot_GiantTreeRootBase";
        data["8ea729cc-719f-4c30-b004-d198b5c49766"] = "WorldEntities/Atmosphere/MushroomForest/MF_cache_box";
        data["8eb1140f-bbb9-4a2c-8704-f9241ee46ae8"] =
            "WorldEntities/Doodads/Precursor/TempGun_Interiors/Gun_Lower_Control_Room_Lights";
        data["8ed37cbb-65be-40d7-838b-11ad53e0e792"] =
            "WorldEntities/Environment/DataBoxes/UltraHighCapacityTankDataBox";
        data["8ed7c383-1f55-462c-a7fe-f7be6bcce8a5"] = "WorldEntities/Environment/Wrecks/basebulkheadfragment1";
        data["8ef17c52-2aa8-46b6-ada3-c3e3c4a78dd6"] = "WorldEntities/Natural/quartz";
        data["8f20a08c-c981-4fad-a57b-2de2106b8abf"] = "WorldEntities/Environment/Wrecks/AbandonedBase2";
        data["8f489a8d-e612-4ac7-86c6-fa277dd8ee62"] =
            "WorldEntities/Doodads/Coral_reef/Coral_reef_red_seaweed_02_tall";
        data["8f5046b4-b727-4359-9d5a-2640ae6bf5d6"] =
            "WorldEntities/Doodads/Debris/Aurora/Rooms/CrashedShip_entrance_02_01";
        data["8f522e8f-b53b-49c4-9cd8-77a3cfb15d55"] =
            "WorldEntities/Slots/DeepGrandReef/DeepGrandReef_Creature_Ceiling";
        data["8f700da9-a474-4015-acd7-0ba9aaf7c5dd"] = "WorldEntities/Tools/Bailer";
        data["8f701e73-7152-429b-a173-7ca62c5b8fd1"] = "WorldEntities/Lights/Precursor/Precursor_Cave_Ambient_Small_2";
        data["8f7abc37-2a56-4d80-863b-154b9a46eedb"] = "WorldEntities/Seeds/HangingFruit";
        data["8f88a33c-aee0-46bd-b786-e45df3b5332f"] =
            "WorldEntities/Slots/GrassyPlateaus/GrassyPlateaus_Loot_CaveEntrance";
        data["8f8b05ae-680c-4a0c-9581-76f626a579b7"] = "WorldEntities/VFX/xLavaJetSmokeSmall";
        data["8f92e25f-31dc-4578-8629-c69648cb74d4"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/descent_bar_sofa_corner_03";
        data["8f95023a-a751-4082-ac83-58108fe4f805"] =
            "WorldEntities/Environment/Precursor/Prison/Aquarium/Precursor_Prison_Aquarium_Teleporter_ToMoonpool";
        data["8fa4a413-57fa-47a3-828d-de2255dbce4f"] = "WorldEntities/Doodads/Land/farming_plant_03";
        data["8fb8a082-d40a-4473-99ec-1ded36cc6813"] = "Submarine/Build/StarshipCargoCrate";
        data["8fe779a5-e907-4e9e-b748-1eee25589b34"] = "WorldEntities/Doodads/Lost_river/ReaperSkeleton";
        data["8ffbb5b5-21b4-4687-9118-730d59330c9a"] = "WorldEntities/Creatures/BoomerangFishSchool";
        data["90148ef8-fda4-4a95-b2bc-d570543a1ecf"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/descent_bar_table_01";
        data["90677349-315b-4221-a7af-7e2ffa72c226"] = "WorldEntities/Environment/Wrecks/ExplorableWreck_Grassy_14";
        data["907d1e85-c740-4cf3-90e6-3299d6823aa0"] =
            "WorldEntities/Slots/MushroomForest/MushroomForest_Loot_CaveCeiling";
        data["908d3f0e-04b9-42b4-80c8-a70624eb5455"] = "WorldEntities/Doodads/Lost_river/lost_river_skull_coral_01";
        data["90950443-743d-4796-893c-eb8e83f52d7b"] = "WorldEntities/Slots/ILZChamber/ILZChamber_Loot_ChamberWall";
        data["909d56bc-6494-4792-8e11-e2815c59f070"] =
            "WorldEntities/Doodads/Debris/Aurora/Rooms/CrashedShip_power_corridors";
        data["90bc7856-4206-41e5-8d6c-1dc86ebb7edb"] = "WorldEntities/Slots/BloodKelp_Cave/BloodKelp_Loot_CaveWall";
        data["90d538f2-50bd-4259-be85-8090192956d7"] = "WorldEntities/Atmosphere/FloatingIslands/CaveTeleporter";
        data["90f032d5-193a-4a00-b892-3d80be04dca3"] =
            "WorldEntities/Doodads/Coral_reef/coral_reef_Stalactites_cluster_03_04";
        data["91094afb-f79e-4efa-aab5-18602679cf7b"] = "WorldEntities/Atmosphere/Dunes/DunesThermalVents_sph";
        data["910af26d-ed48-4b5f-b650-4672e16c30c4"] =
            "WorldEntities/Environment/Aurora/Wreck_GrassyPlateaus_2_WeldablePanel1";
        data["911a118e-f410-4307-9b42-a16875780cbd"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/Starship_work_desk_01_empty_Far";
        data["911afe46-6178-4594-b23c-e577e7633622"] = "WorldEntities/Creatures/CrabSnake";
        data["9129e55d-1071-4d06-9e72-d682989ba0ee"] = "WorldEntities/Doodads/Coral_Decal_02_Projector";
        data["9130679a-3a85-4003-b779-92233fbbeed4"] =
            "WorldEntities/Environment/Precursor/Prison/Aquarium/Precursor_Aquarium_Sand_Drift";
        data["913440ed-5613-47b4-9c0a-137796a6f9e4"] =
            "WorldEntities/Environment/Wrecks/PDAs/EscapePod_6_PDA_RadiationSuit2";
        data["915b844f-a859-4c23-bdb1-15cf67cd763a"] = "WorldEntities/Doodads/Debris/Starship_exploded_debris_24";
        data["917cb699-4d51-4d70-abd4-f8f9509f3c74"] =
            "WorldEntities/Slots/Mountains/Mountains_Loot_Techsite_Scatter_Medium";
        data["91939e10-d202-4995-8992-7b7c13f5a785"] =
            "WorldEntities/Slots/GrandReef/GrandReef_Loot_TechSite_Exterior_Crate";
        data["91af2ecb-d63c-44f4-b6ad-395cf2c9ef04"] = "WorldEntities/Natural/FloatingStone_Beach_02";
        data["91b1dac9-bab3-4444-8fe9-b0f0ee2bf124"] =
            "WorldEntities/Slots/JellyshroomCaves/Jellyshroom_Creature_Jellyshroom";
        data["91bb3de1-36d5-497a-b27a-86aff784cb5a"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/Starship_work_desk_screen_01_damaged";
        data["91e5a9b7-04d0-429a-95a5-478a494f5557"] = "WorldEntities/Environment/Wrecks/ExplorableWreck_TreaderPath_7";
        data["920899e8-da15-49ff-8b7c-ee951a423bb5"] = "WorldEntities/Atmosphere/Ship/CrashedShip_Interior_Dark";
        data["92134a43-6208-4334-bf18-86d47b724aef"] = "WorldEntities/Atmosphere/MushroomForest/MF_cache_sph";
        data["923a14c0-a7a2-49bd-a6fd-915d661582ee"] = "WorldEntities/Lights/UnderwaterIslands/FloatersBig";
        data["9244985e-8ddb-4e72-8306-3b6c9d9a9022"] =
            "WorldEntities/Environment/GrassyPlateaus/Obstruction_Rock_Small01";
        data["924c4ce2-5d29-40cd-b5fe-a4f5989e47e2"] =
            "WorldEntities/Doodads/Precursor/LavaBase/Precursor_LavaCastleBase_Ramp_Animated_Medium";
        data["926ba09b-d7cd-4386-a0e0-350e80e6ccdf"] = "WorldEntities/Lights/EmperorFacility/Aquarium_SpotLight";
        data["9286132d-a08c-452a-bf7a-062535e18daf"] =
            "WorldEntities/Slots/Mountains/Mountains_Creature_IslandCaveWall";
        data["92af11b3-5a88-4016-a742-ab95c5fd7dfe"] =
            "WorldEntities/Atmosphere/KooshZone/Kooshcave_trans_green_night_box";
        data["92b48933-f89e-4d9d-a432-323785d7cdd2"] =
            "WorldEntities/Doodads/Coral_reef/coral_reef_Stalactites_cluster_02_01";
        data["92b6424f-7635-4e61-990e-3c40bfad6e9a"] = "WorldEntities/Tools/SeamothElectricalDefense";
        data["92e908d6-3cbc-4293-ab7b-5c5e1589e538"] =
            "WorldEntities/Slots/LostRiver/BonesField/BonesField_Loot_LakePit_Wall";
        data["92fb421e-a3f6-4b0b-8542-fd4faee4202a"] = "WorldEntities/Doodads/Precursor/PrecursorKey_Purple";
        data["93122b34-aa70-41c5-9f4d-f9316c1caa03"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/explorable_wreckage_modular_room_details_02";
        data["932fc808-9183-4f90-bee2-1eec1b30ee73"] = "WorldEntities/Eggs/CrashEgg";
        data["9343d54f-5f37-4628-ae4c-9b161f65bdbc"] = "WorldEntities/Slots/ILZLavaPit/ILZLavaPit_Loot_Wall";
        data["9380eb20-57fd-4982-a7b1-97c50c6a11d9"] = "WorldEntities/Lights/Koosh Zone/KooshCave_blue_amb";
        data["93a85df9-27b4-4729-a62d-db0450503015"] =
            "WorldEntities/Environment/Precursor/LostRiverBase/Precursor_LostRiverBase_WhiteKey_old";
        data["93a9886d-f2d3-4b6c-8e5f-216f569f82b2"] =
            "WorldEntities/Doodads/Coral_reef/Coral_reef_slanted_coral_plates_01_02";
        data["93b6d5d5-5bcc-41b7-ba5c-0a793dc68fcf"] =
            "WorldEntities/Doodads/Lost_river/LostRiverBase/Lost_river_hanging_plant_03_01";
        data["93c42c1c-5bac-4cdb-96a1-6d0987e4d5f3"] =
            "WorldEntities/Doodads/Debris/Aurora/Decoration/Signs/Aurora_JHallway_Seamoth_Sign";
        data["93d2fb44-eae2-4340-b372-2ecbe15b14c4"] = "WorldEntities/Atmosphere/GrandReef/Normal_named";
        data["93f0252f-3b6d-46b9-bb05-4d8b48ab826a"] =
            "WorldEntities/Environment/Precursor/LostRiverBase/Precursor_LostRiverBase_BrokenAnchor4";
        data["93f39b3c-dee8-41d8-b8e0-f6122c04291e"] =
            "WorldEntities/Slots/LostRiver/GhostTree/GhostTree_Creature_LakePit";
        data["940c7b39-535c-435e-91fd-92f17a3b6e04"] =
            "WorldEntities/Slots/MushroomForest/MushroomForest_Loot_MushroomTreeTrunk";
        data["9427aefa-9e81-4485-bb10-fde56ba13ab1"] = "WorldEntities/Natural/Creepvine_kelp_stem";
        data["942b10ec-e96d-436e-8ea7-02dfd902b7e2"] = "WorldEntities/Atmosphere/MushroomForest/CoralRootZone_Sphere";
        data["945d08c2-9a5a-43ef-8866-98fd63869041"] =
            "WorldEntities/Environment/Precursor/LostRiverBase/Precursor_LostRiverBase_BrokenAnchor5";
        data["9460942c-2347-4b58-b9ff-0f7f693dc9ff"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/Starship_work_desk_01";
        data["947f2823-c42a-45ef-94e4-52a9f1d3459c"] = "WorldEntities/Natural/metal1";
        data["94933bb3-0587-4e8d-a38d-b7ec4c859b1a"] = "WorldEntities/Doodads/Precursor/precursor_cables_middle_02";
        data["949d8657-1e5c-4418-8948-76b8b712fc57"] = "WorldEntities/Doodads/Lost_river/Lost_river_generic_bone_05";
        data["949daada-08b0-4377-980e-4bbaa3584bc8"] = "WorldEntities/Slots/BloodKelp/BloodKelp_Loot_Techsite_Medium";
        data["949dc3e9-7b8a-4e4a-a98f-9928212c7f77"] = "Submarine/Build/Submarine_hull_fragments_03";
        data["94a577fe-b9bc-4f37-a2d4-24a59b0bba2d"] = "Misc/BatchRoot";
        data["94d3c568-67d1-4ee7-9c56-0994adc403a9"] = "WorldEntities/Eggs/SpadefishEgg";
        data["94d7ed83-abb8-49af-9f27-10771dcd1485"] = "WorldEntities/Doodads/Coral_reef/Spiral_blue_thing_cluster_05";
        data["94f18a8a-b7c5-41c6-83f3-279154603e0b"] = "WorldEntities/Doodads/Debris/Starship_exploded_debris_35";
        data["94f294e6-e6c1-4b86-9979-94e50dc323b7"] = "WorldEntities/Slots/CrashZone/CrashZone_Creature_Rock";
        data["951f29b0-e688-4180-9f04-7dd0973ad32d"] =
            "WorldEntities/Environment/Precursor/Prison/Aquarium/Precursor_Prison_Aquarium_TeleporterTerminal_ToMoonpool";
        data["9536fe33-84b6-4f27-bfe4-30eef609d043"] = "WorldEntities/Lights/Mountains/Mountains_Precursor_Spotlight1";
        data["953d4aad-0e94-47e5-8909-9454011bd79b"] = "WorldEntities/Doodads/Debris/Starship_exploded_debris_02";
        data["9569f745-4853-47cf-aaf5-b849c91651f4"] =
            "WorldEntities/Environment/Wrecks/Power_Cell_Charging_Station_damaged_cover";
        data["957657e1-4971-4a17-a286-63b558a1182e"] = "WorldEntities/Slots/LostRiver/Canyon/Canyon_Loot_Grass";
        data["9588863c-bb2b-4992-9ae6-5ae2978c5891"] =
            "WorldEntities/Doodads/Precursor/Precursor_Interior_Damage_Props_07";
        data["961194a9-e88b-40d7-900d-a48c5b739352"] = "WorldEntities/Doodads/Coral_reef/Coral_reef_ball_clusters_03";
        data["961da9b8-066e-4864-8391-3915f9c62dc6"] = "WorldEntities/Doodads/Land/Fern 03";
        data["9623ac82-a6b8-4e96-be91-e23370ab7282"] =
            "WorldEntities/Doodads/Lost_river/LostRiverBase/Lost_river_hanging_plant_01_02";
        data["963fa3a3-9192-4912-8c8d-d0d98f22ed13"] =
            "WorldEntities/Doodads/Precursor/TempGun_Interiors/Precursor_Gun_ControlRoom";
        data["9650806c-0b21-437a-85b9-fc5c08a49c30"] =
            "WorldEntities/Atmosphere/Precursor/Gun/Precursor_Gun_MoonPoolWater_Atmosphere";
        data["966e9d8f-e598-40c2-98bd-0a4e3b2bc996"] = "WorldEntities/Slots/Mountains/Mountains_Creature_IslandRock";
        data["9687766e-ac0c-49d7-baa7-f0b4478edd4c"] =
            "WorldEntities/Atmosphere/MushroomForest/MushroomForest_Wreck_Adjust";
        data["96b1b863-2ff7-451b-aa38-8b3a06e72d63"] = "WorldEntities/Natural/Lubricant";
        data["96b349a7-291d-48fc-9cb1-a2f98d95172a"] = "WorldEntities/Tools/ExosuitJetUpgradeModule";
        data["96edb813-c7c7-4c44-9bf4-5f1975edeff8"] =
            "WorldEntities/Doodads/Precursor/precursor_block_deco_08_04_08_v5";
        data["96f78fca-48d0-4381-992f-f82e8688b79c"] = "WorldEntities/Slots/BloodKelp_Trench/BloodKelp_Creature_Floor";
        data["97244cc9-8aea-4af4-8c36-2f9a484b00bd"] =
            "WorldEntities/Slots/Ship/Loot_ShipInterior_ExoRoomPipes_Barrier";
        data["976e9fae-909f-4a7a-9f2e-03d6150a32e4"] =
            "WorldEntities/Environment/Precursor/Gun/Precursor_Gun_MoonPoolTrigger";
        data["97b1e164-e3fd-4822-ae29-82864fe974e0"] =
            "WorldEntities/Slots/GrassyPlateaus/GrassyPlateaus_Creature_ArchOutcropping";
        data["97ccc660-f0e4-4c18-ae93-e4fe25c321fe"] = "WorldEntities/Tools/PropulsionCannon_damaged";
        data["97d647ce-d45d-4493-bca1-0e2268cf73db"] =
            "WorldEntities/Slots/UnderwaterIslands/UnderwaterIslands_Loot_CaveWall";
        data["97df1c6a-3841-4e17-83ab-bdd4d92093b3"] = "Submarine/Build/Spotlight";
        data["983d4a23-1da8-4860-a3f3-4326e15a6a9f"] =
            "WorldEntities/Slots/UnderwaterIslands/UnderwaterIslands_Loot_CavePlants";
        data["98436b56-a341-4e39-8996-81cc7e7d2851"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/explorable_wreckage_modular_room_details_18";
        data["98692d81-06e8-4a01-a6d3-917e4773bc34"] = "WorldEntities/Slots/Dunes/Dunes_Loot_SandPlateau";
        data["986b31ea-3c9d-498c-9f38-2af8ffe86ed7"] = "WorldEntities/Natural/benzene";
        data["9874f80d-0c3f-44c3-b3e2-f6cefd5ead2d"] =
            "WorldEntities/Slots/LostRiver/BonesField/BonesField_Loot_Corridor_Algae";
        data["989d1bec-d204-4cbe-a759-f2571575b9a1"] = "WorldEntities/Atmosphere/DeepGrandReef/Open_named";
        data["98aaccd8-1bf6-429b-9154-d6025b816640"] = "WorldEntities/Doodads/Lava/lava_leak_01_08";
        data["98ac710d-5390-49fd-a850-dbea7bc07aef"] =
            "WorldEntities/Doodads/Debris/Aurora/Rooms/CrashedShip_power_room";
        data["98b3ffc5-5497-49ad-8155-3608826ad373"] = "WorldEntities/Doodads/Land/Jungle Tree 3b";
        data["98be0944-e0b3-4fba-8f08-ca5d322c22f6"] = "WorldEntities/Doodads/Land/land_plant_small_02_02";
        data["98c01148-02db-4e4a-90a2-ce59e5ded4be"] = "WorldEntities/Environment/CollapsibleSandBig";
        data["98d5b01b-b703-42e1-945b-4df9eec71e29"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/explorable_wreckage_modular_room_details_15";
        data["98daa9ba-2b53-41d3-8d50-0f2db12a6366"] = "WorldEntities/Environment/Prototype/LavaPlane";
        data["98dbe609-3f96-4d6a-b5d3-68b3a3cf0634"] = "WorldEntities/Atmosphere/Dunes/Dunes BiomeOR";
        data["98e69ccf-02cd-495b-bf8a-d3f9307f0c66"] =
            "WorldEntities/Slots/LostRiver/BonesField/BonesField_Creature_LakePit_Open";
        data["98ee9a60-3b80-426c-a181-d4b7883854f3"] =
            "WorldEntities/Doodads/Coral_reef/Crab_snake_mushrooms_entrance_02";
        data["9912d6c1-f0fa-4a66-a827-4469539f5eb3"] =
            "WorldEntities/Lights/EmperorFacility/Prison_Exterior_Lower_Spotlight";
        data["9925060f-6ffd-4979-a4d0-1a74bd8fd16d"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/docking_bar_bottlegroup_01";
        data["993c9891-59de-451f-9f30-d6fa3c528510"] =
            "WorldEntities/Atmosphere/Precursor/Gun/Precursor_Gun_NoLoot_Atmosphere";
        data["9966bd1d-8db4-492a-b8c6-1f5e075c1d5b"] = "WorldEntities/Doodads/Lava/lava_rock_01_bubble_02";
        data["9986db28-e3a2-47ec-936f-305bcba28f59"] = "WorldEntities/Doodads/RandomStalag";
        data["999fa414-639e-4633-83bf-095a1ca3b378"] =
            "WorldEntities/Environment/Precursor/Gun/Precursor_Gun_Terminal2_DoorTerminalsRoot_old";
        data["99a721b1-819e-485a-af9f-1dbbe9507e5b"] = "WorldEntities/Doodads/Coral_reef/Coral_reef_small_deco_01";
        data["99b164ac-dfb4-4a14-b305-8666fa227717"] =
            "WorldEntities/Environment/AbandonedBases/AbandonedBaseFloatingIsland1";
        data["99bbd145-d50e-4afb-bff0-27b33243642b"] =
            "WorldEntities/Doodads/Coral_reef_Light/coral_reef_plant_middle_04_Light";
        data["99be4a72-a5fd-4a3d-8eac-7508433e33b9"] =
            "WorldEntities/Environment/Aurora/Consoles/Aurora_RingRoom_Console1";
        data["99c0da07-a612-4cb7-9e16-e2e6bd3d6207"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/starship_girder_10";
        data["99c5fcbc-eac0-4cae-8106-a6226058ecb5"] = "WorldEntities/Slots/GrandReef/GrandReef_Creature_OpenDeep";
        data["99cdec62-302b-4999-ba49-f50c73575a4d"] =
            "WorldEntities/Doodads/Coral_reef/Coral_reef_purple_mushrooms_01_04";
        data["99d284c9-5793-4723-9e7e-ff024fd969d7"] =
            "WorldEntities/Slots/SafeShallows/SafeShallows_Loot_TechSite_Scatter_Crate_Small";
        data["99da2618-1990-4863-923a-1812afae0ea4"] = "WorldEntities/Creatures/Unused/GrabcrabHome";
        data["99eb0443-cbbd-4749-a0b0-63d7cb1eecdb"] = "Submarine/Build/Submarine_hull_fragments_07";
        data["9a5ff289-4b82-4b9c-b9f6-d60f46dd2d7a"] = "WorldEntities/Doodads/Precursor/PrecursorTeleporter";
        data["9a643563-9278-4c77-8bd2-f9b4b1a1053a"] =
            "WorldEntities/Doodads/Coral_reef/Coral_reef_jeweled_disk_red_01_03";
        data["9a6c357c-1af7-43e9-9a15-e1098f005c7a"] = "WorldEntities/Atmosphere/BloodKelp/Bloodkelp_Wreck_Adjust";
        data["9a8715b8-645c-430a-a66e-4e5560842930"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/Base_interior_wall_planter_Shelves_empty_deco";
        data["9a9cdb4e-f110-412d-b16b-b9ace904b569"] = "WorldEntities/Natural/FloatingStone5_Floaters";
        data["9a9d5786-83ee-4209-8f34-7ff1391b2cba"] =
            "WorldEntities/Doodads/Coral_reef/Coral_reef_blue_barnacles_01_cluster_05";
        data["9aa6b0ad-d23a-48d0-b43b-102a694bcd20"] = "WorldEntities/Slots/Dunes/Dunes_Creature_Grass";
        data["9aa6ffb9-666b-45c2-b961-68fd16efccca"] =
            "WorldEntities/Slots/JellyshroomCaves/Jellyshroom_Loot_CaveFloor";
        data["9aad0455-2af5-42d6-9fed-e15887225690"] =
            "WorldEntities/Environment/Precursor/Cache/Precursor_DunesCraterCache_Console";
        data["9abc15fc-433c-4fbd-b3e6-d1b2cc73abb2"] = "WorldEntities/Fragments/ExosuitPropulsionArmfragment";
        data["9ae4fb76-354f-4c25-b9fd-4f8d69d8aefe"] =
            "WorldEntities/Environment/Precursor/Prison/Moonpool/Precursor_Prison_MoonpoolHallway_Lights";
        data["9aec63ec-4966-45ea-8ec0-3f311505c016"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/docking_food_01_tray7";
        data["9b1e9998-4ade-4478-b2d6-9341923351cd"] =
            "WorldEntities/Slots/KelpForest/KelpForest_Loot_TechSite_Barrier_Small";
        data["9b322641-d9c4-4525-849b-540d75c921ee"] =
            "WorldEntities/Doodads/Precursor/PrecursorTeleporterWithKey_legacy";
        data["9b51b775-79b0-4054-8ac9-74344fac739b"] = "WorldEntities/Slots/Dunes/Dunes_Creature_CaveWall";
        data["9b5fd318-bb6d-4c76-b37d-b12a68ee715c"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/vent_constructor_section_01";
        data["9b71a079-a6f4-429c-a086-4f2c2de3a23c"] =
            "WorldEntities/Slots/LostRiver/GhostTree/GhostTree_Creature_Open";
        data["9b72919d-84fc-4e34-bdce-513ecf080113"] = "WorldEntities/Environment/Prototype/Sandworm";
        data["9ba6541e-193c-4744-9d4f-43c6e9f44d72"] = "WorldEntities/Natural/SupplyCrate_DisinfectedWater";
        data["9ba9489f-c28d-4f89-b877-0a7796f2ee5d"] = "WorldEntities/Atmosphere/JellyshroomCaves/Geyser (Sphere)";
        data["9bc69973-43b8-40e7-a9b7-297b1959817a"] =
            "WorldEntities/Doodads/Coral_reef/Coral_reef_small_blue_fans_small_01_01";
        data["9bd96019-1675-43f7-bba5-26d5f5dac176"] =
            "WorldEntities/Lights/Precursor/Aquarium/Aquarium_Cave_Ambient_01";
        data["9bf67828-8c70-46ec-abbd-5e46940e5b2d"] = "WorldEntities/Environment/Aurora/PDAs/Aurora_Locker_PDA2";
        data["9bfe02bd-60a3-401b-b7a0-627c3bdc4451"] = "WorldEntities/Doodads/Coral_reef/Coral_reef_kelp_dense_03";
        data["9c07c64d-930a-4b41-b10b-b2ea9d8d257f"] = "WorldEntities/Slots/Ship/Loot_ShipSpecial_WreckInterior";
        data["9c254c52-331e-44ae-8e0b-bc0b1e937825"] = "WorldEntities/Environment/Aurora/PDAs/Aurora_LivingArea_PDA2b";
        data["9c27abdd-6b6a-4490-aa11-6fdf7700e040"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/explorable_wreckage_modular_wall_details_09";
        data["9c3f34af-16f4-499f-90d7-3190a215a179"] =
            "WorldEntities/Doodads/Precursor/TempGun_Interiors/Precursor_Gun_MoonPool_Lights";
        data["9c42a3f0-1322-4549-87d6-f18e79b4a585"] = "WorldEntities/Slots/Ship/Loot_ShipInterior_PowerRoom";
        data["9c485f57-078c-4e6c-ae78-3011c2cf1103"] = "WorldEntities/Slots/Mountains/Mountains_Creature_OpenDeep";
        data["9c4d8ef4-1948-4ed9-aab3-e9eb52ba666b"] =
            "WorldEntities/Environment/Wrecks/ExplorableWreck_SafeShallows_16";
        data["9c54b4a0-e4e5-49f6-842c-3af46c5b784f"] = "WorldEntities/Doodads/Coral_reef/coral_reef_small_deco_21_03";
        data["9c59e2ca-3e6b-4869-bee9-2bcce56fbc50"] = "WorldEntities/Lights/Mountains/Mountcave_Plant_light_large_amb";
        data["9c5f22de-5049-48bb-ad1e-0d78c894210e"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/discovery_lab_props_02";
        data["9c5f7d20-873e-401a-b555-b37fd33b2cf7"] =
            "WorldEntities/Environment/Precursor/Cache/Precursor_DunesCraterCache_DoorTerminalsRoot1";
        data["9c609b7f-e87e-46a0-a807-60777234d20d"] =
            "WorldEntities/Doodads/Debris/Wrecks/ExplorableWreckRoom03_aurora";
        data["9c66fc2c-db28-431d-ae6a-004bc31e172a"] = "WorldEntities/Natural/LavaZoneEgg";
        data["9c6b73cc-899c-430d-870a-ee83520674a9"] = "WorldEntities/Slots/SparseReef/SparseReef_Loot_Coral";
        data["9c79491f-0287-4879-8d28-a2ad8b3eea45"] = "WorldEntities/Tools/ExoHullModule2";
        data["9c8f56e6-3380-42e4-a758-e8d733b5ddec"] = "WorldEntities/Natural/drillable/DrillableNickel";
        data["9c903db2-9f15-4de8-b964-42c34f48ca09"] =
            "WorldEntities/Slots/BloodKelp/BloodKelp_Loot_Techsite_Scatter_Medium";
        data["9cb0b87c-302b-45fe-b12c-cd651554d05c"] = "WorldEntities/Creatures/JuvenileEmperorSpawner";
        data["9cc577c4-ea13-4dcc-82e3-70fa5e3f32fc"] =
            "WorldEntities/Slots/JellyshroomCaves/Jellyshroom_Creature_CaveFloor";
        data["9cd2d504-ff8f-4a16-8d42-f8cd55ac8529"] =
            "WorldEntities/Atmosphere/LostRiver/Junction/LostRiver_Junction_Water";
        data["9d266051-1d3e-4521-8b46-a1aebe56ed91"] = "WorldEntities/Lights/Precursor/Aquarium/Aquarium_Cave_TopLight";
        data["9d38a0be-040f-4a54-9da8-31d300739b09"] =
            "WorldEntities/Slots/MushroomForest/MushroomForest_Creature_CavePlants";
        data["9d3e9fa5-a5ac-496e-89f4-70e13c0bedd5"] = "Base/Ghosts/BaseCell";
        data["9d6b5494-1a8f-4fcd-872c-7a85d7e2111c"] = "WorldEntities/Slots/LostRiver/TreeCove/TreeCove_Loot_Wall";
        data["9d7aac2f-7ae7-4b55-ae83-f2ff0627fa2b"] =
            "WorldEntities/Doodads/Coral_reef/coral_reef_Stalactites_cluster_02_02";
        data["9d7d3f7a-fbb9-41ab-84fa-6f40c1ed2524"] = "WorldEntities/Doodads/Lost_river/lost_river_pillar_01";
        data["9d9ed0b0-df64-45ee-9b90-34386a98b233"] = "WorldEntities/Tools/SmallStorage";
        data["9dafed34-133e-43e4-9234-f012ec3872e2"] =
            "WorldEntities/Doodads/Lost_river/lost_river_canyon_bottom_root_01";
        data["9db172f7-a80a-4054-b488-f38f73e9f27a"] = "Base/Ghosts/BaseWindow";
        data["9dd0f850-3616-4253-aa0f-e726e4bacd18"] = "WorldEntities/Slots/CragField/Cragfield_Creature_Rock";
        data["9de31592-85f0-4551-aea9-628ea063c7e2"] = "WorldEntities/Tools/Knife";
        data["9de31ef4-919e-4cd0-b502-38cabf388d84"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/generic_vending_coffee_01";
        data["9df5ae22-5297-487f-8752-5c11c2abaa81"] =
            "WorldEntities/Slots/SafeShallows/SafeShallows_Loot_TechSite_Barrier_Small";
        data["9e676fba-6906-44d4-9474-ec40640b714a"] = "WorldEntities/Creatures/Unused/Grower";
        data["9e8179be-8439-4c52-ae14-89e3e7fd062a"] = "WorldEntities/Lights/LostRiver/Point_Lostriver_blueplants_tiny";
        data["9e9dc886-4ee6-4f61-8c91-b99f0d6d4db7"] =
            "WorldEntities/Environment/Precursor/Prison/PipeRoom/Precursor_PipeRoom_Console1";
        data["9ea12567-c0b3-44b8-8ce2-f2262487a804"] =
            "WorldEntities/Doodads/Precursor/Precursor_prison_interior_box_01";
        data["9eb8239b-5b21-4258-9ff7-899cb8df0976"] =
            "WorldEntities/Doodads/Coral_reef/Coral_reef_small_blue_fans_01_02";
        data["9ec9e154-f265-4534-8657-69342454e9cd"] = "WorldEntities/Doodads/Coral_reef/coral_reef_plant_middle_06";
        data["9eda0145-4407-430f-b96d-63b99e4c8277"] = "WorldEntities/Slots/SafeShallows/SafeShallows_Loot_SandDunes";
        data["9ef26602-d7cf-43d5-9eb0-b7ae0fad84bd"] =
            "WorldEntities/Atmosphere/KooshZone/Kooshcave_trans_green_sphere";
        data["9ef36033-b60c-4f8b-8c3a-b15035de3116"] = "WorldEntities/Tools/Welder";
        data["9f16d82b-11f4-4eeb-aedf-f2fa2bfca8e3"] = "Submarine/Build/Fabricator";
        data["9f31a73c-9eb1-4961-bb64-f136b53cb1d8"] = "WorldEntities/Food/Snack2";
        data["9f41c099-f6a4-49ba-94a3-b701cf783796"] =
            "WorldEntities/Slots/GrassyPlateaus/GrassyPlateaus_Loot_TowerBigBase";
        data["9f45bf2c-5be3-4af7-9db7-d688e0e26998"] =
            "WorldEntities/Slots/Prison/Aquarium/PrisonAquarium_Creature_CaveFloor";
        data["9f5401ad-8211-4069-9c6d-a31f84d31443"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/explorable_wreckage_modular_wall_details_03";
        data["9f616173-e1af-42d7-af77-184331715ffe"] = "WorldEntities/Natural/mercurycrystal";
        data["9f80ba8e-fafc-4dfc-aaad-c855fee34c42"] = "WorldEntities/Doodads/Coral_reef/Coral_reef_brain_coral_02";
        data["9f855246-76c4-438b-8e4d-9cd6d7ce4224"] = "WorldEntities/Natural/drillable/DrillableTitanium";
        data["9f8de2bb-90d7-4e4a-953b-7e77db115d74"] =
            "WorldEntities/Slots/LostRiver/BonesField/BonesField_Creature_Corridor_Ground";
        data["9f9ab512-9ad6-4a84-80ea-6322a432bf80"] = "WorldEntities/Natural/Creepvine";
        data["9f9d2d5b-07c9-4628-b03e-b5522a46c4a3"] =
            "WorldEntities/Slots/FloatingIsland/FloatingIsland_Creature_Birds";
        data["9fadf60a-0498-4308-a4b0-a8915fe3d282"] = "Base/Ghosts/BaseFoundation";
        data["9ffeedc0-5e2e-49b5-9e23-5b2a20117692"] =
            "WorldEntities/Slots/UnderwaterIslands/UnderwaterIslands_Loot_Geyser";
        data["a01a0964-9093-4830-8421-364588f2603f"] =
            "WorldEntities/Slots/LostRiver/Corridor/Corridor_Creature_Ground";
        data["a033b39f-aae5-46eb-be17-609282e92ab8"] = "WorldEntities/Slots/seaTreaderPath/SeaTreaderPath_Loot_Grass";
        data["a0372774-a256-475c-a1a0-f3136fc6625b"] = "WorldEntities/Atmosphere/KelpForest/Caves Entrance (Sphere)";
        data["a05a52de-d6fc-44f5-a908-668a5c255aca"] = "WorldEntities/Doodads/Debris/Starship_exploded_debris_10";
        data["a05fe1c9-ae0d-43db-a12c-865992808cb2"] = "WorldEntities/Natural/drillable/DrillableGold";
        data["a06157cc-8de8-4fec-85a6-76b2aee1e263"] = "WorldEntities/Natural/nutrientblock";
        data["a0717842-faca-470e-9513-cd15d53e7592"] =
            "WorldEntities/Doodads/Precursor/Precursor_Interior_Damage_Props_03";
        data["a07411dc-7ee6-4b02-9507-0f185581a196"] =
            "WorldEntities/Environment/Precursor/LavaCastleBase/Precursor_LavaCastleBase_ThermalPlantConsole1";
        data["a07fdcaa-ef72-43b8-9c3a-6c687b23b16e"] = "WorldEntities/Slots/JellyshroomCaves/Jellyshroom_Loot_Geyser";
        data["a083cd20-bd5a-4ebe-9db2-372e44c1c9e3"] = "WorldEntities/Environment/Precursor/Gun/Precursor_Gun_Console2";
        data["a0a9237e-dee3-4efa-81ff-fea3893a6eb7"] = "WorldEntities/Doodads/Precursor/precursor_cables_end_01";
        data["a0aa5441-8559-4e2b-bc6f-a367ebf2319c"] = "WorldEntities/Creatures/Unused/HoleFishDummy";
        data["a0c5b949-22a4-4899-9c51-64ccce6956bc"] =
            "WorldEntities/Doodads/Coral_reef/Coral_reef_cave_root_small_02_blood";
        data["a0cbac2e-f86d-4ab0-a090-8115f5196f7c"] =
            "WorldEntities/Doodads/Coral_reef/Coral_reef_cave_root_small_03_blood";
        data["a0d12ea2-1808-4afa-83eb-d1a2971e1f09"] = "WorldEntities/Slots/KooshZone/KooshZone_Creature_HugeKooshBase";
        data["a0ed3340-98a7-4a81-90b6-93d196ba18e3"] = "WorldEntities/Slots/LostRiver/BonesField/BonesField_Loot_Ledge";
        data["a0fa0b2c-3bb2-480f-943a-628d567e5cb5"] = "WorldEntities/Slots/BloodKelp/BloodKelp_Loot_EscapePod_Small";
        data["a1040915-abcf-4843-a16f-39a10d6a1c2d"] = "WorldEntities/Doodads/Coral_reef/Coral_reef_sea_crown";
        data["a12ced70-ec31-4e26-9287-e005f93d4724"] = "WorldEntities/Doodads/Debris/Starship_exploded_debris_39";
        data["a1354950-de4a-4deb-982e-c56bd4d8a04e"] =
            "WorldEntities/Slots/Prison/Aquarium/PrisonAquarium_Loot_SpecialCoral";
        data["a1447801-44c0-4217-b050-2313c3a6db50"] = "WorldEntities/Eggs/LavaLizardEgg";
        data["a14d1980-0259-4fee-bfcc-eba301a7d75e"] =
            "WorldEntities/Slots/GrassyPlateaus/GrassyPlateaus_Creature_OpenShallow";
        data["a1570365-e598-4ddb-a080-c86c72f9bbdf"] = "WorldEntities/Fragments/Old/shipfragment";
        data["a17ef178-6952-4a91-8f66-44e1d8ca0575"] = "WorldEntities/Doodads/Coral_reef/Coral_reef_kelp_02_short";
        data["a19a9a9c-25db-4e90-aed4-643d62aa0a5b"] =
            "WorldEntities/Doodads/Precursor/LavaBase/Final_Rooms/Precursor_LavaBase_HallwayRamps";
        data["a1b82685-c045-4e31-96fc-02e1c7f737fa"] = "WorldEntities/Slots/LavaFalls/LavaFalls_Loot_Wall";
        data["a1b9a66d-76cb-4c29-9acc-4cfd773f5e7b"] =
            "WorldEntities/Lights/LostRiver/BonesField/LostRiver_BonesField_SkullCoral_Light";
        data["a1c2680e-c608-4e3c-af32-d034a958ed7f"] = "WorldEntities/Slots/Ship/Loot_ShipInterior_AuxPowerRoom2";
        data["a1e2f322-7080-48ca-8eaf-a05afff8585d"] = "WorldEntities/Environment/Wrecks/AbandonedBase1";
        data["a1e87103-4211-493a-8d1d-d57c632c3b28"] =
            "WorldEntities/Slots/MushroomForest/MushroomForest_Loot_CaveWall";
        data["a1f3da68-d810-44ff-a0a2-6cf3c6a3eff5"] = "WorldEntities/Natural/FloatingStone5";
        data["a1f8e7cf-83ae-438c-9197-3321374eca56"] =
            "WorldEntities/Doodads/Coral_reef_Light/Coral_reef_ball_clusters_01_Light";
        data["a202ce1d-60a4-49d4-a43b-2e37a2fa95c7"] =
            "WorldEntities/Environment/Precursor/LostRiverBase/Precursor_LostRiverBase_WarperLab_Decals";
        data["a2104a9e-fe84-4c51-8874-69350507ef98"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/Starship_cargo_damaged_opened_large_01";
        data["a21e3ded-d0be-4e9f-8bdd-2526f0981643"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/explorable_wreckage_modular_room_details_22";
        data["a227d6b6-d64c-4bf0-b919-2db02d67d037"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/biodome_lab_containers_tube_02";
        data["a22a243d-14c5-4c4d-a646-96955b8d0b01"] = "WorldEntities/Doodads/Debris/Wrecks/Decoration/bed_02";
        data["a254d05f-6374-423e-ad40-5813170c4f1c"] = "WorldEntities/Seeds/RedGreenTentacleSeed";
        data["a276b8a6-11e0-444d-b46d-02209a3957d9"] = "WorldEntities/Atmosphere/Inactive Lavazone/MagmaTree_Sphere";
        data["a28fe83a-87b3-4007-9a68-3f5cfb06d271"] =
            "WorldEntities/Slots/BloodKelp_DeepTrench/BloodKelp_Loot_TrenchFloor";
        data["a29a3902-0f97-4f75-b915-0a63dc5b9b68"] =
            "WorldEntities/Slots/SafeShallows/SafeShallows_Loot_TechSite_Hidden";
        data["a29bf6aa-d186-46fd-9704-d67b1631b73d"] =
            "WorldEntities/Slots/LostRiver/BonesField/BonesField_Creature_Corridor_Ceiling";
        data["a2a065c0-8f17-4598-a86e-f11b0568767a"] =
            "WorldEntities/Slots/GrassyPlateaus/GrassyPlateaus_Loot_EscapePod_Small";
        data["a2a86743-859f-48d3-b3a2-7ce216fd077c"] = "WorldEntities/Slots/LostRiver/TreeCove/TreeCove_Loot_Ground";
        data["a2cc576b-a292-4c06-8eb0-ffd3da7d855e"] = "Base/Ghosts/BaseReinforcement";
        data["a2e36982-f535-4b05-b6a2-2c2a60d7797e"] =
            "WorldEntities/Slots/LostRiver/BonesField/BonesField_Creature_Wall";
        data["a30d0115-c37e-40ec-a5d9-318819e94f81"] = "WorldEntities/Doodads/Precursor/Precursor_Lab_microscope";
        data["a30dd40b-cd3f-4320-8ba9-f2c98e06450e"] =
            "WorldEntities/Slots/GrassyPlateaus/GrassyPlateaus_Loot_CavePlants";
        data["a3134f27-ea27-4691-a23c-fa58be8905d2"] = "WorldEntities/Slots/LostRiver/Corridor/Corridor_Loot_Roots";
        data["a3163af2-ffae-4579-b8d9-c35bb793394e"] =
            "WorldEntities/Environment/Precursor/Prison/TeleporterRooms/Precursor_Prison_TeleporterTerminal_ToLostRiver";
        data["a330a5b4-4c4c-434f-b491-f0f4186e0413"] =
            "WorldEntities/Slots/LostRiver/BonesField/BonesField_Loot_Lake_Floor";
        data["a3476419-0a2f-40e7-b325-0a592f0ebea3"] =
            "WorldEntities/Environment/Precursor/Cache/Precursor_lab_container_02_LabCache";
        data["a350f815-1cec-4eec-898e-e5246d0b236e"] = "WorldEntities/Lights/EmperorFacility/AnteChamber_SpotLight";
        data["a36047b0-1533-4718-8879-d6ba9229c978"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/biodome_lab_tube_01";
        data["a3752d79-75b6-4c23-a01d-50b0cf04e9d5"] =
            "WorldEntities/Environment/Precursor/Prison/Aquarium/Precursor_Prison_Aquarium_TeleporterStand_Final";
        data["a391dda4-6e4f-4d8b-ac85-0e910e81f42e"] =
            "WorldEntities/Atmosphere/Ship/CrashedShip_InteriorEntrance_obsolete";
        data["a3c40990-269e-4821-ae52-e66eec6ded6a"] =
            "WorldEntities/Environment/Aurora/Aurora_DisableGlobalWaterVolume_LowerEntry";
        data["a3ccf0d9-e8e2-4ec5-b1d2-8da9b63a50e4"] =
            "WorldEntities/Lights/Precursor/Aquarium/Aquarium_Platform_Uplight 2";
        data["a3d11348-e589-4867-ac60-1fa122145615"] = "WorldEntities/Doodads/Coral_reef/Crab_snake_mushrooms_04";
        data["a3d7ddd0-bdcb-4d7c-ab00-3003c9245180"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/explorable_wreckage_modular_room_details_05";
        data["a4004101-7007-4808-a4e9-2cdb0607bad8"] = "WorldEntities/Tools/HeatBlade";
        data["a4348961-a95c-4798-925e-fd0ac1860f8a"] = "Base/Ghosts/BaseCorridorX";
        data["a434c32f-7fb5-49b5-b6f3-6a974a05403e"] = "WorldEntities/Lights/Kelpforest/Bounce_Normal";
        data["a449ffcb-93cd-4536-a166-a0ece8351f33"] =
            "WorldEntities/Slots/LostRiver/SkeletonCave/SkeletonCave_Creature_Lake";
        data["a45f9227-e8a4-4df2-9ef5-2ce7d5ec2ad5"] = "WorldEntities/Doodads/Debris/Starship_exploded_debris_31";
        data["a474e5fa-1552-4cea-abdb-945f85ed4b1a"] = "WorldEntities/Doodads/Geometry/CrashSite/CrackedRock";
        data["a4793f2b-d1ef-430a-900d-a42c34da71b8"] =
            "WorldEntities/Slots/MushroomForest/MushroomForest_Creature_GiantTreeRootBase";
        data["a4912ba2-5643-46ee-bd69-6be53dd55d45"] =
            "WorldEntities/Doodads/Coral_reef_Light/Coral_reef_Kelp_blood_02_Light";
        data["a4a84d36-9c23-433c-b8b1-08356ebbaba9"] = "WorldEntities/Slots/KooshZone/KooshZone_Creature_Sand";
        data["a4ad13d2-8f28-4b0b-abb3-d51cc4271d7a"] = "WorldEntities/Doodads/Coral_reef/coral_reef_plant_middle_11";
        data["a4be67bb-f6e1-4d15-bf08-9d9a3fae4bfa"] = "WorldEntities/Doodads/Land/Tropical Plant 1a";
        data["a4d261c3-8b08-41d4-9ab4-c647bdbf2bde"] = "WorldEntities/Doodads/Debris/Aurora/Rooms/CrashedShip_exo_room";
        data["a5076433-b586-4c4f-adff-b002028e8014"] = "WorldEntities/Doodads/Coral_reef/Coral_reef_koosh_bush_medium";
        data["a50c91eb-f7cf-4fbf-8157-0aa8d444820c"] = "WorldEntities/Fragments/Beacon_Fragment";
        data["a50ed435-90fa-41e5-898b-75cc98694c45"] =
            "WorldEntities/Slots/seaTreaderPath/SeaTreaderPath_Creature_OpenShallow";
        data["a523a6be-7358-479f-b07a-71a492e62247"] =
            "WorldEntities/Doodads/Precursor/Precursor_cube_03_damaged_piece_02";
        data["a5338fb9-0d3b-43ba-b056-a2e6661090b8"] = "WorldEntities/Tools/Beacon_damaged";
        data["a5451aee-16a3-406a-ac64-5aa14ac1c785"] = "WorldEntities/Atmosphere/Ship/CrashedShip_Interior_LivingArea";
        data["a55cb287-07ee-4463-95fa-a8a5539e6fa5"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/descent_bar_seat_side_05";
        data["a55ec9a0-8962-4388-8afa-6f18fb5ea789"] =
            "WorldEntities/Doodads/Precursor/Precursor_cube_03_damaged_piece_03";
        data["a58e84a0-a19c-4c54-a782-b4c57afa82bb"] = "WorldEntities/Doodads/Precursor/precursor_lock_C_01_02";
        data["a59cee6b-f605-4641-a236-15ee99ac31f2"] = "WorldEntities/Atmosphere/Ship/CrashedShip_Interior_SeamothRoom";
        data["a5b073a5-4bce-4bcf-8aaf-1e7f57851ba0"] = "WorldEntities/Doodads/Bubbles";
        data["a5b5c3a9-8b15-49c4-ba17-a98ed52b8949"] = "WorldEntities/Natural/KooshZoneEgg";
        data["a5d00fd4-ee01-4d51-b932-7ecb5d90d052"] = "WorldEntities/Environment/Wrecks/tech_light_ShortRangeLight";
        data["a5efc263-8fc6-47db-8432-4647677f1fb4"] = "WorldEntities/Seeds/PurpleVegetable";
        data["a5f0e345-1e46-410f-8bf1-eeeed3e5a126"] = "WorldEntities/Doodads/Debris/Starship_exploded_debris_25";
        data["a600c707-fba2-4272-9afb-5515b1c9e336"] = "WorldEntities/Food/CuredHolefish";
        data["a620b5d5-b413-4627-84b0-1e3a7c6bf5b6"] = "Submarine/Build/ThermalPlant";
        data["a62ceaec-b540-4baf-aaa4-f57b9f204482"] =
            "WorldEntities/Slots/DeepGrandReef/DeepGrandReef_Loot_AbandonedBase_Outside_Medium";
        data["a65a3a02-5337-44a1-933e-f9c91bee203b"] =
            "WorldEntities/Slots/BloodKelp_DeepTrench/BloodKelp_Creature_TrenchWall";
        data["a65cf543-2d3f-40d4-b07f-387b52a92759"] =
            "WorldEntities/Slots/LostRiver/BonesField/BonesField_Creature_Corridor_Stream";
        data["a6a347cb-b211-4ba8-84fe-a841b2fc5709"] =
            "WorldEntities/Environment/Precursor/LostRiverBase/Precursor_LostRiverBase_BrokenAnchor3";
        data["a6dac068-6f8d-4e32-b5e7-2e34a9f97d11"] =
            "WorldEntities/Doodads/Coral_reef/coral_reef_blood_mushrooms_01_04";
        data["a6e122ef-837a-492a-9646-e478f28893be"] =
            "WorldEntities/Slots/seaTreaderPath/SeaTreaderPath_Loot_CaveCeiling";
        data["a711c0fa-f31e-4426-9164-a9a65557a9a2"] = "WorldEntities/Doodads/Lost_river/Reefback_coral_01";
        data["a7130f2f-a24d-405f-ad72-e4049bd7f8ea"] =
            "WorldEntities/Doodads/Precursor/Precursor_Prison_Interior_Aquarium";
        data["a713b5d2-c9b8-4008-b89f-f61a5c868528"] = "WorldEntities/Slots/BloodKelp_Trench/BloodKelp_Loot_Wall";
        data["a7192297-a1a2-49ad-8ace-355db0508b2e"] =
            "WorldEntities/Slots/FloatingIsland/FloatingIsland_Loot_AbandonedBase_Inside_Medium";
        data["a71da66c-6d43-45c1-bc7f-a789cfc61e46"] = "WorldEntities/Doodads/Coral_reef/coral_reef_small_deco_16";
        data["a71f36cb-af91-4212-84ce-d34de1043882"] =
            "WorldEntities/Slots/KooshZone/KooshZone_Loot_KooshZone_MountainRidges";
        data["a72c61ae-1ab7-4ee8-bced-b76505d3f1e2"] = "WorldEntities/Doodads/Fragments/Map_Room_fragment_02";
        data["a73218d6-b307-450a-890e-ec2e2c206324"] = "WorldEntities/Fragments/seamoth_fragment_05";
        data["a73f17b9-2607-467a-95b9-b24bd0f65e69"] = "WorldEntities/Slots/EntitySlotsPlaceholder";
        data["a743777f-1c01-47e9-8436-d107032a0c87"] =
            "WorldEntities/Doodads/Precursor/LavaBase/Final_Rooms/Precursor_LavaBase_Entry01";
        data["a7519acf-6dec-429e-82ed-bbcf7a616c50"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/docking_clerical_clipboard1";
        data["a7a11d87-78d6-46a6-b3d9-da7341e06d6b"] = "WorldEntities/VFX/xSandPileDig";
        data["a7aef01f-0dc0-4d03-913d-d47d8d2ba407"] = "WorldEntities/Doodads/Land/land_plant_small_03_03";
        data["a7b35deb-1ac7-4fb8-8393-c0252cbf6d23"] = "WorldEntities/Natural/FloatingStone1_Floaters";
        data["a7b4dc5f-6603-4f27-99e1-2586a9ea20a4"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/explorable_wreckage_modular_room_details_14";
        data["a7b70c23-8e57-43e0-ab39-e02a29341376"] = "WorldEntities/Creatures/HoleFishSchool";
        data["a7e239bd-67cb-4891-86d5-91a9399f391f"] = "WorldEntities/Slots/Ship/Loot_ShipInterior_ExoRoom_Crate";
        data["a7e272d1-46ce-4346-abb5-2f709eba0777"] = "WorldEntities/Atmosphere/KelpForest/Normal (Sphere)";
        data["a815207b-354b-473b-a90c-9458b27247a0"] =
            "WorldEntities/Slots/JellyshroomCaves/Jellyshroom_Loot_TechSite_Barrier_Small_Obsolete";
        data["a81de30c-b5cd-4bb0-ba2e-4c2e0b4bb04f"] = "WorldEntities/Environment/DataBoxes/DataboxLight_small";
        data["a8490838-57ce-47a2-b4c2-3040de55c50b"] =
            "WorldEntities/Environment/DataBoxes/CyclopsShieldModuleDataBoxSpawner";
        data["a84f22af-9802-49c2-92ff-5c58335593a1"] =
            "WorldEntities/Doodads/Precursor/LavaBase/Final_Rooms/Precursor_LavaBase_Hallway";
        data["a8639442-471c-4958-9f53-b1c6a7acab6e"] =
            "WorldEntities/Slots/KelpForest/KelpForest_Creature_UniqueCreatureCave";
        data["a8901a9c-3c87-4ec3-9fa8-4a4815928ffa"] = "WorldEntities/Lights/Precursor/Precursor_Cave_Ambient_Med_2";
        data["a8c15c6a-428f-4cf2-987f-6bd9c59b04ce"] =
            "WorldEntities/Environment/Precursor/Prison/Moonpool/Precursor_Prison_Moonpool_Lights";
        data["a8dd36b6-7d02-4d59-a7db-42c19fc5f97f"] =
            "WorldEntities/Slots/MushroomForest/MushroomForest_Creature_CaveRecess";
        data["a8ddd876-cb85-4c32-a77c-3ae9de0baa62"] = "WorldEntities/Atmosphere/KooshZone/Kooshcave_Dark_green_sphere";
        data["a8e62c84-a82a-457c-b76d-9149c501da1c"] = "WorldEntities/Doodads/Debris/Wrecks/Decoration/wall_shelves";
        data["a8ef86cb-e056-4f12-afc1-e1e491a1394d"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/descent_bar_seat_straight_02";
        data["a90e9c2f-97e3-4628-8e28-df909331b8ee"] = "WorldEntities/Doodads/Land/Tropical Plant 2b";
        data["a966a14f-d188-4de4-a488-f2c0302ca250"] = "WorldEntities/Doodads/Land/farming_plant_01_01";
        data["a96ebe2c-3520-4181-9799-8d98649c3bbe"] =
            "WorldEntities/Environment/Precursor/SurfaceVents/Precursor_SurfaceVent";
        data["a9752782-82d4-4d02-bcc1-d442028969e7"] =
            "WorldEntities/Environment/AbandonedBases/AbandonedBase PDA/DeepPDA1";
        data["a9958cbb-72eb-4a1d-af7b-13fbc947d8f3"] = "WorldEntities/Doodads/Coral_reef/Coral_reef_koosh_bush_huge";
        data["a9b53ca9-6c28-4651-a804-d7f2634f5417"] = "Base/Ghosts/BaseRoom";
        data["a9bd9fbd-d9e4-4dc8-a65c-91200767286d"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/Starship_wires_02";
        data["a9c7871a-9e1d-4aec-90a8-4553916eac31"] =
            "WorldEntities/Slots/DeepGrandReef/DeepGrandReef_Loot_RockShallow";
        data["a9da9324-84ed-4a51-9ed3-a0969f455067"] = "WorldEntities/Food/CookedPeeper";
        data["a9fd0245-278e-49f8-9ef7-4eaddb84806a"] =
            "WorldEntities/Lights/Precursor/Precursor_Prison_PipeRoom_Lights";
        data["aa01d1ff-c586-4ba3-80ec-8c65fd43cd49"] = "WorldEntities/Lights/Koosh Zone/KooshCave_pink_amb";
        data["aa1abbb9-716c-44b8-a2b8-cb4d9d0f22bb"] = "WorldEntities/Doodads/Coral_reef/coral_reef_small_deco_11";
        data["aa316077-f48f-420a-a105-0412ed3ff936"] =
            "WorldEntities/Slots/MushroomForest/MushroomForest_Loot_CaveRecess";
        data["aa370acc-73da-469d-bd27-21ba968acec0"] = "WorldEntities/Doodads/Land/Land_grass_05_ring";
        data["aa5e08ee-e1de-4ed0-ac58-1fb487fcb531"] =
            "WorldEntities/Lights/LostRiver/BonesField/LostRiver_BonesField_Lake_Light_Large";
        data["aa6af4ad-ce4a-444f-b9af-3b8e053c8d93"] = "WorldEntities/Slots/GrandReef/GrandReef_Loot_WhiteCoral";
        data["aa6b2ede-a1bf-4f70-980c-9ed2a51375a1"] =
            "WorldEntities/Lights/Precursor/Precursor_Cache_Spotlight_Generic_Bright";
        data["aa8dabc9-b1f1-459e-ae41-ce0fd160c2a4"] = "WorldEntities/Lights/Precursor/Precursor_Cave_Lake";
        data["aa8ef061-2bc4-4089-b3c7-22a081ccfb83"] = "WorldEntities/Environment/Prototype/Falling rock";
        data["aa934abc-def5-4998-aa61-30e9730d1223"] =
            "WorldEntities/Slots/GrassyPlateaus/GrassyPlateaus_Creature_TowerSmallBase";
        data["aaa38254-70b2-451b-9c8e-e1824d8a9ace"] = "WorldEntities/Doodads/Land/land_grass_01_yellow";
        data["aacc9e79-b202-40dd-9c3b-76b09eb807f2"] =
            "WorldEntities/Slots/Prison/Aquarium/PrisonAquarium_Loot_CaveCeiling";
        data["aad81104-9f02-47ec-8095-e99ede823b90"] = "WorldEntities/Doodads/Debris/Wrecks/ExplorableWreckHull01";
        data["aae92b67-b483-41d0-8ff5-1ee99c7b1853"] = "WorldEntities/Lights/Mushroom Forest/MF_cache_accent";
        data["ab0cbd59-d0be-43ed-b917-bc0bb925ad18"] = "WorldEntities/Environment/DataBoxes/StillSuitDataBox";
        data["ab13c7a7-2b09-4feb-b9a5-db682e990071"] =
            "WorldEntities/Environment/Wrecks/ExplorableWreck_SafeShallows_16_WeldablePanel2";
        data["ab2d01f0-56de-400b-a975-0a9a89dfca61"] =
            "WorldEntities/Environment/DataBoxes/RepulsionCannonDataBoxSpawner";
        data["ab90da4b-8436-4ecc-a09c-114b0de108b2"] =
            "WorldEntities/Environment/Wrecks/ExplorableWreck_KelpForest_18_WeldablePanelRoot";
        data["abb2e006-acfd-47e1-8abd-5b2c02d458a0"] =
            "WorldEntities/Slots/KooshZone/KooshZone_Loot_Techsite_Scatter_Medium";
        data["abd13df7-bb4a-40aa-8428-f68194d3601f"] =
            "WorldEntities/Slots/UnderwaterIslands/UnderwaterIslands_Creature_IslandCaveWall";
        data["abe4426a-5968-40b0-9d99-b06207984aa8"] = "WorldEntities/Doodads/Land/Jungle Tree 3a";
        data["abe572e9-126b-43eb-bf5c-4edf9ec365c1"] = "WorldEntities/Doodads/Coral_reef/Coral_reef_cave_root_01_blood";
        data["abfcaf57-0cb5-4916-a038-8f4f68141879"] =
            "WorldEntities/Environment/DataBoxes/CreatureDecoyModuleDataboxSpawner";
        data["abfd2c46-f49e-41af-a965-73048dc9bf28"] = "WorldEntities/Fragments/Constructor_Fragment";
        data["ac1065e1-b402-4dcd-94c1-de008018a8f7"] =
            "WorldEntities/Atmosphere/Precursor/EmperorFacility/Precursor_Prison_Aquarium_Cave_Atmosphere";
        data["ac2b0798-e311-4cb1-9074-fae59cd7347a"] =
            "WorldEntities/Environment/Precursor/SkeletonCave/SkeletonCave_Precursor_Scanner_03";
        data["ac6dd6fe-5835-41b9-96e8-2ec4120699ff"] =
            "WorldEntities/Doodads/Precursor/Prison/Precursor_Prison_TankGlassSmall";
        data["ac97373b-0fc0-493f-8ffb-2146287678c9"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/Starship_big_gate_doors_01_L";
        data["ac997abf-659f-4fbe-a318-64606a161d7e"] = "WorldEntities/Fragments/PropulsionCannonJunkFragment";
        data["aca3da67-6739-40e3-b8b6-1fbf7eb80dd2"] = "WorldEntities/Slots/Ship/Loot_ShipInterior_LivingArea_Small";
        data["acb84364-02ec-42d7-8bb2-8a713f526c1d"] = "WorldEntities/Tools/HullReinforcementModule";
        data["acba4eab-6bb4-46f6-8956-adee68df6192"] =
            "WorldEntities/Doodads/Precursor/TempGun_Interiors/MoonPool_Hallway_01";
        data["acc078b2-11a4-447a-bba2-79a7aff32a55"] = "WorldEntities/Atmosphere/Inactive Lavazone/MagmaBubble_Sphere";
        data["acce0e3d-3d4b-4ca9-bd0e-e2f3e6466283"] =
            "WorldEntities/Slots/FloatingIsland/FloatingIsland_Creature_Beach";
        data["acf92ba7-2e75-44c9-ab23-9ca1dc3bedda"] = "WorldEntities/Atmosphere/LostRiver/Junction/LostRiver_Junction";
        data["ad02d2ce-0cb7-4e70-8f44-f7a8354561c7"] = "WorldEntities/Atmosphere/Inactive Lavazone/Normal";
        data["ad18b555-9073-445e-808a-d8b39d72f22e"] = "WorldEntities/Creatures/Mesmer";
        data["ad1e0255-d577-43ac-afa6-4cf17e08a067"] = "WorldEntities/Environment/Wrecks/ExplorableWreck_Grassy_12";
        data["ad2123da-d125-43ed-9ce4-7f96a8d01cea"] = "WorldEntities/Lights/LostRiver/Point_Tree_Cove_Blue_lrg";
        data["ad23314d-256d-4b8a-ab4e-e49502f62723"] = "WorldEntities/Fragments/ExosuitDrillArmfragment";
        data["ad248949-1a8d-44f4-b8da-f294045f9e27"] =
            "WorldEntities/Doodads/Precursor/Precursor_Interior_Damage_Props_05";
        data["ad2c3d8a-cf4e-49eb-a4d3-200339fff75f"] = "WorldEntities/Seeds/OrangePetalsPlantSeed";
        data["ad5e149b-d35c-4b46-bb4e-b4c0a9c6e668"] = "Submarine/Build/Marki_03";
        data["ad6d37cb-14c0-49c4-b697-4d633da1ccd9"] = "WorldEntities/Slots/SparseReef/SparseReef_Creature_Coral";
        data["ad91e879-6b8e-4b81-8fd5-9a0c9e775570"] = "Submarine/Build/SpecialHullPlate";
        data["ad982a4b-68a0-4662-b093-f4898b2f8171"] = "WorldEntities/Doodads/Coral_reef/Coral_reef_shell_02_03";
        data["adad4264-23ee-4303-8369-9f6471d91c28"] = "WorldEntities/Seeds/AcidMushroomSpore";
        data["adcace2c-509e-429e-9d24-9760a2d58ff4"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/Starship_work_chair_01";
        data["add9125b-3691-4e5e-81eb-8d1306781f07"] =
            "WorldEntities/Environment/Precursor/Gun/Mountain_DisableGlobalWaterVolume_CaveEntry";
        data["adfcf419-12e7-46f9-ac15-08b37222aafb"] = "WorldEntities/Slots/Mountains/Mountains_Loot_IslandCaveFloor";
        data["ae06567b-4afd-4aff-9904-e518c1e8e30a"] =
            "WorldEntities/Doodads/Precursor/Precursor_cube_03_damaged_piece_07";
        data["ae0a831e-0f90-43bd-8183-c2002c528e9e"] = "WorldEntities/Environment/FanPlant";
        data["ae210dd4-68f0-4c77-9025-ef7d116948b3"] = "WorldEntities/Doodads/Coral_reef/Coral_reef_grass_01_red";
        data["ae29bdea-72aa-4aae-9099-5bd2509891fa"] = "WorldEntities/Slots/CragField/Cragfield_Creature_Grass";
        data["ae303198-c5a7-403d-9e17-466ab52c051a"] =
            "WorldEntities/Slots/seaTreaderPath/SeaTreaderPath_Creature_Sand";
        data["ae374d9f-22b7-4bd5-af62-45a6aba30727"] = "WorldEntities/Lights/Kelpforest/Stinger_Light";
        data["ae941ec4-075d-4e1b-9686-3ee3ef8c1889"] = "WorldEntities/Doodads/Coral_reef/Coral_reef_shell_02_12";
        data["ae9617a4-9928-4c95-a0ce-1fc7b1142a57"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/Base_interior_wall_planter_leaves_03";
        data["aebec184-efd3-430e-bc8f-f6d7a0f0fe68"] = "Submarine/Build/JackSepticEyeHullPlate";
        data["aedbec0f-4d92-4fcb-a08b-676ea0a93a2e"] = "WorldEntities/Slots/LostRiver/TreeCove/TreeCove_Loot_Algae";
        data["aeeecb1a-08c3-4cde-ac8e-c05a3b700743"] = "WorldEntities/Environment/Wrecks/PDAs/EscapePod_12_PDA";
        data["aefe2153-9e68-41cf-9615-253aa6f965aa"] = "WorldEntities/Creatures/Oculus";
        data["aeff4dad-8256-475b-a764-d5e7028220ce"] = "WorldEntities/Fragments/LaserCutterFragment";
        data["af03cdf9-ab08-4ad9-b89a-de3e90b25f47"] = "Submarine/Build/HullPlate02";
        data["af165b07-a2a3-4d85-8ad7-0c801334c115"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/discovery_lab_cart_01";
        data["af1e5b4e-1417-49d6-b20b-5f980a2ccee8"] =
            "WorldEntities/Atmosphere/LostRiver/BonesField/LostRiver_BonesField_Ledge";
        data["af413920-4fe6-4447-9f62-4f04e605d6be"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/Starship_cargo_opened_large";
        data["af4940e1-6f31-4d6a-9acc-d5325592043e"] = "WorldEntities/Doodads/Precursor/precursor_lock_C_01_01";
        data["af5d3311-3fda-4c7b-97b2-d75b56927b39"] =
            "WorldEntities/Slots/seaTreaderPath/SeaTreaderPath_Loot_CaveWall";
        data["af65ba8c-39c9-4081-899b-63bc59f4e77c"] = "WorldEntities/Doodads/Lost_river/LostRiver_Cave_Collision";
        data["af7ed37e-958f-4b56-b84e-747a7d5a0315"] =
            "WorldEntities/Doodads/Precursor/Precursor_Interior_Damage_Props_09";
        data["af7eda28-d428-45c8-bf86-33fd837a863a"] =
            "WorldEntities/Doodads/Precursor/Prison/Aquarium/Precursor_Prison_TeleporterRoom_04_Lights";
        data["af886bfe-81db-4d8a-93ff-76190265fff4"] = "WorldEntities/Tools/RepulsionCannon";
        data["af8a1867-0362-4aa9-b26d-29b4632421d3"] =
            "WorldEntities/Environment/Precursor/Prison/TeleporterRooms/Precursor_Prison_TeleporterTerminal_ToMushroomForest";
        data["af951d12-3257-4224-a027-657e7e41f587"] = "WorldEntities/Tools/DoubleTank";
        data["afba45cf-00f9-4d80-a203-429d6ce7ff62"] = "WorldEntities/Seeds/FernPalmSeed";
        data["afc1cadd-6441-43c9-8d58-3eddd3289af1"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/starship_girder_03";
        data["afc2a9c3-6388-4258-9653-b2918c2315d5"] = "WorldEntities/Atmosphere/ActiveLavazone/Normal";
        data["afc635fd-085b-4d94-9999-20be888ad339"] = "WorldEntities/Atmosphere/DeepGrandReef/Open_named (Sphere)";
        data["afe53ea1-d2a8-4f76-8ffb-d41ff6046b52"] =
            "WorldEntities/Environment/Aurora/Aurora_ExtinguishableFire_Medium_Tall";
        data["affbc9dc-a5cf-4f87-87c9-8dd4aa950be1"] = "WorldEntities/Environment/Aurora/PDAs/Aurora_RingRoom_PDA1";
        data["b067ee9e-6613-4631-8c77-86e4ecbc3c98"] = "WorldEntities/VFX/xSparksBlue_3s_Small";
        data["b09a156d-d3cf-455a-848d-a9a8cad2b811"] = "Submarine/Build/CoffeeVendingMachine";
        data["b0b7e82f-0967-4e82-a888-00fe0121b843"] = "WorldEntities/Environment/Aurora/Aurora_ExoRoom_Keypad";
        data["b0c57af4-d3fb-459b-b67c-2f537f781f1e"] = "WorldEntities/Tools/Stillsuit";
        data["b0cae640-b155-4bac-9ed5-29ba64a1ee9f"] =
            "WorldEntities/Doodads/Coral_reef_Light/Coral_reef_cave_root_02_blood_Light";
        data["b0d0a942-0a64-4cfc-9f7a-49aef7c8c6f2"] = "WorldEntities/Tools/CyclopsHullModule2";
        data["b12b0142-1676-450b-bf47-fd128ab71ad8"] = "WorldEntities/Environment/Wrecks/EscapePod_3_SafeShallows_old";
        data["b13e84bb-f76d-4cc0-aa35-fc1a72a8bc60"] = "WorldEntities/Atmosphere/KelpForest/Caves (Sphere)";
        data["b1446067-3acb-4a19-b784-652510765ea2"] = "WorldEntities/Seeds/MembrainTreeSeed";
        data["b144817f-6aee-4932-be6d-be5cb5e1cf8b"] = "WorldEntities/Fragments/Old/powercellchargerfragment_old";
        data["b179b366-4342-4545-aa4d-a86ad88b780e"] = "WorldEntities/Atmosphere/GrassyPlateaus/Caves";
        data["b1932ce7-2f62-41be-a48e-15bb487f0a29"] =
            "WorldEntities/Environment/Precursor/LavaCastleBase/Precursor_LavaCastleBase_ThermalPlant_Door";
        data["b19be61c-b011-400f-9cfe-4ad9c70adf6d"] = "WorldEntities/Environment/Wrecks/cyclopshullfragment9";
        data["b1a3945c-4aba-4907-96ab-11d6935e7126"] = "WorldEntities/Environment/Wrecks/PDAs/Aurora_LivingArea_PDA1";
        data["b1b90d0e-468c-4d42-80c3-7beaacd12f85"] =
            "WorldEntities/Environment/Precursor/Prison/TeleporterRooms/Precursor_Prison_TeleporterRoom_02";
        data["b1d76d15-f5ec-4ee9-a895-1a547f8020ef"] =
            "WorldEntities/Doodads/Precursor/LavaBase/Lights/Precursor_LavaCastleBase_ThermalRoom_Lights";
        data["b1d88c87-fd48-495b-a707-e91dc4259858"] = "WorldEntities/Food/CuredHoverfish";
        data["b1e2a070-d104-45d1-ba96-f1b5753d6929"] = "WorldEntities/Food/CookedGarryfish";
        data["b1ee26b9-dd90-4e0c-b4d1-7be399dfa7f5"] =
            "WorldEntities/Doodads/Precursor/Gun/Precursor_Gun_Ramp_Animated";
        data["b1f54987-4652-4f62-a983-4bf3029f8c5b"] =
            "WorldEntities/Environment/Precursor/Gun/Precursor_Gun_DisableGunTerminal";
        data["b24e3e84-4b33-4202-9c1e-1032ef3a8d72"] = "WorldEntities/Doodads/Debris/Starship_exploded_debris_01_Far";
        data["b250309e-5ad0-43ca-9297-f79e22915db6"] = "WorldEntities/Doodads/Lost_river/lost_river_skull";
        data["b2636f23-f764-41ec-bfcf-f33d35d79641"] = "WorldEntities/Doodads/Coral_reef/coral_reef_plant_middle_09";
        data["b28f7dae-fbb6-49b6-9f3d-f98fb7eabb26"] =
            "WorldEntities/Atmosphere/LostRiver/Corridor/LostRiver_Corridor_ThermalVents";
        data["b2d10d9b-878e-4ff8-b71f-cd578e0d2038"] = "WorldEntities/Natural/metal4";
        data["b2e0b5be-d92d-41e5-b8d5-352156eef3c3"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/starship_girder_07";
        data["b32c2582-2985-40c9-b176-5dd8b94cedad"] = "WorldEntities/Tools/CyclopsHullModule1";
        data["b32c8d9e-1e47-47de-b158-a4b2dc99d624"] =
            "WorldEntities/Doodads/Coral_reef/Coral_reef_blue_barnacles_01_02";
        data["b334fbb1-224b-4082-bb69-d4a39051aaca"] = "WorldEntities/Natural/Lead";
        data["b33e3ff5-7185-4312-9e46-ff019a05524f"] =
            "WorldEntities/Doodads/Precursor/TempGun_Interiors/Precursor_Gun_Teleporter_Room";
        data["b343166e-3a17-4a1c-85d1-05dee8ec1575"] = "Submarine/Build/Sign";
        data["b370a70c-da52-444d-9a26-71ffa9ed3b43"] = "WorldEntities/Tools/SeamothSonarModule";
        data["b3787525-0afa-40b1-ae3f-9cd995f24d61"] = "WorldEntities/Slots/Prison/Aquarium/PrisonAquarium_Loot_Wall";
        data["b3ba7af5-891b-45ab-b50c-8221a222db52"] = "Submarine/Build/Submarine_hull_fragments_04";
        data["b3cb0fcd-5bff-4152-8188-955172484705"] = "WorldEntities/Fragments/CyclopsHull_Fragment_Medium";
        data["b3d5e742-554f-4f7f-a36c-57c800c082a9"] = "WorldEntities/Slots/JellyshroomCaves/Jellyshroom_Loot_CaveSand";
        data["b3d9a2eb-0908-4758-88b0-e5c92797ae1f"] = "WorldEntities/Slots/BloodKelp/BloodKelp_Creature_Grass";
        data["b3db72b6-f0cf-4234-be74-d98bd4c49797"] = "WorldEntities/Natural/drillable/DrillableQuartz";
        data["b3f272f4-af9f-4399-a9e1-3b5d99e23a24"] = "WorldEntities/Environment/DataBoxes/CompassDataBoxSpawner";
        data["b406a871-b851-48bd-a290-d9a453a71a50"] = "WorldEntities/Environment/Prototype/SmallRock";
        data["b409ed8d-9a73-4140-ac06-3aa60b66aa47"] = "WorldEntities/Environment/Floater";
        data["b41f71d6-d9d5-411d-8726-e8433b181480"] = "WorldEntities/coral_reef_grass_03_02";
        data["b4478ef8-8593-48b5-a149-37793c5c156f"] =
            "WorldEntities/Slots/UnderwaterIslands/UnderwaterIslands_Creature_IslandSides";
        data["b447ac10-bf6b-4005-8ffc-8d9a4e84450b"] = "WorldEntities/Doodads/Coral_reef/JeweledDiskPiece";
        data["b460a6a6-2a05-472c-b4bf-c76ae49d9a29"] = "Submarine/Build/StarshipMonitor";
        data["b47462ea-4a7b-4be9-84fa-ec0acb92bf37"] = "WorldEntities/Tools/DiamondBlade";
        data["b4e59f7f-a7e0-4f1d-b7bd-2805a1bdb7b8"] = "Submarine/Build/Submarine_hull_fragments_02";
        data["b4ec5044-5519-4743-b61b-92a8b6fe4a32"] = "WorldEntities/VFX/xFloatingPapers";
        data["b582bcdd-d4ac-426c-b86c-5f4abce58c1e"] =
            "WorldEntities/Slots/LostRiver/Junction/Junction_Loot_Water_Floor";
        data["b5a4d5ca-e531-4312-b2df-ab9c7d60ff12"] =
            "WorldEntities/Slots/GrassyPlateaus/GrassyPlateaus_Loot_EscapePod_Medium";
        data["b5a62048-0577-4a85-a7bd-a1896fbc1357"] = "WorldEntities/Doodads/Lost_river/lost_river_skull_coral_08";
        data["b5a6ce17-285c-4683-a754-6b8345d08240"] = "WorldEntities/Doodads/Precursor/Precursor_cube_03";
        data["b5b0d7c8-67a7-4af6-98b8-dabd75464818"] = "WorldEntities/Fragments/Old/SafeShallowsFragment";
        data["b5b542b0-1b42-4fbe-ad58-f37ee3110c61"] = "WorldEntities/Natural/FloatingStoneSmall1";
        data["b5d43e60-df34-4ad7-9fd1-b752a8d13de2"] = "WorldEntities/Environment/DataBoxes/WaterParkDataboxSpawner";
        data["b5d6cf1a-7d42-45f2-a0f3-0e05ff707502"] = "WorldEntities/Eggs/JumperEgg";
        data["b628d104-dcad-4fac-8a12-d0c4ef473d93"] = "WorldEntities/Doodads/Lost_river/lost_river_plant_01_03";
        data["b629c806-d3cd-4ee4-ae99-7b1359b60049"] = "WorldEntities/Doodads/Precursor/Precursor_computer_terminal_C";
        data["b655cb95-bc48-4b15-b579-2b5895d67137"] = "WorldEntities/Environment/Wrecks/PDAs/Aurora_SeamothRoom_PDA1";
        data["b65b2a26-34fa-42b0-8158-529b7a491302"] = "WorldEntities/Doodads/Debris/Wrecks/Decoration/bench_02_deco";
        data["b6794f07-f2b6-41e9-ad66-f3bc76fc532e"] =
            "WorldEntities/Slots/Mountains/Mountains_Creature_IslandCaveFloor";
        data["b679aaf5-be68-4868-9848-d37fdbf348bc"] = "Submarine/Build/BikemanHullPlate";
        data["b693a5ed-bdec-49e1-a7ee-f4849c7b72c9"] =
            "WorldEntities/Slots/LostRiver/Junction/Junction_Creature_Ground";
        data["b6c3cde4-739a-4a1a-b93b-78501ca9ae82"] = "WorldEntities/Eggs/GasopodEgg";
        data["b6c84447-e159-43d7-9440-f7d1ae0b86b3"] = "WorldEntities/Fragments/Old/DeepGrandReefFragment";
        data["b6e4b065-88f4-442c-92a3-1b92dbdc6ae3"] =
            "WorldEntities/Environment/Wrecks/ExplorableWreck_UnderwaterIslands_4";
        data["b6f620f0-e706-4362-81f9-fd63f985a9e9"] =
            "WorldEntities/Doodads/Coral_reef/Coral_reef_small_rocks_seaweed_02";
        data["b6fb57c3-c7ef-48bf-9a30-4cd23d856af4"] = "WorldEntities/Fragments/Old/basebulkheadfragment_old";
        data["b707aa52-1a27-43c4-9500-f346befb8251"] = "WorldEntities/Doodads/Coral_reef/coral_reef_plant_middle_05";
        data["b715508e-a7e4-47f0-a55b-bf6f65d24ac2"] = "WorldEntities/Doodads/Land/land_plant_small_03_05_vertical";
        data["b71823a1-4fbc-42dd-aa3a-caa5809f1f6c"] = "WorldEntities/Doodads/Lava/lava_rock_01_bubble_01";
        data["b71d679c-482d-46c3-8373-684c89334e11"] =
            "WorldEntities/Slots/LostRiver/TreeCove/TreeCove_Creature_Water_Wall";
        data["b726c4cb-78da-4e12-b170-cb4df615f899"] = "WorldEntities/Tools/Builder_damaged";
        data["b747b8a1-aeb8-4f78-bbe1-0fde356cf5b9"] = "WorldEntities/Slots/BloodKelp/BloodKelp_Loot_EscapePod_Medium";
        data["b75d03e4-abe9-40f9-8f1a-03fc2c1d5702"] = "WorldEntities/Doodads/Debris/Wrecks/ExplorableWreck2_clean";
        data["b76507fb-6976-4e79-9e62-6b89f9c30ebb"] = "WorldEntities/Lights/Grassyplateaus/Stinger_Light";
        data["b77e777e-60bf-418a-b04e-bf9408817d4c"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/docking_food_01_food2";
        data["b7838e40-e905-40c3-be3d-cb56eb8b9829"] = "WorldEntities/Fragments/Old/seamothfragment_old";
        data["b78912bc-0191-4455-a9de-3b708e165393"] = "WorldEntities/Eggs/CuteEgg";
        data["b7950b62-8f0b-46a5-903b-7f31480eb88b"] =
            "WorldEntities/Doodads/Precursor/precursor_block_deco_08_04_08_v3";
        data["b79fb664-dd70-47ce-aa05-0a03a98cfb01"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/descent_bar_seat_side_02";
        data["b7af0819-cdc9-479e-a6df-80260c0120b7"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/descent_bar_seat_side_03";
        data["b7eb3eea-a3d6-456d-a75a-8d2f8ca248b6"] =
            "WorldEntities/Environment/Precursor/Prison/PipeRoom/Precursor_Prison_PipeRoom_Pipes";
        data["b7ec7d50-186b-4656-9cc6-7dd503d14d98"] =
            "WorldEntities/Environment/Precursor/Gun/Precursor_Gun_Terminal2Door";
        data["b7f23477-f5c4-4775-b13f-41dde41ff841"] = "WorldEntities/Unused/AuroraRevealSound";
        data["b80629f6-2dc4-4250-846e-23ac3b5ddb80"] = "WorldEntities/Slots/Prison/Aquarium/PrisonAquarium_Loot_Grass";
        data["b80d8237-13e1-4627-9933-c79fe6a5949b"] = "WorldEntities/Food/CuredEyeye";
        data["b816abb4-8f6c-4d70-b4c5-662e69696b23"] =
            "WorldEntities/Environment/Precursor/Gun/Precursor_Gun_ControlRoom_DoorTerminalsRoot";
        data["b81b2503-e580-4448-b151-a02c8e86abcf"] = "WorldEntities/Atmosphere/Mountains/Mountains_Cave_sph";
        data["b823a2df-f873-411f-8752-991384872e41"] =
            "WorldEntities/Environment/Precursor/LavaCastleBase/Precursor_LavaCastleBase";
        data["b85d703f-724a-4988-ad51-600b66c283a1"] =
            "WorldEntities/Doodads/Precursor/precursor_cables_end_01_LavaCastle";
        data["b8604986-49e3-4139-86a3-c41574c08168"] =
            "WorldEntities/Lights/UnderwaterIslands/UnderwaterIslands_Cave_Point";
        data["b86d345e-0517-4f6e-bea4-2c5b40f623b4"] = "WorldEntities/Environment/Wrecks/Wrecks_Starship_doors_manual";
        data["b88a2b71-db4c-47e5-807d-c57fdf90f5ce"] =
            "WorldEntities/Doodads/Debris/Aurora/Rooms/CrashedShip_locker_room_coridor_02";
        data["b8b2dfbd-e252-49f3-99b1-a19ddabf38ec"] = "WorldEntities/Tools/Compass";
        data["b8b3da5d-32cc-450d-8b5f-20decdd8d9e9"] = "WorldEntities/Slots/ILZChamber/ILZChamber_Loot_MagmaBubble";
        data["b8bafddd-c627-49a2-a770-509a2e70e5f2"] = "WorldEntities/Slots/LavaLakes/LavaLakes_Creature_Open";
        data["b8e4c7f2-c18c-48ce-bac3-8576cf2eee39"] =
            "WorldEntities/Atmosphere/Precursor/LavaCastleBase/Precursor_LavaCastleBase_Atmosphere";
        data["b9072400-8147-43f4-b556-bd8de8a13bef"] = "Base/Ghosts/BaseCorridorGlassI";
        data["b90d01c9-7084-4513-bb1f-a0d94960295a"] = "WorldEntities/Slots/CrashZone/CrashZone_Creature_TrenchSand";
        data["b9383fb8-c28e-4825-9400-77e15f13641d"] = "WorldEntities/Environment/Wrecks/PDAs/Wreck7_TreaderPath_PDA1";
        data["b9764db6-1f2a-4cfc-bda0-8a179cb7e155"] = "WorldEntities/Fragments/seamoth_fragment_04";
        data["b986beee-2b3e-43b6-b6da-87ee6eb7925e"] = "WorldEntities/Lights/Precursor/Precursor_Cave_Ambient_Med";
        data["b98da0ef-29d4-4571-9a82-53a6e6706153"] = "WorldEntities/Doodads/Precursor/Prison/Relics/Alien_relic_03";
        data["b9a93710-5390-400b-8552-4b3071facbb8"] = "WorldEntities/Environment/Wrecks/ExplorableWreck_Dunes_a2";
        data["b9b6f515-2b10-43be-9c05-49877b244e36"] = "WorldEntities/Environment/SafeShallowsPDA1";
        data["b9bc16a6-45ba-4535-97be-175e564f01a1"] = "WorldEntities/Slots/Ship/Loot_ShipInterior_Cargo";
        data["b9df161b-529f-422c-8a9f-f3a7a25e57df"] = "WorldEntities/Doodads/Precursor/Precursor_cube_prison_exterior";
        data["b9fe28b2-ed34-4615-b4db-29373a1af896"] =
            "WorldEntities/Slots/MushroomForest/MushroomForest_Creature_GiantTreeInteriorFloor";
        data["b9fe6fc1-8809-4152-9b3e-6b411388009e"] = "WorldEntities/Slots/GrassyPlateaus/GrassyPlateaus_Loot_ArchTop";
        data["b9ffd6a0-6cca-4daf-99c1-f68ac6200530"] =
            "WorldEntities/Doodads/Precursor/TempGun_Interiors/Gun_Elevator_Lights";
        data["ba02feb5-f693-46e7-b663-c37ab6f67c47"] = "WorldEntities/Slots/KooshZone/KooshZone_Loot_HugeKooshBase";
        data["ba18f2c6-82f2-46e2-8bac-3bca09973431"] = "WorldEntities/Lights/Mountains/Mountains_Precursor_Spotlight";
        data["ba258aad-07e9-4c9b-b517-2ce7400db7b2"] = "WorldEntities/Fragments/scannerroomfragment";
        data["ba3fb98d-e408-47eb-aa6c-12e14516446b"] = "WorldEntities/Tools/Exosuit";
        data["ba563b58-bd22-4a87-ae01-bc44d03f5d41"] = "WorldEntities/Environment/Wrecks/PDAs/Aurora_Lab_PDA1";
        data["ba851576-86df-48e5-a0be-5cd7ba6f4617"] = "WorldEntities/Food/CuredSpadefish";
        data["ba866b79-1db1-4689-a697-b7d2bc65959d"] = "WorldEntities/Seeds/PurpleVasePlantPiece";
        data["ba886cfa-fd6f-4971-a467-19d6decfe914"] =
            "WorldEntities/Doodads/Debris/Aurora/Decoration/Signs/Aurora_CrewArea_Captain_Sign";
        data["ba89d2e1-237d-4df4-82c1-ce976f4b2a82"] = "WorldEntities/Doodads/Precursor/Cable_01";
        data["ba8c957d-4a2c-4ed5-86fd-1734e2f0ddee"] =
            "WorldEntities/Slots/SafeShallows/SafeShallows_Loot_IslandSpecial";
        data["ba90d6e8-4a8a-4c66-8f1a-2b02f3fc3acd"] = "WorldEntities/Fragments/seamoth_fragment_01_aurora";
        data["baab31cb-8737-4ea2-887b-f0aee02ba6c9"] = "WorldEntities/Lights/SafeShallows/Point_Cave_Mushroom";
        data["babffa17-578a-4344-8587-a0dff2e7a0a2"] = "WorldEntities/Fragments/Old/baseupgradeconsolefragment_old";
        data["bac42c90-8995-439f-be2f-29a6d164c82a"] = "WorldEntities/Doodads/Coral_reef/coral_reef_grass_kelp_02";
        data["bb16d2bf-bc85-4bfa-a90e-ddc7343b0ac2"] =
            "WorldEntities/Environment/Aurora/Wreck_GrassyPlateaus_2_WeldablePanel2";
        data["bb1c097c-2c8b-4b94-92cf-d951621cf44b"] =
            "WorldEntities/Environment/Wrecks/Wrecks_Starship_doors_manual_open";
        data["bb24f122-6429-4d91-b1d9-e35177be72db"] =
            "WorldEntities/Doodads/Precursor/precursor_block_stripe_08_02_02";
        data["bb30e5fc-648c-42ce-8fa5-c80bc601ca8d"] = "WorldEntities/Doodads/Coral_reef/Coral_reef_shell_01";
        data["bb52dc1c-ddd6-49f5-a3a0-dd831f808ad9"] =
            "WorldEntities/Slots/GrassyPlateaus/GrassyPlateaus_Creature_UniqueCreatureCave";
        data["bb88483b-60ec-4f80-8235-2e6b1c7eaa3b"] = "WorldEntities/Slots/SparseReef/SparseReef_Loot_Wall";
        data["bb89fd5c-e05d-440f-834f-57e322f2755d"] = "WorldEntities/Lights/Grassyplateaus/Point_GPCave_Mushroom";
        data["bb9ff342-2a02-4338-a8a6-4ad918c4950a"] =
            "WorldEntities/Atmosphere/LostRiver/BonesField/LostRiver_BonesField_Corridor_Stream";
        data["bbabfbdf-15a6-42dc-8ed5-c85dd600f241"] =
            "WorldEntities/Environment/Precursor/LostRiverBase/Precursor_LostRiverBase_Lab_01_Decals";
        data["bbc4416a-f6bd-4df9-bea0-22daf52415f1"] = "WorldEntities/Slots/SparseReef/SparseReef_Creature_DeepWall";
        data["bbf20816-a7b1-467b-826a-94260b427ab6"] =
            "WorldEntities/Environment/Precursor/LavaCastleBase/Precursor_LavaCastleBase_Teleporter_ToGun";
        data["bbf7473c-1782-40c2-8e57-0c8a9ccc4d21"] = "WorldEntities/Atmosphere/MushroomForest/Normal";
        data["bc0be818-2723-4c1e-b79c-41ca65e3e41f"] =
            "WorldEntities/Slots/LostRiver/BonesField/BonesField_Creature_Skeleton_Open";
        data["bc0f2b09-1c5c-4573-bdcb-087883677a5f"] = "WorldEntities/Eggs/SandsharkEgg";
        data["bc1146d6-3fcb-40a9-b90a-797509a8d293"] = "WorldEntities/Doodads/Lava/lava_leak_01_06";
        data["bc4426e8-02c4-448c-8c73-c5c5c38c69d2"] =
            "WorldEntities/Slots/LostRiver/Junction/Junction_Creature_LostRiverBase_Interior";
        data["bc487201-94ac-4e8d-8d06-67b681979676"] = "WorldEntities/Seeds/PurpleBranchesSeed";
        data["bc62e06d-0ccc-47b4-90c5-62f6422d4af7"] = "WorldEntities/Environment/Wrecks/cyclopshullfragment5";
        data["bc70e8c8-f750-4c8e-81c1-4884fe1af34e"] = "WorldEntities/Natural/FirstAidKit";
        data["bc7d4038-d681-41dd-b7ae-e134048f421b"] = "WorldEntities/Environment/Wrecks/cyclopshullfragment7";
        data["bc9354f8-2377-411b-be1f-01ea1914ec49"] =
            "WorldEntities/Environment/Aurora/Consoles/Aurora_RingRoom_Console2";
        data["bc948a11-aa33-435c-b65e-dda6bd90cf84"] =
            "WorldEntities/Doodads/Coral_reef/Coral_reef_blue_barnacles_01_03";
        data["bca064c0-9402-4f00-8420-ed754c624a67"] = "WorldEntities/Environment/Wrecks/PDAs/EscapePod_13_PDA";
        data["bca7e12e-22da-4d06-b196-9ea60fd0eef7"] =
            "WorldEntities/Doodads/Coral_reef/Coral_reef_small_rocks_seaweed_01";
        data["bca9b19c-616d-4948-8742-9bb6f4296dc3"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/submarine_locker_04_open";
        data["bcb52360-f014-4ca1-9cf2-9e32504c645f"] = "WorldEntities/Natural/CopperWire";
        data["bcf7a1e4-9c8c-4cc8-9084-06e9ce291c5e"] =
            "WorldEntities/Slots/Ship/Loot_ShipInterior_PlatformRecessUnderwater";
        data["bd2f747b-029f-45ab-9410-95efa6bf09f0"] = "WorldEntities/Seeds/ShellGrassSeed";
        data["bd397c19-5590-44f9-ae32-edc862d5f356"] = "WorldEntities/Tools/LithiumIonBattery";
        data["bd3c0070-3af4-4e44-b50d-506c438829ec"] = "WorldEntities/Doodads/Fragments/Moon_Pool_fragment_06";
        data["bd4d4fa1-d10e-40e5-8ec6-67efd0ba03af"] = "WorldEntities/Doodads/Coral_reef/Coral_reef_jelly_plant_01_01";
        data["bd76139e-10e7-4995-be01-10824ab84a80"] = "WorldEntities/Natural/obsidian";
        data["bdb4e68a-40b2-46cf-86c0-f8a7d5430d8a"] = "WorldEntities/Doodads/Debris/Wrecks/Decoration/DecoFarmingTray";
        data["bdb63d26-5fa0-4352-9dae-7d479121b998"] = "WorldEntities/Atmosphere/KelpForest/Dense (Sphere)";
        data["bdbfdd89-ba81-4a10-b09a-9399c041acb3"] = "WorldEntities/Environment/Wrecks/PDAs/EscapePod_19_PDA_Keen1";
        data["bdc3e9e8-a01f-427f-832b-9e8520873567"] =
            "WorldEntities/Doodads/Debris/Aurora/Decoration/Signs/Aurora_JHallway_Lockers_Sign";
        data["bdc52b41-8b8c-47a8-ad91-24bba4f74a22"] = "WorldEntities/Environment/DataBoxes/SwimChargeFinsDataBox";
        data["bdc7dc99-041a-4141-a673-f0ee0396c87e"] = "WorldEntities/Doodads/Debris/Starship_exploded_debris_14";
        data["bdfe934f-e1cc-4c26-ac1c-6bd8a305bc1f"] =
            "WorldEntities/Atmosphere/LostRiver/TreeCove/LostRiver_TreeCove_WaterBorderFading";
        data["be027095-1d7a-43ba-ad09-6885db9628de"] = "WorldEntities/Atmosphere/Mountains/Mountains";
        data["be2baa90-52b3-46d6-992d-5a2614f36af5"] = "WorldEntities/Tools/FireExtinguisher";
        data["be3971ab-816b-45bc-ad35-f2e333995b45"] = "WorldEntities/Slots/GrandReef/GrandReef_Creature_TreaderPath";
        data["be55c068-4371-4c59-b3d7-c6baac7e1b45"] = "WorldEntities/Doodads/Lost_river/lost_river_skull_coral_03";
        data["be5c62a3-d1f6-414f-8a9f-26bf9d65dd96"] =
            "WorldEntities/Doodads/Coral_reef/Coral_reef_small_blue_fans_01_cluster_small";
        data["be6135c6-689d-4217-87f6-613d92a2b587"] =
            "WorldEntities/Slots/SafeShallows/SafeShallows_Creature_IslandSpecial";
        data["be6febd7-fbfe-417e-a1c5-365faa28e43c"] = "WorldEntities/Slots/KelpForest/KelpForest_Loot_Outcropping";
        data["be8b0e66-0cde-428b-be78-9d6bf06eaef4"] = "WorldEntities/Doodads/Coral_reef/coral_reef_small_deco_19";
        data["be9f8f41-303f-4237-9a85-d6f082b1ae91"] = "WorldEntities/Environment/Aurora/Consoles/GenericConsole2";
        data["beb02a51-139f-4cb1-b7fd-831f8d00e55e"] =
            "WorldEntities/Environment/Precursor/MountainsCache/Precursor_KooshZoneCache_Teleporter_ToPrison";
        data["bebcf785-3f84-4e52-8616-21eb89c6957f"] =
            "WorldEntities/Slots/GrassyPlateaus/GrassyPlateaus_Creature_CavePlants";
        data["bec6223a-4ecf-4ec9-bfe5-598c76361729"] = "WorldEntities/Atmosphere/KelpForest/Caves Entrance";
        data["bedc40fb-bd97-4b4d-a943-d39360c9c7bd"] = "Submarine/Build/LabTrashcan";
        data["bef7bc0b-149d-4342-bbb4-329047685578"] = "Submarine/Build/FragmentAnalyzer";
        data["bf0faaaa-0730-44df-86ff-8c29ef59ecf7"] = "WorldEntities/Slots/LostRiver/Canyon/Canyon_Creature_Lake";
        data["bf297f4d-1c1d-45e7-bf72-e4313c317618"] = "WorldEntities/Slots/Mountains/Mountains_Loot_IslandRock";
        data["bf315203-c105-44f9-9fa4-cea65dd823c6"] = "WorldEntities/Atmosphere/MushroomForest/CoralRootZone_Box";
        data["bf4c70db-8e11-49b3-8951-8b718e2835db"] = "WorldEntities/Doodads/Coral_reef/coral_reef_Stalactite_01_01";
        data["bf59ddea-ccdd-409b-9339-0c2084cc04c8"] =
            "WorldEntities/Slots/SafeShallows/SafeShallows_Creature_SandFlat";
        data["bf604360-6f25-4bf6-8233-44989fef63ec"] =
            "WorldEntities/Doodads/Coral_reef/coral_reef_Stalactites_cluster_02_04";
        data["bf7916d1-c4e6-4e95-b0df-62bb7072cf5a"] = "WorldEntities/Tools/Constructor_damaged_03";
        data["bf7cf349-fcfe-4a6d-9445-4a69f7578aa3"] = "WorldEntities/Doodads/Debris/Starship_exploded_debris_09";
        data["bf9ccd04-60af-4144-aaa1-4ac184c686c2"] = "WorldEntities/Creatures/BladderFish";
        data["bf9d5b7e-510e-4fbd-ae84-aabee61f7a58"] =
            "WorldEntities/Slots/GrassyPlateaus/GrassyPlateaus_Loot_TowerBigTop";
        data["bfc0ea36-4f66-49cf-bb8d-9ccec3235041"] =
            "WorldEntities/Atmosphere/TreaderPath/Treader_Path_Cave_Dark_Sph";
        data["bfd34e0f-74d5-4006-b382-0c56031700e8"] = "WorldEntities/Fragments/BaseRoom_Fragment";
        data["bfd64386-670a-44d6-9218-3835afec1042"] = "WorldEntities/Doodads/Land/land_plant_small_03_06_vertical";
        data["bfdc3e94-ae37-4737-af64-b07f7f8ba63d"] = "WorldEntities/Slots/BloodKelp_Trench/BloodKelp_Loot_Roots";
        data["bfe8345c-fe3c-4c2b-9a03-51bcc5a2a782"] = "WorldEntities/Creatures/GasPod";
        data["bfe993b9-8d6d-441c-922e-7dc074d81d3f"] = "WorldEntities/Doodads/Lost_river/ReaperSkeleton_LostRiver";
        data["bff31cee-146a-4f79-b965-b81d6f897baa"] =
            "WorldEntities/Atmosphere/GrandReef/GrandReef_WreckInterior_Atmosphere";
        data["c006a7e6-22cd-4bae-b939-a4486849adf2"] = "WorldEntities/VFX/xSteamLeakRandom_medium";
        data["c01003c7-38d7-4c1c-9677-58921712e514"] = "WorldEntities/Atmosphere/KooshZone/KooshCaveTeleporter";
        data["c0175cf7-0b6a-4a1d-938f-dad0dbb6fa06"] = "Submarine/Build/MedicalCabinet";
        data["c0207263-51eb-44c6-ae88-b24f41e4f19e"] = "WorldEntities/Slots/ILZCastle/ILZCastle_Loot_TunnelFloor";
        data["c0341768-38a7-4eba-8955-9d8b69cb95ff"] =
            "WorldEntities/Slots/LostRiver/Corridor/Corridor_Creature_Water_Wall";
        data["c060e7fd-f4d2-4bef-8862-f31420d60ba0"] =
            "WorldEntities/Environment/AbandonedBases/AbandonedBase PDA/JellyPDARoom1Locker";
        data["c0684ae2-d4fa-4161-bad9-c7b52ddee33c"] = "WorldEntities/Environment/Wrecks/ExplorableWreck_Grassy_2";
        data["c081e286-bb51-4cc6-b48c-ea03d817ccf9"] =
            "WorldEntities/Doodads/Coral_reef/coral_reef_Stalactites_cluster_03_01";
        data["c085fac9-4916-41e8-bb4c-334f0e62ad44"] =
            "WorldEntities/Slots/UnderwaterIslands/UnderwaterIslands_Loot_Techsite_Scatter_Medium";
        data["c08f45f2-7a67-4579-9ee9-9f7612104cc3"] = "WorldEntities/Tools/DiveReel_damaged";
        data["c0a5e85b-23cb-4e2a-b90e-85df780717cc"] = "WorldEntities/Slots/KelpForest/KelpForest_Creature_Outcropping";
        data["c0d320d2-537e-4128-90ec-ab1466cfbbc3"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/starship_souvenir";
        data["c0e771ef-15f8-435f-8dd6-aab35a03478c"] = "WorldEntities/Slots/KelpForest/KelpForest_Loot_VineBase";
        data["c101cc31-1b2b-465b-aaf8-e907b8f36e2d"] = "WorldEntities/Lights/LostRiver/Point_Lostriver_blueplants_lrg";
        data["c110030e-21fe-41bd-9527-9dcedcba50d8"] = "WorldEntities/Slots/Mountains/Mountains_Loot_Techsite_Medium";
        data["c1139534-b3b9-4750-b60b-a77ca054b3dd"] =
            "WorldEntities/Environment/AbandonedBases/AbandonedBaseJellyShroom6";
        data["c11ecde6-f950-4527-918e-91a182967abc"] = "WorldEntities/Slots/KelpForest/KelpForest_Loot_TechSite_Small";
        data["c129d979-4f68-41d8-b9bc-557676d18a5a"] = "WorldEntities/Tools/TimeCapsule";
        data["c15ba497-90a0-41df-ba4b-a34a2dfbd6aa"] =
            "WorldEntities/Doodads/Coral_reef/Crab_snake_mushrooms_entrance_04";
        data["c1629d8b-a947-4fe6-8886-9d13ec9249e7"] =
            "WorldEntities/Doodads/Precursor/LavaBase/Lights/Precursor_LavaCastleBase_StairWell_Upper_Lights";
        data["c175fe94-2b69-44ce-a57b-33dc73cf2b23"] = "WorldEntities/Slots/Mountains/Mountains_Creature_IslandGrass";
        data["c197a6ca-f910-43db-92ab-2e35e423a6f1"] =
            "WorldEntities/Doodads/Coral_reef/Coral_reef_jeweled_disk_purple_01_04";
        data["c1980091-9d11-445b-88f9-11dc3d24393a"] = "WorldEntities/Slots/ILZCastle/ILZCastle_Loot_ChamberCeiling";
        data["c19bac5e-43f2-4699-8f35-26fd3d549cf5"] = "Base/Ghosts/BaseMoonpool";
        data["c1c83fe3-e4d6-49ab-af76-c67bd2aaed05"] =
            "WorldEntities/Atmosphere/Ship/CrashedShip_Interior_Entrance_01_02";
        data["c1e13315-2c9e-41be-bac9-096d358a7a77"] = "WorldEntities/Slots/KooshZone/KooshZone_Loot_Techsite_Small";
        data["c1f186f9-41e7-400d-9f8f-c786ae1d00a8"] = "WorldEntities/Slots/CragField/Cragfield_Loot_Rock";
        data["c1f8aa68-0ac0-419e-81ec-b7a388027c24"] = "WorldEntities/Fragments/ledlightfragment";
        data["c2178b71-5e47-42f6-9ed4-57d92b53a470"] =
            "WorldEntities/Slots/LostRiver/SkeletonCave/SkeletonCave_Creature_Ceiling";
        data["c228ebf0-5675-4eaa-ac42-4d9a997c9e80"] =
            "WorldEntities/Slots/MushroomForest/MushroomForest_Creature_CoralRoot";
        data["c23aee59-f0d5-4e5d-a671-f1819ccd6680"] =
            "WorldEntities/Slots/SafeShallows/SafeShallows_Creature_OpenDeep";
        data["c2643db0-26e7-4250-9203-e4a7bbd0b1ec"] = "WorldEntities/Atmosphere/KooshZone/KooshZone_Geyser";
        data["c2660405-c4cb-483d-90ea-12ffdbadc15d"] =
            "WorldEntities/Doodads/Debris/Aurora/Decoration/Signs/Aurora_ExoRoom_Lockers_Sign";
        data["c27611ce-de24-46fb-9d4b-9cb16b7c94a0"] =
            "WorldEntities/Environment/Precursor/Prison/Moonpool/Precursor_Prison_MoonPoolSurface";
        data["c2a2a19c-f2dc-4546-aa9e-d12740fa9b67"] = "WorldEntities/Slots/KelpForest/KelpForest_Loot_ShellTunnel";
        data["c2b5b625-bd5b-4390-be53-2d9f3ef58f36"] = "WorldEntities/Environment/Wrecks/PDAs/IslandsPDARendezvous";
        data["c2badd19-23be-4431-8b7e-1b87e320f651"] = "WorldEntities/Slots/MushroomForest/MushroomForest_Loot_Sand";
        data["c2c34745-e8bb-4ede-b7c0-f0773773c23d"] =
            "WorldEntities/Atmosphere/LostRiver/Junction/LostRiver_Junction_Water_Nosurface";
        data["c2cb0381-964e-4ed0-b434-133e5b00d8d1"] =
            "WorldEntities/Environment/Wrecks/PDAs/Wreck9_MushroomForest_PDA2";
        data["c32f78e4-67f4-4a8f-a3f7-42ec1488ed30"] = "WorldEntities/Lights/LostRiver/Point_LR_Canyon_Water_green_lrg";
        data["c3316113-2d89-45d4-81d7-7dd7c254fa6d"] =
            "WorldEntities/Doodads/Coral_reef/Coral_reef_small_rocks_seaweed_07";
        data["c33b3e33-0ddd-4a33-a24a-c412288a96e2"] =
            "WorldEntities/Doodads/Precursor/TempGun_Interiors/Gun_ExtraBlock_01";
        data["c33f7dc7-0e72-4130-a5fc-2e2bb07a5a3e"] = "WorldEntities/Slots/SafeShallows/SafeShallows_Creature_Plants";
        data["c3749c3b-34ca-4371-a173-0e68fbc27d3b"] =
            "WorldEntities/Slots/SafeShallows/SafeShallows_Loot_TechSite_EscapePod_Medium";
        data["c390fcfc-3bf4-470a-93bf-39dafb8b2267"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/Starship_cargo_opened";
        data["c395b5a9-9e44-4c2b-b030-1e987009f5b7"] = "WorldEntities/Environment/Wrecks/Bio_reactor_damaged_01";
        data["c3994649-d0da-4f8c-bb77-1590f50838b9"] = "Submarine/Build/NarrowBed";
        data["c3c0f357-f544-4df4-978d-614a03d3bd3b"] =
            "WorldEntities/Doodads/Lost_river/Lost_river_hanging_plant_03_01";
        data["c3d6cad0-1981-4dfd-9a11-62eb0490b130"] = "WorldEntities/Fragments/exosuit_damaged_03";
        data["c3d844cf-19cc-4430-949d-32d6416f59e3"] = "WorldEntities/Fragments/BaseUpgradeConsole_Fragment";
        data["c3f2225b-718c-4868-bae3-39ce3914e992"] =
            "WorldEntities/Doodads/Precursor/LavaBase/Lights/Precursor_LavaCastleBase_Entry01";
        data["c3f41541-8baa-4845-aa58-c0a9e49afcc9"] =
            "WorldEntities/Slots/SafeShallows/SafeShallows_Creature_CaveSpecial";
        data["c3f62b41-4e65-4953-9e11-edb34b0f151c"] =
            "WorldEntities/Environment/Precursor/LostRiverBase/Precursor_LostRiverBase";
        data["c3f76e10-b1fb-495b-bf90-d2ffdb8ff131"] = "WorldEntities/Slots/ILZChamber/ILZChamber_Loot_CorridorFloor";
        data["c40b819e-3a2f-4fa3-a0c5-47f2191f5652"] =
            "WorldEntities/Doodads/Precursor/Precursor_prison_exterior_box_01_animated";
        data["c40f058c-e73b-4cf5-a4e5-6ce78a73899a"] =
            "WorldEntities/Doodads/Lost_river/Lost_river_hanging_plant_04_03";
        data["c4433458-3683-4b27-8ccf-71a852d2b5ef"] =
            "WorldEntities/Slots/seaTreaderPath/SeaTreaderPath_Loot_Techsite_Barrier_Medium";
        data["c4547062-77b7-4449-a58a-68569f6ce1ff"] = "WorldEntities/Tools/CyclopsShieldModule";
        data["c483f597-c78a-42e9-bad5-3be9ef47aa81"] = "WorldEntities/Natural/Magnesium";
        data["c484f23a-b98c-422d-b83b-ba75d4bade7b"] =
            "WorldEntities/Slots/UnderwaterIslands/UnderwaterIslands_Creature_IslandTop";
        data["c4a28538-e57a-4231-b0c4-b156aad16603"] =
            "WorldEntities/Slots/LostRiver/SkeletonCave/SkeletonCave_Loot_Algae";
        data["c4b1ae57-3726-4521-9f72-85a174396412"] =
            "WorldEntities/Doodads/Lost_river/LostRiverBase/Lost_river_hanging_plant_01_03";
        data["c4b6d3ba-e300-4184-85ac-148a5192d97d"] = "WorldEntities/Environment/Wrecks/tech_light_deco_Far";
        data["c4e9a2e7-f54b-48f2-ac3b-41b2a1ec3661"] = "WorldEntities/VFX/x_LavaFall";
        data["c4ee5a9c-8d3d-46b9-b422-ac8e85e99519"] =
            "WorldEntities/Slots/UnderwaterIslands/UnderwaterIslands_Creature_Geyser";
        data["c5079dd6-89b2-46e3-8599-6e6de05b0010"] =
            "WorldEntities/Slots/LostRiver/Junction/Junction_Creature_ThermalVent";
        data["c50db8c0-98de-4f30-9a66-a7fb9f59bc03"] =
            "WorldEntities/Slots/Ship/Loot_ShipInterior_AuxPowerRoom2_Barrier";
        data["c542bf58-6948-44cb-911e-07e58ea263ee"] = "WorldEntities/Jonas/DummyCreature";
        data["c550e910-58f1-42a7-8fd3-32941df5ce69"] = "WorldEntities/Slots/LostRiver/Canyon/Canyon_Creature_Open";
        data["c5512e00-9959-4f57-98ae-9a9962976eaa"] =
            "WorldEntities/Environment/Precursor/Prison/Precursor_Prison_Outpost1";
        data["c5664c82-d9f4-445e-86b1-b943e97e3913"] =
            "WorldEntities/Doodads/Lost_river/Lost_river_hanging_plant_04_02";
        data["c592f5bc-723a-43ba-8259-0d7e270bfa3b"] = "WorldEntities/Natural/Stone2";
        data["c59c1abc-4e00-4480-8d8d-f337a81ba2d6"] = "Submarine/Build/PlanterPot";
        data["c59e836b-4bb6-4ff5-86ec-523a8182e194"] =
            "WorldEntities/Slots/GrassyPlateaus/GrassyPlateaus_Creature_Tower";
        data["c5ae1472-0bdc-4203-8418-fb1f74c8edf5"] = "Submarine/Build/WallShelves";
        data["c5b40b4f-133d-4303-a457-66aa7f9d5345"] =
            "WorldEntities/Doodads/Precursor/Precursor_Interior_Damage_Props_02";
        data["c5d27b10-b02e-4063-9819-584dbfb721fa"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/Starship_tech_box_01_03";
        data["c608c7b9-3ecc-4b71-a126-f90e721b83c7"] =
            "WorldEntities/Slots/GrassyPlateaus/GrassyPlateaus_Creature_Arch";
        data["c60fc3f8-501f-4127-8514-46f41e4cf666"] = "WorldEntities/Slots/FloatingIsland/FloatingIsland_Loot_beach";
        data["c615975b-58da-45d2-ac2e-16458a778c31"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/vent_constructor_junction_vertical_01";
        data["c625cfb7-c739-424a-9af0-b1f8c71e41eb"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/Starship_cargo_damaged_01_Far";
        data["c64c92d7-851c-4d86-8075-fb826c5f2a98"] =
            "WorldEntities/Atmosphere/Precursor/LostRiverBase/Precursor_LostRiverBase_Atmosphere";
        data["c66b5dfa-7fe9-4688-b165-d2e2f4caa8d9"] = "WorldEntities/Natural/Titanium";
        data["c6891afe-3aff-4510-9912-844a7dd174d7"] = "WorldEntities/Slots/BloodKelp/BloodKelp_Creature_Floor";
        data["c68a7060-a70d-4a17-8a09-96a7704835c6"] = "Base/Ghosts/BaseBulkhead";
        data["c6a57a6d-de07-47e8-8ee2-7fb6e7dd3686"] = "WorldEntities/Slots/KelpForest/KelpForest_Loot_GrassDense";
        data["c6c5c63d-2380-4a26-ac54-679acc339cb5"] = "WorldEntities/Atmosphere/Inactive Lavazone/ILZLava_Sphere";
        data["c6cc580a-355f-4a0d-b7d7-63977bfe695d"] =
            "WorldEntities/Environment/Wrecks/Obsolete/ExplorableWreck_SafeShallows_25_old";
        data["c6f3c2fd-5b80-4aaf-81c3-f056651b868c"] = "WorldEntities/Tools/Builder";
        data["c6f6fe72-e16e-4b00-8df2-6b4e1a3533f4"] =
            "WorldEntities/Environment/Wrecks/PDAs/EscapePod_3_PDA_SeaglideCompass";
        data["c702396e-259c-44c9-ad95-4ac64553284b"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/explorable_wreckage_modular_room_details_23";
        data["c7103527-f6fa-4d1e-a75d-146433851557"] = "WorldEntities/Creatures/Warper";
        data["c718547d-fe06-4247-86d0-efd1e3747af0"] =
            "WorldEntities/Environment/Precursor/Precursor_PurpleKeyTerminal";
        data["c71f41ce-b586-4e85-896e-d25e8b5b9de0"] =
            "WorldEntities/Doodads/Coral_reef/coral_reef_small_deco_17_purple";
        data["c72724f3-125d-4e87-b82f-a91b5892c936"] = "WorldEntities/Environment/Coral_reef_floating_stones_big_02";
        data["c7547370-f748-4c85-b49c-0c28be473f63"] = "WorldEntities/Environment/Wrecks/ExplorableWreck2_Base_0";
        data["c7555217-7406-4dab-b64b-d909d37ba096"] = "WorldEntities/Slots/Mountains/Mountains_Loot_Grass";
        data["c767e46f-63ce-4158-a1b7-3c8e6ab23626"] = "WorldEntities/Lights/Mountains/Mountain_cave_base_sun";
        data["c7925c40-59a0-4bb3-a55a-48119424357a"] =
            "WorldEntities/Slots/LostRiver/BonesField/BonesField_Creature_Ledge";
        data["c794ac3f-d506-4338-9a8d-4b418a2e6741"] = "WorldEntities/Doodads/Debris/Wrecks/ExplorableWreckRoom04";
        data["c7a23cb1-ddde-4fa8-9f5f-f8b408db3062"] = "WorldEntities/Natural/Stone4";
        data["c7cba186-68f1-4b8d-a3dc-6d6c06cd6ec3"] =
            "WorldEntities/Atmosphere/Precursor/EmperorFacility/Precursor_Prison_Aquarium_Mid_Atmosphere";
        data["c7faff7e-d9ff-41b4-9782-98d2e09d29c1"] = "WorldEntities/Doodads/Land/land_plant_small_03_04";
        data["c80288ce-9522-45f5-b3c2-01fe459ae5fe"] =
            "WorldEntities/Doodads/Debris/Aurora/Rooms/CrashedShip_cargo_room";
        data["c804e142-c02d-485b-a533-50b59207fdc4"] = "WorldEntities/Tools/SeamothHullModule2";
        data["c81e0f5b-537b-4f59-8599-34cca92171d8"] = "WorldEntities/Doodads/RandomLargeBoulder";
        data["c83fc84e-7a55-42b7-97d9-8100ebe6d47d"] = "WorldEntities/Unused/PipeOld";
        data["c841bc9d-2744-461f-9334-f513ba7c13ef"] = "WorldEntities/Slots/Ship/Loot_ShipInterior_Locker";
        data["c853e507-6ad9-4ff2-95c1-6044f024a19e"] = "WorldEntities/Doodads/Coral_reef/coral_reef_Stalactite_02_01";
        data["c85420bd-dda8-45ae-a3e6-bd48e94e4522"] = "WorldEntities/Doodads/Lost_river/lost_river_skull_coral_02";
        data["c867df3a-344e-4ee6-91b0-4e66984338b3"] =
            "WorldEntities/Slots/SafeShallows/SafeShallows_Creature_CaveEntrance";
        data["c87c75bd-0342-4ece-8f9b-a1a22c205456"] =
            "WorldEntities/Environment/Precursor/MushroomForestCache/Precursor_MushroomForestCache_ForceField";
        data["c87e584c-7e38-4589-b408-8eca51f474c1"] = "WorldEntities/Doodads/Coral_reef/coral_reef_small_deco_14";
        data["c89a7a04-ea4a-438b-8e11-574e90952289"] = "WorldEntities/Environment/ThermalVent_Bright_Small";
        data["c8a73c88-e538-4d68-b9e7-9bff7c3482ae"] = "WorldEntities/VFX/xSandFall_Small";
        data["c8d35567-7c89-4ba0-aa6a-9a87bf7a7b60"] = "WorldEntities/Doodads/Debris/Wrecks/Decoration/bed_03";
        data["c8d54741-358a-4af7-81a6-286826111399"] =
            "WorldEntities/Slots/Ship/Creature_ShipInterior_PlatformUnderwater";
        data["c8e53aa9-f599-4194-b2b1-c1645d001a82"] = "WorldEntities/Environment/Aurora/Aurora_LivingArea_Keypad";
        data["c8ef64c4-0b10-4556-b597-cd789b21fbe8"] = "WorldEntities/Doodads/Precursor/Precursor_cube_03_damaged";
        data["c8f95cf0-5980-4b06-a4d6-b66b3949e6b8"] = "WorldEntities/Lights/LostRiver/Point_Junction_Water_Green";
        data["c943f248-a643-4cc0-afa9-1496e6965386"] =
            "WorldEntities/Environment/Aurora/Aurora_DisableGlobalWaterVolume_MainEntry";
        data["c94aeded-98a9-4f33-8186-a0928ae286e9"] =
            "WorldEntities/Environment/AbandonedBases/AbandonedBase PDA/DeepPDA3";
        data["c96baff4-0993-4893-8345-adb8709901a7"] = "Submarine/Build/Eatmydiction";
        data["c97386a9-c911-4734-8997-d63ee96f42ef"] = "WorldEntities/Slots/DeepGrandReef/DeepGrandReef_Loot_Ceiling";
        data["c97561bc-94a6-440d-a57d-3f418afdb637"] =
            "WorldEntities/Environment/Aurora/Consoles/Aurora_RingRoom_Console3";
        data["c98447bc-4d51-49e8-b656-b2056e9304b8"] =
            "WorldEntities/Doodads/Debris/Aurora/Decoration/Signs/Aurora_ExoRoom_LivingArea_Sign";
        data["c991ad57-4e6a-4009-9db0-d53a704df8e4"] = "WorldEntities/Doodads/Coral_reef/Coral_reef_small_deco_07";
        data["c9a28181-a0eb-4ae5-9fb8-ce57772980f1"] = "WorldEntities/Creatures/SeaEmperorJuvenile";
        data["c9b2e90e-7ba6-4fe2-813e-6f91a0ff2509"] = "WorldEntities/Atmosphere/Dunes/DunesCaveDark20_Sph";
        data["c9b3e76c-c341-4f86-a34c-a9ea5db509d9"] = "WorldEntities/Doodads/Geometry/SafeShallows/Rock_pillar01";
        data["c9bb076a-eaa1-46f6-bcc5-17d5f83e4ff5"] =
            "WorldEntities/Slots/LostRiver/SkeletonCave/SkeletonCave_Loot_Ground";
        data["c9bdcc4d-a8c6-43c0-8f7a-f86841cd4493"] = "Submarine/Build/SpecimenAnalyzer";
        data["c9d398ff-4ea0-426d-ab1a-e36d2b96af89"] = "WorldEntities/Lights/SparseReef/SparseReef_Cave_Point";
        data["c9d84dfd-6802-41bd-a7b1-34d9b3a31531"] =
            "WorldEntities/Environment/AbandonedBases/Base_exterior_Planter_Tray_01_abandoned";
        data["ca114689-ee6d-4a9f-9757-e5d6f9aec0f3"] = "Submarine/Build/DoorKeypadConsole_UnlockDoor";
        data["ca1fcbd0-81c0-457e-902a-8a62f31be7ca"] =
            "WorldEntities/Environment/Precursor/Cache/Precursor_SparseReefCache_DoorTerminalsRoot1";
        data["ca3f21b3-b5bc-4e07-836e-d948f205fb8f"] =
            "WorldEntities/Slots/Prison/Aquarium/PrisonAquarium_Creature_Coral";
        data["ca50a260-9245-4c6d-bd70-7747651c1c1f"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/explorable_wreckage_modular_room_details_25";
        data["ca55a4d0-0873-47fe-8a7b-d1985ea9f889"] =
            "WorldEntities/Environment/Aurora/Consoles/Wreck_Grassy_2_Console";
        data["ca5e7149-4c00-4839-8707-254e62e75473"] = "WorldEntities/Environment/DataBoxes/StillSuitDataBoxSpawner";
        data["ca66207a-ab0c-4974-80f2-abde941a2daa"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/explorable_wreckage_modular_room_details_07";
        data["ca967b5e-7755-44c3-8ee3-ab5f1ac8f390"] = "WorldEntities/Slots/GrandReef/GrandReef_Creature_WhiteCoral";
        data["caaad5e8-4923-4f66-8437-f49914bc5347"] =
            "WorldEntities/Environment/Precursor/Prison/Antechamber/Precursor_Prison_MainDoor_DoorTerminalsRoot";
        data["cab7f49c-1079-4d78-9d31-838e7525e926"] = "WorldEntities/Environment/Precursor/Precursor_BlueKeyTerminal";
        data["cac6d4fe-03c1-418e-b43e-131577b40d7d"] = "WorldEntities/Environment/Aurora/PDAs/Aurora_Office_PDA1";
        data["cadd50ff-2e1b-49f0-a9aa-72db32b9c1da"] = "WorldEntities/Tools/Transfuser";
        data["cae36d50-5b33-487e-b288-efa9e6211a46"] = "WorldEntities/Slots/LostRiver/TreeCove/TreeCove_Creature_Open";
        data["cae666cd-1cde-4b68-ac39-0a9e5068277d"] = "Submarine/Build/Starship_big_gate_doors_01";
        data["cb05f6ff-d7d6-4e8a-83ab-a1a37346c622"] = "WorldEntities/VFX/xSparksElec_3s_Small";
        data["cb09c3da-90a7-4bd5-8d16-7bc943f7c9bf"] = "WorldEntities/Fragments/Old/KelpFragment";
        data["cb1cbd95-6aee-4c0f-8e85-a5b12943fddb"] = "WorldEntities/Natural/MapRoomHudChip";
        data["cb1e6548-aa05-4f4a-8a44-399d8b221aad"] =
            "WorldEntities/Slots/MushroomForest/MushroomForest_Loot_EscapePod_Small";
        data["cb2e9dc9-cfdc-48e1-ac8e-997d354d759b"] = "WorldEntities/Natural/SupplyCrate_Ration";
        data["cb30612a-7c38-49a1-b5c1-3156019fd44f"] = "WorldEntities/VFX/xGeyserShort_Eruption";
        data["cb586c38-be51-42d4-9367-d744e01138c7"] =
            "WorldEntities/Doodads/Coral_reef/coral_reef_Stalactites_cluster_04_03";
        data["cb612e1b-d57a-44f5-a043-a886eb17e5a6"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/wall_monitor_01_03";
        data["cb66f446-be3e-42ca-88ee-380c1823a92f"] =
            "WorldEntities/Doodads/Coral_reef/Coral_reef_small_blue_fans_small_01_03";
        data["cb89366d-eac0-4011-8665-fafde75b215c"] = "Submarine/Build/Marki_01";
        data["cbeca4bd-cba4-4905-89fd-2470aaa204b1"] = "Submarine/Build/StarshipChair2";
        data["cbf21035-a26b-45bc-bab2-93f084e59922"] = "WorldEntities/Doodads/Precursor/PrecursorKeyTerminal";
        data["cc0745e7-03b9-4d3f-8829-6d00c5a3ed82"] =
            "WorldEntities/Slots/Generic/Creature_Precursor_SurfaceVent_Generic";
        data["cc09cb7f-4450-4e69-b631-36e55d50f0ee"] = "WorldEntities/Slots/LostRiver/Corridor/Corridor_Creature_Wall";
        data["cc0bc831-9cc1-4dac-8285-e0dc8ebb2dd9"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/Starship_work_chair_02";
        data["cc0bf0e2-6d9e-45db-bf10-1d00dd91baf0"] =
            "WorldEntities/Slots/SafeShallows/SafeShallows_Loot_CaveEntrance";
        data["cc144c37-d709-45d3-a6ee-ce99b7dc99bc"] = "Submarine/Build/IGPHullPlate";
        data["cc14ee20-80c5-4573-ae1b-68bebc0feadf"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/Starship_cargo_large_02";
        data["cc4d3799-23d1-4cdd-8214-cbb9ad460981"] =
            "WorldEntities/Environment/Precursor/Prison/Antechamber/Precursor_Prison_Antechamber_MoonPoolDoor_Forcefield";
        data["cc647576-ba92-4ec8-99eb-9be676369838"] = "WorldEntities/Lights/Aurora/Aurora_SeamothRoom_ModuleLight";
        data["cc7e410b-6878-424b-9986-5cefb69ffebd"] = "WorldEntities/Tools/SeamothReinforcementModule";
        data["ccda323d-2b8c-4bd2-b55e-b2def79a0283"] = "WorldEntities/VFX/xSparksBlue_1s_Small";
        data["cd004d89-f798-40d0-bf65-ee4c1c48700c"] =
            "WorldEntities/Doodads/Coral_reef/Coral_reef_cave_root_small_05_blood";
        data["cd0b5fee-7c54-4050-9c83-ad409036a288"] = "WorldEntities/Slots/ILZCastle/ILZCastle_Loot_ChamberFloor";
        data["cd180ada-400b-4668-a324-dcbdec2d9b1d"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/descent_bar_seat_side_curved_01";
        data["cd34fecd-794c-4a0c-8012-dd81b77f2840"] = "Submarine/Build/submarine_locker_04";
        data["cd4221c5-a30a-4aef-851e-1513734af473"] = "WorldEntities/VFX/xBubbleColumn_tiny";
        data["cd60a5f9-b1b7-4386-9325-e72254ef05f0"] = "WorldEntities/Lights/Kelpforest/Bounce_Dense";
        data["cdade216-3d4d-4adf-901c-3a91fb3b88c4"] = "Submarine/Build/Centrifuge";
        data["cdb0acfa-3341-43cc-9882-a04b801a678b"] = "WorldEntities/Doodads/Coral_reef/Coral_reef_shell_02_10";
        data["cdb374fd-4f38-4bef-86a3-100cc87155b6"] = "Submarine/Build/Bed2";
        data["cde26b26-6e28-4cd9-9848-aaeee232d67a"] = "WorldEntities/Food/CookedReginald";
        data["cdf798b7-4523-43fe-8745-40ac72a75b03"] = "WorldEntities/Doodads/Coral_reef/Coral_reef_shell_02_05";
        data["ce0b2844-39b2-4591-9c0f-472a803f14c0"] = "WorldEntities/Jonas/DummyObject";
        data["ce0b4131-86e2-444b-a507-45f7b824a286"] = "WorldEntities/Environment/Geyser";
        data["ce20c267-b52b-4866-8134-f3f78072af3e"] = "WorldEntities/Seeds/RedBasketPlantSeed";
        data["ce23b9ee-fd98-4677-9919-20248356f7cf"] = "WorldEntities/Creatures/BladderFishSchool";
        data["ce3c3053-5022-404e-a165-e31abe495f1b"] =
            "WorldEntities/Environment/Precursor/LavaCastleBase/Precursor_LavaCastleBase_ThermalRoom_AnimatedPillar";
        data["ce650c66-355c-4b77-ad4e-a2bea7e36c95"] = "WorldEntities/Doodads/Land/land_plant_middle_04_02";
        data["ce92c31d-1133-4892-aab5-38997639e0e1"] = "WorldEntities/Food/CookedHoopfish";
        data["ce9e25f2-b062-4c3d-bf10-abc1f08ad2f7"] = "WorldEntities/Tools/ExosuitGrapplingArmModule";
        data["ceaa255c-e1e7-4cbc-938f-fcf735bca757"] = "WorldEntities/Environment/Wrecks/cyclopsenginefragment2";
        data["cebc306a-862b-4b09-bd49-9c9fd7bbe8f2"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/descent_bar_seat_side_04";
        data["cecac0d7-0bf5-4bcc-a512-c58dde88925f"] =
            "WorldEntities/Doodads/Precursor/TempGun_Interiors/Precursor_Gun_TerminalHallway_02_Lights";
        data["cef4460f-31ca-4b7e-beb5-907fe8131c97"] =
            "WorldEntities/Atmosphere/LostRiver/GhostTree/LostRiver_GhostTree_LakeBorderFading";
        data["cf03187a-e77a-4f2c-9755-6f3921ec6476"] = "WorldEntities/Atmosphere/GrassyPlateaus/Normal";
        data["cf066ca3-1043-4b4f-b7db-34250f4fe48a"] =
            "WorldEntities/Lights/Precursor/Aquarium/Aquarium_Platform_Uplight";
        data["cf171ce2-e3d2-4cec-9757-60dbd480e486"] = "WorldEntities/Creatures/Reginald";
        data["cf1df719-905c-4385-98da-b638fdfd53f7"] = "Submarine/Build/SingleWallShelf";
        data["cf461de6-a4e8-4679-ba8a-5774d8d59b06"] =
            "WorldEntities/Slots/LostRiver/GhostTree/GhostTree_Loot_Lake_Floor";
        data["cf4ca320-bb13-45b6-b4c9-2a079023e787"] = "WorldEntities/Doodads/Fragments/Map_Room_fragment_04";
        data["cf522a95-3038-4759-a53c-8dad1242c8ed"] = "Submarine/Build/StarshipDesk";
        data["cf53eeb6-039e-4842-bfbe-2db65389ad07"] = "WorldEntities/Environment/DataBoxes/CyclopsHullModuleDataBox";
        data["cf6856c8-e2e9-4f87-a7bf-2b32dda0f7d5"] =
            "WorldEntities/Slots/SafeShallows/SafeShallows_Creature_UniqueCreature";
        data["cf7482f5-794f-429c-ba29-c6e0e59da804"] =
            "WorldEntities/Environment/Precursor/KooshZoneCache/Precursor_KooshZoneTeleporter_AnimatedLight";
        data["cf8794a1-5cd6-492e-8acf-7da7c940ef70"] = "WorldEntities/Creatures/Stalker";
        data["cfa378e9-5cf5-428e-9efb-42db092fe06d"] =
            "WorldEntities/Slots/LostRiver/Corridor/Corridor_Loot_Water_Wall";
        data["cfbd0028-2e55-48c1-a8e5-8913133c7db7"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/descent_bar_seat_side_04b";
        data["cfd8b9da-36e2-4b61-bc79-cb6ec10b8816"] = "WorldEntities/Environment/Boulder";
        data["cfdd714a-55fb-40df-86e5-6acf0d013b34"] = "WorldEntities/Natural/reactorrod";
        data["cfea2a50-6fc1-41f7-b496-a36a31b0639f"] = "WorldEntities/Tools/ExosuitDrillArmModule";
        data["cfea2d7e-ba41-471a-935c-6be6140579e9"] =
            "WorldEntities/Environment/Precursor/LostRiverBase/Precursor_LostRiverBase_LockedDoor";
        data["d00ad450-2d35-4028-bcaa-b77db755a1b8"] = "WorldEntities/Slots/BloodKelp/BloodKelp_Creature_Roots";
        data["d00efe9c-3412-4592-9c85-866be52d34cf"] = "WorldEntities/Doodads/Coral_reef/Crab_snake_mushrooms_06_04";
        data["d0115374-d251-4e52-8404-af15cc6244c3"] = "WorldEntities/Environment/Wrecks/cyclopsbridgefragment1";
        data["d018058b-79c2-41bd-803a-de796092d337"] =
            "WorldEntities/Slots/JellyshroomCaves/Jellyshroom_Loot_AbandonedBase_Inside_Small";
        data["d040bec1-0368-4f7c-aed6-93b5e1852d45"] = "WorldEntities/Creatures/SpadeFish";
        data["d0621389-84b8-446f-8b22-17048c6af1a4"] = "WorldEntities/Doodads/Coral_reef/coral_reef_kelp_seed";
        data["d0695c27-e983-416f-b837-20c586e88813"] = "WorldEntities/Fragments/stillsuitfragment";
        data["d0811984-35bb-435f-acad-3abcf4fb5d32"] = "WorldEntities/Doodads/Coral_reef/Coral_reef_Kelp_blood_02";
        data["d0aae751-1476-40ac-a9e0-eca1300e3b19"] =
            "WorldEntities/Environment/Precursor/Prison/PipeRoom/Precursor_Prison_PipeRoom_OutgoingPipe4";
        data["d0ac6c14-81a9-4bfd-b107-600655a9b217"] = "WorldEntities/Environment/Wrecks/EscapePod_17_GrassyPlateaus";
        data["d0be2a21-7134-4641-a058-20e9da4a9b37"] = "WorldEntities/Doodads/Geometry/Crystals/Crystal01";
        data["d0e47f29-c1e2-4b2b-a6f7-816d5dc9e471"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/vent_constructor_section_vertical_01_end";
        data["d0f7a4be-19e3-42ce-8bd0-e9c220a932f4"] = "WorldEntities/Environment/MembraneTree";
        data["d0fea4da-39f2-47b4-aece-bb12fe7f9410"] = "WorldEntities/Doodads/Precursor/Precursor_lab_container_01";
        data["d11dfcc3-bce7-4870-a112-65a5dab5141b"] = "WorldEntities/Tools/Gravsphere";
        data["d1247af8-0477-431e-ab82-c34e792e1d59"] = "WorldEntities/Tools/PipeSurfaceFloater";
        data["d13a3429-95bb-475f-b2d8-5d4c43fd2f30"] =
            "WorldEntities/Slots/SafeShallows/SafeShallows_Creature_SandDunes";
        data["d13bd79a-343f-496e-96dd-8e9c3fd3f3bb"] =
            "WorldEntities/Doodads/Coral_reef/Coral_reef_tree_mushrooms_02_04";
        data["d1453ae3-8bab-484e-911d-94e4ead07acc"] = "WorldEntities/Doodads/Coral_reef/coral_reef_grass_06";
        data["d18231c0-e7bd-4fdf-801b-a840c2d0e828"] = "WorldEntities/Slots/GrassyPlateaus/GrassyPlateaus_Loot_Grass";
        data["d1986e95-9b93-4cd6-898f-5bc151da3926"] = "WorldEntities/Slots/Dunes/Dunes_Loot_Techsite_Small";
        data["d1a29ab3-8577-42f6-ad62-065725c431a2"] =
            "WorldEntities/Doodads/Precursor/TempGun_Interiors/Precursor_Gun_box_01_animated";
        data["d1b3e2e5-87f1-4d11-b44a-b99d2d0f9d8c"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/explorable_wreckage_modular_room_details_09";
        data["d1c3d0a6-ec21-4552-888a-decb1048e264"] = "Submarine/Build/DioramaHullPlate";
        data["d1dc9afd-ae78-47f5-b30c-a81258325381"] = "WorldEntities/Doodads/Coral_reef/Coral_reef_red_seaweed_01";
        data["d1e41429-6d48-45c3-b704-912417abd539"] =
            "WorldEntities/Slots/MushroomForest/MushroomForest_Loot_CavePlants";
        data["d200d747-b802-43f4-80b1-5c3d2155fbcd"] = "WorldEntities/Environment/Precursor/Gun/Precursor_Gun_Console1";
        data["d209ef8e-ac76-474f-a2fe-367f6c28f125"] =
            "WorldEntities/Doodads/Precursor/Prison/Aquarium/Precursor_Prison_TeleporterRoom_03_Lights";
        data["d2136158-29ca-415d-b6fd-854b505d3b38"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/explorable_wreckage_modular_wall_details_05";
        data["d21bca5e-6dd2-48d8-bbf0-2f1d5df7fa9c"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/Starship_cargo_02";
        data["d21d90af-d9b2-48c3-aa64-2e7c4c803e55"] = "WorldEntities/Slots/Mountains/Mountains_Creature_Rock";
        data["d25a491e-b267-40e1-82f3-5df1150a087b"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/Starship_cargo_damaged_02_Far";
        data["d26276ab-0c29-4642-bcb8-1a5f8ee42cb2"] =
            "WorldEntities/Environment/Precursor/Gun/Precursor_Gun_ElevatorDoor";
        data["d290b5da-7370-4fb8-81bc-656c6bde78f8"] = "WorldEntities/Tools/VehicleStorageModule";
        data["d2c4f497-70ac-40db-b838-e952975d5901"] = "WorldEntities/Environment/Deprecated Atmosphere (Sphere)";
        data["d2c64045-9821-4996-a18e-4d6960468282"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/starship_girder_02";
        data["d2c92e45-6138-4e9a-810d-be77ec9cdf82"] =
            "WorldEntities/Atmosphere/UnderwaterIslands/UnderwaterIslands_Wreck_Adjust";
        data["d2d0ed5e-aa37-4906-bff7-57718ca77c22"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/discovery_trashcan_01_d";
        data["d32235f2-e230-4e1f-8ea3-8714c42fc3f0"] =
            "WorldEntities/Environment/Precursor/Prison/Antechamber/Precursor_Prison_Antechamber_Lights";
        data["d344afcf-71a1-4191-8869-b9a6c4a1e97a"] =
            "WorldEntities/Slots/JellyshroomCaves/Jellyshroom_Loot_AbandonedBase_Outside_Medium";
        data["d3645d71-518d-4546-9b68-a3352b07399a"] =
            "WorldEntities/Environment/Precursor/Cache/Precursor_Lab_specimencases_LabCache";
        data["d3a33ce4-e54e-480c-918c-5341a4787951"] =
            "WorldEntities/Slots/seaTreaderPath/SeaTreaderPath_Creature_CaveWall";
        data["d3b9095f-fcac-46de-83f7-762e3275e837"] = "WorldEntities/Environment/Wrecks/life_pod_exploded_7";
        data["d3bf649e-1eaa-4790-a113-8f73286af611"] = "Submarine/Build/FarmingTray";
        data["d3c239b6-08eb-4858-aaea-7f386798cb25"] =
            "WorldEntities/Slots/MushroomForest/MushroomForest_Loot_GiantTreeExteriorBase";
        data["d3dc20ad-10fa-47d5-b379-eceed501f1be"] =
            "WorldEntities/Environment/DataBoxes/UltraHighCapacityTankDataBoxSpawner";
        data["d3e933a0-1ba0-4f38-9733-9f81ca8ba444"] =
            "WorldEntities/Doodads/Precursor/precursor_block_deco_08_04_08_v6";
        data["d3ec61fc-a3ac-494c-bf24-6ab6968c5179"] =
            "WorldEntities/Environment/Wrecks/Wrecks_Starship_doors_locked_nokey_Aurora";
        data["d403da9a-7930-4207-a93c-3bee4a2508dd"] =
            "WorldEntities/Slots/MushroomForest/MushroomForest_Loot_GiantTreeInteriorFloor";
        data["d404587a-650b-47ab-a982-65e1b7a5ff64"] =
            "WorldEntities/Environment/Precursor/Gun/Mountains_Cave_WaterSurface";
        data["d40e85d3-610d-4052-9019-346728316e2c"] = "WorldEntities/Slots/KooshZone/KooshZone_Loot_CaveFloor";
        data["d41214f0-7a70-425f-b217-e9a8a84b9958"] =
            "WorldEntities/Slots/UnderwaterIslands/UnderwaterIslands_Loot_Techsite_Barrier_Medium";
        data["d41c1bcf-3993-478b-a22e-08e73461168e"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/Signs/GenericSign";
        data["d420cd62-2983-44a9-886a-8c7d214a2db9"] =
            "WorldEntities/Environment/Wrecks/submarine_Workbench_damaged_03";
        data["d425052e-636c-48fa-89b8-6c47c846a250"] =
            "WorldEntities/Slots/LostRiver/BonesField/BonesField_Loot_Cave_Ground";
        data["d4531315-6111-46ff-ac32-f0dca6fe1328"] =
            "WorldEntities/Doodads/Precursor/PrecursorTerminalWithTeleporter";
        data["d45cf82a-9a66-4274-8504-dba160c1e380"] = "WorldEntities/Slots/Dunes/Dunes_Creature_Rock";
        data["d4823241-ebcd-4238-995b-1f47f8211e4a"] = "WorldEntities/Tools/SeamothHullModule3";
        data["d4aa649b-7508-44e4-89fb-29334f12a64e"] = "WorldEntities/Tools/LaserCutter";
        data["d4ab56b9-91af-4cf4-94d9-0ee7b1b9957d"] = "WorldEntities/Atmosphere/Inactive Lavazone/Entrance";
        data["d4ad48a9-67fa-4b34-8447-5cd6a69d1270"] = "WorldEntities/Natural/FloatingStone2_Floaters";
        data["d4b7b7e2-9b1e-4661-970c-92a52b9020ea"] = "WorldEntities/Doodads/Precursor/precursor_column_08_07_08";
        data["d4be3a5d-67c3-4345-af25-7663da2d2898"] = "WorldEntities/Creatures/CuteFish";
        data["d4bfebc0-a5e6-47d3-b4a7-d5e47f614ed6"] = "WorldEntities/Tools/Battery";
        data["d4db1d27-b96a-419b-bb99-229fde8cfc10"] = "WorldEntities/Atmosphere/SparseReef/Normal";
        data["d4fcaa54-3c51-47ed-9531-b797858c8135"] = "WorldEntities/VFX/xSandFall_Thin";
        data["d503a40c-0cc3-4216-93bd-f21e38985712"] = "WorldEntities/Slots/Dunes/Dunes_Creature_CaveFloor";
        data["d50be841-735c-4e4b-bf5a-912056f0fb7a"] = "WorldEntities/VFX/xSparksOrange_3s_Small";
        data["d51bc179-3f20-4de2-9ee0-6dfd8dd22cb1"] = "WorldEntities/Unused/BubbleUnused";
        data["d51f9ea1-c51c-4140-ab19-1744e342a2fe"] = "WorldEntities/Tools/PropulsionCannon";
        data["d52e28fd-706b-4c07-a3f7-6412fa9b2438"] =
            "WorldEntities/Slots/SafeShallows/SafeShallows_Loot_ShellTunnelHugeExterior";
        data["d53cfbf1-f14d-4e9b-b8bb-cc65e734a9c5"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/docking_bar_bottle_03";
        data["d551d2e9-e581-4dfc-b41c-1343ab8c1337"] =
            "WorldEntities/Doodads/Coral_reef/Coral_reef_tree_mushrooms_02_03";
        data["d571d3dc-6229-430e-a513-0dcafc2c41f3"] = "WorldEntities/Doodads/Debris/Wrecks/Decoration/starfish_04";
        data["d586a247-122a-427d-9032-f42e898df17f"] = "WorldEntities/Doodads/Coral_reef/Crab_snake_mushrooms_01";
        data["d5a68e2e-bfd5-4e95-8863-17d70f044bba"] =
            "WorldEntities/Slots/GrassyPlateaus/GrassyPlateaus_Loot_CaveFloor";
        data["d5def0dd-bf4c-47cd-8c24-2bb9921ae7b2"] = "WorldEntities/Slots/SparseReef/SparseReef_Creature_CaveCoral";
        data["d5f3a601-729e-407a-b229-fd3daa601dd3"] = "WorldEntities/Environment/Wrecks/cyclopshullfragment6";
        data["d5f51365-ae0b-41ce-8bca-6959239c6e50"] = "WorldEntities/Environment/Prototype/FallingStalagmite";
        data["d603fbcd-f192-4654-998f-d7a625be7205"] =
            "WorldEntities/Slots/GrassyPlateaus/GrassyPlateaus_Loot_ArchOutcropping";
        data["d60ecea2-5307-4368-9c08-4e96a6866356"] = "WorldEntities/Atmosphere/Ship/CrashedShip_Interior_Entrance_03";
        data["d6389e01-f2cd-4f9d-a495-0867753e44f0"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/biodome_lab_containers_open_02";
        data["d63c0114-193a-4293-8661-60f53bfd77a3"] = "Submarine/Build/PictureFrame";
        data["d645d7c7-76a2-4818-86b0-5c3e37a51e31"] =
            "WorldEntities/Atmosphere/Precursor/EmperorFacility/Precursor_Prison_Antechamber_Atmosphere";
        data["d67bb43a-fed3-415f-9e4a-87f0c49d1960"] =
            "WorldEntities/Slots/LostRiver/TreeCove/TreeCove_Loot_Water_Floor";
        data["d69d04e9-bef6-4229-9bea-a76378cb0018"] = "WorldEntities/Doodads/Coral_reef/Coral_reef_Kelp_blood_03";
        data["d6b92e8a-177d-4fcb-af2d-99a8978a944b"] =
            "WorldEntities/Environment/Wrecks/PDAs/EscapePod_4_PDA_CaptainsCode";
        data["d6b9e61f-764e-4f27-9549-ca778ee3128a"] =
            "WorldEntities/Atmosphere/Ship/CrashedShip_Interior_PowerCorridor";
        data["d6d3543f-8eef-4cdf-a229-34372073205b"] =
            "WorldEntities/Slots/MushroomForest/MushroomForest_Loot_GiantTreeInteriorCeiling";
        data["d6d58541-ad9f-4686-b909-50b1a0f5835b"] = "WorldEntities/Doodads/Debris/Starship_exploded_debris_08";
        data["d6e8fc38-5767-4bc2-8586-3a847422c8f2"] = "WorldEntities/Slots/CrashZone/CrashZone_Loot_TrenchSand";
        data["d70c8458-4b19-4dbc-ba67-afa654af1999"] = "WorldEntities/Fragments/exosuit_damaged_06";
        data["d736be3a-68c0-43b9-bc8f-a7f07ac38924"] = "WorldEntities/Atmosphere/TreaderPath/Treader_Path_Cave_Tr_Box";
        data["d76dd251-492d-4bf9-8adb-25e59d709df2"] = "WorldEntities/Environment/Wrecks/poster_exosuit_02";
        data["d7981bba-bb72-4179-872d-906a8a6a28ff"] = "WorldEntities/Slots/GrandReef/GrandReef_Creature_CaveWall";
        data["d79ab37f-23b6-42b9-958c-9a1f4fc64cfd"] =
            "WorldEntities/Environment/Wrecks/Wrecks_Starship_doors_locked_nokey";
        data["d7f46e5f-7a6b-4b3c-9111-04af297a1d26"] = "WorldEntities/Doodads/RandomTree";
        data["d809cb15-6784-4f7c-bf5d-f7d0c5bf8546"] = "WorldEntities/Environment/Wrecks/poster_kitty";
        data["d81e84a4-7202-4148-8e3c-682287e59c59"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/DecoPlanterShelf";
        data["d81ed12f-f1c7-497a-bc57-c4f40ff0ffeb"] = "WorldEntities/Environment/Aurora/Aurora_ExoRoom_WeldablePanel";
        data["d8353600-b028-4888-a518-16b7b97dcfbd"] =
            "WorldEntities/Environment/Wrecks/PDAs/Wreck15_SafeShallows_PDA1";
        data["d84e5b62-ac0b-441e-8786-1ed7b2c20d60"] = "WorldEntities/Atmosphere/KelpForest/Caves";
        data["d88147fb-007c-481f-aa75-ebcbab24e4a8"] = "WorldEntities/Doodads/Debris/Starship_exploded_debris_19";
        data["d8838f12-2e24-40c9-a7c5-24fb9c08e934"] = "WorldEntities/Doodads/Coral_reef/coral_reef_small_deco_10";
        data["d899b034-c2d1-4097-8ba4-83bc2ff0540f"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/docking_clerical_folder3";
        data["d8b6b5ac-730f-4bcd-9fb7-593173c37570"] =
            "WorldEntities/Slots/MushroomForest/MushroomForest_Creature_RockWall";
        data["d8c7c300-cf01-448e-9bea-829b67ddfbbc"] = "WorldEntities/Creatures/CreatureRespawner";
        data["d8eb3ccd-497f-45e0-870b-85ecb9b83e4b"] = "WorldEntities/Lights/Grassyplateaus/Bounce";
        data["d8efe522-5355-48b8-b4fb-4d077bbc621d"] =
            "WorldEntities/Doodads/Coral_reef/Coral_reef_cave_root_small_04_blood";
        data["d8f0b5fe-5ca1-44b5-90d5-1037ffd95c73"] = "WorldEntities/Fragments/Old/solarpanelfragment";
        data["d90c18c6-ea54-436c-82cf-ab97af3907ea"] =
            "WorldEntities/Slots/Prison/Aquarium/PrisonAquarium_Loot_DeadCoral";
        data["d90fce02-c505-433c-bd7f-a9d4253ecbe0"] = "WorldEntities/Environment/Wrecks/ExplorableWreck_Grassy_34";
        data["d931cce0-b6b3-4f70-aa08-e1ed5ef12b29"] =
            "WorldEntities/Atmosphere/LostRiver/BonesField/LostRiver_BonesField_Lake";
        data["d939482e-715c-4355-8543-c3abf0eeb860"] = "WorldEntities/Fragments/Old/filtrationmachinefragment_old";
        data["d94bf0dd-dfeb-42e5-b633-f0f298c171c5"] = "WorldEntities/Slots/LostRiver/Canyon/Canyon_Creature_Ceiling";
        data["d95216c8-fa6b-4a20-8c04-e23532bc57a6"] =
            "WorldEntities/Atmosphere/LostRiver/Canyon/LostRiver_SkeletonCave_Cave_Sphere";
        data["d9524ffa-11cf-4265-9f61-da6f0fe84a3f"] =
            "WorldEntities/Environment/Wrecks/Wrecks_Starship_doors_bulkhead";
        data["d964f99c-abc1-463c-9e0b-dc5a719eb94a"] =
            "WorldEntities/Environment/Precursor/Prison/TeleporterRooms/Precursor_Prison_TeleporterHallway03";
        data["d98b7657-aea9-46f4-b118-d57dc2c6db44"] =
            "WorldEntities/Slots/BloodKelp_Cave/BloodKelp_Creature_CaveCeiling";
        data["d98d673a-8992-4486-a49c-81aa058e51dc"] = "WorldEntities/Tools/AirBladder";
        data["d98e748a-90bc-47f5-ba80-a70acc5d350e"] = "WorldEntities/Atmosphere/Inactive Lavazone/Large Chamber";
        data["d9a7d2f1-bbc9-4c30-9ba9-a2267a082f53"] =
            "WorldEntities/Slots/SafeShallows/SafeShallows_Creature_PlateauTop";
        data["d9ae8384-5bec-42c0-a51d-11bbb2662d95"] =
            "WorldEntities/Environment/DataBoxes/CyclopsFireSuppressionModuleDataBox";
        data["d9c3cc26-a295-4c91-8e02-fed447ca49a1"] = "WorldEntities/Doodads/Debris/Starship_exploded_debris_29";
        data["d9dbd520-b51b-4916-8927-83f9f35d369d"] = "WorldEntities/Lights/LostRiver/Point_Tree_Cove_Water_Blue";
        data["d9ea115f-bd23-44c0-b9cd-c1ff84e9ff66"] = "WorldEntities/Slots/KooshZone/KooshZone_Loot_Grass";
        data["d9f8befa-7342-4e45-bb5b-adc833f9543c"] =
            "WorldEntities/Slots/LostRiver/BonesField/BonesField_Loot_Ground";
        data["da298032-eb30-4765-894a-89172e898219"] = "WorldEntities/Tools/Welder_damaged";
        data["da2ec3cc-413d-4577-9dba-f0b95c191a72"] =
            "WorldEntities/Slots/BloodKelp_Cave/BloodKelp_Creature_CaveFloor";
        data["da2f6cc0-fe8b-4753-be69-5767d63f2e38"] = "WorldEntities/Lights/LavaZone/Inactive/Point_Lava_Large";
        data["da5070e8-9cc7-4598-a578-47e9dcac2901"] = "WorldEntities/Slots/Dunes/Dunes_Loot_Techsite_Barrier_Small";
        data["da6ec048-da70-4aca-bc05-1991e75ae89b"] = "Submarine/Build/Starship_doors_manual";
        data["da7341c3-e6a3-4cd3-ad57-49a4dc732ac9"] =
            "WorldEntities/Doodads/Coral_reef_Light/Coral_reef_cave_root_01_blood_Light";
        data["da807dc0-6668-415c-924b-c503f08c0dc2"] =
            "WorldEntities/Environment/AbandonedBases/AbandonedBase PDA/DeepPDA2";
        data["da8f10dd-e181-4f28-bf98-9b6de4a9976a"] = "WorldEntities/Doodads/Precursor/Precursor_Lab_specimencases";
        data["daadceaf-10fc-4724-9ef3-58f01a1853c4"] =
            "WorldEntities/Slots/SafeShallows/SafeShallows_Loot_ShellTunnelHuge";
        data["dab0d20f-1a75-46fd-86be-ead67acda565"] =
            "WorldEntities/Environment/Precursor/Prison/Antechamber/Precursor_Prison_EntranceHallway_Lights";
        data["daf487c1-b217-4d57-b47b-a73aea7a1d8d"] = "WorldEntities/Natural/FloatingStoneSmall3";
        data["daff0e31-dd08-4219-8793-39547fdb745e"] = "WorldEntities/Seeds/RedBushSeed";
        data["db1c4019-21d5-4833-9200-e38011911850"] =
            "WorldEntities/Slots/GrassyPlateaus/GrassyPlateaus_Creature_OpenDeep";
        data["db28e58f-6e41-44a1-bc0c-8b8d3fa91495"] =
            "WorldEntities/Environment/DataBoxes/VehicleModificationStationDataboxSpawner";
        data["db2df7f8-db1a-4210-8ca0-73531b93b889"] = "WorldEntities/Environment/Wrecks/Bio_reactor_damaged_02";
        data["db44e245-1bf5-42b7-9da2-ab7c33e91241"] = "WorldEntities/Doodads/Lost_river/Lost_river_generic_bone_02";
        data["db501e1b-9212-43da-b109-bfea57fc340d"] = "WorldEntities/Food/CookedHoverfish";
        data["db5a85f5-a5fe-43f8-b71e-7b1f0a8636fe"] =
            "WorldEntities/Environment/Precursor/Prison/Antechamber/Precursor_Prison_MainDoor_Divider";
        data["db6907f8-2c37-4d0b-8eac-1b1e3b59fa71"] = "WorldEntities/VFX/xLavaEruption";
        data["db6da81a-2fb6-4707-970b-c50998dd8937"] =
            "WorldEntities/Lights/LostRiver/BonesField/LostRiver_BonesField_Grass_Light";
        data["db79ee0b-65e9-4ea1-8b8b-948bbae128f7"] =
            "WorldEntities/Doodads/Coral_reef_Light/Coral_reef_cave_root_04_blood_Light";
        data["db7b6b56-8471-46b9-ba91-e42c91d2f517"] = "WorldEntities/Atmosphere/BloodKelp/Cave";
        data["db86ef34-e1fa-4eb2-aa18-dda5af30cb45"] = "WorldEntities/Doodads/Geometry/SafeShallows/Coral_Clump03a";
        data["dbedda33-a855-4b40-972e-5c91ab5846a4"] =
            "WorldEntities/Environment/Precursor/LostRiverBase/Precursor_LostRiverBase_Lab01_Extras";
        data["dc220132-9800-482f-a483-22c379b30846"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/Base_interior_wall_planter_leaves_02";
        data["dc7b15a1-20d5-48b9-8dd0-f61ca5d9fca5"] = "WorldEntities/Environment/Aurora/PDAs/Aurora_LivingArea_PDA3";
        data["dc885e5a-52aa-4ac1-be2a-acaee26f0e9d"] = "WorldEntities/Slots/SparseReef/SparseReef_Creature_CaveWall";
        data["dcab4f26-7542-4c44-b272-c48ffdf6ae22"] = "WorldEntities/Tools/Terraformer";
        data["dcefc62d-0f0d-4962-9b9f-9b95930417f0"] =
            "WorldEntities/Slots/LostRiver/Corridor/Corridor_Creature_Ceiling";
        data["dcf2df07-1f43-41c2-9a4f-47043612d4b5"] =
            "WorldEntities/Slots/UnderwaterIslands/UnderwaterIslands_Creature_OpenShallow";
        data["dd0298c1-49c2-44a0-8b32-da98e12228fb"] = "WorldEntities/Tools/Constructor";
        data["dd037903-eb47-47f5-9d4f-83100aca4ec4"] = "WorldEntities/Doodads/Coral_reef/Coral_reef_jelly_plant_01_02";
        data["dd1a3bd5-ceb3-4e21-9841-85f6ec379073"] = "WorldEntities/Doodads/Land/Land_grass_01_bright";
        data["dd3bf908-badb-4c8c-a195-eb50be09df63"] = "WorldEntities/Doodads/Precursor/Precursor_computer_terminal_B";
        data["dd438014-2e46-4a69-8e7e-5cc5b6551cdc"] = "WorldEntities/Environment/DataBoxes/CyclopsShieldModuleDataBox";
        data["dd4606fe-51b4-4037-8d19-b6e9eb677fb4"] =
            "WorldEntities/Atmosphere/Ship/CrashedShip_Interior_Entrance_01_03";
        data["dd6c64a9-5ac8-46b8-90e1-aac2390c65d2"] =
            "WorldEntities/Environment/Precursor/Prison/Aquarium/Precursor_Prison_Aquarium_TeleporterTerminal_Final";
        data["dd7ac9b2-20ff-4282-8d27-fe22e124cd44"] =
            "WorldEntities/Slots/KelpForest/KelpForest_Creature_UniqueCreature";
        data["dd923ae3-20f6-47e0-87c0-ae2bc386607a"] =
            "WorldEntities/Environment/AbandonedBases/AbandonedBaseJellyShroom5";
        data["dda796b6-c2b0-44e6-95b8-8f6641e1225d"] = "WorldEntities/Slots/LavaFalls/LavaFalls_Loot_Ceiling";
        data["de0e28a2-7a17-4254-b520-5f0e28355059"] = "WorldEntities/Doodads/Coral_reef/Coral_reef_kelp_young_04";
        data["de20fd12-cb15-49fa-8d8d-bcab3bd043a4"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/Starship_wires_11";
        data["de38c9d2-2cc9-48aa-8335-1f6cdb8dc2bd"] = "WorldEntities/Lights/Koosh Zone/KooshCave_Steamjet_pink";
        data["de450ed9-d39f-4aa2-8538-467602f845b2"] =
            "WorldEntities/Slots/Ship/Creature_ShipInterior_PowerRoomUnderWater";
        data["de58670c-afa5-47ea-9bee-f2adcc1b5fee"] = "WorldEntities/Environment/Deprecated Atmosphere";
        data["de5d9ea2-77ff-4e58-a744-364407fd54ba"] =
            "WorldEntities/Slots/LostRiver/TreeCove/TreeCove_Loot_Water_Wall";
        data["de91926d-3cab-4631-b74d-e64a87ba3323"] =
            "WorldEntities/Slots/KooshZone/KooshZone_Loot_Techsite_Barrier_Small";
        data["de972f1f-daab-41d6-b274-5173b0dd23d8"] = "WorldEntities/Doodads/Coral_reef/Coral_reef_kelp_01_long";
        data["deb8581f-842f-4854-b984-bff1c44ff220"] = "WorldEntities/Environment/Wrecks/baseroomfragment1";
        data["debfe306-940d-4fbc-8fd6-55733d32d5aa"] =
            "WorldEntities/Environment/AbandonedBases/AbandonedBase PDA/JellyPDARoom1Desk";
        data["dedd13a5-920e-425c-ac99-6da07fa83487"] = "WorldEntities/Slots/SparseReef/SparseReef_Creature_Spike";
        data["dedee57d-6a84-4bbb-92e3-d9b2249acc15"] =
            "WorldEntities/Doodads/Debris/Aurora/Rooms/CrashedShip_locker_room";
        data["dee58f94-e217-46b4-862e-c2a59884435f"] =
            "WorldEntities/Slots/MushroomForest/MushroomForest_Loot_Techsite_Medium";
        data["dee7831a-96d6-4452-be36-d259cf96cf1a"] = "WorldEntities/Doodads/Debris/Starship_exploded_debris_21";
        data["def10d70-f1ff-4f5d-8923-060a03a70fc0"] =
            "WorldEntities/Doodads/Coral_reef/Crab_snake_mushrooms_entrance_05";
        data["df03263c-ebfb-4e7c-b002-1ec3d67c1215"] =
            "WorldEntities/Doodads/Coral_reef/Coral_reef_jeweled_disk_purple_01_03";
        data["df36cdfb-abee-41f1-bdc6-fec6566d3557"] = "WorldEntities/Doodads/Debris/Starship_exploded_debris_06";
        data["df61af19-0e5a-4af9-87a9-e2ca36beff23"] =
            "WorldEntities/Slots/LostRiver/TreeCove/TreeCove_Creature_Ceiling";
        data["df651145-809a-433e-ab2f-8e01b6074880"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/Base_interior_Planter_Pot_02_empty_deco";
        data["df74210a-f565-49ec-a41d-68056a9607d0"] = "WorldEntities/Slots/CragField/Cragfield_Creature_Ground";
        data["df9aed66-c131-4570-9dcd-1e3d2109dcaa"] =
            "WorldEntities/Environment/Precursor/Cache/Precursor_Lab_table_LabCache";
        data["dfabc84e-c4c5-45d9-8b01-ca0eaeeb8e65"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/Goldglove_car_02";
        data["dfb8226a-bebe-4a29-90f6-2dd0cf8bc13b"] = "WorldEntities/Environment/ThermalVent_Bright_Big";
        data["dfbc0d13-d6e2-4c61-9e55-4e90254e5248"] =
            "WorldEntities/Environment/Precursor/LostRiverBase/Precursor_LostRiverBase_Console2_New";
        data["dfd03575-f7f2-441b-ae77-77ad2d828d1e"] =
            "WorldEntities/Doodads/Lost_river/LostRiverBase/Lost_river_hanging_plant_01_01";
        data["dffaf40f-9fbc-4553-9b35-3f939c76c283"] = "Submarine/Build/Bed1";
        data["e0174f84-da24-4347-a841-2af3696c08f6"] =
            "WorldEntities/Slots/BloodKelp_DeepTrench/BloodKelp_Loot_TrenchWall";
        data["e019dd4a-88e3-49c8-93a4-fe909b9b6391"] = "WorldEntities/Environment/FallingRock";
        data["e025be8d-5cf4-49df-89fe-de4375e464f6"] = "WorldEntities/Slots/Ship/Creature_ShipSpecial_RoostBirds";
        data["e04a1f29-2f36-414e-b1a4-82f320cf6999"] = "WorldEntities/Fragments/CyclopsEngine_Fragment";
        data["e04f6447-ea02-4f1f-bf1a-7f88f15f6ebf"] = "WorldEntities/Slots/Ship/Loot_ShipInterior_Cargo_Small";
        data["e0608e57-e9df-4f43-bb3a-8c56a42d2c1f"] =
            "WorldEntities/Doodads/Coral_reef/Coral_reef_jeweled_disk_blue_01_01";
        data["e0964c49-793e-4df3-8b77-d22f98793c40"] =
            "WorldEntities/Slots/GrassyPlateaus/GrassyPlateaus_Loot_CaveCeiling";
        data["e0ae8532-a6d5-436f-bdc0-846061d91686"] =
            "WorldEntities/Doodads/Coral_reef_Light/Coral_reef_Kelp_blood_03_Light";
        data["e0b1f772-b1bd-43a3-9b56-5f6979aab42d"] = "WorldEntities/Seeds/CreepvineSeed";
        data["e0b688b4-0cc6-4e0e-ac58-7f56182d7c24"] = "WorldEntities/Doodads/Geometry/SafeShallows/Rock_Small04";
        data["e0d37b66-c263-4a79-9818-51d403dfe68d"] =
            "WorldEntities/Slots/SafeShallows/SafeShallows_Creature_ShellTunnelHugeExterior";
        data["e0d415d9-1bc6-4c8b-b3c0-69f5e5fa6b08"] =
            "WorldEntities/Doodads/Coral_reef/Coral_reef_tree_mushrooms_02_01";
        data["e0e3036d-93fc-4554-8a58-4efed1efbbd7"] = "WorldEntities/Doodads/Lost_river/Reefback_coral_02";
        data["e0e8eb94-a5f7-42fb-8705-dfe57ec60e76"] = "WorldEntities/Slots/LostRiver/Corridor/Corridor_Loot_Ground";
        data["e1022037-0897-4a64-b460-cda2a309d2f1"] = "WorldEntities/Doodads/Lost_river/Reefback_coral_03";
        data["e109989f-703d-421f-85c7-bf69fbc91ef8"] =
            "WorldEntities/Doodads/Coral_reef/coral_reef_Stalactites_cluster_03_03";
        data["e10ce5d9-9675-4553-bf33-b17e93e3aab4"] = "WorldEntities/Doodads/Precursor/PrecursorKey_Orange";
        data["e10ff9a1-5f1e-4c4d-bf5f-170dba9e321b"] =
            "WorldEntities/Doodads/Lost_river/Lost_river_generic_skeleton_02";
        data["e1819dc3-0271-47ef-8105-4307d4d18dca"] = "WorldEntities/Slots/CragField/Cragfield_Loot_Sand";
        data["e197fcaf-a6fd-42b3-850a-c19036b3b414"] =
            "WorldEntities/Environment/Precursor/MountainIsland/Precursor_Mountain_Teleporter_FromFloatingIsland";
        data["e1ad3855-89d6-4963-b32b-8eddab12c4e3"] = "WorldEntities/Slots/SafeShallows/SafeShallows_Loot_PlateauTop";
        data["e1aea389-5838-4360-adbd-d12f8d4f717b"] = "WorldEntities/Doodads/Precursor/Prison/Relics/Alien_relic_08";
        data["e1d8b721-0edb-466e-93d3-074dc90d57f2"] =
            "WorldEntities/Doodads/Precursor/LostRiverBase/Precursor_LostRiverBase_TankGlassSmall";
        data["e1f7f96c-321d-48b6-b004-029adec77e88"] = "Submarine/Build/DevTestItem";
        data["e205ce39-5e36-4c21-b981-b6240da26449"] = "WorldEntities/Doodads/Land/Fern 02";
        data["e25ad60e-908d-41d5-b303-aaddb1f93f12"] =
            "WorldEntities/Atmosphere/LostRiver/Junction/LostRiver_Junction_Water_BorderFading";
        data["e26957d0-09a3-4631-b9bb-50bebafbca62"] = "WorldEntities/Tools/ExoHullModule1";
        data["e27aacf3-bded-462c-ba1b-919ad3198626"] = "WorldEntities/Tools/CyclopsSonarModule";
        data["e28463e6-ee38-4722-9d83-7d455ec2975f"] = "WorldEntities/Natural/FloatingStone3";
        data["e291d076-bf95-4cdd-9dd9-6acd37566cf6"] =
            "WorldEntities/Doodads/Coral_reef/Coral_reef_Kelp_blood_small_plants_02";
        data["e2a21af9-78dc-46a0-a30b-379ef6374b53"] =
            "WorldEntities/Slots/SafeShallows/SafeShallows_Loot_TechSite_Scatter_Medium";
        data["e2be8784-75d6-4b86-941e-9aac73e0b72b"] = "WorldEntities/Doodads/Land/land_plant_middle_09";
        data["e2c1a581-0cc4-466a-9f35-5363f9818216"] =
            "WorldEntities/Environment/Wrecks/Obsolete/EscapePod_Dunes_23_old";
        data["e2e5bb2d-6427-431c-ac3d-036c22083222"] = "WorldEntities/Eggs/StalkerEgg";
        data["e2fc5cc5-5ab8-4281-b400-ab2b4e9af884"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/descent_bar_seat_straight_04";
        data["e313478a-97ce-4fa8-9afd-d2025bed1037"] =
            "WorldEntities/Slots/MushroomForest/MushroomForest_Loot_Techsite_Small";
        data["e33a3170-7ffc-41c8-996b-be3dda86e3c7"] = "WorldEntities/Tools/CyclopsDecoy";
        data["e34589e1-48ed-48d7-b484-d41a9b07f836"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/explorable_wreckage_modular_room_details_13";
        data["e34b16d0-27cc-4044-abb0-1adb3c1a9a30"] = "WorldEntities/Slots/GrandReef/GrandReef_Creature_CaveCeiling";
        data["e34e2f46-7f24-44ce-af12-b0d1a3fb6452"] =
            "WorldEntities/Slots/ILZChamber/ILZChamber_Creature_CorridorOpen";
        data["e35c2df2-e7c0-4982-92ad-231ce4af7846"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/Starship_wires_13";
        data["e35fb5aa-19ba-4736-8f8c-6db679b5766c"] = "WorldEntities/Environment/Wrecks/Nuclear_reactor_damaged_03";
        data["e3742c20-ab0b-4714-929a-cc4eea95cc18"] = "WorldEntities/Lights/Precursor/Precursor_Cache_Spotlight_1";
        data["e39ccb91-844c-4ecb-8e90-6181409ea94f"] =
            "WorldEntities/Environment/Precursor/Prison/EggLab/Precursor_Prison_EggLab_Lights";
        data["e3a82cc4-5ce4-488c-a49b-9263affc00fb"] =
            "WorldEntities/Slots/LostRiver/BonesField/BonesField_Loot_Cave_Ceiling";
        data["e3bcfa3e-9c25-4f48-8389-e451f53c234d"] =
            "WorldEntities/Environment/Precursor/Prison/DissectionRoom/Precursor_Prison_DissectionRoom_EmperorEgg_Opened";
        data["e3bd7597-8dc1-4847-b647-a779169b9c33"] = "WorldEntities/Slots/Mesa/Mesa_Creature_Side";
        data["e3d5b699-c4b4-4b70-a001-60f2abdf4df2"] =
            "WorldEntities/Slots/LostRiver/BonesField/BonesField_Creature_Ceiling";
        data["e3d778b5-a81e-4b64-8dd6-910fb22772db"] = "WorldEntities/Natural/FloatingStone3_Floaters";
        data["e3df9a70-9c73-42d6-a81f-1abdf828630b"] = "WorldEntities/Doodads/Lava/lava_leak_01_03";
        data["e3e00261-92fc-4f52-bad2-4f0e5802a43d"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/biodome_lab_containers_close_02";
        data["e3fd373d-6ecc-497a-b396-816f3cb5f9b6"] = "WorldEntities/Doodads/Coral_reef/Coral_reef_cave_root_03_blood";
        data["e40daa31-8eb8-463a-b91a-d3aedb631744"] = "WorldEntities/Doodads/Coral_reef/Coral_reef_cave_root_04_blood";
        data["e411825d-cc5e-4717-a1c1-a533c9d40939"] = "WorldEntities/Environment/Wrecks/constructorfragment2";
        data["e42243eb-4f38-42cd-acec-1d38d9b1b120"] =
            "WorldEntities/Doodads/Precursor/Precursor_cube_03_damaged_piece_06";
        data["e44ebb24-d731-41e1-b104-351ba3936c2d"] = "WorldEntities/Lights/UnderwaterIslands/Floaters";
        data["e459fe68-2844-4998-9a29-f44dd22ef2cf"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/Starship_wires_06";
        data["e482e01d-8a47-48fe-aa97-3a51c35eee4f"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/Starship_work_chair_03";
        data["e4897657-74bb-43fe-9b24-78ba26132055"] =
            "WorldEntities/Environment/Precursor/SurfaceVents/Precursor_GrandReef_Vent";
        data["e4afd08e-6b70-4b6e-883d-afbe116803c1"] = "WorldEntities/VFX/xSteamLeakLoop_medium";
        data["e4b62296-ec83-4324-90b6-de321166e722"] = "WorldEntities/Slots/GrassyPlateaus/GrassyPlateaus_Loot_Tower";
        data["e4ccde5a-24e9-4b48-8bd0-7c0661e95901"] = "WorldEntities/Slots/SparseReef/SparseReef_Creature_OpenShallow";
        data["e4d385cf-b067-4eba-a126-1e46c3c2d773"] =
            "WorldEntities/Slots/Mountains/Mountains_Creature_IslandCaveCeiling";
        data["e4ea0e38-7baa-49ce-b85c-89a22935574f"] =
            "WorldEntities/Doodads/Coral_reef/coral_reef_blood_mushrooms_01_03";
        data["e4f47afd-18aa-4ebb-a7e8-8f24dc130051"] =
            "WorldEntities/Slots/LostRiver/Junction/Junction_Loot_ThermalVent";
        data["e4f6fd0f-82ec-49ee-8546-6b770d118f61"] = "WorldEntities/Doodads/Land/Fern 01";
        data["e501c2fb-cdd6-45b3-8dcf-4440d7378fe7"] =
            "WorldEntities/Doodads/Precursor/LavaBase/Lights/Precursor_LavaCastleBase_StairWell_Lower_Lights";
        data["e54098a2-3e1b-46b6-a52a-ebd3b8080ee6"] =
            "WorldEntities/Slots/UnderwaterIslands/UnderwaterIslands_Loot_IslandCaveWall";
        data["e54a9087-b4f6-4f31-8860-3c725b2dc788"] =
            "WorldEntities/Slots/MushroomForest/MushroomForest_Loot_CoralRoot";
        data["e557149e-b045-4271-9118-da72f87a9cfe"] = "WorldEntities/Fragments/ReinforcedDiveSuitFragment_old";
        data["e56a14ce-7f31-4f5e-9278-8bdf16eca3e2"] = "WorldEntities/Fragments/exosuit_01_old";
        data["e57da0d6-c79d-45e4-907d-870c0b3a04cc"] = "WorldEntities/Lights/LostRiver/Point_Tree_Cove_Pink_med";
        data["e57dff85-9900-4106-8467-d3c81c6401a7"] = "WorldEntities/Seeds/SmallFanSeed";
        data["e5ac5d26-be6e-4634-8693-dd95410c4ac9"] =
            "WorldEntities/Slots/MushroomForest/MushroomForest_Loot_Techsite_Barrier_Small";
        data["e5ce971f-399c-4a51-a610-76a8f9a1b0d8"] =
            "WorldEntities/Doodads/Precursor/Prison/Aquarium/Precursor_Prison_TeleporterRoom_02_Lights";
        data["e600a1f4-83df-447d-80ab-e3f4ec074b32"] = "WorldEntities/Tools/HighCapacityTank";
        data["e60dba6a-80d2-4583-a241-058f9ee823ca"] =
            "WorldEntities/Doodads/Debris/Aurora/Rooms/CrashedShip_entrance_03";
        data["e6156d7d-1463-4179-a2fe-f926013b463c"] = "WorldEntities/Seeds/PurpleStalkSeed";
        data["e6175247-4963-420d-8fc5-58c711a08d56"] = "WorldEntities/Atmosphere/JellyshroomCaves/Geyser";
        data["e63a1477-a7ad-4acc-93de-03178728c2c6"] = "WorldEntities/Lights/Koosh Zone/KooshCave_pink_geyser_large";
        data["e6400ba5-9bd8-43fd-a1ba-4ba5238db752"] = "WorldEntities/Slots/KooshZone/KooshZone_Loot_Sand";
        data["e64676d7-0648-4f1e-9ab0-8e37ec877ef9"] = "WorldEntities/Doodads/Lost_river/Lost_river_generic_bone_11";
        data["e64b7e70-c6a3-4224-b603-c5d53041b6ab"] = "WorldEntities/Slots/SafeShallows/SafeShallows_Loot_Island";
        data["e65b36c8-3b85-463c-8f30-95859401b2cb"] = "WorldEntities/Environment/WallPlant";
        data["e69be2e8-a2e3-4c4c-a979-281fbf221729"] = "WorldEntities/Creatures/Shocker";
        data["e6ac95bf-4daa-440d-8ce7-4437ed47c3de"] =
            "WorldEntities/Environment/Precursor/Gun/Precursor_Gun_MoonPoolSurface";
        data["e6cd1290-9831-4d0c-8039-c0cb3becbaf7"] =
            "WorldEntities/Slots/LostRiver/SkeletonCave/SkeletonCave_Creature_Open";
        data["e6e7977e-3639-43b9-978f-9d0b40f17800"] = "WorldEntities/Doodads/Precursor/Prison/Relics/Alien_relic_02";
        data["e6f6ebfc-ee5d-456d-9ed5-b88e7bcc42c8"] = "WorldEntities/Atmosphere/KelpForest/Dense";
        data["e70f0843-0e9f-472c-b0a2-796e278958e8"] = "WorldEntities/Atmosphere/BloodKelpTwo/Normal";
        data["e712fdde-4d3d-4242-b618-cd43a08f0e96"] =
            "WorldEntities/Atmosphere/LostRiver/GhostTree/LostRiver_GhostTree_Waterfall";
        data["e7182326-813d-427c-bf30-3ae3fca3a1a2"] = "WorldEntities/Doodads/Coral_reef/Coral_reef_shell_02_11";
        data["e71c0826-b7d3-479e-b1e4-a1bc377e79d3"] = "WorldEntities/Doodads/Precursor/PrecursorKey01_legacy";
        data["e729fcbe-de07-4caf-9165-98c1b7576286"] = "WorldEntities/Tools/WorldPDA";
        data["e73c400b-b557-44d4-baa4-0205dab24ff1"] = "WorldEntities/Slots/Mountains/Mountains_Creature_CaveFloor";
        data["e76de278-2a58-4b6a-8029-0a6016cda8d7"] = "WorldEntities/Doodads/Land/Tallgrass 8";
        data["e7768d87-1982-46fb-a42f-479a6b207740"] = "WorldEntities/Slots/GrandReef/GrandReef_Creature_Wall";
        data["e776a8ba-4a50-4246-bd0c-0e6744048008"] = "WorldEntities/Slots/Mountains/Mountains_Loot_ThermalVent";
        data["e78040d0-38c0-48dc-87c1-bd8651f03914"] = "WorldEntities/Creatures/Unused/Grabcrab";
        data["e7843016-7f0b-40ea-9a4c-1daac7b64fb7"] =
            "WorldEntities/Slots/UnderwaterIslands/UnderwaterIslands_Loot_Techsite_Medium";
        data["e7a307ac-8f20-407a-8389-85f0a756f328"] =
            "WorldEntities/Environment/Precursor/Prison/EggLab/Precursor_Prison_EggLab_EmperorEgg";
        data["e7c097ac-e7be-4808-aaaa-70178d96f68b"] = "WorldEntities/Natural/drillable/DrillableDiamond";
        data["e7f2eca3-9e86-4e9c-aa76-0b08bcc7a82c"] = "WorldEntities/Lights/Precursor/Precursor_Cave_Plant04";
        data["e7f9c5e7-3906-4efd-b239-28783bce17a5"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/biodome_lab_containers_close_01";
        data["e8047056-e202-49b3-829f-7458615103ac"] =
            "WorldEntities/Doodads/Coral_reef/Coral_reef_purple_tentacle_plant_01_01";
        data["e80ab79b-cf7a-465d-92f2-b8a275fc8429"] =
            "WorldEntities/Environment/Precursor/Gun/Precursor_Gun_Elevator_DoorTerminalsRoot";
        data["e80b22ff-064d-46ca-b71e-456d6b3426ab"] = "WorldEntities/Doodads/Coral_reef/Coral_reef_purple_fan";
        data["e8143977-448e-4202-b780-83485fa5f31a"] =
            "WorldEntities/Doodads/Precursor/Precursor_Prison_Interior_Antechamber";
        data["e82d3c24-5a58-4307-a775-4741050c8a78"] = "WorldEntities/Creatures/SpineEel";
        data["e837f37f-ed22-499d-b6ce-51f01b9602d8"] = "WorldEntities/Natural/SupplyCrate_Sealed";
        data["e85adb0d-665e-48f5-9fa2-2dd316776864"] = "WorldEntities/Atmosphere/GrassyPlateaus/WreckInterior";
        data["e862224b-3da8-41bd-809e-6d26ae557ea5"] = "WorldEntities/Tools/RadiationSuit";
        data["e871df3e-45fa-43cf-91ca-3a2b257ceaf6"] = "WorldEntities/Doodads/Coral_reef/Coral_reef_Kelp_blood_blob_01";
        data["e88e7a23-2a99-41c5-aed9-a2bfaca3619d"] = "WorldEntities/Doodads/Land/land_plant_small_03_02";
        data["e8a8f22d-1c20-42ad-a0c6-09cb27d89d95"] =
            "WorldEntities/Environment/Precursor/Gun/Precursor_Gun_Teleporter_ToLavaCastleBase";
        data["e8adf3f7-f928-47fd-b43f-0f2ca93dbfcf"] =
            "WorldEntities/Environment/Precursor/LostRiverBase/Precursor_LostRiverBase_Aquarium_Decals";
        data["e90956ad-9af0-4aa4-8d70-3350620677f8"] =
            "WorldEntities/Lights/Precursor/Precursor_Gun_MoonPoolEntranceLight";
        data["e914366d-72da-44bf-8c58-acec90f86116"] = "WorldEntities/Slots/ILZCastle/ILZCastle_Creature_ChamberOpen";
        data["e93a0e26-116b-4439-91c4-cb644df0e023"] = "WorldEntities/Slots/KooshZone/KooshZone_Loot_CaveWall";
        data["e9445fdf-fbae-49dc-a005-48c05bf9f401"] = "WorldEntities/Doodads/Land/farming_plant_01_02";
        data["e94d9bcb-0d35-4418-b303-1ba5171d04d3"] = "WorldEntities/Natural/SupplyCrate_Flare";
        data["e95ca15f-d07d-4ca7-a18f-6de1c322b36a"] =
            "WorldEntities/Doodads/Lost_river/lost_river_skull_coral_group_01";
        data["e968ac17-2a1a-400e-864e-991d97c60634"] =
            "WorldEntities/Doodads/Precursor/LavaBase/Final_Rooms/Precursor_LavaBase_Entry02";
        data["e97c72ec-4999-48fa-b8b2-6d3f8791a7e8"] = "WorldEntities/Doodads/Land/land_plant_small_01_03";
        data["e99477b6-1cca-40af-bd49-8d5ffe53984c"] = "WorldEntities/Slots/GrandReef/GrandReef_Creature_ThermalVent";
        data["e9a1e527-058f-4fa7-be26-6d4e009cbc28"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/descent_bar_sofa_str_01";
        data["e9a2cd1b-44ae-45a5-a42c-e1d1e680c4b8"] =
            "WorldEntities/Environment/Precursor/LavaCastleBase/Precursor_LavaCastleBase_Entry_Door_02";
        data["e9b75112-f920-45a9-97cc-838ee9b389bb"] = "WorldEntities/Structures/Base";
        data["e9b7f02b-ed87-4a49-aa19-00c1d894c696"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/docking_bar_cupgroup_01";
        data["e9c17365-1abc-4061-92e9-04df569efe63"] = "WorldEntities/Doodads/Debris/Wrecks/ExplorableWreckRoom02";
        data["e9fc2ec7-47da-4a13-80f8-153977193f69"] =
            "WorldEntities/Slots/GrassyPlateaus/GrassyPlateaus_Creature_CaveCeiling";
        data["ea10c63a-6983-49ac-947a-6c752567f3e5"] = "WorldEntities/Slots/Ship/Creature_ShipInterior_Cargo";
        data["ea24134e-4deb-4652-959e-1a4a5487ba13"] =
            "WorldEntities/Slots/SafeShallows/SafeShallows_Creature_CaveRecess";
        data["ea65ef91-e875-4157-99f9-a8f4f6dc92f8"] =
            "WorldEntities/Doodads/Precursor/LavaBase/Precursor_LavaCastleBase_IonCrystalPedestal";
        data["ea672491-328e-484e-844d-0e7add295a3a"] = "WorldEntities/Slots/Mountains/Mountains_Creature_OpenShallow";
        data["ea771dca-6332-42f2-b9b6-4ca39171df15"] = "WorldEntities/Environment/MagmaSpawn";
        data["ea808fee-3ee8-4faa-9df0-246dab74ea8e"] = "WorldEntities/Doodads/Precursor/Cable_04";
        data["ea9a81dd-7fc8-415f-8c56-a95c48376a92"] =
            "WorldEntities/Slots/LostRiver/BonesField/BonesField_Creature_Cave_Ground";
        data["ea9f43f5-373f-4276-8743-852fb8a2cb88"] = "WorldEntities/Doodads/Debris/Starship_exploded_debris_17";
        data["eab2dd30-7060-40d1-9e4a-e685ef4962ca"] = "WorldEntities/Doodads/Lava/lava_pillar_middle_01";
        data["eac9cc2c-bbf9-4a4c-b19b-344ad0d937fe"] = "WorldEntities/Atmosphere/Mountains/MountainsBaseBox";
        data["eade781a-86a7-4636-9e4c-ee70b7244056"] = "WorldEntities/Tools/SeamothStorageModule";
        data["eafc576d-f153-4f70-903d-9dd0aa66b4a8"] = "WorldEntities/Doodads/Land/land_grass_03";
        data["eb05669f-a12b-403c-8175-e38f60f66426"] = "WorldEntities/Slots/SparseReef/SparseReef_Creature_Sand";
        data["eb075490-2ae4-41d4-bd1d-9d068548557c"] = "WorldEntities/Seeds/BulboTreePiece";
        data["eb1745f3-7c0e-4b21-8ad5-7c74833eedb6"] = "WorldEntities/Fragments/Old/GrandReefFragment";
        data["eb38b229-1289-421e-8599-e7c38a30ce34"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/explorable_wreckage_modular_wall_details_02";
        data["eb38de5d-c3df-4446-a37a-d770fb0f92bb"] = "WorldEntities/Environment/CrashHome";
        data["eb3c9533-e181-4429-8238-f557c7db0209"] =
            "WorldEntities/Doodads/Precursor/Precursor_Interior_Damage_Props_01";
        data["eb59359e-c9d4-4387-8cbf-e544e76a0ffe"] = "WorldEntities/Environment/Wrecks/PDAs/EscapePod_7_PDA_Random";
        data["eb5ea858-930d-4272-91b5-e9ebe2286ca8"] = "WorldEntities/Doodads/Coral_reef/coral_reef_grass_03";
        data["eb6634e5-3a58-4a0d-ae4e-b673e1fa51ea"] =
            "WorldEntities/Doodads/Coral_reef/Coral_reef_jeweled_disk_purple_01_02";
        data["eb667015-21f8-45e0-8dc9-ee06e8ed2dd1"] = "WorldEntities/Natural/GrassyPlateausEgg";
        data["eb876b8c-72a5-4edf-a632-8a2dac89de31"] = "WorldEntities/Doodads/Lava/lava_leak_01_01";
        data["ebb0965f-e8ce-40e7-9b90-3ee09e95d259"] = "WorldEntities/Environment/Wrecks/Wrecks_VentCover";
        data["ebb740bf-a23f-4e48-a776-30c78fb6db05"] =
            "WorldEntities/Environment/Aurora/Consoles/Wreck_UnderwaterIslands_4_Console";
        data["ebbf8081-5195-4a14-88cd-d79b76ca4cbf"] =
            "WorldEntities/Slots/LostRiver/GhostTree/GhostTree_Creature_Wall";
        data["ebc835bd-221a-4722-b1d0-becf08bd2f2c"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/Starship_cargo_damaged_opened_02";
        data["ebc943e4-200c-4789-92f3-e675cd982dbe"] =
            "WorldEntities/Environment/Precursor/SkeletonCave/SkeletonCave_Precursor_Scanner_02";
        data["ebdebe72-2c09-4dcb-9a8d-3226a105886a"] = "WorldEntities/Atmosphere/SafeShallows/Caves Entrance (Sphere)";
        data["ebff579f-2fdd-47ec-9471-c2f88da4f734"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/vent_constructor_junction_vertical_02";
        data["ec4edf1f-7077-4196-9ee9-4fd05088d80d"] = "Submarine/Build/HullPlate01";
        data["ec6a10d5-7514-4fbd-b9f7-039c7bd35319"] = "WorldEntities/Food/CuredReginald";
        data["ec6fa336-2f55-468e-9bfe-626e655e146d"] = "WorldEntities/Environment/Precursor/Precursor_Prison_Vent";
        data["eca7420d-1b15-43f7-9abf-571fc7810e6f"] = "WorldEntities/Environment/Wrecks/ExplorableWreck_Grassy_33";
        data["eca96e8f-0097-4627-b906-f454c329d9e5"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/base_hull_crack_02";
        data["ecb2a647-95bb-4660-8380-20f2a5b76ec4"] = "WorldEntities/Doodads/Lost_river/Lost_river_tree_01";
        data["ecb30a76-47f4-486d-8937-62c46cf4d27c"] = "WorldEntities/Fragments/Old/SparseReefFragment";
        data["ecbce131-1f9b-4acd-a249-aac4966f3d80"] =
            "WorldEntities/Doodads/Lost_river/LostRiverBase/Lost_river_hanging_plant_03_03";
        data["ecde4b2b-decf-4b2a-8eb1-8b0415d6264f"] =
            "WorldEntities/Slots/SafeShallows/SafeShallows_Loot_TechSite_EscapePod_Small";
        data["ed0c1682-ddd3-4b5a-93d4-ec8d0408e673"] =
            "WorldEntities/Environment/AbandonedBases/AbandonedBase PDA/JellyPDAExterior";
        data["ed118e2d-09e4-4e26-b560-5fab726c7c71"] =
            "WorldEntities/Slots/GrassyPlateaus/GrassyPlateaus_Creature_CaveSpecial";
        data["ed2c6028-7a1c-4d73-a810-8e72618c246d"] = "WorldEntities/Slots/KooshZone/KooshZone_Loot_Geyser";
        data["ed3555f7-7e92-4c80-9f0a-f545956cb4a8"] = "WorldEntities/Doodads/Debris/Wrecks/Wreck_FiltrationMachine";
        data["ed3a6c39-3ca1-4c14-8f2a-4a9d07a8d048"] =
            "WorldEntities/Slots/SparseReef/SparseReef_Loot_Techsite_Barrier_Medium";
        data["ed652a88-d4d3-4d03-bbd1-d16953d0b8b1"] =
            "WorldEntities/Slots/MushroomForest/MushroomForest_Creature_GiantTreeInteriorCeiling";
        data["ed71de8c-f40e-42cf-ba33-cfbac00c4af8"] = "WorldEntities/Atmosphere/MushroomForest/MF_caves_light_box";
        data["ed844685-29a5-44a7-9658-23cc8a8c54ee"] = "WorldEntities/Slots/LostRiver/Corridor/Corridor_Loot_Ceiling";
        data["ed8d3ff3-3f27-4ff4-99dd-6e30d548400c"] = "WorldEntities/Doodads/Precursor/PrecursorSickRevealTerminal";
        data["ed9efc3d-7957-4ce8-ac5d-d36476c9e96f"] = "WorldEntities/Fragments/Old/nuclearreactorfragment";
        data["eddc8357-1794-45f6-a41b-b0a6555924fa"] =
            "WorldEntities/Slots/KooshZone/KooshZone_Loot_KooshZone_Koosharama";
        data["edf679a5-7256-4388-aea2-d733d6977b41"] =
            "WorldEntities/Slots/MushroomForest/MushroomForest_Loot_CaveFloor";
        data["ee12929a-08e5-4a48-8ec0-5e61396093cf"] = "WorldEntities/Seeds/SpikePlantSeed";
        data["ee1807bf-6744-4fee-a66f-c71edc9e7fb6"] = "WorldEntities/Doodads/Lost_river/Lost_river_rib_03";
        data["ee1baf03-0560-4f4d-ad29-13a337bef0d7"] = "WorldEntities/Doodads/Coral_reef/Coral_reef_kelp_dense_01";
        data["ee340c54-1069-47b0-9999-0586728ee771"] = "Base/Ghosts/BaseBioReactor";
        data["ee49dc2d-392f-44d6-9ef0-2b879d1bc1c8"] =
            "WorldEntities/Slots/MushroomForest/MushroomForest_Loot_GiantTreeInteriorEntrance";
        data["ee56cc29-1da3-41d7-8cf3-d8f028cb9559"] = "WorldEntities/VFX/xSandWarning";
        data["ee7ef0cf-21ab-4c0c-871d-e477c5dfa1ce"] = "WorldEntities/Natural/diamond";
        data["ee95dbaf-d96e-4837-86a1-e3fa323582a1"] = "Submarine/Build/Submarine_hull_fragments_01";
        data["eebc9447-3a36-4b15-bc1f-82762abb4272"] = "WorldEntities/Natural/basalt";
        data["eec4e14c-0d29-48ec-b511-66f46df28a96"] =
            "WorldEntities/Slots/GrassyPlateaus/GrassyPlateaus_Creature_ArchTop";
        data["eec96e86-3660-4ec8-abbd-932724951461"] =
            "WorldEntities/Doodads/Precursor/TempGun_Interiors/Old/Precursor_Gun_Teleporter_Room_Lights_old";
        data["eed4ec38-0363-40de-84dc-de6dd9b9e876"] = "WorldEntities/Creatures/Biter_02";
        data["eef635cf-a8eb-413b-9497-92953a597dae"] = "WorldEntities/Slots/LostRiver/Canyon/Canyon_Loot_Algae";
        data["ef1370e3-832f-4008-ac39-99ad24f43f76"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/Starship_doors_door";
        data["ef263e45-c2c6-4861-9103-99e95835f632"] = "WorldEntities/VFX/xFakeSunShafts";
        data["ef375125-885f-4289-8577-c7a4a5f218b3"] =
            "WorldEntities/Environment/Precursor/Prison/DissectionRoom/Precursor_Prison_DissectionRoom";
        data["ef58d052-ff43-4461-840c-06421b414190"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/explorable_wreckage_modular_room_details_12";
        data["ef9567ba-0cc8-4a2c-abed-017b4cc838a1"] = "WorldEntities/Environment/Wrecks/EscapePod_13_MushroomForest";
        data["ef997794-fcc7-4bb2-9b4a-16c278236124"] = "WorldEntities/Atmosphere/Ship/CrashedShip_Interior_Exo";
        data["efad7d03-969c-47e4-8e05-02f50dd57104"] = "WorldEntities/Slots/BloodKelp_Cave/BloodKelp_Creature_CaveWall";
        data["efaf4fac-d240-4f51-b572-072b448ab4de"] = "WorldEntities/Doodads/Lost_river/lost_river_pillar_02";
        data["efbad810-06f3-4366-8a67-c9803aa129fd"] = "WorldEntities/Doodads/Lava/lava_rock_01_04";
        data["efc12083-779f-4567-9819-185dc7e3c226"] = "WorldEntities/Fragments/BaseBulkhead_Fragment";
        data["efe034c5-8fb0-4ce7-997b-86b2b9fd9261"] = "Base/Ghosts/BasePlanter";
        data["f01ea803-822b-472c-b4df-40546f36fbeb"] = "WorldEntities/Lights/Grassyplateaus/Point_GPCave_Plant";
        data["f0295655-8f4f-4b18-b67d-925982a472d7"] = "WorldEntities/Doodads/Coral_reef/Coral_reef_shell_tunnel_02";
        data["f0429c44-a387-42e6-b621-74ba4dd8c2da"] =
            "WorldEntities/Environment/Precursor/Prison/TeleporterRooms/Precursor_Prison_Teleporter_ToKooshZone";
        data["f0438971-2761-412c-bc42-df80577de473"] = "WorldEntities/Doodads/Geometry/RockBlades/RockBlade01";
        data["f04f2d34-ad30-410d-81d6-46760ba54aca"] =
            "WorldEntities/Slots/SafeShallows/SafeShallows_Creature_CavePlants";
        data["f070f056-6064-456f-9c51-45d5c5aa66a5"] = "WorldEntities/Doodads/Coral_reef/Coral_reef_shell_02_08";
        data["f0713f3d-586b-4c71-88a3-18dd6c3dd2a4"] =
            "WorldEntities/Doodads/Coral_reef/Coral_reef_jeweled_disk_red_01_02";
        data["f0721fd2-dac9-4730-8e73-fb602daa225e"] = "WorldEntities/Fragments/LaserCutterFragment_InCrate";
        data["f0877072-08ab-4fe8-adba-a17dc3d369fb"] =
            "WorldEntities/Doodads/Debris/Aurora/Decoration/Signs/Aurora_Lockers_Robotics_Sign2";
        data["f08a4013-5852-4b33-bd7d-466aae6b6969"] = "WorldEntities/Natural/sulphurcrystal";
        data["f08e7cfd-5aa5-40a7-a341-bd16514c40c0"] = "WorldEntities/Food/StillsuitWater";
        data["f08f286f-8b5d-4b22-96ff-21007d34f31f"] = "WorldEntities/Atmosphere/SafeShallows/HugeTube";
        data["f091042a-614e-4424-82d8-b3442de81fe9"] = "WorldEntities/Fragments/Old/MushroomForestFragment";
        data["f0982501-76d5-4b8d-b5b5-8df3a4da67f9"] = "WorldEntities/Slots/GrandReef/GrandReef_Loot_Wall";
        data["f0a54d9a-7717-473f-8450-5ff24824ed7e"] = "WorldEntities/Doodads/Coral_reef/Coral_reef_cave_root_02_blood";
        data["f0cc7c28-fe3f-41db-8c23-dcb11c730b32"] =
            "WorldEntities/Lights/LostRiver/BonesField/LostRiver_DeepGrandReef_Pool_Light_Large";
        data["f0e96bd9-eae9-43cd-88a3-ce105d6b8eb4"] = "WorldEntities/Fragments/Marki_03_scan";
        data["f1048ab1-6c1f-4cb4-a74f-6e927437a806"] = "WorldEntities/Natural/FloatingStone_Beach_01";
        data["f1052b87-8e48-461d-a910-0400b3346be4"] = "WorldEntities/Environment/DataBoxes/UltraGlideFinsDataBox";
        data["f111c882-4ef6-4ad0-aeba-d123568ad3fc"] = "WorldEntities/Doodads/Precursor/Prison/Relics/Alien_relic_10";
        data["f18de3f2-b0bb-40bc-93cd-9a2ef9df94dc"] =
            "WorldEntities/Slots/LostRiver/SkeletonCave/SkeletonCave_Creature_Skeleton";
        data["f19fe6dc-4bea-4f80-aeb9-793a44221e5b"] =
            "WorldEntities/Slots/seaTreaderPath/SeaTreaderPath_Creature_CaveFloor";
        data["f1a5a572-9f96-4ff8-953c-651a4786e5e8"] =
            "WorldEntities/Atmosphere/LostRiver/Canyon/LostRiver_SkeletonCave";
        data["f1cde32e-101a-4dd5-8084-8c950b9c2432"] = "Submarine/Build/Trashcans";
        data["f1f3d023-a8c9-40e4-8b36-60abf7f7ed6c"] = "WorldEntities/Slots/Ship/Loot_ShipInterior_LivingArea";
        data["f2107564-5928-4ce5-82fb-1f58b8d98ec3"] = "WorldEntities/Slots/KelpForest/KelpForest_Loot_Sand";
        data["f21fc283-7b4d-44e2-a02d-adc77eb5dac4"] = "WorldEntities/Slots/SafeShallows/SafeShallows_Loot_CaveWall";
        data["f23274c9-3c98-49d4-b60d-48011256fcf3"] = "WorldEntities/Doodads/Debris/Wrecks/Decoration/shelve_01";
        data["f23ee303-c180-4b39-8b2e-931ae4a2254b"] = "WorldEntities/Slots/KooshZone/KooshZone_Creature_CaveFloor";
        data["f26ecc40-ea99-4a62-96f5-e419b7293d05"] =
            "WorldEntities/Slots/BloodKelp_Cave/BloodKelp_Creature_CaveRoots";
        data["f2772c62-1bd5-48c5-897a-64bd8e991fe1"] = "WorldEntities/Jonas/DummyStorageChest";
        data["f28a2e46-3cd0-4f5a-9a26-7632c5020724"] = "WorldEntities/Slots/Mountains/Mountains_Loot_IslandCaveCeiling";
        data["f2ae1b00-0768-4fb7-8220-6facbba32fb8"] = "WorldEntities/Environment/Wrecks/PDAs/EscapePod_4_PDA_Decoy";
        data["f2ae9bd0-c6ac-46c8-82c0-ce31ebdfb75c"] = "WorldEntities/Seeds/MelonSeed";
        data["f2b9fe45-39d6-4307-b1e0-143eb1937d6e"] = "WorldEntities/Environment/Wrecks/life_pod_exploded_4";
        data["f314c25d-7e3a-4993-927f-4c4d9772b01c"] =
            "WorldEntities/Slots/LostRiver/Junction/Junction_Creature_Water_Floor";
        data["f31c5df1-e26d-4c33-9d7c-6b2034966517"] =
            "WorldEntities/Lights/LostRiver/BonesField/LostRiver_BonesField_DirectionalGlow";
        data["f3350851-47f2-46fe-92d5-2ab8a1a98fcb"] =
            "WorldEntities/Environment/Precursor/Prison/TeleporterRooms/Precursor_Prison_TeleporterHallway02";
        data["f350b8ae-9ee4-4349-a6de-d031b11c82b1"] = "WorldEntities/Doodads/Fragments/Map_Room_fragment_03";
        data["f38898b1-2c55-4069-af58-dffa7ef315a0"] = "WorldEntities/Fragments/BaseNuclearReactor_Fragment";
        data["f39e56b9-9a11-4582-875f-c37f1ed37314"] = "WorldEntities/VFX/xLavaJetSmokeHuge";
        data["f3b8a107-c2b1-444f-9abb-50dd0188d366"] = "WorldEntities/Seeds/PurpleFanSeed";
        data["f3c4588c-816a-4a7b-b82f-3aba23d07851"] =
            "WorldEntities/Slots/LostRiver/SkeletonCave/SkeletonCave_Creature_Wall";
        data["f3cc7890-36a2-4f11-8b29-c13cf771f1e9"] = "WorldEntities/Atmosphere/LostRiver/Canyon/LostRiver_Canyon";
        data["f3de21af-550b-4901-a6e8-e45e31c1509d"] = "WorldEntities/Doodads/Coral_reef/Coral_reef_ball_clusters_02";
        data["f3f56cd3-9840-4689-8f9e-eb00a91f3658"] = "WorldEntities/Slots/Dunes/Dunes_Creature_SandPlateau";
        data["f4146f7a-d334-404a-abdc-dff98365eb10"] = "WorldEntities/Tools/Transfuser_damaged";
        data["f41782ed-1ba3-49d1-b7a1-9ee7eaf4e50d"] = "WorldEntities/VFX/xGeyser_Eruption";
        data["f41a1855-1dc1-495a-adf2-c4495fd39936"] =
            "WorldEntities/Environment/Wrecks/Power_Cell_Charging_Station_damaged_base";
        data["f42ef34d-b5b8-4ee9-b0dc-c29eb98d9abb"] =
            "WorldEntities/Atmosphere/Ship/CrashedShip_Interior_Entrance_01_01";
        data["f461e181-ac02-4d1e-ba2d-7cab7c61d689"] =
            "WorldEntities/Lights/LostRiver/BonesField/LostRiver_BonesField_Ceiling_Light_Large";
        data["f475663a-6dce-4a45-9613-a7e829687098"] = "WorldEntities/Slots/Ship/Creature_ShipSpecial_Birds";
        data["f475b85f-4893-490f-908b-a725895cb4d4"] = "WorldEntities/Doodads/Precursor/PrecursorDoorWithKey";
        data["f49b7a4d-6dad-4e6d-82d7-4a1cf19a74bf"] = "WorldEntities/Slots/KelpForest/KelpForest_Loot_CaveSpecial";
        data["f4b3942e-02d8-4526-b384-677a2ad9ce58"] = "WorldEntities/Environment/Wrecks/cyclopshullfragment8";
        data["f4b5674b-8d19-4fc0-90f1-363c1769e745"] = "WorldEntities/Slots/KelpForest/KelpForest_Creature_GrassDense";
        data["f4bb41d2-7c47-4c5b-8651-c1538d8c0a9d"] = "WorldEntities/Natural/TwistyBridgesEgg";
        data["f4ce1e14-26b4-444f-8ccc-b75524e88dd4"] = "WorldEntities/Slots/DeepGrandReef/DeepGrandReef_Creature_Wall";
        data["f4f5f1ea-d860-4d08-9204-3c237ff08a0f"] = "WorldEntities/Doodads/Coral_reef/Coral_reef_green_mohawk_02";
        data["f515d7bd-2e3a-4551-b5d9-7051c8ec5f26"] =
            "WorldEntities/Slots/LostRiver/TreeCove/TreeCove_Creature_Ledgewall";
        data["f531f5a2-6aa6-4b03-b2c1-6a73570594bf"] =
            "WorldEntities/Doodads/Coral_reef/Coral_reef_small_blue_fans_small_01_05";
        data["f54adc84-8087-49a7-b99c-2954e264f279"] = "WorldEntities/Tools/PrecursorIonPowerCell";
        data["f5593eef-efe4-43ba-a998-817593b99246"] =
            "WorldEntities/Doodads/Lost_river/Lost_river_hanging_plant_01_03";
        data["f5654b52-805a-4324-ac66-e571bbce4e41"] = "WorldEntities/Environment/Aurora/PDAs/Aurora_THallway_PDA1";
        data["f56ddb54-d326-4a0e-b916-1f79e9eae1fe"] = "WorldEntities/Doodads/Debris/Wrecks/Decoration/bed_01";
        data["f575af41-9245-46e7-bea4-e60f0c3a860b"] = "WorldEntities/Slots/LostRiver/BonesField/BonesField_Loot_Algae";
        data["f578f94a-3cb0-46ee-b4df-0def68cb7803"] = "WorldEntities/Environment/CollapsibleSandSmall";
        data["f59d499b-c1ff-45d9-867a-a6808fdf5dc1"] = "WorldEntities/Environment/ThermalVent_EcoEvent_Big";
        data["f5b113ba-fd9a-45f0-a095-50ce14e26fa8"] = "WorldEntities/Environment/DataBoxes/CreatureDecoyDataBox";
        data["f5b14ae4-dd07-4789-8100-193361baac11"] = "WorldEntities/Tools/CyclopsSeamothRepairModule";
        data["f5b6ebed-9ad9-4e46-b0b4-0f8d6467e091"] = "WorldEntities/Tools/Flare";
        data["f5bbdafc-7228-4fbe-a302-ce3fac4107b2"] = "WorldEntities/Doodads/Geometry/SafeShallows/Coral_Clump03c";
        data["f5c542df-7388-42dd-83c6-fd3b60128ca1"] =
            "WorldEntities/Atmosphere/LostRiver/Junction/LostRiver_Junction_ThermalVent";
        data["f5da7019-e0d4-4f5f-ba54-27b8fe3dd21e"] =
            "WorldEntities/Environment/Precursor/Gun/Precursor_Gun_ControlRoom_AnimatedPillar";
        data["f5dc3fa5-7ef7-429e-9dc6-2ea0e97b6187"] =
            "WorldEntities/Atmosphere/Precursor/Caches/Precursor_Cache_Atmosphere";
        data["f5ebac74-4099-4af7-9b64-a1b1fad3fb1e"] = "WorldEntities/Doodads/Lost_river/Lost_river_tree_roots_02";
        data["f6011f25-c8c7-41bc-a74b-415b9934e672"] =
            "WorldEntities/Doodads/Coral_reef/Coral_reef_small_rocks_seaweed_06";
        data["f60b5fb5-9430-4a1d-9978-390cd4685132"] = "WorldEntities/Environment/Wrecks/constructorfragment3";
        data["f61433fe-a319-49fc-81f4-f44584128843"] = "WorldEntities/Slots/LostRiver/TreeCove/TreeCove_Creature_Algae";
        data["f616e02e-bafc-42d0-9eee-6dd4fc74ae5b"] = "WorldEntities/Environment/Aurora/Aurora_WaterClip_LowerEntry";
        data["f6211589-93b1-4667-828d-56cad2554015"] = "WorldEntities/Lights/Mushroom Forest/MF_bounce_light";
        data["f6232c0d-ad52-46d3-bc8f-417f888d98a2"] = "WorldEntities/Doodads/Coral_reef/Coral_reef_small_deco_04";
        data["f6484349-4141-4016-8685-5fe7c8c1b22e"] = "WorldEntities/Structures/PowerGenerator";
        data["f654e870-3101-4ff3-8bb4-528dceef43a5"] = "WorldEntities/Natural/salt";
        data["f65beedb-2d76-466b-abc8-37c474228157"] = "WorldEntities/Natural/lithium";
        data["f67c158c-3b83-473c-ad52-93fd2eeef66b"] = "WorldEntities/Natural/drillable/DrillableMagnetite";
        data["f699ffb2-c099-45c6-ba8c-0130223046a1"] = "WorldEntities/Atmosphere/CrashZone/CrashZonelootexclusion_box";
        data["f6a02723-61cf-4048-9dac-543b5aa241d3"] = "WorldEntities/Atmosphere/FloatingIslands/Islands";
        data["f6a103e0-c4e9-4514-ae5b-5d3362fbe16d"] = "WorldEntities/Slots/LavaFalls/LavaFalls_Creature_Open";
        data["f6d9aa88-aae3-48e3-b5c2-4ebd2b4cec81"] =
            "WorldEntities/Environment/Precursor/Precursor_Prison_Vent_Mount";
        data["f6e196e8-b3f2-4d88-93dc-2811f7c4e2f5"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/docking_clerical_clock";
        data["f72d8e76-691f-4ddb-a274-0fcc236dd43d"] = "WorldEntities/Doodads/Precursor/precursor_block_deco_02_04_04";
        data["f744e6d9-f719-4653-906b-34ed5dbdb230"] = "WorldEntities/Doodads/Fragments/Moon_Pool_fragment_03";
        data["f78942c3-87e7-4015-865a-5ae4d8bd9dcb"] = "WorldEntities/Creatures/ReaperLeviathan";
        data["f7b31a12-3ea1-404e-a5c4-71bff23f0fe1"] = "WorldEntities/Slots/LostRiver/Corridor/Corridor_Loot_Wall";
        data["f7d46bd9-0f77-450f-9c27-9a2172f6e93b"] = "WorldEntities/Atmosphere/LostRiver/Corridor/LostRiver_Corridor";
        data["f7e26c44-bb28-4979-8f83-76ed529979fc"] = "Submarine/Build/Marki_02";
        data["f7f2dd12-514e-4500-bbd1-e1671b2754f6"] =
            "WorldEntities/Environment/Precursor/Gun/Precursor_TeleporterFinal_Stand";
        data["f7f2f98b-6607-4695-a184-5a57fbefc6c2"] =
            "WorldEntities/Lights/LostRiver/BonesField/LostRiver_BonesField_Stream_Light_Large";
        data["f7fb4077-b4d7-443c-b367-349cc1d39cc8"] = "WorldEntities/Food/DisinfectedWater";
        data["f80bd6d5-d567-414d-91b3-33adcd4eb4f3"] = "WorldEntities/Doodads/Lava/lava_leak_01_09";
        data["f817eafa-4551-4b29-af5c-224b0f980e93"] = "WorldEntities/Slots/Ship/Loot_ShipSpecial_Wreck";
        data["f81988d5-886d-4218-9c5a-6dcc98290197"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/docking_clerical_penholder";
        data["f845092a-3545-4e9e-96e1-078c5d5c1e46"] = "WorldEntities/Seeds/SmallMelon";
        data["f88550bf-3d43-4159-974f-2ed7c59385d4"] =
            "WorldEntities/Environment/Precursor/Cache/Precursor_Cache_Console1";
        data["f8939889-d23e-413d-b4cb-807c4a8d1761"] = "WorldEntities/Spawns/Spawn_Skyray_Decontaminated_NoRoost";
        data["f895696c-cdc6-4427-a87f-2b62666ea0cb"] = "WorldEntities/Natural/FloatingStone4_Floaters";
        data["f8957f23-aef8-451a-a5f9-5146919398f5"] = "WorldEntities/Doodads/Coral_reef/Coral_reef_shell_02";
        data["f8b3d5c8-68d6-4a54-955f-fc5ee466c40a"] =
            "WorldEntities/Slots/MushroomForest/MushroomForest_Loot_GiantTreeExterior";
        data["f8c69b59-666b-4fc0-8b1a-d38c35264cea"] = "WorldEntities/Slots/ILZChamber/ILZChamber_Loot_CorridorCeiling";
        data["f8de4919-8d08-4bfd-b3b5-7d91cb8c72a6"] =
            "WorldEntities/Doodads/Precursor/TempGun_Interiors/Gun_Entry_Lights";
        data["f8e33be6-fa34-424b-85c4-cfea9549a268"] = "WorldEntities/Atmosphere/Mountains/Mountains_IslandCave_sph";
        data["f9006f3c-1694-4711-9532-624577e4ac7d"] = "WorldEntities/Creatures/EyeyeLava";
        data["f901b968-5b3c-4795-8ded-82db2fa23440"] = "Submarine/Build/power_cylinder";
        data["f902e4e9-ac1a-4df0-bc8b-005585e77102"] =
            "WorldEntities/Slots/GrassyPlateaus/GrassyPlateaus_Loot_Techsite_Barrier_Small";
        data["f905cf4f-3a0d-4194-82e9-1432d0851d92"] =
            "WorldEntities/Environment/Precursor/LavaCastleBase/Precursor_LavaCastleBase_KeyBlue";
        data["f90ba94f-326b-4cbd-bc95-4dc39addbf33"] = "WorldEntities/Doodads/Coral_reef/Coral_reef_koosh_bush_small";
        data["f90d7d3c-d017-426f-af1a-62ca93fae22e"] = "WorldEntities/Natural/PrecursorIonCrystalMatrix";
        data["f91a9f38-ed82-4790-b6a2-a7753120e001"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/explorable_wreckage_modular_wall_details_08";
        data["f9242b9d-2feb-4d25-add9-47eb84fc7085"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/discovery_trashcan_01_c";
        data["f92c849a-d198-45d3-9355-8cf63ff67585"] = "WorldEntities/Environment/Wrecks/PDAs/Wreck17_KelpForest_PDA1";
        data["f931d301-19c4-47f4-a593-e7dc090cd48e"] =
            "WorldEntities/Slots/JellyshroomCaves/Jellyshroom_Loot_CaveCeiling";
        data["f935fcd0-e49f-4f9a-826a-78856706533c"] =
            "WorldEntities/Environment/Aurora/Consoles/Aurora_LivingArea_Console";
        data["f9449d71-da9c-446e-aaf0-7a7014e418e9"] = "WorldEntities/Slots/LostRiver/Canyon/Canyon_Loot_Wall";
        data["f97552d1-cfd5-4544-b931-c1c63f0b440d"] = "WorldEntities/Slots/SparseReef/SparseReef_Loot_Sand";
        data["f978cb78-8b00-4991-afaa-eaca969c8cac"] = "WorldEntities/Slots/GrandReef/GrandReef_Loot_CaveFloor";
        data["f97bf790-a5bd-4e7f-a5e8-9fca1b37f81c"] = "WorldEntities/Doodads/Lost_river/lost_river_plant_02";
        data["f9db5e76-0f8a-49f6-8e5e-d782d83fbfe5"] =
            "WorldEntities/Atmosphere/LostRiver/GhostTree/LostRiver_GhostTree_Skeleton";
        data["f9f01e62-2983-4ebd-a67e-a904033b4a97"] = "WorldEntities/Tools/PowerCell";
        data["fa18a1df-c5b2-4d14-93ae-60ee0bcc2e8a"] =
            "WorldEntities/Doodads/Debris/Aurora/Decoration/Signs/Aurora_CrewArea_Cabin_03_Sign";
        data["fa20d32e-9214-4b34-845f-cb810cc60851"] =
            "WorldEntities/Slots/LostRiver/BonesField/BonesField_Loot_Cave_Grass";
        data["fa2e064b-b156-4443-8bb2-11b7cc3f0c95"] =
            "WorldEntities/Doodads/Coral_reef/Coral_reef_tree_mushrooms_connector_01";
        data["fa331518-7a53-4432-b5f2-760d07bbfadc"] = "WorldEntities/Fragments/Old/exosuitfragment_old";
        data["fa362f56-4de4-4b05-b4f0-e46cc555ffb4"] = "WorldEntities/Atmosphere/Ship/CrashedShip_Interior_Elevator";
        data["fa40d69f-61eb-4691-80b2-79dfc5da2acb"] =
            "WorldEntities/Slots/JellyshroomCaves/Jellyshroom_Loot_AbandonedBase_Outside_Small";
        data["fa45bade-00f3-4d5a-8a03-c34c710770cc"] =
            "WorldEntities/Slots/seaTreaderPath/SeaTreaderPath_Creature_Grass";
        data["fa4be476-31d8-4267-8836-d202c3e534d0"] = "WorldEntities/Tools/WhirlpoolTorpedo";
        data["fa4cfe65-4eaf-4d51-ba0d-e8cc9632fd47"] = "WorldEntities/Creatures/Boomerang";
        data["fa5327d8-1975-4e5a-93b2-9e5554907d7b"] = "WorldEntities/Eggs/EmperorEgg";
        data["fa57316f-468c-42bc-bae3-813e95274ca4"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/Starship_wires_04";
        data["fa5e644a-777b-4b54-a92a-0241752b8e06"] =
            "WorldEntities/Doodads/Precursor/precursor_block_deco_08_04_08_v2";
        data["fa7fa15c-5515-497f-872d-d6d579a39f60"] = "WorldEntities/Creatures/Jumper";
        data["fa895c8f-3dc4-47e3-8fa1-efa214c9255c"] =
            "WorldEntities/Environment/Precursor/Cache/Precursor_SkeletonCaveCache_Console";
        data["fa8e6060-31e6-42db-b20b-1ed707ac87a5"] =
            "WorldEntities/Slots/LostRiver/BonesField/BonesField_Creature_Ground";
        data["fa986d5a-0cf8-4c63-af9f-8c36acd5bea4"] =
            "WorldEntities/Environment/Kelp Forest/Obstruction_Rock_Medium01";
        data["fa9b3999-d201-47fc-a8c5-e7c4030b6b60"] = "WorldEntities/Tools/RadiationGloves";
        data["faad3954-b0fd-4bff-be98-6d2108e9bfd5"] =
            "WorldEntities/Slots/seaTreaderPath/SeaTreaderPath_Creature_CaveCeiling";
        data["fab9bc63-1916-4434-a9c6-231f421ffbb5"] = "WorldEntities/Natural/HatchingEnzymes";
        data["faef77dc-65e2-4fe5-9099-bc3980aba4dd"] = "WorldEntities/Atmosphere/Ship/CrashedShip_Interior_Cargo";
        data["faf96875-22aa-401b-a144-4a4c856239d1"] = "WorldEntities/Doodads/Land/Tropical Plant 1b";
        data["fb04bbd8-5e60-4a8e-afe9-c82880fb5cd4"] = "WorldEntities/Slots/Mountains/Mountains_Creature_CaveCeiling";
        data["fb075f1c-9e81-45c6-bed8-9ec76b80b4af"] =
            "WorldEntities/Slots/UnderwaterIslands/UnderwaterIslands_Loot_ValleyFloor";
        data["fb24fd2b-4951-4fc1-9b64-b0feaeaa6f56"] = "WorldEntities/Doodads/Lost_river/lost_river_skull_coral_05";
        data["fb2886c4-7e03-4a47-a122-dc7242e7de5b"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/Starship_cargo_damaged_opened_large_02";
        data["fb30026c-1302-4197-9fe6-eb3ee949ef6e"] =
            "WorldEntities/Environment/Wrecks/ExplorableWreck_SafeShallows_41";
        data["fb377474-e5de-490e-b2f9-11fd9996c3e2"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/explorable_wreckage_modular_wall_details_07";
        data["fb470956-2d0e-499a-a256-05d0e9a8e933"] =
            "WorldEntities/Doodads/Precursor/precursor_column_maze_10_32_10_v2";
        data["fb4de51f-cac9-4683-a7a4-1c10e9d9addc"] =
            "WorldEntities/Environment/Precursor/Prison/Antechamber/Precursor_Prison_MainDoor_WaterForceField";
        data["fb5de2b6-1fe8-44fc-a555-dc0a09dc292a"] = "WorldEntities/Natural/drillable/DrillableUraninite";
        data["fb9204ab-c39d-4ea5-98cc-9aa7804d9c19"] = "WorldEntities/Slots/Dunes/Dunes_Loot_ThermalVent_Grass";
        data["fb941ab6-9c74-4673-b6a5-2dcb40720d34"] = "WorldEntities/Doodads/Coral_reef/Coral_reef_small_deco_08";
        data["fb9afc2b-13a1-48ae-8e5f-b5c34a9adb80"] =
            "WorldEntities/Slots/DeepGrandReef/DeepGrandReef_Loot_AbandonedBase_Inside_Small";
        data["fba656f8-6259-4706-81fa-6a97092980e4"] =
            "WorldEntities/Environment/Precursor/Gun/Precursor_Gun_MoonPool_ScanDoor_old";
        data["fbbc088c-6c8b-4859-a18b-d951058a2825"] =
            "WorldEntities/Doodads/Debris/Aurora/Decoration/Signs/Aurora_ExoRoom_LivingArea_Sign2";
        data["fbfacd7b-32a8-4065-8c25-b0a703f2683b"] = "WorldEntities/Natural/Bleach";
        data["fc5d61e0-8001-405e-b3f5-4fe32b967030"] =
            "WorldEntities/Environment/Wrecks/Wrecks_Starship_doors_backgrounddoor";
        data["fc7c1098-13af-417a-8038-0053b65498e5"] =
            "WorldEntities/Doodads/Coral_reef/Coral_reef_purple_mushrooms_01_01";
        data["fc9c96ac-5c0b-4611-897d-aaae644e4458"] = "WorldEntities/Atmosphere/Mountains/Mountains_CaveEntrance_cube";
        data["fca5cdd9-1d00-4430-8836-a747627cdb2f"] = "WorldEntities/VFX/BubbleColumn_med_01";
        data["fcae5fbd-2e40-4946-a1bf-8b7109546019"] =
            "WorldEntities/Doodads/Coral_reef/Crab_snake_mushrooms_entrance_01";
        data["fcc9917f-8122-4e34-a5ed-288ce6dc2efd"] =
            "WorldEntities/Slots/FloatingIsland/FloatingIsland_Loot_AbandonedBase_Inside_Small";
        data["fce043f4-d156-44ea-9afd-dd5eb56578cd"] = "WorldEntities/Environment/Wrecks/PDAs/Wreck2_Grassy_PDA2";
        data["fce170c2-3147-432d-a8df-f86a187db5d3"] = "WorldEntities/Slots/seaTreaderPath/SeaTreaderPath_Loot_Rock";
        data["fcf04278-bfbb-409d-bada-a6f22564efde"] = "WorldEntities/Doodads/Coral_reef/Coral_reef_koosh_bush_large";
        data["fcfdfa61-8768-43f7-9d00-b85c397e3553"] =
            "WorldEntities/Doodads/Debris/Wrecks/ExplorableWreck1_clean_atmospherezonetemplate";
        data["fd1f04f2-7440-474e-be02-23ed2aa37b80"] =
            "WorldEntities/Environment/DataBoxes/UltraGlideFinsDataBoxSpawner";
        data["fd2380ab-9d46-477f-a254-3aa486f7c34d"] = "WorldEntities/Natural/depletedreactorrod";
        data["fd24f106-7a7b-4255-bcaf-196edcc253a2"] = "WorldEntities/Slots/Ship/Loot_ShipInterior_Corridor_Small";
        data["fd32969f-c4d7-4c51-9d68-0cb61b0bdca7"] =
            "WorldEntities/Environment/AbandonedBases/AbandonedBase PDA/JellyPDARoom2Desk";
        data["fd3f6266-079a-4aa8-8f26-ef21045724c9"] = "WorldEntities/Environment/Wrecks/ExplorableWreck_Mountains_5";
        data["fd642907-b0f6-422c-a65d-2ed9e261ab87"] =
            "WorldEntities/Environment/Precursor/Cache/Precursor_BloodKelpCache_DoorTerminalsRoot1";
        data["fd70584f-f3f1-4dc7-a157-32a3681211d3"] = "WorldEntities/Slots/Mountains/Mountains_Creature_Sand";
        data["fd79bd80-f873-472b-9dd2-39893e452172"] = "WorldEntities/Environment/Prototype/BurningRock";
        data["fdb2bcbb-288a-40b6-bd7a-5585445eb43f"] =
            "WorldEntities/Environment/Precursor/LostRiverBase/Precursor_LostRiverBase_Balcony_DoorTerminalsRoot";
        data["fdb93810-dfdf-446b-aa27-de1856656caf"] =
            "WorldEntities/Slots/MushroomForest/MushroomForest_Loot_EscapePod_Medium";
        data["fddc977e-bc6a-444c-872b-00f983e8c9ab"] =
            "WorldEntities/Environment/DataBoxes/Obsolete/DataboxSpawner_Base";
        data["fde8c0c0-7588-4d0b-b24f-4632315bd86c"] = "WorldEntities/Tools/DiveReel";
        data["fdedd0ed-c0b1-4418-9902-564b6a7d3c46"] = "WorldEntities/Environment/Wrecks/PDAs/Wreck13_Grassy_PDA1";
        data["fdfe24a6-e905-4b77-b4a3-d019f8557650"] =
            "WorldEntities/Environment/Precursor/Prison/DissectionRoom/Precursor_Prison_DissectionRoom_Lights";
        data["fe0ac1d2-e86a-4be1-b8ad-cf8b4683df11"] = "WorldEntities/Natural/SandLoot";
        data["fe114eff-7567-4503-b4d4-78d347c8711f"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/docking_bar_bottle_01";
        data["fe145621-5b25-4000-a3dd-74c1aaa961e2"] = "WorldEntities/Doodads/Coral_reef/Coral_reef_ball_clusters_01";
        data["fe24885d-8b61-4bcd-b57b-193f79c958f3"] = "WorldEntities/Environment/Wrecks/EscapePod_2_BloodKelp";
        data["fe24efb3-b34f-4c24-932d-b514db580f40"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/submarine_engine_console_01_wide";
        data["fe44f5fa-31a7-4385-9422-e0eb8170c210"] = "WorldEntities/Lights/Precursor/Skeleton_Cave_Spotlight";
        data["fe481885-c591-49fa-aedf-0ee679f4a6b4"] =
            "WorldEntities/Environment/Precursor/Prison/PipeRoom/Precursor_Prison_PipeRoom_OutgoingPipe1";
        data["fe5a7250-cb43-4d9c-ad51-5218cc581f60"] =
            "WorldEntities/Doodads/Debris/Aurora/Decoration/Signs/Aurora_CrewArea_Cabin_04_Sign";
        data["fe856d8a-133c-43f8-9472-315d02f0664a"] = "WorldEntities/Lights/Mountains/Mountains_YellowPlant_LRG";
        data["fe89d8d5-7857-46ac-8420-7f0c3b6f10b1"] = "Submarine/Build/Submarine_hull_fragments_05";
        data["fe96f3ed-5ea7-45a8-b4ff-ce1b473b12b2"] =
            "WorldEntities/Slots/UnderwaterIslands/UnderwaterIslands_Loot_IslandPlants";
        data["feaf94db-75f2-438b-a2de-787cf4fc2e5e"] =
            "WorldEntities/Slots/LostRiver/BonesField/BonesField_Creature_Open";
        data["febfd3f0-5dc9-43a9-9d09-152c685bba37"] = "WorldEntities/Natural/FloatingStone7";
        data["fec5bf85-8e70-48bb-9e9d-939d694632a5"] = "WorldEntities/Doodads/Coral_reef/coral_reef_plant_middle_08";
        data["fecb50b0-eb8a-4ca1-b95b-356fc0f4ac32"] =
            "WorldEntities/Doodads/Precursor/Cache/Precursor_MushroomForestCache_TeleporterDecoration";
        data["fede6143-7da3-4aa8-826d-44590b42a975"] = "WorldEntities/Slots/Dunes/Dunes_Loot_CaveCeiling";
        data["ff364183-7c19-464d-ade0-b9bd626decf1"] =
            "WorldEntities/Environment/Precursor/Prison/TeleporterRooms/Precursor_Prison_TeleporterHallway04";
        data["ff4374cf-2d98-4a0e-b6c8-ded844657323"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/starfish_03_bend";
        data["ff43eacd-1a9e-4182-ab7b-aa43c16d1e53"] = "WorldEntities/Creatures/SeaDragon";
        data["ff44da08-fbbe-41bd-8b11-7119db865adc"] =
            "WorldEntities/Slots/SafeShallows/SafeShallows_Loot_UniqueCreature";
        data["ff57f8a7-4699-489c-ad35-96c8de21e00c"] = "WorldEntities/Slots/Ship/Loot_ShipInterior_AuxPowerRoom1_Small";
        data["ff727b98-8d85-416a-9ee7-4beda86d2ba2"] = "WorldEntities/Seeds/OrangeMushroomSpore";
        data["ff7e2f77-9479-4f16-ab5f-3588986f9bd5"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/Base_interior_Planter_Pot_01_empty_deco";
        data["ff8e782e-e6f3-40a6-9837-d5b6dcce92bc"] = "WorldEntities/VFX/xUnderwaterElecSource_medium";
        data["ff9b4394-e7d3-42e6-b924-585af2d0e03f"] =
            "WorldEntities/Doodads/Debris/Wrecks/Decoration/docking_bar_bottle_02";
        data["ffd41645-a702-4b91-8736-3114a33ede11"] = "WorldEntities/Fragments/terraformerfragment_old";
        data["ffef3320-9d36-4a0f-8b2b-6ab1247426cb"] = "WorldEntities/Environment/Wrecks/Bio_reactor_damaged_03";
        data["ffefd592-fd1f-4a7a-bf9c-20fe3b10930f"] = "WorldEntities/Fragments/Old/seamothfragment_old3";
        data["fff7ee12-c75d-48bd-a6e0-8fb4856cd1ab"] = "WorldEntities/Atmosphere/UnderwaterIslands/Cave";

        inverse = data.ToDictionary(e => e.Value, e => e.Key);
        foreach (var kvp in data)
        {
            var sh = kvp.Value.Substring(kvp.Value.LastIndexOf('/') + 1);
            shortName[sh] = kvp.Key;
        }
    }

    public static string getPrefab(string id)
    {
        return data.ContainsKey(id) ? data[id] : null;
    }

    public static string getPrefabID(string name)
    {
        return inverse.ContainsKey(name) ? inverse[name] : null;
    }

    public static string getPrefabIDByShortName(string name)
    {
        return shortName.ContainsKey(name) ? shortName[name] : null;
    }
}