using Terraria;
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
            ItemID.Sets.SortingPriorityBossSpawns[item.type] = 13;
			Tooltip.SetDefault("Provokes the guardians of the Sky's Sea despite its status");
		}

		public override void SetDefaults()
		{
			item.width = 14;
			item.height = 14;
			item.maxStack = 99;
			item.value = Item.buyPrice(0, 25, 0, 0);
			item.rare = 10;
			item.useStyle = 1;
			item.useTime = 60;
			item.useAnimation = 60;
			item.useTurn = true;
			item.autoReuse = false;
			item.consumable = true;
			item.useStyle = 4;
		}
		public override bool CanUseItem(Player player)
		{
			return !NPC.AnyNPCs(ModContent.NPCType<MorilusMain>());
		}
		public override bool UseItem(Player player)
		{
			NPC.SpawnOnPlayer(player.whoAmI, ModContent.NPCType<MorilusMain>());
            NPC.SpawnOnPlayer(player.whoAmI, ModContent.NPCType<SkySeaGuardian>());
            NPC.SpawnOnPlayer(player.whoAmI, ModContent.NPCType<SkySeaGuardian>());
            NPC.SpawnOnPlayer(player.whoAmI, ModContent.NPCType<SkySeaGuardian>());
            NPC.SpawnOnPlayer(player.whoAmI, ModContent.NPCType<SkySeaGuardian>());
			Main.PlaySound(15, (int)player.position.X, (int)player.position.Y);

			return true;
		}


		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.LunarBar, 10);
			recipe.AddIngredient(ModContent.ItemType<SoulOfTrite>(), 6);
			recipe.AddIngredient(575, 6);
            recipe.AddIngredient(824, 250);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
