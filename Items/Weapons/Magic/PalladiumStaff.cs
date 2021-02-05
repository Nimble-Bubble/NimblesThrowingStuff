using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace NimblesThrowingStuff.Items.Weapons.Magic
{
	public class PalladiumStaff : ModItem
	{
        public override void SetStaticDefaults()
		{
            Item.staff[item.type] = true;
		}

		public override void SetDefaults() 
		{
			item.damage = 32;
			item.magic = true;
			item.width = 24;
			item.height = 24;
			item.useTime = 11;
			item.useAnimation = 33;
			item.useStyle = 5;
			item.knockBack = 4.5f;
            item.noMelee = true;
			item.value = Item.buyPrice(0, 7, 50, 0);
			item.rare = 4;
			item.UseSound = SoundID.Item43;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("PalladiumBolt");
			item.shootSpeed = 5.5f;
            item.mana = 15;
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
				position = player.Center + new Vector2((-(float)Main.rand.Next(0, 11) * player.direction), +600f);
				position.Y += (100 * i);
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
				Projectile.NewProjectile(target.X, position.Y, speedX / 2, speedY * -1, type, damage, knockBack, player.whoAmI, 0f, ceilingLimit);
			}
			return false;
		}
		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(1184, 12);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}