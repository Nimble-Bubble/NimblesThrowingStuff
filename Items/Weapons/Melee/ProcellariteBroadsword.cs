using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework;
using System;

namespace NimblesThrowingStuff.Items.Weapons.Melee
{
	public class ProcellariteBroadsword : ModItem
	{

		public override void SetDefaults() {
			item.damage = 340;
			item.useStyle = 1;
			item.useAnimation = 21;
			item.useTime = 4;
			item.knockBack = 8f;
			item.width = 90;
			item.height = 90;
			item.scale = 1.5f;
			item.rare = 11;
			item.value = Item.buyPrice(1, 0, 0, 0);
            item.melee = true;
            item.shoot = mod.ProjectileType("ProcellariteBroadswordProj");
            item.shootSpeed = 11f;
			item.UseSound = SoundID.Item1;
		}
        public override void MeleeEffects(Player player, Rectangle hitbox) 
        {
			if (Main.rand.NextBool(3)) 
            {
				int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 174);
			}
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 target = Main.screenPosition + new Vector2((float)Main.mouseX, (float)Main.mouseY);
			float ceilingLimit = target.Y;
			if (ceilingLimit > player.Center.Y - 200f)
			{
				ceilingLimit = player.Center.Y - 200f;
			}
			for (int i = 0; i < 1; i++)
			{
				position = player.Center + new Vector2((-(float)Main.rand.Next(0, 11) * player.direction), -600f);
				position.Y -= (100 * i);
				Vector2 heading = target - position;
				if (heading.Y < 0f)
				{
					heading.Y *= -1f;
				}
				if (heading.Y < 20f)
				{
					heading.Y = 20f;
				}
				heading.Normalize();
				heading *= new Vector2(speedX, speedY).Length();
				speedX = heading.X;
				speedY = heading.Y + Main.rand.Next(-40, 41) * 0.10f;
				Projectile.NewProjectile(target.X, position.Y, speedX / 2, speedY, type, damage / 2, knockBack, player.whoAmI, 0f, ceilingLimit);
			}
			return false;
		}
		public override void AddRecipes()
		{
			var recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("ProcellariteBar"), 12);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}