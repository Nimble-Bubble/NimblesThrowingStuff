using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NimblesThrowingStuff.Items.Weapons.Ranged
{
	public class NecroRepeater : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("A rapidly-firing crossbow");
		}

		public override void SetDefaults()
		{
			item.damage = 20;
			item.width = 40;
			item.height = 40;
			item.useTime = 14;
			item.useAnimation = 14;
			item.useStyle = 5;
			item.value = Item.buyPrice(0, 5, 0, 0);
			item.rare = 2;
			item.noMelee = true;
			item.useAmmo = AmmoID.Arrow;
			item.UseSound = SoundID.Item5;
			item.shoot = 1;
            item.knockBack = 5f;
			item.shootSpeed = 9f;
			item.ranged = true;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(154, 20);
			recipe.AddIngredient(150, 15);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}