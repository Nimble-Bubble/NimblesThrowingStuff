using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria.WorldBuilding;
using NimblesThrowingStuff.NPCs.Morilus;
using NimblesThrowingStuff.Items.Consumables;
using NimblesThrowingStuff.Items.Vanity;
using NimblesThrowingStuff.Items.Weapons.Melee;
using NimblesThrowingStuff.Items.Weapons.Ranged;
using NimblesThrowingStuff.Items.Weapons.Magic;
using NimblesThrowingStuff.Items.Weapons.Summoning;
using NimblesThrowingStuff.Items.Weapons.Throwing;
using NimblesThrowingStuff.Items.Placeables.Blocks;
using NimblesThrowingStuff.Items.Placeables.Furniture;
using static Terraria.ModLoader.ModContent;

namespace NimblesThrowingStuff
{
	public class NimblesThrowingStuff : Mod
	{
        public static NimblesThrowingStuff instance;

        public static ModKeybind MIGuardKey;
        
        

        public NimblesThrowingStuff()
        {
            GoreAutoloadingEnabled = true;
            ContentAutoloadingEnabled = true;
            //Properties = new ModProperties()
            // {
            //    Autoload = true,
            //    AutoloadSounds = true,
            //    AutoloadGores = true
            //};
        }
        public override void Load()
        {
            instance = this;
            MIGuardKey = KeybindLoader.RegisterKeybind(this, "Guard", "Z");
            //Chances are, a lot of players won't see this message. However, if you do, please note that the wiki is currently incomplete and outdated. You don't need to help, but if you want to, you can do so.
            ModLoader.TryGetMod("Wikithis", out Mod wikithis);
            if (wikithis != null && !Main.dedServ)
            {
                wikithis.Call("AddModURL", this, "https://terrariamods.fandom.com/wiki/Magnumiactus/{}");
            }
        }
        public override void Unload()
        {
            instance = null;
            MIGuardKey = null;
        }
        public override void PostSetupContent()
        {
        //Mod censusMod = ModLoader.GetMod("Census");
        //    if(censusMod != null)
        //    {
        //     censusMod.Call("TownNPCCondition", Find<ModNPC>("Living Relic").Type, "Defeat the Eye of Cthulhu");   
        //    }
        //Mod bossChecklist = ModLoader.GetMod("BossChecklist");
        //    if(bossChecklist != null)
        //    {
        //        bossChecklist.Call(
        //        "addBoss",
        //        15f,
        //        ModContent.NPCType<MorilusMain>(),
        //        this,
        //        "$Mods.NimblesThrowingStuff.NPCName.MorilusMain",
        //        (Func<bool>)(() => NimblesWorld.downedMorilus),
        //        ModContent.ItemType<DeceptiveArtifact>(),
        //        new List<int> { ModContent.ItemType<MorilusMask>(), ModContent.ItemType<MorilusTrophy>() },
        //        new List<int> { ModContent.ItemType<ProcellariteOre>(), ModContent.ItemType<SkyseaSpinner>(), ModContent.ItemType<ProcellariteLongbow>(), ModContent.ItemType<StormShot>(), ModContent.ItemType<LacusDecapitator>(), ModContent.ItemType<GuardianStaff>() },
        //        "Create a Deceptive Artifact and use it in space",
        //        "Morilus moves on to what it considers to be its next issue...");
//
        //    }

        }
        //private static ModRecipe GetNewRecipe() => new ModRecipe(ModContent.GetInstance<NimblesThrowingStuff>());
	}
}