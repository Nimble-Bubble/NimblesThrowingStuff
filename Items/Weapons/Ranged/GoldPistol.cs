using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NimblesThrowingStuff.Items.Weapons.Ranged
{
	public class GoldPistol : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 12;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 26;
			Item.useAnimation = 26;
			Item.useStyle = 5;
			Item.value = Item.buyPrice(0, 2, 40, 0);
			Item.rare = 1;
			Item.noMelee = true;
			Item.useAmmo = AmmoID.Bullet;
			Item.UseSound = SoundID.Item11;
			Item.shoot = ProjectileID.Bullet;
            Item.knockBack = 4f;
			Item.shootSpeed = 8f;
			Item.DamageType = DamageClass.Ranged;
		}
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.GoldBar, 8);
			recipe.AddIngredient(ItemID.Ruby, 8);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.Register();
		}
        public override Vector2? HoldoutOffset()
		{
			return new Vector2(0, 4);
		}
	}
}