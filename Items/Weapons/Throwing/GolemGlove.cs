using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace NimblesThrowingStuff.Items.Weapons.Throwing
{
	public class GolemGlove : ModItem
	{
        public override void SetStaticDefaults()
        {
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
			// DisplayName.SetDefault("Golem's Glove");
         // Tooltip.SetDefault("Throws three balls of fire");   
        }

		public override void SetDefaults() 
		{
			Item.damage = 52;
			Item.DamageType = DamageClass.Throwing;
			Item.width = 26;
			Item.height = 28;
			Item.useTime = 28;
			Item.useAnimation = 28;
			Item.useStyle = 1;
			Item.knockBack = 5f;
            Item.noMelee = true;
            Item.noUseGraphic = true;
			Item.value = Item.buyPrice(0, 35, 0, 0);
			Item.rare = ItemRarityID.Yellow;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.shoot = Mod.Find<ModProjectile>("GolemFireProj").Type;
			Item.shootSpeed = 5f;
            Item.mana = 12;
		}
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
		{
      float numberProjectiles = 3; //making it an int messes up where the fireballs are headed
			float rotation = MathHelper.ToRadians(20);
			position += Vector2.Normalize(velocity) * 5f;
			for (int i = 0; i < numberProjectiles; i++)
			{
				Vector2 perturbedSpeed = velocity.RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * 2f; // Watch out for dividing by 0 if there is only 1 projectile.
				Projectile.NewProjectile(Item.GetSource_FromThis(), position, perturbedSpeed, type, damage, Item.knockBack, player.whoAmI);
			}
        }
	}
}