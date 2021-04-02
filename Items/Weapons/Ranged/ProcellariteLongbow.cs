using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using NimblesThrowingStuff.Items.Materials;

namespace NimblesThrowingStuff.Items.Weapons.Ranged
{
	public class ProcellariteLongbow : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Pain Rain");
			Tooltip.SetDefault("Rains several arrows down from the heavens(?)");
		}

		public override void SetDefaults()
		{
			item.damage = 135;
			item.width = 40;
			item.height = 40;
			item.useTime = 14;
			item.useAnimation = 14;
			item.useStyle = 5;
			item.value = Item.buyPrice(1, 0, 0, 0);
			item.rare = 11;
			item.noMelee = true;
			item.useAmmo = AmmoID.Arrow;
			item.UseSound = SoundID.Item5;
			item.shoot = 1;
            item.knockBack = 6f;
			item.shootSpeed = 21f;
			item.ranged = true;
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			int numberProjectiles = 4 + Main.rand.Next(2);  //This defines how many projectiles to shot
			for (int index = 0; index < numberProjectiles; ++index)
			{
				Vector2 vector2_1 = new Vector2((float)(player.Center.X + (Main.rand.Next(201) * -player.direction) + Main.mouseX + Main.screenPosition.X - player.position.X), player.Center.Y - 600f);   //this defines the projectile width, direction and position
				vector2_1.X = ((vector2_1.X + player.Center.X) / 2f) + Main.rand.NextFloat(-200, 200);
				vector2_1.Y -= (float)(100 * index);
				float num12 = Main.mouseX + Main.screenPosition.X - vector2_1.X;
				float num13 = Main.mouseY + Main.screenPosition.Y - vector2_1.Y;
				if (num13 < 0f)
				{
					num13 *= -1f;
				}
				if (num13 < 20f)
				{
					num13 = 20f;
				}
				float num14 = new Vector2(num12, num13).Length();
				float num15 = item.shootSpeed / num14;
				float num16 = num12 * num15;
				float num17 = num13 * num15;
				float SpeedX = num16 + Main.rand.NextFloat(-40, 40) * 0.03f;  //this defines the projectile X position speed and randomnes
				float SpeedY = num17 + Main.rand.NextFloat(-40, 40) * 0.03f;  //this defines the projectile Y position speed and randomnes
				Projectile.NewProjectile(vector2_1.X, vector2_1.Y, SpeedX, SpeedY, type, damage, knockBack, Main.myPlayer, 0f, (float)Main.rand.Next(5));
			}
			return false;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<ProcellariteBar>(), 12);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}