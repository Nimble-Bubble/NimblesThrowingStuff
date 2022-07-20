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
			Item.damage = 88;
			Item.DamageType = DamageClass.Throwing;
			Item.width = 24;
			Item.height = 24;
			Item.useTime = 10;
			Item.useAnimation = 11;
			Item.useStyle = 1;
			Item.knockBack = 9f;
            Item.noMelee = true;
            Item.noUseGraphic = true;
			Item.value = Item.buyPrice(1, 25, 0, 0);
			Item.rare = 9;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = false;
			Item.shoot = Mod.Find<ModProjectile>("CosmosCrasherProj").Type;
			Item.shootSpeed = 21f;
            Item.mana = 18;
            Item.channel = true;
		}
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
		{
			Vector2 target = Main.screenPosition + new Vector2((float)Main.mouseX, (float)Main.mouseY);
			float ceilingLimit = target.Y;
			if (ceilingLimit > player.Center.Y - 200f)
			{
				ceilingLimit = player.Center.Y - 200f;
			}
			position = player.Center + new Vector2((-(float)Main.rand.Next(0, 11) * player.direction), -600f);
			position.Y -= 250;
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
			heading *= velocity.Length();
			velocity.X = heading.X;
			velocity.Y = heading.Y + Main.rand.Next(-40, 41) * 0.10f;
			position.X = target.X;
		}
	}
}