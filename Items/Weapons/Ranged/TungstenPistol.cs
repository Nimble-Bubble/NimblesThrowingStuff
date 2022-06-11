using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NimblesThrowingStuff.Items.Weapons.Ranged
{
	public class TungstenPistol : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 11;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 29;
			Item.useAnimation = 29;
			Item.useStyle = 5;
			Item.value = Item.buyPrice(0, 2, 0, 0);
			Item.rare = 1;
			Item.noMelee = true;
			Item.useAmmo = AmmoID.Bullet;
			Item.UseSound = SoundID.Item11;
			Item.shoot = ProjectileID.Bullet;
            Item.knockBack = 3f;
			Item.shootSpeed = 7.5f;
			Item.DamageType = DamageClass.Ranged;
		}
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.TungstenBar, 8);
			recipe.AddIngredient(ItemID.Emerald, 8);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
        public override Vector2? HoldoutOffset()
		{
			return new Vector2(0, 4);
		}
	}
}