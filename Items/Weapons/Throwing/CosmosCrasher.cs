using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace NimblesThrowingStuff.Items.Weapons.Throwing
{
	public class CosmosCrasher : ModItem
	{

		public override void SetDefaults() 
		{
			item.damage = 88;
			item.thrown = true;
			item.width = 24;
			item.height = 24;
			item.useTime = 10;
			item.useAnimation = 11;
			item.useStyle = 1;
			item.knockBack = 9f;
            item.noMelee = true;
            item.noUseGraphic = true;
			item.value = Item.buyPrice(1, 25, 0, 0);
			item.rare = 9;
			item.UseSound = SoundID.Item1;
			item.autoReuse = false;
			item.shoot = mod.ProjectileType("CosmosCrasherProj");
			item.shootSpeed = 21f;
            item.mana = 18;
            item.channel = true;
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
				Projectile.NewProjectile(target.X, position.Y, speedX / 2, speedY, type, damage, knockBack, player.whoAmI, 0f, ceilingLimit);
			}
			return false;
		}
	}
}