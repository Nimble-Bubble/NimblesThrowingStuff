using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NimblesThrowingStuff.Items.Weapons.Throwing
{
	public class SatelliteSpear : ModItem
	{
		public override void SetDefaults()
		{
			item.damage = 95;
			item.width = 36;
			item.height = 54;
			item.useTime = 45;
			item.useAnimation = 45;
			item.useStyle = 1;
			item.value = Item.buyPrice(1, 25, 0, 0);
			item.rare = 10;
			item.noMelee = true;
            item.noUseGraphic = true;
			item.mana = 30;
			item.UseSound = SoundID.Item1;
			item.shoot = mod.ProjectileType("SatelliteSpearEcho");
			item.shootSpeed = 12f;
            item.knockBack = 5f;
			item.thrown = true;
			item.autoReuse = true;
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("SatelliteSpearProj"), damage, knockBack, player.whoAmI);
            int numberProjectiles = 6; // 4 or 5 shots
			for (int i = 0; i < numberProjectiles; i++)
			{
				Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(15)); // 15 degree spread.
				// If you want to randomize the speed to stagger the projectiles
				// float scale = 1f - (Main.rand.NextFloat() * .3f);
				// perturbedSpeed = perturbedSpeed * scale; 
				Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage / 2, knockBack, player.whoAmI);
			}
			return false;
		}
	}
}