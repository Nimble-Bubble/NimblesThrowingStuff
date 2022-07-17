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
            Item.staff[Item.type] = true;
        }

		public override void SetDefaults() 
		{
			Item.damage = 48;
			Item.DamageType = DamageClass.Throwing;
			Item.width = 34;
			Item.height = 34;
			Item.useTime = 12;
			Item.useAnimation = 12;
			Item.useStyle = 5;
			Item.knockBack = 3.25f;
            Item.noMelee = true;
            Item.noUseGraphic = false;
			Item.value = Item.buyPrice(0, 45, 0, 0);
			Item.rare = 8;
			Item.UseSound = SoundID.Item5;
			Item.autoReuse = true;
			Item.shoot = Mod.Find<ModProjectile>("SpookySpineProj").Type;
			Item.shootSpeed = 12f;
            Item.mana = 5;
		}
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
		{
      int numberProjectiles = 2 + Main.rand.Next(2); 
			for (int i = 0; i < numberProjectiles; i++)
			{
				Vector2 perturbedSpeed = velocity.RotatedByRandom(MathHelper.ToRadians(20)); 
				Projectile.NewProjectile(Item.GetSource_FromThis(), position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, Item.knockBack, player.whoAmI);
			}
        }
	}
}