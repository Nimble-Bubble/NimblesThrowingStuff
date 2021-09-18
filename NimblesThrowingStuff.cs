using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using NimblesThrowingStuff.NPCs.Morilus;
using NimblesThrowingStuff.Items.Consumables;
using NimblesThrowingStuff.Items.Vanity;
using NimblesThrowingStuff.Items.Placeables.Blocks;
using static Terraria.ModLoader.ModContent;

namespace NimblesThrowingStuff
{
	public class NimblesThrowingStuff : Mod
	{
        public static NimblesThrowingStuff instance;

        public NimblesThrowingStuff()
        {
            Properties = new ModProperties()
            {
                Autoload = true
            };
        }
        public override void Load()
        {
            instance = this;
        }
        public override void Unload()
        {
            instance = null;
        }
        public override void PostSetupContent()
        {
        Mod censusMod = ModLoader.GetMod("Census");
            if(censusMod != null)
            {
             censusMod.Call("TownNPCCondition", NPCType("Living Relic"), "Defeat the Eye of Cthulhu");   
            }
        Mod bossChecklist = ModLoader.GetMod("BossChecklist");
            if(bossChecklist != null)
            {
                bossChecklist.Call(
                "addBoss",
                15f,
                ModContent.NPCType<MorilusMain>(),
                this,
                "$Mods.NimblesThrowingStuff.NPCName.MorilusMain",
                (Func<bool>)(() => NimblesWorld.downedMorilus),
                ModContent.ItemType<DeceptiveArtifact>(),
                new List<int> { ModContent.ItemType<MorilusMask>() },
                new List<int> { ModContent.ItemType<ProcellariteOre>() },
                "Create a Deceptive Artifact and use it in space",
                "Morilus moves on to what it considers to be its next issue...");

            }

        }
        private static ModRecipe GetNewRecipe() => new ModRecipe(ModContent.GetInstance<NimblesThrowingStuff>());
        public override void AddRecipes()
        {
        ModRecipe recipe = GetNewRecipe();
        recipe.AddRecipeGroup("IronBar");
        recipe.AddTile(TileID.Anvils);
        recipe.SetResult(ItemID.MusketBall, 50);
        recipe.AddRecipe();
        }
	}
}