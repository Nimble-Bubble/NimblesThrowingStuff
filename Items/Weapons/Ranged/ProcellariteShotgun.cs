using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using NimblesThrowingStuff.Items.Materials;
using NimblesThrowingStuff.Projectiles.Ranged;

namespace NimblesThrowingStuff.Items.Weapons.Ranged
{
	public class ProcellariteShotgun : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Storm Shotgun");
			Tooltip.SetDefault("Fires several bullets and one crystal at once");
		}

		public override void SetDefaults()
		{
			item.damage = 125;
			item.width = 40;
			item.height = 40;
			item.useTime = 30;
			item.useAnimation = 30;
			item.useStyle = 5;
			item.value = Item.buyPrice(1, 0, 0, 0);
			item.rare = 11;
			item.noMelee = true;
			item.useAmmo = AmmoID.Bullet;
			item.UseSound = SoundID.Item38;
			item.shoot = ProjectileID.Bullet;
            item.knockBack = 8f;
			item.shootSpeed = 16f;
			item.ranged = true;
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Projectile.NewProjectile(position.X, position.Y, speedX * 2, speedY * 2, ModContent.ProjectileType<ProcellariteShotgunProj>(), damage * 2, knockBack, player.whoAmI);
			int numberProjectiles = 6; 
			for (int i = 0; i < numberProjectiles; i++)
			{
				Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(15)); 
																												
																												
																												
				Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
			}
			return false;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<ProcellariteBar>(), 20);
			recipe.AddIngredient(ItemID.TacticalShotgun);
			recipe.AddIngredient(ItemID.OnyxBlaster);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}