using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NimblesThrowingStuff.Items.Weapons.Ranged
{
	public class SporeSling : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Fires several stingers along with your arrow");
		}

		public override void SetDefaults()
		{
			item.damage = 17;
			item.width = 40;
			item.height = 40;
			item.useTime = 35;
			item.useAnimation = 35;
			item.useStyle = 5;
			item.value = Item.buyPrice(0, 2, 70, 0);
			item.rare = 2;
			item.noMelee = true;
			item.useAmmo = AmmoID.Arrow;
			item.UseSound = SoundID.Item5;
			item.shoot = 1;
            item.knockBack = 6f;
			item.shootSpeed = 7f;
			item.ranged = true;
		}
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, player.whoAmI);
            int numberProjectiles = 3; 
			for (int i = 0; i < numberProjectiles; i++)
			{
				Vector2 stingerSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(30)); // 15 degree spread.
				int stinger = Projectile.NewProjectile(position.X, position.Y, stingerSpeed.X, stingerSpeed.Y, ProjectileID.HornetStinger, damage / 3, knockBack, player.whoAmI);
                Main.projectile[stinger].minion = false;
                Main.projectile[stinger].ranged = true;
			}
			return false;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.JungleSpores, 12);
			recipe.AddIngredient(ItemID.Stinger, 12);
            recipe.AddIngredient(ItemID.Vine, 2);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}