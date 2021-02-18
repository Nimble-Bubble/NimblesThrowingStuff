using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NimblesThrowingStuff.Items.Weapons.Ranged
{
	public class SilverPistol : ModItem
	{
		public override void SetDefaults()
		{
			item.damage = 10;
			item.width = 40;
			item.height = 40;
			item.useTime = 31;
			item.useAnimation = 31;
			item.useStyle = 5;
			item.value = Item.buyPrice(0, 1, 60, 0);
			item.rare = 1;
			item.noMelee = true;
			item.useAmmo = AmmoID.Bullet;
			item.UseSound = SoundID.Item11;
			item.shoot = ProjectileID.Bullet;
            item.knockBack = 3f;
			item.shootSpeed = 7f;
			item.ranged = true;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.SilverBar, 8);
			recipe.AddIngredient(ItemID.Sapphire, 8);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
        public override Vector2? HoldoutOffset()
		{
			return new Vector2(0, 4);
		}
	}
}