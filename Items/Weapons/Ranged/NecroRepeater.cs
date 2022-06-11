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
			Item.damage = 20;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 14;
			Item.useAnimation = 14;
			Item.useStyle = 5;
			Item.value = Item.buyPrice(0, 5, 0, 0);
			Item.rare = 2;
			Item.noMelee = true;
			Item.useAmmo = AmmoID.Arrow;
			Item.UseSound = SoundID.Item5;
			Item.shoot = 1;
            Item.knockBack = 5f;
			Item.shootSpeed = 9f;
			Item.DamageType = DamageClass.Ranged;
		}
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(154, 20);
			recipe.AddIngredient(150, 15);
			recipe.AddTile(TileID.WorkBenches);
			recipe.Register();
		}
	}
}