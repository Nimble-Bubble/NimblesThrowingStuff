using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NimblesThrowingStuff.Items.Weapons.Throwing
{
	public class SpookySpines : ModItem
	{
        public override void SetStaticDefaults()
        {
        DisplayName.SetDefault("Macabrazor");
         Tooltip.SetDefault("Hmm...This is familiar...");   
            Item.staff[item.type] = true;
        }

		public override void SetDefaults() 
		{
			item.damage = 48;
			item.thrown = true;
			item.width = 34;
			item.height = 34;
			item.useTime = 12;
			item.useAnimation = 12;
			item.useStyle = 5;
			item.knockBack = 3.25f;
            item.noMelee = true;
            item.noUseGraphic = false;
			item.value = Item.buyPrice(0, 45, 0, 0);
			item.rare = 8;
			item.UseSound = SoundID.Item5;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("SpookySpineProj");
			item.shootSpeed = 12f;
            item.mana = 5;
		}
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
      int numberProjectiles = 2 + Main.rand.Next(3); 
			for (int i = 0; i < numberProjectiles; i++)
			{
				Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(20)); 
				Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
			}
			return false;
        }
	}
}