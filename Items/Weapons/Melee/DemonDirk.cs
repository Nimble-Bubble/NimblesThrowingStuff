using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework;
using System;

namespace NimblesThrowingStuff.Items.Weapons.Melee
{
	public class DemonDirk : ModItem
	{

		public override void SetDefaults() {
			item.damage = 15;
			item.useStyle = 3;
			item.useAnimation = 11;
			item.useTime = 11;
			item.knockBack = 5.5f;
			item.width = 36;
			item.height = 36;
			item.scale = 1.1f;
			item.rare = ItemRarityID.Blue;
			item.value = Item.sellPrice(silver: 27);
            item.melee = true;
			item.UseSound = SoundID.Item1;
		}
				public override void AddRecipes()
		{
			var recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.DemoniteBar, 8);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}