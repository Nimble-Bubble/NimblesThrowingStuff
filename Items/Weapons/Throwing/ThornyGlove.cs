using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NimblesThrowingStuff.Items.Weapons.Throwing
{
	public class ThornyGlove : ModItem
	{
        public override void SetStaticDefaults()
        {
         Tooltip.SetDefault("Throws out poisonous seeds");   
        }

		public override void SetDefaults() 
		{
			item.damage = 54;
			item.thrown = true;
			item.width = 34;
			item.height = 34;
			item.useTime = 10;
			item.useAnimation = 10;
			item.useStyle = 1;
			item.knockBack = 3.6f;
            item.noMelee = true;
            item.noUseGraphic = true;
			item.value = Item.buyPrice(0, 36, 0, 0);
			item.rare = 7;
			item.UseSound = SoundID.Item5;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("PoisonSeedProj");
			item.shootSpeed = 12f;
            item.mana = 6;
		}
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
      int numberProjectiles = 1; 
			for (int i = 0; i < numberProjectiles; i++)
			{
				Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(20)); 
				Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
			}
			return false;
        }
	}
}