using System;
using Terraria;
using Terraria.Audio;
using Terraria.ModLoader;
using Terraria.ID;
using NimblesThrowingStuff.NPCs.Morilus;
using NimblesThrowingStuff.Items.Materials;
using System.Collections.Generic;

namespace NimblesThrowingStuff.Items.Consumables
{
	public class DeceptiveArtifact : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Deceptive Artifact of the Sky's Sea");
            ItemID.Sets.SortingPriorityBossSpawns[Item.type] = 13;
			Tooltip.SetDefault("Provokes the guardians of the Sky's Sea despite its status");
		}

		public override void SetDefaults()
		{
			Item.width = 14;
			Item.height = 14;
			Item.maxStack = 99;
			Item.value = Item.buyPrice(0, 25, 0, 0);
			Item.rare = 10;
			Item.useStyle = 1;
			Item.useTime = 60;
			Item.useAnimation = 60;
			Item.useTurn = true;
			Item.autoReuse = false;
			Item.consumable = true;
			Item.useStyle = 4;
		}
		public override bool CanUseItem(Player player)
		{
			return !NPC.AnyNPCs(ModContent.NPCType<MorilusMain>());
		}
		//public override Nullable UseItem(Player player)
		//{
		//	NPC.SpawnOnPlayer(player.whoAmI, ModContent.NPCType<MorilusMain>());
        //    NPC.SpawnOnPlayer(player.whoAmI, ModContent.NPCType<SkySeaGuardian>());
         //   NPC.SpawnOnPlayer(player.whoAmI, ModContent.NPCType<SkySeaGuardian>());
        //    NPC.SpawnOnPlayer(player.whoAmI, ModContent.NPCType<SkySeaGuardian>());
        //    NPC.SpawnOnPlayer(player.whoAmI, ModContent.NPCType<SkySeaGuardian>());
		//	SoundEngine.PlaySound(15, (int)player.position.X, (int)player.position.Y);
//
		//	return null;
		//}


		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.LunarBar, 10);
			recipe.AddIngredient(ModContent.ItemType<SoulOfTrite>(), 6);
			recipe.AddIngredient(575, 6);
            recipe.AddIngredient(824, 250);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.Register();
		}
	}
}
