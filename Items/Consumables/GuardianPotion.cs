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
using NimblesThrowingStuff.Buffs;

namespace NimblesThrowingStuff.Items.Consumables
{
	public class GuardianPotion : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 30;
			/* Tooltip.SetDefault("Reduced potion cooldown"
				+"\nDoesn't work that well with quick keys at the moment" +
				"\nUse it manually if you have to"); */
		}

		public override void SetDefaults()
		{
			Item.width = 20;
			Item.height = 34;
			Item.maxStack = 9999;
			Item.value = Item.buyPrice(0, 3, 0, 0);
			Item.rare = ItemRarityID.Lime;
			Item.useStyle = 9;
			Item.useTime = 17;
			Item.useAnimation = 17;
			Item.useTurn = true;
			Item.autoReuse = false;
			Item.consumable = true;
			Item.UseSound = SoundID.Item3;
			Item.buffType = ModContent.BuffType<GuardianPotionBuff>();
		}
		public override void OnConsumeItem(Player player)
		{
				player.AddBuff(Item.buffType, 28800);
		}
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe(3);
			recipe.AddIngredient(ItemID.BottledWater, 3);
			recipe.AddIngredient(ItemID.Moonglow, 3);
			recipe.AddIngredient(ItemID.ChlorophyteBar, 1);
			recipe.AddTile(13);
			recipe.Register();
		}
	}
}
