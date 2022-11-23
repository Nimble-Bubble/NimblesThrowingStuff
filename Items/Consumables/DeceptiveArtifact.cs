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
			DisplayName.SetDefault("Deceptive Artifact of the Sky's Sea");
            ItemID.Sets.SortingPriorityBossSpawns[Item.type] = 13;
			Tooltip.SetDefault("A precious-looking work of art, but not quite genuine"
				+"\nProvokes the great guardian of the Sky's Sea regardless"
				+"\nUse it as high as you can go for the best results");
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
			return !NPC.AnyNPCs(ModContent.NPCType<MorilusMain>()) && player.ZoneSkyHeight;
		}
		public override bool? UseItem(Player player)
		{
			NPC.SpawnOnPlayer(player.whoAmI, ModContent.NPCType<MorilusMain>());
            //NPC.SpawnOnPlayer(player.whoAmI, ModContent.NPCType<SkySeaGuardian>());
            //NPC.SpawnOnPlayer(player.whoAmI, ModContent.NPCType<SkySeaGuardian>());
            //NPC.SpawnOnPlayer(player.whoAmI, ModContent.NPCType<SkySeaGuardian>());
            //NPC.SpawnOnPlayer(player.whoAmI, ModContent.NPCType<SkySeaGuardian>());
			SoundEngine.PlaySound(SoundID.Roar);

			return true;
		}
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.LunarBar, 10);
			recipe.AddIngredient(ModContent.ItemType<SoulOfTrite>(), 6);
			recipe.AddIngredient(575, 6);
            recipe.AddIngredient(824, 250);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.Register();
		}
	}
}
