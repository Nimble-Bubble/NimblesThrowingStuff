using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.Audio;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;
using Terraria.ID;
using NimblesThrowingStuff.NPCs.Morilus;
using NimblesThrowingStuff.Items.Materials;
using System.Collections.Generic;
using Terraria.GameContent.Creative;

namespace NimblesThrowingStuff.Items.Consumables
{
	public class DeceptiveArtifact : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 3;
            ItemID.Sets.SortingPriorityBossSpawns[Item.type] = 13;
		}

		public override void SetDefaults()
		{
			Item.width = 48;
			Item.height = 48;
			Item.maxStack = 99;
			Item.value = Item.buyPrice(0, 25, 0, 0);
			Item.rare = ItemRarityID.Red;
			Item.useStyle = ItemUseStyleID.HoldUp;
			Item.useTime = 60;
			Item.useAnimation = 60;
			Item.useTurn = true;
			Item.autoReuse = false;
			Item.consumable = true;
		}
		public override bool CanUseItem(Player player)
		{
			return !NPC.AnyNPCs(ModContent.NPCType<MorilusMain>()) && player.ZoneSkyHeight;
		}
		public override bool? UseItem(Player player)
		{
			NPC.SpawnOnPlayer(player.whoAmI, ModContent.NPCType<MorilusMain>());
			SoundEngine.PlaySound(SoundID.Roar);

			return true;
		}
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.LunarBar, 10);
			recipe.AddIngredient(ModContent.ItemType<SoulOfTrite>(), 6);
			recipe.AddIngredient(ItemID.SoulofFlight, 6);
            recipe.AddIngredient(ItemID.SunplateBlock, 250);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.Register();
		}
	}
}
