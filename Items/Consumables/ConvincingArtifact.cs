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
	public class ConvincingArtifact : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 3;
			// DisplayName.SetDefault("A More Convincing Artifact");
            ItemID.Sets.SortingPriorityBossSpawns[Item.type] = 13;
			/* Tooltip.SetDefault("A precious-looking work of art!"
				+"\nSummons Morilus, even if he is present already"
				+"\nUse it in space for the best results"); */
		}

		public override void SetDefaults()
		{
			Item.width = 14;
			Item.height = 14;
			Item.maxStack = 9999;
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
			ModLoader.TryGetMod("Fargowiltas", out Mod FargosMutant);
			if (FargosMutant != null)
			{
				Recipe recipe = CreateRecipe();
				recipe.AddIngredient(ModContent.ItemType<DeceptiveArtifact>(), 6);
				recipe.AddTile(TileID.WorkBenches);
				recipe.Register();
			}
		}
	}
}
