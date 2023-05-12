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
	public class GreaterRestorationPotion : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 30;
			Tooltip.SetDefault("Reduced potion cooldown");
		}

		public override void SetDefaults()
		{
			Item.width = 14;
			Item.height = 14;
			Item.maxStack = 9999;
			Item.value = Item.buyPrice(0, 0, 60, 0);
			Item.rare = 5;
			Item.useStyle = 1;
			Item.useTime = 17;
			Item.useAnimation = 17;
			Item.useTurn = true;
			Item.autoReuse = false;
			Item.consumable = true;
			Item.useStyle = 2;
			Item.UseSound = SoundID.Item3;
			Item.buffType = BuffID.PotionSickness;
			Item.potion = true;
			Item.healMana = 270;
			Item.healLife = 135;
		}
		public override bool CanUseItem(Player player)
		{
			return !player.HasBuff(BuffID.PotionSickness);
		}
		public override bool? UseItem(Player player)
		{
			if (player.pStone)
			{
				player.AddBuff(Item.buffType, 2025);
			}
			else
			{
				player.AddBuff(Item.buffType, 2700);
			}

			return true;
		}
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe(5);
			recipe.AddIngredient(ItemID.RestorationPotion, 5);
			recipe.AddIngredient(ItemID.SoulofNight, 2);
			recipe.AddIngredient(ItemID.SoulofLight, 2);
			recipe.AddTile(13);
			recipe.Register();
		}
	}
}
