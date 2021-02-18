using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NimblesThrowingStuff.Items.Weapons.Ranged
{
	public class TinPistol : ModItem
	{
		public override void SetDefaults()
		{
			item.damage = 8;
			item.width = 40;
			item.height = 40;
			item.useTime = 34;
			item.useAnimation = 34;
			item.useStyle = 5;
			item.value = Item.buyPrice(0, 1, 0, 0);
			item.rare = 0;
			item.noMelee = true;
			item.useAmmo = AmmoID.Bullet;
			item.UseSound = SoundID.Item11;
			item.shoot = ProjectileID.Bullet;
            item.knockBack = 2f;
			item.shootSpeed = 6.5f;
			item.ranged = true;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.TinBar, 8);
			recipe.AddIngredient(ItemID.Topaz, 8);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}