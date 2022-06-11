using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NimblesThrowingStuff.Items.Weapons.Ranged
{
	public class CopperPistol : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 7;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 36;
			Item.useAnimation = 36;
			Item.useStyle = 5;
			Item.value = Item.buyPrice(0, 0, 80, 0);
			Item.rare = 0;
			Item.noMelee = true;
			Item.useAmmo = AmmoID.Bullet;
			Item.UseSound = SoundID.Item11;
			Item.shoot = ProjectileID.Bullet;
            Item.knockBack = 2f;
			Item.shootSpeed = 6f;
			Item.DamageType = DamageClass.Ranged;
		}
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.CopperBar, 8);
			recipe.AddIngredient(ItemID.Amethyst, 8);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
        public override Vector2? HoldoutOffset()
		{
			return new Vector2(0, 4);
		}
	}
}